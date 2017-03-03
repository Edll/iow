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
            this.bttWrite = new System.Windows.Forms.Button();
            this.tbA1 = new System.Windows.Forms.TrackBar();
            this.txtA1Min = new System.Windows.Forms.TextBox();
            this.txtA1Max = new System.Windows.Forms.TextBox();
            this.txtA2Max = new System.Windows.Forms.TextBox();
            this.txtA3Max = new System.Windows.Forms.TextBox();
            this.txtA4Max = new System.Windows.Forms.TextBox();
            this.txtA2Min = new System.Windows.Forms.TextBox();
            this.txtA3Min = new System.Windows.Forms.TextBox();
            this.txtA4Min = new System.Windows.Forms.TextBox();
            this.tbA2 = new System.Windows.Forms.TrackBar();
            this.tbA3 = new System.Windows.Forms.TrackBar();
            this.tbA4 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA4)).BeginInit();
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
            // bttWrite
            // 
            this.bttWrite.Location = new System.Drawing.Point(689, 408);
            this.bttWrite.Name = "bttWrite";
            this.bttWrite.Size = new System.Drawing.Size(75, 23);
            this.bttWrite.TabIndex = 15;
            this.bttWrite.Text = "write";
            this.bttWrite.UseVisualStyleBackColor = true;
            this.bttWrite.Click += new System.EventHandler(this.bttWrite_Click);
            // 
            // tbA1
            // 
            this.tbA1.Location = new System.Drawing.Point(171, 128);
            this.tbA1.Maximum = 600;
            this.tbA1.Minimum = 150;
            this.tbA1.Name = "tbA1";
            this.tbA1.Size = new System.Drawing.Size(289, 42);
            this.tbA1.TabIndex = 16;
            this.tbA1.Value = 150;
            // 
            // txtA1Min
            // 
            this.txtA1Min.Location = new System.Drawing.Point(64, 128);
            this.txtA1Min.Name = "txtA1Min";
            this.txtA1Min.Size = new System.Drawing.Size(100, 20);
            this.txtA1Min.TabIndex = 20;
            this.txtA1Min.Text = "150";
            this.txtA1Min.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtA1Max
            // 
            this.txtA1Max.Location = new System.Drawing.Point(466, 128);
            this.txtA1Max.Name = "txtA1Max";
            this.txtA1Max.Size = new System.Drawing.Size(100, 20);
            this.txtA1Max.TabIndex = 21;
            this.txtA1Max.Text = "600";
            // 
            // txtA2Max
            // 
            this.txtA2Max.Location = new System.Drawing.Point(466, 201);
            this.txtA2Max.Name = "txtA2Max";
            this.txtA2Max.Size = new System.Drawing.Size(100, 20);
            this.txtA2Max.TabIndex = 22;
            this.txtA2Max.Text = "600";
            // 
            // txtA3Max
            // 
            this.txtA3Max.Location = new System.Drawing.Point(466, 271);
            this.txtA3Max.Name = "txtA3Max";
            this.txtA3Max.Size = new System.Drawing.Size(100, 20);
            this.txtA3Max.TabIndex = 23;
            this.txtA3Max.Text = "600";
            // 
            // txtA4Max
            // 
            this.txtA4Max.Location = new System.Drawing.Point(466, 346);
            this.txtA4Max.Name = "txtA4Max";
            this.txtA4Max.Size = new System.Drawing.Size(100, 20);
            this.txtA4Max.TabIndex = 24;
            this.txtA4Max.Text = "600";
            // 
            // txtA2Min
            // 
            this.txtA2Min.Location = new System.Drawing.Point(65, 201);
            this.txtA2Min.Name = "txtA2Min";
            this.txtA2Min.Size = new System.Drawing.Size(100, 20);
            this.txtA2Min.TabIndex = 25;
            this.txtA2Min.Text = "150";
            // 
            // txtA3Min
            // 
            this.txtA3Min.Location = new System.Drawing.Point(62, 271);
            this.txtA3Min.Name = "txtA3Min";
            this.txtA3Min.Size = new System.Drawing.Size(100, 20);
            this.txtA3Min.TabIndex = 26;
            this.txtA3Min.Text = "150";
            // 
            // txtA4Min
            // 
            this.txtA4Min.Location = new System.Drawing.Point(64, 346);
            this.txtA4Min.Name = "txtA4Min";
            this.txtA4Min.Size = new System.Drawing.Size(100, 20);
            this.txtA4Min.TabIndex = 27;
            this.txtA4Min.Text = "150";
            // 
            // tbA2
            // 
            this.tbA2.Location = new System.Drawing.Point(171, 191);
            this.tbA2.Maximum = 600;
            this.tbA2.Minimum = 150;
            this.tbA2.Name = "tbA2";
            this.tbA2.Size = new System.Drawing.Size(289, 42);
            this.tbA2.TabIndex = 28;
            this.tbA2.Value = 150;
            // 
            // tbA3
            // 
            this.tbA3.Location = new System.Drawing.Point(171, 260);
            this.tbA3.Maximum = 600;
            this.tbA3.Minimum = 150;
            this.tbA3.Name = "tbA3";
            this.tbA3.Size = new System.Drawing.Size(289, 42);
            this.tbA3.TabIndex = 29;
            this.tbA3.Value = 150;
            // 
            // tbA4
            // 
            this.tbA4.Location = new System.Drawing.Point(171, 335);
            this.tbA4.Maximum = 600;
            this.tbA4.Minimum = 150;
            this.tbA4.Name = "tbA4";
            this.tbA4.Size = new System.Drawing.Size(289, 42);
            this.tbA4.TabIndex = 30;
            this.tbA4.Value = 150;
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
            ((System.ComponentModel.ISupportInitialize)(this.tbA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA4)).EndInit();
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
    }
}
