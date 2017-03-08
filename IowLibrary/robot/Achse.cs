using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibary.robot {
    public class Achse {
        private const int MIN = 150;
        private const int MAX = 600;

        private I2CMode _i2cMode;
        private Device _device;

        private byte _i2cAddrs;

        private byte _registerOnL;
        private byte _registerOnH;
        private byte _registerOffL;
        private byte _registerOffH;

        public int Value;
        public int AchsenNummer;

        public IDictionary<int, Achse> LastPoints = new Dictionary<int, Achse>();

        /// <summary>
        /// Neue Instanz des PMW Moduls
        /// </summary>
        /// <param name="device">Device welches genutzt werden soll</param>
        /// <param name="i2cAdress">I2C Adresse auf dem Bus</param>
        public Achse(Device device, byte  i2cAddrs) {
            this._device = device;
            this._i2cAddrs = i2cAddrs;
            if (_device.Modes is I2CMode) {
                _i2cMode = _device.Modes as I2CMode;
            } else {
                _device.AddDeviceError("Device ist nicht im I2C Mode");
            }
        }

        /// <summary>
        /// Values from 0 to 100
        /// </summary>
        /// <param name="value"></param>
        /// <param name="achsenNummer"></param>
        public void Move(int achsenNummer, int value) {
            AchsenNummer = achsenNummer;
            Value = value;
            if (LastPoints.ContainsKey(achsenNummer)) {
                Achse achse;
                LastPoints.TryGetValue(achsenNummer, out achse);
                achse = this;
            } else {
                LastPoints.Add(achsenNummer, this);
            }

            int maxRange = MAX - MIN;
            int moveRange = (maxRange * value / 100) + MIN;
            WriteToI2C(MIN, moveRange);
        }

        private void WriteToI2C(int on, int off) {
            CalcServoAdress(AchsenNummer);

            byte ON_1 = (byte)(on & 0xff);
            byte ON_2 = (byte)(on >> 8);
            byte OFF_1 = (byte)(off & 0xff);
            byte OFF_2 = (byte)(off >> 8);

            _i2cMode.AddDataToQueue(_i2cAddrs, _registerOnL, ON_1);
            _i2cMode.AddDataToQueue(_i2cAddrs, _registerOnH, ON_2);
            _i2cMode.AddDataToQueue(_i2cAddrs, _registerOffL, OFF_1);
            _i2cMode.AddDataToQueue(_i2cAddrs, _registerOffH, OFF_2);
        }

        private void CalcServoAdress(int servoNumber) {
            _registerOnL = (byte)((servoNumber * 4) + 6);
            _registerOnH = (byte)((servoNumber * 4) + 7);
            _registerOffL = (byte)((servoNumber * 4) + 8);
            _registerOffH = (byte)((servoNumber * 4) + 9);
        }
    }
}
