using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IowLibary;
using Roboter.Control;
using static Roboter.App;

namespace Roboter.GUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static byte I2CAdress = (0x40 << 1);
        public static byte PmwFrequenz = 50;

        private delegate void SetEventLogCallback(List<LogEntry> ojc);

        private delegate void SetDeviceConnectedCallback(Dictionary<int, Device> ojc);

        private  DeviceManager _deviceManager;
        private List<LogEntry> _logEntries = new List<LogEntry>();
        private I2CMode _i2CMode = new I2CMode();
        private Device _device;
        private AxisController _axisController;

        public MainWindow() {
            InitializeComponent();

            _deviceManager = new DeviceManager(DeviceManager_Error, DeviceManger_EventLog);
    }

   


        private void MenuConnectIow_Click(object sender, RoutedEventArgs e) {
            Connect();
        }

        private void MenuCloseIow_Click(object sender, RoutedEventArgs e) {
            Disconnect();
        }

        private void MenuClose_Click(object sender, RoutedEventArgs e) {
            // TODO Schliesen des Forms
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {
        }

        private void DeviceManager_Error(DeviceManager deviceError) {
            SetLog(deviceError.Log.GetLogEntrysErrorAndReset());
        }

        private void DeviceManger_EventLog(DeviceManager deviceEvent) {
            SetLog(deviceEvent.Log.GetLogEntrysEvent());
        }

        private bool Connect() {
            bool isConnected = _deviceManager.InitFactory();
            if (isConnected) {
                MenuCloseIow.IsEnabled = true;
                MenuConnectIow.IsEnabled = false;
                SetDeviceList(_deviceManager.Devices);

                _device = _deviceManager.GetDeviceNumber(1);
                _deviceManager.RunDevice(1, Device_PortChangeStatus ,DeviceFactoryRunTimeUpdate, new I2CMode());

        
                AddAxis();
                return true;
            }
            return false;
        }

        private void AddAxis() {
            _axisController = new AxisController(_device, I2CAdress, PmwFrequenz);

            Axis1.MaximalValue = 360;
            Axis1.MinimalValue = 0;
            Axis1.HeaderName = "Achse 1";
            Axis1.Changed += Axis1OnChanged;
            Axis1.IsEnabled = true;
            _axisController.AddAxis(1);

            Axis2.MaximalValue = 360;
            Axis2.MinimalValue = 0;
            Axis2.HeaderName = "Achse 2";
            Axis2.Changed += Axis2OnChanged;
            Axis2.IsEnabled = true;
            _axisController.AddAxis(2);

            Axis3.MaximalValue = 360;
            Axis3.MinimalValue = 0;
            Axis3.HeaderName = "Achse 3";
            Axis3.Changed += Axis3OnChanged;
            Axis3.IsEnabled = true;
            _axisController.AddAxis(3);

            Axis4.MaximalValue = 360;
            Axis4.MinimalValue = 0;
            Axis4.HeaderName = "Achse 4";
            Axis4.Changed += Axis4OnChanged;
            Axis4.IsEnabled = true;
            _axisController.AddAxis(4);
        }

        private void Axis1OnChanged(int value) {
            _axisController.MoveAxis(1, value);
        }

        private void Axis2OnChanged(int value) {
            _axisController.MoveAxis(2, value);
        }

        private void Axis3OnChanged(int value) {
            _axisController.MoveAxis(3, value);
        }

        private void Axis4OnChanged(int value) {
            _axisController.MoveAxis(4, value);
        }


        private bool Disconnect() {
            _deviceManager.RemoveAllDevices();
            MenuCloseIow.IsEnabled = false;
            MenuConnectIow.IsEnabled = true;
            SetDeviceList(null);
            return true;
        }

        private void SetLog(List<LogEntry> errorItem) {
            if (ListLog.Dispatcher.CheckAccess()) {
                _logEntries.AddRange(errorItem);
                foreach (LogEntry logEntry in errorItem) {
                    ListLog.Items.Add(logEntry);
                }
            } else {
                var slc = new SetEventLogCallback(SetLog);
                Dispatcher.Invoke(slc, errorItem);
            }
        }

        private void SetDeviceList(Dictionary<int, Device> devices) {
            if (ListConnectedDevices.Dispatcher.CheckAccess()) {
                ListConnectedDevices.Items.Clear();

                if (devices == null) {
                    return;
                }

                foreach (KeyValuePair<int, Device> device in devices) {
                    ListConnectedDevices.Items.Add(device.Value);
                }
            } else {
                var slc = new SetDeviceConnectedCallback(SetDeviceList);
                Dispatcher.Invoke(slc, devices);
            }
        }

        private void DeviceFactoryRunTimeUpdate(long runtime) {
        Console.WriteLine("runtime: "  + runtime);
        }

        private void Device_PortChangeStatus(Device device, Port port, PortBit portbit) {
            Console.WriteLine("port update: ");
        }
    }
}