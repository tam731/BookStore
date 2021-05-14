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
    public partial class FrmTacGia : Form
    {
        public FrmTacGia()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        TacGiaBUS tgb = new TacGiaBUS();
        private void FrmTacGia_Load(object sender, EventArgs e)
        {
            tgb.hienthi(dgvTG);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTG.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Tác giả", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTG.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Email", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            try
            {
                TacGia nv = new TacGia();
                nv.TenTG = txtTenTG.Text;
                nv.SDT = txtSDT.Text;
                nv.Email = txtEmail.Text;
                db.TacGias.InsertOnSubmit(nv);
                db.SubmitChanges();
                tgb.hienthi(dgvTG);
                MessageBox.Show("them thanh cong");
            }
            catch(Exception e1)
            {
                MessageBox.Show("Lỗi ngoại lệ :" + e1.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void dgvTG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int matg = int.Parse(dgvTG.Rows[e.RowIndex].Cells[0].Value.ToString());
            var nvXS = db.TacGias.SingleOrDefault(nv => nv.MaTG == matg);
            tgb.Xoa(e, dgvTG);
            if (e.ColumnIndex == 5)
            {
                Form frm = new FrmSuaTG();
                frm.Tag = nvXS;
                frm.ShowDialog();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            tgb.Tim(e, dgvTG, txtTim);
        }

        private void FrmTacGia_Activated(object sender, EventArgs e)
        {
            tgb.hienthi(dgvTG);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            f.Show();
            this.Hide();
        }
    }
}
