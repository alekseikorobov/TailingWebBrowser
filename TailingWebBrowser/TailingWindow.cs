using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailingWebBrowser.Dialogs;
using TailingWebBrowser.HookKeybordApp;
using WeifenLuo.WinFormsUI.Docking;
namespace TailingWebBrowser
{
    public partial class TailingWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        HookKeybordHelper hookKeybordHelper;
        public TailingWindow()
        {
            InitializeComponent();

            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";

            Cef.Initialize(cefSettings);

            hookKeybordHelper = new HookKeybordHelper(this);
            hookKeybordHelper.SetHook();
        }

        private void TailingWindow_Deactivate(object sender, EventArgs e)
        {
            IsActive = false;
        }

        public bool IsActive = false;
        private void TailingWindow_Activated(object sender, EventArgs e)
        {
            IsActive = true;
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
        private void FullScreenshot(String filepath, String filename, ImageFormat format)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                string fullpath = filepath + "\\" + filename;

                bitmap.Save(fullpath, format);
            }
        }
        public void WindowScreenshotWithoutClass()
        {
            String desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filepath = Path.Combine(desk, "Image");
            Directory.CreateDirectory(filepath);
            String filename = $"im_{DateTime.Now:yyyy_MM_dd_hhmmss}.jpg";
            ImageFormat format = ImageFormat.Jpeg;
            Rectangle bounds = this.Bounds;

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                string fullpath = Path.Combine(filepath, filename);

                bitmap.Save(fullpath, format);
            }
        }
      
    }
}
