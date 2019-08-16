module Graphics
  SWP_NOMOVE         = 0x0002
  SWP_NOSIZE         = 0x0001
  SWP_NOZORDER       = 0x0004
  SWP_FRAMECHANGED   = 0x0020
  WS_EX_DLGMODALFRAME = 0x00000001
  WS_EX_TOOLWINDOW = 0x00000080
  WS_MAXIMIZEBOX = 0x00010000
  WS_MINIMIZEBOX = 0x00020000
  WS_SYSMENU = 0x00080000
  WM_SETICON = 0x0080
  MOD_ALT = 0x0001
  VK_RETURN = 0x0D
  VK_F1 = 0x70

  def self.resize_screen(width, height)
    hwnd = Win32API.get_hwnd
    win_style = Win32API::GetWindowLong.call(hwnd, Win32API::GWL_STYLE)
    screen_rect = Win32API.get_rect_of_screen
    window_rect = Win32API.get_rect_of_adjust_window(width, height, win_style)
    taskbar_rect = Win32API.get_rect_of_taskbar
    Win32API::SetWindowLong.call(hwnd, Win32API::GWL_STYLE, win_style & ~(WS_SYSMENU))
    x = screen_rect.width - window_rect.width + window_rect.x
    x -= taskbar_rect.width if screen_rect.width != taskbar_rect.width
    y = screen_rect.height - window_rect.height + window_rect.y
    y -= taskbar_rect.height if screen_rect.height != taskbar_rect.height
    Win32API::SetWindowPos.call(hwnd, Win32API::HWND_TOP, x / 2, y / 2, window_rect.width - window_rect.x, window_rect.height - window_rect.y, Win32API::SWP_SHOWWINDOW)
    Win32API::RegisterHotKey.call(hwnd, 0, MOD_ALT, VK_RETURN)
    Win32API::RegisterHotKey.call(hwnd, 0, 0, VK_F1)
    Win32API::SetWindowPos.call(hwnd, 0, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED)
  end

  def self.only_resize_screen(width, height)
    hwnd = Win32API.get_hwnd
    win_style = Win32API::GetWindowLong.call(hwnd, Win32API::GWL_STYLE)
    window_rect = Win32API.get_rect_of_adjust_window(width, height, win_style)
    Win32API::SetWindowPos.call(hwnd, 0, 0, 0, window_rect.width - window_rect.x, window_rect.height - window_rect.y, SWP_NOMOVE | SWP_NOZORDER)
  end

  def self.move_screen(x, y)
    hwnd = Win32API.get_hwnd
    Win32API::SetWindowPos.call(hwnd, 0, x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER)
  end
end