namespace AudibleImprovedBot
{
    partial class Form1
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
            this.logT = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.displayT = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.inputI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.twoCaptchaKeyI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeI = new System.Windows.Forms.DateTimePicker();
            this.runAtI = new System.Windows.Forms.CheckBox();
            this.isRedeemLimitedI = new System.Windows.Forms.CheckBox();
            this.redeemNumberI = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LoopI = new System.Windows.Forms.CheckBox();
            this.SkipTheFailedI = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.starsCountI = new System.Windows.Forms.ComboBox();
            this.loopFilesI = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.delayBetweenFilesI = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.delayI = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.threadsI = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redeemNumberI)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayBetweenFilesI)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsI)).BeginInit();
            this.SuspendLayout();
            // 
            // logT
            // 
            this.logT.BackColor = System.Drawing.SystemColors.Control;
            this.logT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logT.Location = new System.Drawing.Point(20, 20);
            this.logT.Margin = new System.Windows.Forms.Padding(6);
            this.logT.Name = "logT";
            this.logT.ReadOnly = true;
            this.logT.Size = new System.Drawing.Size(1674, 405);
            this.logT.TabIndex = 1;
            this.logT.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.displayT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 910);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1694, 56);
            this.panel1.TabIndex = 2;
            // 
            // displayT
            // 
            this.displayT.AutoSize = true;
            this.displayT.Location = new System.Drawing.Point(31, 15);
            this.displayT.Name = "displayT";
            this.displayT.Size = new System.Drawing.Size(26, 25);
            this.displayT.TabIndex = 0;
            this.displayT.Text = "--";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.startButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1394, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 485);
            this.panel3.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(29, 410);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(259, 47);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // inputI
            // 
            this.inputI.Location = new System.Drawing.Point(161, 56);
            this.inputI.Name = "inputI";
            this.inputI.ReadOnly = true;
            this.inputI.Size = new System.Drawing.Size(590, 31);
            this.inputI.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input File";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(773, 56);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(137, 34);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select File";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(916, 54);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(137, 34);
            this.openFileButton.TabIndex = 5;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // twoCaptchaKeyI
            // 
            this.twoCaptchaKeyI.Location = new System.Drawing.Point(161, 118);
            this.twoCaptchaKeyI.Name = "twoCaptchaKeyI";
            this.twoCaptchaKeyI.Size = new System.Drawing.Size(590, 31);
            this.twoCaptchaKeyI.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "2Captcha Key";
            // 
            // dateTimeI
            // 
            this.dateTimeI.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimeI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeI.Location = new System.Drawing.Point(161, 178);
            this.dateTimeI.Name = "dateTimeI";
            this.dateTimeI.Size = new System.Drawing.Size(246, 31);
            this.dateTimeI.TabIndex = 8;
            // 
            // runAtI
            // 
            this.runAtI.AutoSize = true;
            this.runAtI.Location = new System.Drawing.Point(31, 182);
            this.runAtI.Name = "runAtI";
            this.runAtI.Size = new System.Drawing.Size(92, 29);
            this.runAtI.TabIndex = 9;
            this.runAtI.Text = "Run At";
            this.runAtI.UseVisualStyleBackColor = true;
            // 
            // isRedeemLimitedI
            // 
            this.isRedeemLimitedI.AutoSize = true;
            this.isRedeemLimitedI.Location = new System.Drawing.Point(31, 237);
            this.isRedeemLimitedI.Name = "isRedeemLimitedI";
            this.isRedeemLimitedI.Size = new System.Drawing.Size(172, 29);
            this.isRedeemLimitedI.TabIndex = 10;
            this.isRedeemLimitedI.Text = "Limit Redeem to ";
            this.isRedeemLimitedI.UseVisualStyleBackColor = true;
            // 
            // redeemNumberI
            // 
            this.redeemNumberI.Location = new System.Drawing.Point(209, 237);
            this.redeemNumberI.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.redeemNumberI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.redeemNumberI.Name = "redeemNumberI";
            this.redeemNumberI.Size = new System.Drawing.Size(92, 31);
            this.redeemNumberI.TabIndex = 11;
            this.redeemNumberI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.threadsI);
            this.panel2.Controls.Add(this.LoopI);
            this.panel2.Controls.Add(this.SkipTheFailedI);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.starsCountI);
            this.panel2.Controls.Add(this.loopFilesI);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.delayBetweenFilesI);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.delayI);
            this.panel2.Controls.Add(this.redeemNumberI);
            this.panel2.Controls.Add(this.isRedeemLimitedI);
            this.panel2.Controls.Add(this.runAtI);
            this.panel2.Controls.Add(this.dateTimeI);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.twoCaptchaKeyI);
            this.panel2.Controls.Add(this.openFileButton);
            this.panel2.Controls.Add(this.selectButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.inputI);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1694, 485);
            this.panel2.TabIndex = 3;
            // 
            // LoopI
            // 
            this.LoopI.AutoSize = true;
            this.LoopI.Location = new System.Drawing.Point(773, 364);
            this.LoopI.Name = "LoopI";
            this.LoopI.Size = new System.Drawing.Size(305, 29);
            this.LoopI.TabIndex = 21;
            this.LoopI.Text = "Loop between entries of same file";
            this.LoopI.UseVisualStyleBackColor = true;
            // 
            // SkipTheFailedI
            // 
            this.SkipTheFailedI.AutoSize = true;
            this.SkipTheFailedI.Location = new System.Drawing.Point(456, 364);
            this.SkipTheFailedI.Name = "SkipTheFailedI";
            this.SkipTheFailedI.Size = new System.Drawing.Size(177, 29);
            this.SkipTheFailedI.TabIndex = 20;
            this.SkipTheFailedI.Text = "Skip failed entries";
            this.SkipTheFailedI.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Stars#";
            // 
            // starsCountI
            // 
            this.starsCountI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.starsCountI.FormattingEnabled = true;
            this.starsCountI.Items.AddRange(new object[] {
            "Random 4-5",
            "5"});
            this.starsCountI.Location = new System.Drawing.Point(117, 365);
            this.starsCountI.Name = "starsCountI";
            this.starsCountI.Size = new System.Drawing.Size(244, 33);
            this.starsCountI.TabIndex = 18;
            // 
            // loopFilesI
            // 
            this.loopFilesI.AutoSize = true;
            this.loopFilesI.Location = new System.Drawing.Point(773, 305);
            this.loopFilesI.Name = "loopFilesI";
            this.loopFilesI.Size = new System.Drawing.Size(187, 29);
            this.loopFilesI.TabIndex = 17;
            this.loopFilesI.Text = "Loop between files";
            this.loopFilesI.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(554, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hours between files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Promotion Codes next run";
            // 
            // delayBetweenFilesI
            // 
            this.delayBetweenFilesI.Location = new System.Drawing.Point(456, 307);
            this.delayBetweenFilesI.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.delayBetweenFilesI.Name = "delayBetweenFilesI";
            this.delayBetweenFilesI.Size = new System.Drawing.Size(92, 31);
            this.delayBetweenFilesI.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Delay";
            // 
            // delayI
            // 
            this.delayI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.delayI.FormattingEnabled = true;
            this.delayI.Items.AddRange(new object[] {
            "No Delay",
            "5 min",
            "10 min",
            "20 min",
            "30 min",
            "40 min",
            "60 min"});
            this.delayI.Location = new System.Drawing.Point(117, 306);
            this.delayI.Name = "delayI";
            this.delayI.Size = new System.Drawing.Size(244, 33);
            this.delayI.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.logT);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 485);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.panel4.Size = new System.Drawing.Size(1694, 425);
            this.panel4.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Threads";
            // 
            // threadsI
            // 
            this.threadsI.Location = new System.Drawing.Point(577, 178);
            this.threadsI.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.threadsI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadsI.Name = "threadsI";
            this.threadsI.Size = new System.Drawing.Size(92, 31);
            this.threadsI.TabIndex = 22;
            this.threadsI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 966);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "AudibleImprovedBot 1.00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.redeemNumberI)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayBetweenFilesI)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.threadsI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RichTextBox logT;
        private Panel panel1;
        private Label displayT;
        private Panel panel3;
        private Button startButton;
        private TextBox inputI;
        private Label label1;
        private Button selectButton;
        private Button openFileButton;
        private TextBox twoCaptchaKeyI;
        private Label label2;
        private DateTimePicker dateTimeI;
        private CheckBox runAtI;
        private CheckBox isRedeemLimitedI;
        private NumericUpDown redeemNumberI;
        private Panel panel2;
        private Label label3;
        private ComboBox delayI;
        private Label label5;
        private Label label4;
        private NumericUpDown delayBetweenFilesI;
        private CheckBox loopFilesI;
        private CheckBox LoopI;
        private CheckBox SkipTheFailedI;
        private Label label6;
        private ComboBox starsCountI;
        private Panel panel4;
        private Label label7;
        private NumericUpDown threadsI;
    }
}