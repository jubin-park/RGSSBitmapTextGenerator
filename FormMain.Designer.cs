namespace RGSSBitmapTextGenerator
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.fontDialogInfo = new System.Windows.Forms.FontDialog();
            this.buttonChangeFont = new System.Windows.Forms.Button();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.buttonExecutePreview = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.colorDialogFont = new System.Windows.Forms.ColorDialog();
            this.buttonFontColor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxAlignHorizontal = new System.Windows.Forms.ComboBox();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSaveAsPNG = new System.Windows.Forms.Button();
            this.saveFileDialogPNG = new System.Windows.Forms.SaveFileDialog();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabelFontColor = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxAlignVertical = new System.Windows.Forms.ComboBox();
            this.checkBoxFixSize = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // fontDialogInfo
            // 
            this.fontDialogInfo.AllowVerticalFonts = false;
            this.fontDialogInfo.Font = new System.Drawing.Font("돋움", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialogInfo.FontMustExist = true;
            this.fontDialogInfo.MaxSize = 96;
            this.fontDialogInfo.ShowApply = true;
            this.fontDialogInfo.ShowEffects = false;
            this.fontDialogInfo.Apply += new System.EventHandler(this.FontDialog1_Apply);
            // 
            // buttonChangeFont
            // 
            this.buttonChangeFont.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonChangeFont.Location = new System.Drawing.Point(151, 52);
            this.buttonChangeFont.Name = "buttonChangeFont";
            this.buttonChangeFont.Size = new System.Drawing.Size(60, 39);
            this.buttonChangeFont.TabIndex = 4;
            this.buttonChangeFont.Text = "변경";
            this.buttonChangeFont.UseVisualStyleBackColor = true;
            this.buttonChangeFont.Click += new System.EventHandler(this.ButtonChangeFont_Click);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(12, 325);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxText.Size = new System.Drawing.Size(217, 85);
            this.textBoxText.TabIndex = 0;
            this.textBoxText.Text = "Hello World !";
            // 
            // buttonExecutePreview
            // 
            this.buttonExecutePreview.Location = new System.Drawing.Point(12, 462);
            this.buttonExecutePreview.Name = "buttonExecutePreview";
            this.buttonExecutePreview.Size = new System.Drawing.Size(217, 37);
            this.buttonExecutePreview.TabIndex = 3;
            this.buttonExecutePreview.Text = "미리보기 실행";
            this.buttonExecutePreview.UseVisualStyleBackColor = true;
            this.buttonExecutePreview.Click += new System.EventHandler(this.ButtonExecutePreview_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(127, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "GetBuffer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDraw.Location = new System.Drawing.Point(12, 420);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(103, 36);
            this.buttonDraw.TabIndex = 1;
            this.buttonDraw.Text = "그리기";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // colorDialogFont
            // 
            this.colorDialogFont.Color = System.Drawing.Color.White;
            this.colorDialogFont.FullOpen = true;
            // 
            // buttonFontColor
            // 
            this.buttonFontColor.Location = new System.Drawing.Point(151, 24);
            this.buttonFontColor.Name = "buttonFontColor";
            this.buttonFontColor.Size = new System.Drawing.Size(60, 23);
            this.buttonFontColor.TabIndex = 5;
            this.buttonFontColor.Text = "글자색";
            this.buttonFontColor.UseVisualStyleBackColor = true;
            this.buttonFontColor.Click += new System.EventHandler(this.ButtonFontColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.buttonChangeFont);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 102);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "글꼴";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(46, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(61, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "효과";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(45, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "보통";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "크기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "이름";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "정렬";
            // 
            // comboBoxAlignHorizontal
            // 
            this.comboBoxAlignHorizontal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBoxAlignHorizontal.FormattingEnabled = true;
            this.comboBoxAlignHorizontal.Items.AddRange(new object[] {
            "왼쪽",
            "가운데",
            "오른쪽"});
            this.comboBoxAlignHorizontal.Location = new System.Drawing.Point(48, 73);
            this.comboBoxAlignHorizontal.MaxDropDownItems = 3;
            this.comboBoxAlignHorizontal.Name = "comboBoxAlignHorizontal";
            this.comboBoxAlignHorizontal.Size = new System.Drawing.Size(64, 20);
            this.comboBoxAlignHorizontal.TabIndex = 11;
            this.comboBoxAlignHorizontal.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAlign_SelectedIndexChanged);
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.Location = new System.Drawing.Point(59, 54);
            this.numericUpDownAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.Size = new System.Drawing.Size(41, 21);
            this.numericUpDownAlpha.TabIndex = 6;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownAlpha.ValueChanged += new System.EventHandler(this.NumericUpDownAlpha_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "Alpha";
            // 
            // buttonSaveAsPNG
            // 
            this.buttonSaveAsPNG.Location = new System.Drawing.Point(121, 420);
            this.buttonSaveAsPNG.Name = "buttonSaveAsPNG";
            this.buttonSaveAsPNG.Size = new System.Drawing.Size(108, 36);
            this.buttonSaveAsPNG.TabIndex = 2;
            this.buttonSaveAsPNG.Text = "png 파일로 저장";
            this.buttonSaveAsPNG.UseVisualStyleBackColor = true;
            this.buttonSaveAsPNG.Click += new System.EventHandler(this.ButtonSaveAsPNG_Click);
            // 
            // buttonBackgroundColor
            // 
            this.buttonBackgroundColor.Location = new System.Drawing.Point(151, 53);
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.buttonBackgroundColor.Size = new System.Drawing.Size(60, 23);
            this.buttonBackgroundColor.TabIndex = 7;
            this.buttonBackgroundColor.Text = "배경색";
            this.buttonBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.ButtonBackgroundColor_Click);
            // 
            // colorDialogBackground
            // 
            this.colorDialogBackground.FullOpen = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.linkLabelFontColor);
            this.groupBox2.Controls.Add(this.buttonBackgroundColor);
            this.groupBox2.Controls.Add(this.buttonFontColor);
            this.groupBox2.Controls.Add(this.numericUpDownAlpha);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 89);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "색상";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "RGB";
            // 
            // linkLabelFontColor
            // 
            this.linkLabelFontColor.AutoSize = true;
            this.linkLabelFontColor.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.linkLabelFontColor.LinkColor = System.Drawing.Color.Blue;
            this.linkLabelFontColor.Location = new System.Drawing.Point(56, 29);
            this.linkLabelFontColor.Name = "linkLabelFontColor";
            this.linkLabelFontColor.Size = new System.Drawing.Size(61, 12);
            this.linkLabelFontColor.TabIndex = 5;
            this.linkLabelFontColor.TabStop = true;
            this.linkLabelFontColor.Text = "linkLabel2";
            this.linkLabelFontColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelFontColor_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.comboBoxAlignVertical);
            this.groupBox3.Controls.Add(this.checkBoxFixSize);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.comboBoxAlignHorizontal);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 101);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "레이아웃";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "+";
            // 
            // comboBoxAlignVertical
            // 
            this.comboBoxAlignVertical.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBoxAlignVertical.FormattingEnabled = true;
            this.comboBoxAlignVertical.Items.AddRange(new object[] {
            "위",
            "가운데",
            "아래"});
            this.comboBoxAlignVertical.Location = new System.Drawing.Point(138, 73);
            this.comboBoxAlignVertical.MaxDropDownItems = 3;
            this.comboBoxAlignVertical.Name = "comboBoxAlignVertical";
            this.comboBoxAlignVertical.Size = new System.Drawing.Size(64, 20);
            this.comboBoxAlignVertical.TabIndex = 12;
            this.comboBoxAlignVertical.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAlignVertical_SelectedIndexChanged);
            // 
            // checkBoxFixSize
            // 
            this.checkBoxFixSize.AutoSize = true;
            this.checkBoxFixSize.Location = new System.Drawing.Point(12, 17);
            this.checkBoxFixSize.Name = "checkBoxFixSize";
            this.checkBoxFixSize.Size = new System.Drawing.Size(116, 16);
            this.checkBoxFixSize.TabIndex = 8;
            this.checkBoxFixSize.Text = "비트맵 크기 고정";
            this.checkBoxFixSize.UseVisualStyleBackColor = true;
            this.checkBoxFixSize.CheckedChanged += new System.EventHandler(this.CheckBoxFixSize_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDownHeight);
            this.groupBox4.Controls.Add(this.numericUpDownWidth);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(8, 18);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 46);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownHeight.Location = new System.Drawing.Point(146, 18);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(48, 21);
            this.numericUpDownHeight.TabIndex = 10;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownWidth.Location = new System.Drawing.Point(40, 18);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(48, 21);
            this.numericUpDownWidth.TabIndex = 9;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "높이";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "너비";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 509);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonSaveAsPNG);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.buttonExecutePreview);
            this.Controls.Add(this.textBoxText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGSS1 Bitmap Text Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonChangeFont;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Button buttonExecutePreview;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonDraw;
        protected System.Windows.Forms.FontDialog fontDialogInfo;
        private System.Windows.Forms.ColorDialog colorDialogFont;
        private System.Windows.Forms.Button buttonFontColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAlignHorizontal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonSaveAsPNG;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPNG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabelFontColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxFixSize;
        private System.Windows.Forms.ComboBox comboBoxAlignVertical;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
    }
}

