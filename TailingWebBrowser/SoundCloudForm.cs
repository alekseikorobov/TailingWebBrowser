using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace TailingWebBrowser
{
    public partial class SoundCloudForm : Form
    {
        public ChromiumWebBrowser chromiumWebBrowser;
        public SoundCloudForm()
        {
            InitializeComponent();

            InitializeChromium();
            chromiumWebBrowser.IsBrowserInitializedChanged += this.ChromiumWebBrowser_IsBrowserInitializedChanged;

            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void ChromiumWebBrowser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (args.IsBrowserInitialized)
            {
                //chromiumWebBrowser.ExecuteScriptAsync("document.querySelector('.g-opacity-transition').click()");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void InitializeChromium()
        {
            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";

            Cef.Initialize(cefSettings);
            var address = "https://soundcloud.com/discover";
            chromiumWebBrowser = new ChromiumWebBrowser(address);
            panel1.Controls.Add(chromiumWebBrowser);

            chromiumWebBrowser.Dock = DockStyle.Fill;

            chromiumWebBrowser.ConsoleMessage += this.ChromiumWebBrowser_ConsoleMessage;
        }

        private void ChromiumWebBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            cw.AddMessage(e);
        }
        bool isClosing = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                this.Hide();
                WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
            }
            else
            {
                Cef.Shutdown();
            }
        }

        private void вызовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chromiumWebBrowser.ExecuteScriptAsync("document.querySelector('.playControl.sc-ir.playControls__control.playControls__play').click()");
        }



        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {

        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("document.querySelector('.playControls__play').focus();");
            sb.AppendLine("document.querySelector('.playControls__play').click();");
            chromiumWebBrowser.ExecuteScriptAsyncWhenPageLoaded(sb.ToString());

            //ClickCss(".playControls__play");
        }


        public void ClickCss(string css)
        {
            var js = "document.querySelector('" + css + "').click()";

            EvaluateJavascript(js);
        }


        public async Task EvaluateJavascript(string script)
        {
            JavascriptResponse javascriptResponse = await chromiumWebBrowser.GetMainFrame().EvaluateScriptAsync(script);

            if (!javascriptResponse.Success)
            {

                //throw new JavascriptException(javascriptResponse.Message);
            }
        }

        private void следующаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.ExecuteScriptAsyncWhenPageLoaded("document.querySelector('.skipControl__next').click();");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClosing = true;
            Application.Exit();
            OnClosed(e);
        }

        private void следующаяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.ExecuteScriptAsyncWhenPageLoaded("document.querySelector('.skipControl__next').click();");
        }

        private void стартстопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.ExecuteScriptAsyncWhenPageLoaded("document.querySelector('.playControls__play').click();");
        }
        ConsoleWindow cw = new ConsoleWindow();
        private void показатьКонсольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cw.ShowConsole();
            cw.Show();
        }
    }
}
