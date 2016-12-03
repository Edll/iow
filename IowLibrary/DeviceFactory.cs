using System;
using System.Collections.Generic;
using System.Linq;
using IowLibrary.DllWapper;

namespace IowLibrary {
    public delegate void DeviceFactoryEventHandler(DeviceFactory device);
    public delegate void DeviceUpdateEventHandler(long runtime);

    public class DeviceFactory {
        public const int DeviceTimeout = 200;

        public event DeviceFactoryEventHandler DeviceError;
        public event DeviceUpdateEventHandler RunTimeUpate;

        private Dictionary<int, Device> _devices;
        private int? _deviceCounter;
        private readonly DeviceFactory _instance;
        private DeviceHandlerFactory _deviceHandlerFactory = new DeviceHandlerFactory();
        private readonly List<string> _errorsList = new List<string>();

        public DeviceFactory(DeviceFactoryEventHandler deviceError) {
            DeviceError += deviceError;
            InitFactory();

            if (_instance == null) {
                _instance = this;
            }
        }

        ~DeviceFactory() {
            RemoveAllDevices();
        }

        public Dictionary<int, Device> Devices {
            get {
                if (_devices != null) return _devices;
                InitFactory();
                return _devices;
            }
            set { _devices = value; }
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
        /// Stops the I/O Read for the Device with the given number
        /// </summary>
        /// <param name="deviceNumber">Number of the device to Stop</param>
        public void StopDevice(int deviceNumber) {
            var device = GetDeviceNumber(deviceNumber);
            _deviceHandlerFactory?.StopDeviceThread(device);
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
                    RemoveDeviceFromFactory(deviceEntry.Key);
                }
            } catch (InvalidOperationException) {
                // kann ignoriert werden da alle Devices schon weg sind!
            }

            _devices.Clear();
        }

        /// <summary>
        /// Picks the Devices with the DeviceNumber.
        /// </summary>
        /// <param name="deviceNumber">Number of the Device we want to Pick</param>
        /// <returns>Null if device is not found</returns>
        /// <exception cref="ArgumentException">if number is not Valid</exception>
        public Device GetDeviceNumber(int deviceNumber) {
            LibaryUtils.CheckDeviceNumber(deviceNumber);

            if (_devices != null) {
                foreach (var deviceEntry in _devices) {
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
        /// Get a Device by the Handler
        /// </summary>
        /// <param name="handler">handler of the Device we want</param>
        public Device GetDeviceFromHandler(int handler) {
            Device device;

            _devices.TryGetValue(handler, out device);

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
            return _devices?.Count ?? 0;
        }

        /// <summary>
        ///  Gets all Error stored in the Factory
        /// </summary>
        public string GetDeviceFactoryErrors() {
            return _errorsList.Aggregate("", (current, error) => current + (error + "\n"));
        }

        /// <summary>
        /// Reset the Errors stored in the Factory
        /// </summary>
        public void ResetErrorList() {
            _errorsList?.Clear();
        }

        /// <summary>
        /// Get all Errors form the Factory and Reset them.
        /// </summary>
        public string GetAndResetErrorList() {
            var errors = GetDeviceFactoryErrors();
            ResetErrorList();
            return errors;
        }

        private void InitFactory() {
            var isOpen = OpenConnectedDevices();
            if (!isOpen) {
                return;
            }

            var isCountDevices = CountConnectedDevices();
            if (!isCountDevices) {
                return;
            }
            AddAllConnectedDeviceToFactory();
        }

        private bool OpenConnectedDevices() {
            var firstDeviceHandler = IowKit.OpenDevices();

            if (firstDeviceHandler != null) {
                return true;
            }

            AddDeviceFactoryError("Fehler beim öffnen der Devices. Sind welche Verbunden?");
            return false;

        }

        private bool CountConnectedDevices() {
            _deviceCounter = IowKit.GetConnectDeviceCounter();

            if (_deviceCounter != null) {
                return true;
            }

            AddDeviceFactoryError("Fehler beim öffnen der Devices. Sind welche Verbunden?");
            return false;
        }

        private void AddAllConnectedDeviceToFactory() {
            for (int? i = Defines.IOWKIT_START_NUMBERING; i <= _deviceCounter; i++) {
                var handler = IowKit.GetHandlerForDevice(i);

                if (handler == null) {
                    AddDeviceFactoryError("Das Device mit der Nummer: " + i + " konnte nicht geöffnet " +
                        "werden.");
                    continue;
                }

                AddDeviceToFactory((int)handler, (int)i);
            }
        }

        private void AddDeviceToFactory(int handler, int deviceNumber) {
            if (_devices == null) {
                _devices = new Dictionary<int, Device>();
            }

            var device = new Device(handler) { DeviceNumber = deviceNumber };
            device.DeviceClose += Device_DeviceClose;
            _devices.Add(handler, device);
        }

        private void RemoveDeviceFromFactory(int? handler) {
            Device device;

            if (handler == null) { return; }

            _devices.TryGetValue((int)handler, out device);

            if (device != null) {
                device.Close();
                RemoveDevice(handler);
            } else {
                AddDeviceFactoryError("Device mit dem Handler: " + handler + " konnte nicht enfernt werden.");
            }
        }

        private void RemoveDevice(int? handler) {
            Console.WriteLine("Device will be removed: " + handler);
            if (handler != null) _devices.Remove((int)handler);
        }

        private void Device_DeviceClose(Device device) {
            if (device?.Handler != null) {
                RemoveDeviceAsCloseEvent(device);
            }
        }

        private void RemoveDeviceAsCloseEvent(Device device) {
            if (device.Handler == null) return;

            Device deviceFromFactroy;

            _devices.TryGetValue((int)device.Handler, out deviceFromFactroy);

            if (deviceFromFactroy != null) {
                RemoveDevice(device.Handler);
            }
        }

        private void AddDeviceFactoryError(string msg) {
            _errorsList.Add(msg);
            if (DeviceError == null) {
                throw new SystemException("Error at Devices handling: " + msg);
            }
            DeviceError(this);
        }

        private void DeviceHandler_RunTimeUpdate(long runtime) {
            RunTimeUpate?.Invoke(runtime);
        }
    }
}
