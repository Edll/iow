namespace IoWarrior {
    partial class I2CModePanel {
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
            this.bttStop = new System.Windows.Forms.Button();
            this.bttRun = new System.Windows.Forms.Button();
            this.lbDeviceNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.runtimeLabel = new System.Windows.Forms.Label();
            this.runStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.port0selectAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.port0Output = new System.Windows.Forms.CheckedListBox();
            this.port0Input = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.port1selectAll = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.port1Output = new System.Windows.Forms.CheckedListBox();
            this.port1Input = new System.Windows.Forms.CheckedListBox();
            this.bttSetFre = new System.Windows.Forms.Button();
            this.tbA4 = new System.Windows.Forms.TrackBar();
            this.tbA3 = new System.Windows.Forms.TrackBar();
            this.tbA2 = new System.Windows.Forms.TrackBar();
            this.txtA4Min = new System.Windows.Forms.TextBox();
            this.txtA3Min = new System.Windows.Forms.TextBox();
            this.txtA2Min = new System.Windows.Forms.TextBox();
            this.txtA4Max = new System.Windows.Forms.TextBox();
            this.txtA3Max = new System.Windows.Forms.TextBox();
            this.txtA2Max = new System.Windows.Forms.TextBox();
            this.txtA1Max = new System.Windows.Forms.TextBox();
            this.txtA1Min = new System.Windows.Forms.TextBox();
            this.tbA1 = new System.Windows.Forms.TrackBar();
            this.bttWrite = new System.Windows.Forms.Button();
            this.tbPmwWeite = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbA4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA1)).BeginInit();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tbPmwWeite);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.bttSetFre);
            this.panel1.Controls.Add(this.tbA4);
            this.panel1.Controls.Add(this.tbA3);
            this.panel1.Controls.Add(this.tbA2);
            this.panel1.Controls.Add(this.txtA4Min);
            this.panel1.Controls.Add(this.txtA3Min);
            this.panel1.Controls.Add(this.txtA2Min);
            this.panel1.Controls.Add(this.txtA4Max);
            this.panel1.Controls.Add(this.txtA3Max);
            this.panel1.Controls.Add(this.txtA2Max);
            this.panel1.Controls.Add(this.txtA1Max);
            this.panel1.Controls.Add(this.txtA1Min);
            this.panel1.Controls.Add(this.tbA1);
            this.panel1.Controls.Add(this.bttWrite);
            this.panel1.Controls.Add(this.lbDeviceNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.runtimeLabel);
            this.panel1.Controls.Add(this.runStatus);
            this.panel1.Controls.Add(this.bttStop);
            this.panel1.Controls.Add(this.bttRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 557);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.port0selectAll);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.port0Output);
            this.groupBox2.Controls.Add(this.port0Input);
            this.groupBox2.Location = new System.Drawing.Point(667, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 184);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port0";
            // 
            // port0selectAll
            // 
            this.port0selectAll.AutoSize = true;
            this.port0selectAll.Location = new System.Drawing.Point(68, 162);
            this.port0selectAll.Name = "port0selectAll";
            this.port0selectAll.Size = new System.Drawing.Size(37, 17);
            this.port0selectAll.TabIndex = 5;
            this.port0selectAll.Text = "All";
            this.port0selectAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input";
            // 
            // port0Output
            // 
            this.port0Output.CheckOnClick = true;
            this.port0Output.FormattingEnabled = true;
            this.port0Output.Location = new System.Drawing.Point(68, 32);
            this.port0Output.Name = "port0Output";
            this.port0Output.Size = new System.Drawing.Size(55, 124);
            this.port0Output.TabIndex = 1;
            // 
            // port0Input
            // 
            this.port0Input.FormattingEnabled = true;
            this.port0Input.Location = new System.Drawing.Point(7, 32);
            this.port0Input.Name = "port0Input";
            this.port0Input.Size = new System.Drawing.Size(55, 124);
            this.port0Input.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.port1selectAll);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.port1Output);
            this.groupBox3.Controls.Add(this.port1Input);
            this.groupBox3.Location = new System.Drawing.Point(667, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(132, 184);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port1";
            // 
            // port1selectAll
            // 
            this.port1selectAll.AutoSize = true;
            this.port1selectAll.Location = new System.Drawing.Point(68, 162);
            this.port1selectAll.Name = "port1selectAll";
            this.port1selectAll.Size = new System.Drawing.Size(37, 17);
            this.port1selectAll.TabIndex = 6;
            this.port1selectAll.Text = "All";
            this.port1selectAll.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input";
            // 
            // port1Output
            // 
            this.port1Output.CheckOnClick = true;
            this.port1Output.FormattingEnabled = true;
            this.port1Output.Location = new System.Drawing.Point(67, 32);
            this.port1Output.Name = "port1Output";
            this.port1Output.Size = new System.Drawing.Size(55, 124);
            this.port1Output.TabIndex = 1;
            // 
            // port1Input
            // 
            this.port1Input.FormattingEnabled = true;
            this.port1Input.Location = new System.Drawing.Point(6, 32);
            this.port1Input.Name = "port1Input";
            this.port1Input.Size = new System.Drawing.Size(55, 124);
            this.port1Input.TabIndex = 0;
            // 
            // bttSetFre
            // 
            this.bttSetFre.Location = new System.Drawing.Point(295, 39);
            this.bttSetFre.Name = "bttSetFre";
            this.bttSetFre.Size = new System.Drawing.Size(125, 23);
            this.bttSetFre.TabIndex = 31;
            this.bttSetFre.Text = "PMW weite Schreiben";
            this.bttSetFre.UseVisualStyleBackColor = true;
            this.bttSetFre.Click += new System.EventHandler(this.bttSetFre_Click);
            // 
            // tbA4
            // 
            this.tbA4.Location = new System.Drawing.Point(115, 221);
            this.tbA4.Maximum = 600;
            this.tbA4.Minimum = 150;
            this.tbA4.Name = "tbA4";
            this.tbA4.Size = new System.Drawing.Size(289, 42);
            this.tbA4.TabIndex = 30;
            this.tbA4.Value = 150;
            // 
            // tbA3
            // 
            this.tbA3.Location = new System.Drawing.Point(115, 173);
            this.tbA3.Maximum = 600;
            this.tbA3.Minimum = 150;
            this.tbA3.Name = "tbA3";
            this.tbA3.Size = new System.Drawing.Size(289, 42);
            this.tbA3.TabIndex = 29;
            this.tbA3.Value = 150;
            // 
            // tbA2
            // 
            this.tbA2.Location = new System.Drawing.Point(115, 125);
            this.tbA2.Maximum = 600;
            this.tbA2.Minimum = 150;
            this.tbA2.Name = "tbA2";
            this.tbA2.Size = new System.Drawing.Size(289, 42);
            this.tbA2.TabIndex = 28;
            this.tbA2.Value = 150;
            // 
            // txtA4Min
            // 
            this.txtA4Min.Location = new System.Drawing.Point(9, 221);
            this.txtA4Min.Name = "txtA4Min";
            this.txtA4Min.Size = new System.Drawing.Size(100, 20);
            this.txtA4Min.TabIndex = 27;
            this.txtA4Min.Text = "150";
            // 
            // txtA3Min
            // 
            this.txtA3Min.Location = new System.Drawing.Point(9, 173);
            this.txtA3Min.Name = "txtA3Min";
            this.txtA3Min.Size = new System.Drawing.Size(100, 20);
            this.txtA3Min.TabIndex = 26;
            this.txtA3Min.Text = "150";
            // 
            // txtA2Min
            // 
            this.txtA2Min.Location = new System.Drawing.Point(9, 125);
            this.txtA2Min.Name = "txtA2Min";
            this.txtA2Min.Size = new System.Drawing.Size(100, 20);
            this.txtA2Min.TabIndex = 25;
            this.txtA2Min.Text = "150";
            // 
            // txtA4Max
            // 
            this.txtA4Max.Location = new System.Drawing.Point(410, 221);
            this.txtA4Max.Name = "txtA4Max";
            this.txtA4Max.Size = new System.Drawing.Size(100, 20);
            this.txtA4Max.TabIndex = 24;
            this.txtA4Max.Text = "600";
            // 
            // txtA3Max
            // 
            this.txtA3Max.Location = new System.Drawing.Point(410, 173);
            this.txtA3Max.Name = "txtA3Max";
            this.txtA3Max.Size = new System.Drawing.Size(100, 20);
            this.txtA3Max.TabIndex = 23;
            this.txtA3Max.Text = "600";
            // 
            // txtA2Max
            // 
            this.txtA2Max.Location = new System.Drawing.Point(410, 125);
            this.txtA2Max.Name = "txtA2Max";
            this.txtA2Max.Size = new System.Drawing.Size(100, 20);
            this.txtA2Max.TabIndex = 22;
            this.txtA2Max.Text = "600";
            // 
            // txtA1Max
            // 
            this.txtA1Max.Location = new System.Drawing.Point(410, 81);
            this.txtA1Max.Name = "txtA1Max";
            this.txtA1Max.Size = new System.Drawing.Size(100, 20);
            this.txtA1Max.TabIndex = 21;
            this.txtA1Max.Text = "600";
            // 
            // txtA1Min
            // 
            this.txtA1Min.Location = new System.Drawing.Point(9, 81);
            this.txtA1Min.Name = "txtA1Min";
            this.txtA1Min.Size = new System.Drawing.Size(100, 20);
            this.txtA1Min.TabIndex = 20;
            this.txtA1Min.Text = "150";
            // 
            // tbA1
            // 
            this.tbA1.Location = new System.Drawing.Point(115, 81);
            this.tbA1.Maximum = 600;
            this.tbA1.Minimum = 150;
            this.tbA1.Name = "tbA1";
            this.tbA1.Size = new System.Drawing.Size(289, 42);
            this.tbA1.TabIndex = 16;
            this.tbA1.Value = 150;
            // 
            // bttWrite
            // 
            this.bttWrite.Location = new System.Drawing.Point(18, 295);
            this.bttWrite.Name = "bttWrite";
            this.bttWrite.Size = new System.Drawing.Size(75, 23);
            this.bttWrite.TabIndex = 15;
            this.bttWrite.Text = "write";
            this.bttWrite.UseVisualStyleBackColor = true;
            this.bttWrite.Click += new System.EventHandler(this.bttWrite_Click);
            // 
            // tbPmwWeite
            // 
            this.tbPmwWeite.Location = new System.Drawing.Point(255, 41);
            this.tbPmwWeite.Name = "tbPmwWeite";
            this.tbPmwWeite.Size = new System.Drawing.Size(34, 20);
            this.tbPmwWeite.TabIndex = 34;
            this.tbPmwWeite.Text = "200";
            // 
            // I2CModePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "I2CModePanel";
            this.Size = new System.Drawing.Size(854, 557);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbA4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bttStop;
        private System.Windows.Forms.Button bttRun;
        private System.Windows.Forms.Label lbDeviceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label runtimeLabel;
        private System.Windows.Forms.Label runStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttWrite;
        private System.Windows.Forms.TextBox txtA4Min;
        private System.Windows.Forms.TextBox txtA3Min;
        private System.Windows.Forms.TextBox txtA2Min;
        private System.Windows.Forms.TextBox txtA4Max;
        private System.Windows.Forms.TextBox txtA3Max;
        private System.Windows.Forms.TextBox txtA2Max;
        private System.Windows.Forms.TextBox txtA1Max;
        private System.Windows.Forms.TextBox txtA1Min;
        private System.Windows.Forms.TrackBar tbA1;
        private System.Windows.Forms.TrackBar tbA4;
        private System.Windows.Forms.TrackBar tbA3;
        private System.Windows.Forms.TrackBar tbA2;
        private System.Windows.Forms.Button bttSetFre;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox port1selectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox port1Output;
        private System.Windows.Forms.CheckedListBox port1Input;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox port0selectAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox port0Output;
        private System.Windows.Forms.CheckedListBox port0Input;
        private System.Windows.Forms.TextBox tbPmwWeite;
    }
}
