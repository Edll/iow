using System;
using System.Linq;
using System.Text;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// IowKit calls methods from the DllWapper class. It will be Warp input 
    /// and output vars for this Api.
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class IowKit {

        /// <summary>
        /// Open all devices wich are connected to the USB Ports.
        /// </summary>
        /// <returns>null if no devices was found else handler of the first device.</returns>
        public static int? OpenDevices() {
            var handler = ConvertIntPtrToInt(Method.IowKitOpenDevice());
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
            var number = (int)Method.IowKitGetNumDevs();
            if (number == 0) {
                return null;
            }
            return number;
        }

        /// <summary>
        /// Try to Close a device with the given Handler.
        /// </summary>
        /// <param name="handler">device handler</param>
        public static void CloseDevice(int? handler) {
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

            var handler = ConvertIntPtrToInt(Method.IowKitGetDeviceHandle((uint)deviceNumber));
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

            var id = Method.IowKitGetProductId(ConvertIntToIntPtr(handler));
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
        public static string GetProductSerial(int? handler) {
            if (handler == null) {
                throw new IowLibaryException("handler to get product serial is null");
            }
            var sb = new StringBuilder();

            var conditon = Method.IowKitGetSerialNumber(ConvertIntToIntPtr(handler), sb);
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
        public static string GetProductSoftwareVersion(int? handler) {
            if (handler == null) {
                throw new IowLibaryException("handler to get software version is null");
            }
            var software = Method.IowKitGetRevision(ConvertIntToIntPtr(handler));
            // Es sind 4 Hex-Stellen gültig. Wäre die gegenwärtige Softwareversion 1.0.2.1 so wird
            // 0x1021 zurückgegeben.
            return software == Defines.IOW_NON_LEGACY_REVISION ? "no Software Version" : $"{software:X}";
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
            var handlerConvert = ConvertIntToIntPtr(handler);

            int? result = (int)Method.IowKitRead(handlerConvert, (uint)numPipe, data, (uint)byteLength);
            if (result == 0) {
                return null;
            }
            return result;
        }

        public static bool ReadImmediate(int? handler, byte[] data) {
            if (handler == null) {
                throw new IowLibaryException("handler to to read is null");
            }
            var handlerConvert = ConvertIntToIntPtr(handler);

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
            var handlerConvert = ConvertIntToIntPtr(handler);

            int? result = (int)Method.IowKitWrite(handlerConvert, (uint)numPipe, data, (uint)byteLength);
            if (result == 0) {
                result = null;
            }

            return result;
        }

        public static bool Timeout(int? handler, int timeout) {
            if (handler == null) {
                throw new IowLibaryException("handler to to write is null");
            }
            var handlerConvert = ConvertIntToIntPtr(handler);
           return Method.IowKitSetTimeout(handlerConvert, (uint)timeout);
        }

        private static IntPtr ConvertIntToIntPtr(int? input) {
            if (input == null) {
                throw new IowLibaryException("input to convert In to IntPtr is null");
            }
            return (IntPtr)input;
        }

        private static int ConvertIntPtrToInt(IntPtr input) {
            return (int)input;
        }

    }
}
