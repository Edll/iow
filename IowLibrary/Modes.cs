using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roboter {
    /// <summary>
    /// Static representations of the modes
    /// </summary>
    public abstract  class Modes
    {
        /// <summary>
        /// I/O mode for ports
        /// </summary>
        public const int IoMode = 0;

        /// <summary>
        /// LCD mode for HD47880 LCD drivers
        /// </summary>
        public const int LcdMode = 1;
    }
}
