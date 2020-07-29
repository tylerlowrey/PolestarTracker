using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolestarTracker.Core;

namespace PolestarTracker.Tests.Core
{
    [TestClass]
    public class MouseTrackerTests
    {
        [TestMethod]
        public void MousePosition_Returns_Sensible_X_Value()
        {
            int BAD_X_VALUE = 100000;
            MouseTracker mouseTracker = new MouseTracker(-BAD_X_VALUE, 0);
            var (currentX, _) = MouseTracker.GetMousePosition();
            Console.WriteLine(currentX);
            Assert.IsFalse(mouseTracker.PreviousXPos > currentX);
            Assert.IsFalse(BAD_X_VALUE < mouseTracker.PreviousXPos);
        }

        [TestMethod]
        public void MousePosition_Returns_Sensible_Y_Value()
        {
            int BAD_Y_VALUE = 100000;
            MouseTracker mouseTracker = new MouseTracker(0, -BAD_Y_VALUE);
            var (_, currentY) = MouseTracker.GetMousePosition();
            Console.WriteLine(currentY);
            Assert.IsFalse(mouseTracker.PreviousYPos > currentY);
            Assert.IsFalse(BAD_Y_VALUE < mouseTracker.PreviousYPos);
        }
    }
}
