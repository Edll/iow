using System;
using System.Windows;
using System.Windows.Controls;

namespace Roboter.GUI {

    /// <summary>
    /// Menü Events im SourceCodeEditor Editor
    /// </summary>
    public delegate void SourceCodeMenuEvent(string source);

    /// <summary>
    /// Interaction logic for SourceCodeEditor.xaml
    /// </summary>
    public partial class SourceCodeEditor : UserControl {
        private string _sourceCode;

        /// <summary>
        /// Menü Auswahl Speichern des SourceCodes
        /// </summary>
        public event SourceCodeMenuEvent MenuSaveClick;

        /// <summary>
        /// Menü Auwahl Laden des SourceCodes
        /// </summary>
        public event SourceCodeMenuEvent MenuLoadClick;

        /// <summary>
        /// Menü auswahl Prüfen des SourceCodes
        /// </summary>
        public event SourceCodeMenuEvent MenuCheckClick;

        /// <summary>
        /// Führt den SourceCodeEditor aus
        /// </summary>
        public event SourceCodeMenuEvent MenuRunClick;

        public string SourceCode {
            get {
                _sourceCode = TxtScourceCode.Text;
                return _sourceCode;
            }
            set {
                _sourceCode = value;
            }
        }

        public SourceCodeEditor() {
            InitializeComponent();
        }

        private void MenuLoad_OnClick(object sender, RoutedEventArgs e) {
            MenuLoadClick?.Invoke(SourceCode);
        }

        private void MenuSave_OnClick(object sender, RoutedEventArgs e) {
            MenuSaveClick?.Invoke(SourceCode);
        }

        private void MenuCheckCode_OnClick(object sender, RoutedEventArgs e) {
            MenuCheckClick?.Invoke(SourceCode);
        }

        private void MenuRun_OnClick(object sender, RoutedEventArgs e) {
            MenuRunClick?.Invoke(SourceCode);
        }
    }
}
