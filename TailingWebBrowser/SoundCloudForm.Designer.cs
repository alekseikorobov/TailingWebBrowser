namespace TailingWebBrowser
{
    partial class SoundCloudForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundCloudForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.опцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вызовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.следующаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предыдущаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьКонсольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.следующаяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.стартстопToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.опцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // опцииToolStripMenuItem
            // 
            this.опцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вызовToolStripMenuItem,
            this.стартToolStripMenuItem,
            this.следующаяToolStripMenuItem,
            this.предыдущаяToolStripMenuItem,
            this.показатьКонсольToolStripMenuItem});
            this.опцииToolStripMenuItem.Name = "опцииToolStripMenuItem";
            this.опцииToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.опцииToolStripMenuItem.Text = "Опции";
            // 
            // вызовToolStripMenuItem
            // 
            this.вызовToolStripMenuItem.Name = "вызовToolStripMenuItem";
            this.вызовToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.вызовToolStripMenuItem.Text = "Вызов";
            this.вызовToolStripMenuItem.Click += new System.EventHandler(this.вызовToolStripMenuItem_Click);
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.стартToolStripMenuItem.Text = "Старт";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // следующаяToolStripMenuItem
            // 
            this.следующаяToolStripMenuItem.Name = "следующаяToolStripMenuItem";
            this.следующаяToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.следующаяToolStripMenuItem.Text = "Следующая";
            this.следующаяToolStripMenuItem.Click += new System.EventHandler(this.следующаяToolStripMenuItem_Click);
            // 
            // предыдущаяToolStripMenuItem
            // 
            this.предыдущаяToolStripMenuItem.Name = "предыдущаяToolStripMenuItem";
            this.предыдущаяToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.предыдущаяToolStripMenuItem.Text = "Предыдущая";
            // 
            // показатьКонсольToolStripMenuItem
            // 
            this.показатьКонсольToolStripMenuItem.Name = "показатьКонсольToolStripMenuItem";
            this.показатьКонсольToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.показатьКонсольToolStripMenuItem.Text = "Показать консоль";
            this.показатьКонсольToolStripMenuItem.Click += new System.EventHandler(this.показатьКонсольToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 422);
            this.panel1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SoundCloud";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.следующаяToolStripMenuItem1,
            this.стартстопToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 76);
            // 
            // следующаяToolStripMenuItem1
            // 
            this.следующаяToolStripMenuItem1.Name = "следующаяToolStripMenuItem1";
            this.следующаяToolStripMenuItem1.Size = new System.Drawing.Size(158, 24);
            this.следующаяToolStripMenuItem1.Text = "Следующая";
            this.следующаяToolStripMenuItem1.Click += new System.EventHandler(this.следующаяToolStripMenuItem1_Click);
            // 
            // стартстопToolStripMenuItem
            // 
            this.стартстопToolStripMenuItem.Name = "стартстопToolStripMenuItem";
            this.стартстопToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.стартстопToolStripMenuItem.Text = "Старт/стоп";
            this.стартстопToolStripMenuItem.Click += new System.EventHandler(this.стартстопToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // SoundCloudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SoundCloudForm";
            this.Text = "SoundCloud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem опцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вызовToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem следующаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предыдущаяToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стартстопToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem следующаяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem показатьКонсольToolStripMenuItem;
    }
}