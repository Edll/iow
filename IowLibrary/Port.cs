using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IowLibrary {
    public delegate void PortEventHandler(Port port);

    public class Port {
        public event PortEventHandler Error;

        private int portNumber;
        private int bitNumber;
        private List<PortBit> portBits;
        private byte[] data;
        private Device device;
  
        public Port(int bitNumber, Device device) {
            this.bitNumber = bitNumber;
            this.device = device;
            initPort();
        }

        public List<PortBit> PortBits {
            get { return portBits; }
            set { portBits = value; }
        }

        public int PortNumber {
            get { return portNumber; }
            set { portNumber = value; }
        }

        private void initPort() {
            if (portBits == null) {
                portBits = new List<PortBit>();
            }

            for (int i = 0; i < portNumber; i++) {
                PortBit bit = new PortBit(i);
                bit.Change += Bit_Change;
                portBits.Add(bit);
            }
            data = new byte[4];           
        }

        public void ReadIn(int pipeNum) {
            System.Console.WriteLine("ReadIn");
            int? readByts = IowKit.Read(device.Handler, pipeNum, data, device.ReportSize);
            if(readByts == null) {
                errorEvent();
            }
            if(readByts != device.ReportSize) {
                // TODO nicht alle bit eingelesen und nun?
                System.Console.WriteLine("not all read in!");
            }
            foreach(Byte dat in data) {
                System.Console.WriteLine("data: " + dat);
            }
        }

        private void Bit_Change(PortBit portbit) {
            System.Console.WriteLine("port: " + portNumber +
                " bit change: " + portbit.BitNumber +
                " to: " + portbit.BitValue);
        }

        private void errorEvent() {
            if (Error != null) {
                Error(this);
            }
        }
    }
}
