using System;
using System.Collections.Generic;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// Event delegater for Devices
    /// </summary>
    /// <param name="device">this</param>
    public delegate void DeviceStatusEventHandler(Device device);

    /// <summary>
    /// Event delegater for the Device Ports
    /// </summary>
    /// <param name="device">this</param>
    /// <param name="port">Port which has the event</param>
    /// <param name="portBit">Bit which has the event</param>
    public delegate void DevicPortEventHandler(Device device, Port port, PortBit portBit);

    /// <summary>
    /// Representation Class for an IOWarrior Device
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class Device {
        /// <summary>
        /// When the device is Close it self or from external it will be report
        /// </summary>
        public event DeviceStatusEventHandler DeviceClose;

        /// <summary>
        /// When the device has an error it will be logged and reported
        /// </summary>
        public event DeviceStatusEventHandler DeviceError;

        /// <summary>
        /// When the device has an event logged it will be reported
        /// </summary>
        public event DeviceStatusEventHandler DeviceEventLog;

        /// <summary>
        /// When the status of an in bit has changed device will report
        /// </summary>
        /// 
        public event DevicPortEventHandler PortBitInChange;
        /// <summary>
        /// when the status of an out bit has changed device will report
        /// </summary>
        public event DevicPortEventHandler PortBitOutChange;

        /// <summary>
        /// Logging for device
        /// </summary>
        public Log Log { get; set; } = new Log();

        /// <summary>
        /// Paramtered Ctor for an device. It will Init the device with the given handler.
        /// </summary>
        /// <param name="handler">handler of the device to startup</param>
        public Device(int? handler) {
            Handler = handler;
            DeviceInitialisation();
        }

        /// <inheritdoc />
        ~Device() {
            Close();
        }

        /// <summary>
        /// individual device handler from the iow driver
        /// </summary>
        public int? Handler { get; set; }

        /// <summary>
        /// individual deviceNumber from the iow driver
        /// </summary>
        public int DeviceNumber { get; set; }

        /// <summary>
        /// will be readout at initialization of the device
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// will be readout at initialization of the device
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// will be readout at initialization of the device
        /// </summary>
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// Contains the Ports which will be generated on device initialization
        /// </summary>
        public Dictionary<int, Port> Ports { get; set; }

        /// <summary>
        /// will be set automatical at initialization of the device
        /// </summary>
        public int ReportSize { get; set; }

        /// <summary>
        /// will be set automatical at initialization of the device
        /// </summary>
        public int IoReportsSize { get; set; }

        private IModes _modes;

        /// <summary>
        /// Mode for the device.
        /// </summary>
        public IModes Modes {
            get { return _modes; }
            set
            {
                _modes = value;
                _modes.SetDevice(this);
            }
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
        /// Set all bit of a ports to a value
        /// </summary>
        /// <param name="port">port number</param>
        /// <param name="value">ture or false</param>
        public void SetAllPortBits(int port, bool value)
        {
            for (var bit = 0; bit < Defines.MaxBitNumber+1; bit++)
            {
                SetBit(port, bit, value);
            }
        }

        /// <summary>
        /// Close this Device. Triggers the Devices close Event
        /// </summary>
        public void Close() {
            IowKit.CloseDevice(Handler);
            DeviceCloseEvent();
        }

        /// <summary>
        /// Write the Current out state of the ports to the Device
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

        /// <summary>
        /// Set a ArrayList of byte Data Reports to the Device
        /// </summary>
        /// <param name="data">Byte of data für ports</param>
        public void SetDataStateToPort(IEnumerable<byte> data) {
            // Da wir mit readImm arbeiten ist das result byte 0 das erste
            var i = 0;
            foreach (var dataIn in data) {
                if ((i + 1) <= Ports.Count) {
                    var port = Ports[i];
                    port.SetBitState(dataIn);
                } else {
                    break;
                }
                i++;
            }
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
                    AddDeviceError("Fehler beim Lesen der Product die des Devices");
                }
            }
            SetDeviceReportSize();
        }

        private void SetDeviceReportSize() {
            switch (ProductId) {
                case Defines.IowkitPidIow24:
                ReportSize = Defines.IowkitReportSize;
                IoReportsSize = Defines.Iowkit24IoReportSize;
                break;
                default:
                ReportSize = Defines.IowkitSpecialReportSize;
                IoReportsSize = Defines.IowkitSpecialReportSize;
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

        private void PortBitOutChangeEvent(Port port, PortBit portBit) {
            PortBitOutChange?.Invoke(this, port, portBit);
            AddDeviceEventLog("Out Port: " + port.PortNumber + " hat sich verändert zu: " + portBit.BitOut);
        }

        private void PortBitInChangeEvent(Port port, PortBit portBit) {
            PortBitInChange?.Invoke(this, port, portBit);
            AddDeviceEventLog("In Port: " + port.PortNumber + " hat sich verändert zu: " + portBit.BitIn);
        }

        private void DeviceCloseEvent() {
            DeviceClose?.Invoke(this);
            AddDeviceEventLog("wurde erfolgreich geschlossen.");
        }

        private void AddDeviceEventLog(string log) {
            Log.AddEventLog(this, log);
            DeviceEventLog?.Invoke(this);
        }

        /// <summary>
        /// Add an error to the device error log
        ///  </summary>
        /// <param name="msg">error log entry</param>
        public void AddDeviceError(string msg) {
            Log.AddErrorLog(this, msg);
            if (DeviceError == null) {
                throw new SystemException("Error at Devices handling: " + msg);
            }
            DeviceError(this);
        }
    }
}
