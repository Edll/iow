using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary
{
   public class Port
    {
        private int portNumber;
        private List<PortBit> portBits;

        public List<PortBit> PortBits
        {
            get { return portBits; }
            set { portBits = value; }
        }

        public int PortNumber
        {
            get { return portNumber; }
            set { portNumber = value; }
        }

    }
}
