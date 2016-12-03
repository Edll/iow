using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using IowLibrary;

namespace IOW_A1_3 {

    public partial class Main : Form {
        private delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);
        private delegate void SetStringCallback(string text);

        private readonly DeviceFactory _deviceFactory;
        public Main() {

            InitializeComponent();
            // open of the DeviceFactory
            _deviceFactory = new DeviceFactory(DeviceFactory_OpenError);
        }

        private void Port0Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            var port = 0;
            var device = 1;
            CheckOutputBit(sender, e, port, device);
        }

        private void Port1Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            var port = 1;
            var device = 1;
            CheckOutputBit(sender, e, port, device);
        }

        private void CheckOutputBit(object sender, ItemCheckEventArgs e, int port, int device) {
            if (!(sender is CheckedListBox)) return;
            var clb = (CheckedListBox)sender;
            var bit = Convert.ToInt32(clb.SelectedItem);
            var value = e.NewValue == CheckState.Checked;
            _deviceFactory.SetBit(device, port, bit, value);
        }

        private void InitDevice() {
            bool isTo = _deviceFactory.InitFactory();

            // create inputs
            GuiUtils.CreatePortEntrys(port0Input, false);
            GuiUtils.CreatePortEntrys(port1Input, false);

            // create outputs
            GuiUtils.CreatePortEntrys(port0Output, true);
            port0Output.ItemCheck += Port0Output_ItemCheck;
            GuiUtils.CreatePortEntrys(port1Output, true);
            port1Output.ItemCheck += Port1Output_ItemCheck;

            var device = _deviceFactory.GetDeviceNumber(1);
            if (device != null) {
                device.PortBitInChange += Device_PortBitChange;
            }
        }

        private void ClearDevice()
        {
                port0Input.Items.Clear();
            port1Input.Items.Clear();
            port0Output.Items.Clear();
            port1Output.Items.Clear();
        }

        private void Device_PortBitChange(Port port, PortBit portbit) {
            if (port.PortNumber == 0) {
                ChangeCheckOnList(port0Input, portbit.BitNumber, portbit.BitIn);
            }
            if (port.PortNumber == 1) {
                ChangeCheckOnList(port1Input, portbit.BitNumber, portbit.BitIn);
            }
        }

        private void ChangeCheckOnList(CheckedListBox clb, int index, bool value) {
            // um das hier ThreadSafe zu machen wird ein Callback erzeugt wenn der aufrufer nicht gleich dem erzeuger ist.
            if (clb.InvokeRequired) {
                var sbc = new SetBoolCallback(ChangeCheckOnList);
                Invoke(sbc, clb, index, value);
            } else {
                clb.SetItemChecked(index, !value);
            }
        }

        private void bttReadInfos_Click(object sender, EventArgs e) {
            _deviceFactory.Refresh();
            var devices = _deviceFactory.Devices;
            NumberOfConDevices.Text = devices?.Count.ToString() ?? "0";
            dataGridView1.DataSource = IowDataTable.GetResultsTable(devices);
        }

        private void DeviceFactory_OpenError(DeviceFactory deviceError) {
            SetErrorLog(deviceError.GetAndResetErrorList());
        }

        private void SetErrorLog(string error) {
            errorLogList.Items.Add(DateTime.Now + " : " + error);
        }

        private void bttRun_Click(object sender, EventArgs e) {
            InitDevice();

            _deviceFactory.RunDevice(1);
            _deviceFactory.RunTimeUpate += DeviceFactoryRunTimeUpate;
            bttStop.Enabled = true;
            bttRun.Enabled = false;
            runStatus.BackColor = Color.Green;
        }

        private void DeviceFactoryRunTimeUpate(long runtime) {
            if (runtimeLabel.InvokeRequired) {
                var slc = new SetStringCallback(SetRuntimeLabelText);
                Invoke(slc, Convert.ToString(runtime));
            } else {
                SetRuntimeLabelText(Convert.ToString(runtime));
            }
        }

        private void SetRuntimeLabelText(string text) {
            runtimeLabel.Text = text + " ms";
        }

        private void bttStop_Click(object sender, EventArgs e) {
            _deviceFactory.StopDevice(1);
            bttRun.Enabled = true;
            bttStop.Enabled = false;
            runStatus.BackColor = Color.Red;
            SetRuntimeLabelText("0");

            ClearDevice();
        }

        private void checked_port1invert(object sender, EventArgs e) {

        }

        private void checked_port0invert(object sender, EventArgs e) {

        }

        private void checked_port0selectAll(object sender, EventArgs e) {
            GuiUtils.CheckboxListSetAllItems(sender, port0Output);
        }

        private void checked_port1selectAll(object sender, EventArgs e) {
            GuiUtils.CheckboxListSetAllItems(sender, port1Output);
        }

        private void CloseProgramm(object sender, FormClosedEventArgs e) {
            _deviceFactory.RemoveAllDevices();
        }
    }
}
