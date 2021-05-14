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
    public partial class FrmSach : Form
    {
        public FrmSach()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        private void FrmSach_Load(object sender, EventArgs e)
        {
            hienthi(dgrdSach);
            LoadCoboboxLoaiS(cboLoai);
            LoadCoboboxTG(cboTG);
            LoadCoboboxNXB(cboTenNXb);

        }
        public void hienthi(DataGridView data)
        {
            dgrdSach.Rows.Clear();
            var sachqr = from s in db.Saches
                         select new
                         {
                             s.MaSach,
                             s.TenSach,
                             s.LoaiSach.TenLoai,
                             s.TacGia.TenTG,
                             s.NXB.TenNXB,
                             s.DonViTinh,
                             s.Soluong,
                             s.DonGia
                         };
            foreach (var item in sachqr)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgrdSach.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.MaSach;
                dongmoi.Cells[1].Value = item.TenSach;
                dongmoi.Cells[2].Value = item.TenLoai;
                dongmoi.Cells[3].Value = item.TenTG;
                dongmoi.Cells[4].Value = item.TenNXB;
                dongmoi.Cells[5].Value = item.DonViTinh;
                dongmoi.Cells[6].Value = item.Soluong;
                dongmoi.Cells[7].Value = item.DonGia;
                dongmoi.Cells[8].Value = "Xóa";
                dongmoi.Cells[9].Value = "Sửa";
                dgrdSach.Rows.Add(dongmoi);

            }

        }
        public void LoadCoboboxLoaiS(ComboBox cbo)
        {
            var cbotensach = from tg in db.LoaiSaches
                             select tg;
            cbo.DataSource = cbotensach;
            cbo.DisplayMember = "TenLoai";
            cbo.ValueMember = "MaLoai";
            cbo.SelectedIndex = -1;
        }
        public void LoadCoboboxTG(ComboBox cbo)
        {
            var cbotg = db.TacGias.ToList();
            cbo.DataSource = cbotg;
            cbo.DisplayMember = "TenTG";
            cbo.ValueMember = "MaTG";
            cbo.SelectedIndex = -1;

        }
        public void LoadCoboboxNXB(ComboBox cbo)
        {
            var cbotg = db.NXBs.ToList();
            cbo.DataSource = cbotg;
            cbo.DisplayMember = "TenNXB";
            cbo.ValueMember = "MaNXB";
            cbo.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã sách", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSach.Focus();
                return;

            }
            if (string.IsNullOrEmpty(txtTenSach.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sách", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;

            }
            if (cboLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại sách", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (cboTG.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn tác giả", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (cboTenNXb.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (string.IsNullOrEmpty(txtSL.Text)||int.Parse(txtSL.Text)<0)
            {
                MessageBox.Show("Số lượng sách phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSL.Focus();
                return;

            }
            if (string.IsNullOrEmpty(txtDonGia.Text)||int.Parse(txtDonGia.Text)<0)
            {
                MessageBox.Show("Dơn giá sách phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;

            }
            try
            {
                Sach nv = new Sach();
                nv.MaSach = txtMaSach.Text;
                nv.TenSach = txtTenSach.Text;
                nv.MaLoai = int.Parse(cboLoai.SelectedValue.ToString());
                nv.MaTG = int.Parse(cboTG.SelectedValue.ToString());
                nv.MaNXB = int.Parse(cboTenNXb.SelectedValue.ToString());

                if (radQuyen.Enabled == true)
                {
                    nv.DonViTinh = "Quyển";
                }
                else
                {
                    nv.DonViTinh = "Bộ";

                }
                nv.Soluong = int.Parse(txtSL.Text);
                nv.DonGia = int.Parse(txtDonGia.Text);
                db.Saches.InsertOnSubmit(nv);
                db.SubmitChanges();
                hienthi(dgrdSach);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trùng lặp mã nhân viên" + ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgrdSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mas = dgrdSach.Rows[e.RowIndex].Cells[0].Value.ToString();
            Sach nvSuaXoa = db.Saches.SingleOrDefault(nv => nv.MaSach == mas);
            if (e.ColumnIndex == 8)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    db.Saches.DeleteOnSubmit(nvSuaXoa);
                    db.SubmitChanges();
                    hienthi(dgrdSach);
                    MessageBox.Show("Xoa Thanh cong", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (e.ColumnIndex == 9)
            {
                Form frm = new FrmSuaSach();
                frm.Tag = nvSuaXoa;
                frm.ShowDialog();
            }


        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgrdSach.Rows.Clear();
            var timKiemQuery = from s in db.Saches
                               where s.TenSach.Contains(txtTimSach.Text)
                               select new
                               {
                                   s.MaSach,
                                   s.TenSach,
                                   s.LoaiSach.TenLoai,
                                   s.TacGia.TenTG,
                                   s.NXB.TenNXB,
                                   s.DonViTinh,
                                   s.Soluong,
                                   s.DonGia
                               };
            if (timKiemQuery.Count() == 0)
            {
                MessageBox.Show("Không có nhân viên nào chứa chuỗi" + txtTimSach.Text);
            }
            else
            {
                foreach (var item in timKiemQuery)
                {
                    try
                    {
                        DataGridViewRow dongmoi = (DataGridViewRow)dgrdSach.Rows[0].Clone();

                        dongmoi.Cells[0].Value = item.MaSach;
                        dongmoi.Cells[1].Value = item.TenSach;
                        dongmoi.Cells[2].Value = item.TenLoai;
                        dongmoi.Cells[3].Value = item.TenTG;
                        dongmoi.Cells[4].Value = item.TenNXB;
                        dongmoi.Cells[5].Value = item.DonViTinh;
                        dongmoi.Cells[6].Value = item.Soluong;
                        dongmoi.Cells[7].Value = item.DonGia;
                        dongmoi.Cells[8].Value = "Xóa";
                        dongmoi.Cells[9].Value = "Sửa";
                        dgrdSach.Rows.Add(dongmoi);
                        hienthi(dgrdSach);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Lỗi : " + e1.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        private void FrmSach_Activated(object sender, EventArgs e)
        {
            hienthi(dgrdSach);
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
