using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IowLibrary.DllWapper;

namespace IowLibrary {
    /// <summary>
    /// IowKit calls methods from the DllWapper class. It will be Warp input 
    /// and output vars for this Api.
    /// </summary>
    public class IowKit {

        /// <summary>
        /// Open all devices wich are connected to the USB Ports.
        /// </summary>
        /// <returns>null if no devices was found else handler of the first device.</returns>
        public static int? OpenDevices() {
            int handler = ConvertIntPtrToInt(Method.IowKitOpenDevice());
            if (handler == 0) {
                return null;
            }
            return handler;
        }

        /// <summary>
        /// Get the number of connected Devices.
        /// </summary>
        /// <returns>null if no device was found else number of Devices.</returns>
        public static int? GetConnectDeviceCounter() {
            int number = (int)Method.IowKitGetNumDevs();
            if (number == 0) {
                return null;
            }
            return number;
        }

        /// <summary>
        /// Try to Close a device with the given Handler.
        /// </summary>
        /// <param name="handler">device handler</param>
        public static void closeDevice(int? handler) {
            Method.IowKitCloseDevice(ConvertIntToIntPtr(handler));
        }

        /// <summary>
        /// Get the handler for the Device with the number. Bevor use this you must call 
        /// OpenDevices() to open the device stream.
        /// </summary>
        /// <param name="deviceNumber">Devicenumber of the selected Device</param>
        /// <returns>null if device was not Found else handler</returns>
        /// <exception cref="IowLibaryException">If deviceNumber is null</exception> 
        public static int? GetHandlerForDevice(int? deviceNumber) {
            if (deviceNumber == null) {
                throw new IowLibaryException("devicenumber is null");
            }

            int handler = ConvertIntPtrToInt(Method.IowKitGetDeviceHandle((uint)deviceNumber));
            if (handler == 0) {
                return null;
            } else {
                return handler;
            }
        }

        /// <summary>
        /// get the ProductId from a device.
        /// </summary>
        /// <param name="handler">Handler for the Device</param>
        /// <returns>null if device could not be found else int with product id</returns>
        /// <exception cref="IowLibaryException">If handler is null</exception> 
        public static int? GetProductId(int? handler) {
            if (handler == null) {
                throw new IowLibaryException("handler to get productid is null");
            }

            uint id = Method.IowKitGetProductId(ConvertIntToIntPtr(handler));
            if (id == 0) {
                return null;
            } else {
                return (int)id;
            }
        }

        /// <summary>
        /// get the Prductserial from a Device.
        /// </summary>
        /// <param name="handler">Handler for the Device</param>
        /// <returns>Productserial as String</returns>
        /// <exception cref="IowLibaryException">If handler is null</exception> 
        public static String GetProductSerial(int? handler) {
            if (handler == null) {
                throw new IowLibaryException("handler to get product serial is null");
            }
            StringBuilder sb = new StringBuilder();

            bool conditon = Method.IowKitGetSerialNumber(ConvertIntToIntPtr(handler), sb);
            if (!conditon) {
                return null;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get the Product Software version of the devices with the given handler
        /// </summary>
        /// <param name="handler">Handler for the Device</param>
        /// <returns>Software Version as formated String</returns>
        /// <exception cref="IowLibaryException">If handler is null</exception> 
        public static String GetProductSoftwareVersion(int? handler) {
            if (handler == null) {
                throw new IowLibaryException("handler to get software version is null");
            }
            UInt32 software = Method.IowKitGetRevision(ConvertIntToIntPtr(handler));
            if (software == Defines.IOW_NON_LEGACY_REVISION) {
                return "no Software Version";
            }
            /// Es sind 4 Hex-Stellen gültig. Wäre die gegenwärtige Softwareversion 1.0.2.1 so wird
            /// 0x1021 zurückgegeben.
            return String.Format("{0:X}", software);
        }

        /// <summary>
        /// Read in Data from Device, while reading thread is blocked.
        /// </summary>
        /// <param name="handler">Handler for the Device</param>
        /// <param name="numPipe">DataPipe of the usb interface</param>
        /// <param name="data">Data Buffer for Result</param>
        /// <param name="byteLength">length for the Data bytes.</param>
        /// <returns>Real number of bits wich was readin</returns>
        public static int? Read(int? handler, int numPipe, byte[] data, int byteLength) {
            if (handler == null) {
                throw new IowLibaryException("handler to to read is null");
            }
            IntPtr handlerConvert = ConvertIntToIntPtr(handler);

            int? result = (int)Method.IowKitRead(handlerConvert, (UInt32)numPipe, data, (UInt32)byteLength);
            if (result == 0) {
                return null;
            }
            return result;
        }

        public static bool ReadImmediate(int? handler, byte[] data) {
            if (handler == null) {
                throw new IowLibaryException("handler to to read is null");
            }
            IntPtr handlerConvert = ConvertIntToIntPtr(handler);

            return Method.IowKitReadImmediate(handlerConvert, data);
        }

        /// <summary>
        /// Write Data to a Device.
        /// </summary>
        /// <param name="handler">Handler for the Device</param>
        /// <param name="numPipe">DataPipe of the usb interface</param>
        /// <param name="data">data wich are write to the device</param>
        /// <param name="byteLength">lenght of the Data bytes</param>
        /// <returns>Real number of bits wich was write to the device</returns>
        public static int? Write(int? handler, int numPipe, byte[] data, int byteLength) {
            if (handler == null) {
                throw new IowLibaryException("handler to to write is null");
            }
            IntPtr handlerConvert = ConvertIntToIntPtr(handler);

            int? result = (int)Method.IowKitWrite(handlerConvert, (UInt32)numPipe, data, (UInt32)byteLength);
            if (result == 0) {
                result = null;
            }

            return result;
        }

        public static bool Timeout(int? handler, int timeout) {
            if (handler == null) {
                throw new IowLibaryException("handler to to write is null");
            }
            IntPtr handlerConvert = ConvertIntToIntPtr(handler);
           return Method.IowKitSetTimeout(handlerConvert, (uint)timeout);
        }

        private static IntPtr ConvertIntToIntPtr(int? Input) {
            if (Input == null) {
                throw new IowLibaryException("input to convert In to IntPtr is null");
            }
            return (IntPtr)Input;
        }

        private static int ConvertIntPtrToInt(IntPtr Input) {
            return (int)Input;
        }

    }
}
