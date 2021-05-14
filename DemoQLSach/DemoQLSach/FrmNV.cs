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
    public partial class FrmNV : Form
    {
        public FrmNV()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        NhanVIenBUS nvBus = new NhanVIenBUS();
        private void FrmNV_Load(object sender, EventArgs e)
        {
            nvBus.hienthi(dgvNV);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên mật khẩu", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMK.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            // kiem tra trùng tên đăng nhập
            var c = db.NhanViens.Where(nv => nv.TenDN.Trim().ToLower() == txtTenDN.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Tài khoản này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }
            try
            {
                NhanVien nv = new NhanVien();
                nv.TenDN = txtTenDN.Text;
                nv.MatKhau = txtMK.Text;
                nv.TenNV = txtTennv.Text;

                nv.NgaySinh = dateNgaySinh.Value;
                if (radnam.Enabled == true)
                {
                    nv.GioiTinh = "nam";
                }
                else
                {
                    nv.GioiTinh = "nu";
                }
                nv.DiaChi = txtDiaChi.Text;
                nv.SoDienThoai = txtSDT.Text;
                nv.Email = txtEmail.Text;
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
                nvBus.hienthi(dgvNV);
                MessageBox.Show("Thêm thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Clear();
                txtMK.Clear();
                txtTennv.Clear();
                txtDiaChi.Clear();
                txtSDT.Clear();
            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string manv = dgvNV.Rows[e.RowIndex].Cells[0].Value.ToString();
            var nvXS = db.NhanViens.SingleOrDefault(nv => nv.TenDN == manv);
            nvBus.Xoa(e, dgvNV);
            if (e.ColumnIndex == 9)
            {
                Form frm = new FrmSuaNV();
                frm.Tag = nvXS;
                frm.ShowDialog();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            nvBus.Tim(dgvNV, txtTimnv);
        }

        private void FrmNV_Activated(object sender, EventArgs e)
        {
            nvBus.hienthi(dgvNV);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }
        //chi cho nhap so
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
