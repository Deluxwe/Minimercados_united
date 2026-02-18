namespace Minimercados_Unidos.Formularios.LogIn
{
    partial class FmrLogInAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrLogInAdmin));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.TXTContraseña = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BttEntrar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.bttVolver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(100, 223);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(270, 26);
            this.txtUsuario.TabIndex = 0;
            // 
            // TXTContraseña
            // 
            this.TXTContraseña.AutoSize = true;
            this.TXTContraseña.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTContraseña.Location = new System.Drawing.Point(186, 265);
            this.TXTContraseña.Name = "TXTContraseña";
            this.TXTContraseña.Size = new System.Drawing.Size(118, 22);
            this.TXTContraseña.TabIndex = 2;
            this.TXTContraseña.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContrasena.Location = new System.Drawing.Point(100, 290);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.Size = new System.Drawing.Size(270, 26);
            this.TxtContrasena.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(176, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 117);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BttEntrar
            // 
            this.BttEntrar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttEntrar.Location = new System.Drawing.Point(100, 422);
            this.BttEntrar.Name = "BttEntrar";
            this.BttEntrar.Size = new System.Drawing.Size(270, 42);
            this.BttEntrar.TabIndex = 6;
            this.BttEntrar.Text = "Acceder";
            this.BttEntrar.UseVisualStyleBackColor = true;
            this.BttEntrar.Click += new System.EventHandler(this.BttEntrar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(97, 389);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 18);
            this.lblMensaje.TabIndex = 7;
            // 
            // bttVolver
            // 
            this.bttVolver.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttVolver.Location = new System.Drawing.Point(100, 481);
            this.bttVolver.Name = "bttVolver";
            this.bttVolver.Size = new System.Drawing.Size(270, 42);
            this.bttVolver.TabIndex = 8;
            this.bttVolver.Text = "Cancerlar";
            this.bttVolver.UseVisualStyleBackColor = true;
            this.bttVolver.Click += new System.EventHandler(this.bttVolver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Administrador";
            // 
            // FmrLogInAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(473, 560);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttVolver);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.BttEntrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTContraseña);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrLogInAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmrLogInAdmin";
            this.Load += new System.EventHandler(this.FmrLogInAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label TXTContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BttEntrar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button bttVolver;
        private System.Windows.Forms.Label label2;
    }
}