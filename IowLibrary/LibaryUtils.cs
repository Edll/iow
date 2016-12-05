using System;
using IowLibrary.DllWapper;

namespace IowLibrary {
    public class LibaryUtils {
        /// <summary>
        /// Utils Class for the Libary
        /// </summary>
        /// <author>M. Vervoorst junk@edlly.de</author>
        private LibaryUtils() {

        }
        /// <summary>
        /// Check the DeviceNumber if it is not Valid throws an Exception
        /// </summary>
        /// <param name="deviceNumber">Devicenumber to check</param>
        /// <exception cref="ArgumentException">if number is not Valid</exception>
        public static void CheckDeviceNumber(int deviceNumber) {
            if (deviceNumber < Defines.IOWKIT_START_NUMBERING) {
                throw new ArgumentException("Die angegebene Device Nummer ist zu klein");
            }
        }
    }
}
