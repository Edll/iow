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

namespace Roboter.GUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Axis1.MaximalValue = 360;
            Axis1.MinimalValue = 0;
            Axis1.HeaderName = "Achse 1";
            Axis1.Changed +=Axis1OnChanged;
        }

        private void Axis1OnChanged(int value) {
            Console.WriteLine("Value: " + value);
        }


        private void MenuConnectIow_Click(object sender, RoutedEventArgs e) {

        }

        private void MenuCloseIow_Click(object sender, RoutedEventArgs e) {

        }

        private void MenuClose_Click(object sender, RoutedEventArgs e) {
           // TODO Schliesen des Forms
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {
        }
    }
}
