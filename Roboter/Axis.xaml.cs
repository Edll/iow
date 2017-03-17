using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Roboter {
    /// <summary>
    /// Interaction logic for Axis.xaml
    /// </summary>
    public partial class Axis : UserControl {
        private int _minimalValue = 0;
        private int _maximalValue = 0;
        private bool _isEndPosition = false;

        public bool IsAktiv { get; set; }

        public bool IsEndPosition {
            get { return _isEndPosition; }
            set {
                _isEndPosition = value;
                CheckEndPosition.IsChecked = value;
            }
        }

        public int AxisValue { get; set; }

        public int MinimalValue {
            get { return _minimalValue; }
            set {
                _minimalValue = value;
                LblMinimal.Content = Convert.ToString(value);
            }
        }

        public int MaximalValue {
            get { return _maximalValue; }
            set {
                _maximalValue = value;
                LblMaximal.Content = Convert.ToString(value);
            }
        }

        public Axis() {
            InitializeComponent();
        }

        private void BttAktiv_Click(object sender, RoutedEventArgs e) {
            IsAktiv = !IsAktiv;
            CheckIsAktiv.IsChecked = IsAktiv;
            if (IsAktiv) {
                BttAktiv.Content = "Deaktivieren";
            }
            else {
                BttAktiv.Content = "Aktivieren";
            }
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

        private void SliderManual_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            AxisValue = Convert.ToInt32(SliderManual.Value);
            TxtActualValue.Text = Convert.ToString(AxisValue);
        }

        private void TxtManualValue_KeyUp(object sender, KeyEventArgs e) {
            try {
                if (e.Key == Key.Enter) {
                   int axisValue = Convert.ToInt32(TxtManualValue.Text);
                    if (axisValue < MinimalValue || axisValue > MaximalValue) {
                        TxtManualValue.Background = Brushes.Tomato;
                        return;
                    }
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
    }
}