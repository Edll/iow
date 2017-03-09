using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IowLibary.robot {
    public class Achse {
        private const int Min = 150;
        private const int Max = 600;

        private readonly I2CMode _i2CMode;
        private readonly Device _device;

        private readonly byte _i2CAddrs;

        private byte _registerOnL;
        private byte _registerOnH;
        private byte _registerOffL;
        private byte _registerOffH;

        public int Value { get; set; }
        public int AchsenNummer { get; set; }

        private IDictionary<int, Achse> _lastPoints = new Dictionary<int, Achse>();

        /// <summary>
        /// Neue Instanz des PMW Moduls
        /// </summary>
        /// <param name="device">Device welches genutzt werden soll</param>
        /// <param name="i2cAdress">I2C Adresse auf dem Bus</param>
        public Achse(Device device, byte i2cAddrs) {
            this._device = device;
            this._i2CAddrs = i2cAddrs;
            if (_device.Modes is I2CMode) {
                _i2CMode = _device.Modes as I2CMode;
            }
            else {
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

 

            int stepPoints = 2;
            int startPosition = 0;
            Achse lastPoint;
            _lastPoints.TryGetValue( achsenNummer, out lastPoint);
            if (lastPoint != null) {
                startPosition = lastPoint.Value;
            }
            int diff = startPosition - value;
            if (diff < 0) {
                diff = diff*-1;
            }
            int steps = diff/stepPoints;

            for (int i = startPosition; i <= value; i = i + stepPoints) {


                int maxRange = Max - Min;
                int moveRange = (maxRange*i/100) + Min;
                WriteToI2C(Min, moveRange);
            }

            AddAchseToLastPoints(achsenNummer);
        }

        private void AddAchseToLastPoints(int achsenNummer) {
            if (_lastPoints.ContainsKey(achsenNummer)) {
                _lastPoints[achsenNummer] = this.MemberwiseClone() as Achse;
            }
            else {
                _lastPoints.Add(achsenNummer, this.MemberwiseClone() as Achse);
            }
        }

        /// <summary>
        /// Gibt die letzten angefahrenen Punkte aller Achsen die Benutzt worden sind zurück.
        /// </summary>
        /// <returns>Eine Dict aller zuletzt angefahrenen Achsen</returns>
        public IDictionary<int, Achse> ReadOutLastPoints() {
            IDictionary<int, Achse> result = _lastPoints;
            _lastPoints = new Dictionary<int, Achse>();
            return result;
        }

        public string ToString() {
            return "Achse: " + AchsenNummer + " Value: ";
        }

        private void WriteToI2C(int on, int off) {
            CalcServoAdress(AchsenNummer);

            // Berechnen der Werte für die Register
            byte on1 = (byte) (on & 0xff);
            byte on2 = (byte) (on >> 8);
            byte off1 = (byte) (off & 0xff);
            byte off2 = (byte) (off >> 8);

            _i2CMode.AddDataToQueue(_i2CAddrs, _registerOnL, on1);
            _i2CMode.AddDataToQueue(_i2CAddrs, _registerOnH, on2);
            _i2CMode.AddDataToQueue(_i2CAddrs, _registerOffL, off1);
            _i2CMode.AddDataToQueue(_i2CAddrs, _registerOffH, off2);
        }

        private void CalcServoAdress(int servoNumber) {
            _registerOnL = (byte) ((servoNumber*4) + 6);
            _registerOnH = (byte) ((servoNumber*4) + 7);
            _registerOffL = (byte) ((servoNumber*4) + 8);
            _registerOffH = (byte) ((servoNumber*4) + 9);
        }
    }
}