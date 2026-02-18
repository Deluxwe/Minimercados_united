namespace Minimercados_Unidos.Formularios.Admin
{
    partial class FmrAgregarAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrAgregarAdmin));
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewAdmins = new System.Windows.Forms.DataGridView();
            this.BttAgregarAdm = new System.Windows.Forms.Button();
            this.Txtcontrasena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtusuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id_admin = new System.Windows.Forms.Label();
            this.Txtid_admin = new System.Windows.Forms.TextBox();
            this.BttEliminarAdm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(599, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "Sus Admins";
            // 
            // dataGridViewAdmins
            // 
            this.dataGridViewAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmins.Location = new System.Drawing.Point(470, 110);
            this.dataGridViewAdmins.Name = "dataGridViewAdmins";
            this.dataGridViewAdmins.Size = new System.Drawing.Size(367, 463);
            this.dataGridViewAdmins.TabIndex = 35;
            // 
            // BttAgregarAdm
            // 
            this.BttAgregarAdm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttAgregarAdm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttAgregarAdm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAgregarAdm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttAgregarAdm.Location = new System.Drawing.Point(149, 415);
            this.BttAgregarAdm.Name = "BttAgregarAdm";
            this.BttAgregarAdm.Size = new System.Drawing.Size(145, 56);
            this.BttAgregarAdm.TabIndex = 33;
            this.BttAgregarAdm.Text = "Agrega Admin";
            this.BttAgregarAdm.UseVisualStyleBackColor = false;
            this.BttAgregarAdm.Click += new System.EventHandler(this.BttAgregarAdm_Click);
            // 
            // Txtcontrasena
            // 
            this.Txtcontrasena.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcontrasena.Location = new System.Drawing.Point(76, 265);
            this.Txtcontrasena.Name = "Txtcontrasena";
            this.Txtcontrasena.Size = new System.Drawing.Size(296, 26);
            this.Txtcontrasena.TabIndex = 32;
            this.Txtcontrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(162, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 31;
            this.label2.Text = "Contraseña";
            // 
            // Txtusuario
            // 
            this.Txtusuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtusuario.Location = new System.Drawing.Point(76, 185);
            this.Txtusuario.Name = "Txtusuario";
            this.Txtusuario.Size = new System.Drawing.Size(296, 26);
            this.Txtusuario.TabIndex = 30;
            this.Txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(181, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 29;
            this.label1.Text = "Usuario";
            // 
            // id_admin
            // 
            this.id_admin.AutoSize = true;
            this.id_admin.BackColor = System.Drawing.Color.Transparent;
            this.id_admin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_admin.ForeColor = System.Drawing.Color.Black;
            this.id_admin.Location = new System.Drawing.Point(185, 85);
            this.id_admin.Name = "id_admin";
            this.id_admin.Size = new System.Drawing.Size(95, 22);
            this.id_admin.TabIndex = 28;
            this.id_admin.Text = "Id_admin";
            // 
            // Txtid_admin
            // 
            this.Txtid_admin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtid_admin.Location = new System.Drawing.Point(76, 110);
            this.Txtid_admin.Name = "Txtid_admin";
            this.Txtid_admin.Size = new System.Drawing.Size(296, 26);
            this.Txtid_admin.TabIndex = 27;
            this.Txtid_admin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BttEliminarAdm
            // 
            this.BttEliminarAdm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttEliminarAdm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttEliminarAdm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttEliminarAdm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttEliminarAdm.Location = new System.Drawing.Point(149, 497);
            this.BttEliminarAdm.Name = "BttEliminarAdm";
            this.BttEliminarAdm.Size = new System.Drawing.Size(145, 56);
            this.BttEliminarAdm.TabIndex = 37;
            this.BttEliminarAdm.Text = "Eliminar Admin";
            this.BttEliminarAdm.UseVisualStyleBackColor = false;
            this.BttEliminarAdm.Click += new System.EventHandler(this.BttEliminarAdm_Click);
            // 
            // FmrAgregarAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 658);
            this.Controls.Add(this.BttEliminarAdm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewAdmins);
            this.Controls.Add(this.BttAgregarAdm);
            this.Controls.Add(this.Txtcontrasena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txtusuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_admin);
            this.Controls.Add(this.Txtid_admin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrAgregarAdmin";
            this.Text = "FrmAgragarAdmin";
            this.Load += new System.EventHandler(this.FmrAgregarAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewAdmins;
        private System.Windows.Forms.Button BttAgregarAdm;
        private System.Windows.Forms.TextBox Txtcontrasena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtusuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label id_admin;
        private System.Windows.Forms.TextBox Txtid_admin;
        private System.Windows.Forms.Button BttEliminarAdm;
    }
}