using System;
using System.Collections.Generic;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// delegate events from factory
    /// </summary>
    /// <param name="device">this</param>
    public delegate void DeviceFactoryEventHandler(DeviceFactory device);

    /// <summary>
    /// delegate update events on runtime
    /// </summary>
    /// <param name="runtime">runtime in ms</param>
    public delegate void DeviceUpdateEventHandler(long runtime);

    /// <summary>
    /// Construct all Connected Device. Remove on close automatically. 
    /// On Remove it close the device. On deconstruction of the factory 
    /// it close an destroy all device.
    /// <code>
    ///  // open of the DeviceFactory
    /// _deviceFactory = new DeviceFactory(DeviceFactory_Error, DeviceFactory_EventLog);
    /// // init of all connected devices
    /// var isConnected = _deviceFactory.InitFactory();
    /// 
    /// // start I/O thread for device
    ///  _deviceFactory.RunDevice(selectedDevice, Device_PortChangeStatus, DeviceFactoryRunTimeUpdate);
    /// 
    /// // stop all threads and close all devices
    /// _deviceFactory.RemoveAllDevices();
    /// </code>
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class DeviceFactory {

        /// <summary>
        /// delegates Device Errors to observers
        /// </summary>
        public event DeviceFactoryEventHandler DeviceError;

        /// <summary>
        /// delegates Device Events to observers
        /// </summary>
        public event DeviceFactoryEventHandler DeviceEvent;

        /// <summary>
        /// delegates runtime update to observer
        /// </summary>
        public event DeviceUpdateEventHandler RunTimeUpdate;


        /// <summary>
        /// Devices registered in factory
        /// </summary>
        public Dictionary<int, Device> Devices { get; set; }

        private int? _deviceCounter;
        private readonly DeviceFactory _instance;
        private DeviceHandlerFactory _deviceHandlerFactory = new DeviceHandlerFactory();

        /// <summary>
        /// Logger for Event, Errors...
        /// </summary>
        public Log Log { get; set; } = Log.NewInstance();


        /// <summary>
        /// entry point for factory
        /// </summary>
        /// <param name="deviceError">reports all device errors to given delegate event method</param>
        /// <param name="deviceEvent">reports all device errors to given delegate event method</param>
        public DeviceFactory(DeviceFactoryEventHandler deviceError, DeviceFactoryEventHandler deviceEvent) {
            DeviceError += deviceError;
            DeviceEvent += deviceEvent;

            if (_instance == null) {
                _instance = this;
            }
        }

        /// <inheritdoc />
        ~DeviceFactory() {
            RemoveAllDevices();
        }

        /// <summary>
        /// Initalitation of the Factory, Open and Load all devices
        /// </summary>
        /// <author>M. Vervoorst junk@edlly.de</author>
        /// <returns>Is Returning true on no errors</returns>
        public bool InitFactory() {
            if (Devices != null) {
                RemoveAllDevices();
            }

            var isOpen = OpenConnectedDevices();
            if (!isOpen) {
                return false;
            }

            var isCountDevices = CountConnectedDevices();
            if (!isCountDevices) {
                return false;
            }
            return AddAllConnectedDeviceToFactory();
        }

        /// <summary>
        /// Runs the I/O Read/Write for the Device with the given devices Number
        /// </summary>
        /// <param name="deviceNumber">Device wich is to Run</param>
        /// <param name="devicePortBitChange">PortBit Change Event Listener</param>
        /// <param name="deviceFactoryRunTimeUpdate">Loop Timer Update Event</param>
        public void RunDevice(object deviceNumber, DevicPortEventHandler devicePortBitChange,
            DeviceUpdateEventHandler deviceFactoryRunTimeUpdate) {

            var device = GetDeviceNumber(deviceNumber);
            if (device == null) return;
            device.PortBitInChange += devicePortBitChange;
            RunTimeUpdate += deviceFactoryRunTimeUpdate;
            RunDevice(device.DeviceNumber);
        }

        /// <summary>
        /// Runs the I/O Read/Write for the Device with the given devices Number
        /// </summary>
        /// <param name="deviceNumber">Number of the Device to Run</param>
        public void RunDevice(int deviceNumber) {
            var device = GetDeviceNumber(deviceNumber);
            if (_deviceHandlerFactory == null) {
                _deviceHandlerFactory = new DeviceHandlerFactory();
            }
            var deviceHandler = _deviceHandlerFactory.AddNewDeviceThread(device);
            if (deviceHandler == null) {
                return;
            }
            deviceHandler.RunTimeUpdate += DeviceHandler_RunTimeUpdate;
        }

        /// <summary>
        /// Runs the I/O Read/Write for the Device with the given devices Number
        /// </summary>
        /// <param name="deviceNumber">Number of the Device to Run</param>
        public void RunDevice(object deviceNumber) {
            try {
                var selectedDevice = Convert.ToInt32(deviceNumber);
                RunDevice(selectedDevice);
            } catch (Exception) {
                AddDeviceFactoryEventLog("Es wurde keine gültige Device Auswahl getroffen.");
            }
        }

        /// <summary>
        /// Stops the I/O Read for the Device with the given number
        /// </summary>
        /// <param name="deviceNumber">Number of the device to Stop</param>
        public void StopDevice(int deviceNumber) {
            var device = GetDeviceNumber(deviceNumber);
            _deviceHandlerFactory?.StopDeviceThread(device);
        }

        /// <summary>
        /// Stops the I/O Read for the Device with the given number
        /// Ma
        /// </summary>
        /// <param name="deviceNumber">Number of the device to Stop</param>
        public void StopDevice(object deviceNumber) {
            try {
                var selectedDevice = Convert.ToInt32(deviceNumber);
                StopDevice(selectedDevice);
            } catch (Exception) {
                AddDeviceFactoryEventLog("Es wurde keine gültige Device Auswahl getroffen.");
            }
        }

        /// <summary>
        /// Set a Bit of a Device
        /// </summary>
        /// <param name="deviceNumber">Number of the Target Device</param>
        /// <param name="port">Target port Number Starts with 0</param>
        /// <param name="bit">Target Bit of the port Starts with 0</param>
        /// <param name="value">Target portstate</param>
        public void SetBit(int deviceNumber, int port, int bit, bool value) {
            var device = GetDeviceNumber(deviceNumber);
            device.SetBit(port, bit, value);
        }

        /// <summary>
        /// Refresh the Factory
        /// </summary>
        public void Refresh() {
            RemoveAllDevices();
            InitFactory();
        }

        /// <summary>
        /// Remove All Devices From the Factory, if needed it Close the Devices.
        /// </summary>
        public void RemoveAllDevices() {
            if (_deviceHandlerFactory != null) {
                _deviceHandlerFactory.StopAllDeviceThreads();
                _deviceHandlerFactory = null;
            }
            if (Devices == null) return;
            try {
                foreach (var deviceEntry in Devices) {
                    bool isClosed = CloseDeviceFromFactory(deviceEntry.Key);
                    if (isClosed) {
                        RemoveDevice(deviceEntry.Key);
                    }
                }
            } catch (InvalidOperationException) {
                // kann ignoriert werden da alle Devices schon weg sind!
            }

            //   Devices.Clear();
            Devices = null;
        }

        /// <summary>
        /// Picks the Devices with the DeviceNumber.
        /// </summary>
        /// <param name="deviceNumber">Number of the Device we want to Pick</param>
        /// <returns>Null if device is not found</returns>
        /// <exception cref="ArgumentException">if number is not Valid</exception>
        public Device GetDeviceNumber(int deviceNumber) {
            LibaryUtils.CheckDeviceNumber(deviceNumber);

            if (Devices != null) {
                foreach (var deviceEntry in Devices) {
                    var device = deviceEntry.Value;
                    if (device.DeviceNumber == deviceNumber) {
                        return device;
                    }
                }
            }
            AddDeviceFactoryError("Es wurde kein Device mit der Nummer: " + deviceNumber + " gefunden");
            return null;
        }

        /// <summary>
        /// Picks the Devices with the DeviceNumber.
        /// </summary>
        /// <param name="deviceNumber">Number of the Device we want to Pick</param>
        /// <returns>Null if device is not found</returns>
        /// <exception cref="ArgumentException">if number is not Valid</exception>
        public Device GetDeviceNumber(object deviceNumber) {
            try {
                var selectedDevice = Convert.ToInt32(deviceNumber);
                return GetDeviceNumber(selectedDevice);
            } catch (Exception) {
                AddDeviceFactoryEventLog("Es wurde keine gültige Device Auswahl getroffen.");

            }
            return null;
        }
        /// <summary>
        /// Get a Device by the Handler
        /// </summary>
        /// <param name="handler">handler of the Device we want</param>
        /// <returns>Device when found als null</returns>
        public Device GetDeviceFromHandler(int handler) {
            Device device;

            Devices.TryGetValue(handler, out device);

            if (device == null) {
                AddDeviceFactoryError("Device mit dem Handler: " + handler + " konnte nicht gefunden werden.");
            }
            return device;
        }

        /// <summary>
        /// Number of the Devices handel in Factory
        /// </summary>
        /// <returns>0 to Number of Devices</returns>
        public int GetNumberOfDevices() {
            return Devices?.Count ?? 0;
        }

        private bool OpenConnectedDevices() {
            var firstDeviceHandler = IowKit.OpenDevices();

            if (firstDeviceHandler != null) {
                return true;
            }

            AddDeviceFactoryEventLog("Fehler beim öffnen der Devices. Sind welche Verbunden?");
            return false;

        }

        private bool CountConnectedDevices() {
            _deviceCounter = IowKit.GetConnectDeviceCounter();

            if (_deviceCounter != null) {
                return true;
            }

            AddDeviceFactoryEventLog("Fehler beim öffnen der Devices. Sind welche Verbunden?");
            return false;
        }

        private bool AddAllConnectedDeviceToFactory() {
            for (int? i = Defines.IowkitStartNumbering; i <= _deviceCounter; i++) {
                var handler = IowKit.GetHandlerForDevice(i);

                if (handler == null) {
                    AddDeviceFactoryEventLog("Das Device mit der Nummer: " + i + " konnte nicht geöffnet " +
                        "werden. Es wird nicht geladen.");
                    continue;
                }

                AddDeviceToFactory((int)handler, (int)i);
            }
            AddDeviceFactoryEventLog("Alle Devices sind erfolgreich Connected worden.");
            return true;
        }

        private void AddDeviceToFactory(int handler, int deviceNumber) {
            if (Devices == null) {
                Devices = new Dictionary<int, Device>();
            }

            var device = new Device(handler) { DeviceNumber = deviceNumber };
            device.DeviceClose += Device_DeviceClose;
            device.DeviceError += Device_DeviceError;
            device.DeviceEventLog += Device_DeviceEventLog;
            // TODO das hier muss eine methode werden damit device zur laufzeit den mode wechseln können....!
            device.Modes = new IoMode();
            Devices.Add(handler, device);
        }

        private bool CloseDeviceFromFactory(int? handler) {
            Device device;

            if (handler == null) { return false; }

            Devices.TryGetValue((int)handler, out device);

            if (device != null) {
                device.Close();
                return true;
            }
            AddDeviceFactoryError("Device mit dem Handler: " + handler + " konnte nicht enfernt werden.");
            return false;
        }

        private void RemoveDevice(int? handler) {

            if (handler != null) {
                if (Devices.ContainsKey((int)handler)) {
                    AddDeviceFactoryEventLog("Device mit dem Handler: " + handler + " wird enfernt");
                    Device device;
                    Devices.TryGetValue((int)handler, out device);
                    StopDevice(device);
                    Devices.Remove((int)handler);
                }
            }
        }

        private void Device_DeviceClose(Device device) {
            if (device?.Handler != null) {
                RemoveDeviceAsCloseEvent(device);
            }
        }

        private void Device_DeviceEventLog(Device device) {
            Log.AddList(device.Log.GetLogEntrysEventAndReset());
            DeviceEvent?.Invoke(this);
        }

        private void Device_DeviceError(Device device) {
            StopDevice(device.DeviceNumber);
            RemoveDevice(device.Handler);
            device.Close();
            Log.AddList(device.Log.GetLogEntrysErrorAndReset());
            AddDeviceFactoryError("Es wurde automatisch geschlossen und gestoppt! " + device.Handler);
        }

        private void RemoveDeviceAsCloseEvent(Device device) {
            if (Devices == null) return;
            if (device.Handler == null) return;

            Device deviceFromFactroy;

            Devices.TryGetValue((int)device.Handler, out deviceFromFactroy);

            if (deviceFromFactroy != null) {
                RemoveDevice(device.Handler);
            }
        }

        private void AddDeviceFactoryError(string msg) {
            Log.AddErrorLog(null, msg);
            if (DeviceError == null) {
                throw new SystemException("Error at Devices handling: " + msg);
            }
            DeviceError(this);
        }

        private void AddDeviceFactoryEventLog(string msg) {
            Log.AddEventLog(null, msg);
            if (DeviceEvent == null) {
                throw new SystemException("Error at Devices handling: " + msg);
            }
            DeviceEvent(this);
        }

        private void DeviceHandler_RunTimeUpdate(long runtime) {
            RunTimeUpdate?.Invoke(runtime);
        }
    }
}
