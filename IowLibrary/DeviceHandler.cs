using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using IowLibrary.DllWapper;

namespace IowLibrary {
    public delegate void DeviceHandlerEvent(long runtime);

    public class DeviceHandler {
        public event DeviceHandlerEvent RunTimeUpdate;

        private volatile bool _stopHandler = false;
        private bool _isDataWrite;

        private long _runtime;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly List<long> _stopWatchResult = new List<long>();

        public DeviceHandler(Device device) {
            this.Device = device;
            device.PortBitOutChange += Device_PortBitOutChange;
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

            if (_stopWatchResult.Count() < 50) return;

            UpdateRuntime();
        }

        private void UpdateRuntime()
        {
            var time = _stopWatchResult.Sum();
            time = time/_stopWatchResult.Count();
            Runtime = time;
            _stopWatchResult.Clear();
        }

        private void Device_PortBitOutChange(Port port, PortBit portbit) {
            _isDataWrite = true;
        }
    }
}
