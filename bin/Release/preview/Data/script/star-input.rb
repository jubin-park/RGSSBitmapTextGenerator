# 뷄귺긏긡귻긳렄궸귖벍띿똯뫏 (RGSS3)
#
# 럊궋뺴   : 벏뜪궻"StarInput.dll"귩긒??궴벏궣긲긅깑?궸뭫궖긚긏깏긵긣귩벑볺
#          : 뷠뾴궕궇귢궽긇긚??귽긛?뽞귩뺂뢜
#
# 딮뽵     : 궟렔뾕궸궵궎궪
#-------------------------------------------------------
# 12/07/14 VX붎귩댷륚갂뚺둎
#-------------------------------------------------------

module STARINPUT
# 긇긚??귽긛?뽞  ------------------------------------

  # DLL궻긲?귽깑뼹 ( .dll 궼듵귒귏궧귪갂DLL궻긲?귽깑뼹귩빾뛛궢궫뤾뜃궻귒빾뛛 )
DLLNAME = "StarInput"

# 긇긚??귽긛?뽞궞궞귏궳 -----------------------------
end

begin
  $starinput_e.call if $starinput_e
  $starinput = Win32API.new(STARINPUT::DLLNAME, '?start@@YGHPAUHWND__@@@Z', %w(l), 'l')
  $starinput_e = Win32API.new(STARINPUT::DLLNAME, '?end@@YGHXZ', %w(v), 'l')
rescue
  raise(LoadError, STARINPUT::DLLNAME + '.dll궕뙥궰궔귟귏궧귪')
  exit
end

module Input
  def self.sb_ini
    readini = Win32API.new('kernel32', 'GetPrivateProfileStringA', %w(p p p p l p), 'l')
    game_name = "\0" * 256
    readini.call("Game", "Title", "", game_name, 255, ".\\Game.ini")
    findwindow = Win32API.new('user32', 'FindWindowA', %w(p p), 'l')
    @hWnd = findwindow.call("RGSS Player", game_name)
    $starinput.call(@hWnd)
  end
  sb_ini
end