namespace ImageConverter
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            groupBox1 = new GroupBox();
            labelQuality = new Label();
            comboBoxQuality = new ComboBox();
            rbFormatPNG = new RadioButton();
            rbFormatBMP = new RadioButton();
            rbFormatJPG = new RadioButton();
            buttonConvert = new Button();
            listBoxImages = new ListBox();
            groupBox2 = new GroupBox();
            rbDim75 = new RadioButton();
            rbDim50 = new RadioButton();
            rbDim25 = new RadioButton();
            rbDimMaxWidthAndHeight = new RadioButton();
            rbDimFixedWidthAndHeight = new RadioButton();
            rbDimMaxHeight = new RadioButton();
            rbDimMaxWidth = new RadioButton();
            textBoxDimY = new TextBox();
            textBoxDimX = new TextBox();
            rbDimMegapixels = new RadioButton();
            rbDimFixedHeight = new RadioButton();
            rbDimFixedWidth = new RadioButton();
            rbDimNoChange = new RadioButton();
            textBoxOutputPath = new TextBox();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelQuality);
            groupBox1.Controls.Add(comboBoxQuality);
            groupBox1.Controls.Add(rbFormatPNG);
            groupBox1.Controls.Add(rbFormatBMP);
            groupBox1.Controls.Add(rbFormatJPG);
            groupBox1.Location = new Point(12, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 59);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Format";
            // 
            // labelQuality
            // 
            labelQuality.AutoSize = true;
            labelQuality.Location = new Point(190, 24);
            labelQuality.Name = "labelQuality";
            labelQuality.Size = new Size(48, 15);
            labelQuality.TabIndex = 6;
            labelQuality.Text = "Quality:";
            // 
            // comboBoxQuality
            // 
            comboBoxQuality.FormattingEnabled = true;
            comboBoxQuality.Items.AddRange(new object[] { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" });
            comboBoxQuality.Location = new Point(244, 21);
            comboBoxQuality.Name = "comboBoxQuality";
            comboBoxQuality.Size = new Size(68, 23);
            comboBoxQuality.TabIndex = 3;
            // 
            // rbFormatPNG
            // 
            rbFormatPNG.AutoSize = true;
            rbFormatPNG.Location = new Point(112, 22);
            rbFormatPNG.Name = "rbFormatPNG";
            rbFormatPNG.Size = new Size(49, 19);
            rbFormatPNG.TabIndex = 2;
            rbFormatPNG.Text = "PNG";
            rbFormatPNG.UseVisualStyleBackColor = true;
            rbFormatPNG.CheckedChanged += HandleOptionUpdate;
            // 
            // rbFormatBMP
            // 
            rbFormatBMP.AutoSize = true;
            rbFormatBMP.Location = new Point(56, 22);
            rbFormatBMP.Name = "rbFormatBMP";
            rbFormatBMP.Size = new Size(50, 19);
            rbFormatBMP.TabIndex = 1;
            rbFormatBMP.Text = "BMP";
            rbFormatBMP.UseVisualStyleBackColor = true;
            rbFormatBMP.CheckedChanged += HandleOptionUpdate;
            // 
            // rbFormatJPG
            // 
            rbFormatJPG.AutoSize = true;
            rbFormatJPG.Checked = true;
            rbFormatJPG.Location = new Point(6, 22);
            rbFormatJPG.Name = "rbFormatJPG";
            rbFormatJPG.Size = new Size(44, 19);
            rbFormatJPG.TabIndex = 0;
            rbFormatJPG.TabStop = true;
            rbFormatJPG.Text = "JPG";
            rbFormatJPG.UseVisualStyleBackColor = true;
            rbFormatJPG.CheckedChanged += HandleOptionUpdate;
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(443, 6);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(75, 23);
            buttonConvert.TabIndex = 1;
            buttonConvert.Text = "Convert";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // listBoxImages
            // 
            listBoxImages.AllowDrop = true;
            listBoxImages.FormattingEnabled = true;
            listBoxImages.ItemHeight = 15;
            listBoxImages.Items.AddRange(new object[] { "(drag and drop JPG, BMP, and/or PNG files here)" });
            listBoxImages.Location = new Point(336, 35);
            listBoxImages.Name = "listBoxImages";
            listBoxImages.Size = new Size(391, 244);
            listBoxImages.TabIndex = 3;
            listBoxImages.DragDrop += listBox1_DragDrop;
            listBoxImages.DragEnter += listBox1_DragEnter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbDim75);
            groupBox2.Controls.Add(rbDim50);
            groupBox2.Controls.Add(rbDim25);
            groupBox2.Controls.Add(rbDimMaxWidthAndHeight);
            groupBox2.Controls.Add(rbDimFixedWidthAndHeight);
            groupBox2.Controls.Add(rbDimMaxHeight);
            groupBox2.Controls.Add(rbDimMaxWidth);
            groupBox2.Controls.Add(textBoxDimY);
            groupBox2.Controls.Add(textBoxDimX);
            groupBox2.Controls.Add(rbDimMegapixels);
            groupBox2.Controls.Add(rbDimFixedHeight);
            groupBox2.Controls.Add(rbDimFixedWidth);
            groupBox2.Controls.Add(rbDimNoChange);
            groupBox2.Location = new Point(12, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 240);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dimensions";
            // 
            // rbDim75
            // 
            rbDim75.AutoSize = true;
            rbDim75.Location = new Point(222, 22);
            rbDim75.Name = "rbDim75";
            rbDim75.Size = new Size(47, 19);
            rbDim75.TabIndex = 12;
            rbDim75.Text = "75%";
            rbDim75.UseVisualStyleBackColor = true;
            rbDim75.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDim50
            // 
            rbDim50.AutoSize = true;
            rbDim50.Location = new Point(163, 22);
            rbDim50.Name = "rbDim50";
            rbDim50.Size = new Size(47, 19);
            rbDim50.TabIndex = 11;
            rbDim50.Text = "50%";
            rbDim50.UseVisualStyleBackColor = true;
            rbDim50.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDim25
            // 
            rbDim25.AutoSize = true;
            rbDim25.Location = new Point(104, 22);
            rbDim25.Name = "rbDim25";
            rbDim25.Size = new Size(47, 19);
            rbDim25.TabIndex = 10;
            rbDim25.Text = "25%";
            rbDim25.UseVisualStyleBackColor = true;
            rbDim25.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDimMaxWidthAndHeight
            // 
            rbDimMaxWidthAndHeight.AutoSize = true;
            rbDimMaxWidthAndHeight.Location = new Point(6, 197);
            rbDimMaxWidthAndHeight.Name = "rbDimMaxWidthAndHeight";
            rbDimMaxWidthAndHeight.Size = new Size(83, 19);
            rbDimMaxWidthAndHeight.TabIndex = 9;
            rbDimMaxWidthAndHeight.Text = "Max w && h";
            rbDimMaxWidthAndHeight.UseVisualStyleBackColor = true;
            rbDimMaxWidthAndHeight.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDimFixedWidthAndHeight
            // 
            rbDimFixedWidthAndHeight.AutoSize = true;
            rbDimFixedWidthAndHeight.Location = new Point(6, 97);
            rbDimFixedWidthAndHeight.Name = "rbDimFixedWidthAndHeight";
            rbDimFixedWidthAndHeight.Size = new Size(88, 19);
            rbDimFixedWidthAndHeight.TabIndex = 8;
            rbDimFixedWidthAndHeight.Text = "Fixed w && h";
            rbDimFixedWidthAndHeight.UseVisualStyleBackColor = true;
            rbDimFixedWidthAndHeight.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDimMaxHeight
            // 
            rbDimMaxHeight.AutoSize = true;
            rbDimMaxHeight.Location = new Point(6, 172);
            rbDimMaxHeight.Name = "rbDimMaxHeight";
            rbDimMaxHeight.Size = new Size(85, 19);
            rbDimMaxHeight.TabIndex = 7;
            rbDimMaxHeight.Text = "Max height";
            rbDimMaxHeight.UseVisualStyleBackColor = true;
            rbDimMaxHeight.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDimMaxWidth
            // 
            rbDimMaxWidth.AutoSize = true;
            rbDimMaxWidth.Location = new Point(6, 147);
            rbDimMaxWidth.Name = "rbDimMaxWidth";
            rbDimMaxWidth.Size = new Size(81, 19);
            rbDimMaxWidth.TabIndex = 6;
            rbDimMaxWidth.Text = "Max width";
            rbDimMaxWidth.UseVisualStyleBackColor = true;
            rbDimMaxWidth.CheckedChanged += HandleOptionUpdate;
            // 
            // textBoxDimY
            // 
            textBoxDimY.Location = new Point(179, 46);
            textBoxDimY.Name = "textBoxDimY";
            textBoxDimY.Size = new Size(62, 23);
            textBoxDimY.TabIndex = 5;
            // 
            // textBoxDimX
            // 
            textBoxDimX.Location = new Point(111, 46);
            textBoxDimX.Name = "textBoxDimX";
            textBoxDimX.Size = new Size(62, 23);
            textBoxDimX.TabIndex = 4;
            // 
            // rbDimMegapixels
            // 
            rbDimMegapixels.AutoSize = true;
            rbDimMegapixels.Location = new Point(6, 122);
            rbDimMegapixels.Name = "rbDimMegapixels";
            rbDimMegapixels.Size = new Size(85, 19);
            rbDimMegapixels.TabIndex = 3;
            rbDimMegapixels.Text = "Megapixels";
            rbDimMegapixels.UseVisualStyleBackColor = true;
            rbDimMegapixels.ClientSizeChanged += HandleOptionUpdate;
            // 
            // rbDimFixedHeight
            // 
            rbDimFixedHeight.AutoSize = true;
            rbDimFixedHeight.Location = new Point(6, 72);
            rbDimFixedHeight.Name = "rbDimFixedHeight";
            rbDimFixedHeight.Size = new Size(90, 19);
            rbDimFixedHeight.TabIndex = 2;
            rbDimFixedHeight.Text = "Fixed height";
            rbDimFixedHeight.UseVisualStyleBackColor = true;
            rbDimFixedHeight.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDimFixedWidth
            // 
            rbDimFixedWidth.AutoSize = true;
            rbDimFixedWidth.Location = new Point(6, 47);
            rbDimFixedWidth.Name = "rbDimFixedWidth";
            rbDimFixedWidth.Size = new Size(86, 19);
            rbDimFixedWidth.TabIndex = 1;
            rbDimFixedWidth.Text = "Fixed width";
            rbDimFixedWidth.UseVisualStyleBackColor = true;
            rbDimFixedWidth.CheckedChanged += HandleOptionUpdate;
            // 
            // rbDimNoChange
            // 
            rbDimNoChange.AutoSize = true;
            rbDimNoChange.Checked = true;
            rbDimNoChange.Location = new Point(6, 22);
            rbDimNoChange.Name = "rbDimNoChange";
            rbDimNoChange.Size = new Size(83, 19);
            rbDimNoChange.TabIndex = 0;
            rbDimNoChange.TabStop = true;
            rbDimNoChange.Text = "No change";
            rbDimNoChange.UseVisualStyleBackColor = true;
            rbDimNoChange.CheckedChanged += HandleOptionUpdate;
            // 
            // textBoxOutputPath
            // 
            textBoxOutputPath.Location = new Point(116, 6);
            textBoxOutputPath.Name = "textBoxOutputPath";
            textBoxOutputPath.Size = new Size(321, 23);
            textBoxOutputPath.TabIndex = 4;
            textBoxOutputPath.Text = "C:\\Users\\";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 5;
            label1.Text = "Output directory:";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 387);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(735, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 409);
            Controls.Add(statusStrip1);
            Controls.Add(label1);
            Controls.Add(textBoxOutputPath);
            Controls.Add(groupBox2);
            Controls.Add(listBoxImages);
            Controls.Add(buttonConvert);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Image Resizer";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            Resize += FormMain_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonConvert;
        private RadioButton rbFormatPNG;
        private RadioButton rbFormatBMP;
        private RadioButton rbFormatJPG;
        private ListBox listBoxImages;
        private GroupBox groupBox2;
        private RadioButton rbDimMegapixels;
        private RadioButton rbDimFixedHeight;
        private RadioButton rbDimFixedWidth;
        private RadioButton rbDimNoChange;
        private TextBox textBoxOutputPath;
        private Label label1;
        private ComboBox comboBoxQuality;
        private Label labelQuality;
        private ToolTip toolTip1;
        private TextBox textBoxDimY;
        private TextBox textBoxDimX;
        private RadioButton rbDimMaxHeight;
        private RadioButton rbDimMaxWidth;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private RadioButton rbDimFixedWidthAndHeight;
        private RadioButton rbDimMaxWidthAndHeight;
        private RadioButton rbDim75;
        private RadioButton rbDim50;
        private RadioButton rbDim25;
    }
}