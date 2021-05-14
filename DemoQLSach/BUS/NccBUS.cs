using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class NccBUS
    {
        QLSachDataContext db = new QLSachDataContext();

        //hien thi
        public void hienthi(DataGridView dgvNCC)
        {
            dgvNCC.Rows.Clear();
            var nvQR = db.NhaCungCaps.ToList();
            foreach (var item in nvQR)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgvNCC.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.MaNCC;
                dongmoi.Cells[1].Value = item.TenNCC;
                dongmoi.Cells[2].Value = item.SDT;
                dongmoi.Cells[3].Value = item.Diachi;
                dongmoi.Cells[4].Value = item.Email;
                dongmoi.Cells[5].Value = "Xoa";
                dongmoi.Cells[6].Value = "Sua";
                dgvNCC.Rows.Add(dongmoi);
            }
        }
        //xóa và form sửa
        public void xoa(object sender, DataGridViewCellEventArgs e,DataGridView dgv)
        {
            int mancc = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            var nvXS = db.NhaCungCaps.SingleOrDefault(nv => nv.MaNCC == mancc);
            if (e.ColumnIndex == 5)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    db.NhaCungCaps.DeleteOnSubmit(nvXS);
                    db.SubmitChanges();
                    MessageBox.Show("Xoa Thanh cong", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    hienthi(dgv);
                }
            }
           
        }

        //Tìm
        public void Tim(object sender, EventArgs e,DataGridView dgv, TextBox t)
        {
            dgv.Rows.Clear();
            var timKiemQuery = db.NhaCungCaps.Where(nv => nv.TenNCC.Contains(t.Text)).ToList();
            if (string.IsNullOrEmpty(t.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu tìm kiếm", "Informaition", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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
                            dongmoi.Cells[0].Value = item.MaNCC;
                            dongmoi.Cells[1].Value = item.TenNCC;
                            dongmoi.Cells[2].Value = item.SDT;
                            dongmoi.Cells[3].Value = item.Diachi;

                            dongmoi.Cells[4].Value = "Xoa";
                            dongmoi.Cells[5].Value = "Sua";
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
}
