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
            this.label7 = new System.Windows.Forms.Label();
            this.threadsI = new System.Windows.Forms.NumericUpDown();
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
            this.label8 = new System.Windows.Forms.Label();
            this.totalEntriesL = new System.Windows.Forms.Label();
            this.successL = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.failedL = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.toProcessL = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redeemNumberI)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayBetweenFilesI)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // logT
            // 
            this.logT.BackColor = System.Drawing.SystemColors.Control;
            this.logT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logT.Location = new System.Drawing.Point(16, 16);
            this.logT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.logT.Name = "logT";
            this.logT.ReadOnly = true;
            this.logT.Size = new System.Drawing.Size(1339, 324);
            this.logT.TabIndex = 1;
            this.logT.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.displayT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 728);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1355, 45);
            this.panel1.TabIndex = 2;
            // 
            // displayT
            // 
            this.displayT.AutoSize = true;
            this.displayT.Location = new System.Drawing.Point(25, 12);
            this.displayT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.displayT.Name = "displayT";
            this.displayT.Size = new System.Drawing.Size(21, 20);
            this.displayT.TabIndex = 0;
            this.displayT.Text = "--";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.startButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1115, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 388);
            this.panel3.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(23, 328);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(207, 38);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // inputI
            // 
            this.inputI.Location = new System.Drawing.Point(129, 45);
            this.inputI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputI.Name = "inputI";
            this.inputI.ReadOnly = true;
            this.inputI.Size = new System.Drawing.Size(473, 27);
            this.inputI.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input File";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(618, 45);
            this.selectButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(110, 27);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select File";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(733, 43);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(110, 27);
            this.openFileButton.TabIndex = 5;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // twoCaptchaKeyI
            // 
            this.twoCaptchaKeyI.Location = new System.Drawing.Point(129, 94);
            this.twoCaptchaKeyI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.twoCaptchaKeyI.Name = "twoCaptchaKeyI";
            this.twoCaptchaKeyI.Size = new System.Drawing.Size(473, 27);
            this.twoCaptchaKeyI.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "2Captcha Key";
            // 
            // dateTimeI
            // 
            this.dateTimeI.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimeI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeI.Location = new System.Drawing.Point(129, 142);
            this.dateTimeI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimeI.Name = "dateTimeI";
            this.dateTimeI.Size = new System.Drawing.Size(198, 27);
            this.dateTimeI.TabIndex = 8;
            // 
            // runAtI
            // 
            this.runAtI.AutoSize = true;
            this.runAtI.Location = new System.Drawing.Point(25, 146);
            this.runAtI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runAtI.Name = "runAtI";
            this.runAtI.Size = new System.Drawing.Size(75, 24);
            this.runAtI.TabIndex = 9;
            this.runAtI.Text = "Run At";
            this.runAtI.UseVisualStyleBackColor = true;
            // 
            // isRedeemLimitedI
            // 
            this.isRedeemLimitedI.AutoSize = true;
            this.isRedeemLimitedI.Location = new System.Drawing.Point(25, 190);
            this.isRedeemLimitedI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isRedeemLimitedI.Name = "isRedeemLimitedI";
            this.isRedeemLimitedI.Size = new System.Drawing.Size(145, 24);
            this.isRedeemLimitedI.TabIndex = 10;
            this.isRedeemLimitedI.Text = "Limit Redeem to ";
            this.isRedeemLimitedI.UseVisualStyleBackColor = true;
            // 
            // redeemNumberI
            // 
            this.redeemNumberI.Location = new System.Drawing.Point(167, 190);
            this.redeemNumberI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.redeemNumberI.Size = new System.Drawing.Size(74, 27);
            this.redeemNumberI.TabIndex = 11;
            this.redeemNumberI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toProcessL);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.failedL);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.successL);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.totalEntriesL);
            this.panel2.Controls.Add(this.label8);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1355, 388);
            this.panel2.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(540, 144);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Threads";
            // 
            // threadsI
            // 
            this.threadsI.Location = new System.Drawing.Point(462, 142);
            this.threadsI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.threadsI.Size = new System.Drawing.Size(74, 27);
            this.threadsI.TabIndex = 22;
            this.threadsI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LoopI
            // 
            this.LoopI.AutoSize = true;
            this.LoopI.Location = new System.Drawing.Point(618, 291);
            this.LoopI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoopI.Name = "LoopI";
            this.LoopI.Size = new System.Drawing.Size(256, 24);
            this.LoopI.TabIndex = 21;
            this.LoopI.Text = "Loop between entries of same file";
            this.LoopI.UseVisualStyleBackColor = true;
            // 
            // SkipTheFailedI
            // 
            this.SkipTheFailedI.AutoSize = true;
            this.SkipTheFailedI.Location = new System.Drawing.Point(365, 291);
            this.SkipTheFailedI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SkipTheFailedI.Name = "SkipTheFailedI";
            this.SkipTheFailedI.Size = new System.Drawing.Size(149, 24);
            this.SkipTheFailedI.TabIndex = 20;
            this.SkipTheFailedI.Text = "Skip failed entries";
            this.SkipTheFailedI.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
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
            this.starsCountI.Location = new System.Drawing.Point(94, 292);
            this.starsCountI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.starsCountI.Name = "starsCountI";
            this.starsCountI.Size = new System.Drawing.Size(196, 28);
            this.starsCountI.TabIndex = 18;
            // 
            // loopFilesI
            // 
            this.loopFilesI.AutoSize = true;
            this.loopFilesI.Location = new System.Drawing.Point(618, 244);
            this.loopFilesI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loopFilesI.Name = "loopFilesI";
            this.loopFilesI.Size = new System.Drawing.Size(157, 24);
            this.loopFilesI.TabIndex = 17;
            this.loopFilesI.Text = "Loop between files";
            this.loopFilesI.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 247);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hours between files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Promotion Codes next run";
            // 
            // delayBetweenFilesI
            // 
            this.delayBetweenFilesI.Location = new System.Drawing.Point(365, 246);
            this.delayBetweenFilesI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delayBetweenFilesI.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.delayBetweenFilesI.Name = "delayBetweenFilesI";
            this.delayBetweenFilesI.Size = new System.Drawing.Size(74, 27);
            this.delayBetweenFilesI.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
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
            this.delayI.Location = new System.Drawing.Point(94, 245);
            this.delayI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delayI.Name = "delayI";
            this.delayI.Size = new System.Drawing.Size(196, 28);
            this.delayI.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.logT);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 388);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(16, 16, 0, 0);
            this.panel4.Size = new System.Drawing.Size(1355, 340);
            this.panel4.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Total Entries :";
            // 
            // totalEntriesL
            // 
            this.totalEntriesL.AutoSize = true;
            this.totalEntriesL.Location = new System.Drawing.Point(197, 346);
            this.totalEntriesL.Name = "totalEntriesL";
            this.totalEntriesL.Size = new System.Drawing.Size(0, 20);
            this.totalEntriesL.TabIndex = 25;
            // 
            // successL
            // 
            this.successL.AutoSize = true;
            this.successL.Location = new System.Drawing.Point(302, 346);
            this.successL.Name = "successL";
            this.successL.Size = new System.Drawing.Size(0, 20);
            this.successL.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(230, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Success :";
            // 
            // failedL
            // 
            this.failedL.AutoSize = true;
            this.failedL.Location = new System.Drawing.Point(427, 346);
            this.failedL.Name = "failedL";
            this.failedL.Size = new System.Drawing.Size(0, 20);
            this.failedL.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(365, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Failed :";
            // 
            // toProcessL
            // 
            this.toProcessL.AutoSize = true;
            this.toProcessL.Location = new System.Drawing.Point(601, 346);
            this.toProcessL.Name = "toProcessL";
            this.toProcessL.Size = new System.Drawing.Size(0, 20);
            this.toProcessL.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(510, 346);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "To Process :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 773);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "AudibleImprovedBot 1.01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.redeemNumberI)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayBetweenFilesI)).EndInit();
            this.panel4.ResumeLayout(false);
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
        private Label toProcessL;
        private Label label14;
        private Label failedL;
        private Label label12;
        private Label successL;
        private Label label10;
        private Label totalEntriesL;
        private Label label8;
    }
}