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
    public partial class FrmSuaTG : Form
    {
        public FrmSuaTG()
        {
            InitializeComponent();
        }

        private void FrmSuaTG_Load(object sender, EventArgs e)
        {
            TacGia nvChon = (TacGia)this.Tag;
            txtMaTG.Text = nvChon.MaTG.ToString();
            txtTenTG.Text = nvChon.TenTG;
            txtSDT.Text = nvChon.SDT;
            txtEmail.Text = nvChon.Email;
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTG.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Tác giả", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTG.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Email", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            try
            {
                QLSachDataContext db = new QLSachDataContext();
                TacGia nvSua = db.TacGias.SingleOrDefault(nv => nv.MaTG == int.Parse(txtMaTG.Text));
                nvSua.MaTG = int.Parse(txtMaTG.Text);
                nvSua.TenTG = txtTenTG.Text;
                nvSua.SDT = txtSDT.Text;
                nvSua.Email = txtEmail.Text;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Sửa thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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
