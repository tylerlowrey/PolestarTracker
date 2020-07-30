﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace PolestarTracker.Core
{
    /**
     * Adapted from: https://stackoverflow.com/questions/604410/global-keyboard-capture-in-c-sharp-application
     */
    public class KeyboardTracker
    {
        private static readonly Stopwatch KeyPressedStopwatch = new Stopwatch();

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        private static readonly LowLevelKeyboardProc _hookCallback = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public KeyboardTracker()
        {
            _hookID = SetHook(_hookCallback);
            KeyPressedStopwatch.Start();
        }

        ~KeyboardTracker()
        {
            UnhookWindowsHookEx(_hookID);
            KeyPressedStopwatch.Reset();
        }

        public long GetTimeElapsedSinceLastKeyPress() => KeyPressedStopwatch.ElapsedMilliseconds;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                KeyPressedStopwatch.Reset();
                KeyPressedStopwatch.Start();
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

    }
}
