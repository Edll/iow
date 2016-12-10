using System;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// Bit change event delegater
    /// </summary>
    /// <param name="portbit"></param>
    public delegate void PortBitChangeEventHandler(PortBit portbit);

    /// <summary>
    /// Bit of a Port
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class PortBit {
        /// <summary>
        /// reports output bit changes
        /// </summary>
        public event PortBitChangeEventHandler ChangeOut;

        /// <summary>
        /// report input bit changes
        /// </summary>
        public event PortBitChangeEventHandler ChangeIn;


        private int _bitNumber;
        private bool _bitOut;
        private bool _bitIn;

        /// <summary>
        /// instance of new bitNumber
        /// </summary>
        /// <param name="bitNumber">bit number</param>
        public PortBit(int bitNumber) {
            _bitNumber = bitNumber;
        }

        /// <summary>
        /// Output Bit
        /// </summary>
        public bool BitOut {
            get { return _bitOut; }
            set {
                if (_bitOut == value) { return; }
                _bitOut = value;
                ChangeOutEvent();
            }
        }

        /// <summary>
        /// Input Bit
        /// </summary>
        public bool BitIn {
            get { return _bitIn; }
            set {
                if (_bitIn == value) return;

                _bitIn = value;
                ChangeInEvent();
            }
        }

        /// <summary>
        /// Bit Number
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">if number is greater than MaxBitNumber</exception>
        public int BitNumber {
            get { return _bitNumber; }
            set {
                if (value < Defines.MaxBitNumber) {
                    throw new IndexOutOfRangeException("Max Bitnumber is: " + Defines.MaxBitNumber + " given was: " + value);
                }
                _bitNumber = value;
            }
        }

        /// <summary>
        /// Converts boolean to int true = 1 false = 0
        /// </summary>
        /// <param name="value">true or false</param>
        /// <returns>1 or 0</returns>
        public static int ConvertToInt(bool value) {
            return value ? 1 : 0;
        }

        private void ChangeOutEvent() {
            ChangeOut?.Invoke(this);
        }

        private void ChangeInEvent() {
            ChangeIn?.Invoke(this);
        }

    

    }
}
