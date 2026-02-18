namespace Minimercados_Unidos
{
    partial class FmrLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrLogIn));
            this.PnlButton = new System.Windows.Forms.Panel();
            this.bttRepartidor = new System.Windows.Forms.Button();
            this.BttClienteLogin = new System.Windows.Forms.Button();
            this.BttAdminLogin = new System.Windows.Forms.Button();
            this.PnlBorder = new System.Windows.Forms.Panel();
            this.PnlButton.SuspendLayout();
            this.PnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlButton
            // 
            this.PnlButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlButton.BackgroundImage")));
            this.PnlButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlButton.Controls.Add(this.bttRepartidor);
            this.PnlButton.Controls.Add(this.BttClienteLogin);
            this.PnlButton.Controls.Add(this.BttAdminLogin);
            this.PnlButton.Location = new System.Drawing.Point(13, 15);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(258, 498);
            this.PnlButton.TabIndex = 0;
            // 
            // bttRepartidor
            // 
            this.bttRepartidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttRepartidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttRepartidor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRepartidor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttRepartidor.Location = new System.Drawing.Point(33, 270);
            this.bttRepartidor.Name = "bttRepartidor";
            this.bttRepartidor.Size = new System.Drawing.Size(185, 42);
            this.bttRepartidor.TabIndex = 2;
            this.bttRepartidor.Text = "Repartidor";
            this.bttRepartidor.UseVisualStyleBackColor = false;
            this.bttRepartidor.Click += new System.EventHandler(this.bttRepartidor_Click);
            // 
            // BttClienteLogin
            // 
            this.BttClienteLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttClienteLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttClienteLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttClienteLogin.Location = new System.Drawing.Point(33, 182);
            this.BttClienteLogin.Name = "BttClienteLogin";
            this.BttClienteLogin.Size = new System.Drawing.Size(185, 43);
            this.BttClienteLogin.TabIndex = 1;
            this.BttClienteLogin.Text = "Cliente";
            this.BttClienteLogin.UseVisualStyleBackColor = false;
            this.BttClienteLogin.Click += new System.EventHandler(this.BttClienteLogin_Click);
            // 
            // BttAdminLogin
            // 
            this.BttAdminLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BttAdminLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BttAdminLogin.FlatAppearance.BorderSize = 120;
            this.BttAdminLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttAdminLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAdminLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttAdminLogin.Location = new System.Drawing.Point(33, 102);
            this.BttAdminLogin.Name = "BttAdminLogin";
            this.BttAdminLogin.Size = new System.Drawing.Size(185, 43);
            this.BttAdminLogin.TabIndex = 0;
            this.BttAdminLogin.Text = "Administrador";
            this.BttAdminLogin.UseVisualStyleBackColor = false;
            this.BttAdminLogin.Click += new System.EventHandler(this.BttAdminLogin_Click);
            // 
            // PnlBorder
            // 
            this.PnlBorder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlBorder.BackgroundImage")));
            this.PnlBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlBorder.Controls.Add(this.PnlButton);
            this.PnlBorder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PnlBorder.Location = new System.Drawing.Point(508, 78);
            this.PnlBorder.Name = "PnlBorder";
            this.PnlBorder.Size = new System.Drawing.Size(284, 534);
            this.PnlBorder.TabIndex = 1;
            // 
            // FmrLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1374, 642);
            this.Controls.Add(this.PnlBorder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FmrLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmrLogIn";
            this.PnlButton.ResumeLayout(false);
            this.PnlBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlButton;
        private System.Windows.Forms.Button BttAdminLogin;
        private System.Windows.Forms.Button BttClienteLogin;
        private System.Windows.Forms.Panel PnlBorder;
        private System.Windows.Forms.Button bttRepartidor;
    }
}