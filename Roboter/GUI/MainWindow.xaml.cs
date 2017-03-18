using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IowLibary;
using static Roboter.App;

namespace Roboter.GUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private delegate void SetEventLogCallback(List<LogEntry> ojc);

        private List<LogEntry> _logEntries;

        public MainWindow() {
            InitializeComponent();

            App.DeviceManager = new DeviceManager(DeviceManager_Error, DeviceManger_EventLog);

            Axis1.MaximalValue = 360;
            Axis1.MinimalValue = 0;
            Axis1.HeaderName = "Achse 1";
            Axis1.Changed += Axis1OnChanged;
        }

        private void Axis1OnChanged(int value) {
            Console.WriteLine("Value: " + value);
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
            bool isConnected = App.DeviceManager.InitFactory();
            if (isConnected) {
                MenuCloseIow.IsEnabled = true;
                MenuConnectIow.IsEnabled = false;
                return true;
            }
            return false;
        }

        private bool Disconnect() {
            App.DeviceManager.RemoveAllDevices();

            MenuCloseIow.IsEnabled = false;
            MenuConnectIow.IsEnabled = true;
            return true;
        }

        private void SetLog(List<LogEntry> errorItem) {
            if (ListLog.Dispatcher.CheckAccess()) {
                var slc = new SetEventLogCallback(SetLog);
                Dispatcher.Invoke(slc, errorItem);
            }
            else {
                _logEntries.AddRange(errorItem);
                ListLog.ItemsSource = _logEntries;
            }
        }
    }
}