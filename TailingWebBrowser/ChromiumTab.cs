using CefSharp;
using CefSharp.WinForms;
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
    public partial class ChromiumTab : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ChromiumWebBrowser chromiumWebBrowser;


        public ChromiumTab(string url)
        {
            InitializeComponent();

            this.textBoxAddress.Text = url;

            InitializeChromium();
            chromiumWebBrowser.IsBrowserInitializedChanged += this.ChromiumWebBrowser_IsBrowserInitializedChanged;
            chromiumWebBrowser.AddressChanged += ChromiumWebBrowser_AddressChanged;
            chromiumWebBrowser.TitleChanged += ChromiumWebBrowser_TitleChanged;
        }

        private void ChromiumWebBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = e.Title;
            });
        }

        private void ChromiumWebBrowser_IsBrowserInitializedChanged(object sender, EventArgs args)
        {
            //if (args.IsBrowserInitialized)
            //{
            //}
        }

        private void InitializeChromium()
        {
            chromiumWebBrowser = new ChromiumWebBrowser(this.textBoxAddress.Text);

            chromiumWebBrowser.Dock = DockStyle.Fill;

            chromiumWebBrowser.ConsoleMessage += this.ChromiumWebBrowser_ConsoleMessage;
        }
        private void ChromiumWebBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            //cw.AddMessage(e);
        }

        private void CromiumTab_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(chromiumWebBrowser);
        }

        private void ChromiumWebBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            try
            {
                this.textBoxAddress.Invoke((MethodInvoker)delegate
                {
                    this.textBoxAddress.Text = e.Address;
                    this.DockHandler.GetPersistStringCallback = () =>
                    {
                        return e.Address;
                    };
                });
            }
            catch (Exception ex)
            {
                this.textBoxAddress.Text = "";
            }
        }

        private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chromiumWebBrowser.Load(this.textBoxAddress.Text);

            }
        }
    }
}
