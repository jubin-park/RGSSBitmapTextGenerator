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
        public static IntPtr hSlotForm = IntPtr.Zero;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FontDialog1_Apply(object sender, EventArgs e)
        {
            SendFontSpec();
            SendText();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.Verb = "open";
            psi.FileName = @"preview\Game.exe";
            psi.Arguments = $"{this.Handle}";
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SendBitmapRect();
            JObject jsonObj = ReceivePacket();
            if (jsonObj == null)
            {
                return;
            }
        }

        private void TextboxText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            SendText();
            SendFontAColor();
        }

        private void ButtonFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                linkLabel1.Text = fontDialog1.Font.Name;
                label5.Text = Convert.ToInt32(fontDialog1.Font.Size + 0.5).ToString();
                if (fontDialog1.Font.Bold && fontDialog1.Font.Italic)
                {
                    label6.Font = new Font(label6.Font, FontStyle.Bold | FontStyle.Italic);
                    label6.Text = "굵은 기울임꼴";
                }
                else if (fontDialog1.Font.Bold)
                {
                    label6.Font = new Font(label6.Font, FontStyle.Bold);
                    label6.Text = "굵게";
                }
                else if (fontDialog1.Font.Italic)
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


        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabelFontColor.Text = $"{colorDialog1.Color.R}, {colorDialog1.Color.G}, {colorDialog1.Color.B}";
                SendFontRGBColor();
                SendText();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);
            MessageBox.Show($"글꼴 이름을 클립보드로 복사했습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLabelFontColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = $"{colorDialog1.Color.R}, {colorDialog1.Color.G}, {colorDialog1.Color.B}";
            if (numericUpDownAlpha.Value < 255)
            {
                s += $", {numericUpDownAlpha.Value}";
            }
            Clipboard.SetText(s);
            MessageBox.Show($"색상값을 클립보드로 복사했습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "png 파일로 저장";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "PNG Image|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Packet010(saveFileDialog1.FileName);
                saveFileDialog1.FileName = System.IO.Path.GetFileName(saveFileDialog1.FileName);
            }
        }

        private void NumericUpDownAlpha_ValueChanged(object sender, EventArgs e)
        {
            SendFontAColor();
            SendText();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            hSlotForm = Win32.CreateMailslot(Win32.MailSlotNameEditor, 0, Win32.MAILSLOT_WAIT_FOREVER, IntPtr.Zero);
            if (hSlotForm == (IntPtr)(Win32.INVALID_HANDLE_VALUE))
            {
                MessageBox.Show("메일슬롯 생성 실패", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Win32.CloseHandle(hSlotForm);
                this.Close();
                return;
            }
            textBoxText.KeyDown += new KeyEventHandler(this.TextboxText_KeyDown);
            this.Closing += new CancelEventHandler(FormMain_Closing);
            linkLabel1.Text = fontDialog1.Font.Name;
            linkLabelFontColor.Text = $"{colorDialog1.Color.R}, {colorDialog1.Color.G}, {colorDialog1.Color.B}";
            label5.Text = Convert.ToInt32(fontDialog1.Font.Size + 0.5).ToString();
            label6.Text = "보통";
            comboBoxAlignHorizontal.SelectedIndex = 0;
            comboBoxAlignVertical.SelectedIndex = 0;
            groupBox4.Enabled = false;
            Button2_Click(sender, e);
        }

        private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private JObject ReceivePacket()
        {
            Thread.Sleep(50);
            uint messageSize = 0;
            while (true)
            {
                Win32.GetMailslotInfo(hSlotForm, IntPtr.Zero, out messageSize, IntPtr.Zero, IntPtr.Zero);
                if (messageSize > 0 && messageSize < uint.MaxValue)
                {
                    break;
                }
                Application.DoEvents();
            }
            var buffer = new byte[messageSize];
            uint size = 0;
            IntPtr hRead = Win32.ReadFile(hSlotForm, buffer, messageSize, out size, IntPtr.Zero);
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
            jsonObj.Add("font_name", fontDialog1.Font.Name);
            jsonObj.Add("font_size", Convert.ToInt32(fontDialog1.Font.Size + 0.5f));
            jsonObj.Add("font_bold", fontDialog1.Font.Bold);
            jsonObj.Add("font_italic", fontDialog1.Font.Italic);
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
            jsonObj.Add("r", colorDialog1.Color.R);
            jsonObj.Add("g", colorDialog1.Color.G);
            jsonObj.Add("b", colorDialog1.Color.B);
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
            jsonObj.Add("r", colorDialog2.Color.R);
            jsonObj.Add("g", colorDialog2.Color.G);
            jsonObj.Add("b", colorDialog2.Color.B);
            SendPacket(jsonObj);
        }

        private void Packet010(string fileName)
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 10);
            jsonObj.Add("file_name", fileName);
            SendPacket(jsonObj);
        }

        private void SendBitmapRect()
        {
            JObject jsonObj = new JObject();
            jsonObj.Add("no", 11);
            jsonObj.Add("text", textBoxText.Text);
            SendPacket(jsonObj);
        }

        private void ComboBoxAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendAlignHorizontal();
        }

        private void ComboBoxAlignVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendAlignVertical();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                SendBackgroundRGBColor();
            }
        }

        private void checkBoxFixSize_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = checkBoxFixSize.Checked;
        }
    }
}