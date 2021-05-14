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
    public partial class FrmHoaDonCTHD : Form
    {
        public FrmHoaDonCTHD()
        {
            InitializeComponent();
        }
        QLSachDataContext db = new QLSachDataContext();
        HoaDonBus hdBus = new HoaDonBus();
        private void FrmHoaDonCTHD_Load(object sender, EventArgs e)
        {
            hdBus.hienthiHD(dgvHd);
        }
        string sohd;
        private void dgvHd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                sohd = dgvHd.Rows[e.RowIndex].Cells[0].Value.ToString();
                InHoaDon();
            }
        }
        private void InHoaDon()
        {
            printPreviewDialogHD.Document = printDocumentHD;
            printPreviewDialogHD.ShowDialog();
        }

        private void printDocumentHD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var w = printDocumentHD.DefaultPageSettings.PaperSize.Width;

            e.Graphics.DrawString("NHÀ SÁCH THÁI HÀ",
                                 new Font("Arial", 30, FontStyle.Bold),
                                 Brushes.Black, new Point(190, 150)
                                 );

            e.Graphics.DrawString("138, Đường Láng Phường Láng Thượng, Quận Đống Đa Hà Nội",
                                 new Font("Arial", 15, FontStyle.Bold),
                                 Brushes.Black, new Point(213, 222)
                                 );

            e.Graphics.DrawString("Điện thoại: 0989358744",
                                 new Font("Arial", 15, FontStyle.Bold),
                                 Brushes.Black, new Point(263, 247)
                                 );

            e.Graphics.DrawString("---------------------------------------------------------",
                                 new Font("Arial", 15, FontStyle.Bold),
                                 Brushes.Black, new Point(213, 277)
                                 );

            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN",
                                 new Font("Arial", 30, FontStyle.Regular),
                                 Brushes.Black, new Point(175, 357)
                                 );
            var hd = db.HoaDons.SingleOrDefault(X => X.SoHD == sohd);
            var hdt = from cthd in db.ChiTietHoaDons
                      where cthd.SoHD == hd.SoHD
                      select cthd;
            e.Graphics.DrawString("Mã hóa đơn:    " + hd.SoHD.ToString(),
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(100, 427)
                                 );

            e.Graphics.DrawString("Ngày in:    " + hd.NgayLap,
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(100, 467)
                                 );



            e.Graphics.DrawString("Thu ngân:    " + hd.NhanVien.TenNV,
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(100, 547)
                                 );

            Pen blackpen = new Pen(Color.Gray, 1);

            var y = 597;

            Point a = new Point(100, y);
            Point b = new Point(w - 100, y);

            e.Graphics.DrawLine(blackpen, a, b);

            e.Graphics.DrawString("TÊN SÁCH",
                                 new Font("Arial", 17, FontStyle.Bold),
                                 Brushes.Black, new Point(100, 614)
                                 );

            e.Graphics.DrawString("SL",
                                 new Font("Arial", 17, FontStyle.Bold),
                                 Brushes.Black, new Point(359, 614)
                                 );

            e.Graphics.DrawString("ĐƠN GIÁ",
                                 new Font("Arial", 17, FontStyle.Bold),
                                 Brushes.Black, new Point(420, 614)
                                 );

            e.Graphics.DrawString("THÀNH TIỀN",
                                 new Font("Arial", 17, FontStyle.Bold),
                                 Brushes.Black, new Point(565, 614)
                                 );
            var y1 = 648;
            Point a1 = new Point(100, y1);
            Point b1 = new Point(w - 100, y1);

            e.Graphics.DrawLine(blackpen, a1, b1);
            int sl = 0;
            foreach (var item in hdt)
            {
                y1 += 17;
                e.Graphics.DrawString(item.Sach.TenSach,
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(100, y1)
                                 );

                e.Graphics.DrawString(item.SLMua.ToString(),
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(359, y1)
                                 );

                e.Graphics.DrawString(item.DonGia.Value.ToString("N0"),
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(420, y1)
                                 );

                e.Graphics.DrawString((item.SLMua * item.DonGia).Value.ToString("N0"),
                                 new Font("Arial", 15, FontStyle.Regular),
                                 Brushes.Black, new Point(565, y1)
                                 );
                y1 += 32;
                Point a2 = new Point(100, y1);
                Point b2 = new Point(w - 100, y1);

                e.Graphics.DrawLine(blackpen, a2, b2);

                
            }
            y1 += 17;
            e.Graphics.DrawString("Tổng cộng: ",
                                 new Font("Arial", 15, FontStyle.Bold),
                                 Brushes.Black, new Point(100, y1)
                                 );

            e.Graphics.DrawString(sl.ToString(),
                                 new Font("Arial", 15, FontStyle.Bold),
                                 Brushes.Black, new Point(359, y1)
                                 );

            //e.Graphics.DrawString(tong1.ToString("N0"),
            //                     new Font("Arial", 15, FontStyle.Bold),
            //                     Brushes.Black, new Point(565, y1)
            //                     );

            //y1 += 40;
            //e.Graphics.DrawString("Giảm giá:    " +  + "%",
            //                     new Font("Arial", 15, FontStyle.Bold),
            //                     Brushes.Black, new Point(100, y1)
            //                     );

            //y1 += 40;
            //e.Graphics.DrawString("TIỀN MẶT: ",
            //                     new Font("Arial", 20, FontStyle.Bold),
            //                     Brushes.Black, new Point(100, y1)
            //                     );

            //e.Graphics.DrawString(txtthanhtien.Text.Trim(),
            //                     new Font("Arial", 20, FontStyle.Bold),
            //                     Brushes.Black, new Point(550, y1)
            //                     );

            //var h = pdHoaDon.DefaultPageSettings.PaperSize.Height;

            //Point a3 = new Point(100, h - 80);
            //Point b3 = new Point(w - 100, h - 80);

            //e.Graphics.DrawLine(blackpen, a3, b3);

            //e.Graphics.DrawString("Cảm ơn Quý Khách - Hẹn gặp lại!",
            //                     new Font("Arial", 20, FontStyle.Bold),
            //                     Brushes.Black, new Point(190, h - 50)
            //                     );
        
        }
    }
}
