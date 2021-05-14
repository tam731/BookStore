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
    public partial class FrmNCC : Form
    {
        public FrmNCC()
        {
            InitializeComponent();
        }
        
        QLSachDataContext db = new QLSachDataContext();
        NccBUS n = new NccBUS();
        private void FrmNCC_Load(object sender, EventArgs e)
        {
            n.hienthi(dgvNCC);
        }
       
        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int mancc = int.Parse(dgvNCC.Rows[e.RowIndex].Cells[0].Value.ToString());
            var nvXS = db.NhaCungCaps.SingleOrDefault(nv => nv.MaNCC == mancc);
            n.xoa(sender, e, dgvNCC);
             if (e.ColumnIndex == 5)
            {
                Form frm = new FrmSuaNCC();
                frm.Tag = nvXS;
                frm.ShowDialog();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
           
            if (string.IsNullOrEmpty(txtSDT.Text) )
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDC.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDC.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            try
            {
                
                NhaCungCap nv = new NhaCungCap();
                nv.TenNCC = txtTenNCC.Text.Trim();
                nv.SDT = txtSDT.Text.Trim();
                nv.Diachi = txtDC.Text.Trim();
                nv.Email = txtEmail.Text.Trim();

                db.NhaCungCaps.InsertOnSubmit(nv);
                db.SubmitChanges();
                n.hienthi(dgvNCC);
                MessageBox.Show("Thêm thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Clear();
                txtDC.Clear();
                txtSDT.Clear();
            }
            catch(Exception e1)
            {
                MessageBox.Show("lỗi :"+e1.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            n.Tim(sender, e, dgvNCC, txtTimNCC);
        }
    
        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
           
        }
        private void FrmNCC_Activated(object sender, EventArgs e)
        {
            n.hienthi(dgvNCC);
        }

    }
}
