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
    public partial class FrmSuaNCC : Form
    {
        public FrmSuaNCC()
        {
            InitializeComponent();
        }
        
        private void FrmSuaNCC_Load(object sender, EventArgs e)
        {

            NhaCungCap nvChon = (NhaCungCap)this.Tag;
            txtMaNCC.Text = nvChon.MaNCC.ToString();
            txtTenNCC.Text = nvChon.TenNCC.Trim();
            txtSDT.Text = nvChon.SDT.Trim();
            txtDC.Text = nvChon.Diachi.Trim();
            txtEmail.Text = nvChon.Email.Trim();
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDC.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDC.Focus();
                return;
            }
            try
            {
                QLSachDataContext db = new QLSachDataContext();
                NhaCungCap nvSua = db.NhaCungCaps.SingleOrDefault(nv => nv.MaNCC == int.Parse(txtMaNCC.Text));
                nvSua.MaNCC = int.Parse(txtMaNCC.Text);
                nvSua.TenNCC = txtTenNCC.Text;
                nvSua.SDT = txtSDT.Text;
                nvSua.Diachi = txtDC.Text;
                db.SubmitChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           catch(Exception e1)
            {
                MessageBox.Show("Lỗi truy vấn SQL : " + e1.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            BatLoiBUS bl = new BatLoiBUS();
            bl.NhapSo(sender, e);
        }
    }
}
