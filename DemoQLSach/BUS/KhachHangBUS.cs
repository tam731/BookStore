using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;


namespace BUS
{
    public class KhachHangBUS
    {
        QLSachDataContext db = new QLSachDataContext();

        //hien thi
        public void hienthi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var nvQR = from nv in db.Khachhangs
                       select new
                       {
                           nv.MaKH,
                           nv.TenKH,
                           nv.GioiTinh,
                           nv.DiaChi,
                           nv.SDT,
                           nv.Email
                       };
            foreach (var item in nvQR)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgv.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.MaKH;
                dongmoi.Cells[1].Value = item.TenKH;
                dongmoi.Cells[2].Value = item.GioiTinh;
                dongmoi.Cells[3].Value = item.DiaChi;
                dongmoi.Cells[4].Value = item.SDT;
                dongmoi.Cells[5].Value = item.Email;
                dongmoi.Cells[6].Value = "Xoa";
                dongmoi.Cells[7].Value = "Sua";
                dgv.Rows.Add(dongmoi);
            }
        }

        //Xoa
        public void Xoa(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            string manv = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            var nvXS = db.Khachhangs.SingleOrDefault(nv => nv.MaKH == manv);
            if (e.ColumnIndex == 6)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    db.Khachhangs.DeleteOnSubmit(nvXS);
                    db.SubmitChanges();
                    MessageBox.Show("Xoa Thanh cong", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    hienthi(dgv);
                }
            }
        }

        //Tim
        public void Tim(DataGridView dgv,TextBox t)
        {
            dgv.Rows.Clear();
            var timKiemQuery = db.Khachhangs.Where(nv => nv.TenKH.Contains(t.Text)).ToList();
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
                        dongmoi.Cells[0].Value = item.MaKH;
                        dongmoi.Cells[1].Value = item.TenKH;
                        dongmoi.Cells[2].Value = item.GioiTinh;
                        dongmoi.Cells[3].Value = item.DiaChi;
                        dongmoi.Cells[4].Value = item.SDT;
                        dongmoi.Cells[5].Value = item.Email;
                        dongmoi.Cells[6].Value = "Xóa";
                        dongmoi.Cells[7].Value = "Sửa";
                        dgv.Rows.Add(dongmoi);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Lỗi : " + e1.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Mã khách hàng tự tăng
      
    }
        
}
