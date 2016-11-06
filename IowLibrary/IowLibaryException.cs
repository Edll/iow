using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    public class IowLibaryException : Exception {
        public IowLibaryException() {
        }

        public IowLibaryException(String msg) : base(msg) {
        }

        public IowLibaryException(String msg, Exception e) : base(msg, e) {
        }
    }
}
