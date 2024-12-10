using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class TrangChu : UserControl
    {
        DatabaseHelper db;
        public TrangChu()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

            LoadBestSellers();
            LoadTodayOrdersCount();
            LoadTodayTotalRevenue();
            LoadSalesRevenueData();

            
        }

        

        private void LoadBestSellers()
        {
            DataTable dt = db.ExecuteStoredProcedure("GetBestSellers");
            var chartdata = dt.AsEnumerable().Select(row => new
            {
                TenSanPham = row.Field<string>("TenSanPham"),
                SoLuongBan = row.Field<int>("SoLuongBan")
            }).ToList();

            chart1.Series.Clear();
            Series series = new Series("Sản phẩm bán chạy")
            {
                ChartType = SeriesChartType.Bar
            };

            foreach (var item in chartdata)
            {
                series.Points.AddXY(item.TenSanPham, item.SoLuongBan);
            }

            chart1.Series.Add(series);
        }

        
        private void LoadTodayOrdersCount()
        {
            object result = db.ExecuteScalar("GetTodayOrdersCount");
            SoDon.Text = result.ToString();
        }

        private void LoadTodayTotalRevenue()
        {
            object result = db.ExecuteScalar("GetTodayTotalRevenue");
            decimal total = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            DoanThu.Text = total.ToString("N0") + " VNĐ";
        }

        private void LoadSalesRevenueData()
        {
            DataTable dt = db.ExecuteStoredProcedure("GetSalesRevenueData");
            var doanhThuData = dt.AsEnumerable().Select(row => new
            {
                NgayMuaHang = row.Field<DateTime>("NgayMuaHang"),
                TongTien = row.Field<decimal>("TongTien")
            }).ToList();

            chartDoanhThu.Series.Clear();
            Series series = new Series("Doanh Thu")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double
            };

            foreach (var item in doanhThuData)
            {
                series.Points.AddXY(item.NgayMuaHang, item.TongTien);
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("Biểu Đồ Doanh Thu Theo Đơn Hàng");
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày Mua Hàng";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh Thu (VNĐ)";
        }

        
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiBarChart1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiSmoothLabel2_Click(object sender, EventArgs e)
        {

        }

        private void SoDon_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            //LichLamNhanVien l=new LichLamNhanVien();
            //l.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
