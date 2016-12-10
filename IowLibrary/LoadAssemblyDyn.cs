using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IowLibary {
    /// <summary>
    /// Loads the iowdll dynamical, this allows us to give feedback for the installation of the dll.
    /// </summary>
    public class LoadAssemblyDyn {

        // das kann man sicher auch als programm einstellung machen...
        private const string DefaultAssemblyFileName = "iowkit.dll";

        private Assembly _assembly;

        /// <summary>
        /// Loads an assembly from the system  by the given  name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Assembly Load(string name) {
           
                _assembly = Assembly.Load(name);
        
            return _assembly;
        }
    }
}
