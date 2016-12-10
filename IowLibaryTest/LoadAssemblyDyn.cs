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
            Assembly actual = load.Load("iowkit.dll");
            Assert.IsNotNull(actual);
        }
    }
}
