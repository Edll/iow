using System;
using System.Reflection;
using IowLibary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IowLibaryTest {
    [TestClass]
    public class LoadAssemblyDynTest {


        [TestMethod]
        public void LoadTest() {
            LoadAssemblyDyn load = new LoadAssemblyDyn();
            var actual = load.Load<Delegate>("iowkit.dll" , "IowKitOpenDevice");
            Assert.AreEqual(actual, 0);
        }
    }
}
