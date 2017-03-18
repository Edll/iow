using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IowLibary;
using Roboter;
using IoWarrior.Properties;

namespace IoWarrior {
    /// <summary>
    /// IOMode Panel 
    /// </summary>
    public partial class IoModePanel : UserControl {
        private delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);
        private delegate void SetStringCallback(string text);
        private delegate void SetObjectCallback(List<LogEntry> ojc);

        private readonly DeviceManager _deviceManager;
        private readonly Device _device;

        private bool lauflichtRun;
        // create inputs
       private IoMode mode = new IoMode();

        /// <summary>
        /// Panel to show the IOMode
        /// </summary>
        /// <param name="deviceManager">current instacen of device Factory</param>
        /// <param name="device">device which should be show</param>
        public IoModePanel(DeviceManager deviceManager, Device device) {
            _deviceManager = deviceManager;
            _device = device;
            InitializeComponent();

            lbDeviceNumber.Text = _device.DeviceNumber.ToString();
        }

        private void bttRun_Click(object sender, EventArgs e) {

            InitDevice();
            SetButtonStatusRun();
        }

        private void bttStop_Click(object sender, EventArgs e) {
            ClearDevice();

            SetButtonStatusStop();
        }

        private void InitDevice() {
            // TODO wenn es eine anderer IOW ist mit mehr oder weniger ports sollte das hier dynamisch eingefügt werden....

         

            GuiUtils.CreatePortEntrys(port0Input, false);
            GuiUtils.CreatePortEntrys(port1Input, false);

            // create outputs
            GuiUtils.CreatePortEntrys(port0Output, true);
            port0Output.ItemCheck += Port0Output_ItemCheck;
            GuiUtils.CreatePortEntrys(port1Output, true);
            port1Output.ItemCheck += Port1Output_ItemCheck;

            _deviceManager.RunDevice(_device.DeviceNumber, Device_PortChangeStatus, DeviceFactoryRunTimeUpdate, mode);

        }

        private void ClearDevice() {
            _deviceManager.StopDevice(_device.DeviceNumber);

            port0Input.Items.Clear();
            port1Input.Items.Clear();
            port0Output.Items.Clear();
            port1Output.Items.Clear();
        }

        private void SetButtonStatusRun() {
            bttStop.Enabled = true;
            bttRun.Enabled = false;
            runStatus.BackColor = Color.Green;
        }

        private void SetButtonStatusStop() {
            bttRun.Enabled = true;
            bttStop.Enabled = false;
            runStatus.BackColor = Color.Red;
            SetRuntimeLabelText("0");
        }

        private void Port0Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            const int port = 0;
            CheckOutputBit(sender, e, port, _device.DeviceNumber);
        }

        private void Port1Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            const int port = 1;
            CheckOutputBit(sender, e, port, _device.DeviceNumber);
        }

        private void Device_PortChangeStatus(Device device, Port port, PortBit portbit) {
            // TODO muss dynamisch werden je nach art des Devices
            if (port.PortNumber == 0) {
                ChangeCheckOnList(port0Input, portbit.BitNumber, portbit.BitIn);
            }
            if (port.PortNumber == 1) {
                ChangeCheckOnList(port1Input, portbit.BitNumber, portbit.BitIn);
            }
        }

        private void ChangeCheckOnList(CheckedListBox clb, int index, bool value) {
            if (clb.InvokeRequired) {
                var sbc = new SetBoolCallback(ChangeCheckOnList);
                Invoke(sbc, clb, index, value);
            } else {
                clb.SetItemChecked(index, !value);
            }
        }

        private void DeviceFactoryRunTimeUpdate(long runtime) {
            if (runtimeLabel.InvokeRequired) {
                var slc = new SetStringCallback(SetRuntimeLabelText);
                Invoke(slc, Convert.ToString(runtime));
            } else {
                SetRuntimeLabelText(Convert.ToString(runtime));
            }
        }

        private void SetRuntimeLabelText(string text) {
            runtimeLabel.Text = text + Resources.runtime_ms;
        }

        private void CheckOutputBit(object sender, ItemCheckEventArgs e, int port, int device) {
            if (!(sender is CheckedListBox)) return;
            var clb = (CheckedListBox)sender;
            var bit = Convert.ToInt32(clb.SelectedItem);
            var value = e.NewValue == CheckState.Checked;
            _deviceManager.SetBit(device, port, bit, value);
        }

        private void checked_port0selectAll(object sender, EventArgs e) {
            GuiUtils.CheckboxListSetAllItems(sender, port0Output);
        }

        private void checked_port1selectAll(object sender, EventArgs e) {
            GuiUtils.CheckboxListSetAllItems(sender, port1Output);
        }

        private void bttLauflicht_Click(object sender, EventArgs e) {
            if (lauflichtRun) {
                bttLauflicht.Text = "Start";
                lauflichtRun = false;
            }else {
                bttLauflicht.Text = "Stop";
                lauflichtRun = true;
            }
            int timer = int.Parse(timing.Text);
            mode.LaufLicht(timer, lauflichtRun);
        }
    }
}
