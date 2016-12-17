using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IowLibary;
using IoWarrior.Properties;

namespace IoWarrior {
    /// <summary>
    /// Main Class for GUI
    /// TODO: eine Menge!
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public partial class Main : Form {
        private delegate void SetBoolCallback(CheckedListBox clb, int index, bool value);
        private delegate void SetStringCallback(string text);
        private delegate void SetObjectCallback(List<LogEntry> ojc);

        private readonly DeviceFactory _deviceFactory;

        /// <summary>
        /// Start Point for GUI
        /// </summary>
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
        //
        // Neue erkenntnis:
        // Das laden der Assemlby ist nicht so einfach da die iowkit.dll kein .net ist sondern native
        private void OnClick_CloseConnected(object sender, EventArgs e) {
            _deviceFactory.RemoveAllDevices();
            NumberOfConDevices.Text = Resources.Connect_0_devices;
            dataGridView1.DataSource = null;
            closeAllToolStripMenuItem1.Enabled = false;
            readInToolStripMenuItem1.Enabled = true;
            ClearDeviceSelectorList();

            // FIXME:
            // WORKAROUND für das DLL speicher problem
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            Close();
        }

        private void Click_AddSelectedDevice(object sender, EventArgs e) {
            var deviceNumber = GetDeviceNumber();

            var title = "Device " + deviceNumber;
            var tabPage = new TabPage(title);
            Control panel = null;
            if (rbIOMode.Checked)
            {
                 panel = new IoModePanel(_deviceFactory, _deviceFactory.GetDeviceNumber(deviceNumber));
            }else if (rbLCDMode.Checked)
            {
                 panel = new LcdModePanel(_deviceFactory, _deviceFactory.GetDeviceNumber(deviceNumber));
            }

            tabPage.Controls.Add(panel);
            tabControlDevices.TabPages.Add(tabPage);
        }


        private void Click_RemoveSelectedDevice(object sender, EventArgs e) {
            var deviceNumber = GetDeviceNumber();

            tabControlDevices.TabPages.RemoveAt(0);
            _deviceFactory.StopDevice(deviceNumber);
        }

        private void ClearDeviceSelectorList() {
            runDeviceSelecter.Items.Clear();
        }

        private void CloseProgramm(object sender, FormClosedEventArgs e) {
            _deviceFactory.RemoveAllDevices();
        }


        private void SetDevices() {
            if (_deviceFactory.Devices == null) return;
            dataGridView1.DataSource = IowDataModelTable.GetResultsTable(_deviceFactory.Devices);

            NumberOfConDevices.Text = _deviceFactory.GetNumberOfDevices().ToString();

            foreach (var dev in _deviceFactory.Devices) {
                runDeviceSelecter.Items.Add(dev.Value.DeviceNumber);
            }
            runDeviceSelecter.SelectedIndex = 0;
        }

        private void DeviceFactory_Error(DeviceFactory deviceError) {
            SetErrorLog(deviceError.Log.GetLogEntrysErrorAndReset());
        }

        private void SetErrorLog(List<LogEntry> errorItem) {
            if (ErrorLogList.InvokeRequired) {
                var slc = new SetObjectCallback(SetErrorLog);
                Invoke(slc, errorItem);
            } else {

                foreach (var logEntry in errorItem) {
                    ErrorLogList.Items.Add(logEntry.ToString());
                }

                int visibleItems = ErrorLogList.ClientSize.Height / ErrorLogList.ItemHeight;
                ErrorLogList.TopIndex = Math.Max(ErrorLogList.Items.Count - visibleItems + 1, 0);
            }
        }

        private void DeviceFactory_EventLog(DeviceFactory deviceEvent) {
            SetEventLog(deviceEvent.Log.GetLogEntrysEvent());
        }

        private void SetEventLog(List<LogEntry> eventItem) {
            if (EventLogList.InvokeRequired) {
                var slc = new SetObjectCallback(SetEventLog);
                Invoke(slc, eventItem);
            } else {
                foreach (var logEntry in eventItem) {
                    EventLogList.Items.Add(logEntry.ToString());
                }
                int visibleItems = EventLogList.ClientSize.Height / EventLogList.ItemHeight;
                EventLogList.TopIndex = Math.Max(EventLogList.Items.Count - visibleItems + 1, 0);
            }
        }

        private void OnClick_ShowAbout(object sender, EventArgs e) {
            // ReSharper disable once LocalizableElement
            MessageBox.Show("Program M. Vervoorst (2016)" +
                             " \nIcon pack by Icons8 https://icons8.com", "IO Warrior I/O");
        }


        private int GetDeviceNumber() {
            try {
                return Convert.ToInt32(runDeviceSelecter.SelectedItem.ToString());
            } catch (FormatException) {
                MessageBox.Show("Keine gültig auswahl getroffen!");
            } catch (NullReferenceException) {
                MessageBox.Show("Keine gültig auswahl getroffen!");
            }

            return 0;
        }
    }
}
