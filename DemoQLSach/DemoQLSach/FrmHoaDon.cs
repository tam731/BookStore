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
    public partial class FrmHoaDon : Form
    {
        public FrmHoaDon()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        HoaDonBus hdbus = new HoaDonBus();
        string sohd;
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            hdbus.loadcboKH(cboMaKH);
            hdbus.loadcbonv(cboTenNV);
            cboHTT.DataSource = new List<string>() { "Tiền mặt", "Quẹt thẻ" };
            cboHTT.SelectedIndex = -1;
           


        }

        private void txtMaSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sach hangMua = (from sp in db.Saches
                                   where sp.MaSach == txtMaSach.Text
                                   select sp).SingleOrDefault();
                if (hangMua != null)
                {
                    txtTenSach.Text = hangMua.TenSach;
                   
                    txtDonGia.Text = hangMua.DonGia.ToString();
                }
                else
                {
                    MessageBox.Show("Mã sách sai.");
                }
            }
        }
       
        private void btnMua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSoHD.Text))
            {
                MessageBox.Show("Vui lòng nhập tên số hóa đơn", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Focus();
                return;
            }
            if (cboMaKH.SelectedIndex<0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên khách hàng ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
            if (cboTenNV.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhân viên ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (cboHTT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhân viên ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            var c = db.HoaDons.Where(h => h.SoHD.Trim().ToLower() == txtSoHD.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Số hóa đơn này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Focus();
                return;
            }
            try
            {
                DataGridViewRow dongMoi =
              (DataGridViewRow)dgvSachMua.Rows[0].Clone();
                //Thêm dữ liệu cho 1 dòng
                dongMoi.Cells[0].Value = txtMaSach.Text;
                dongMoi.Cells[1].Value = txtTenSach.Text;
                dongMoi.Cells[2].Value = txtSl.Text;
                dongMoi.Cells[3].Value = txtDonGia.Text;
                dongMoi.Cells[4].Value = txtGiamGia.Text;
                double t = int.Parse(txtSl.Text) * int.Parse(txtDonGia.Text);
                double g = (double)(t - (double)(t * int.Parse(txtGiamGia.Text) / 100));
                dongMoi.Cells[5].Value = g.ToString("N0");
                dongMoi.Cells[6].Value = "Xóa";
                dgvSachMua.Rows.Add(dongMoi);
            }
           catch(Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn : " + ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHD.Text))
            {
                MessageBox.Show("Vui lòng nhập tên số hóa đơn", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Focus();
                return;
            }
            if (cboMaKH.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên khách hàng ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (cboTenNV.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhân viên ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (cboHTT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập chọn tên nhân viên ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            var c = db.HoaDons.Where(h => h.SoHD.Trim().ToLower() == txtSoHD.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Số hóa đơn này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Focus();
                return;
            }
            HoaDon hoaDonMoi = new HoaDon();
            hoaDonMoi.SoHD = txtSoHD.Text;
            hoaDonMoi.MaKH = cboMaKH.SelectedValue.ToString();
            hoaDonMoi.TenDN = cboTenNV.SelectedValue.ToString();
            hoaDonMoi.NgayLap = DateTime.Now;
            hoaDonMoi.HinhThucTT = cboHTT.SelectedValue.ToString();
        
            db.HoaDons.InsertOnSubmit(hoaDonMoi);
            
            //thêm các hóa đơn chi tiết trong data gridview
            for (int i = 0; i < dgvSachMua.RowCount - 1; i++)
            {
                ChiTietHoaDon hdct = new ChiTietHoaDon();
                hdct.SoHD = hoaDonMoi.SoHD;
                hdct.MaSach =dgvSachMua.Rows[i].Cells[0].Value.ToString();
                hdct.SLMua = Convert.ToInt32(dgvSachMua.Rows[i].Cells[2].Value);
                hdct.DonGia = Convert.ToInt32(dgvSachMua.Rows[i].Cells[3].Value);
                hdct.GiamGia = Convert.ToInt32(txtGiamGia.Text);
                
                //Thêm vào hóa đơn mới
                hoaDonMoi.ChiTietHoaDons.Add(hdct);
                db.ChiTietHoaDons.InsertOnSubmit(hdct);
                db.SubmitChanges();
            }
            
            MessageBox.Show("Lưu hóa đơn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
           

        }

        private void dgvSachMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
                dgvSachMua.Rows.RemoveAt(e.RowIndex);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
      
       
        private void cboMaKH_SelectedValueChanged(object sender, EventArgs e)
        {
            
           
        }
        public double tinhtongTien()
        {
            int a=0;
            for (int i = 0; i < dgvSachMua.RowCount - 1; i++)
            {
                a += Convert.ToInt32(dgvSachMua.Rows[i].Cells[5].Value);

            }
            return a;
        }
        private void btnTongTien_Click(object sender, EventArgs e)
        {
            txtTongTien.Text = tinhtongTien().ToString("N0");
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDonCTHD f = new FrmHoaDonCTHD();
            f.ShowDialog();
            this.Hide();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }

        private void txtSl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
