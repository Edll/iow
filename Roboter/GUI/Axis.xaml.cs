using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Roboter.GUI {
    /// <summary>
    /// Wenn der User die Achse verändert wird diese Event ausgelöst
    /// </summary>
    /// <param name="value">Achsen wert der vom User gewählt worden ist.</param>
    public delegate void ChangeAxisValueEvent(int value);

    /// <summary>
    /// Wird ausgelöst wenn sich der Aktiv Status der Achse ändert
    /// </summary>
    /// <param name="active">bool der den Actualvalue der Achse enthält</param>
    public delegate void ChangeActiveEvent(bool active);

    /// <summary>
    /// Interaction logic for Axis.xaml
    /// </summary>
    public partial class Axis : UserControl {
        private int _minimalValue = 0;
        private int _maximalValue = 0;
        private bool _isEndPosition = false;
        private string _name = "Achse";
        private bool _isActive;
        private int _axisValue;
        private int _speed;

        /// <summary>
        /// Wird ausgelöst wann immer der User den Aktuellen Wert verändert
        /// </summary>
        public event ChangeAxisValueEvent AxisValueChanged;

        /// <summary>
        /// Wird ausgelöst wenn der SpeedWert geändert wird
        /// </summary>
        public event ChangeAxisValueEvent SpeedValueChanged;

        /// <summary>
        /// Wird ausgelöst wenn sich der Aktivstatus der Achse ändert
        /// </summary>
        public event ChangeActiveEvent OnChangedActive;

        /// <summary>
        /// Gibt den aktuellen Aktiv Status des Achsenkanals wieder oder setzt den in die GUI
        /// </summary>
        public bool IsActive {
            get { return _isActive; }
            set {
                _isActive = value;
                ChangeActivStatus(_isActive);
                OnChangeActive();
            }
        }

        /// <summary>
        /// Anzeige ob die Endlage der Achse erreicht ist
        /// </summary>
        public bool IsEndPosition {
            get { return _isEndPosition; }
            set {
                _isEndPosition = value;
                CheckEndPosition.IsChecked = value;
            }
        }

        /// <summary>
        /// Setzt oder gibt den Namen im Rahmen wieder
        /// </summary>
        public string HeaderName {
            get { return _name; }
            set {
                GroupBoxMain.Header = value;
                _name = value;
            }
        }

        /// <summary>
        /// Aktueller wert der für die Achse eingestellt worden ist.
        /// </summary>
        public int AxisValue {
            get { return _axisValue; }
            set {
                _axisValue = value;
                OnChangedValue();
            }
        }

        /// <summary>
        /// Gibt den Minimal oder Setzt den Minimal wert in die Oberfläche
        /// </summary>
        public int MinimalValue {
            get { return _minimalValue; }
            set {
                _minimalValue = value;
                LblMinimal.Content = Convert.ToString(value);
            }
        }

        /// <summary>
        /// Gibt oder Setzt den Maximalwert in die Oberfläche
        /// </summary>
        public int MaximalValue {
            get { return _maximalValue; }
            set {
                _maximalValue = value;
                LblMaximal.Content = Convert.ToString(value);
            }
        }

        /// <summary>
        /// Speed wert der Achse
        /// </summary>
        public int Speed {
            get { return _speed; }
            set {
                _speed = value;
                TxtSpeed.Text = Convert.ToString(value);
                OnChangedSpeed();
            }
        }

        public Axis() {
            InitializeComponent();
        }

        protected virtual void OnChangedValue() {
            AxisValueChanged?.Invoke(_axisValue);
        }

        protected virtual void OnChangedSpeed() {
            SpeedValueChanged?.Invoke(_speed);
        }

        protected virtual void OnChangeActive() {
            OnChangedActive?.Invoke(_isActive);
        }

        private void BttAktiv_Click(object sender, RoutedEventArgs e) {
            IsActive = !IsActive;
            ChangeActivStatus(IsActive);
        }

        private void ChangeActivStatus(bool isActive) {
            CheckIsAktiv.IsChecked = isActive;
            BttAktiv.Content = isActive ? "Deaktivieren" : "Aktivieren";
        }

        private void CheckEndPosition_Checked(object sender, RoutedEventArgs e) {
            if (CheckEndPosition.IsChecked != null && CheckEndPosition.IsChecked.Value) {
                GridCheckEndPosition.Background = Brushes.Tomato;
            }
        }

        private void CheckEndPosition_Unchecked(object sender, RoutedEventArgs e) {
            if (CheckEndPosition.IsChecked != null && !CheckEndPosition.IsChecked.Value) {
                GridCheckEndPosition.Background = Brushes.WhiteSmoke;
            }
        }

        private void TxtManualValue_KeyUp(object sender, KeyEventArgs e) {
            try {
                // Wenn Enter gedrückt wird dann wird der eingeben wert eingestellt
                if (e.Key == Key.Enter) {
                    int axisValue = Convert.ToInt32(TxtManualValue.Text);
                    // Wert ausserhalb des grenzbereiches dann gibt des einen Fehler
                    if (axisValue < MinimalValue || axisValue > MaximalValue) {
                        TxtManualValue.Background = Brushes.Tomato;
                        return;
                    }
                    // Werte übertragen auf Slider und Anzeige
                    AxisValue = axisValue;
                    TxtActualValue.Text = TxtManualValue.Text;
                    SliderManual.Value = Convert.ToDouble(axisValue);
                    TxtActualValue.Text = Convert.ToString(axisValue);
                }
                else {
                    TxtManualValue.Background = Brushes.White;
                }
            }
            catch (FormatException) {
                TxtManualValue.Background = Brushes.Tomato;
            }
        }

        private void SliderManual_OnDragCompleted(object sender, DragCompletedEventArgs e) {
            AxisValue = Convert.ToInt32(SliderManual.Value);
            TxtActualValue.Text = Convert.ToString(AxisValue);
        }

        private void SliderManual_OnKeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Left || e.Key == Key.Right) {
                AxisValue = Convert.ToInt32(SliderManual.Value);
                TxtActualValue.Text = Convert.ToString(AxisValue);
            }
        }

        private void TxtSpeed_KeyUp(object sender, KeyEventArgs e) {
            try {
                // Wenn Enter gedrückt wird dann wird der eingeben wert eingestellt
                if (e.Key == Key.Enter) {
                    int speed = Convert.ToInt32(TxtSpeed.Text);
                    // Wert ausserhalb des grenzbereiches dann gibt des einen Fehler
                    if (speed < Control.Axis.MinSpeed || speed > Control.Axis.MaxSpeed ) {
                        TxtSpeed.Background = Brushes.Tomato;
                        return;
                    }
                    // Werte übertragen auf Slider und Anzeige
                    Speed = speed;
                    TxtSpeed.Text = Convert.ToString(speed);
                } else {
                    TxtSpeed.Background = Brushes.White;
                }
            } catch (FormatException) {
                TxtSpeed.Background = Brushes.Tomato;
            }
        }
    }
}