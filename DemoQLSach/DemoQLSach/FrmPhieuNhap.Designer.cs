namespace DemoQLSach
{
    partial class FrmPhieuNhap
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
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnTongTien = new System.Windows.Forms.Button();
            this.btnMua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvSachMua = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtSl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTenNV = new System.Windows.Forms.ComboBox();
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.dateNgay = new System.Windows.Forms.DateTimePicker();
            this.txtSoPN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachMua)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(359, 319);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(113, 31);
            this.btnHoaDon.TabIndex = 7;
            this.btnHoaDon.Text = "Bảng hóa đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnTongTien
            // 
            this.btnTongTien.Location = new System.Drawing.Point(196, 274);
            this.btnTongTien.Name = "btnTongTien";
            this.btnTongTien.Size = new System.Drawing.Size(85, 26);
            this.btnTongTien.TabIndex = 6;
            this.btnTongTien.Text = "Tổng tiền";
            this.btnTongTien.UseVisualStyleBackColor = true;
            // 
            // btnMua
            // 
            this.btnMua.Location = new System.Drawing.Point(44, 320);
            this.btnMua.Name = "btnMua";
            this.btnMua.Size = new System.Drawing.Size(87, 28);
            this.btnMua.TabIndex = 5;
            this.btnMua.Text = ">>";
            this.btnMua.UseVisualStyleBackColor = true;
            this.btnMua.Click += new System.EventHandler(this.btnMua_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(661, 316);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(116, 32);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // dgvSachMua
            // 
            this.dgvSachMua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachMua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7});
            this.dgvSachMua.Location = new System.Drawing.Point(30, 112);
            this.dgvSachMua.Name = "dgvSachMua";
            this.dgvSachMua.Size = new System.Drawing.Size(680, 155);
            this.dgvSachMua.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã sách : ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(570, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Tổng tiền : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(570, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Đơn giá : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnback);
            this.groupBox2.Controls.Add(this.btnHoaDon);
            this.groupBox2.Controls.Add(this.btnTongTien);
            this.groupBox2.Controls.Add(this.btnMua);
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Controls.Add(this.dgvSachMua);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtTongTien);
            this.groupBox2.Controls.Add(this.txtDonGia);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtMaSach);
            this.groupBox2.Controls.Add(this.txtSl);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTenSach);
            this.groupBox2.Location = new System.Drawing.Point(31, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 356);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết phiếu nhập";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(650, 274);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(149, 22);
            this.txtTongTien.TabIndex = 1;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(650, 24);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(149, 22);
            this.txtDonGia.TabIndex = 1;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(177, 318);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(116, 32);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu hóa đơn";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Số lượng : ";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(119, 30);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(149, 22);
            this.txtMaSach.TabIndex = 1;
            // 
            // txtSl
            // 
            this.txtSl.Location = new System.Drawing.Point(119, 62);
            this.txtSl.Name = "txtSl";
            this.txtSl.Size = new System.Drawing.Size(149, 22);
            this.txtSl.TabIndex = 1;
            this.txtSl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSl_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên sách : ";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(398, 24);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(149, 22);
            this.txtTenSach.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTenNV);
            this.groupBox1.Controls.Add(this.cboMaNCC);
            this.groupBox1.Controls.Add(this.dateNgay);
            this.groupBox1.Controls.Add(this.txtSoPN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(31, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 153);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // cboTenNV
            // 
            this.cboTenNV.FormattingEnabled = true;
            this.cboTenNV.Location = new System.Drawing.Point(121, 113);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.Size = new System.Drawing.Size(149, 23);
            this.cboTenNV.TabIndex = 3;
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Location = new System.Drawing.Point(675, 32);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(149, 23);
            this.cboMaNCC.TabIndex = 3;
            // 
            // dateNgay
            // 
            this.dateNgay.CustomFormat = "dd/MM/yyyy";
            this.dateNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgay.Location = new System.Drawing.Point(121, 71);
            this.dateNgay.Name = "dateNgay";
            this.dateNgay.Size = new System.Drawing.Size(147, 22);
            this.dateNgay.TabIndex = 2;
            // 
            // txtSoPN
            // 
            this.txtSoPN.Location = new System.Drawing.Point(121, 35);
            this.txtSoPN.Name = "txtSoPN";
            this.txtSoPN.Size = new System.Drawing.Size(149, 22);
            this.txtSoPN.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày nhập: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên nhà cung cấp : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tên nhân viên : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số phiếu nhập : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(386, -25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hóa đơn bán sách";
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(506, 320);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(112, 30);
            this.btnback.TabIndex = 9;
            this.btnback.Text = "Quay lại";
            this.btnback.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã sách";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Sách";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Số lượng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Đơn giá";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Thành tiền";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Xóa";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 50;
            // 
            // FrmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 640);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPhieuNhap";
            this.Text = "FrmPhieuNhap";
            this.Load += new System.EventHandler(this.FrmPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachMua)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnTongTien;
        private System.Windows.Forms.Button btnMua;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvSachMua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtSl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTenNV;
        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.DateTimePicker dateNgay;
        private System.Windows.Forms.TextBox txtSoPN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.Button btnback;
    }
}