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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.ioWarriorInfoTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorLogTab = new System.Windows.Forms.TabPage();
            this.ErrorLogList = new System.Windows.Forms.ListBox();
            this.eventLogTab = new System.Windows.Forms.TabPage();
            this.EventLogList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ioWarriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.numberOfConnectedDevicesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumberOfConDevices = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.runDeviceSelecter = new System.Windows.Forms.ComboBox();
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
            this.tabControl2.SuspendLayout();
            this.ioWarriorInfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.errorLogTab.SuspendLayout();
            this.eventLogTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.ioWarriorInfoTab);
            this.tabControl2.Controls.Add(this.errorLogTab);
            this.tabControl2.Controls.Add(this.eventLogTab);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 423);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(876, 137);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl2.TabIndex = 1;
            // 
            // ioWarriorInfoTab
            // 
            this.ioWarriorInfoTab.Controls.Add(this.dataGridView1);
            this.ioWarriorInfoTab.Location = new System.Drawing.Point(4, 4);
            this.ioWarriorInfoTab.Name = "ioWarriorInfoTab";
            this.ioWarriorInfoTab.Size = new System.Drawing.Size(868, 111);
            this.ioWarriorInfoTab.TabIndex = 2;
            this.ioWarriorInfoTab.Text = "IO Warrior Infos";
            this.ioWarriorInfoTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(868, 111);
            this.dataGridView1.TabIndex = 4;
            // 
            // errorLogTab
            // 
            this.errorLogTab.Controls.Add(this.ErrorLogList);
            this.errorLogTab.Location = new System.Drawing.Point(4, 4);
            this.errorLogTab.Name = "errorLogTab";
            this.errorLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.errorLogTab.Size = new System.Drawing.Size(868, 111);
            this.errorLogTab.TabIndex = 0;
            this.errorLogTab.Text = "Error Log";
            this.errorLogTab.UseVisualStyleBackColor = true;
            // 
            // ErrorLogList
            // 
            this.ErrorLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorLogList.ForeColor = System.Drawing.Color.Red;
            this.ErrorLogList.FormattingEnabled = true;
            this.ErrorLogList.Location = new System.Drawing.Point(3, 3);
            this.ErrorLogList.Name = "ErrorLogList";
            this.ErrorLogList.Size = new System.Drawing.Size(862, 105);
            this.ErrorLogList.TabIndex = 7;
            // 
            // eventLogTab
            // 
            this.eventLogTab.Controls.Add(this.EventLogList);
            this.eventLogTab.Location = new System.Drawing.Point(4, 4);
            this.eventLogTab.Name = "eventLogTab";
            this.eventLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventLogTab.Size = new System.Drawing.Size(868, 111);
            this.eventLogTab.TabIndex = 1;
            this.eventLogTab.Text = "Event Log";
            this.eventLogTab.UseVisualStyleBackColor = true;
            // 
            // EventLogList
            // 
            this.EventLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventLogList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EventLogList.FormattingEnabled = true;
            this.EventLogList.Location = new System.Drawing.Point(3, 3);
            this.EventLogList.Name = "EventLogList";
            this.EventLogList.Size = new System.Drawing.Size(862, 105);
            this.EventLogList.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ioWarriorToolStripMenuItem,
            this.readInToolStripMenuItem1,
            this.closeAllToolStripMenuItem1,
            this.abouteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ioWarriorToolStripMenuItem
            // 
            this.ioWarriorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endToolStripMenuItem});
            this.ioWarriorToolStripMenuItem.Name = "ioWarriorToolStripMenuItem";
            this.ioWarriorToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ioWarriorToolStripMenuItem.Text = "IoWarrior";
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.endToolStripMenuItem.Text = "End";
            // 
            // readInToolStripMenuItem1
            // 
            this.readInToolStripMenuItem1.Name = "readInToolStripMenuItem1";
            this.readInToolStripMenuItem1.Size = new System.Drawing.Size(100, 20);
            this.readInToolStripMenuItem1.Text = "Open Connected";
            this.readInToolStripMenuItem1.Click += new System.EventHandler(this.OnClick_OpenAllConnected);
            // 
            // closeAllToolStripMenuItem1
            // 
            this.closeAllToolStripMenuItem1.Enabled = false;
            this.closeAllToolStripMenuItem1.Name = "closeAllToolStripMenuItem1";
            this.closeAllToolStripMenuItem1.Size = new System.Drawing.Size(100, 20);
            this.closeAllToolStripMenuItem1.Text = "Close Connected";
            this.closeAllToolStripMenuItem1.Click += new System.EventHandler(this.OnClick_CloseConnected);
            // 
            // abouteToolStripMenuItem
            // 
            this.abouteToolStripMenuItem.Name = "abouteToolStripMenuItem";
            this.abouteToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.abouteToolStripMenuItem.Text = "Aboute";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.numberOfConnectedDevicesLabel,
            this.NumberOfConDevices});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // numberOfConnectedDevicesLabel
            // 
            this.numberOfConnectedDevicesLabel.Name = "numberOfConnectedDevicesLabel";
            this.numberOfConnectedDevicesLabel.Size = new System.Drawing.Size(152, 17);
            this.numberOfConnectedDevicesLabel.Text = "Number of Connected Devices";
            // 
            // NumberOfConDevices
            // 
            this.NumberOfConDevices.Name = "NumberOfConDevices";
            this.NumberOfConDevices.Size = new System.Drawing.Size(13, 17);
            this.NumberOfConDevices.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.60036F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.39964F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 563);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.runDeviceSelecter);
            this.panel1.Controls.Add(this.runtimeLabel);
            this.panel1.Controls.Add(this.runStatus);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.bttStop);
            this.panel1.Controls.Add(this.bttRun);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 414);
            this.panel1.TabIndex = 2;
            // 
            // runDeviceSelecter
            // 
            this.runDeviceSelecter.FormattingEnabled = true;
            this.runDeviceSelecter.Location = new System.Drawing.Point(9, 12);
            this.runDeviceSelecter.Name = "runDeviceSelecter";
            this.runDeviceSelecter.Size = new System.Drawing.Size(121, 21);
            this.runDeviceSelecter.TabIndex = 11;
            // 
            // runtimeLabel
            // 
            this.runtimeLabel.AutoSize = true;
            this.runtimeLabel.Location = new System.Drawing.Point(326, 15);
            this.runtimeLabel.Name = "runtimeLabel";
            this.runtimeLabel.Size = new System.Drawing.Size(29, 13);
            this.runtimeLabel.TabIndex = 10;
            this.runtimeLabel.Text = "0 ms";
            // 
            // runStatus
            // 
            this.runStatus.BackColor = System.Drawing.Color.Red;
            this.runStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.runStatus.Location = new System.Drawing.Point(298, 10);
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
            this.port1invert.CheckedChanged += new System.EventHandler(this.checked_port1invert);
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
            this.bttStop.Location = new System.Drawing.Point(217, 10);
            this.bttStop.Name = "bttStop";
            this.bttStop.Size = new System.Drawing.Size(75, 23);
            this.bttStop.TabIndex = 8;
            this.bttStop.Text = "stop";
            this.bttStop.UseVisualStyleBackColor = true;
            this.bttStop.Click += new System.EventHandler(this.Click_StopSelectedDevice);
            // 
            // bttRun
            // 
            this.bttRun.Location = new System.Drawing.Point(136, 10);
            this.bttRun.Name = "bttRun";
            this.bttRun.Size = new System.Drawing.Size(75, 23);
            this.bttRun.TabIndex = 6;
            this.bttRun.Text = "run";
            this.bttRun.UseVisualStyleBackColor = true;
            this.bttRun.Click += new System.EventHandler(this.Click_RunSelectedDevice);
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
            this.port0invert.CheckedChanged += new System.EventHandler(this.checked_port0invert);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 609);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "IO Warrior";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseProgramm);
            this.tabControl2.ResumeLayout(false);
            this.ioWarriorInfoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.errorLogTab.ResumeLayout(false);
            this.eventLogTab.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage errorLogTab;
        private System.Windows.Forms.ListBox ErrorLogList;
        private System.Windows.Forms.TabPage eventLogTab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage ioWarriorInfoTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem ioWarriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel numberOfConnectedDevicesLabel;
        private System.Windows.Forms.ToolStripStatusLabel NumberOfConDevices;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.ListBox EventLogList;
        private System.Windows.Forms.ToolStripMenuItem readInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abouteToolStripMenuItem;
        private System.Windows.Forms.ComboBox runDeviceSelecter;
    }
}

