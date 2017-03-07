﻿using System;
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
    public partial class I2CModePanel : UserControl {
        private delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);

        private delegate void SetStringCallback(string text);

        private delegate void SetObjectCallback(List<LogEntry> ojc);

        private readonly DeviceFactory _deviceFactory;
        private readonly Device _device;

        private I2CMode mode = new I2CMode();
        private IowLibary.robot.PMW _pmw;

        /// <summary>
        /// Panel to show the IOMode
        /// </summary>
        /// <param name="deviceFactory">current instacen of device Factory</param>
        /// <param name="device">device which should be show</param>
        public I2CModePanel(DeviceFactory deviceFactory, Device device) {
            _deviceFactory = deviceFactory;
            _device = device;
            InitializeComponent();

            lbDeviceNumber.Text = Convert.ToString(_device?.DeviceNumber ?? 0);
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
            _deviceFactory.RunDevice(_device.DeviceNumber, Device_PortChangeStatus, DeviceFactoryRunTimeUpdate, mode);


            GuiUtils.CreatePortEntrys(port0Input, false);
            GuiUtils.CreatePortEntrys(port1Input, false);

            // create outputs
            GuiUtils.CreatePortEntrys(port0Output, true);
            port0Output.ItemCheck += Port0Output_ItemCheck;
            GuiUtils.CreatePortEntrys(port1Output, true);
            port1Output.ItemCheck += Port1Output_ItemCheck;

            _deviceFactory.RunDevice(_device.DeviceNumber, Device_PortChangeStatus, DeviceFactoryRunTimeUpdate, mode);

            _pmw = new IowLibary.robot.PMW(_device, (byte)0x00);
        }

        private void ClearDevice() {
            _deviceFactory.StopDevice(_device.DeviceNumber);

            port0Input.Items.Clear();
            port1Input.Items.Clear();
            port0Output.Items.Clear();
            port1Output.Items.Clear();
        }

        private void bttWrite_Click(object sender, EventArgs e) {
        }

        private void bttSetFre_Click(object sender, EventArgs e) {
            try {
                int range = Convert.ToInt32(tbPmwWeite.Text);
                _pmw.SetFrequenz(50);
            }catch(FormatException) {
                tbPmwWeite.BackColor = Color.IndianRed;
            }
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
            }
            else {
                clb.SetItemChecked(index, !value);
            }
        }

        private void DeviceFactoryRunTimeUpdate(long runtime) {
            if (runtimeLabel.InvokeRequired) {
                var slc = new SetStringCallback(SetRuntimeLabelText);
                Invoke(slc, Convert.ToString(runtime));
            }
            else {
                SetRuntimeLabelText(Convert.ToString(runtime));
            }
        }

        private void Port0Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            const int port = 0;
            CheckOutputBit(sender, e, port, _device.DeviceNumber);
        }

        private void Port1Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            const int port = 1;
            CheckOutputBit(sender, e, port, _device.DeviceNumber);
        }

        private void CheckOutputBit(object sender, ItemCheckEventArgs e, int port, int device) {
            if (!(sender is CheckedListBox)) return;
            var clb = (CheckedListBox)sender;
            var bit = Convert.ToInt32(clb.SelectedItem);
            var value = e.NewValue == CheckState.Checked;
            _deviceFactory.SetBit(device, port, bit, value);
        }

        private void SetRuntimeLabelText(string text) {
            runtimeLabel.Text = text + Resources.runtime_ms;
        }
    }
}