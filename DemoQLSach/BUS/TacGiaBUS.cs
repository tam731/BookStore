using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class TacGiaBUS
    {
        QLSachDataContext db = new QLSachDataContext();
        //hien thi
        public void hienthi(DataGridView dgvTG)
        {
            dgvTG.Rows.Clear();
            var nvQR = from nv in db.TacGias
                       select new
                       {
                           nv.MaTG,
                           nv.TenTG,
                           nv.SDT,
                           nv.Email
                       };
            foreach (var item in nvQR)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgvTG.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.MaTG;
                dongmoi.Cells[1].Value = item.TenTG;
                dongmoi.Cells[2].Value = item.SDT;
                dongmoi.Cells[3].Value = item.Email;
                dongmoi.Cells[4].Value = "Xoa";
                dongmoi.Cells[5].Value = "Sua";
                dgvTG.Rows.Add(dongmoi);
            }
        }

        //xóa
        public void Xoa(DataGridViewCellEventArgs e,DataGridView dgv)
        {
            int matg = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            var nvXS = db.TacGias.SingleOrDefault(nv => nv.MaTG == matg);
            if (e.ColumnIndex == 4)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    try
                    {
                        db.TacGias.DeleteOnSubmit(nvXS);
                        db.SubmitChanges();
                        MessageBox.Show("Xoa Thanh cong", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        hienthi(dgv);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Xóa thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            
        }

        //Tìm
        public void Tim(EventArgs e, DataGridView dgv,TextBox t)
        {
            dgv.Rows.Clear();
            var timKiemQuery = db.TacGias.Where(nv => nv.TenTG.Contains(t.Text)).ToList();
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
                        dongmoi.Cells[0].Value = item.MaTG;
                        dongmoi.Cells[1].Value = item.TenTG;
                        dongmoi.Cells[2].Value = item.SDT;
                        dongmoi.Cells[3].Value = item.Email;
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
