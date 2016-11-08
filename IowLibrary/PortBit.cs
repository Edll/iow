using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    public delegate void PortBitChangeEventHandler(PortBit portbit);

    public class PortBit {
        public event PortBitChangeEventHandler Change;

        public const int maxBitNumber = 7;
        private int bitNumber = 0;
        private bool bitValue = false;

        public PortBit(int bitNumber) {
            this.bitNumber = bitNumber;
        }

        public bool BitValue {
            get { return bitValue; }
            set { bitValue = value;
                changeEvent();
            }
        }

        public int BitNumber {
            get { return bitNumber; }
            set {
                if (value < maxBitNumber) {
                    throw new IndexOutOfRangeException("Max Bitnumber is: " + maxBitNumber + " given was: " + value);
                }
                bitNumber = value;
            }
        }

        private void changeEvent() {
            if(Change != null) {
                Change(this);
            }
        }

    }
}
