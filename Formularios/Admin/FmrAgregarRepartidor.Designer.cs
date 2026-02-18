namespace Minimercados_Unidos.Formularios.Admin
{
    partial class FmrAgregarRepartidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrAgregarRepartidor));
            this.BttEliminarRep = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DtgRepartidores = new System.Windows.Forms.DataGridView();
            this.BttAgregarRep = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Id_Repartidor = new System.Windows.Forms.Label();
            this.Txtid_repartidor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRepartidores)).BeginInit();
            this.SuspendLayout();
            // 
            // BttEliminarRep
            // 
            this.BttEliminarRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttEliminarRep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttEliminarRep.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttEliminarRep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttEliminarRep.Location = new System.Drawing.Point(155, 472);
            this.BttEliminarRep.Name = "BttEliminarRep";
            this.BttEliminarRep.Size = new System.Drawing.Size(145, 56);
            this.BttEliminarRep.TabIndex = 48;
            this.BttEliminarRep.Text = "Eliminar Repartidor";
            this.BttEliminarRep.UseVisualStyleBackColor = false;
            this.BttEliminarRep.Click += new System.EventHandler(this.BttEliminarRep_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(564, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 22);
            this.label3.TabIndex = 47;
            this.label3.Text = "Sus Repartidor";
            // 
            // DtgRepartidores
            // 
            this.DtgRepartidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRepartidores.Location = new System.Drawing.Point(499, 111);
            this.DtgRepartidores.Name = "DtgRepartidores";
            this.DtgRepartidores.Size = new System.Drawing.Size(285, 463);
            this.DtgRepartidores.TabIndex = 46;
            // 
            // BttAgregarRep
            // 
            this.BttAgregarRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttAgregarRep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttAgregarRep.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAgregarRep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttAgregarRep.Location = new System.Drawing.Point(155, 390);
            this.BttAgregarRep.Name = "BttAgregarRep";
            this.BttAgregarRep.Size = new System.Drawing.Size(145, 56);
            this.BttAgregarRep.TabIndex = 44;
            this.BttAgregarRep.Text = "Agrega Repartidor";
            this.BttAgregarRep.UseVisualStyleBackColor = false;
            this.BttAgregarRep.Click += new System.EventHandler(this.BttAgregarRep_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(83, 296);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(296, 26);
            this.TxtNombre.TabIndex = 41;
            this.TxtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(188, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "Nombre";
            // 
            // Id_Repartidor
            // 
            this.Id_Repartidor.AutoSize = true;
            this.Id_Repartidor.BackColor = System.Drawing.Color.Transparent;
            this.Id_Repartidor.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id_Repartidor.ForeColor = System.Drawing.Color.Black;
            this.Id_Repartidor.Location = new System.Drawing.Point(164, 196);
            this.Id_Repartidor.Name = "Id_Repartidor";
            this.Id_Repartidor.Size = new System.Drawing.Size(136, 22);
            this.Id_Repartidor.TabIndex = 39;
            this.Id_Repartidor.Text = "Id_Repartidor";
            // 
            // Txtid_repartidor
            // 
            this.Txtid_repartidor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtid_repartidor.Location = new System.Drawing.Point(83, 221);
            this.Txtid_repartidor.Name = "Txtid_repartidor";
            this.Txtid_repartidor.Size = new System.Drawing.Size(296, 26);
            this.Txtid_repartidor.TabIndex = 38;
            this.Txtid_repartidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FmrAgregarRepartidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 658);
            this.Controls.Add(this.BttEliminarRep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtgRepartidores);
            this.Controls.Add(this.BttAgregarRep);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Id_Repartidor);
            this.Controls.Add(this.Txtid_repartidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrAgregarRepartidor";
            this.Text = "FmrAgregarRepartidor";
            this.Load += new System.EventHandler(this.FmrAgregarRepartidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRepartidores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BttEliminarRep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DtgRepartidores;
        private System.Windows.Forms.Button BttAgregarRep;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Id_Repartidor;
        private System.Windows.Forms.TextBox Txtid_repartidor;
    }
}