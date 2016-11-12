using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IowLibrary;
using System.Threading;

namespace IOW_A1_3 {

    public partial class Main : Form {
        delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);

        private DeviceFactory df;
        private DeviceHandler portHandler;
        private Thread portThread;
        public Main() {

            InitializeComponent();

            // open of the DeviceFactory
            df = new DeviceFactory(DeviceFactory_OpenError);

            // create inputs
            createPortEntrys(port0Input, false);
            createPortEntrys(port1Input, false);

            // create outputs
            createPortEntrys(port0Output, true);
            port0Output.ItemCheck += Port0Output_ItemCheck;
            createPortEntrys(port1Output, true);
            port1Output.ItemCheck += Port1Output_ItemCheck;

            Device device = df.GetDeviceNumber(1);
            if (device != null) {
                device.PortBitChange += Device_PortBitChange;
                portHandler = new DeviceHandler(device);
            }
        }

        private void Port1Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            int port = 0;
            int device = 1;
            CheckOutputBit(sender, e, port, device);
        }

        private void Port0Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            int port = 0;
            int device = 1;
            CheckOutputBit(sender, e, port, device);
        }

        private void CheckOutputBit(object sender, ItemCheckEventArgs e, int port, int device) {
            if (sender is CheckedListBox) {
                CheckedListBox clb = (CheckedListBox)sender;
                int bit = Convert.ToInt32(clb.SelectedItem);
                bool value = false;
                if (e.NewValue == CheckState.Checked) {
                    value = true;
                }
                df.SetBit(device, port, bit, value);
            }
        }

        private void Device_PortBitChange(Port port, PortBit portbit) {
            if (port.PortNumber == 0) {
                changeCheckOnList(port0Input, portbit.BitNumber, portbit.BitIn);
            }
            if (port.PortNumber == 1) {
                changeCheckOnList(port1Input, portbit.BitNumber, portbit.BitIn);
            }
        }

        private void changeCheckOnList(CheckedListBox clb, int index, bool value) {
            // um das hier ThreadSafe zu machen wird ein Callback erzeugt wenn der aufrufer nicht gleich dem erzeuger ist.
            if (clb.InvokeRequired) {
                SetBoolCallback sbc = new SetBoolCallback(changeCheckOnList);
                this.Invoke(sbc, new Object[] { clb, index, value });
            } else {
                clb.SetItemChecked(index, value);
            }
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

        private void createPortEntrys(CheckedListBox clb, bool enabel) {
            for (int i = 0; i < PortBit.maxBitNumber + 1; i++) {
                clb.Items.Add(i);
                clb.Enabled = enabel;
            }
        }

        private void bttRun_Click(object sender, EventArgs e) {
            portThread = new Thread(portHandler.IO);
            portThread.Start();
            bttStop.Enabled = true;
            bttRun.Enabled = false;
        }

        private void bttStop_Click(object sender, EventArgs e) {
            bttRun.Enabled = true;
            bttStop.Enabled = false;
            portHandler.RequestStop();
            portThread.Join();
        }
    }
}
