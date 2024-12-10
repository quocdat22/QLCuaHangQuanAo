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
//using Microsoft.Reporting.WinForms;

//using System.Data.Entity;
using QLCuaHangQuanAo;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class BanHang : UserControl
    {
        public float TongTienHang=0;
        public string TenNhanVien;

        public int IdNhanVien;

        DatabaseHelper db;
    
        public BanHang()
        {
            InitializeComponent();

            db = new DatabaseHelper();
        }

        

        private void BanHang_Load(object sender, EventArgs e)
        {
            LoadSanPhamList();
            LoadSizeSanPham();
            LoadMauSacSanPham();
            LoadLoaiSanPham();
            LoadDanhSachKhachHang();

            LoadThanhToan();
        }

        //==================================//
        #region LOAD 

        void LoadThanhToan()
        {
            txtTienThoi.Enabled = false;
        }

        private void LoadSanPhamList()
        {
            DataTable dt = db.ExecuteQuery("SELECT * FROM SanPham");
            var sanPhamList = dt.AsEnumerable().Select(row => new
            {
                TenSanPham = row.Field<string>("TenSanPham"),
                HinhAnh = row.Field<string>("HinhAnh"),
                Gia = row.Field<decimal>("Gia"),
                Size = row.Field<string>("Size"),
                MauSac = row.Field<string>("MauSac")
            }).ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach (var sp in sanPhamList)
            {
                Item item = new Item();
                item.SetSP(sp.TenSanPham, sp.HinhAnh, sp.Gia.ToString(), sp.Size, sp.MauSac);
                item.OnAddItemHD += ItemControl_OnAddItemHD;
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void LoadLoaiSanPham()
        {
            DataTable dt = db.ExecuteQuery("SELECT DISTINCT MaLoai, TenLoai FROM LoaiSanPham");
            var loaiSanPham = dt.AsEnumerable().Select(row => new
            {
                MaLoai = row.Field<int>("MaLoai"),
                TenLoai = row.Field<string>("TenLoai")
            }).ToList();

            cbo_Loai.DataSource = loaiSanPham;
            cbo_Loai.DisplayMember = "TenLoai";
            cbo_Loai.ValueMember = "MaLoai";
            cbo_Loai.SelectedIndex = -1; // Ensure no item is selected by default
        }

        private void LoadSizeSanPham()
        {
            DataTable dt = db.ExecuteQuery("SELECT DISTINCT Size FROM SanPham");
            var sizeSanPham = dt.AsEnumerable().Select(row => row.Field<string>("Size")).ToList();

            cbo_Size.Items.Clear();
            cbo_Size.Items.Insert(0, "");
            foreach (var size in sizeSanPham)
            {
                cbo_Size.Items.Add(size);
            }
            cbo_Size.SelectedIndex = 0;
        }

        private void LoadMauSacSanPham()
        {
            DataTable dt = db.ExecuteQuery("SELECT DISTINCT MauSac FROM SanPham");
            var mauSacSanPham = dt.AsEnumerable().Select(row => row.Field<string>("MauSac")).ToList();

            cbo_Mau.Items.Clear();
            cbo_Mau.Items.Insert(0, "");
            foreach (var color in mauSacSanPham)
            {
                cbo_Mau.Items.Add(color);
            }
            cbo_Mau.SelectedIndex = 0;
        }

        private void LoadDanhSachKhachHang()
        {
            DataTable dt = db.ExecuteQuery("SELECT MaKhachHang, HoTen FROM KhachHang");

            var danhSachKH = dt.AsEnumerable().Select(row => new
            {
                MaKhachHang = row.Field<int>("MaKhachHang"),
                HoTen = row.Field<string>("HoTen")
            }).ToList();

            cb_KhachHangHD.Items.Clear();
            cb_KhachHangHD.DataSource = danhSachKH;

            cb_KhachHangHD.DisplayMember = "HoTen";
            cb_KhachHangHD.ValueMember = "MaKhachHang";
            cb_KhachHangHD.SelectedIndex = -1;

        }
        #endregion



        private void ItemControl_OnAddItemHD(object sender, EventArgs e)
        {

            itemHD1 newItemHD = new itemHD1();

            Item item = sender as Item;

            if (item != null && item.Count > 0)
            {
                newItemHD.getItem(item.name, item.price, item.Imagess, item.Count, item.SizeSP1, item.color);
                if (kiemTra(newItemHD))
                {
                    flowLayoutPanel3.Controls.Add(newItemHD);

                    newItemHD.Remove += RemoveItemHoaDon;
                    TongTienHang += newItemHD.ThanhTien;
                    txt_TongTien.Text = TongTienHang.ToString();
                }

            }
        }
        private bool kiemTra(itemHD1 itemHD)
        {
            foreach (var con in flowLayoutPanel3.Controls)
            {
                itemHD1 i = con as itemHD1;
                if (i.NameCTHD == itemHD.NameCTHD && i.SizeCt == itemHD.SizeCt && i.ColorCt == itemHD.ColorCt)
                    return false;
            }
            return true;

        }

        private void RemoveItemHoaDon(object sender, EventArgs e)
        {
            itemHD1 itemHD = sender as itemHD1;
            TongTienHang -= itemHD.ThanhTien;
            txt_TongTien.Clear();
            txt_TongTien.Text += TongTienHang.ToString();
            flowLayoutPanel3.Controls.Remove(itemHD);
        }



        private void btn_search_Click_1(object sender, EventArgs e)
        {
            string tenSP = !string.IsNullOrEmpty(txt_TenSP.Text) ? txt_TenSP.Text : null;
            int? maLoai = cbo_Loai.SelectedIndex >= 0 ? (int?)cbo_Loai.SelectedValue : null;
            string size = cbo_Size.SelectedIndex > 0 ? cbo_Size.SelectedItem.ToString() : null;
            string mauSac = cbo_Mau.SelectedIndex > 0 ? cbo_Mau.SelectedItem.ToString() : null;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenSP", SqlDbType.NVarChar) { Value = (object)tenSP ?? DBNull.Value },
                new SqlParameter("@MaLoai", SqlDbType.Int) { Value = (object)maLoai ?? DBNull.Value },
                new SqlParameter("@Size", SqlDbType.NVarChar) { Value = (object)size ?? DBNull.Value },
                new SqlParameter("@MauSac", SqlDbType.NVarChar) { Value = (object)mauSac ?? DBNull.Value }
            };

            DataTable dt = db.ExecuteStoredProcedure("SearchSanPham", parameters);
            var list = dt.AsEnumerable().Select(row => new
            {
                TenSanPham = row.Field<string>("TenSanPham"),
                HinhAnh = row.Field<string>("HinhAnh"),
                Gia = row.Field<decimal>("Gia"),
                Size = row.Field<string>("Size"),
                MauSac = row.Field<string>("MauSac")
            }).ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach (var sp in list)
            {
                Item item = new Item();
                item.SetSP(sp.TenSanPham, sp.HinhAnh, sp.Gia.ToString(), sp.Size, sp.MauSac);
                item.OnAddItemHD += ItemControl_OnAddItemHD;
                flowLayoutPanel1.Controls.Add(item);
            }
        }



        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            int maKhachHang;
            if (cbx_KhachHangHD.Checked)
                maKhachHang = -1;
            else
            {
                // Kiểm tra nếu không chọn khách hàng
                if (cb_KhachHangHD.SelectedValue == null || string.IsNullOrEmpty(cb_KhachHangHD.Text))
                {
                    MessageBox.Show("Bổ sung thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng xử lý khi thông tin khách hàng không hợp lệ
                }

                maKhachHang = (int)cb_KhachHangHD.SelectedValue;

            }

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TrangThaiThanhToan", "Đã thanh toán"),
                new SqlParameter("@MaNhanVien", IdNhanVien),
                new SqlParameter("@MaKhachHang", maKhachHang),
                new SqlParameter("@TongTien", decimal.Parse(txt_TongTien.Text)),
                new SqlParameter("@NgayMuaHang", DateTime.Now)
            };

            DataTable dt = db.ExecuteStoredProcedure("InsertHoaDon", parameters);

            int maHoaDon = Convert.ToInt32(dt.Rows[0]["MaHoaDon"]);
            decimal chietKhau = 0;
            
            foreach (var con in flowLayoutPanel3.Controls)
            {
                itemHD1 i = con as itemHD1;
                SqlParameter[] ctParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon),
                    new SqlParameter("@MaSanPham", GetMaSanPham(i.NameCTHD)),
                    new SqlParameter("@SoLuong", i.soluong),
                    new SqlParameter("@DonGia", i.gia),
                
                    new SqlParameter("@ChietKhau", chietKhau),
                    //new SqlParameter("@GiaSauChietKhau", (decimal)i.ThanhTien)
                };

                
                db.ExecuteStoredProcedure("InsertChiTietHoaDon", ctParameters);
            }

            DialogResult result = MessageBox.Show("Bạn có muốn in hoa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InHoaDon inHoaDon = new InHoaDon();
                inHoaDon.Show();
                inHoaDon.tenNv = TenNhanVien;
                inHoaDon.tenKhach = GetTenKhachHangByMa(maKhachHang);
                inHoaDon.tongTien = decimal.Parse(txt_TongTien.Text);
                inHoaDon.tienKhach = decimal.Parse(txt_TienKhach.Text);
                inHoaDon.tienThua = decimal.Parse(txtTienThoi.Text);
                inHoaDon.ngayLap = DateTime.Now;
                inHoaDon.ShowInvoiceReport(maHoaDon);

                ResetDS();
            }
            else
            {
                ResetDS();
            }


            

        }

        void ResetDS()
        {
            flowLayoutPanel3.Controls.Clear();
            txt_TongTien.Clear();
            txt_TienKhach.Clear();
            txtTienThoi.Clear();
            
            cb_KhachHangHD.SelectedValue = -1;
            cb_KhachHangHD.Text = "";
        }

        string GetTenKhachHangByMa(int MaKH)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhachHang", MaKH)
            };

            string tenKhachHang = db.ExecuteScalar("SELECT HoTen FROM KhachHang WHERE MaKhachHang = @MaKhachHang", parameters).ToString();

            return tenKhachHang;
        }

        private void KhachHanhTuDo()
        {
            if (cbx_KhachHangHD.Checked)
            {
                cb_KhachHangHD.SelectedIndex = -1; // Bỏ chọn bất kỳ giá trị nào
                cb_KhachHangHD.Text = ""; // Xóa nội dung hiển thị
                cb_KhachHangHD.Enabled = false; // Vô hiệu hóa ComboBox
            }
            else
            {
                cb_KhachHangHD.Enabled = true; // Kích hoạt lại ComboBox
            }
        }

        private void cbx_KhachHangHD_CheckedChanged(object sender, EventArgs e)
        {
            KhachHanhTuDo();
        }


        //private int GetMaNhanVien()
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@TaiKhoan", this.TaiKhoan)
        //    };

        //    return (int)db.ExecuteScalar("SELECT dbo.GetMaNhanVienByTaiKhoan(@TaiKhoan)", parameters);
        //}

        private int GetMaSanPham(string tenSanPham)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenSanPham", tenSanPham)
            };

            return (int)db.ExecuteScalar("SELECT MaSanPham FROM SanPham WHERE TenSanPham = @TenSanPham", parameters);
        }

        private string GetTenNhanVien(int maHoaDon)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };

            return db.ExecuteScalar("SELECT nv.HoTen FROM NhanVien nv JOIN HoaDon hd ON nv.MaNhanVien = hd.MaNhanVien WHERE hd.MaHoaDon = @MaHoaDon", parameters).ToString();
        }

        private void txt_TienKhach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TienKhach.Text))
            {
                txtTienThoi.Text = "0";
                return;
            }

            long tienthoi = long.Parse(txt_TienKhach.Text) - long.Parse(txt_TongTien.Text);
            txtTienThoi.Text = tienthoi <= 0 ? "0" : tienthoi.ToString();
        }


        
        

        #region empty code
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void item3_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void itemHD11_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cbo_Loai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void txt_TienKhach_TextAlignChanged(object sender, EventArgs e)
        {

        }
        private void txt_TongTien_TextChanged(object sender, EventArgs e)
        {

        }


        #endregion

        
    }
}
