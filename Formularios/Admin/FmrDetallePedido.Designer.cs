namespace Minimercados_Unidos
{
    partial class FmrDetallePedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrDetallePedido));
            this.DtgDetallePedido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgDetallePedido
            // 
            this.DtgDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetallePedido.Location = new System.Drawing.Point(12, 124);
            this.DtgDetallePedido.Name = "DtgDetallePedido";
            this.DtgDetallePedido.Size = new System.Drawing.Size(888, 451);
            this.DtgDetallePedido.TabIndex = 0;
            // 
            // FmrDetallePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 658);
            this.Controls.Add(this.DtgDetallePedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmrDetallePedido";
            this.Text = "FmrDetallePedido";
            this.Load += new System.EventHandler(this.FmrDetallePedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetallePedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgDetallePedido;
    }
}