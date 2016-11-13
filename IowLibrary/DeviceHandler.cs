using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IowLibrary {
    public class DeviceHandler {
        private volatile bool stopHandler = false;
        private Device device;
        private int numPipe = 0;
        private bool isDataWrite;

        public DeviceHandler(Device device) {
            this.device = device;
            device.PortBitOutChange += Device_PortBitOutChange;
        }

        private void Device_PortBitOutChange(Port port, PortBit portbit) {
            isDataWrite = true;
        }

        public Device Device {
            get { return device; }
            set { device = value; }
        }

        public void IO() {
            stopHandler = false;
            device.InitPorts(numPipe);

               device.SetReadTimeout(100);
     
            while (!stopHandler) {
                if (isDataWrite) {
                   bool ok = device.WritePortStateToDevice();
                    if (ok) {
                        isDataWrite = false;
                    }
                } 
                    device.ReadPortState(numPipe);
                
            }
        }

        public void RequestStop() {
            stopHandler = true;
        }

    }
}
