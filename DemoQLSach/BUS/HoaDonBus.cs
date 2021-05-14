using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class HoaDonBus
    {
        QLSachDataContext db = new QLSachDataContext();

      
      
        public void loadcboKH(ComboBox cbo)
        {
            cbo.DataSource = db.Khachhangs.ToList();
            cbo.DisplayMember = "TenKH";
            cbo.ValueMember = "MaKH";
            cbo.SelectedIndex = -1;
        }
        public void loadcbonv(ComboBox cbo)
        {
            cbo.DataSource = db.NhanViens.ToList();
            cbo.DisplayMember = "TenNV";
            cbo.ValueMember = "TenDN";
            cbo.SelectedIndex = -1;
        }
        //hien thi
        public void hienthiHD(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var nvQR = from nv in db.HoaDons
                       select new
                       {
                           nv.SoHD,
                           nv.Khachhang.TenKH,
                           nv.NhanVien.TenNV,
                           nv.NgayLap,
                           nv.HinhThucTT
                       };
            foreach (var item in nvQR)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dgv.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.SoHD;
                dongmoi.Cells[1].Value = item.TenKH;
                dongmoi.Cells[2].Value = item.TenNV;
                dongmoi.Cells[3].Value = item.NgayLap;
                dongmoi.Cells[4].Value = item.HinhThucTT;
               
                dgv.Rows.Add(dongmoi);
            }
        }
        //Tim
      
    }

}
