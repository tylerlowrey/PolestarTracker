using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PolestarTracker.Core
{
    /**
     * Adapted from: https://stackoverflow.com/questions/27133957/global-mouse-hook-in-wpf
     */
    class MouseTracker
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

        private int _previousXPos;
        private int _previousYPos;

        public MouseTracker()
        {
            var (x, y) = GetMousePosition();
            _previousXPos = x;
            _previousYPos = y;
        }

        public bool HasMouseMoved()
        {
            var (currentX, currentY) = GetMousePosition();
            return currentX == _previousXPos && currentY == _previousYPos;
        }


        public static (int, int) GetMousePosition()
        {
            Win32Point mousePos = new Win32Point();
            GetCursorPos(ref mousePos);
            return (mousePos.X, mousePos.Y);
        }
    }
}
