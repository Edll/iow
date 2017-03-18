using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IowLibary;
using IoWarrior.Properties;

namespace IoWarrior {
    /// <summary>
    /// LcdMode Panel for LCD connection
    /// </summary>
    public partial class LcdModePanel : UserControl {
        private delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);
        private delegate void SetStringCallback(string text);
        private delegate void SetObjectCallback(List<LogEntry> ojc);

        private readonly DeviceManager _deviceManager;
        private readonly Device _device;
        private LCDMode mode = new LCDMode();

        /// <summary>
        /// Panel to show the IOMode
        /// </summary>
        /// <param name="deviceManager">current instacen of device Factory</param>
        /// <param name="device">device which should be show</param>
        public LcdModePanel(DeviceManager deviceManager, Device device) {
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
            _deviceManager.RunDevice(_device.DeviceNumber, Device_PortChangeStatus, DeviceFactoryRunTimeUpdate, mode);
        }

        private void ClearDevice() {
            _deviceManager.StopDevice(_device.DeviceNumber);
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



        private void Device_PortChangeStatus(Device device, Port port, PortBit portbit) {
            // TODO muss dynamisch werden je nach art des Devices
            if (port.PortNumber == 0) {

            }
            if (port.PortNumber == 1) {

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

        private void bttWrite_Click(object sender, EventArgs e) {

            mode.SetLine(1, line1.Text);
            mode.SetLine(2, line2.Text);
        }
    }
}
