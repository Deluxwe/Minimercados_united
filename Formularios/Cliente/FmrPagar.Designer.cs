namespace Minimercados_Unidos.Formularios.Cliente
{
    partial class FmrPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrPagar));
            this.DttgrindPagos = new System.Windows.Forms.DataGridView();
            this.PnlCedula = new System.Windows.Forms.Panel();
            this.LblNombreCiente = new System.Windows.Forms.Label();
            this.PnlPagos = new System.Windows.Forms.Panel();
            this.DtpPagos = new System.Windows.Forms.DateTimePicker();
            this.bttPagar = new System.Windows.Forms.Button();
            this.TxtAbonar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DttgrindPagos)).BeginInit();
            this.PnlCedula.SuspendLayout();
            this.PnlPagos.SuspendLayout();
            this.SuspendLayout();
            // 
            // DttgrindPagos
            // 
            this.DttgrindPagos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DttgrindPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DttgrindPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DttgrindPagos.Location = new System.Drawing.Point(0, 276);
            this.DttgrindPagos.Name = "DttgrindPagos";
            this.DttgrindPagos.Size = new System.Drawing.Size(895, 346);
            this.DttgrindPagos.TabIndex = 1;
            // 
            // PnlCedula
            // 
            this.PnlCedula.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlCedula.BackgroundImage")));
            this.PnlCedula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlCedula.Controls.Add(this.LblNombreCiente);
            this.PnlCedula.Location = new System.Drawing.Point(12, 23);
            this.PnlCedula.Name = "PnlCedula";
            this.PnlCedula.Size = new System.Drawing.Size(350, 229);
            this.PnlCedula.TabIndex = 14;
            // 
            // LblNombreCiente
            // 
            this.LblNombreCiente.AutoSize = true;
            this.LblNombreCiente.BackColor = System.Drawing.Color.Transparent;
            this.LblNombreCiente.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreCiente.ForeColor = System.Drawing.Color.Black;
            this.LblNombreCiente.Location = new System.Drawing.Point(69, 102);
            this.LblNombreCiente.Name = "LblNombreCiente";
            this.LblNombreCiente.Size = new System.Drawing.Size(15, 22);
            this.LblNombreCiente.TabIndex = 11;
            this.LblNombreCiente.Text = ".";
            // 
            // PnlPagos
            // 
            this.PnlPagos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlPagos.BackgroundImage")));
            this.PnlPagos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlPagos.Controls.Add(this.DtpPagos);
            this.PnlPagos.Controls.Add(this.bttPagar);
            this.PnlPagos.Controls.Add(this.TxtAbonar);
            this.PnlPagos.Controls.Add(this.label2);
            this.PnlPagos.Location = new System.Drawing.Point(423, 23);
            this.PnlPagos.Name = "PnlPagos";
            this.PnlPagos.Size = new System.Drawing.Size(461, 229);
            this.PnlPagos.TabIndex = 15;
            // 
            // DtpPagos
            // 
            this.DtpPagos.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpPagos.Location = new System.Drawing.Point(31, 142);
            this.DtpPagos.Name = "DtpPagos";
            this.DtpPagos.Size = new System.Drawing.Size(200, 20);
            this.DtpPagos.TabIndex = 16;
            // 
            // bttPagar
            // 
            this.bttPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttPagar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttPagar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttPagar.Location = new System.Drawing.Point(294, 115);
            this.bttPagar.Name = "bttPagar";
            this.bttPagar.Size = new System.Drawing.Size(145, 56);
            this.bttPagar.TabIndex = 14;
            this.bttPagar.Text = "Pagar";
            this.bttPagar.UseVisualStyleBackColor = false;
            this.bttPagar.Click += new System.EventHandler(this.bttPagar_Click);
            // 
            // TxtAbonar
            // 
            this.TxtAbonar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAbonar.Location = new System.Drawing.Point(31, 83);
            this.TxtAbonar.Name = "TxtAbonar";
            this.TxtAbonar.Size = new System.Drawing.Size(408, 26);
            this.TxtAbonar.TabIndex = 14;
            this.TxtAbonar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Valor a abonar";
            // 
            // FmrPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(896, 646);
            this.Controls.Add(this.PnlPagos);
            this.Controls.Add(this.PnlCedula);
            this.Controls.Add(this.DttgrindPagos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrPagar";
            this.Text = "FmrPagar";
            ((System.ComponentModel.ISupportInitialize)(this.DttgrindPagos)).EndInit();
            this.PnlCedula.ResumeLayout(false);
            this.PnlCedula.PerformLayout();
            this.PnlPagos.ResumeLayout(false);
            this.PnlPagos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DttgrindPagos;
        private System.Windows.Forms.Panel PnlCedula;
        private System.Windows.Forms.Label LblNombreCiente;
        private System.Windows.Forms.Panel PnlPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttPagar;
        private System.Windows.Forms.TextBox TxtAbonar;
        private System.Windows.Forms.DateTimePicker DtpPagos;
    }
}