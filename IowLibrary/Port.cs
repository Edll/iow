using System;
using System.Collections.Generic;
using Roboter.DllWapper;

namespace Roboter {
    /// <summary>
    /// reports port events
    /// </summary>
    /// <param name="port">this</param>
    public delegate void PortEventHandler(Port port);

    /// <summary>
    /// reports port change events
    /// </summary>
    /// <param name="port">this</param>
    /// <param name="portBit">bit causer</param>
    public delegate void PortChangeEventHandler(Port port, PortBit portBit);


    /// <summary>
    /// Port of a Device
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class Port {
        /// <summary>
        /// reports bit on change event
        /// </summary>
        public event PortChangeEventHandler PortBitInChange;

        /// <summary>
        ///  report bit out change event
        /// </summary>
        public event PortChangeEventHandler PortBitOutChange;


        /// <summary>
        /// offset for the port result list
        /// </summary>
        public const int PortOffset = 1;

        /// <summary>
        /// Init a port an generate bit objects
        /// </summary>
        /// <param name="portNumber">Number of the Port</param>
        public Port(int portNumber) {
            PortNumber = portNumber;
            InitPort();
        }

        /// <summary>
        /// Bits in the Port
        /// </summary>
        public List<PortBit> PortBits { get; set; }

        /// <summary>
        /// Individual port number
        /// </summary>
        public int PortNumber { get; set; }

        /// <summary>
        /// set a bit of this port to the given state
        /// </summary>
        /// <param name="bit">number of the bit</param>
        /// <param name="value">state</param>
        public void SetBit(int bit, bool value) {
            if (PortBits.Count - 1 < bit) return;

            var pb = PortBits[bit];
            pb.BitOut = value;
        }

        /// <summary>
        /// Returns the State of the out bits as Byte
        /// </summary>
        /// <returns>state of out bit as byte</returns>
        public byte GetBitStateAsByte()
        {
            byte portMaskState = 0x00;
            foreach(var bit in PortBits) {
                var value = PortBit.ConvertToInt(bit.BitOut);
                var bitNum = bit.BitNumber;

                portMaskState |= (byte) (value << bitNum);
            }
            return portMaskState;
        }

        /// <summary>
        /// set a byte to in bits
        /// </summary>
        /// <param name="dataIn">byte which will set to bits</param>
        public void SetBitState(byte dataIn) {
            foreach (var bit in PortBits) {
                var mask = (byte)(1 << bit.BitNumber);
                bit.BitIn = ((dataIn & mask) == mask);
            }
        }

        private void InitPort() {
            if (PortBits == null) {
                PortBits = new List<PortBit>();
            }

            for (var i = 0; i < Defines.MaxBitNumber + 1; i++) {
                var bit = new PortBit(i);
                bit.ChangeIn += BitInChange;
                bit.ChangeOut += BitOutChange;
                PortBits.Add(bit);
            }
        }

        private void BitInChange(PortBit portbit) {
            PortBitInChangeEvent(portbit);
        }

        private void BitOutChange(PortBit portbit) {
            PortBitOutChangeEvent(portbit);
        }

        private void PortBitInChangeEvent(PortBit portbit)
        {
            PortBitInChange?.Invoke(this, portbit);
        }

        private void PortBitOutChangeEvent(PortBit portbit)
        {
            PortBitOutChange?.Invoke(this, portbit);
        }
    }
}
