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
            this.components = new System.ComponentModel.Container();
            this.bttStop = new System.Windows.Forms.Button();
            this.bttRun = new System.Windows.Forms.Button();
            this.lbDeviceNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.runtimeLabel = new System.Windows.Forms.Label();
            this.runStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.runSavePoints = new System.Windows.Forms.Button();
            this.bttSaveValues = new System.Windows.Forms.Button();
            this.tbPmwWeite = new System.Windows.Forms.TextBox();
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
            this.txtA4 = new System.Windows.Forms.TextBox();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.tbA1 = new System.Windows.Forms.TrackBar();
            this.runList = new System.Windows.Forms.ListBox();
            this.txtOut1 = new System.Windows.Forms.TextBox();
            this.txtOut2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtOut3 = new System.Windows.Forms.TextBox();
            this.txtOut4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtOut4);
            this.panel1.Controls.Add(this.txtOut3);
            this.panel1.Controls.Add(this.txtOut2);
            this.panel1.Controls.Add(this.txtOut1);
            this.panel1.Controls.Add(this.runList);
            this.panel1.Controls.Add(this.runSavePoints);
            this.panel1.Controls.Add(this.bttSaveValues);
            this.panel1.Controls.Add(this.tbPmwWeite);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.bttSetFre);
            this.panel1.Controls.Add(this.tbA4);
            this.panel1.Controls.Add(this.tbA3);
            this.panel1.Controls.Add(this.tbA2);
            this.panel1.Controls.Add(this.txtA4);
            this.panel1.Controls.Add(this.txtA3);
            this.panel1.Controls.Add(this.txtA2);
            this.panel1.Controls.Add(this.txtA1);
            this.panel1.Controls.Add(this.tbA1);
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
            // runSavePoints
            // 
            this.runSavePoints.Location = new System.Drawing.Point(449, 268);
            this.runSavePoints.Name = "runSavePoints";
            this.runSavePoints.Size = new System.Drawing.Size(119, 23);
            this.runSavePoints.TabIndex = 36;
            this.runSavePoints.Text = "Laufen";
            this.runSavePoints.UseVisualStyleBackColor = true;
            this.runSavePoints.Click += new System.EventHandler(this.runSavePoints_Click);
            // 
            // bttSaveValues
            // 
            this.bttSaveValues.Location = new System.Drawing.Point(449, 79);
            this.bttSaveValues.Name = "bttSaveValues";
            this.bttSaveValues.Size = new System.Drawing.Size(119, 23);
            this.bttSaveValues.TabIndex = 35;
            this.bttSaveValues.Text = "Werte Speichern";
            this.bttSaveValues.UseVisualStyleBackColor = true;
            this.bttSaveValues.Click += new System.EventHandler(this.bttSaveValues_Click);
            // 
            // tbPmwWeite
            // 
            this.tbPmwWeite.Location = new System.Drawing.Point(255, 41);
            this.tbPmwWeite.Name = "tbPmwWeite";
            this.tbPmwWeite.Size = new System.Drawing.Size(34, 20);
            this.tbPmwWeite.TabIndex = 34;
            this.tbPmwWeite.Text = "50";
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
            this.tbA4.Location = new System.Drawing.Point(18, 219);
            this.tbA4.Maximum = 85;
            this.tbA4.Minimum = 45;
            this.tbA4.Name = "tbA4";
            this.tbA4.Size = new System.Drawing.Size(289, 42);
            this.tbA4.TabIndex = 30;
            this.tbA4.Value = 45;
            this.tbA4.ValueChanged += new System.EventHandler(this.tbA4_ValueChanged);
            // 
            // tbA3
            // 
            this.tbA3.Location = new System.Drawing.Point(18, 171);
            this.tbA3.Maximum = 100;
            this.tbA3.Minimum = 30;
            this.tbA3.Name = "tbA3";
            this.tbA3.Size = new System.Drawing.Size(289, 42);
            this.tbA3.TabIndex = 29;
            this.tbA3.Value = 30;
            this.tbA3.ValueChanged += new System.EventHandler(this.tbA3_ValueChanged);
            // 
            // tbA2
            // 
            this.tbA2.Location = new System.Drawing.Point(18, 123);
            this.tbA2.Maximum = 100;
            this.tbA2.Minimum = 20;
            this.tbA2.Name = "tbA2";
            this.tbA2.Size = new System.Drawing.Size(289, 42);
            this.tbA2.TabIndex = 28;
            this.tbA2.Value = 60;
            this.tbA2.ValueChanged += new System.EventHandler(this.tbA2_ValueChanged);
            // 
            // txtA4
            // 
            this.txtA4.Location = new System.Drawing.Point(365, 219);
            this.txtA4.Name = "txtA4";
            this.txtA4.Size = new System.Drawing.Size(33, 20);
            this.txtA4.TabIndex = 24;
            this.txtA4.Text = "45";
       
            // 
            // txtA3
            // 
            this.txtA3.Location = new System.Drawing.Point(365, 171);
            this.txtA3.Name = "txtA3";
            this.txtA3.Size = new System.Drawing.Size(33, 20);
            this.txtA3.TabIndex = 23;
            this.txtA3.Text = "30";
       
            // 
            // txtA2
            // 
            this.txtA2.Location = new System.Drawing.Point(365, 123);
            this.txtA2.Name = "txtA2";
            this.txtA2.Size = new System.Drawing.Size(33, 20);
            this.txtA2.TabIndex = 22;
            this.txtA2.Text = "20";
         
            // 
            // txtA1
            // 
            this.txtA1.Location = new System.Drawing.Point(365, 79);
            this.txtA1.Name = "txtA1";
            this.txtA1.Size = new System.Drawing.Size(33, 20);
            this.txtA1.TabIndex = 21;
            this.txtA1.Text = "70";
    
            // 
            // tbA1
            // 
            this.tbA1.Location = new System.Drawing.Point(18, 79);
            this.tbA1.Maximum = 90;
            this.tbA1.Minimum = 70;
            this.tbA1.Name = "tbA1";
            this.tbA1.Size = new System.Drawing.Size(289, 42);
            this.tbA1.TabIndex = 16;
            this.tbA1.Value = 70;
            this.tbA1.ValueChanged += new System.EventHandler(this.tbA1_ValueChanged);
            // 
            // runList
            // 
            this.runList.FormattingEnabled = true;
            this.runList.Location = new System.Drawing.Point(30, 268);
            this.runList.Name = "runList";
            this.runList.ScrollAlwaysVisible = true;
            this.runList.Size = new System.Drawing.Size(383, 264);
            this.runList.TabIndex = 37;
            // 
            // txtOut1
            // 
            this.txtOut1.Enabled = false;
            this.txtOut1.Location = new System.Drawing.Point(304, 81);
            this.txtOut1.Name = "txtOut1";
            this.txtOut1.Size = new System.Drawing.Size(43, 20);
            this.txtOut1.TabIndex = 38;
            // 
            // txtOut2
            // 
            this.txtOut2.Enabled = false;
            this.txtOut2.Location = new System.Drawing.Point(304, 123);
            this.txtOut2.Name = "txtOut2";
            this.txtOut2.Size = new System.Drawing.Size(43, 20);
            this.txtOut2.TabIndex = 39;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtOut3
            // 
            this.txtOut3.Enabled = false;
            this.txtOut3.Location = new System.Drawing.Point(304, 171);
            this.txtOut3.Name = "txtOut3";
            this.txtOut3.Size = new System.Drawing.Size(43, 20);
            this.txtOut3.TabIndex = 40;
            // 
            // txtOut4
            // 
            this.txtOut4.Enabled = false;
            this.txtOut4.Location = new System.Drawing.Point(304, 219);
            this.txtOut4.Name = "txtOut4";
            this.txtOut4.Size = new System.Drawing.Size(43, 20);
            this.txtOut4.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
        private System.Windows.Forms.TextBox txtA4;
        private System.Windows.Forms.TextBox txtA3;
        private System.Windows.Forms.TextBox txtA2;
        private System.Windows.Forms.TextBox txtA1;
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
        private System.Windows.Forms.Button runSavePoints;
        private System.Windows.Forms.Button bttSaveValues;
        private System.Windows.Forms.ListBox runList;
        private System.Windows.Forms.TextBox txtOut4;
        private System.Windows.Forms.TextBox txtOut3;
        private System.Windows.Forms.TextBox txtOut2;
        private System.Windows.Forms.TextBox txtOut1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
    }
}
