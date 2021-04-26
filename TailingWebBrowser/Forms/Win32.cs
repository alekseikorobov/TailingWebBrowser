using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCatchWin
{
    public static class Win32
    {

        //Sets window attributes
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Gets window attributes
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);




        //public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, HandleRef dwNewLong)
        //{
        //    if (IntPtr.Size == 4)
        //    {
        //        return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
        //    }
        //    return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        //}
        [SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable")]
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        [SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist")]
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr")]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, HandleRef dwNewLong);

        //public static IntPtr GetWindowLong(HandleRef hWnd, int nIndex)
        //{
        //    if (IntPtr.Size == 4)
        //    {
        //        return GetWindowLong32(hWnd, nIndex);
        //    }
        //    return GetWindowLongPtr64(hWnd, nIndex);
        //}



        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);


        [DllImport("user32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)] //, CallingConvention = CallingConvention.StdCall
        public static extern long SetWindowLongA(HandleRef hwnd, int nIndex, HandleRef dwNewLong);


        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrA", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long SetWindowLongPtrA(IntPtr hwnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);



        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);






        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn,
            IntPtr lParam);

        static IEnumerable<IntPtr> EnumerateProcessWindowHandles(Process process)
        {
            var handles = new List<IntPtr>();

            foreach (ProcessThread thread in process.Threads)
                EnumThreadWindows(thread.Id,
                    (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

            return handles;
        }


        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SetActiveWindow", CharSet = CharSet.Auto)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);



        #region MyRegion
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        [DllImport("psapi.dll")]
        static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] int nSize);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        public static string GetWindowModuleFileName(IntPtr hWnd)
        {
            uint processId = 0;
            const int nChars = 1024;
            StringBuilder filename = new StringBuilder(nChars);
            GetWindowThreadProcessId(hWnd, out processId);
            IntPtr hProcess = OpenProcess(1040, 0, processId);
            GetModuleFileNameEx(hProcess, IntPtr.Zero, filename, nChars);
            CloseHandle(hProcess);
            return (filename.ToString());
        }


        #endregion

    }

    static class WindowLongFlags
    {
        public static int GWL_EXSTYLE = -20;
        public static int GWLP_HINSTANCE = -6;
        public static int GWLP_HWNDPARENT = -8;
        public static int GWL_ID = -12;
        public static int GWL_STYLE = -16;
        public static int GWL_USERDATA = -21;
        public static int GWL_WNDPROC = -4;
        public static int DWLP_USER = 0x8;
        public static int DWLP_MSGRESULT = 0x0;
        public static int DWLP_DLGPROC = 0x4;
    }
    static class WindowLongFlagsExtend
    {
        public static int GWL_STYLE = -16;
        public static int WS_VISIBLE = 0x10000000;
        public static int WS_EX_NOACTIVATE = 0x08000000;
        public static int WS_CAPTION = 0x00C00000;
        public static int WS_MAXIMIZE = 0x01000000;
        public static int WS_OVERLAPPED = 0x00C00000;
        public static int WS_SYSMENU = 0x00080000;
        public static int WS_THICKFRAME = 0x00040000;
        public static int WS_MINIMIZEBOX = 0x00020000;
        public static int WS_MAXIMIZEBOX = 0x00010000;
        public static int WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
    }
}
