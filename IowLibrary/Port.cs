using System;
using System.Collections.Generic;

namespace IowLibrary {
    public delegate void PortEventHandler(Port port);
    public delegate void PortChangeEventHandler(Port port, PortBit portBit);

    public class Port {
        public event PortChangeEventHandler PortBitInChange;
        public event PortChangeEventHandler PortBitOutChange;

        public const int PortOffset = 1;

        private int _portNumber;
        private List<PortBit> _portBits;

        public Port(int portNumber) {
            _portNumber = portNumber;
            InitPort();
        }

        public List<PortBit> PortBits {
            get { return _portBits; }
            set { _portBits = value; }
        }

        public int PortNumber {
            get { return _portNumber; }
            set {
                _portNumber = value;
            }
        }

        public void SetBit(int bit, bool value) {
            if (_portBits.Count - 1 >= bit) {
                var pb = _portBits[bit];
                pb.BitOut = value;
            } 

        }

        public byte GetBitStateAsByte() {
            byte portState = 0xff;
            foreach(var bit in _portBits) {
                var value = PortBit.ConvertToInt(bit.BitOut);
                var bitNum = bit.BitNumber;

                portState &= (byte) ~(value << bitNum);
            }
            return portState;
        }

        private void InitPort() {
            if (_portBits == null) {
                _portBits = new List<PortBit>();
            }

            for (var i = 0; i < PortBit.MaxBitNumber + 1; i++) {
                var bit = new PortBit(i);
                bit.ChangeIn += BitInChange;
                bit.ChangeOut += BitOutChange;
                _portBits.Add(bit);
            }
        }

        private void BitInChange(PortBit portbit) {
            PortBitInChangeEvent(portbit);
        }

        private void BitOutChange(PortBit portbit) {
            PortBitOutChangeEvent(portbit);
        }

        private void PortBitInChangeEvent(PortBit portbit) {
            if (PortBitInChange != null) {
                PortBitInChange(this, portbit);
            }
        }

        private void PortBitOutChangeEvent(PortBit portbit) {
            if (PortBitOutChange != null) {
                PortBitOutChange(this, portbit);
            }
        }

        public void SetInputData(byte dataIn) {
            foreach (var bit in _portBits) {
                var mask = (byte)(1 << bit.BitNumber);
                bit.BitIn = ((dataIn & mask) == mask);
            }
        }
    }
}
