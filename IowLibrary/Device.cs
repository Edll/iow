using System;
using System.Collections.Generic;
using IowLibrary.DllWapper;

namespace IowLibrary {
    public delegate void DeviceStatusEventHandler(Device device);
    public delegate void DevicPortEventHandler(Device device, Port port, PortBit portBit);
    /// <summary>
    /// Representation Class for an IOWarrior Device
    /// </summary>
    public class Device {
        public event DeviceStatusEventHandler DeviceClose;
        public event DeviceStatusEventHandler DeviceError;

        public event DevicPortEventHandler PortBitInChange;
        public event DevicPortEventHandler PortBitOutChange;

        private int _writeLoopCounter;

        public Device(int? handler) {
            Handler = handler;
            DeviceInitialisation();
        }

        ~Device() {
            Close();
        }

        public int? Handler { get; set; }

        public int DeviceNumber { get; set; }

        public int? ProductId { get; set; }

        public string Serial { get; set; }

        public string SoftwareVersion { get; set; }

        public Dictionary<int, Port> Ports { get; set; }

        public int ReportSize { get; set; }

        public int IoReportsSize { get; set; }

        public string LastError { get; set; }

        /// <summary>
        /// Set the Timeout for this Device
        /// </summary>
        /// <param name="timeout"></param>
        public void SetReadTimeout(int timeout) {
            var result = IowKit.Timeout(Handler, timeout);
            if (result) { return; }
            DeviceAddError("Timeout konnte nicht gesetzt werden");
        }

        /// <summary>
        /// initialisat ports for I/O Reading of this Device
        /// </summary>
        /// <param name="pipeNum">pipe to use Write</param>
        public void PortsInitialisation(int pipeNum) {
            var write = new byte[IoReportsSize];

            write[0] = 0x00;
            write[1] = 0xff;
            write[2] = 0xff;
            var writebyts = IowKit.Write(Handler, pipeNum, write, IoReportsSize);
            if (writebyts == IoReportsSize) { return; }
            writebyts = IowKit.Write(Handler, pipeNum, write, IoReportsSize);
            if (writebyts == IoReportsSize) { return; }
            DeviceAddError("Beim Device: " + DeviceNumber + " konnten die I/O Ports nicht Initalisiert werden.");
        }

        /// <summary>
        /// Set of a Bit on a Port of this Devices
        /// </summary>
        /// <param name="port">Ports to set Starts with 0</param>
        /// <param name="bit">Bit to set starts with 0</param>
        /// <param name="value">target state</param>
        public void SetBit(int port, int bit, bool value) {
            if (Ports.Count - 1 < port) { return; }
            var p = Ports[port];
            p.SetBit(bit, value);
        }

        /// <summary>
        /// Read in the current State of all Ports of this Device
        /// </summary>
        /// <param name="pipeNum">Pipe for Read In</param>
        public void ReadInPortState(int pipeNum) {
            var data = ReadDeviceImmediate();
            SetDataStateToPort(data);
        }

        /// <summary>
        /// Close this Device. Triggers the Devices close Event
        /// </summary>
        public void Close() {
            IowKit.CloseDevice(Handler);
            DeviceCloseEvent();
        }

        /// <summary>
        /// Write the Current out state of the Ports to the Device
        /// </summary>
        /// <returns>true if all Bits write to the device</returns>
        public bool WritePortStateToDevice() {
            var data = new byte[IoReportsSize];
            data[0] = 0x00;
            foreach (var kvp in Ports) {
                var p = kvp.Value;
                data[kvp.Key + Port.PortOffset] = p.GetBitStateAsByte();
            }

            var size = IowKit.Write(Handler, 0, data, IoReportsSize);

            return size != null && size == IoReportsSize;
        }

        private byte[] ReadDeviceImmediate() {
            if (_writeLoopCounter >= 3) {
                DeviceAddError("Schreib schleife vorgang abgebrochen");
                return new byte[IoReportsSize];
            }
            _writeLoopCounter++;
            var data = new byte[IoReportsSize];
            var ok = IowKit.ReadImmediate(Handler, data);
            if (!ok) {

                data = ReadDeviceImmediate();
            }
            _writeLoopCounter = 0;
            if (data != null) { return data; }

            DeviceAddError("Device ist offenbar nicht mehr angeschlossen");
            return new byte[IoReportsSize];
        }

        private void DeviceInitialisation() {
            ReadDeviceProductId();
            ReadDeviceSerial();
            ReadSoftwareVersion();
            PortsInitialisation();
        }

        private void ReadDeviceProductId() {
            if (ProductId == null) {
                ProductId = IowKit.GetProductId(Handler);
                if (ProductId == null) {
                    DeviceErrorEvent();
                }
            }
            SetDeviceReportSize();
        }

        private void SetDeviceReportSize() {
            switch (ProductId) {
                case Defines.IOWKIT_PID_IOW24:
                ReportSize = Defines.IOWKIT_REPORT_SIZE;
                IoReportsSize = Defines.IOWKIT24_IO_REPORT_SIZE;
                break;
                default:
                ReportSize = Defines.IOWKIT_SPECIAL_REPORT_SIZE;
                IoReportsSize = Defines.IOWKIT_SPECIAL_REPORT_SIZE;
                break;
            }
        }

        private void ReadDeviceSerial() {
            Serial = IowKit.GetProductSerial(Handler);
        }

        private void ReadSoftwareVersion() {
            SoftwareVersion = IowKit.GetProductSoftwareVersion(Handler);
        }

        private void PortsInitialisation() {
            if (Ports == null) {
                Ports = new Dictionary<int, Port>();
            }
            for (var i = 0; i < 2; i++) {
                var port = new Port(i);
                port.PortBitInChange += PortBitInChangeEvent;
                port.PortBitOutChange += PortBitOutChangeEvent;
                Ports.Add(i, port);
            }
        }

        private void SetDataStateToPort(IEnumerable<byte> data) {
            // Da wir mit readImm arbeiten ist das result byte 0 das erste
            var i = 0;
            foreach (var dataIn in data) {
                if ((i + 1) <= Ports.Count) {
                    var port = Ports[i];
                    port.SetInputData(dataIn);
                } else {
                    break;
                }
                i++;
            }
        }

        private void PortBitOutChangeEvent(Port port, PortBit portBit) {
            PortBitOutChange?.Invoke(this ,port, portBit);
        }

        private void PortBitInChangeEvent(Port port, PortBit portBit) {
            PortBitInChange?.Invoke(this, port, portBit);
        }

        private void DeviceCloseEvent() {
            DeviceClose?.Invoke(this);
            Console.WriteLine("Device: " + Handler + " close");
        }

        private void DeviceErrorEvent() {
            if (DeviceError == null) { return; }
            Close();
            DeviceError(this);
        }

        private void DeviceAddError(string error) {
            LastError = error;
            DeviceErrorEvent();
        }
    }
}
