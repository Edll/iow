using System.Collections.Generic;
using System.Threading;

namespace IowLibrary {
    /// <summary>
    /// Controlls and Handel Threads for the DeviceFactory.
    /// </summary>
    public class DeviceHandlerFactory {
        private readonly Dictionary<int, DeviceHandler> _deviceThreadpool = new Dictionary<int, DeviceHandler>();

        /// <summary>
        /// Destroys on Deconstrution all Runninig Threads
        /// </summary>
        ~DeviceHandlerFactory() {
            StopAllDeviceThreads();
        }

        /// <summary>
        /// Start a new Thread for the given Devices and add it to the Threadpool
        /// </summary>
        /// <param name="device"></param>
        public DeviceHandler AddNewDeviceThread(Device device) {
            if (device == null) {
                return null;
            }
            var deviceHandler = new DeviceHandler(device);
            var thread = new Thread(deviceHandler.RunDevice);
            deviceHandler.DeviceThread = thread;
            thread.Start();
            if (thread.IsAlive) {
                _deviceThreadpool.Add(device.DeviceNumber, deviceHandler);
            }
            return deviceHandler;
        }

        /// <summary>
        /// Start a new Thread for the given Devices and add it to the Threadpool
        /// </summary>
        /// <param name="device"></param>
        public void StopDeviceThread(Device device) {
            if (device == null) {
                return;
            }
            DeviceHandler deviceHandler;
            _deviceThreadpool.TryGetValue(device.DeviceNumber, out deviceHandler);
            if (deviceHandler != null) {
                deviceHandler.RequestStop();
                deviceHandler.DeviceThread.Join();
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
