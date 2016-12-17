using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibary {
    class LCDMode : IModes {

        public Dictionary<int, Port> Read()
        {
            throw new NotImplementedException();
        }

        public bool Write(Dictionary<int, Port> ports)
        {
            throw new NotImplementedException();
        }

        public bool PortsInitialisation()
        {
            throw new NotImplementedException();
        }

        public void SetDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public bool ReadTimeout(int readTimeout)
        {
            throw new NotImplementedException();
        }
    }
}
