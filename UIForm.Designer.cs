namespace ADesktop
{
    partial class UIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIForm));
            this.buttonApply = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonStretch = new System.Windows.Forms.RadioButton();
            this.radioButtonActualSize = new System.Windows.Forms.RadioButton();
            this.radioButtonTile = new System.Windows.Forms.RadioButton();
            this.radioButtonManual = new System.Windows.Forms.RadioButton();
            this.buttonSelectPictures = new System.Windows.Forms.Button();
            this.radioButtonAuto = new System.Windows.Forms.RadioButton();
            this.radioButtonConsecutively = new System.Windows.Forms.RadioButton();
            this.radioButtonRandom = new System.Windows.Forms.RadioButton();
            this.groupBoxChangePicture = new System.Windows.Forms.GroupBox();
            this.radioButtonFrequency = new System.Windows.Forms.RadioButton();
            this.groupBoxFrequencyChange = new System.Windows.Forms.GroupBox();
            this.labelMinute = new System.Windows.Forms.Label();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.labelHour = new System.Windows.Forms.Label();
            this.numericUpDownHour = new System.Windows.Forms.NumericUpDown();
            this.radioButtonByLoad = new System.Windows.Forms.RadioButton();
            this.groupBoxPositionPicture = new System.Windows.Forms.GroupBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNumberFiles = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxChangePicture.SuspendLayout();
            this.groupBoxFrequencyChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).BeginInit();
            this.groupBoxPositionPicture.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(12, 274);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(76, 26);
            this.buttonApply.TabIndex = 8;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonStretch
            // 
            this.radioButtonStretch.AutoSize = true;
            this.radioButtonStretch.Location = new System.Drawing.Point(26, 24);
            this.radioButtonStretch.Name = "radioButtonStretch";
            this.radioButtonStretch.Size = new System.Drawing.Size(103, 30);
            this.radioButtonStretch.TabIndex = 7;
            this.radioButtonStretch.Tag = "5";
            this.radioButtonStretch.Text = "Подогнать под \r\nразмер экрана";
            this.radioButtonStretch.UseVisualStyleBackColor = true;
            this.radioButtonStretch.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // radioButtonActualSize
            // 
            this.radioButtonActualSize.AutoSize = true;
            this.radioButtonActualSize.Checked = true;
            this.radioButtonActualSize.Location = new System.Drawing.Point(26, 51);
            this.radioButtonActualSize.Name = "radioButtonActualSize";
            this.radioButtonActualSize.Size = new System.Drawing.Size(117, 17);
            this.radioButtonActualSize.TabIndex = 7;
            this.radioButtonActualSize.TabStop = true;
            this.radioButtonActualSize.Tag = "6";
            this.radioButtonActualSize.Text = "Реальный размер";
            this.radioButtonActualSize.UseVisualStyleBackColor = true;
            this.radioButtonActualSize.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // radioButtonTile
            // 
            this.radioButtonTile.AutoSize = true;
            this.radioButtonTile.Location = new System.Drawing.Point(26, 74);
            this.radioButtonTile.Name = "radioButtonTile";
            this.radioButtonTile.Size = new System.Drawing.Size(124, 17);
            this.radioButtonTile.TabIndex = 7;
            this.radioButtonTile.Tag = "7";
            this.radioButtonTile.Text = "Замостить плиткой";
            this.radioButtonTile.UseVisualStyleBackColor = true;
            this.radioButtonTile.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // radioButtonManual
            // 
            this.radioButtonManual.AutoSize = true;
            this.radioButtonManual.Checked = true;
            this.radioButtonManual.Location = new System.Drawing.Point(26, 27);
            this.radioButtonManual.Name = "radioButtonManual";
            this.radioButtonManual.Size = new System.Drawing.Size(70, 17);
            this.radioButtonManual.TabIndex = 1;
            this.radioButtonManual.TabStop = true;
            this.radioButtonManual.Tag = "1";
            this.radioButtonManual.Text = "В ручную";
            this.radioButtonManual.UseVisualStyleBackColor = true;
            this.radioButtonManual.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // buttonSelectPictures
            // 
            this.buttonSelectPictures.Location = new System.Drawing.Point(26, 76);
            this.buttonSelectPictures.Name = "buttonSelectPictures";
            this.buttonSelectPictures.Size = new System.Drawing.Size(105, 23);
            this.buttonSelectPictures.TabIndex = 2;
            this.buttonSelectPictures.Text = "Выбрать файл";
            this.buttonSelectPictures.UseVisualStyleBackColor = true;
            this.buttonSelectPictures.Click += new System.EventHandler(this.buttonSelectPictures_Click);
            // 
            // radioButtonAuto
            // 
            this.radioButtonAuto.AutoSize = true;
            this.radioButtonAuto.Location = new System.Drawing.Point(26, 46);
            this.radioButtonAuto.Name = "radioButtonAuto";
            this.radioButtonAuto.Size = new System.Drawing.Size(103, 17);
            this.radioButtonAuto.TabIndex = 3;
            this.radioButtonAuto.Tag = "2";
            this.radioButtonAuto.Text = "Автоматически";
            this.radioButtonAuto.UseVisualStyleBackColor = true;
            this.radioButtonAuto.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // radioButtonConsecutively
            // 
            this.radioButtonConsecutively.AutoSize = true;
            this.radioButtonConsecutively.Checked = true;
            this.radioButtonConsecutively.Location = new System.Drawing.Point(24, 27);
            this.radioButtonConsecutively.Name = "radioButtonConsecutively";
            this.radioButtonConsecutively.Size = new System.Drawing.Size(116, 17);
            this.radioButtonConsecutively.TabIndex = 7;
            this.radioButtonConsecutively.TabStop = true;
            this.radioButtonConsecutively.Tag = "3";
            this.radioButtonConsecutively.Text = "Последовательно";
            this.radioButtonConsecutively.UseVisualStyleBackColor = true;
            this.radioButtonConsecutively.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // radioButtonRandom
            // 
            this.radioButtonRandom.AutoSize = true;
            this.radioButtonRandom.Location = new System.Drawing.Point(24, 50);
            this.radioButtonRandom.Name = "radioButtonRandom";
            this.radioButtonRandom.Size = new System.Drawing.Size(115, 17);
            this.radioButtonRandom.TabIndex = 7;
            this.radioButtonRandom.Tag = "4";
            this.radioButtonRandom.Text = "Случайный выбор";
            this.radioButtonRandom.UseVisualStyleBackColor = true;
            this.radioButtonRandom.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // groupBoxChangePicture
            // 
            this.groupBoxChangePicture.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxChangePicture.Controls.Add(this.radioButtonRandom);
            this.groupBoxChangePicture.Controls.Add(this.radioButtonConsecutively);
            this.groupBoxChangePicture.Location = new System.Drawing.Point(519, 37);
            this.groupBoxChangePicture.Name = "groupBoxChangePicture";
            this.groupBoxChangePicture.Size = new System.Drawing.Size(163, 107);
            this.groupBoxChangePicture.TabIndex = 5;
            this.groupBoxChangePicture.TabStop = false;
            this.groupBoxChangePicture.Text = "Метод смены";
            // 
            // radioButtonFrequency
            // 
            this.radioButtonFrequency.AutoSize = true;
            this.radioButtonFrequency.Location = new System.Drawing.Point(24, 51);
            this.radioButtonFrequency.Name = "radioButtonFrequency";
            this.radioButtonFrequency.Size = new System.Drawing.Size(57, 17);
            this.radioButtonFrequency.TabIndex = 7;
            this.radioButtonFrequency.Tag = "9";
            this.radioButtonFrequency.Text = "Через";
            this.radioButtonFrequency.UseVisualStyleBackColor = true;
            this.radioButtonFrequency.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // groupBoxFrequencyChange
            // 
            this.groupBoxFrequencyChange.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxFrequencyChange.Controls.Add(this.labelMinute);
            this.groupBoxFrequencyChange.Controls.Add(this.numericUpDownMin);
            this.groupBoxFrequencyChange.Controls.Add(this.labelHour);
            this.groupBoxFrequencyChange.Controls.Add(this.numericUpDownHour);
            this.groupBoxFrequencyChange.Controls.Add(this.radioButtonByLoad);
            this.groupBoxFrequencyChange.Controls.Add(this.radioButtonFrequency);
            this.groupBoxFrequencyChange.Location = new System.Drawing.Point(519, 150);
            this.groupBoxFrequencyChange.Name = "groupBoxFrequencyChange";
            this.groupBoxFrequencyChange.Size = new System.Drawing.Size(163, 107);
            this.groupBoxFrequencyChange.TabIndex = 6;
            this.groupBoxFrequencyChange.TabStop = false;
            this.groupBoxFrequencyChange.Text = "Частота смены";
            this.groupBoxFrequencyChange.UseCompatibleTextRendering = true;
            // 
            // labelMinute
            // 
            this.labelMinute.AutoSize = true;
            this.labelMinute.Location = new System.Drawing.Point(127, 82);
            this.labelMinute.Name = "labelMinute";
            this.labelMinute.Size = new System.Drawing.Size(27, 13);
            this.labelMinute.TabIndex = 9;
            this.labelMinute.Text = "мин";
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.Location = new System.Drawing.Point(86, 78);
            this.numericUpDownMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownMin.TabIndex = 8;
            this.numericUpDownMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMin.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelHour
            // 
            this.labelHour.AutoSize = true;
            this.labelHour.Location = new System.Drawing.Point(59, 82);
            this.labelHour.Name = "labelHour";
            this.labelHour.Size = new System.Drawing.Size(24, 13);
            this.labelHour.TabIndex = 9;
            this.labelHour.Text = "час";
            // 
            // numericUpDownHour
            // 
            this.numericUpDownHour.Location = new System.Drawing.Point(14, 78);
            this.numericUpDownHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDownHour.Name = "numericUpDownHour";
            this.numericUpDownHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownHour.TabIndex = 8;
            this.numericUpDownHour.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // radioButtonByLoad
            // 
            this.radioButtonByLoad.AutoSize = true;
            this.radioButtonByLoad.Checked = true;
            this.radioButtonByLoad.Location = new System.Drawing.Point(24, 31);
            this.radioButtonByLoad.Name = "radioButtonByLoad";
            this.radioButtonByLoad.Size = new System.Drawing.Size(92, 17);
            this.radioButtonByLoad.TabIndex = 7;
            this.radioButtonByLoad.TabStop = true;
            this.radioButtonByLoad.Tag = "8";
            this.radioButtonByLoad.Text = "при загрузке";
            this.radioButtonByLoad.UseVisualStyleBackColor = true;
            this.radioButtonByLoad.Click += new System.EventHandler(this.radioButtons_Click);
            // 
            // groupBoxPositionPicture
            // 
            this.groupBoxPositionPicture.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxPositionPicture.Controls.Add(this.radioButtonTile);
            this.groupBoxPositionPicture.Controls.Add(this.radioButtonStretch);
            this.groupBoxPositionPicture.Controls.Add(this.radioButtonActualSize);
            this.groupBoxPositionPicture.Location = new System.Drawing.Point(348, 150);
            this.groupBoxPositionPicture.Name = "groupBoxPositionPicture";
            this.groupBoxPositionPicture.Size = new System.Drawing.Size(163, 107);
            this.groupBoxPositionPicture.TabIndex = 7;
            this.groupBoxPositionPicture.TabStop = false;
            this.groupBoxPositionPicture.Text = "Картинка на столе";
            // 
            // labelPath
            // 
            this.labelPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPath.Location = new System.Drawing.Point(6, 311);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(676, 23);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Выбранный файл или каталог";
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.ContextMenuStrip = this.contextMenu;
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "Рабочий стол";
            this.notifyIconApp.Visible = true;
            this.notifyIconApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconApp_MouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenCloseToolStripMenuItem,
            this.exitMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(132, 48);
            // 
            // OpenCloseToolStripMenuItem
            // 
            this.OpenCloseToolStripMenuItem.Name = "OpenCloseToolStripMenuItem";
            this.OpenCloseToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.OpenCloseToolStripMenuItem.Text = "Открыть";
            this.OpenCloseToolStripMenuItem.Click += new System.EventHandler(this.OpenCloseToolStripMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.radioButtonManual);
            this.groupBox1.Controls.Add(this.buttonSelectPictures);
            this.groupBox1.Controls.Add(this.radioButtonAuto);
            this.groupBox1.Location = new System.Drawing.Point(348, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 107);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Смена картинок";
            // 
            // labelNumberFiles
            // 
            this.labelNumberFiles.Location = new System.Drawing.Point(107, 281);
            this.labelNumberFiles.Name = "labelNumberFiles";
            this.labelNumberFiles.Size = new System.Drawing.Size(571, 13);
            this.labelNumberFiles.TabIndex = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(607, 12);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(75, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "О программе";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 338);
            this.Controls.Add(this.labelNumberFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.groupBoxPositionPicture);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBoxFrequencyChange);
            this.Controls.Add(this.groupBoxChangePicture);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UIForm";
            this.ShowInTaskbar = false;
            this.Text = "Выбери картинку для рабочего стола";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxChangePicture.ResumeLayout(false);
            this.groupBoxChangePicture.PerformLayout();
            this.groupBoxFrequencyChange.ResumeLayout(false);
            this.groupBoxFrequencyChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).EndInit();
            this.groupBoxPositionPicture.ResumeLayout(false);
            this.groupBoxPositionPicture.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonStretch;
        private System.Windows.Forms.RadioButton radioButtonActualSize;
        private System.Windows.Forms.RadioButton radioButtonTile;
        private System.Windows.Forms.RadioButton radioButtonManual;
        private System.Windows.Forms.Button buttonSelectPictures;
        private System.Windows.Forms.RadioButton radioButtonAuto;
        private System.Windows.Forms.RadioButton radioButtonConsecutively;
        private System.Windows.Forms.RadioButton radioButtonRandom;
        private System.Windows.Forms.GroupBox groupBoxChangePicture;
        private System.Windows.Forms.RadioButton radioButtonFrequency;
        private System.Windows.Forms.GroupBox groupBoxFrequencyChange;
        private System.Windows.Forms.GroupBox groupBoxPositionPicture;
        private System.Windows.Forms.RadioButton radioButtonByLoad;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.Label labelMinute;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.Label labelHour;
        private System.Windows.Forms.NumericUpDown numericUpDownHour;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNumberFiles;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenCloseToolStripMenuItem;
    }
}

