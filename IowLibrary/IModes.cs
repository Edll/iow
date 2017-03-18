using System.Collections.Generic;

namespace Roboter {
    /// <summary>
    /// All function Modes represention by this class.
    /// 
    /// To Create own Modes only impliements this interface in your class. Then wenn you 
    /// set a Device in RunMode use your instance as mode parameter
    /// </summary>
    public interface IModes {

        /// <summary>
        /// Initialisation for the pictured device mode
        /// </summary>
        /// <returns>tue if initialisation was successful</returns>
        bool PortsInitialisation();

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
        /// Set the device for the datasize an port information to the mode
        /// </summary>
        /// <param name="device"></param>
        void SetDevice(Device device);

        /// <summary>
        /// set the Readtimeout to the Device
        /// </summary>
        /// <param name="readTimeout">Read Timeout in Ms</param>
        /// <returns>Set the ReadTimeout to the Device</returns>
        bool ReadTimeout(int readTimeout);
    }
}
