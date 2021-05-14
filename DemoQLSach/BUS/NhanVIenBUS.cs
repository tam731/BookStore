using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{

    public class NhanVIenBUS
    {
        QLSachDataContext db = new QLSachDataContext();
        //hienthi
        public void hienthi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var nvQR = from nv in db.NhanViens
                       select new
                       {
                           nv.TenDN,
                           nv.MatKhau,
                           nv.TenNV,
                           nv.NgaySinh,
                           nv.GioiTinh,
                           nv.DiaChi,
                           nv.SoDienThoai,
                           nv.Email
                       };
            foreach (var item in nvQR)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgv.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.TenDN;
                dongmoi.Cells[1].Value = item.MatKhau;
                dongmoi.Cells[2].Value = item.TenNV;
                dongmoi.Cells[3].Value = item.NgaySinh;
                dongmoi.Cells[4].Value = item.GioiTinh;
                dongmoi.Cells[5].Value = item.DiaChi;
                dongmoi.Cells[6].Value = item.SoDienThoai;
                dongmoi.Cells[7].Value = item.Email;
                dongmoi.Cells[8].Value = "Xoa";
                dongmoi.Cells[9].Value = "Sua";
                dgv.Rows.Add(dongmoi);
            }
           
        }

        //Xóa
        public void Xoa(DataGridViewCellEventArgs e,DataGridView dgv)
        {
            string manv = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            var nvXS = db.NhanViens.SingleOrDefault(nv => nv.TenDN == manv);
            if (e.ColumnIndex == 8)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    db.NhanViens.DeleteOnSubmit(nvXS);
                    db.SubmitChanges();
                    MessageBox.Show("Xoa Thanh cong", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    hienthi(dgv);
                }
            }
        }

        //Tìm
        public void Tim( DataGridView dgv,TextBox t)
        {
            dgv.Rows.Clear();
            var timKiemQuery = db.NhanViens.Where(nv => nv.TenNV.Contains(t.Text)).ToList();
            if (timKiemQuery.Count() == 0)
            {
                MessageBox.Show("Không có nhân viên nào chứa chuỗi" + t.Text);
            }
            else
            {
                foreach (var item in timKiemQuery)
                {
                    try
                    {
                        DataGridViewRow dongmoi = (DataGridViewRow)dgv.Rows[0].Clone();
                        dongmoi.Cells[0].Value = item.TenDN;
                        dongmoi.Cells[1].Value = item.MatKhau;
                        dongmoi.Cells[2].Value = item.TenNV;
                        dongmoi.Cells[3].Value = item.NgaySinh;
                        dongmoi.Cells[4].Value = item.GioiTinh;
                        dongmoi.Cells[5].Value = item.DiaChi;
                        dongmoi.Cells[6].Value = item.SoDienThoai;
                        dongmoi.Cells[7].Value = item.Email;
                        dongmoi.Cells[8].Value = "Xoa";
                        dongmoi.Cells[9].Value = "Sua";
                        dgv.Rows.Add(dongmoi);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Lỗi : " + e1.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
