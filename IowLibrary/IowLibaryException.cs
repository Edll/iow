using System;

namespace IowLibrary {
    public class IowLibaryException : Exception {
        public IowLibaryException() {
        }

        public IowLibaryException(string msg) : base(msg) {
        }

        public IowLibaryException(string msg, Exception e) : base(msg, e) {
        }
    }
}
