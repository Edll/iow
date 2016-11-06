using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    public class PortBit {
        public const int maxBitNumber = 7;
        private int bitNumber = 0;
        private bool bitValue = false;

        public bool BitValue {
            get { return bitValue; }
            set { bitValue = value; }
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

    }
}
