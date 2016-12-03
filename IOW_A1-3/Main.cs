using System;
using System.Drawing;
using System.Windows.Forms;
using IowLibrary;
using IOW_A1_3.Properties;

namespace IOW_A1_3 {

    public partial class Main : Form {
        private delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);
        private delegate void SetStringCallback(string text);

        private readonly DeviceFactory _deviceFactory;

        public Main() {

            InitializeComponent();

            // open of the DeviceFactory
            _deviceFactory = new DeviceFactory(DeviceFactory_Error, DeviceFactory_EventLog);
        }

        private void OnClick_OpenAllConnected(object sender, EventArgs e) {
            var isConnected = _deviceFactory.InitFactory();
            if (!isConnected) return;
            SetDevices();
            closeAllToolStripMenuItem1.Enabled = true;
            readInToolStripMenuItem1.Enabled = false;
        }

        // FIXME: 
        // hier sind ein paar fehler drin...
        // 1.) Die IOW Dll merkt nicht das ein USB device entfernt worden ist sonder behält diesen im speicher, erst wenn ein Schreib fehler auftritt wird das device Entfernt!
        // 2.) Das Close des devices entfernt dieses nicht aus dem DLL speicher. Dadurch ist das einmal geöffnete Devices bis in alle ewigkeiten im speicher
        // 3.) Durch den Statischen import der DLL wird diese bei einem close des devices nicht neu geladen.
        // 4.) Workaround bei einem Close Connected starten wird das ganze programm neu dadruch wird die DLL auch neu geladen. Eventuell kann man durch ein Dynamisches laden des Assembleys das lösen.
        // https://www.codeproject.com/articles/18729/loading-and-unloading-an-assembly-at-runtime
        // das habe ich aber jetzt erstmal hinten angestellt.
        private void OnClick_CloseConnected(object sender, EventArgs e) {
            _deviceFactory.RemoveAllDevices();
            NumberOfConDevices.Text = Resources.Connect_0_devices;
            dataGridView1.DataSource = null;
            closeAllToolStripMenuItem1.Enabled = false;
            readInToolStripMenuItem1.Enabled = true;
            ClearAllDevice();

            // FIXME:
            // WORKAROUND für das DLL speicher problem
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            Close();
        }

        private void Click_RunSelectedDevice(object sender, EventArgs e) {
            if (runDeviceSelecter.SelectedItem == null) return;

            InitDevice(runDeviceSelecter.SelectedItem);

            SetButtonStatusRun();
        }

        private void Click_StopSelectedDevice(object sender, EventArgs e) {
            if (runDeviceSelecter.SelectedItem == null) return;

            ClearDevice(runDeviceSelecter.SelectedItem);

            SetButtonStatusStop();
        }

        private void InitDevice(object selectedDevice) {

            _deviceFactory.RunDevice(selectedDevice, Device_PortChangeStatus, DeviceFactoryRunTimeUpdate);
            // TODO wenn es eine anderer IOW ist mit mehr oder weniger ports sollte das hier dynamisch eingefügt werden....
            // TODO das sollte auch gemacht werden wenn wir mehr als einen IOW laufen lassen.....
            // create inputs
            GuiUtils.CreatePortEntrys(port0Input, false);
            GuiUtils.CreatePortEntrys(port1Input, false);

            // create outputs
            GuiUtils.CreatePortEntrys(port0Output, true);
            port0Output.ItemCheck += Port0Output_ItemCheck;
            GuiUtils.CreatePortEntrys(port1Output, true);
            port1Output.ItemCheck += Port1Output_ItemCheck;
        }

        private void ClearDevice(object selectedDevice) {
            _deviceFactory.StopDevice(selectedDevice);

            // TODO wenn mehrere Laufen sollte hier auch das entsprechende Device gelöscht werden....
            port0Input.Items.Clear();
            port1Input.Items.Clear();
            port0Output.Items.Clear();
            port1Output.Items.Clear();
        }

        private void ClearAllDevice() {
            // TODO wenn die ansicht der Device Dynamisch werden soll muss das hier auch um einen dynamisches löschen erweitert werden....
            ClearDevice(runDeviceSelecter.SelectedItem);
            runDeviceSelecter.Items.Clear();
            SetButtonStatusStop();
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

        private void Port0Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            const int port = 0;
            var device = Convert.ToInt32(runDeviceSelecter.SelectedItem);
            CheckOutputBit(sender, e, port, device);
        }

        private void Port1Output_ItemCheck(object sender, ItemCheckEventArgs e) {
            const int port = 1;
            var device = Convert.ToInt32(runDeviceSelecter.SelectedItem);
            CheckOutputBit(sender, e, port, device);
        }

        private void CheckOutputBit(object sender, ItemCheckEventArgs e, int port, int device) {
            if (!(sender is CheckedListBox)) return;
            var clb = (CheckedListBox)sender;
            var bit = Convert.ToInt32(clb.SelectedItem);
            var value = e.NewValue == CheckState.Checked;
            _deviceFactory.SetBit(device, port, bit, value);
        }

        private void checked_port1invert(object sender, EventArgs e) {
            // TODO Invert funktion für port einfügen
            SetEventLog("Invert Funktion ist noch nicht eingebaut");
        }

        private void checked_port0invert(object sender, EventArgs e) {
            // TODO Invert funktion für port einfügen
            SetEventLog("Invert Funktion ist noch nicht eingebaut");
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

        private void SetDevices() {
            if (_deviceFactory.Devices == null) return;
            dataGridView1.DataSource = IowDataTable.GetResultsTable(_deviceFactory.Devices);

            NumberOfConDevices.Text = _deviceFactory.GetNumberOfDevices().ToString();

            foreach (var dev in _deviceFactory.Devices) {
                runDeviceSelecter.Items.Add(dev.Value.DeviceNumber);
            }
            runDeviceSelecter.SelectedIndex = 0;
        }

        private void DeviceFactory_Error(DeviceFactory deviceError) {
            SetErrorLog(deviceError.GetAndResetErrorList());
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

        private void SetErrorLog(string errorItem) {
            if (ErrorLogList.InvokeRequired) {
                var slc = new SetStringCallback(SetErrorLog);
                Invoke(slc, Convert.ToString(errorItem));
            } else {

                ErrorLogList.Items.Add(DateTime.Now + " : " + errorItem);
                int visibleItems = ErrorLogList.ClientSize.Height / ErrorLogList.ItemHeight;
                ErrorLogList.TopIndex = Math.Max(ErrorLogList.Items.Count - visibleItems + 1, 0);
            }
        }

        private void DeviceFactory_EventLog(DeviceFactory deviceEvent) {
            SetEventLog(deviceEvent.GetAndResetEventList());
        }

        private void SetEventLog(string eventItem) {
            if (EventLogList.InvokeRequired) {
                var slc = new SetStringCallback(SetEventLog);
                Invoke(slc, Convert.ToString(eventItem));
            } else {

                EventLogList.Items.Add(DateTime.Now + " : " + eventItem);
                int visibleItems = EventLogList.ClientSize.Height / EventLogList.ItemHeight;
                EventLogList.TopIndex = Math.Max(EventLogList.Items.Count - visibleItems + 1, 0);
            }
        }

        private void OnClick_ShowAbout(object sender, EventArgs e) {
            MessageBox.Show("Program M. Vervoorst (2016)" +
                             " \nIcon pack by Icons8 https://icons8.com", "IO Warrior I/O");
        }
    }
}
