using System;
using System.Collections.Generic;

namespace Roboter.Control {
    public class Axis {
        private const int Min = 150;
        private const int Max = 600;
        public const int MaxSpeed = 100;
        public const int MinSpeed = 1;

        private readonly I2CMode _i2CMode;

        private readonly byte _i2CAddrs;

        private byte _registerOnL;
        private byte _registerOnH;
        private byte _registerOffL;
        private byte _registerOffH;

      

        public int Value { get; set; }
        private int _lastPosition = 0;
        public int AxisNumber { get; set; }
        public bool IsActive { get; set; }
        public int Speed { get; set; }

        /// <summary>
        /// Neue Instanz des PMW Moduls
        /// </summary>
        /// <param name="device">Device welches genutzt werden soll</param>
        /// <param name="i2CAddrs">I2C Adresse auf dem Bus</param>
        /// <param name="axisNumber">Nummer der Achse am Arm. Ist 0 Basierend</param>
        public Axis(Device device, byte i2CAddrs, int axisNumber) {
            AxisNumber = axisNumber;
            _i2CAddrs = i2CAddrs;

            I2CMode i2CMode = device.Modes as I2CMode;
            if (i2CMode != null) {
                _i2CMode = i2CMode;
            }
            else {
                device.AddDeviceError("Device ist nicht im I2C Mode");
            }
        }

        /// <summary>
        /// Values from 0 to 100
        /// </summary>
        /// <param name="value"></param>
        /// <param name="achsenNummer"></param>
        public void Move(int value) {
            // wenn 0 dann schleife ewig!
            if (value <= 0) {
                Console.WriteLine("Value == -1");
                return;
          
            }
            Value = value;
            int stepPoints = 1;
            int startPosition = _lastPosition;
   
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

 
        public override string ToString() {
            return "Achse: " + AxisNumber + " Value: " + Value;
        }

        private void WriteToI2C(int on, int off) {
            CalcServoAdress(AxisNumber);

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
