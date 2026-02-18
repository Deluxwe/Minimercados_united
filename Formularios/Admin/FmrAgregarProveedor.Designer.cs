namespace Minimercados_Unidos.Formularios.Admin
{
    partial class FmrAgregarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrAgregarProveedor));
            this.Txtnombre = new System.Windows.Forms.TextBox();
            this.TXTContraseña = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txtdireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtcorreo = new System.Windows.Forms.TextBox();
            this.BttAgregarProdu = new System.Windows.Forms.Button();
            this.BttCancelar = new System.Windows.Forms.Button();
            this.dataGridViewProveedores = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // Txtnombre
            // 
            this.Txtnombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtnombre.Location = new System.Drawing.Point(39, 50);
            this.Txtnombre.Name = "Txtnombre";
            this.Txtnombre.Size = new System.Drawing.Size(296, 26);
            this.Txtnombre.TabIndex = 17;
            this.Txtnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txtnombre.TextChanged += new System.EventHandler(this.Txtnombre_TextChanged);
            // 
            // TXTContraseña
            // 
            this.TXTContraseña.AutoSize = true;
            this.TXTContraseña.BackColor = System.Drawing.Color.Transparent;
            this.TXTContraseña.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTContraseña.ForeColor = System.Drawing.Color.Black;
            this.TXTContraseña.Location = new System.Drawing.Point(96, 25);
            this.TXTContraseña.Name = "TXTContraseña";
            this.TXTContraseña.Size = new System.Drawing.Size(186, 22);
            this.TXTContraseña.TabIndex = 18;
            this.TXTContraseña.Text = "Nombre Proveedor";
            this.TXTContraseña.Click += new System.EventHandler(this.TXTContraseña_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(136, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Direccion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Txtdireccion
            // 
            this.Txtdireccion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdireccion.Location = new System.Drawing.Point(39, 125);
            this.Txtdireccion.Name = "Txtdireccion";
            this.Txtdireccion.Size = new System.Drawing.Size(296, 26);
            this.Txtdireccion.TabIndex = 20;
            this.Txtdireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txtdireccion.TextChanged += new System.EventHandler(this.Txtdireccion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(148, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Correo";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Txtcorreo
            // 
            this.Txtcorreo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcorreo.Location = new System.Drawing.Point(39, 205);
            this.Txtcorreo.Name = "Txtcorreo";
            this.Txtcorreo.Size = new System.Drawing.Size(296, 26);
            this.Txtcorreo.TabIndex = 22;
            this.Txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txtcorreo.TextChanged += new System.EventHandler(this.Txtcorreo_TextChanged);
            // 
            // BttAgregarProdu
            // 
            this.BttAgregarProdu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttAgregarProdu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttAgregarProdu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAgregarProdu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttAgregarProdu.Location = new System.Drawing.Point(112, 355);
            this.BttAgregarProdu.Name = "BttAgregarProdu";
            this.BttAgregarProdu.Size = new System.Drawing.Size(145, 56);
            this.BttAgregarProdu.TabIndex = 23;
            this.BttAgregarProdu.Text = "Agrega Proveedor";
            this.BttAgregarProdu.UseVisualStyleBackColor = false;
            this.BttAgregarProdu.Click += new System.EventHandler(this.BttAgregarProdu_Click);
            // 
            // BttCancelar
            // 
            this.BttCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttCancelar.Location = new System.Drawing.Point(112, 441);
            this.BttCancelar.Name = "BttCancelar";
            this.BttCancelar.Size = new System.Drawing.Size(145, 56);
            this.BttCancelar.TabIndex = 24;
            this.BttCancelar.Text = "Cancelar";
            this.BttCancelar.UseVisualStyleBackColor = false;
            this.BttCancelar.Click += new System.EventHandler(this.BttCancelar_Click);
            // 
            // dataGridViewProveedores
            // 
            this.dataGridViewProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProveedores.Location = new System.Drawing.Point(433, 50);
            this.dataGridViewProveedores.Name = "dataGridViewProveedores";
            this.dataGridViewProveedores.Size = new System.Drawing.Size(481, 463);
            this.dataGridViewProveedores.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(598, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Sus Proveedores";
            // 
            // FmrAgregarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(944, 538);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewProveedores);
            this.Controls.Add(this.BttCancelar);
            this.Controls.Add(this.BttAgregarProdu);
            this.Controls.Add(this.Txtcorreo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txtdireccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTContraseña);
            this.Controls.Add(this.Txtnombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrAgregarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmrAgregarProveedor";
            this.Load += new System.EventHandler(this.FmrAgregarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txtnombre;
        private System.Windows.Forms.Label TXTContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txtdireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtcorreo;
        private System.Windows.Forms.Button BttAgregarProdu;
        private System.Windows.Forms.Button BttCancelar;
        private System.Windows.Forms.DataGridView dataGridViewProveedores;
        private System.Windows.Forms.Label label3;
    }
}