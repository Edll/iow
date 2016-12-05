using System;
using System.Windows.Forms;

namespace IoWarrior {
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <author>M. Vervoorst junk@edlly.de</author>
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
