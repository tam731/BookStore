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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            QLSachDataContext db = new QLSachDataContext();
            NhanVien ndHienTai = db.NhanViens.SingleOrDefault(
                nd => nd.TenDN == txt_TaiKhoan.Text &&
                nd.MatKhau == txtMatKhau.Text);
           
            if (ndHienTai != null)
            {
                FrmMain frm = new FrmMain();
                frm.Tag = ndHienTai;
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Tên đăng nhập và (hoặc) mật khẩu sai");
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
