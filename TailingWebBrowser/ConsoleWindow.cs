using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TailingWebBrowser
{
    public partial class ConsoleWindow : Form
    {
        //public Action Add;
        //public event Action Add;
        public ConsoleWindow()
        {
            InitializeComponent();
        }

        public void ShowConsole()
        {
            richTextBox1.Clear();
            foreach (var item in listMessage)
            {
                ShowConsoleLine(item);
            }
        }
        internal void ShowConsoleLine(ConsoleMessageEventArgs e)
        {
            
            Color c = Color.Black;
            switch (e.Level)
            {
                case LogSeverity.Default:
                    break;
                case LogSeverity.Verbose:
                    break;
                case LogSeverity.Info:
                    break;
                case LogSeverity.Warning:
                    c = Color.Yellow;
                    break;
                case LogSeverity.Error:
                case LogSeverity.Fatal:
                    c = Color.Red;
                    break;
                case LogSeverity.Disable:
                    break;
                default:
                    break;
            }

            richTextBox1.AppendText(e.Message, c, true);
        }
        List<ConsoleMessageEventArgs> listMessage = new List<ConsoleMessageEventArgs>();
        internal void AddMessage(ConsoleMessageEventArgs e)
        {
            listMessage.Add(e);
        }

        private void ConsoleWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            //WindowState = FormWindowState.Minimized;
        }

        private void ConsoleWindow_Shown(object sender, EventArgs e)
        {}
    }
}
