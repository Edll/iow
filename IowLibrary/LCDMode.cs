using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// LCDMode representation for LCD Mode current Only for KSO076B Driver
    /// </summary>
    public class LCDMode : IModes {
        private Device _device;
        private Dictionary<int, string> _lineTexts = new Dictionary<int, string>();
        private bool _newText;

        /// <summary>
        /// Initialisation for KSO076B LCD Drive
        /// </summary>
        /// <returns>true on success</returns>
        public bool PortsInitialisation() {
            //TODO: timing... da aber der iow eh nicht schneller als 3ms 
            // die ausgänge schalten kann im IO ist das nicht so wichtig und 
            // kann auf später geschoben werden. Solange reicht auch Threadsleep 
            // auch wenn Windows das nicht genau nimmt.

            // Datenblatt Seite 6

            // alle Bits auf False
            _device.SetAllPortBits(0, false);
            _device.SetAllPortBits(1, false);
            WriteDataToLcd();

            //15 ms wait for rais VDD
            Thread.Sleep(15);

            // db4 and db5 to 1 must be send 3 times
            _device.SetBit(1, 4, true);
            _device.SetBit(1, 5, true);
            SendEnablePulse();

            // Wating time from datasheet 4.1ms
            Thread.Sleep(5);
            SendEnablePulse();

            // Wating time from datasheet 100µs
            Thread.Sleep(1);
            SendEnablePulse();

            // send 3 times ending

            // Setup display functions
            _device.SetAllPortBits(1, false);
            // 2 Lines
            _device.SetBit(1, 3, true);
            // 8 bit mode
            _device.SetBit(1, 4, true);
            // Set Function
            _device.SetBit(1, 5, true);

            SendEnablePulse();

            // Display ON/OFF
            _device.SetAllPortBits(1, false);
            _device.SetBit(1, 3, true);
            // Display on/off
            _device.SetBit(1, 2, true);
            // curser on/off
            _device.SetBit(1, 1, true);
            // blinking on/off
            _device.SetBit(1, 0, false);
            // Wating time from datasheet 42µs
            SendEnablePulse();

            // Display Clear
            _device.SetAllPortBits(1, false);
            _device.SetBit(1, 0, true);
            SendEnablePulse();
            // Wating time from datasheet 1.64ms
            Thread.Sleep(2);

            // Entry Mode Set
            _device.SetAllPortBits(1, false);
            _device.SetBit(1, 2, true);
            // Increase 1 / Decrease 0
            _device.SetBit(1, 1, true);
            // Shift = 1 not shift = 0
            _device.SetBit(1, 1, true); // steht auf 1 sonst geht das schreiben nicht... wieso?
            SendEnablePulse();
            // Wating time from datasheet 42µs

            // inialization end

            // Reset Ports
            _device.SetAllPortBits(0, false);
            _device.SetAllPortBits(1, false);
            WriteDataToLcd();
            return true;
        }

        /// <summary>
        /// Write methode will call, if device register a 
        /// port change on a cycel or TriggerWriteData() is called on the Device. 
        /// </summary>
        /// <param name="ports">Data from the Ports to Write, could be ignore on other modes then IO</param>
        /// <returns>true on successe if we retrun true ThreadHandler will not call on net cycle</returns>
        public bool Write(Dictionary<int, Port> ports) {
            if (_newText) {
                WriteText();
                _newText = false;
            }
            return true;
        }

        private bool WriteText() {
            if (_lineTexts.Count != 0) {
                foreach (var line in _lineTexts) {
                    if (line.Key == 1) {
                        // Reset Curser
                        _device.SetAllPortBits(0, false);
                        _device.SetAllPortBits(1, false);
                        _device.SetBit(1, 1, true);
                        SendEnablePulse();
                    } else if (line.Key == 2) {
                        // Reset Curser line 2
                        _device.SetAllPortBits(0, false);
                        _device.SetAllPortBits(1, false);
                        _device.SetBit(1, 6, true);
                        _device.SetBit(1, 7, true);
                        SendEnablePulse();
                    }

                    _device.SetAllPortBits(0, false);

                    // RS to high
                    _device.SetBit(0, 5, true);

                    foreach (Char _char in line.Value) {
                        SendCharToLcd(_char);
                    }
                }


            }
            return true;
        }

        /// <summary>
        /// Current not in use
        /// </summary>
        /// <returns>device port list</returns>
        public Dictionary<int, Port> Read() {
            return _device.Ports;
        }

        /// <summary>
        /// Set device instancen will normaly made from Device on set Mode
        /// </summary>
        /// <param name="device">instance</param>
        public void SetDevice(Device device) {
            _device = device;
        }

        /// <summary>
        /// Sets the Line to the LCD
        /// </summary>
        /// <param name="lineNumber">linenumber to set</param>
        /// <param name="text">Text to set</param>
        public void SetLine(int lineNumber, string text) {
            if (_lineTexts.ContainsKey(lineNumber)) {
                _lineTexts.Remove(lineNumber);
            }
            _lineTexts.Add(lineNumber, text);
            _newText = true;
            _device.TriggerDataWrite();
        }

        // converts char to Byte an send Data to LCD
        private void SendCharToLcd(char _char) {
            _device.SetAllPortBits(1, false);
            byte _charByte = Convert.ToByte(_char);
            int bitSize = Defines.MaxBitNumber;
            for (int bit = 0; bit <= bitSize; bit++) {
                var mask = (byte)(1 << bit);
                _device.SetBit(1, bit, ((_charByte & mask) == mask));
            }
            SendEnablePulse();
        }

        /// <summary>
        /// Set the ReadTimeout for the Read in Function of iowkit.dll
        /// </summary>
        /// <param name="readTimeout">timeout in ms</param>
        /// <returns>true on success</returns>
        public bool ReadTimeout(int readTimeout) {
            var result = IowKit.Timeout(_device.Handler, readTimeout);
            if (result) { return true; }
            _device.AddDeviceError("Timeout konnte nicht gesetzt werden");
            return false;
        }

        // writes Data from Ports to the LCD
        private bool WriteDataToLcd() {
            var data = new byte[_device.IoReportsSize];
            data[0] = 0x00;
            foreach (var kvp in _device.Ports) {
                var p = kvp.Value;
                data[kvp.Key + Port.PortOffset] = p.GetBitStateAsByte();
            }

            var size = IowKit.Write(_device.Handler, 0, data, _device.IoReportsSize);

            return size != null && size == _device.IoReportsSize;
        }

        private void SendEnablePulse() {
            // E to 1
            _device.SetBit(0, 7, true);
            WriteDataToLcd();
            // Wating time for signal rais/fall
            Thread.Sleep(1);
            // E to 0
            _device.SetBit(0, 7, false);
            WriteDataToLcd();
        }
    }
}
