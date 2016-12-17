namespace IoWarrior {
    partial class IOModePanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDeviceNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.runtimeLabel = new System.Windows.Forms.Label();
            this.runStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.port1selectAll = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.port1invert = new System.Windows.Forms.CheckBox();
            this.port1Output = new System.Windows.Forms.CheckedListBox();
            this.port1Input = new System.Windows.Forms.CheckedListBox();
            this.bttStop = new System.Windows.Forms.Button();
            this.bttRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.port0selectAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.port0invert = new System.Windows.Forms.CheckBox();
            this.port0Output = new System.Windows.Forms.CheckedListBox();
            this.port0Input = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lbDeviceNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.runtimeLabel);
            this.panel1.Controls.Add(this.runStatus);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.bttStop);
            this.panel1.Controls.Add(this.bttRun);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 575);
            this.panel1.TabIndex = 3;
            // 
            // lbDeviceNumber
            // 
            this.lbDeviceNumber.AutoSize = true;
            this.lbDeviceNumber.Location = new System.Drawing.Point(59, 13);
            this.lbDeviceNumber.Name = "lbDeviceNumber";
            this.lbDeviceNumber.Size = new System.Drawing.Size(10, 13);
            this.lbDeviceNumber.TabIndex = 12;
            this.lbDeviceNumber.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Device: ";
            // 
            // runtimeLabel
            // 
            this.runtimeLabel.AutoSize = true;
            this.runtimeLabel.Location = new System.Drawing.Point(199, 43);
            this.runtimeLabel.Name = "runtimeLabel";
            this.runtimeLabel.Size = new System.Drawing.Size(29, 13);
            this.runtimeLabel.TabIndex = 10;
            this.runtimeLabel.Text = "0 ms";
            // 
            // runStatus
            // 
            this.runStatus.BackColor = System.Drawing.Color.Red;
            this.runStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.runStatus.Location = new System.Drawing.Point(171, 38);
            this.runStatus.Name = "runStatus";
            this.runStatus.Size = new System.Drawing.Size(22, 23);
            this.runStatus.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.port1selectAll);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.port1invert);
            this.groupBox3.Controls.Add(this.port1Output);
            this.groupBox3.Controls.Add(this.port1Input);
            this.groupBox3.Location = new System.Drawing.Point(268, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 226);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port1";
            // 
            // port1selectAll
            // 
            this.port1selectAll.AutoSize = true;
            this.port1selectAll.Location = new System.Drawing.Point(68, 200);
            this.port1selectAll.Name = "port1selectAll";
            this.port1selectAll.Size = new System.Drawing.Size(37, 17);
            this.port1selectAll.TabIndex = 6;
            this.port1selectAll.Text = "All";
            this.port1selectAll.UseVisualStyleBackColor = true;
            this.port1selectAll.CheckedChanged += new System.EventHandler(this.checked_port1selectAll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input";
            // 
            // port1invert
            // 
            this.port1invert.AutoSize = true;
            this.port1invert.Location = new System.Drawing.Point(7, 18);
            this.port1invert.Name = "port1invert";
            this.port1invert.Size = new System.Drawing.Size(53, 17);
            this.port1invert.TabIndex = 2;
            this.port1invert.Text = "Invert";
            this.port1invert.UseVisualStyleBackColor = true;
            // 
            // port1Output
            // 
            this.port1Output.CheckOnClick = true;
            this.port1Output.FormattingEnabled = true;
            this.port1Output.Location = new System.Drawing.Point(68, 70);
            this.port1Output.Name = "port1Output";
            this.port1Output.Size = new System.Drawing.Size(55, 124);
            this.port1Output.TabIndex = 1;
            // 
            // port1Input
            // 
            this.port1Input.FormattingEnabled = true;
            this.port1Input.Location = new System.Drawing.Point(7, 70);
            this.port1Input.Name = "port1Input";
            this.port1Input.Size = new System.Drawing.Size(55, 124);
            this.port1Input.TabIndex = 0;
            // 
            // bttStop
            // 
            this.bttStop.Enabled = false;
            this.bttStop.Location = new System.Drawing.Point(90, 38);
            this.bttStop.Name = "bttStop";
            this.bttStop.Size = new System.Drawing.Size(75, 23);
            this.bttStop.TabIndex = 8;
            this.bttStop.Text = "stop";
            this.bttStop.UseVisualStyleBackColor = true;
            this.bttStop.Click += new System.EventHandler(this.bttStop_Click);
            // 
            // bttRun
            // 
            this.bttRun.Location = new System.Drawing.Point(9, 38);
            this.bttRun.Name = "bttRun";
            this.bttRun.Size = new System.Drawing.Size(75, 23);
            this.bttRun.TabIndex = 6;
            this.bttRun.Text = "run";
            this.bttRun.UseVisualStyleBackColor = true;
            this.bttRun.Click += new System.EventHandler(this.bttRun_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.port0selectAll);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.port0invert);
            this.groupBox2.Controls.Add(this.port0Output);
            this.groupBox2.Controls.Add(this.port0Input);
            this.groupBox2.Location = new System.Drawing.Point(9, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 226);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port0";
            // 
            // port0selectAll
            // 
            this.port0selectAll.AutoSize = true;
            this.port0selectAll.Location = new System.Drawing.Point(68, 201);
            this.port0selectAll.Name = "port0selectAll";
            this.port0selectAll.Size = new System.Drawing.Size(37, 17);
            this.port0selectAll.TabIndex = 5;
            this.port0selectAll.Text = "All";
            this.port0selectAll.UseVisualStyleBackColor = true;
            this.port0selectAll.CheckedChanged += new System.EventHandler(this.checked_port0selectAll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input";
            // 
            // port0invert
            // 
            this.port0invert.AutoSize = true;
            this.port0invert.Location = new System.Drawing.Point(7, 19);
            this.port0invert.Name = "port0invert";
            this.port0invert.Size = new System.Drawing.Size(53, 17);
            this.port0invert.TabIndex = 2;
            this.port0invert.Text = "Invert";
            this.port0invert.UseVisualStyleBackColor = true;
            // 
            // port0Output
            // 
            this.port0Output.CheckOnClick = true;
            this.port0Output.FormattingEnabled = true;
            this.port0Output.Location = new System.Drawing.Point(68, 70);
            this.port0Output.Name = "port0Output";
            this.port0Output.Size = new System.Drawing.Size(55, 124);
            this.port0Output.TabIndex = 1;
            // 
            // port0Input
            // 
            this.port0Input.FormattingEnabled = true;
            this.port0Input.Location = new System.Drawing.Point(7, 70);
            this.port0Input.Name = "port0Input";
            this.port0Input.Size = new System.Drawing.Size(55, 124);
            this.port0Input.TabIndex = 0;
            // 
            // IOModePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "IOModePanel";
            this.Size = new System.Drawing.Size(874, 575);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label runtimeLabel;
        private System.Windows.Forms.Label runStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox port1selectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox port1invert;
        private System.Windows.Forms.CheckedListBox port1Output;
        private System.Windows.Forms.CheckedListBox port1Input;
        private System.Windows.Forms.Button bttStop;
        private System.Windows.Forms.Button bttRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox port0selectAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox port0invert;
        private System.Windows.Forms.CheckedListBox port0Output;
        private System.Windows.Forms.CheckedListBox port0Input;
        private System.Windows.Forms.Label lbDeviceNumber;
        private System.Windows.Forms.Label label1;
    }
}
