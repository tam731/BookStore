using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;

namespace DemoQLSach
{
    public partial class FrmPhieuNhap : Form
    {
        public FrmPhieuNhap()
        {
            InitializeComponent();

        }
        QLSachDataContext db = new QLSachDataContext();
        PhieuNhapBUS pnBus = new PhieuNhapBUS();
        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {
            pnBus.loadcboNV(cboTenNV);
            pnBus.loadcbo_NCC(cboMaNCC);
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPN.Text))
            {
                MessageBox.Show("Vui lòng nhập tên số phiếu nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPN.Focus();
                return;
            }
            if (cboMaNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhà cung cấp ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (cboTenNV.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhân viên ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sách", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSach.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSl.Text)||int.Parse(txtSl.Text)<0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSl.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text)||int.Parse(txtDonGia.Text)<0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }
            var c = db.PhieuNhaps.Where(h => h.SoPN.Trim().ToLower() == txtSoPN.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show(" Số PN này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPN.Focus();
                return;
            }
            try
            {
                var b = db.Saches.Where(h => h.MaSach.Trim().ToLower() == txtMaSach.Text.Trim().ToLower()).Count();
                if (b < 0)
                {
                    MessageBox.Show(" Mã sách không có trong cơ sỏ dũ liệu", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSach.Focus();
                    return;
                }
                DataGridViewRow dongMoi =
              (DataGridViewRow)dgvSachMua.Rows[0].Clone();
                //Thêm dữ liệu cho 1 dòng
                dongMoi.Cells[0].Value = txtMaSach.Text;
                dongMoi.Cells[1].Value = txtTenSach.Text;
                dongMoi.Cells[2].Value = txtSl.Text;
                dongMoi.Cells[3].Value = txtDonGia.Text;
                double t = int.Parse(txtSl.Text) * int.Parse(txtDonGia.Text);
                dongMoi.Cells[4].Value = t.ToString("N0");
                dongMoi.Cells[5].Value = "Xóa";
                dgvSachMua.Rows.Add(dongMoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn : " + ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPN.Text))
            {
                MessageBox.Show("Vui lòng nhập tên số phiếu nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPN.Focus();
                return;
            }
            if (cboMaNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhà cung cấp ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (cboTenNV.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhân viên ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var c = db.PhieuNhaps.Where(h => h.SoPN.Trim().ToLower() == txtSoPN.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show(" Số PN này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPN.Focus();
                return;
            }
            PhieuNhap hoaDonMoi = new PhieuNhap();
            hoaDonMoi.SoPN = txtSoPN.Text;
            hoaDonMoi.MaNCC = int.Parse(cboMaNCC.SelectedValue.ToString());
            hoaDonMoi.NhanVienNhap = cboTenNV.SelectedValue.ToString();
            hoaDonMoi.NgayNhap = DateTime.Now;

            db.PhieuNhaps.InsertOnSubmit(hoaDonMoi);

            //thêm các hóa đơn chi tiết trong data gridview
            for (int i = 0; i < dgvSachMua.RowCount - 1; i++)
            {
                ChiTietPhieuNhap hdct = new ChiTietPhieuNhap();
                hdct.SoPN = hoaDonMoi.SoPN;
                hdct.MaSach = dgvSachMua.Rows[i].Cells[0].Value.ToString();
                hdct.SoLuongN = Convert.ToInt32(dgvSachMua.Rows[i].Cells[2].Value);
                hdct.DongiaN = Convert.ToInt32(dgvSachMua.Rows[i].Cells[3].Value);
            
                //Thêm vào hóa đơn mới
                hoaDonMoi.ChiTietPhieuNhaps.Add(hdct);
                db.ChiTietPhieuNhaps.InsertOnSubmit(hdct);
                db.SubmitChanges();
            }

            MessageBox.Show("Lưu  thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtSl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
