using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using IowLibary.DllWapper;

namespace IowLibary {
    public delegate void DeviceFactoryEventHandler(DeviceFactory device);
    public delegate void DeviceUpdateEventHandler(long runtime);

    public class DeviceFactory {
        public const int DeviceTimeout = 200;

        public event DeviceFactoryEventHandler DeviceError;
        public event DeviceFactoryEventHandler DeviceEvent;
        public event DeviceUpdateEventHandler RunTimeUpdate;

        public Dictionary<int, Device> Devices { get; set; }

        private int? _deviceCounter;
        private readonly DeviceFactory _instance;
        private DeviceHandlerFactory _deviceHandlerFactory = new DeviceHandlerFactory();

        Log _log = Log.NewInstance();

        public DeviceFactory(DeviceFactoryEventHandler deviceError, DeviceFactoryEventHandler deviceEvent) {
            DeviceError += deviceError;
            DeviceEvent += deviceEvent;

            if (_instance == null) {
                _instance = this;
            }
        }

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
        public Device GetDeviceFromHandler(int handler) {
            Device device;

            Devices.TryGetValue(handler, out device);

            if (device == null) {
                AddDeviceFactoryError("Device mit dem Handler: " + handler + " konnte nicht enfernt werden.");
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

        /// <summary>
        ///  Gets all Error stored in the Factory
        /// </summary>
        public List<LogEntry> GetDeviceFactoryErrors() {
            return _log.GetLogEntrysError();
        }

        /// <summary>
        /// Reset the Errors stored in the Factory
        /// </summary>
        public void ResetErrorList() {
            _log.ClearLog();
        }

        /// <summary>
        /// Get all Errors form the Factory and Reset them.
        /// </summary>
        public List<LogEntry> GetAndResetErrorList() {
            var errors = GetDeviceFactoryErrors();
            ResetErrorList();
            return errors;
        }

        /// <summary>
        ///  Gets all Events stored in the Factory
        /// </summary>
        public List<LogEntry> GetDeviceFactoryEventLog() {
            return _log.GetLogEntrysEvent();
        }

        /// <summary>
        /// Reset the Events stored in the Factory
        /// </summary>
        public void ResetEventList() {
            _log.ClearLog();
        }

        /// <summary>
        /// Get all Events form the Factory and Reset them.
        /// </summary>
        public List<LogEntry> GetAndResetEventList() {
            var errors = GetDeviceFactoryEventLog();
            ResetEventList();
            return errors;
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
            for (int? i = Defines.IOWKIT_START_NUMBERING; i <= _deviceCounter; i++) {
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
            device.DeviceEventLog += Device_DeviceEventLog; ;
            Devices.Add(handler, device);
        }

        private bool CloseDeviceFromFactory(int? handler) {
            Device device;

            if (handler == null) { return false; }

            Devices.TryGetValue((int)handler, out device);

            if (device != null) {
                device.Close();
                return true;
            } else {
                AddDeviceFactoryError("Device mit dem Handler: " + handler + " konnte nicht enfernt werden.");
                return false;
            }
        }

        private void RemoveDevice(int? handler) {
            if (handler != null) {
                if (Devices.ContainsKey((int)handler)) {
                    AddDeviceFactoryEventLog("Device mit dem Handler: " + handler + " wird enfernt");
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
            _log.AddList(device.GetAndResetEventList());
            DeviceEvent?.Invoke(this);
        }

        private void Device_DeviceError(Device device) {
            device.Close();

            _log.AddList(device.GetAndResetEventList());
            AddDeviceFactoryError("Es wurde automatisch geschlossen und gestoppt!");

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
            _log.AddErrorLog(null, msg);
            if (DeviceError == null) {
                throw new SystemException("Error at Devices handling: " + msg);
            }
            DeviceError(this);
        }

        private void AddDeviceFactoryEventLog(string msg) {
            _log.AddEventLog(null, msg);
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
