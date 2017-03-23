using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roboter.Control {
    public class AxisController {

        private readonly Dictionary<int, Axis> _axis = new Dictionary<int, Axis>();
        private readonly Device _device;
        private readonly byte _i2CAdress;
        private readonly PMW _pmw;

        public AxisController(Device device, byte i2CAdress, int pmwRange) {
            _device = device;
            _i2CAdress = i2CAdress;

            _pmw = new PMW(_device, i2CAdress);
            _pmw.SetFrequenz(pmwRange);
        }

        /// <summary>
        /// Fügt eine neues Achse in den Controller ein.
        /// </summary>
        /// <param name="axisNumber">Die Achsenummer. Ist 1 basierend</param>
        public void AddAxis(int axisNumber) {
            axisNumber = axisNumber - 1;
            Axis axis = new Axis(_device, _i2CAdress, axisNumber);
            _axis.Add(axisNumber, axis);
            _device.AddDeviceEventLog("Achse " + axisNumber + " erfolgreich eingefügt");
        }

        /// <summary>
        /// Bewegt eine Achse zum gewählten Value
        /// </summary>
        /// <param name="axisNumber">Nummer des Achse die Bewegt werden soll. Ist 1 basierend</param>
        /// <param name="value">Wert um den die Achse bewegt werden soll</param>
        public void MoveAxis(int axisNumber, int value) {
            var axis = GetAxis(axisNumber);
            axis?.Move(value);
        }

        private Axis GetAxis(int axisNumber) {
            axisNumber = axisNumber - 1;
            Axis axis;
            _axis.TryGetValue(axisNumber, out axis);
            return axis;
        }

        /// <summary>
        /// Ändert die Achsengeschwindigkeit an einer Achse
        /// </summary>
        /// <param name="axisNumber">Nummer des Achse die Bewegt werden soll. Ist 1 basierend</param>
        /// <param name="speed">Geschwindigkeit mit dem die Achse bewegt werden soll</param>
        public void ChangeSpeed(int axisNumber, int speed) {
            var axis = GetAxis(axisNumber);
            if (axis == null) {
                return;
            }
            axis.Speed = speed;
        }

        /// <summary>
        /// Ändert den Active Status der Achse
        /// </summary>
        /// <param name="axisNumber">Nummer des Achse die Bewegt werden soll. Ist 1 basierend</param>
        /// <param name="isActive">bool wert der den Active Status der Achse abbildet</param>
        public void ChangeActive(int axisNumber, bool isActive) {
            var axis = GetAxis(axisNumber);
            if (axis == null) {
                return;
            }
            axis.IsActive = isActive;
        }
    }
}
