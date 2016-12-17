using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using IowLibary.DllWapper;

namespace IowLibary {
    /// <summary>
    /// Loads the iowdll dynamical, this allows us to give feedback for the installation of the dll.
    /// D
    /// FIXME: Das geht nicht. Weil IOW DLL keine .net anwendung ist 
    /// sonder c++ und mit marsheling eingebunden wird.
    /// </summary>
    public class  LoadAssemblyDyn {
        // das kann man sicher auch als programm einstellung machen...
        private const string DefaultAssemblyFileName = "iowkit.dll";

        private delegate IntPtr OpenDele();
        private object MessageBox;


        /// <summary>
        /// Loads an assembly from the system  by the given  name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Load<T>(string name, string functionName) {
            var baseDir = Thread.GetDomain().BaseDirectory;
            var hModule = FunctionLoader.LoadLibrary(baseDir + "\\" + name);

            var functionAddress = FunctionLoader.GetProcAddress(hModule, functionName);
            try
            {
                var deleg = Marshal.GetDelegateForFunctionPointer(functionAddress, typeof(OpenDele));
                MethodInfo meth = deleg.Method;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                string bla = "bla";
            }
            // Load functions and set them up as delegates
            // This is just an example - you could load the .dll from any path,
            // and you could even determine the file location at runtime.



       //     MessageBox = (OpenDele)
          //  FunctionLoader.LoadFunction<OpenDele>("iowkit.dll", "IowKitOpenDevice");


            return null;
        }

    }

    class FunctionLoader {
        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibrary(string path);

        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        //    public static Delegate LoadFunction<T>(string dllPath, string functionName) {

        //    }
    }
}
