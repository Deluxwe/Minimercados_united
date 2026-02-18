namespace Minimercados_Unidos
{
    partial class FmrRepartidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrRepartidor));
            this.PnlSubMenu = new System.Windows.Forms.Panel();
            this.bttRegresar = new System.Windows.Forms.Button();
            this.bttPedidos = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.PnlSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlSubMenu
            // 
            this.PnlSubMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlSubMenu.BackgroundImage")));
            this.PnlSubMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlSubMenu.Controls.Add(this.bttRegresar);
            this.PnlSubMenu.Controls.Add(this.bttPedidos);
            this.PnlSubMenu.Controls.Add(this.pnlLogo);
            this.PnlSubMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PnlSubMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlSubMenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PnlSubMenu.Location = new System.Drawing.Point(0, 0);
            this.PnlSubMenu.Name = "PnlSubMenu";
            this.PnlSubMenu.Size = new System.Drawing.Size(204, 640);
            this.PnlSubMenu.TabIndex = 0;
            // 
            // bttRegresar
            // 
            this.bttRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bttRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttRegresar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRegresar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttRegresar.Location = new System.Drawing.Point(24, 572);
            this.bttRegresar.Name = "bttRegresar";
            this.bttRegresar.Size = new System.Drawing.Size(145, 56);
            this.bttRegresar.TabIndex = 4;
            this.bttRegresar.Text = "REGRESAR LOGIN";
            this.bttRegresar.UseVisualStyleBackColor = false;
            this.bttRegresar.Click += new System.EventHandler(this.bttRegresar_Click);
            // 
            // bttPedidos
            // 
            this.bttPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bttPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttPedidos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttPedidos.ForeColor = System.Drawing.Color.Black;
            this.bttPedidos.Location = new System.Drawing.Point(12, 219);
            this.bttPedidos.Name = "bttPedidos";
            this.bttPedidos.Size = new System.Drawing.Size(179, 45);
            this.bttPedidos.TabIndex = 1;
            this.bttPedidos.Text = "Pedidos";
            this.bttPedidos.UseVisualStyleBackColor = false;
            this.bttPedidos.Click += new System.EventHandler(this.bttPedidos_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(204, 154);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlCentral
            // 
            this.pnlCentral.BackColor = System.Drawing.Color.Transparent;
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(204, 0);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(900, 640);
            this.pnlCentral.TabIndex = 1;
            // 
            // FmrRepartidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1104, 640);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.PnlSubMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmrRepartidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmrRepartidor";
            this.PnlSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSubMenu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button bttPedidos;
        private System.Windows.Forms.Button bttRegresar;
        private System.Windows.Forms.Panel pnlCentral;
    }
}