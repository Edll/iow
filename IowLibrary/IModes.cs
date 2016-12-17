using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IowLibary {
    /// <summary>
    /// All function Modes represention by this class.
    /// </summary>
    public interface IModes {
        /// <summary>
        /// Read the current state from the Ports
        /// </summary>
        /// <returns>HashMap with the current port state</returns>
        Dictionary<int, Port> Read();

        /// <summary>
        /// write the current port state to a device
        /// </summary>
        /// <param name="ports"></param>
        /// <returns>true if write was successful</returns>
        bool Write(Dictionary<int, Port> ports);

        /// <summary>
        /// Initialisation for the pictured device mode
        /// </summary>
        /// <returns>tue if initialisation was successful</returns>
        bool PortsInitialisation();

        /// <summary>
        /// Set the device for the datasize an port information to the mode
        /// </summary>
        /// <param name="device"></param>
        void SetDevice(Device device);
    }
}
