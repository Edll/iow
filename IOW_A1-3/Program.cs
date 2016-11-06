using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IowLibrary;

namespace IOW_A1_3 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }      
    }
}
