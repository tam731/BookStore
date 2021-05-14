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
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        KhachHangBUS khbus = new KhachHangBUS();
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            khbus.hienthi(dgvNV);
        }
        string makh;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenkh.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Khách hàng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
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
                MessageBox.Show("Vui lòng nhập email", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            try
            {
                
                //ma tu tang
                int count = 0;
                count = dgvNV.Rows.Count;
                //dem tat ca cac dong  trong datagridview roi dem gan cho count
                string chuoi1 = "";
                int chuoi2 = 0;
                chuoi1 = Convert.ToString(dgvNV.Rows[count - 2].Cells[0].Value);
                chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));
                if (chuoi2 + 1 < 10)
                    makh = "KH00" + (chuoi2 + 1).ToString();
                else if (chuoi2 + 1 < 100)
                    makh = "KH0" + (chuoi2 + 1).ToString();
                Khachhang nv = new Khachhang();
                nv.MaKH = makh;
                nv.TenKH = txtTenkh.Text;

                if (radnam.Enabled == true)
                {
                    nv.GioiTinh = "nam";
                }
                else
                {
                    nv.GioiTinh = "nu";
                }
                nv.DiaChi = txtDiaChi.Text;
                nv.SDT = txtSDT.Text;
                nv.Email = txtEmail.Text;
                db.Khachhangs.InsertOnSubmit(nv);
               
                db.SubmitChanges();
                khbus.hienthi(dgvNV);
                MessageBox.Show("Thêm thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtTenkh.Text= txtDiaChi.Text= txtSDT.Text=txtEmail.Text=null;
            }
            catch (Exception e1)
            {
               
                MessageBox.Show("Lỗi ngoại lệ: " + e1.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string manv = dgvNV.Rows[e.RowIndex].Cells[0].Value.ToString();
            var nvXS = db.Khachhangs.SingleOrDefault(nv => nv.MaKH == manv);
            khbus.Xoa(e, dgvNV);
        
                
            if (e.ColumnIndex == 7)
            {
                FrmSuaKH frm = new FrmSuaKH();
                frm.Tag = nvXS;
                frm.ShowDialog();
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            khbus.Tim(dgvNV, txtTimkh);

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void FrmKhachHang_Activated(object sender, EventArgs e)
        {
            khbus.hienthi(dgvNV);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            FrmKhachHang f = new FrmKhachHang();
            f.Show();
            this.Hide();
        }
    }
}
