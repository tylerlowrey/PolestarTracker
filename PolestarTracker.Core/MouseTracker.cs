using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PolestarTracker.Core
{
    /**
     * Adapted from: https://stackoverflow.com/questions/27133957/global-mouse-hook-in-wpf
     */
    public class MouseTracker
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        public int PreviousXPos { get; }
        public int PreviousYPos { get; }

        public MouseTracker()
        {
            var (x, y) = GetMousePosition();
            PreviousXPos = x;
            PreviousYPos = y;
        }

        public MouseTracker(int startingX, int startingY)
        {
            PreviousXPos = startingX;
            PreviousYPos = startingY;
        }

        public bool HasMouseMoved()
        {
            var (currentX, currentY) = GetMousePosition();
            return currentX == PreviousXPos && currentY == PreviousYPos;
        }


        public static (int, int) GetMousePosition()
        {
            Win32Point mousePos = new Win32Point();
            GetCursorPos(ref mousePos);
            return (mousePos.X, mousePos.Y);
        }
    }
}
