using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IowLibrary;

namespace IOW_A1_3 {
    public partial class Main : Form {
        private DeviceFactory df;

        public Main() {

            InitializeComponent();

            // open of the DeviceFactory
            df = new DeviceFactory(DeviceFactory_OpenError);


            // ist es möglich ein custom table model zu generieren
            dataPort0.DataSource = IowPortDataTable.GetResultsTable();

        }

        private void bttReadInfos_Click(object sender, EventArgs e) {
            df.Refresh();
            Dictionary<int, Device> devices = df.Devices;

            NumberOfConDevices.Text = devices == null ? "0" : devices.Count.ToString();

            dataGridView1.DataSource = IowDataTable.GetResultsTable(devices);
          
        }


        private static void Device_DeviceError(Device device) {
            MessageBox.Show("Upss....Device error!: " + device.Handler);
        }

        private static void DeviceFactory_OpenError(String deviceError) {
            MessageBox.Show("Problem mit einem Device " + deviceError);
        }

  
    }
}
