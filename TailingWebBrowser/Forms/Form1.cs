using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCatchWin
{
    public partial class Form1 : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        // импорт WinApi функций и констант
        

        private IntPtr appHandle; // Handle окна другого приложения
        public Form1()
        {
            InitializeComponent();

            this.Resize += this.Form1_Resize;

            contextMenuStrip1_Opening(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (appHandle != IntPtr.Zero && !isParented)
            {
                Win32.MoveWindow(appHandle, 0, 0, panel1.Width, panel1.Height, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetParented();
        }

        bool isParented = true;

        private void SetParented()
        {
            if (appHandle == IntPtr.Zero) return;


            if (isParented = !isParented)
            {
                UnParent();
            }
            else
            {
                Win32.SetParent(appHandle, panel1.Handle);
                Win32.SetWindowLong(appHandle, WindowLongFlags.GWL_STYLE, WindowLongFlagsExtend.WS_VISIBLE);
                Win32.MoveWindow(appHandle, 0, 0, panel1.Width, panel1.Height, true);
                Win32.SetActiveWindow(Process.GetCurrentProcess().MainWindowHandle);

            }

        }

        private void UnParent()
        {
            Win32.SetParent(appHandle, IntPtr.Zero);
            int style = Win32.GetWindowLong(appHandle, WindowLongFlags.GWL_STYLE);
            Win32.SetWindowLong(appHandle, WindowLongFlags.GWL_STYLE, style | WindowLongFlagsExtend.WS_OVERLAPPEDWINDOW);
            //Win32.MoveWindow(appHandle, 0, 0, 300, 200, true);

            Win32.SetActiveWindow(Process.GetCurrentProcess().MainWindowHandle);
            this.Text = "Empty";
        }


        IDictionary<string, IntPtr> listProcess;
        List<string> ListProcessWindows()
        {
            listProcess = WindowHandleInfo.GetOpenWindows();
            return listProcess.Keys.OrderBy(c => c).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var key = sender.ToString();

            if (appHandle != IntPtr.Zero && !isParented)
                UnParent();

            appHandle = this.listProcess[key];
            isParented = true;
            this.Text = key;

            SetParented();
        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            if (appHandle != IntPtr.Zero && !isParented)
            {
                Win32.MoveWindow(appHandle, 0, 0, panel1.Width, panel1.Height, true);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            

            EventHandler eventHandler = new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            foreach (var item in ListProcessWindows())
            {
                contextMenuStrip1.Items.Add(item, null, eventHandler);
            }
            //Thread.Sleep(1000);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appHandle != IntPtr.Zero && !isParented)
                UnParent();
        }
    }
}