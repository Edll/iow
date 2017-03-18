using System;
using System.Collections.Generic;

namespace Roboter.Control {
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

        private IDictionary<int, int> _lastPoints = new Dictionary<int, int>();

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
            // wenn 0 dann schleife ewig!
            if (value <= 0) {
                Console.WriteLine("Value == -1");
                return;
          
            }

            AchsenNummer = achsenNummer;
            Value = value;

 

            int stepPoints = 1;
            int startPosition = 0;
            Int32 lastPoint;
            _lastPoints.TryGetValue( achsenNummer, out lastPoint);
            if (lastPoint != null) {
                startPosition = lastPoint;
            }
            int diff = startPosition - value;
            if (diff < 0) {
                diff = diff*-1;
            }
            int steps = diff/stepPoints;

            for (int i = startPosition; i <= value; i = i + steps) {


                int maxRange = Max - Min;
                int moveRange = (maxRange*i/100) + Min;
                WriteToI2C(Min, moveRange);
            }

            int maxRange2 = Max - Min;
            int moveRange2 = (maxRange2 * value / 100) + Min;
       //     WriteToI2C(Min, moveRange2);

            // bring uns in einen Speicher überlauf???
           // AddAchseToLastPoints(achsenNummer);
        }

        private void AddAchseToLastPoints(int achsenNummer) {
            if (_lastPoints.ContainsKey(achsenNummer)) {
                _lastPoints[achsenNummer] = Value;
            }
            else {
                _lastPoints.Add(achsenNummer, Value);
            }
        }

        /// <summary>
        /// Gibt die letzten angefahrenen Punkte aller Achsen die Benutzt worden sind zurück.
        /// </summary>
        /// <returns>Eine Dict aller zuletzt angefahrenen Achsen</returns>
        public IDictionary<int, int> ReadOutLastPoints() {
            IDictionary<int, int> result = _lastPoints;
            _lastPoints = new Dictionary<int, int>();
            return result;
        }

        public string ToString() {
            return "Achse: " + AchsenNummer + " Value: " + Value;
        }

        private void WriteToI2C(int on, int off) {
            CalcServoAdress(AchsenNummer);

            // Berechnen der Werte für die Register
            byte on1 = (byte) (on & 0xff);
            byte on2 = (byte) (on >> 8);
            byte off1 = (byte) (off & 0xff);
            byte off2 = (byte) (off >> 8);
            Console.WriteLine("Write To ic2");
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
