using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace RGSSBitmapTextGenerator
{
    public partial class FormMain : Form
    {
        public static IntPtr hSlotEditor = IntPtr.Zero;
        public static string varBitmapName = "my_bmp";
        public static string varFontName = "my_font";

        public FormMain()
        {
            InitializeComponent();
            hSlotEditor = Win32.CreateMailslot(Win32.MailSlotNameEditor, 0, Win32.MAILSLOT_WAIT_FOREVER, IntPtr.Zero);
            if (hSlotEditor == (IntPtr)(Win32.INVALID_HANDLE_VALUE))
            {
                MessageBox.Show("메일슬롯 생성 실패", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Win32.CloseHandle(hSlotEditor);
                this.Close();
                return;
            }
            numericUpDownAlpha.MouseWheel += new MouseEventHandler(Disable_MouseWheel);
            numericUpDownWidth.MouseWheel += new MouseEventHandler(Disable_MouseWheel);
            numericUpDownHeight.MouseWheel += new MouseEventHandler(Disable_MouseWheel);
            comboBoxAlignHorizontal.MouseWheel += new MouseEventHandler(Disable_MouseWheel);
            comboBoxAlignVertical.MouseWheel += new MouseEventHandler(Disable_MouseWheel);
            linkLabel1.Text = fontDialogInfo.Font.Name;
            linkLabelFontColor.Text = $"{colorDialogFont.Color.R}, {colorDialogFont.Color.G}, {colorDialogFont.Color.B}";
            label5.Text = Convert.ToInt32(fontDialogInfo.Font.Size + 0.5).ToString();
            label6.Text = "보통";
            comboBoxAlignHorizontal.SelectedIndex = 0;
            comboBoxAlignVertical.SelectedIndex = 0;
            groupBox4.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ButtonExecutePreview_Click(sender, e);
        }

        private void ButtonSaveAsPNG_Click(object sender, EventArgs e)
        {
            saveFileDialogPNG.Title = "png 파일로 저장";
            saveFileDialogPNG.OverwritePrompt = true;
            saveFileDialogPNG.Filter = "PNG Image|*.png";
            if (saveFileDialogPNG.ShowDialog() == DialogResult.OK)
            {
                Packet010(saveFileDialogPNG.FileName);
                saveFileDialogPNG.FileName = System.IO.Path.GetFileName(saveFileDialogPNG.FileName);
            }
        }

        private void ButtonExecutePreview_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.Verb = "open";
            psi.FileName = @"preview\Game.exe";
            psi.Arguments = $"{this.Handle}";
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void ButtonBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                SendBackgroundRGBColor();
            }
        }
        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            SendText();
            SendFontAColor();
        }

        private void ButtonChangeFont_Click(object sender, EventArgs e)
        {
            if (fontDialogInfo.ShowDialog() != DialogResult.Cancel)
            {
                linkLabel1.Text = fontDialogInfo.Font.Name;
                label5.Text = Convert.ToInt32(fontDialogInfo.Font.Size + 0.5).ToString();
                if (fontDialogInfo.Font.Bold && fontDialogInfo.Font.Italic)
                {
                    label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic);
                    label6.Text = "굵은 기울임꼴";
                }
                else if (fontDialogInfo.Font.Bold)
                {
                    label6.Font = new Font(label6.Font, FontStyle.Bold);
                    label6.Text = "굵게";
                }
                else if (fontDialogInfo.Font.Italic)
                {
                    label6.Font = new Font(label6.Font, FontStyle.Italic);
                    label6.Text = "기울임꼴";
                }
                else
                {
                    label6.Font = new Font(label6.Font, FontStyle.Regular);
                    label6.Text = "보통";
                }
                SendFontSpec();
                SendFontRGBColor();
                SendText();
            }
        }

        private void ButtonFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialogFont.ShowDialog() == DialogResult.OK)
            {
                linkLabelFontColor.Text = $"{colorDialogFont.Color.R}, {colorDialogFont.Color.G}, {colorDialogFont.Color.B}";
                SendFontRGBColor();
                SendText();
            }
        }

        private void ComboBoxAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendAlignHorizontal();
        }

        private void ComboBoxAlignVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendAlignVertical();
        }

        private void CheckBoxFixSize_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = checkBoxFixSize.Checked;
        }

        private void FontDialog1_Apply(object sender, EventArgs e)
        {
            SendFontSpec();
            SendText();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);
            MessageBox.Show($"글꼴 이름을 클립보드로 복사했습니다.\nCtrl+V 를 눌러 붙여넣으세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLabelFontColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = $"{colorDialogFont.Color.R}, {colorDialogFont.Color.G}, {colorDialogFont.Color.B}";
            if (numericUpDownAlpha.Value < 255)
            {
                s += $", {numericUpDownAlpha.Value}";
            }
            Clipboard.SetText(s);
            MessageBox.Show($"색상값을 클립보드로 복사했습니다.\nCtrl+V 를 눌러 붙여넣으세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NumericUpDownAlpha_ValueChanged(object sender, EventArgs e)
        {
            SendFontAColor();
            SendText();
        }

        private void Disable_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private JObject ReceivePacket()
        {
            Thread.Sleep(50);
            uint messageSize = 0;
            while (true)
            {
                Win32.GetMailslotInfo(hSlotEditor, IntPtr.Zero, out messageSize, IntPtr.Zero, IntPtr.Zero);
                if (messageSize > 0 && messageSize < uint.MaxValue)
                {
                    break;
                }
                Application.DoEvents();
            }
            var buffer = new byte[messageSize];
            uint size = 0;
            IntPtr hRead = Win32.ReadFile(hSlotEditor, buffer, messageSize, out size, IntPtr.Zero);
            if (hRead == IntPtr.Zero)
            {
                MessageBox.Show("버퍼 읽기 실패", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            string str = Encoding.UTF8.GetString(buffer);//.Replace("\0", string.Empty);
            return JObject.Parse(str);

        }

        private uint SendPacket(JObject jsonObj)
        {
            IntPtr hFile = Win32.CreateFile(Win32.MailSlotNamePreview, Win32.GENERIC_WRITE, Win32.FILE_SHARE_READ, IntPtr.Zero, Win32.OPEN_EXISTING, Win32.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            if (hFile == (IntPtr)Win32.INVALID_HANDLE_VALUE)
            {
                //MessageBox.Show("Client MailSlot에 접근하는데 실패했습니다.");
                return 0;
            }
            byte[] buffer = Encoding.UTF8.GetBytes(jsonObj.ToString(Newtonsoft.Json.Formatting.None));
            uint size;
            IntPtr hWrite = Win32.WriteFile(hFile, buffer, (uint)(buffer.Length), out size, IntPtr.Zero);
            if (hWrite == IntPtr.Zero)
            {
                MessageBox.Show("파일 쓰기 실패", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            return size;
        }

        private void SendFontSpec()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 1);
            jsonObj.Add("font_name", fontDialogInfo.Font.Name);
            jsonObj.Add("font_size", Convert.ToInt32(fontDialogInfo.Font.Size + 0.5f));
            jsonObj.Add("font_bold", fontDialogInfo.Font.Bold);
            jsonObj.Add("font_italic", fontDialogInfo.Font.Italic);
            SendPacket(jsonObj);
        }

        private void SendText()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 2);
            jsonObj.Add("text", textBoxText.Text);
            jsonObj.Add("fixed", checkBoxFixSize.Checked);
            if (checkBoxFixSize.Checked)
            {
                jsonObj.Add("width", numericUpDownWidth.Value);
                jsonObj.Add("height", numericUpDownHeight.Value);
            }
            SendPacket(jsonObj);
        }

        private void SendFontRGBColor()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 3);
            jsonObj.Add("r", colorDialogFont.Color.R);
            jsonObj.Add("g", colorDialogFont.Color.G);
            jsonObj.Add("b", colorDialogFont.Color.B);
            SendPacket(jsonObj);
        }

        private void SendFontAColor()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 4);
            jsonObj.Add("a", numericUpDownAlpha.Value);
            SendPacket(jsonObj);
        }

        private void SendAlignHorizontal()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 5);
            jsonObj.Add("align_h", comboBoxAlignHorizontal.SelectedIndex);
            SendPacket(jsonObj);
        }
        private void SendAlignVertical()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 6);
            jsonObj.Add("align_v", comboBoxAlignVertical.SelectedIndex);
            SendPacket(jsonObj);
        }

        private void SendBackgroundRGBColor()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 7);
            jsonObj.Add("r", colorDialogBackground.Color.R);
            jsonObj.Add("g", colorDialogBackground.Color.G);
            jsonObj.Add("b", colorDialogBackground.Color.B);
            SendPacket(jsonObj);
        }

        private void Packet010(string fileName)
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 10);
            jsonObj.Add("file_name", fileName);
            SendPacket(jsonObj);
        }

        private void SendBitmapRectRequest()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 11);
            jsonObj.Add("text", textBoxText.Text);
            SendPacket(jsonObj);
        }

        private void ButtonExtractScript_Click(object sender, EventArgs e)
        {
            SendBitmapRectRequest();
            JObject jsonObj = ReceivePacket();
            if (jsonObj == null)
            {
                return;
            }
            if ((int)jsonObj["no"] != 11)
            {
                return;
            }
            varFontName = Microsoft.VisualBasic.Interaction.InputBox("폰트 변수명을 입력하세요.", this.Text, varFontName);
            varBitmapName = Microsoft.VisualBasic.Interaction.InputBox("비트맵 변수명을 입력하세요.", this.Text, varBitmapName);

            string sName = $@"""{fontDialogInfo.Font.Name}""";
            string sSize = $"{Convert.ToInt32(fontDialogInfo.Font.Size + 0.5f)}";
            string sBold = $"{fontDialogInfo.Font.Bold.ToString().ToLower()}";
            string sItalic = $"{fontDialogInfo.Font.Italic.ToString().ToLower()}";
            string sColor = $"({colorDialogFont.Color.R}, {colorDialogFont.Color.G}, {colorDialogFont.Color.B}";
            if (numericUpDownAlpha.Value < 255)
            {
                sColor += $", {numericUpDownAlpha.Value}";
            }
            sColor += ")";

            int intSize = (int)jsonObj["size"];
            int intWidth = (int)jsonObj["width"];
            int intHeight = (int)jsonObj["height"];
            int intAlign = (int)jsonObj["align_h"];

            string sDefaultFont = $@"# 기본 폰트
Font.default_name = {sName}
Font.default_size = {sSize}
Font.default_bold = {sBold}
Font.default_italic = {sItalic}
Font.default_color.set{sColor}

";
            string sObjectFont = $@"# 폰트 개체
{varFontName} = Font.new
{varFontName}.name = {sName}
{varFontName}.size = {sSize}
{varFontName}.bold = {sBold}
{varFontName}.italic = {sItalic}
{varFontName}.color.set{sColor}

";
            string sBitmap1 = $@"# 비트맵 (폰트 개체 사용)
{varBitmapName} = Bitmap.new({intWidth}, {intHeight})
{varBitmapName}.font = {varFontName}

";
            string sBitmap2 = $@"# 비트맵
{varBitmapName} = Bitmap.new({intWidth}, {intHeight})
{varBitmapName}.font.name = {sName}
{varBitmapName}.font.size = {sSize}
{varBitmapName}.font.bold = {sBold}
{varBitmapName}.font.italic = {sItalic}
{varBitmapName}.font.color.set{sColor}

";
            string sDrawText = "";
            string sTextLength = "";
            if (intSize > 0)
            {
                JArray jArrayY = JArray.Parse(jsonObj["arr_y"].ToString());
                JArray jArrayRect = JArray.Parse(jsonObj["arr_rect"].ToString());
                string[] sStr = textBoxText.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);//.Replace("\r\n", "\n").Split('\n');

                sDrawText = "# draw_text 메서드\n";
                sTextLength = @"# 문자열 길이
# ""<문자열>""
# (너비, 높이)
";
                for (int i = 0; i < intSize; ++i)
                {
                    if (sStr[i] == "")
                    {
                        continue;
                    }
                    {
                        string s = $@"{varBitmapName}.draw_text(0, {jArrayY[i]}, {intWidth + 1}, {intHeight}, ""{sStr[i]}""";
                        if (intAlign != 0)
                        {
                            s += $", {intAlign}";
                        }
                        s += ")\n";
                        sDrawText += s;
                    }
                    {
                        string s = "\n" + $@"""{sStr[i]}""" + "\n" + $@"({jArrayRect[i * 2]}, {jArrayRect[i * 2 + 1]})" + "\n";
                        sTextLength += s;
                    }
                }
                sDrawText += "\n";
            }
            Clipboard.SetText(sDefaultFont + sObjectFont + sBitmap1 + sBitmap2 + sDrawText + sTextLength);
            MessageBox.Show("클립보드로 복사되었습니다.\nCtrl+V 를 눌러 붙여넣으세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}