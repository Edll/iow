namespace IoWarrior {
    partial class LcdModePanel {
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
            this.line1 = new System.Windows.Forms.TextBox();
            this.line2 = new System.Windows.Forms.TextBox();
            this.bttWrite = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.bttWrite);
            this.panel1.Controls.Add(this.line2);
            this.panel1.Controls.Add(this.line1);
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
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(77, 100);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(289, 20);
            this.line1.TabIndex = 13;
            // 
            // line2
            // 
            this.line2.Location = new System.Drawing.Point(77, 126);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(289, 20);
            this.line2.TabIndex = 14;
            // 
            // bttWrite
            // 
            this.bttWrite.Location = new System.Drawing.Point(373, 115);
            this.bttWrite.Name = "bttWrite";
            this.bttWrite.Size = new System.Drawing.Size(75, 23);
            this.bttWrite.TabIndex = 15;
            this.bttWrite.Text = "write";
            this.bttWrite.UseVisualStyleBackColor = true;
            // 
            // LcdModePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LcdModePanel";
            this.Size = new System.Drawing.Size(854, 557);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox line2;
        private System.Windows.Forms.TextBox line1;
    }
}
