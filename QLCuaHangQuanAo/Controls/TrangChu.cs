using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            flowLayoutPanel1.AutoScroll = true;

            LoadBestSellers();
            LoadTodayOrdersCount();
            LoadTodayTotalRevenue();
            LoadSalesRevenueData();
            LoadChartTonKhoTheoLoai();
            LoadChartDoanhThuVaNhapHang();
            LoadChartTopNhanVien();


        }

        void LoadChartTopNhanVien()
        {
            // Lấy dữ liệu 3 nhân viên có doanh số bán hàng cao nhất
            DataTable tableTopNhanVien = db.ExecuteQuery("LayTop3NhanVienBanHang");

            chartTopNhanVien.Series.Clear();

            // Series Doanh số bán hàng
            Series seriesDoanhSo = new Series("Doanh số bán hàng");
            seriesDoanhSo.ChartType = SeriesChartType.Column; // Đảm bảo là Column
            seriesDoanhSo.Color = Color.Orange;

            foreach (DataRow row in tableTopNhanVien.Rows)
            {
                string tenNhanVien = row["HoTen"].ToString();
                decimal doanhSo = Convert.ToDecimal(row["DoanhSo"]);
                seriesDoanhSo.Points.AddXY(tenNhanVien, doanhSo);
            }

            // Thêm Series vào Chart
            chartTopNhanVien.Series.Add(seriesDoanhSo);

            // Cài đặt trục X và Y
            chartTopNhanVien.ChartAreas[0].AxisX.Title = "Nhân viên";
            chartTopNhanVien.ChartAreas[0].AxisY.Title = "Doanh số";
            chartTopNhanVien.ChartAreas[0].AxisX.Interval = 1;
            chartTopNhanVien.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

            // Thêm tiêu đề
            chartTopNhanVien.Titles.Clear();
            chartTopNhanVien.Titles.Add("Top doanh số bán hàng nhân viên");
            chartTopNhanVien.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Đảm bảo các cột không chồng chéo
            chartTopNhanVien.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartTopNhanVien.ChartAreas[0].AxisX.IsMarginVisible = true;

            chartTopNhanVien.Legends.Clear();
        }

        void LoadChartDoanhThuVaNhapHang()
        {
            int nam = DateTime.Now.Year;
            // Lấy dữ liệu Tiền nhập hàng
          
            DataTable tableNhapHang = db.ExecuteQuery("LayTongTienNhapHangHangThangTrongNamHienTai");

            // Lấy dữ liệu Doanh thu
            DataTable tableDoanhThu = db.ExecuteQuery("LayDoanhThuMoiThangNamHienTai");

            chartDoanhThuVaNhapHang.Series.Clear();

            // Series Tiền nhập hàng
            Series seriesTienNhap = new Series("Tiền nhập hàng");
            seriesTienNhap.ChartType = SeriesChartType.Column; // Đảm bảo là Column
            seriesTienNhap.Color = Color.Blue;

            foreach (DataRow row in tableNhapHang.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                decimal tienNhapHang = Convert.ToDecimal(row["TongTienNhapHang"]);
                seriesTienNhap.Points.AddXY(thang, tienNhapHang);
            }

            // Series Doanh thu
            Series seriesDoanhThu = new Series("Doanh thu");
            seriesDoanhThu.ChartType = SeriesChartType.Column; // Đảm bảo là Column
            seriesDoanhThu.Color = Color.Green;

            foreach (DataRow row in tableDoanhThu.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                seriesDoanhThu.Points.AddXY(thang, doanhThu);
            }

            // Thêm Series vào Chart
            chartDoanhThuVaNhapHang.Series.Add(seriesTienNhap);
            chartDoanhThuVaNhapHang.Series.Add(seriesDoanhThu);

            // Cài đặt trục X và Y
            chartDoanhThuVaNhapHang.ChartAreas[0].AxisX.Title = "Tháng";
            chartDoanhThuVaNhapHang.ChartAreas[0].AxisY.Title = "Giá trị (VNĐ)";
            chartDoanhThuVaNhapHang.ChartAreas[0].AxisX.Interval = 1;
            chartDoanhThuVaNhapHang.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

            // Thêm tiêu đề
            chartDoanhThuVaNhapHang.Titles.Clear();
            chartDoanhThuVaNhapHang.Titles.Add("Biểu đồ tổng hợp tiền nhập hàng và doanh thu theo tháng năm " + nam);
            chartDoanhThuVaNhapHang.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Đảm bảo các cột không chồng chéo
            chartDoanhThuVaNhapHang.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartDoanhThuVaNhapHang.ChartAreas[0].AxisX.IsMarginVisible = true;


        }

        void LoadChartTonKhoTheoLoai()
        {
            // Lấy dữ liệu từ stored procedure
            DataTable tableTonKho = db.ExecuteStoredProcedure("SO_LUONG_TON_KHO_LOAI_SP");

            chartSLTonKho.Series.Clear();

            // Series Số lượng tồn kho
            Series seriesTonKho = new Series("Số lượng tồn kho");
            seriesTonKho.ChartType = SeriesChartType.Column; // Đảm bảo là Column
            seriesTonKho.Color = Color.Purple;

            foreach (DataRow row in tableTonKho.Rows)
            {
                string tenLoai = row["TenLoai"].ToString();
                int tongSoLuongTon = Convert.ToInt32(row["TongSoLuongTon"]);
                seriesTonKho.Points.AddXY(tenLoai, tongSoLuongTon);
            }

            // Thêm Series vào Chart
            chartSLTonKho.Series.Add(seriesTonKho);

            // Cài đặt trục X và Y
            chartSLTonKho.ChartAreas[0].AxisX.Title = "Loại sản phẩm";
            chartSLTonKho.ChartAreas[0].AxisY.Title = "Số lượng tồn kho";
            chartSLTonKho.ChartAreas[0].AxisX.Interval = 1;
            chartSLTonKho.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

            // Thêm tiêu đề
            chartSLTonKho.Titles.Clear();
            chartSLTonKho.Titles.Add("Số lượng tồn kho theo loại sản phẩm");
            chartSLTonKho.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Đảm bảo các cột không chồng chéo
            chartSLTonKho.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartSLTonKho.ChartAreas[0].AxisX.IsMarginVisible = true;

            chartSLTonKho.Legends.Clear();
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
            Series series = new Series()
            {
                ChartType = SeriesChartType.Bar
            };

            foreach (var item in chartdata)
            {
                series.Points.AddXY(item.TenSanPham, item.SoLuongBan);
            }

            chart1.Series.Add(series);
            chart1.Legends.Clear();

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Sản phẩm bán chạy");
            chart1.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
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

            chartDoanhThu.Legends.Clear();
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
