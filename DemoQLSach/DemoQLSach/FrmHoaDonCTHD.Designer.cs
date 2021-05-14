namespace DemoQLSach
{
    partial class FrmHoaDonCTHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoaDonCTHD));
            this.dgvHd = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printPreviewDialogHD = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentHD = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHd
            // 
            this.dgvHd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvHd.Location = new System.Drawing.Point(48, 106);
            this.dgvHd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHd.Name = "dgvHd";
            this.dgvHd.Size = new System.Drawing.Size(549, 268);
            this.dgvHd.TabIndex = 0;
            this.dgvHd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHd_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hóa đơn";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã hóa đơn";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Khách hàng";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên nhân viên";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngàu lập";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Hình thức thanh toán";
            this.Column5.Name = "Column5";
            // 
            // printPreviewDialogHD
            // 
            this.printPreviewDialogHD.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogHD.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogHD.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialogHD.Enabled = true;
            this.printPreviewDialogHD.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialogHD.Icon")));
            this.printPreviewDialogHD.Name = "printPreviewDialogHD";
            this.printPreviewDialogHD.Visible = false;
            // 
            // printDocumentHD
            // 
            this.printDocumentHD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentHD_PrintPage);
            // 
            // FrmHoaDonCTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmHoaDonCTHD";
            this.Text = "FrmHoaDonCTHD";
            this.Load += new System.EventHandler(this.FrmHoaDonCTHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogHD;
        private System.Drawing.Printing.PrintDocument printDocumentHD;
    }
}