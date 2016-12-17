using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// Mode for standard I/O funktion of the device Ports
    /// </summary>
    public class IoMode : IModes {
        private Device _device;
        private int _writeLoopCounter;

        /// <summary>
        /// Device set for mode will normaly call from the device at mode set.
        /// </summary>
        /// <param name="device"></param>
        public void SetDevice(Device device) {
            _device = device;
        }

        /// <summary>
        /// Initalisation of the Ports device.
        /// </summary>
        /// <returns></returns>
        public bool PortsInitialisation() {
            var write = new byte[_device.IoReportsSize];

            write[0] = 0x00;
            write[1] = 0xff;
            write[2] = 0xff;
            var writebyts = IowKit.Write(_device.Handler, Defines.IowPipeIoPins, write, _device.IoReportsSize);
            if (writebyts == _device.IoReportsSize) {
                return true;
            }
            writebyts = IowKit.Write(_device.Handler, Defines.IowPipeIoPins, write, _device.IoReportsSize);
            if (writebyts == _device.IoReportsSize) {
                return true;
            }
            _device.AddDeviceError("Beim Device: " + _device.DeviceNumber + " konnten die I/O Ports nicht Initalisiert werden.");
            return false;
        }

        /// <summary>
        /// Reads the current state of the device ports an write it to the device Ports.
        /// </summary>
        /// <returns>device Ports</returns>
        public Dictionary<int, Port> Read() {
            var data = ReadDeviceImmediate();
            _device.SetDataStateToPort(data);
            return _device.Ports;
        }

        /// <summary>
        /// Port IO write
        /// </summary>
        /// <param name="ports"></param>
        /// <returns></returns>
        public bool Write(Dictionary<int, Port> ports) {
            var data = new byte[_device.IoReportsSize];
            data[0] = 0x00;
            foreach (var kvp in ports) {
                var p = kvp.Value;
                data[kvp.Key + Port.PortOffset] = p.GetBitStateAsByte();
            }

            var size = IowKit.Write(_device.Handler, 0, data, _device.IoReportsSize);

            return size != null && size == _device.IoReportsSize;
        }

        /// <summary>
        /// Set the ReadtimeOut to the Device
        /// </summary>
        /// <param name="readTimeout">timeout in ms</param>
        /// <returns>true on success</returns>
        public bool ReadTimeout(int readTimeout) {
            var result = IowKit.Timeout(_device.Handler, readTimeout);
            if (result) { return true; }
            _device.AddDeviceError("Timeout konnte nicht gesetzt werden");
            return false;
        }

        private byte[] ReadDeviceImmediate() {
            if (_writeLoopCounter >= 3) {
                _device.AddDeviceError("Der Versuch zu schreiben ist nach dem dritten versucht abgebrochen worden");
                return new byte[_device.IoReportsSize];
            }
            _writeLoopCounter++;
            var data = new byte[_device.IoReportsSize];
            var ok = IowKit.ReadImmediate(_device.Handler, data);
            if (!ok) {

                data = ReadDeviceImmediate();
            }
            _writeLoopCounter = 0;
            if (data != null) { return data; }

            _device.AddDeviceError("Device ist offenbar nicht mehr angeschlossen");
            return new byte[_device.IoReportsSize];
        }
    }
}
