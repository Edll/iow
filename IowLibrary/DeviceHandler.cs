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

        public DeviceHandler(Device device) {
            this.device = device;
        }
        public Device Device {
            get { return device; }
            set { device = value; }
        }

        public void IO() {
            device.InitPorts(numPipe);

               device.SetReadTimeout(100);
     
            while (!stopHandler) {
                device.IO(numPipe);
       
            }
        }

        public void RequestStop() {
            stopHandler = true;
        }

    }
}
