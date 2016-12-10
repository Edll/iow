using System;

namespace IowLibary {
    /// <summary>
    /// Exception Wapper
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class IowLibaryException : Exception {
        /// <summary>
        /// IowLibary Exception
        /// </summary>
        public IowLibaryException() {
        }

        /// <summary>
        /// IowLibary Exception
        /// </summary>
        /// <param name="msg">string msg</param>
        public IowLibaryException(string msg) : base(msg) {
        }

        /// <summary>
        /// IowLibary Exception
        /// </summary>
        /// <param name="msg">string msg</param>
        /// <param name="e">exception to warp</param>
        public IowLibaryException(string msg, Exception e) : base(msg, e) {
        }
    }
}
