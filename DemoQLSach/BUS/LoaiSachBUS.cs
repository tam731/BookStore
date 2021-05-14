using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;


namespace BUS
{
    public class LoaiSachBUS
    {
        QLSachDataContext db = new QLSachDataContext();
        // hiển thị
        public void hienthi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var ls = from l in db.LoaiSaches
                     select new
                     {
                         l.MaLoai,
                         l.TenLoai
                     };
            foreach (var item in ls)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgv.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.MaLoai;
                dongmoi.Cells[1].Value = item.TenLoai;
                dongmoi.Cells[2].Value = "Xoa";
                dongmoi.Cells[3].Value = "Sua";
                dgv.Rows.Add(dongmoi);
            }
        }

        //Xóa
        public void Xoa(DataGridViewCellEventArgs e,DataGridView dgv)
        {
            int maloai = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            var lsSuaXoa = db.LoaiSaches.SingleOrDefault(s => s.MaLoai == maloai);
            if (e.ColumnIndex == 2)
            {
                try
                {
                    db.LoaiSaches.DeleteOnSubmit(lsSuaXoa);
                    db.SubmitChanges();
                    hienthi(dgv);
                }
                catch (Exception)
                {
                    //lỗi khi  sách đang tham chiếu đến loại sách  thì sẽ không xóa được(quan hệ 1-n)=> TH catch
                    MessageBox.Show("Xóa Loại phòng thất bại ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //Tìm

    }
}
