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

namespace DemoQLSach
{
    public partial class FrmSuaNV : Form
    {
        public FrmSuaNV()
        {
            InitializeComponent();
        }

        private void FrmSuaNV_Load(object sender, EventArgs e)
        {

            NhanVien nvChon = (NhanVien)this.Tag;
            txtMK.Text = nvChon.MatKhau;
            txtTennv.Text = nvChon.TenNV.Trim();
            txtTenDN.Text = nvChon.TenDN;
            dateNgaySinh.Value = nvChon.NgaySinh.Value;
            txtGioiTinh.Text = nvChon.GioiTinh.Trim();
            txtDiaChi.Text = nvChon.DiaChi.Trim();
            txtSDT.Text = nvChon.SoDienThoai.Trim();
            txtEmail.Text = nvChon.Email.Trim();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

                    QLSachDataContext db = new QLSachDataContext();
                    NhanVien nvSua = db.NhanViens.SingleOrDefault(nv => nv.TenDN == txtTenDN.Text);
                    nvSua.MatKhau = txtMK.Text;
                    nvSua.TenNV = txtTennv.Text;
                    nvSua.TenDN = txtTenDN.Text;
                    nvSua.NgaySinh = dateNgaySinh.Value;
                    nvSua.GioiTinh = txtGioiTinh.Text;
                    nvSua.DiaChi = txtDiaChi.Text;
                    nvSua.SoDienThoai = txtSDT.Text;
                    nvSua.Email = txtEmail.Text;
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
