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
        private List<PortBit> portBits;
        private byte[] data;
        private Device device;

        public Port(int portNumber, Device device) {
            this.portNumber = portNumber;
            this.device = device;
            initPort();
        }

        public List<PortBit> PortBits {
            get { return portBits; }
            set { portBits = value; }
        }

        public int PortNumber {
            get { return portNumber; }
            set {
                Console.WriteLine("set port:" + value);
                portNumber = value;
            }
        }

        private void initPort() {
            if (portBits == null) {
                portBits = new List<PortBit>();
            }

            for (int i = 0; i < PortBit.maxBitNumber + 1; i++) {
                PortBit bit = new PortBit(i);
                bit.ChangeIn += BitInChange;
                bit.ChangeOut += BitOutChange;
                portBits.Add(bit);
            }
            data = new byte[4];
        }

        private void BitInChange(PortBit portbit) {
            System.Console.WriteLine("port: " + portNumber +
                " bit IN change: " + portbit.BitNumber +
                " to: " + portbit.BitIn);
        }

        private void BitOutChange(PortBit portbit) {
            System.Console.WriteLine("port: " + portNumber +
                " bit OUT change: " + portbit.BitNumber +
                " to: " + portbit.BitOut);
        }

        private void errorEvent() {
            if (Error != null) {
                Error(this);
            }
        }

        public void SetInputData(byte dataIn) {
            foreach (PortBit bit in portBits) {
                byte mask = (byte)(1 << bit.BitNumber);
                 bit.BitIn = ((dataIn & mask) == mask);
            }
        }
    }
}
