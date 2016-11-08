using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            while (!stopHandler) {
                device.IO(0);
            }
        }

        public void RequestStop() {
            stopHandler = true;
        }

    }
}
