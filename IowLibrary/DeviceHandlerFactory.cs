using System.Collections.Generic;
using System.Threading;

namespace IowLibary {
    /// <summary>
    /// Controlls and Handel Threads for the DeviceManager.
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class DeviceHandlerFactory {
        private readonly Dictionary<int, DeviceThreadHandler> _deviceThreadpool = new Dictionary<int, DeviceThreadHandler>();

        /// <summary>
        /// Destroys on Deconstrution all Runninig Threads
        /// </summary>
        ~DeviceHandlerFactory() {
            StopAllDeviceThreads();
        }

        /// <summary>
        /// Start a new Thread for the given Devices and add it to the Threadpool
        /// </summary>
        /// <param name="device">device for the new thread</param>
        /// <returns>null if device is null else the new DeviceThread object</returns>
        public DeviceThreadHandler AddNewDeviceThread(Device device) {
            if (device == null) {
                return null;
            }
            var deviceHandler = new DeviceThreadHandler(device);
            var thread = new Thread(deviceHandler.RunDevice);
            deviceHandler.DeviceThread = thread;
            thread.Start();
            if (thread.IsAlive) {
                if (_deviceThreadpool.ContainsKey(device.DeviceNumber)) {
                    StopDeviceThread(device);
                }
                _deviceThreadpool.Add(device.DeviceNumber, deviceHandler);
            }
            return deviceHandler;
        }

        /// <summary>
        /// Start a new Thread for the given Devices and add it to the Threadpool
        /// </summary>
        /// <param name="device">device for the new thread</param>
        public void StopDeviceThread(Device device) {
            if (device == null) {
                return;
            }
            DeviceThreadHandler deviceThreadHandler;
            _deviceThreadpool.TryGetValue(device.DeviceNumber, out deviceThreadHandler);
            if (deviceThreadHandler != null) {
                deviceThreadHandler.RequestStop();
                //         deviceThreadHandler.DeviceThread.Join();
            }
            _deviceThreadpool.Remove(device.DeviceNumber);
        }

        /// <summary>
        /// Stops all Thread in this Factory and Clears Threadpool
        /// </summary>
        public void StopAllDeviceThreads() {
            foreach (var deviceEntry in _deviceThreadpool) {
                var deviceHandler = deviceEntry.Value;
                var thread = deviceHandler.DeviceThread;
                deviceHandler.RequestStop();
                thread.Join();
            }
            _deviceThreadpool.Clear();
        }
    }
}
