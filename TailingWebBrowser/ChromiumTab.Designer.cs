namespace TailingWebBrowser
{
    partial class ChromiumTab
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 422);
            this.panel1.TabIndex = 0;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAddress.Location = new System.Drawing.Point(0, 0);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(800, 22);
            this.textBoxAddress.TabIndex = 1;
            this.textBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAddress_KeyDown);
            // 
            // ChromiumTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.panel1);
            this.Name = "ChromiumTab";
            this.Text = "CromiumTab";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += new System.EventHandler(this.CromiumTab_Load);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxAddress;
    }
}