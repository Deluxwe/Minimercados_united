namespace Minimercados_Unidos
{
    partial class FmrPedidosAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrPedidosAdmin));
            this.DttgDescripcionPedi = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_idpedido = new System.Windows.Forms.TextBox();
            this.BttAgregarProdu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DttgDescripcionPedi)).BeginInit();
            this.SuspendLayout();
            // 
            // DttgDescripcionPedi
            // 
            this.DttgDescripcionPedi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DttgDescripcionPedi.Location = new System.Drawing.Point(12, 63);
            this.DttgDescripcionPedi.Name = "DttgDescripcionPedi";
            this.DttgDescripcionPedi.Size = new System.Drawing.Size(888, 490);
            this.DttgDescripcionPedi.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(375, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 22);
            this.label4.TabIndex = 25;
            this.label4.Text = "PedidosAdmin";
            // 
            // Txt_idpedido
            // 
            this.Txt_idpedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_idpedido.Location = new System.Drawing.Point(64, 594);
            this.Txt_idpedido.Name = "Txt_idpedido";
            this.Txt_idpedido.Size = new System.Drawing.Size(380, 26);
            this.Txt_idpedido.TabIndex = 26;
            this.Txt_idpedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BttAgregarProdu
            // 
            this.BttAgregarProdu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BttAgregarProdu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BttAgregarProdu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAgregarProdu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BttAgregarProdu.Location = new System.Drawing.Point(718, 578);
            this.BttAgregarProdu.Name = "BttAgregarProdu";
            this.BttAgregarProdu.Size = new System.Drawing.Size(145, 56);
            this.BttAgregarProdu.TabIndex = 27;
            this.BttAgregarProdu.Text = "Buscar por pedido";
            this.BttAgregarProdu.UseVisualStyleBackColor = false;
            this.BttAgregarProdu.Click += new System.EventHandler(this.BttAgregarProdu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(60, 569);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Id Pedido";
            // 
            // FmrPedidosAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 658);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BttAgregarProdu);
            this.Controls.Add(this.Txt_idpedido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DttgDescripcionPedi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrPedidosAdmin";
            this.Text = "FmrPedidosAdmin";
            this.Load += new System.EventHandler(this.FmrPedidosAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DttgDescripcionPedi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DttgDescripcionPedi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_idpedido;
        private System.Windows.Forms.Button BttAgregarProdu;
        private System.Windows.Forms.Label label2;
    }
}