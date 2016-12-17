using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using IowLibary.DllWapper;

namespace IowLibary {

    /// <summary>
    /// Delegates Runtimes events
    /// </summary>
    /// <param name="runtime">Runtime in ms</param>
    /// 
    public delegate void DeviceHandlerRuntimeEvent(long runtime);
    /// <summary>
    /// Handling for the Device Threads
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class DeviceThreadHandler {
        private const int CountRuntimeRounds = 50;


        /// <summary>
        /// When a new Runtime measure result is available this event will it report
        /// </summary>
        public event DeviceHandlerRuntimeEvent RunTimeUpdate;

        private volatile bool _stopHandler;
        private bool _isDataWrite;

        private long _runtime;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly List<long> _stopWatchResult = new List<long>();

        /// <summary>
        /// Holds Methode for the Device to handel IO Loop
        /// </summary>
        /// <param name="device">device wich will be threaded</param>
        public DeviceThreadHandler(Device device) {
            Device = device;
            if (Device != null) {
                Device.PortBitOutChange += Device_PortBitOutChange;
            }
        }

        /// <summary>
        /// the device Thread
        /// </summary>
        public Thread DeviceThread { get; set; }

        /// <summary>
        /// is set with the param ctor
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// Runtime of the this device thread
        /// </summary>
        public long Runtime {
            get { return _runtime; }
            set {
                _runtime = value;
                RunTimeUpdate?.Invoke(_runtime);
            }
        }

        /// <summary>
        /// Starts the Device I/O Loop
        /// </summary>
        public void RunDevice() {
            _stopHandler = false;

          //  Device.PortsInitialisation(Defines.IowPipeIoPins);
            Device.Modes.PortsInitialisation();

            // TODO in Imodes aufnehmen!
            Device.SetReadTimeout(Defines.DeviceTimeout);

            while (!_stopHandler) {
                _stopwatch.Reset();
                _stopwatch.Start();
                if (_isDataWrite) {
                    //     var ok = Device.WritePortStateToDevice();
                    var ok = Device.Modes.Write(Device.Ports);
                    if (ok) {
                        _isDataWrite = false;
                    }
                }
                //   Device.ReadInPortState(Defines.IowPipeIoPins);
                Device.Modes.Read();
                _stopwatch.Stop();
                AddStopWatchResult(_stopwatch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Stops the I/O loop at the next cycle
        /// </summary>
        public void RequestStop() {
            _stopHandler = true;
        }

        private void AddStopWatchResult(long stopwatchElapsedMilliseconds) {
            _stopWatchResult.Add(stopwatchElapsedMilliseconds);

            if (_stopWatchResult.Count() < CountRuntimeRounds) return;

            UpdateRuntime();
        }

        private void UpdateRuntime() {
            var time = _stopWatchResult.Sum();
            time = time / _stopWatchResult.Count();
            Runtime = time;
            _stopWatchResult.Clear();
        }

        private void Device_PortBitOutChange(Device device, Port port, PortBit portbit) {
            _isDataWrite = true;
        }
    }
}
