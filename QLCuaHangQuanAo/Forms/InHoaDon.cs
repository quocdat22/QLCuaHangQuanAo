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

using Microsoft.Reporting.WinForms;

namespace QLCuaHangQuanAo
{
    public partial class InHoaDon : Form
    {
        public decimal tongTien;
        public decimal tienKhach;
        public decimal tienThua;
        public string tenKhach;
        public string tenNv;
        public DateTime ngayLap;

        private DatabaseHelper db;

        public InHoaDon()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void InHoaDon_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        public void ShowInvoiceReport(int maHoaDon)
        {
            string connectionString = DatabaseHelper.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Lấy dữ liệu hóa đơn
                SqlParameter[] hoaDonPar = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };
                string hoaDonQuery = "SELECT MaHoaDon, NgayMuaHang, TongTien, TrangThaiThanhToan FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
                DataTable hoaDonData = db.ExecuteQuery(hoaDonQuery, hoaDonPar);
                //SqlCommand hoaDonCommand = new SqlCommand(hoaDonQuery, connection);
                //hoaDonCommand.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                //DataTable hoaDonData = new DataTable();
                //using (SqlDataAdapter hoaDonAdapter = new SqlDataAdapter(hoaDonCommand))
                //{
                //    hoaDonAdapter.Fill(hoaDonData);
                //}



                // Lấy dữ liệu chi tiết hóa đơn
                SqlParameter[] chiTietParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };
                DataTable chiTietData = db.ExecuteStoredProcedure("GetChiTietHoaDon", chiTietParameters);

                reportViewer1.LocalReport.ReportPath = "Report2.rdlc"; // Đảm bảo đường dẫn đúng

                // Xóa các dữ liệu cũ trong báo cáo
                reportViewer1.LocalReport.DataSources.Clear();

                // Khai báo các tham số
                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("TongTien", tongTien.ToString()),
                    new ReportParameter("TienKhach", tienKhach.ToString()),
                    new ReportParameter("TienTra", tienThua.ToString()),
                    new ReportParameter("TenKhach", tenKhach),
                    new ReportParameter("TenNhanVien", tenNv),
                    new ReportParameter("NgayLap", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("MaHoaDon", maHoaDon.ToString())
                };

                // Gán các tham số cho báo cáo
                reportViewer1.LocalReport.SetParameters(reportParameters);

                // Tạo và thêm các nguồn dữ liệu vào báo cáo
                ReportDataSource rdsHoaDon = new ReportDataSource("HoaDonDataSet", hoaDonData);
                ReportDataSource rdsChiTietHoaDon = new ReportDataSource("DataSet2", chiTietData);

                reportViewer1.LocalReport.DataSources.Add(rdsHoaDon);
                reportViewer1.LocalReport.DataSources.Add(rdsChiTietHoaDon);

                // Làm mới và hiển thị báo cáo
                reportViewer1.RefreshReport();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
