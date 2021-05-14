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
    public partial class FrmSuaKH : Form
    {
        public FrmSuaKH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLSachDataContext db = new QLSachDataContext();
            Khachhang nvSua = db.Khachhangs.SingleOrDefault(nv => nv.MaKH == txtMakh.Text);
           
            nvSua.MaKH = txtMakh.Text;
            nvSua.TenKH = txtTenkh.Text.Trim();
            nvSua.GioiTinh = txtgt.Text.Trim();
            
            nvSua.DiaChi = txtDiaChi.Text.Trim();
            nvSua.SDT = txtSDT.Text.Trim();
            nvSua.Email = txtEmail.Text.Trim();
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void FrmSuaKH_Load(object sender, EventArgs e)
        {
            Khachhang nvChon = (Khachhang)this.Tag;
            txtMakh.Text = nvChon.MaKH;
            txtTenkh.Text = nvChon.TenKH.Trim();
            txtgt.Text = nvChon.GioiTinh.Trim();
            txtDiaChi.Text = nvChon.DiaChi.Trim();
            txtSDT.Text = nvChon.SDT.Trim();
            
        }

        private void button2_Click(object sender, EventArgs e)
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
