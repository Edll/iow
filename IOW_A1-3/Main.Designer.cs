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
            this.tabWarriorInfo = new System.Windows.Forms.TabPage();
            this.bttReadInfos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfConDevices = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabWarriorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabControl);
            this.tabControl1.Controls.Add(this.tabWarriorInfo);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1214, 446);
            this.tabControl1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(4, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(1206, 420);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Controll";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // tabWarriorInfo
            // 
            this.tabWarriorInfo.Controls.Add(this.dataGridView1);
            this.tabWarriorInfo.Controls.Add(this.NumberOfConDevices);
            this.tabWarriorInfo.Controls.Add(this.label1);
            this.tabWarriorInfo.Controls.Add(this.bttReadInfos);
            this.tabWarriorInfo.Location = new System.Drawing.Point(4, 22);
            this.tabWarriorInfo.Name = "tabWarriorInfo";
            this.tabWarriorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarriorInfo.Size = new System.Drawing.Size(1206, 420);
            this.tabWarriorInfo.TabIndex = 1;
            this.tabWarriorInfo.Text = "IO Warrior Info";
            this.tabWarriorInfo.UseVisualStyleBackColor = true;
            // 
            // bttReadInfos
            // 
            this.bttReadInfos.Location = new System.Drawing.Point(7, 7);
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
            this.label1.Location = new System.Drawing.Point(88, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Connected Devices";
            // 
            // NumberOfConDevices
            // 
            this.NumberOfConDevices.AutoSize = true;
            this.NumberOfConDevices.Location = new System.Drawing.Point(247, 12);
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
            this.dataGridView1.Location = new System.Drawing.Point(7, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1196, 380);
            this.dataGridView1.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 471);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "IO Warrior";
            this.tabControl1.ResumeLayout(false);
            this.tabWarriorInfo.ResumeLayout(false);
            this.tabWarriorInfo.PerformLayout();
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
    }
}

