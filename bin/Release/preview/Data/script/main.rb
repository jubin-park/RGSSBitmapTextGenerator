require "star-input"
require "editor"
require "mailslot"
require "bitmap-text-preview"
require "win32api"
require "graphics"
require "bitmap-export"
require "set-window-text"
require "json"

Editor.init
Mailslot.init

Font.default_name = "돋움"
$preview = BitmapTextPreview.new
Graphics.resize_screen(640, 480)

loop do
  Mailslot.update
  Graphics.update
  Input.update
  Editor.update
end