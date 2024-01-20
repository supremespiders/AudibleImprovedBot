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
            logT = new RichTextBox();
            panel1 = new Panel();
            displayT = new Label();
            panel3 = new Panel();
            UpdateButton = new Button();
            clearAllButton = new Button();
            startButton = new Button();
            inputI = new TextBox();
            label1 = new Label();
            selectButton = new Button();
            openFileButton = new Button();
            twoCaptchaKeyI = new TextBox();
            label2 = new Label();
            dateTimeI = new DateTimePicker();
            runAtI = new CheckBox();
            isRedeemLimitedI = new CheckBox();
            redeemNumberI = new NumericUpDown();
            panel2 = new Panel();
            testI = new CheckBox();
            toProcessL = new Label();
            label14 = new Label();
            failedL = new Label();
            label12 = new Label();
            successL = new Label();
            label10 = new Label();
            totalEntriesL = new Label();
            label8 = new Label();
            label7 = new Label();
            threadsI = new NumericUpDown();
            LoopI = new CheckBox();
            SkipTheFailedI = new CheckBox();
            label6 = new Label();
            starsCountI = new ComboBox();
            loopFilesI = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            delayBetweenFilesI = new NumericUpDown();
            label3 = new Label();
            delayI = new ComboBox();
            panel4 = new Panel();
            label9 = new Label();
            listenDurationI = new NumericUpDown();
            forceStopI = new CheckBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)redeemNumberI).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)threadsI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)delayBetweenFilesI).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listenDurationI).BeginInit();
            SuspendLayout();
            // 
            // logT
            // 
            logT.BackColor = SystemColors.Control;
            logT.BorderStyle = BorderStyle.None;
            logT.Dock = DockStyle.Fill;
            logT.Location = new Point(20, 20);
            logT.Margin = new Padding(6);
            logT.Name = "logT";
            logT.ReadOnly = true;
            logT.Size = new Size(1674, 405);
            logT.TabIndex = 1;
            logT.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(displayT);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 910);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 56);
            panel1.TabIndex = 2;
            // 
            // displayT
            // 
            displayT.AutoSize = true;
            displayT.Location = new Point(31, 15);
            displayT.Margin = new Padding(2, 0, 2, 0);
            displayT.Name = "displayT";
            displayT.Size = new Size(26, 25);
            displayT.TabIndex = 0;
            displayT.Text = "--";
            // 
            // panel3
            // 
            panel3.Controls.Add(UpdateButton);
            panel3.Controls.Add(clearAllButton);
            panel3.Controls.Add(startButton);
            panel3.Dock = DockStyle.Right;
            panel3.ForeColor = SystemColors.ActiveCaptionText;
            panel3.Location = new Point(1394, 0);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 485);
            panel3.TabIndex = 1;
            // 
            // UpdateButton
            // 
            UpdateButton.BackColor = Color.FromArgb(192, 192, 255);
            UpdateButton.FlatStyle = FlatStyle.Flat;
            UpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateButton.ForeColor = Color.Red;
            UpdateButton.Location = new Point(11, 47);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(259, 46);
            UpdateButton.TabIndex = 2;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = false;
            UpdateButton.Visible = false;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // clearAllButton
            // 
            clearAllButton.Location = new Point(11, 98);
            clearAllButton.Margin = new Padding(2);
            clearAllButton.Name = "clearAllButton";
            clearAllButton.Size = new Size(259, 48);
            clearAllButton.TabIndex = 1;
            clearAllButton.Text = "Clear all results";
            clearAllButton.UseVisualStyleBackColor = true;
            clearAllButton.Click += clearAllButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(11, 410);
            startButton.Margin = new Padding(2);
            startButton.Name = "startButton";
            startButton.Size = new Size(259, 48);
            startButton.TabIndex = 0;
            startButton.Text = "start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // inputI
            // 
            inputI.Location = new Point(161, 56);
            inputI.Margin = new Padding(2);
            inputI.Name = "inputI";
            inputI.ReadOnly = true;
            inputI.Size = new Size(590, 31);
            inputI.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 56);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 3;
            label1.Text = "Input File";
            // 
            // selectButton
            // 
            selectButton.Location = new Point(772, 56);
            selectButton.Margin = new Padding(2);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(138, 34);
            selectButton.TabIndex = 4;
            selectButton.Text = "Select File";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(916, 54);
            openFileButton.Margin = new Padding(2);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(138, 34);
            openFileButton.TabIndex = 5;
            openFileButton.Text = "Open File";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // twoCaptchaKeyI
            // 
            twoCaptchaKeyI.Location = new Point(161, 118);
            twoCaptchaKeyI.Margin = new Padding(2);
            twoCaptchaKeyI.Name = "twoCaptchaKeyI";
            twoCaptchaKeyI.Size = new Size(590, 31);
            twoCaptchaKeyI.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 121);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 7;
            label2.Text = "2Captcha Key";
            // 
            // dateTimeI
            // 
            dateTimeI.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            dateTimeI.Format = DateTimePickerFormat.Custom;
            dateTimeI.Location = new Point(161, 178);
            dateTimeI.Margin = new Padding(2);
            dateTimeI.Name = "dateTimeI";
            dateTimeI.Size = new Size(246, 31);
            dateTimeI.TabIndex = 8;
            // 
            // runAtI
            // 
            runAtI.AutoSize = true;
            runAtI.Location = new Point(31, 182);
            runAtI.Margin = new Padding(2);
            runAtI.Name = "runAtI";
            runAtI.Size = new Size(92, 29);
            runAtI.TabIndex = 9;
            runAtI.Text = "Run At";
            runAtI.UseVisualStyleBackColor = true;
            // 
            // isRedeemLimitedI
            // 
            isRedeemLimitedI.AutoSize = true;
            isRedeemLimitedI.Location = new Point(31, 238);
            isRedeemLimitedI.Margin = new Padding(2);
            isRedeemLimitedI.Name = "isRedeemLimitedI";
            isRedeemLimitedI.Size = new Size(172, 29);
            isRedeemLimitedI.TabIndex = 10;
            isRedeemLimitedI.Text = "Limit Redeem to ";
            isRedeemLimitedI.UseVisualStyleBackColor = true;
            // 
            // redeemNumberI
            // 
            redeemNumberI.Location = new Point(209, 238);
            redeemNumberI.Margin = new Padding(2);
            redeemNumberI.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            redeemNumberI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            redeemNumberI.Name = "redeemNumberI";
            redeemNumberI.Size = new Size(92, 31);
            redeemNumberI.TabIndex = 11;
            redeemNumberI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panel2
            // 
            panel2.Controls.Add(label9);
            panel2.Controls.Add(listenDurationI);
            panel2.Controls.Add(forceStopI);
            panel2.Controls.Add(testI);
            panel2.Controls.Add(toProcessL);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(failedL);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(successL);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(totalEntriesL);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(threadsI);
            panel2.Controls.Add(LoopI);
            panel2.Controls.Add(SkipTheFailedI);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(starsCountI);
            panel2.Controls.Add(loopFilesI);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(delayBetweenFilesI);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(delayI);
            panel2.Controls.Add(redeemNumberI);
            panel2.Controls.Add(isRedeemLimitedI);
            panel2.Controls.Add(runAtI);
            panel2.Controls.Add(dateTimeI);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(twoCaptchaKeyI);
            panel2.Controls.Add(openFileButton);
            panel2.Controls.Add(selectButton);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(inputI);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 485);
            panel2.TabIndex = 3;
            // 
            // testI
            // 
            testI.AutoSize = true;
            testI.Location = new Point(1322, 52);
            testI.Margin = new Padding(2);
            testI.Name = "testI";
            testI.Size = new Size(68, 29);
            testI.TabIndex = 32;
            testI.Text = "Test";
            testI.UseVisualStyleBackColor = true;
            // 
            // toProcessL
            // 
            toProcessL.AutoSize = true;
            toProcessL.Location = new Point(751, 432);
            toProcessL.Margin = new Padding(4, 0, 4, 0);
            toProcessL.Name = "toProcessL";
            toProcessL.Size = new Size(0, 25);
            toProcessL.TabIndex = 31;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(638, 432);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(104, 25);
            label14.TabIndex = 30;
            label14.Text = "To Process :";
            // 
            // failedL
            // 
            failedL.AutoSize = true;
            failedL.Location = new Point(534, 432);
            failedL.Margin = new Padding(4, 0, 4, 0);
            failedL.Name = "failedL";
            failedL.Size = new Size(0, 25);
            failedL.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(456, 432);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(66, 25);
            label12.TabIndex = 28;
            label12.Text = "Failed :";
            // 
            // successL
            // 
            successL.AutoSize = true;
            successL.Location = new Point(378, 432);
            successL.Margin = new Padding(4, 0, 4, 0);
            successL.Name = "successL";
            successL.Size = new Size(0, 25);
            successL.TabIndex = 27;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(288, 432);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(82, 25);
            label10.TabIndex = 26;
            label10.Text = "Success :";
            // 
            // totalEntriesL
            // 
            totalEntriesL.AutoSize = true;
            totalEntriesL.Location = new Point(246, 432);
            totalEntriesL.Margin = new Padding(4, 0, 4, 0);
            totalEntriesL.Name = "totalEntriesL";
            totalEntriesL.Size = new Size(0, 25);
            totalEntriesL.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(118, 432);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(115, 25);
            label8.TabIndex = 24;
            label8.Text = "Total Entries :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(675, 180);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 23;
            label7.Text = "Threads";
            // 
            // threadsI
            // 
            threadsI.Location = new Point(578, 178);
            threadsI.Margin = new Padding(2);
            threadsI.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            threadsI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            threadsI.Name = "threadsI";
            threadsI.Size = new Size(92, 31);
            threadsI.TabIndex = 22;
            threadsI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LoopI
            // 
            LoopI.AutoSize = true;
            LoopI.Location = new Point(772, 364);
            LoopI.Margin = new Padding(2);
            LoopI.Name = "LoopI";
            LoopI.Size = new Size(305, 29);
            LoopI.TabIndex = 21;
            LoopI.Text = "Loop between entries of same file";
            LoopI.UseVisualStyleBackColor = true;
            // 
            // SkipTheFailedI
            // 
            SkipTheFailedI.AutoSize = true;
            SkipTheFailedI.Location = new Point(456, 364);
            SkipTheFailedI.Margin = new Padding(2);
            SkipTheFailedI.Name = "SkipTheFailedI";
            SkipTheFailedI.Size = new Size(177, 29);
            SkipTheFailedI.TabIndex = 20;
            SkipTheFailedI.Text = "Skip failed entries";
            SkipTheFailedI.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 368);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 19;
            label6.Text = "Stars#";
            // 
            // starsCountI
            // 
            starsCountI.DropDownStyle = ComboBoxStyle.DropDownList;
            starsCountI.FormattingEnabled = true;
            starsCountI.Items.AddRange(new object[] { "Random 4-5", "5" });
            starsCountI.Location = new Point(118, 365);
            starsCountI.Margin = new Padding(2);
            starsCountI.Name = "starsCountI";
            starsCountI.Size = new Size(244, 33);
            starsCountI.TabIndex = 18;
            // 
            // loopFilesI
            // 
            loopFilesI.AutoSize = true;
            loopFilesI.Location = new Point(772, 305);
            loopFilesI.Margin = new Padding(2);
            loopFilesI.Name = "loopFilesI";
            loopFilesI.Size = new Size(187, 29);
            loopFilesI.TabIndex = 17;
            loopFilesI.Text = "Loop between files";
            loopFilesI.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(554, 309);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(168, 25);
            label5.TabIndex = 16;
            label5.Text = "Hours between files";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(308, 239);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(221, 25);
            label4.TabIndex = 15;
            label4.Text = "Promotion Codes next run";
            // 
            // delayBetweenFilesI
            // 
            delayBetweenFilesI.Location = new Point(456, 308);
            delayBetweenFilesI.Margin = new Padding(2);
            delayBetweenFilesI.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            delayBetweenFilesI.Name = "delayBetweenFilesI";
            delayBetweenFilesI.Size = new Size(92, 31);
            delayBetweenFilesI.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 306);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 13;
            label3.Text = "Delay";
            // 
            // delayI
            // 
            delayI.DropDownStyle = ComboBoxStyle.DropDownList;
            delayI.FormattingEnabled = true;
            delayI.Items.AddRange(new object[] { "No Delay", "5 min", "10 min", "20 min", "30 min", "40 min", "60 min" });
            delayI.Location = new Point(118, 306);
            delayI.Margin = new Padding(2);
            delayI.Name = "delayI";
            delayI.Size = new Size(244, 33);
            delayI.TabIndex = 12;
            // 
            // panel4
            // 
            panel4.Controls.Add(logT);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 485);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(20, 20, 0, 0);
            panel4.Size = new Size(1694, 425);
            panel4.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(856, 236);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(75, 25);
            label9.TabIndex = 35;
            label9.Text = "Minutes";
            // 
            // listenDurationI
            // 
            listenDurationI.Location = new Point(757, 235);
            listenDurationI.Margin = new Padding(2);
            listenDurationI.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            listenDurationI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            listenDurationI.Name = "listenDurationI";
            listenDurationI.Size = new Size(92, 31);
            listenDurationI.TabIndex = 34;
            listenDurationI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // forceStopI
            // 
            forceStopI.AutoSize = true;
            forceStopI.Location = new Point(579, 235);
            forceStopI.Margin = new Padding(2);
            forceStopI.Name = "forceStopI";
            forceStopI.Size = new Size(162, 29);
            forceStopI.TabIndex = 33;
            forceStopI.Text = "Stop listen after";
            forceStopI.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1694, 966);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "AudibleImprovedBot 1.14";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)redeemNumberI).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)threadsI).EndInit();
            ((System.ComponentModel.ISupportInitialize)delayBetweenFilesI).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listenDurationI).EndInit();
            ResumeLayout(false);
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
        private Button clearAllButton;
        private CheckBox testI;
        private Button UpdateButton;
        private Label label9;
        private NumericUpDown listenDurationI;
        private CheckBox forceStopI;
    }
}