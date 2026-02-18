namespace Minimercados_Unidos
{
    partial class FmrPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrPedidos));
            this.DttgrindPedidos = new System.Windows.Forms.DataGridView();
            this.LblNombreCiente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bttConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DttgrindPedidos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DttgrindPedidos
            // 
            this.DttgrindPedidos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DttgrindPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DttgrindPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DttgrindPedidos.Location = new System.Drawing.Point(-2, 278);
            this.DttgrindPedidos.Name = "DttgrindPedidos";
            this.DttgrindPedidos.Size = new System.Drawing.Size(915, 368);
            this.DttgrindPedidos.TabIndex = 0;
            // 
            // LblNombreCiente
            // 
            this.LblNombreCiente.AutoSize = true;
            this.LblNombreCiente.BackColor = System.Drawing.Color.Transparent;
            this.LblNombreCiente.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreCiente.ForeColor = System.Drawing.Color.Black;
            this.LblNombreCiente.Location = new System.Drawing.Point(227, 46);
            this.LblNombreCiente.Name = "LblNombreCiente";
            this.LblNombreCiente.Size = new System.Drawing.Size(15, 22);
            this.LblNombreCiente.TabIndex = 11;
            this.LblNombreCiente.Text = ".";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.bttConsultar);
            this.panel1.Controls.Add(this.LblNombreCiente);
            this.panel1.Location = new System.Drawing.Point(134, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 207);
            this.panel1.TabIndex = 13;
            // 
            // bttConsultar
            // 
            this.bttConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttConsultar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttConsultar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttConsultar.Location = new System.Drawing.Point(231, 92);
            this.bttConsultar.Name = "bttConsultar";
            this.bttConsultar.Size = new System.Drawing.Size(145, 56);
            this.bttConsultar.TabIndex = 13;
            this.bttConsultar.Text = "Consultar";
            this.bttConsultar.UseVisualStyleBackColor = false;
            this.bttConsultar.Click += new System.EventHandler(this.bttConsultar_Click);
            // 
            // FmrPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 658);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DttgrindPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrPedidos";
            ((System.ComponentModel.ISupportInitialize)(this.DttgrindPedidos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DttgrindPedidos;
        private System.Windows.Forms.Label LblNombreCiente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttConsultar;
    }
}