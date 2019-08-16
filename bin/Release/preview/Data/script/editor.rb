module Editor
	GetCommandLine = Win32API.new("Kernel32", "GetCommandLineA", "v", "p")
	IsWindow = Win32API.new("user32", "IsWindow", "l", "l")

	@hwnd = 0

	module_function

	def init
		undef_method :init
		@hwnd = get_hwnd
		if @hwnd == 0
			exit
		end
	end

	def get_hwnd
		if GetCommandLine.call =~ /\"(.*)\" (\d+)/
			return $2.to_i
		end
	end

	def update
		if IsWindow.call(@hwnd) == 0
			exit
		end
		r = Win32API.get_rect_of_window(Editor.get_hwnd)
		Graphics.move_screen(r[2], r[1])
	end
end