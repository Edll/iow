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
            this.groupBox3.Controls.Add(this.port1Output);
            this.groupBox3.Controls.Add(this.port1Input);
            this.groupBox3.Location = new System.Drawing.Point(159, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 162);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port1";
            // 
            // port1Output
            // 
            this.port1Output.CheckOnClick = true;
            this.port1Output.FormattingEnabled = true;
            this.port1Output.Location = new System.Drawing.Point(83, 19);
            this.port1Output.Name = "port1Output";
            this.port1Output.Size = new System.Drawing.Size(55, 124);
            this.port1Output.TabIndex = 1;
            // 
            // port1Input
            // 
            this.port1Input.FormattingEnabled = true;
            this.port1Input.Location = new System.Drawing.Point(6, 19);
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
            this.groupBox2.Controls.Add(this.port0Output);
            this.groupBox2.Controls.Add(this.port0Input);
            this.groupBox2.Location = new System.Drawing.Point(4, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 162);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port0";
            // 
            // port0Output
            // 
            this.port0Output.CheckOnClick = true;
            this.port0Output.FormattingEnabled = true;
            this.port0Output.Location = new System.Drawing.Point(83, 19);
            this.port0Output.Name = "port0Output";
            this.port0Output.Size = new System.Drawing.Size(55, 124);
            this.port0Output.TabIndex = 1;
            // 
            // port0Input
            // 
            this.port0Input.FormattingEnabled = true;
            this.port0Input.Location = new System.Drawing.Point(6, 19);
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
            this.groupBox2.ResumeLayout(false);
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
    }
}

