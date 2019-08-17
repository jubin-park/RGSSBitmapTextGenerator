class BitmapTextPreview
	
	attr_reader :my_viewport
	attr_accessor :my_font
	attr_accessor :my_sprite
	attr_reader :my_bitmap
	attr_accessor :my_align_h
	attr_accessor :my_align_v

	def initialize
		@my_viewport = Viewport.new(0, 0, 640, 480)
		@my_sprite = Sprite.new
		@my_bitmap = Bitmap.new(1, 1)
		@my_font = Font.new
		@my_sprite.bitmap = @my_bitmap
		@my_align_h = 0
		@my_align_v = 0
	end

	def self.get_text_rect(font, text)
		bitmap = Bitmap.new(1, 1)
		bitmap.font = font
		rect = bitmap.text_size(text)
		bitmap.dispose
		return [rect.width, rect.height]
	end

	def self.get_arr_text_rect(font, arr_text)
		res = []
		for text in arr_text
			r = self.get_text_rect(font, text)
			res.push(r[0])
			res.push(r[1])
		end
		return res
	end

	def get_arr_y(arr_text)
		arr_y = []
		y = case @my_align_v
		when 0
			0
		when 1
			(height - @my_bitmap.font.size * arr_text.size) / 2
		when 2
			height - @my_bitmap.font.size * arr_text.size
		end
		h = @my_bitmap.font.size
		arr_text.size.times do |i|
			arr_y.push(y)
			y += h
		end
		return arr_y
	end

	def self.create_font_object(name, size, bold, italic)
		font = Font.new(name, size)
		font.bold = bold
		font.italic = italic
		font.color = Color.new(255, 255, 255)
		return font
	end

	def create_bitmap(width, height, arr_text)
		@my_bitmap.dispose unless @my_bitmap.disposed?
		return if width == 0 || height == 0
		@my_bitmap = Bitmap.new(width, height)
		@my_bitmap.font = @my_font
		y = case @my_align_v
		when 0
			0
		when 1
			(height - @my_bitmap.font.size * arr_text.size) / 2
		when 2
			height - @my_bitmap.font.size * arr_text.size
		end
		h = @my_bitmap.font.size
		for text in arr_text
			@my_bitmap.draw_text(0, y, width + 1, h, text, @my_align_h)
			y += h
		end
		@my_sprite.bitmap = @my_bitmap
	end

	def save_png(filename)
		return if @my_bitmap.disposed?
		@my_bitmap.save(filename)
	end
end