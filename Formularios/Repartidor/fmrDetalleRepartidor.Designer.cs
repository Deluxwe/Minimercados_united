namespace Minimercados_Unidos
{
    partial class fmrDetalleRepartidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrDetalleRepartidor));
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.Txt_IdRepartidor = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerEntrega = new System.Windows.Forms.DateTimePicker();
            this.BttEnviado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BttAgregarProdu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(12, 306);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(888, 340);
            this.dgvResultados.TabIndex = 0;
            // 
            // Txt_IdRepartidor
            // 
            this.Txt_IdRepartidor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_IdRepartidor.Location = new System.Drawing.Point(26, 60);
            this.Txt_IdRepartidor.Name = "Txt_IdRepartidor";
            this.Txt_IdRepartidor.Size = new System.Drawing.Size(360, 26);
            this.Txt_IdRepartidor.TabIndex = 27;
            this.Txt_IdRepartidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerEntrega);
            this.panel1.Controls.Add(this.BttEnviado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BttAgregarProdu);
            this.panel1.Controls.Add(this.Txt_IdRepartidor);
            this.panel1.Location = new System.Drawing.Point(12, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 264);
            this.panel1.TabIndex = 28;
            // 
            // dateTimePickerEntrega
            // 
            this.dateTimePickerEntrega.Location = new System.Drawing.Point(202, 124);
            this.dateTimePickerEntrega.Name = "dateTimePickerEntrega";
            this.dateTimePickerEntrega.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEntrega.TabIndex = 32;
            // 
            // BttEnviado
            // 
            this.BttEnviado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttEnviado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttEnviado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttEnviado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttEnviado.Location = new System.Drawing.Point(241, 150);
            this.BttEnviado.Name = "BttEnviado";
            this.BttEnviado.Size = new System.Drawing.Size(145, 56);
            this.BttEnviado.TabIndex = 31;
            this.BttEnviado.Text = "Entregado";
            this.BttEnviado.UseVisualStyleBackColor = false;
            this.BttEnviado.Click += new System.EventHandler(this.BttEnviado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cedula Repartidor";
            // 
            // BttAgregarProdu
            // 
            this.BttAgregarProdu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttAgregarProdu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttAgregarProdu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAgregarProdu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttAgregarProdu.Location = new System.Drawing.Point(26, 150);
            this.BttAgregarProdu.Name = "BttAgregarProdu";
            this.BttAgregarProdu.Size = new System.Drawing.Size(145, 56);
            this.BttAgregarProdu.TabIndex = 28;
            this.BttAgregarProdu.Text = "Consultar";
            this.BttAgregarProdu.UseVisualStyleBackColor = false;
            this.BttAgregarProdu.Click += new System.EventHandler(this.BttAgregarProdu_Click);
            // 
            // fmrDetalleRepartidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 658);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvResultados);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmrDetalleRepartidor";
            this.Text = "fmrDetalleRepartidor";
            this.Load += new System.EventHandler(this.fmrDetalleRepartidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.TextBox Txt_IdRepartidor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BttAgregarProdu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BttEnviado;
        private System.Windows.Forms.DateTimePicker dateTimePickerEntrega;
    }
}