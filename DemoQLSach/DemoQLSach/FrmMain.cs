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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        private void SachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSach frm = new FrmSach();
            frm.ShowDialog();
            this.Hide();
        }

        private void NhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNV frm = new FrmNV();
            frm.ShowDialog();
            this.Hide();
        }

        private void NCCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNCC frm = new FrmNCC();
            frm.ShowDialog();
            this.Hide();
        }

        private void TacGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTacGia frm = new FrmTacGia();
            frm.ShowDialog();
            this.Hide();
        }

        private void HoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {


            FrmHoaDon frm = new FrmHoaDon();
           
            frm.Show();
            this.Hide();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void KhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            FrmKhachHang f = new FrmKhachHang();
            f.Show();
            this.Hide();
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }

        private void LoaiSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoaiSach f = new FrmLoaiSach();
            f.Show();
            this.Hide();
        }

        private void lậpPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhieuNhap f = new FrmPhieuNhap();
            f.Show();
            this.Hide();
        }

        private void InHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoaDonCTHD f = new FrmHoaDonCTHD();
            f.Show();
            this.Hide();

        }
    }
}
