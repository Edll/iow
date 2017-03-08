namespace IoWarrior
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.ioWarriorInfoTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorLogTab = new System.Windows.Forms.TabPage();
            this.ErrorLogList = new System.Windows.Forms.ListBox();
            this.eventLogTab = new System.Windows.Forms.TabPage();
            this.EventLogList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbI2C = new System.Windows.Forms.RadioButton();
            this.rbLCDMode = new System.Windows.Forms.RadioButton();
            this.rbIOMode = new System.Windows.Forms.RadioButton();
            this.runDeviceSelecter = new System.Windows.Forms.ComboBox();
            this.bttRemoveMode = new System.Windows.Forms.Button();
            this.bttAddMode = new System.Windows.Forms.Button();
            this.tabControlDevices = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.ioWarriorInfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.errorLogTab.SuspendLayout();
            this.eventLogTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.abouteToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.abouteToolStripMenuItem.Text = "About";
            this.abouteToolStripMenuItem.Click += new System.EventHandler(this.OnClick_ShowAbout);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.numberOfConnectedDevicesLabel,
            this.NumberOfConDevices});
            this.statusStrip1.Location = new System.Drawing.Point(0, 828);
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
            this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControlDevices, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 804);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.ioWarriorInfoTab);
            this.tabControl2.Controls.Add(this.errorLogTab);
            this.tabControl2.Controls.Add(this.eventLogTab);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 699);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(876, 102);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl2.TabIndex = 3;
            // 
            // ioWarriorInfoTab
            // 
            this.ioWarriorInfoTab.Controls.Add(this.dataGridView1);
            this.ioWarriorInfoTab.Location = new System.Drawing.Point(4, 4);
            this.ioWarriorInfoTab.Name = "ioWarriorInfoTab";
            this.ioWarriorInfoTab.Size = new System.Drawing.Size(868, 76);
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
            this.dataGridView1.Size = new System.Drawing.Size(868, 76);
            this.dataGridView1.TabIndex = 4;
            // 
            // errorLogTab
            // 
            this.errorLogTab.Controls.Add(this.ErrorLogList);
            this.errorLogTab.Location = new System.Drawing.Point(4, 4);
            this.errorLogTab.Name = "errorLogTab";
            this.errorLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.errorLogTab.Size = new System.Drawing.Size(868, 76);
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
            this.ErrorLogList.Size = new System.Drawing.Size(862, 70);
            this.ErrorLogList.TabIndex = 7;
            // 
            // eventLogTab
            // 
            this.eventLogTab.Controls.Add(this.EventLogList);
            this.eventLogTab.Location = new System.Drawing.Point(4, 4);
            this.eventLogTab.Name = "eventLogTab";
            this.eventLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventLogTab.Size = new System.Drawing.Size(868, 76);
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
            this.EventLogList.Size = new System.Drawing.Size(862, 70);
            this.EventLogList.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.rbI2C);
            this.panel1.Controls.Add(this.rbLCDMode);
            this.panel1.Controls.Add(this.rbIOMode);
            this.panel1.Controls.Add(this.runDeviceSelecter);
            this.panel1.Controls.Add(this.bttRemoveMode);
            this.panel1.Controls.Add(this.bttAddMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 46);
            this.panel1.TabIndex = 2;
            // 
            // rbI2C
            // 
            this.rbI2C.AutoSize = true;
            this.rbI2C.Location = new System.Drawing.Point(290, 16);
            this.rbI2C.Name = "rbI2C";
            this.rbI2C.Size = new System.Drawing.Size(71, 17);
            this.rbI2C.TabIndex = 14;
            this.rbI2C.Text = "I2C Mode";
            this.rbI2C.UseVisualStyleBackColor = true;
            // 
            // rbLCDMode
            // 
            this.rbLCDMode.AutoSize = true;
            this.rbLCDMode.Location = new System.Drawing.Point(208, 16);
            this.rbLCDMode.Name = "rbLCDMode";
            this.rbLCDMode.Size = new System.Drawing.Size(76, 17);
            this.rbLCDMode.TabIndex = 13;
            this.rbLCDMode.Text = "LCD Mode";
            this.rbLCDMode.UseVisualStyleBackColor = true;
            // 
            // rbIOMode
            // 
            this.rbIOMode.AutoSize = true;
            this.rbIOMode.Checked = true;
            this.rbIOMode.Location = new System.Drawing.Point(136, 16);
            this.rbIOMode.Name = "rbIOMode";
            this.rbIOMode.Size = new System.Drawing.Size(66, 17);
            this.rbIOMode.TabIndex = 12;
            this.rbIOMode.TabStop = true;
            this.rbIOMode.Text = "IO Mode";
            this.rbIOMode.UseVisualStyleBackColor = true;
            // 
            // runDeviceSelecter
            // 
            this.runDeviceSelecter.FormattingEnabled = true;
            this.runDeviceSelecter.Location = new System.Drawing.Point(9, 12);
            this.runDeviceSelecter.Name = "runDeviceSelecter";
            this.runDeviceSelecter.Size = new System.Drawing.Size(121, 21);
            this.runDeviceSelecter.TabIndex = 11;
            // 
            // bttRemoveMode
            // 
            this.bttRemoveMode.Enabled = false;
            this.bttRemoveMode.Location = new System.Drawing.Point(452, 13);
            this.bttRemoveMode.Name = "bttRemoveMode";
            this.bttRemoveMode.Size = new System.Drawing.Size(75, 23);
            this.bttRemoveMode.TabIndex = 8;
            this.bttRemoveMode.Text = "Remove";
            this.bttRemoveMode.UseVisualStyleBackColor = true;
            this.bttRemoveMode.Click += new System.EventHandler(this.Click_RemoveSelectedDevice);
            // 
            // bttAddMode
            // 
            this.bttAddMode.Location = new System.Drawing.Point(371, 13);
            this.bttAddMode.Name = "bttAddMode";
            this.bttAddMode.Size = new System.Drawing.Size(75, 23);
            this.bttAddMode.TabIndex = 6;
            this.bttAddMode.Text = "Add";
            this.bttAddMode.UseVisualStyleBackColor = true;
            this.bttAddMode.Click += new System.EventHandler(this.Click_AddSelectedDevice);
            // 
            // tabControlDevices
            // 
            this.tabControlDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDevices.Location = new System.Drawing.Point(3, 55);
            this.tabControlDevices.Name = "tabControlDevices";
            this.tabControlDevices.SelectedIndex = 0;
            this.tabControlDevices.Size = new System.Drawing.Size(876, 638);
            this.tabControlDevices.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 850);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "IO Warrior I/O";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseProgramm);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ioWarriorInfoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.errorLogTab.ResumeLayout(false);
            this.eventLogTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ioWarriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel numberOfConnectedDevicesLabel;
        private System.Windows.Forms.ToolStripStatusLabel NumberOfConDevices;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttRemoveMode;
        private System.Windows.Forms.Button bttAddMode;
        private System.Windows.Forms.ToolStripMenuItem readInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abouteToolStripMenuItem;
        private System.Windows.Forms.ComboBox runDeviceSelecter;
        private System.Windows.Forms.RadioButton rbLCDMode;
        private System.Windows.Forms.RadioButton rbIOMode;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage ioWarriorInfoTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage errorLogTab;
        private System.Windows.Forms.ListBox ErrorLogList;
        private System.Windows.Forms.TabPage eventLogTab;
        private System.Windows.Forms.ListBox EventLogList;
        private System.Windows.Forms.TabControl tabControlDevices;
        private System.Windows.Forms.RadioButton rbI2C;
    }
}

