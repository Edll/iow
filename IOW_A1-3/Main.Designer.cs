namespace IOW_A1_3
{
    partial class Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.port1Output = new System.Windows.Forms.CheckedListBox();
            this.port1Input = new System.Windows.Forms.CheckedListBox();
            this.bttStop = new System.Windows.Forms.Button();
            this.bttRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.port0Output = new System.Windows.Forms.CheckedListBox();
            this.port0Input = new System.Windows.Forms.CheckedListBox();
            this.tabWarriorInfo = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttReadInfos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfConDevices = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.port0invert = new System.Windows.Forms.CheckBox();
            this.port1invert = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.port0selectAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.port1selectAll = new System.Windows.Forms.CheckBox();
            this.runStatus = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabWarriorInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabControl);
            this.tabControl1.Controls.Add(this.tabWarriorInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 551);
            this.tabControl1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.runStatus);
            this.tabControl.Controls.Add(this.groupBox3);
            this.tabControl.Controls.Add(this.bttStop);
            this.tabControl.Controls.Add(this.bttRun);
            this.tabControl.Controls.Add(this.groupBox2);
            this.tabControl.Location = new System.Drawing.Point(4, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(953, 525);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Controll";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.port1selectAll);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.port1invert);
            this.groupBox3.Controls.Add(this.port1Output);
            this.groupBox3.Controls.Add(this.port1Input);
            this.groupBox3.Location = new System.Drawing.Point(244, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 226);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port1";
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
            this.bttStop.Location = new System.Drawing.Point(87, 6);
            this.bttStop.Name = "bttStop";
            this.bttStop.Size = new System.Drawing.Size(75, 23);
            this.bttStop.TabIndex = 2;
            this.bttStop.Text = "stop";
            this.bttStop.UseVisualStyleBackColor = true;
            this.bttStop.Click += new System.EventHandler(this.bttStop_Click);
            // 
            // bttRun
            // 
            this.bttRun.Location = new System.Drawing.Point(6, 6);
            this.bttRun.Name = "bttRun";
            this.bttRun.Size = new System.Drawing.Size(75, 23);
            this.bttRun.TabIndex = 1;
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
            this.groupBox2.Location = new System.Drawing.Point(4, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 226);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port0";
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
            // tabWarriorInfo
            // 
            this.tabWarriorInfo.Controls.Add(this.groupBox1);
            this.tabWarriorInfo.Controls.Add(this.dataGridView1);
            this.tabWarriorInfo.Location = new System.Drawing.Point(4, 22);
            this.tabWarriorInfo.Name = "tabWarriorInfo";
            this.tabWarriorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarriorInfo.Size = new System.Drawing.Size(953, 525);
            this.tabWarriorInfo.TabIndex = 1;
            this.tabWarriorInfo.Text = "IO Warrior Info";
            this.tabWarriorInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttReadInfos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NumberOfConDevices);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // bttReadInfos
            // 
            this.bttReadInfos.Location = new System.Drawing.Point(6, 14);
            this.bttReadInfos.Name = "bttReadInfos";
            this.bttReadInfos.Size = new System.Drawing.Size(75, 23);
            this.bttReadInfos.TabIndex = 0;
            this.bttReadInfos.Text = "Read in";
            this.bttReadInfos.UseVisualStyleBackColor = true;
            this.bttReadInfos.Click += new System.EventHandler(this.bttReadInfos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Connected Devices";
            // 
            // NumberOfConDevices
            // 
            this.NumberOfConDevices.AutoSize = true;
            this.NumberOfConDevices.Location = new System.Drawing.Point(246, 19);
            this.NumberOfConDevices.Name = "NumberOfConDevices";
            this.NumberOfConDevices.Size = new System.Drawing.Size(13, 13);
            this.NumberOfConDevices.TabIndex = 2;
            this.NumberOfConDevices.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(941, 464);
            this.dataGridView1.TabIndex = 3;
            // 
            // port0invert
            // 
            this.port0invert.AutoSize = true;
            this.port0invert.Location = new System.Drawing.Point(7, 19);
            this.port0invert.Name = "port0invert";
            this.port0invert.Size = new System.Drawing.Size(54, 17);
            this.port0invert.TabIndex = 2;
            this.port0invert.Text = "Invert";
            this.port0invert.UseVisualStyleBackColor = true;
            this.port0invert.CheckedChanged += new System.EventHandler(this.checked_port0invert);
            // 
            // port1invert
            // 
            this.port1invert.AutoSize = true;
            this.port1invert.Location = new System.Drawing.Point(7, 18);
            this.port1invert.Name = "port1invert";
            this.port1invert.Size = new System.Drawing.Size(54, 17);
            this.port1invert.TabIndex = 2;
            this.port1invert.Text = "Invert";
            this.port1invert.UseVisualStyleBackColor = true;
            this.port1invert.CheckedChanged += new System.EventHandler(this.checked_port1invert);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output";
            // 
            // port0selectAll
            // 
            this.port0selectAll.AutoSize = true;
            this.port0selectAll.Location = new System.Drawing.Point(68, 201);
            this.port0selectAll.Name = "port0selectAll";
            this.port0selectAll.Size = new System.Drawing.Size(38, 17);
            this.port0selectAll.TabIndex = 5;
            this.port0selectAll.Text = "All";
            this.port0selectAll.UseVisualStyleBackColor = true;
            this.port0selectAll.CheckedChanged += new System.EventHandler(this.checked_port0selectAll);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Output";
            // 
            // port1selectAll
            // 
            this.port1selectAll.AutoSize = true;
            this.port1selectAll.Location = new System.Drawing.Point(68, 200);
            this.port1selectAll.Name = "port1selectAll";
            this.port1selectAll.Size = new System.Drawing.Size(38, 17);
            this.port1selectAll.TabIndex = 6;
            this.port1selectAll.Text = "All";
            this.port1selectAll.UseVisualStyleBackColor = true;
            this.port1selectAll.CheckedChanged += new System.EventHandler(this.checked_port1selectAll);
            // 
            // runStatus
            // 
            this.runStatus.BackColor = System.Drawing.Color.Red;
            this.runStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.runStatus.Location = new System.Drawing.Point(168, 6);
            this.runStatus.Name = "runStatus";
            this.runStatus.Size = new System.Drawing.Size(22, 23);
            this.runStatus.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 551);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "IO Warrior";
            this.tabControl1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabWarriorInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.TabPage tabWarriorInfo;
        private System.Windows.Forms.Button bttReadInfos;
        private System.Windows.Forms.Label NumberOfConDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox port0Output;
        private System.Windows.Forms.CheckedListBox port0Input;
        private System.Windows.Forms.Button bttRun;
        private System.Windows.Forms.Button bttStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox port1Output;
        private System.Windows.Forms.CheckedListBox port1Input;
        private System.Windows.Forms.Label runStatus;
        private System.Windows.Forms.CheckBox port1selectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox port1invert;
        private System.Windows.Forms.CheckBox port0selectAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox port0invert;
    }
}

