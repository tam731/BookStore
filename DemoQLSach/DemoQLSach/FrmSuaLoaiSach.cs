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
    public partial class FrmSuaLoaiSach : Form
    {
        public FrmSuaLoaiSach()
        {
            InitializeComponent();
        }

        private void FrmSuaLoaiSach_Load(object sender, EventArgs e)
        {
            LoaiSach lschon = (LoaiSach)this.Tag;
            txtMa.Text = lschon.MaLoai.ToString();
            txtLoaiSach.Text = lschon.TenLoai;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã loại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLoaiSach.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên loại sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiSach.Focus();
                return;
            }
            try
            {
                QLSachDataContext db = new QLSachDataContext();
                var l = db.LoaiSaches.SingleOrDefault(lo => lo.MaLoai == int.Parse(txtMa.Text));
                l.MaLoai = int.Parse(txtMa.Text);
                l.TenLoai = txtLoaiSach.Text;
                db.SubmitChanges();
                MessageBox.Show("Lưu thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không được sửa mã loại", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
