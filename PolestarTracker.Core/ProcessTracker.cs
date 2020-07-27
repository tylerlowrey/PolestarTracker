using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace PolestarTracker.Core
{
    public class ProcessTracker
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        public static string GetActiveWindowTitle()
        {
            return GetActiveProcess().MainWindowTitle;
        }

        /**
         * Adapted from: https://stackoverflow.com/questions/17345202/get-the-current-active-application-name
         */
        public static string GetActiveProcessName()
        {
            return GetActiveProcess().ProcessName;
        }

        /**
         * Adapted from: https://stackoverflow.com/questions/17345202/get-the-current-active-application-name
         */
        public static Process GetActiveProcess()
        {
            IntPtr windowHandle = GetForegroundWindow();
            uint pid = 0;
            GetWindowThreadProcessId(windowHandle, out pid);
            Process proc = Process.GetProcessById((int) pid);
            return proc;
        }
    }
}
