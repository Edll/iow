using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    class PortHandler {
        private volatile bool stopHandler = false;
        private Port port;
        private int numPipe = 0;

        public PortHandler(Port port) {
            this.port = port;
        }
        public Port Port {
            get { return port; }
            set { port = value; }
        }

        public void IO() {
            while (!stopHandler) {
                port.ReadIn(numPipe);
            }
        }

        public void RequestStop() {
            stopHandler = true;
        }

    }
}
