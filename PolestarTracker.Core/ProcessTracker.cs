using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PolestarTracker.Core
{
    public class ProcessTracker
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        /**
         * Original Author: Jorge Ferreira
         * Taken from: https://stackoverflow.com/questions/115868/how-do-i-get-the-title-of-the-current-active-window-using-c
         */
        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static string GetActiveProcessName()
        {
            return null;
        }
    }
}
