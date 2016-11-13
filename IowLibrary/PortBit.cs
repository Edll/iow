using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    public delegate void PortBitChangeEventHandler(PortBit portbit);

    public class PortBit {
        public event PortBitChangeEventHandler ChangeOut;
        public event PortBitChangeEventHandler ChangeIn;

        public const int maxBitNumber = 7;
        private int bitNumber = 0;
        private bool bitOut = false;
        private bool bitIn = false;

        public PortBit(int bitNumber) {
            this.bitNumber = bitNumber;
        }

        public bool BitOut {
            get { return bitOut; }
            set {
                if (bitOut != value) {
                    bitOut = value;
                    changeOutEvent();
                }
            }
        }

        public bool BitIn {
            get { return bitIn; }
            set { 
                if (bitIn != value) {
                    bitIn = value;
                    changeInEvent();
                }

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

        private void changeOutEvent() {
            if (ChangeOut != null) {
                ChangeOut(this);
            }
        }

        private void changeInEvent() {
            if (ChangeIn != null) {
                ChangeIn(this);
            }
        }

        public static int ConvertToInt(bool value) {
            if (value) {
                return 1;
            }else {
                return 0;
            }
        }

    }
}
