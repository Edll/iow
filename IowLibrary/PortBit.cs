using System;

namespace IowLibrary {
    public delegate void PortBitChangeEventHandler(PortBit portbit);

    public class PortBit {
        public event PortBitChangeEventHandler ChangeOut;
        public event PortBitChangeEventHandler ChangeIn;

        public const int MaxBitNumber = 7;
        private int _bitNumber;
        private bool _bitOut;
        private bool _bitIn;

        public PortBit(int bitNumber) {
            _bitNumber = bitNumber;
        }

        public bool BitOut {
            get { return _bitOut; }
            set {
                if (_bitOut == value) { return;}
                _bitOut = value;
                ChangeOutEvent();
            }
        }

        public bool BitIn {
            get { return _bitIn; }
            set { 
                if (_bitIn != value) {
                    _bitIn = value;
                    ChangeInEvent();
                }

            }
        }

        public int BitNumber {
            get { return _bitNumber; }
            set {
                if (value < MaxBitNumber) {
                    throw new IndexOutOfRangeException("Max Bitnumber is: " + MaxBitNumber + " given was: " + value);
                }
                _bitNumber = value;
            }
        }

        private void ChangeOutEvent()
        {
            ChangeOut?.Invoke(this);
        }

        private void ChangeInEvent()
        {
            ChangeIn?.Invoke(this);
        }

        public static int ConvertToInt(bool value)
        {
            return value ? 1 : 0;
        }

    }
}
