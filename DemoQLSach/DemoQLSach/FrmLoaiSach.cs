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
    public partial class FrmLoaiSach : Form
    {
        public FrmLoaiSach()
        {
            InitializeComponent();
        }
        QLSachDataContext db=new QLSachDataContext();
        LoaiSachBUS lsbus = new LoaiSachBUS();
        private void FrmLoaiSach_Load(object sender, EventArgs e)
        {
            lsbus.hienthi(dgvLS);
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên loại sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }
            try
            {
                LoaiSach l = new LoaiSach();
                l.TenLoai = txtTenLoai.Text;
                db.LoaiSaches.InsertOnSubmit(l);
                db.SubmitChanges();
                lsbus.hienthi(dgvLS);
                MessageBox.Show("Thêm thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e1)
            {
                MessageBox.Show("Nhập trùng khóa chính", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvLS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int maloai = int.Parse(dgvLS.Rows[e.RowIndex].Cells[0].Value.ToString());
            var lsSuaXoa = db.LoaiSaches.SingleOrDefault(s => s.MaLoai == maloai);
            
            if (e.ColumnIndex == 3)
            {
                FrmSuaLoaiSach f = new FrmSuaLoaiSach();
                f.Tag = lsSuaXoa;
                f.ShowDialog();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }

        private void FrmLoaiSach_Activated(object sender, EventArgs e)
        {
            lsbus.hienthi(dgvLS);
        }
    }
}
