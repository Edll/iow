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
            System.Console.WriteLine("bla: ");
            DeviceFactory df = new DeviceFactory(Df_OpenError);
            int number = df.GetNumberOfDevices();

            System.Console.WriteLine("bla: " + number);

            System.Console.Read();

          Device device =  df.GetDeviceNumber(1);
            if (device != null) {
                device.DeviceError += Device_DeviceError;
                System.Console.WriteLine("bla: " + device.Handler);
                System.Console.WriteLine("ProduktID: " + device.ProductId);
                System.Console.WriteLine("Serial: " + device.SoftwareVersion);
                System.Console.WriteLine("Software: " + device.Serial);
               
            }
        
            System.Console.Read();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

        }

        private static void Device_DeviceError(Device device) {
            System.Console.WriteLine("Upss.... Device error!: " + device);
        }

        private static void Df_OpenError(String deviceError) {
            System.Console.WriteLine("Upss.... Device could not open!: " + deviceError);
        }

       
    }
}
