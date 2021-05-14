using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class BatLoiBUS
    {
        
        QLSachDataContext db = new QLSachDataContext();
        public BatLoiBUS() { }

       
       

        // Chỉ nhập số
        public void NhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        
    }
}
