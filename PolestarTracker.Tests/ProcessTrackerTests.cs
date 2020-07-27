using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolestarTracker.Core;

namespace PolestarTracker.Tests
{
    [TestClass]
    public class ProcessTrackerTests
    {
        [TestMethod]
        public void GetActiveWindowTitle_Does_Not_Return_Null()
        {
            Assert.IsNotNull(ProcessTracker.GetActiveWindowTitle());
        }

        [TestMethod]
        public void GetActiveProcessName_Does_Not_Return_Null()
        {
            Assert.IsNotNull(ProcessTracker.GetActiveProcessName());
            Console.WriteLine(ProcessTracker.GetActiveProcessName());
        }
    }
}
