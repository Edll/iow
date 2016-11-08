using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using IowLibrary;

namespace IOW_A1_3 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            System.Console.WriteLine("io Read in!");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            DeviceFactory df = new DeviceFactory(deviceError);
            Device device = df.GetDeviceNumber(1);

            
            DeviceHandler portHandler = new DeviceHandler(device);

            Thread portThread = new Thread(portHandler.IO);
            portThread.Start();



          

        }

        private static void deviceError(string deviceError) {
            System.Console.WriteLine(deviceError);
        }
    }
}
