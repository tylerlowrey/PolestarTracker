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
            MouseTracker mouseTracker = new MouseTracker(-100000, 0);
            var (currentX, _) = MouseTracker.GetMousePosition();
            Console.WriteLine(currentX);
            Assert.IsFalse(mouseTracker.PreviousXPos > currentX);
        }

        [TestMethod]
        public void MousePosition_Returns_Sensible_Y_Value()
        {
            MouseTracker mouseTracker = new MouseTracker(0, -100000);
            var (_, currentY) = MouseTracker.GetMousePosition();
            Console.WriteLine(currentY);
            Assert.IsFalse(mouseTracker.PreviousYPos > currentY);
        }
    }
}
