using System;

namespace IowLibrary {
    /// <summary>
    /// Exception Wapper
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class IowLibaryException : Exception {
        public IowLibaryException() {
        }

        public IowLibaryException(string msg) : base(msg) {
        }

        public IowLibaryException(string msg, Exception e) : base(msg, e) {
        }
    }
}
