using System;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>                         
    /// Utils Class for the Libary                   
    /// </summary>                   
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class LibaryUtils {

        // instance prevention
        private LibaryUtils() {
        }
        /// <summary>
        /// Check the DeviceNumber if it is not Valid throws an Exception
        /// </summary>
        /// <param name="deviceNumber">Devicenumber to check</param>
        /// <exception cref="ArgumentException">if number is not Valid</exception>
        public static void CheckDeviceNumber(int deviceNumber) {
            if (deviceNumber < Defines.IowkitStartNumbering) {
                throw new ArgumentException("Die angegebene Device Nummer ist zu klein");
            }
        }
    }
}
