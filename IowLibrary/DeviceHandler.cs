using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using IowLibary.DllWapper;

namespace IowLibary {
    public delegate void DeviceHandlerEvent(long runtime);
    /// <summary>
    /// Handling for the Device Threads
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class DeviceHandler {
        private const int CountRuntimeRounds = 50;

        public event DeviceHandlerEvent RunTimeUpdate;

        private volatile bool _stopHandler;
        private bool _isDataWrite;

        private long _runtime;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly List<long> _stopWatchResult = new List<long>();

        public DeviceHandler(Device device) {
            Device = device;
            if (Device != null) {
                Device.PortBitOutChange += Device_PortBitOutChange;
            }
        }

        public Thread DeviceThread { get; set; }

        public Device Device { get; set; }

        public long Runtime {
            get { return _runtime; }
            set {
                _runtime = value;
                RunTimeUpdate?.Invoke(_runtime);
            }
        }

        public void RunDevice() {
            _stopHandler = false;

            Device.PortsInitialisation(Defines.IOW_PIPE_IO_PINS);

            Device.SetReadTimeout(DeviceFactory.DeviceTimeout);

            while (!_stopHandler) {
                _stopwatch.Reset();
                _stopwatch.Start();
                if (_isDataWrite) {
                    var ok = Device.WritePortStateToDevice();
                    if (ok) {
                        _isDataWrite = false;
                    }
                }
                Device.ReadInPortState(Defines.IOW_PIPE_IO_PINS);
                _stopwatch.Stop();
                AddStopWatchResult(_stopwatch.ElapsedMilliseconds);
            }
        }

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
