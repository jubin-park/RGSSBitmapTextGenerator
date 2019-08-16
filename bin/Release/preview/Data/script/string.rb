class String
	CP_UTF8 = 65001
	MultiByteToWideChar = Win32API.new('kernel32', 'MultiByteToWideChar', 'llplpl', 'l')
	WideCharToMultiByte = Win32API.new('kernel32', 'WideCharToMultiByte', 'llplplpp', 'l')

	def to_unicode
		len = MultiByteToWideChar.call(CP_UTF8, 0, self, -1, 0, 0) << 1
		buf = 0.chr * len
		MultiByteToWideChar.call(CP_UTF8, 0, self, -1, buf, len)
		return buf
	end

	def to_utf8
		len = WideCharToMultiByte.call(CP_UTF8, 0, self, -1, 0, 0, 0, 0)
		buf = 0.chr * len
		WideCharToMultiByte.call(CP_UTF8, 0, self, -1, buf, len, 0, 0)
		return buf
	end
end