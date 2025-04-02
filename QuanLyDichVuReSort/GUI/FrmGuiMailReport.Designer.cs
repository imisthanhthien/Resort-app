namespace GUI
{
    partial class FrmGuiMailReport
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
            this.pcbLoader = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbLoader
            // 
            this.pcbLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbLoader.FillColor = System.Drawing.Color.Transparent;
            this.pcbLoader.Image = global::GUI.Properties.Resources.loadmail;
            this.pcbLoader.ImageRotate = 0F;
            this.pcbLoader.Location = new System.Drawing.Point(0, 0);
            this.pcbLoader.Name = "pcbLoader";
            this.pcbLoader.Size = new System.Drawing.Size(171, 150);
            this.pcbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLoader.TabIndex = 1;
            this.pcbLoader.TabStop = false;
            // 
            // FrmGuiMailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 150);
            this.Controls.Add(this.pcbLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGuiMailReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGuiMailReport";
            this.Load += new System.EventHandler(this.FrmGuiMailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLoader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pcbLoader;
    }
}