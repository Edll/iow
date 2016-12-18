using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IowLibary.DllWapper;

namespace IowLibary {
    public class LCDMode : IModes {
        private Device _device;

        public Dictionary<int, Port> Read() {
         //   throw new NotImplementedException();
            return _device.Ports;
        }

        public bool Write(Dictionary<int, Port> ports)
        {
            return true;
            // noo
        }

        public bool PortsInitialisation() {

            // alle Bits auf False
            _device.SetAllPortBits(0, false);
            _device.SetAllPortBits(1, false);
            WriteData();
         //   Thread.Sleep(3);


            _device.SetBit(1, 4, true);
            _device.SetBit(1, 5, true);

            _device.SetBit(0, 7, true);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
          //  Thread.Sleep(3);

            _device.SetBit(1, 4, true);
            _device.SetBit(1, 5, true);
            _device.SetBit(0, 7, true);
            WriteData();
         //   Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
         //   Thread.Sleep(3);

            _device.SetBit(1, 4, true);
            _device.SetBit(1, 5, true);
            _device.SetBit(0, 7, true);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetBit(1, 3, true);
            _device.SetBit(1, 4, true);
            _device.SetBit(1, 5, true);
            _device.SetBit(0, 7, true);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
          //  Thread.Sleep(3);


            _device.SetAllPortBits(1, false);
            _device.SetBit(1, 3, true);
            _device.SetBit(0, 7, true);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetAllPortBits(1, false);
            _device.SetBit(1, 0, true);
            _device.SetBit(0, 7, true);
            WriteData();
         //   Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
        //    Thread.Sleep(3);

            _device.SetAllPortBits(1, false);
            _device.SetBit(1, 0, true);
            _device.SetBit(1, 1, true);
            _device.SetBit(1, 2, true);
            _device.SetBit(0, 7, true);
            WriteData();
           // Thread.Sleep(3);

            _device.SetBit(0, 7, false);
            WriteData();
            Thread.Sleep(10);

            _device.SetAllPortBits(0, false);
            _device.SetAllPortBits(1, false);
            WriteData();
            Thread.Sleep(10);

            _device.SetBit(0, 5, true);
            _device.SetBit(1, 0, true);
            _device.SetBit(1, 1, true);
            _device.SetBit(0, 7, true);
            WriteData();
            Thread.Sleep(10);

            _device.SetBit(0, 7, false);
            WriteData();
            Thread.Sleep(10);

            return true;
        }

        /// <summary>
        /// Set device instancen will normaly made from Device on set Mode
        /// </summary>
        /// <param name="device">instance</param>
        public void SetDevice(Device device) {
            _device = device;
        }

       public void SetLine(int p0, string text)
        {
            
        }

        public bool ReadTimeout(int readTimeout) {
            var result = IowKit.Timeout(_device.Handler, readTimeout);
            if (result) { return true; }
            _device.AddDeviceError("Timeout konnte nicht gesetzt werden");
            return false;
        }

        private bool WriteData() {
            var data = new byte[_device.IoReportsSize];
            data[0] = 0x00;
            foreach (var kvp in _device.Ports) {
                var p = kvp.Value;
                data[kvp.Key + Port.PortOffset] = p.GetBitStateAsByte();
            }

            var size = IowKit.Write(_device.Handler, 0, data, _device.IoReportsSize);

            return size != null && size == _device.IoReportsSize;
        }
    }
}
