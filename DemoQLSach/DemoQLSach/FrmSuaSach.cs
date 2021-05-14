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
    public partial class FrmSuaSach : Form
    {
        public FrmSuaSach()
        {
            InitializeComponent();
        }

        private void FrmSuaSach_Load(object sender, EventArgs e)
        {
            Sach nv = (Sach)this.Tag;
            txtMaSach.Text = nv.MaSach.Trim();
            txtTenSach.Text = nv.TenSach.Trim();
            txtMaloai.Text = nv.MaLoai.ToString().Trim();
            txtMaTG.Text = nv.MaTG.ToString().Trim();
            txtManxb.Text = nv.MaNXB.ToString().Trim();

            txtDVT.Text = nv.DonViTinh.Trim();
            txtSL.Text = nv.Soluong.ToString().Trim();
            txtDonGia.Text = nv.DonGia.ToString().Trim();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            QLSachDataContext db = new QLSachDataContext();
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtSL.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("vui long nhập đầy đủ dữ liệu", "waning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    Sach nv = db.Saches.SingleOrDefault(n => n.MaSach == txtMaSach.Text);
                    nv.MaSach = txtMaSach.Text;
                    nv.TenSach = txtTenSach.Text;
                    nv.MaLoai = int.Parse(txtMaloai.Text);
                    nv.MaTG = int.Parse(txtMaTG.Text);
                    nv.MaNXB = int.Parse(txtManxb.Text);
                    nv.DonViTinh = txtDVT.Text;
                    nv.Soluong = int.Parse(txtSL.Text);
                    nv.DonGia = int.Parse(txtDonGia.Text);
                    db.SubmitChanges();

                    MessageBox.Show("sửa  thành công");
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Trùng lặp mã nhân sách " + ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
