namespace IS_Comandas_
{
    partial class frmMainCajero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainCajero));
            this.btniCerrar = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // btniCerrar
            // 
            this.btniCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btniCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btniCerrar.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btniCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btniCerrar.HoverState.ImageSize = new System.Drawing.Size(128, 128);
            this.btniCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btniCerrar.Image")));
            this.btniCerrar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btniCerrar.ImageRotate = 0F;
            this.btniCerrar.ImageSize = new System.Drawing.Size(115, 115);
            this.btniCerrar.Location = new System.Drawing.Point(1100, 580);
            this.btniCerrar.Name = "btniCerrar";
            this.btniCerrar.PressedState.ImageSize = new System.Drawing.Size(128, 128);
            this.btniCerrar.Size = new System.Drawing.Size(128, 128);
            this.btniCerrar.TabIndex = 2;
            this.btniCerrar.UseTransparentBackground = true;
            this.btniCerrar.Click += new System.EventHandler(this.btniCerrar_Click);
            // 
            // frmMainCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 720);
            this.Controls.Add(this.btniCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainCajero";
            this.Text = "frmMainCajero";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btniCerrar;
    }
}