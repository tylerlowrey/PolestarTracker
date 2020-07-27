using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolestarTracker.Core;

namespace PolestarTracker.Tests
{
    [TestClass]
    public class WindowTrackerTests
    {
        [TestMethod]
        public void GetActiveWindowTitle_Does_Not_Return_Null()
        {
            Assert.IsNotNull(WindowTracker.GetActiveWindowTitle());
        }
    }
}
