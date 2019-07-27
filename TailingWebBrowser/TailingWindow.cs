using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailingWebBrowser.Dialogs;
using WeifenLuo.WinFormsUI.Docking;
namespace TailingWebBrowser
{
    public partial class TailingWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public TailingWindow()
        {
            InitializeComponent();

            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";

            Cef.Initialize(cefSettings);
        }

        private void newTabctrltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTab n = new NewTab();

            var res = n.ShowDialog();
            if (res == DialogResult.OK)
            {
                ChromiumTab cr = new ChromiumTab(n.textBoxUrl.Text);
                cr.Show(dockPanel1);
                cr.DockHandler.GetPersistStringCallback = () =>
                {
                    return n.textBoxUrl.Text;
                };
            }
        }
        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dockPanel1.SaveAsXml("session.xml");
        }

        private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = new DeserializeDockContent(GetContentFromPersistString);
            dockPanel1.LoadFromXml("session.xml", r);
        }

        IDockContent GetContentFromPersistString(string persistString)
        {
            return new ChromiumTab(persistString);
        }

        private void TailingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSessionToolStripMenuItem_Click(sender, e);
        }
    }
}
