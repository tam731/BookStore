using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class PhieuNhapBUS
    {
        QLSachDataContext db = new QLSachDataContext();
        //load cobobox
        public void loadcboNV(ComboBox cbo)
        {
            cbo.DataSource = db.NhanViens.ToList();
            cbo.DisplayMember = "TenNV";
            cbo.ValueMember = "TenDN";
            cbo.SelectedIndex = -1;
        }
        public void loadcbo_NCC(ComboBox cbo)
        {
            cbo.DataSource = db.NhaCungCaps.ToList();
            cbo.DisplayMember = "TenNCC";
            cbo.ValueMember = "MaNCC";
        }

            //hienthi
            
        public void hienthi(DataGridView dgv)
        {
            
        }

        
    }
}
