using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibary.robot {

    /// <summary>
    /// Steuerung von PMW Modulen über I2C
    /// </summary>
    public class PMW {
        private Device _device;
        private I2CMode _i2cMode;

        private byte _frequenz;
        private byte _i2cAddrs;

        /// <summary>
        /// Neue Instanz des PMW Moduls
        /// </summary>
        /// <param name="device">Device welches genutzt werden soll</param>
        /// <param name="i2cAdress">I2C Adresse auf dem Bus</param>
        public PMW(Device device, byte i2cAdress) {
            this._device = device;
            this._i2cAddrs = i2cAdress;
            if (_device.Modes is I2CMode) {
                _i2cMode = _device.Modes as I2CMode;
            } else {
                _device.AddDeviceError("Device ist nicht im I2C Mode");
            }
        }

        /// <summary>
        /// Set the Frequenz of the PMW signal
        /// </summary>
        /// <param name="frequenz"></param>
        public void SetFrequenz(int frequenz) {
            _frequenz = (byte)((25000000 / 4096 / frequenz) - 1);

            _i2cMode.AddDataToQueue(_i2cAddrs, 0x00, 0x10);
            _i2cMode.AddDataToQueue(_i2cAddrs, 0xfe, 0x10);
            _i2cMode.AddDataToQueue(_i2cAddrs, 0xfe, _frequenz);
        }
    }
}
