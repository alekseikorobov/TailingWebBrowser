using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailingWebBrowser
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    namespace HookKeybordApp
    {
        public class HookKeybordHelper
        {

            private const int WH_KEYBOARD_LL = 13;
            public static LowLevelKeyboardProcDelegate m_callback = null;
            public IntPtr m_hHook;
            private TailingWindow tailingWindow;

            public HookKeybordHelper(TailingWindow tailingWindow)
            {
                this.tailingWindow = tailingWindow;
            }

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(
                int idHook,
                LowLevelKeyboardProcDelegate lpfn,
                IntPtr hMod, int dwThreadId);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("Kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr CallNextHookEx(
                IntPtr hhk,
                int nCode, IntPtr wParam, IntPtr lParam);

            private IntPtr LowLevelKeyboardHookProc(
                int nCode, IntPtr wParam, IntPtr lParam)
            {
                try
                {
                    if (nCode < 0)
                    {
                        return CallNextHookEx(m_hHook, nCode, wParam, lParam);
                    }
                    else
                    {
                        if (!tailingWindow.IsActive)
                            return CallNextHookEx(m_hHook, nCode, wParam, lParam);
                        var khs = (KeyboardHookStruct)
                                  Marshal.PtrToStructure(lParam,
                                  typeof(KeyboardHookStruct));

                        //if(khs.Flags != 128)
                        //  return CallNextHookEx(m_hHook, nCode, wParam, lParam);

                        Debug.Print(
                            $"Hook: VirtualKeyCode - {khs.VirtualKeyCode}, WParam - {wParam},ScanCode - {khs.ScanCode}, Code: {nCode},{lParam} {khs.Flags}, {khs.Time}");

                        //Debug.Print(khs.VirtualKeyCode.ToString());

                        if (khs.VirtualKeyCode == 68 &&
                            wParam.ToInt32() == 260 &&
                            khs.ScanCode == 32) //alt+D
                        {
                            tailingWindow.WindowScreenshotWithoutClass();
                            System.Console.WriteLine("Alt+D pressed!");
                            IntPtr val = new IntPtr(1);
                            return val;
                        }

                        return CallNextHookEx(m_hHook, nCode, wParam, lParam);

                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct KeyboardHookStruct
            {
                public readonly int VirtualKeyCode;
                public readonly int ScanCode;
                public readonly int Flags;
                public readonly int Time;
                public readonly IntPtr ExtraInfo;
            }
            public delegate IntPtr LowLevelKeyboardProcDelegate(
                int nCode, IntPtr wParam, IntPtr lParam);
            public void SetHook()
            {
                m_callback = new LowLevelKeyboardProcDelegate(LowLevelKeyboardHookProc);
                m_hHook = SetWindowsHookEx(WH_KEYBOARD_LL, m_callback, GetModuleHandle(IntPtr.Zero), 0);

                GC.KeepAlive(m_callback);
            }
            public void Unhook()
            {
                UnhookWindowsHookEx(m_hHook);
            }
        }
    }
}
