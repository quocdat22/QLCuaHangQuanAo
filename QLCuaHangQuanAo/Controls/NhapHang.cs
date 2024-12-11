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
using QLCuaHangQuanAo.Forms.MiniForms;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class NhapHang : UserControl
    {
        public float TongTienHang=0;
        public string TenNhanVien;

        public int IdNhanVien;

        DatabaseHelper db;
    
        public NhapHang()
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
            LoadNhaCungCap();

            LoadNhapHang();
        }

        //==================================//
        #region LOAD 

        void LoadNhapHang()
        {
            
        }

        private void LoadSanPhamList()
        {
            DataTable dt = db.ExecuteQuery("SELECT * FROM SanPham");
            var sanPhamList = dt.AsEnumerable().Select(row => new
            {
                TenSanPham = row.Field<string>("TenSanPham"),
                HinhAnh = row.Field<string>("HinhAnh"),
                
                Size = row.Field<string>("Size"),
                MauSac = row.Field<string>("MauSac")
            }).ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach (var sp in sanPhamList)
            {
                ItemNhapHang item = new ItemNhapHang();
                item.SetSP(sp.TenSanPham, sp.HinhAnh, sp.Size, sp.MauSac);
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

        private void LoadNhaCungCap()
        {
            DataTable dt = db.ExecuteQuery("select distinct MaNhaCungCap, TenNhaCungCap from NhaCungCap;");
            var dsNCC = dt.AsEnumerable().Select(row => new
            {
                MaNCC = row.Field<int>("MaNhaCungCap"),
                TenNCC = row.Field<string>("TenNhaCungCap")
            }).ToList();

            cb_NhaCC.DataSource = dsNCC;
            cb_NhaCC.DisplayMember = "TenNCC";
            cb_NhaCC.ValueMember = "MaNCC";
            cb_NhaCC.SelectedIndex = 0; // Ensure no item is selected by default
        }

        
        #endregion



        private void ItemControl_OnAddItemHD(object sender, EventArgs e)
        {

            itemHDNhapHang newItemHDNhapHang = new itemHDNhapHang();
            ItemNhapHang item = sender as ItemNhapHang;

            if (item != null && item.Count > 0)
            {
                newItemHDNhapHang.getItem(item.name, item.price, item.Imagess, item.Count, item.SizeSP1, item.color);
                if (kiemTra(newItemHDNhapHang))
                {
                    flowLayoutPanel3.Controls.Add(newItemHDNhapHang);

                    newItemHDNhapHang.Remove += RemoveItemHoaDon;
                    TongTienHang += newItemHDNhapHang.ThanhTien;
                    txt_TongTien.Text = TongTienHang.ToString();
                }
            }
        }
        private bool kiemTra(itemHDNhapHang itemHD)
        {
            foreach (var con in flowLayoutPanel3.Controls)
            {
                itemHDNhapHang i = con as itemHDNhapHang;
                if (i.NameCTHD == itemHD.NameCTHD && i.SizeCt == itemHD.SizeCt && i.ColorCt == itemHD.ColorCt)
                    return false;
            }
            return true;
        }

        private void RemoveItemHoaDon(object sender, EventArgs e)
        {
            itemHD itemHD = sender as itemHD;
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
                MauSac = row.Field<string>("MauSac"),
                SoLuong = row.Field<int>("SoLuongTonKho")
            }).ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach (var sp in list)
            {
                ItemBanHang item = new ItemBanHang();
                item.SetSP(sp.TenSanPham, sp.HinhAnh, sp.Gia.ToString(), sp.Size, sp.MauSac, sp.SoLuong);
                item.OnAddItemHD += ItemControl_OnAddItemHD;
                flowLayoutPanel1.Controls.Add(item);
            }
        }



        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            int maNCC = (int)cb_NhaCC.SelectedValue;
            
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNhaCungCap", maNCC),
                new SqlParameter("@NgayNhapHang", DateTime.Now),
                new SqlParameter("@TongTien",decimal.Parse(txt_TongTien.Text))
            };

            DataTable dt = db.ExecuteStoredProcedure("ThemPhieuNhapHang", parameters);

            int maPhieuNhap = Convert.ToInt32(dt.Rows[0]["PhieuNhapHang"]);

            foreach(var item in flowLayoutPanel3.Controls)
            {
                itemHDNhapHang i = item as itemHDNhapHang;
                SqlParameter[] parameters1 =
                {
                    new SqlParameter("@MaPhieuNhap", maPhieuNhap),
                    new SqlParameter("@MaSanPham",  GetMaSanPham(i.NameCTHD)),
                    new SqlParameter("@SoLuong", i.soluong),
                    new SqlParameter("@DonGia", i.gia)
                };
                db.ExecuteStoredProcedure("ThemChiTietPhieuNhapHang", parameters1);
            }

            MessageBox.Show("Nhập hàng thành công");

            ResetDS();

        }

        private int GetMaSanPham(string tenSanPham)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenSanPham", tenSanPham)
            };

            return (int)db.ExecuteScalar("SELECT MaSanPham FROM SanPham WHERE TenSanPham = @TenSanPham", parameters);
        }

        void ResetDS()
        {
            flowLayoutPanel3.Controls.Clear();
            txt_TongTien.Clear();
           
            
            cb_NhaCC.SelectedValue = -1;
            //cb_NhaCC.Text = "";
        }

       

        

        private void cbx_KhachHangHD_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_TienKhach_TextChanged(object sender, EventArgs e)
        {
           
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            ThemNhaCungCap themNhaCungCap = new ThemNhaCungCap();
            themNhaCungCap.ShowDialog();

            LoadNhaCungCap();
        }
    }
}
