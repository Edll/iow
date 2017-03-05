using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IowLibary.DllWapper.Defines;

namespace IowLibary {
    /// <summary>
    /// I2c mode
    /// </summary>
    public class I2CMode : IModes {
        private Device _device;
        private byte _frequenz;
        private byte _i2cAddrs;
        private int _writeLoopCounter;
        private IList<I2CData> dataQueue = new List<I2CData>();

        /// <summary>
        /// Starten des Modus
        /// </summary>
        /// <returns></returns>
        public bool PortsInitialisation() {
            byte[] report = new byte[IowkitSpecialReportSize];

            // I2C Mode
            report[0] = 0X01;

            // enable
            report[1] = 0X01;

            // flags
            report[2] = 0X00;

            // timeout
            report[3] = 0X00;

            return IowKit.Write(_device.Handler, IowPipeSpecialMode, report, IowkitSpecialReportSize) ==
                   IowkitSpecialReportSize;
        }

        /// <summary>
        /// Lesen der Ports
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Port> Read() {
            var data = ReadDeviceImmediate();
            _device.SetDataStateToPort(data);
            return _device.Ports;
        }

        /// <summary>
        /// Setzten der Timeouts
        /// </summary>
        /// <param name="readTimeout"></param>
        /// <returns></returns>
        public bool ReadTimeout(int readTimeout) {
            return true;
        }

        /// <summary>
        /// Setzt das Device in das 
        /// </summary>
        /// <param name="device"></param>
        public void SetDevice(Device device) {
            _device = device;
        }

        /// <summary>
        /// Schreibt auf das IOw
        /// </summary>
        /// <param name="ports"></param>
        /// <returns></returns>
        public bool Write(Dictionary<int, Port> ports) {
            IList<I2CData> removeList = new List<I2CData>();

            // Durch die Warteschleife der Daten gehen
            foreach (I2CData i2CData in dataQueue.ToList()) {
                bool result = WriteSingelRegister(i2CData.Adress, i2CData.Register, i2CData.Value);
                if (result) {
                    removeList.Add(i2CData);
                }
            }

            // Alle geschriebenen Elemente aus der Warteschleife entfernen
            foreach (I2CData i2CData in removeList) {
                try {
                    dataQueue.Remove(i2CData);
                }
                catch (Exception) {
                    _device.Log.AddErrorLog(_device,
                        "Fehler beim entfernen von Element aus der Data Queue, alles wurde zurück gesetzt");
                    dataQueue.Clear();
                    return false;
                }
            }
            removeList.Clear();
            return true;
        }

        private bool WriteSingelRegister(byte adress, byte register, byte value) {
            byte[] report = new byte[IowkitSpecialReportSize];

            // I2C Write
            report[0] = 0X02;

            // 3 Byte Start und Stop
            report[1] = 0XC3;

            report[2] = adress;
            report[3] = register;
            report[4] = value;


            IowKit.Write(_device.Handler, IowPipeSpecialMode, report, IowkitSpecialReportSize);
            IowKit.Read(_device.Handler, IowPipeSpecialMode, report, IowkitSpecialReportSize);
            //   IowKit.ReadImmediate(_device.Handler, report);
            if (report[1] == 128) {
                return false;
            }
            return true;
        }

        public void SetFrequenz(bool digi) {
            int localafer = 50;
            if (digi) {
                localafer = 200;
            }

            _frequenz = (byte) ((25000000/4096/localafer) - 1);

            AddDataToQueue(_i2cAddrs, 0x00, 0x10);
            AddDataToQueue(_i2cAddrs, 0xfe, 0x10);
            AddDataToQueue(_i2cAddrs, 0xfe, _frequenz);
        }

        private void AddDataToQueue(byte adress, byte register, byte value) {
            dataQueue.Add(I2CData.create(adress, register, value));
            _device.TriggerDataWrite();
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

  

    class I2CData {
        public byte Adress { get; set; }
        public byte Register { get; set; }
        public byte Value { get; set; }

        private I2CData(byte adress, byte register, byte value) {
            Adress = adress;
            Register = register;
            Value = value;
        }

        public static I2CData create(byte adress, byte register, byte value) {
            return new I2CData(adress, register, value);
        }
    }
}