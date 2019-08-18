require "string"

module Mailslot
	CreateMailslot = Win32API.new("kernel32", "CreateMailslotA", 'pllp', 'l')
	GetMailslotInfo = Win32API.new("kernel32", "GetMailslotInfo", 'llpll', 'l')
	CreateFile = Win32API.new("kernel32", "CreateFileA", "pllplll", "l")
	ReadFile = Win32API.new("kernel32", "ReadFile", "lplpp", "l")
	WriteFile = Win32API.new("kernel32", "WriteFile", "lplpl", "l")
	CloseHandle = Win32API.new("kernel32", "CloseHandle", "l", "l")

	INVALID_HANDLE_VALUE 	= -1
	MAILSLOT_WAIT_FOREVER = -1
	MAILSLOT_NO_MESSAGE	  = -1
	GENERIC_WRITE 			  = 0x40000000
	FILE_SHARE_READ 		  = 0x1
	OPEN_EXISTING 			  = 3
	FILE_ATTRIBUTE_NORMAL = 0x80

	MAILSLOT_NAME_EDITOR = "\\\\.\\mailslot\\editor"
	MAILSLOT_NAME_PREVIEW = "\\\\.\\mailslot\\preview"

	module_function

	def init
		undef_method :init
		@h_mail_client = CreateMailslot.call(MAILSLOT_NAME_PREVIEW, 0, MAILSLOT_WAIT_FOREVER, 0)
		if @h_mail_client == INVALID_HANDLE_VALUE
			#print "메일 슬롯 생성 실패"
			CloseHandle.call(@h_mail_client)
			exit
		end
	end

	def send_byte(str)
		h_file = CreateFile.call(MAILSLOT_NAME_EDITOR, GENERIC_WRITE, FILE_SHARE_READ, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0)
		if h_file == INVALID_HANDLE_VALUE
			print MAILSLOT_NAME_EDITOR + "를 생성하는데 실패하였습니다."
			CloseHandle.call(h_file)
			return 0
		end
		size = [0].pack("l")
		return WriteFile.call(h_file, str, str.size, size, 0)
	end

	def recv_byte
		size = [0].pack("l")
		GetMailslotInfo.call(@h_mail_client, 0, size, 0, 0)
		size = size.unpack("I*").to_s.to_i
		return nil if size <= 0 || size >= 1 << 31 - 1
		buf = 0.chr * size
		lngBytesRead = [0].pack("l")
		hRead = ReadFile.call(@h_mail_client, buf, size, lngBytesRead, 0)
		return buf.delete(0.chr)
	end

	def update
		recv = Mailslot.recv_byte
		return if recv.nil?
		recv = Json.decode(recv)
		case recv["no"].to_i
		when 1
			$preview.my_font = BitmapTextPreview.create_font_object(recv["font_name"], recv["font_size"], recv["font_bold"], recv["font_italic"])
		when 2
			arr_text = recv["text"].split("\\r\\n")
			if recv["fixed"]
				width = recv["width"].to_i
				height = recv["height"].to_i
				$preview.create_bitmap(width, height, arr_text)
			else
				width = 0
				height = $preview.my_font.size * arr_text.size
				for t in arr_text
					rect = BitmapTextPreview.get_text_rect($preview.my_font, t)
					if width < rect[0]
						width = rect[0]
					end
				end
				$preview.create_bitmap(width, height, arr_text)
			end
			return if width == 0 || height == 0
			Graphics.only_resize_screen(width, height)
			WindowText.set("Preview ( #{width} x #{height} )")
			$preview.my_viewport.rect.set(0, 0, width, height)
		when 3
			$preview.my_font.color.red = recv["r"].to_i
			$preview.my_font.color.green = recv["g"].to_i
			$preview.my_font.color.blue = recv["b"].to_i
		when 4
			$preview.my_font.color.alpha = recv["a"].to_i
		when 5
			$preview.my_align_h = recv["align_h"].to_i
		when 6
			$preview.my_align_v = recv["align_v"].to_i
		when 7
			$preview.my_viewport.color.set(recv["r"].to_i, recv["g"].to_i, recv["b"].to_i)
		when 10 # save png
			$preview.save_png(recv["file_name"])
		when 11 # rect request
			return if $preview.my_bitmap.disposed?
			arr_text = recv["text"].split("\\r\\n")
			json = Json.encode(
				{
					"no" => 11,
					"arr_y" => $preview.get_arr_y(arr_text),
					"width" => $preview.my_bitmap.width,
					"height" => $preview.my_bitmap.height,
					"align_h" => $preview.my_align_h,
					"arr_rect" => BitmapTextPreview.get_arr_text_rect($preview.my_font, arr_text),
					"count" => arr_text.size,
					"font_name" => $preview.my_font.name,
					"font_size" => $preview.my_font.size,
					"font_bold" => $preview.my_font.bold,
					"font_italic" => $preview.my_font.italic,
					"r" => $preview.my_font.color.red,
					"g" => $preview.my_font.color.green,
					"b" => $preview.my_font.color.blue,
					"a" => $preview.my_font.color.alpha
				}
			)
			Mailslot.send_byte(json)
		end
	end
end
