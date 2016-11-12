using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IowLibrary {
    public delegate void PortEventHandler(Port port);
    public delegate void PortChangeEventHandler(Port port, PortBit portBit);

    public class Port {
        public event PortEventHandler Error;
        public event PortChangeEventHandler PortBitInChange;

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

        public void SetBit(int bit, bool value) {
            if (portBits.Count - 1 >= bit) {
                PortBit pb = portBits[bit];
                pb.BitOut = value;
            } else {
                Console.WriteLine("try to write bit out of size!");
            }

        }

        private void initPort() {
            if (portBits == null) {
                portBits = new List<PortBit>();
            }

            for (int i = 0; i < PortBit.maxBitNumber + 1; i++) {
                PortBit bit = new PortBit(i);
                bit.ChangeIn += bitInChange;
                bit.ChangeOut += bitOutChange;
                portBits.Add(bit);
            }
            data = new byte[4];
        }

        private void bitInChange(PortBit portbit) {
            portBitInChangeEvent(portbit);
            System.Console.WriteLine("port: " + portNumber +
                " bit IN change: " + portbit.BitNumber +
                " to: " + portbit.BitIn);
        }

        private void bitOutChange(PortBit portbit) {
          // TODO nach oben weiter geben!!!
            System.Console.WriteLine("port: " + portNumber +
                " bit OUT change: " + portbit.BitNumber +
                " to: " + portbit.BitOut);
        }

        private void portBitInChangeEvent(PortBit portbit) {
            if (PortBitInChange != null) {
                PortBitInChange(this, portbit);
            }
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
