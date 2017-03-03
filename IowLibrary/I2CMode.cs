using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibary {
    /// <summary>
    /// I2c mode
    /// </summary>
    public class I2CMode : IModes {
        private Device _device;
        private int frequenz;
        private byte _i2cAddrs;

        /// <summary>
        /// Starten des Modus
        /// </summary>
        /// <returns></returns>
        public bool PortsInitialisation() {
            byte[] report = new byte[4];

            // I2C Mode
            report[0] = 0X01;

            // enable
            report[1] = 0X01;

            // flags
            report[2] = 0X00;

            // timeout
            report[3] = 0X00;

            return IowKit.Write(_device.Handler, DllWapper.Defines.IowPipeSpecialMode, report, 4) == 4;
        }

        /// <summary>
        /// Lesen der Ports
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Port> Read() {

            return null;
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

            return true;
        }

        private bool WriteSingelRegister(byte adress, byte register, byte value) {
            byte[] report = new byte[DllWapper.Defines.IowkitSpecialReportSize];

            // I2C Write
            report[0] = 0X02;

            // 3 Byte Start und Stop
            report[1] = 0XC3;

            report[2] = adress;
            report[3] = register;
            report[4] = value;


            IowKit.Write(_device.Handler, DllWapper.Defines.IowPipeSpecialMode, report, DllWapper.Defines.IowkitSpecialReportSize);
            IowKit.Read(_device.Handler, DllWapper.Defines.IowPipeSpecialMode, report, DllWapper.Defines.IowkitSpecialReportSize);
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

            frequenz = (int)((25000000/4096/ localafer) -1);

            WriteSingelRegister(_i2cAddrs, 0x00, 0x10);
            WriteSingelRegister(_i2cAddrs, 0xfe, 0x10);
            WriteSingelRegister(_i2cAddrs, 0xfe, 0x10);

        }
    }
}
