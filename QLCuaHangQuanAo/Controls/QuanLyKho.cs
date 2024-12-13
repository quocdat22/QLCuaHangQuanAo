using QLCuaHangQuanAo;
using QLCuaHangQuanAo.Forms.MiniForms;
using QLCuaHangQuanAo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using System.Windows.Media.Media3D;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class QuanLyKho : UserControl
     {
        string path;
        int masp;
        DataTable dt;
        List<SanPham> sanPhamList = new List<SanPham>();
        private List<SanPham> deletedSanPhamList = new List<SanPham>();
        List<SanPham> add_sp = new List<SanPham>();

        DatabaseHelper db;
        public QuanLyKho()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            
            btn_xoa.Enabled = false;
            loadData();
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Luu.Visible = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;

        }

        public void loadData()
        {
            loadDataGridView();
            loadComboBoxLoai();
            loadComboBoxSize();
            loadComboBoxMauSac();
        }

        void loadComboBoxMauSac()
        {
            DataTable dt = db.ExecuteQuery("SELECT DISTINCT MauSac FROM SanPham");
            var mauSacSanPham = dt.AsEnumerable().Select(row => row.Field<string>("MauSac")).ToList();
            cbo_mau.Items.Clear();
            cbo_mau.Items.Insert(0, "");
            foreach (var mau in mauSacSanPham)
            {
                cbo_mau.Items.Add(mau);
            }
            cbo_mau.SelectedIndex = 0;
        }
            void loadComboBoxLoai()
        {
            DataTable dt = db.ExecuteQuery("SELECT DISTINCT MaLoai, TenLoai FROM LoaiSanPham");
            var loaiSanPham = dt.AsEnumerable().Select(row => new
            {
                MaLoai = row.Field<int>("MaLoai"),
                TenLoai = row.Field<string>("TenLoai")
            }).ToList();

            cbo_loai.DataSource = loaiSanPham;
            cbo_loai.DisplayMember = "TenLoai";
            cbo_loai.ValueMember = "MaLoai";
            cbo_loai.SelectedIndex = -1;
        }
        void loadComboBoxSize()
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

        private void loadDataGridView()
        {
           
            string query = "SELECT * FROM SanPham";
            DataTable dt = db.ExecuteQuery(query);

            sanPhamList = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                SanPham sanPham = new SanPham
                {
                    MaSanPham = Convert.ToInt32(row["MaSanPham"]),
                    TenSanPham = row["TenSanPham"].ToString(),
                    MaLoai = Convert.ToInt32(row["MaLoai"]),
                    MoTa = row["MoTa"].ToString(),
                    Size = row["Size"].ToString(),
                    MauSac = row["MauSac"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    SoLuongTonKho = Convert.ToInt32(row["SoLuongTonKho"]),
                    HinhAnh = row["HinhAnh"].ToString()
                };
                sanPhamList.Add(sanPham);
            }

            dataGridView1.DataSource = sanPhamList;
        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        //them
        private void uiButton1_Click(object sender, EventArgs e)
        {
            SanPham s = new SanPham
            {
                TenSanPham = txt_Ten.Text,
                MauSac = cbo_mau.SelectedItem.ToString(),
                Gia = decimal.Parse(txt_Gia.Text),
                MaLoai = int.Parse(cbo_loai.SelectedValue.ToString()),
                SoLuongTonKho = 0,
                MoTa = txt_MoTa.Text,
                Size = cbo_Size.SelectedItem.ToString(),
                HinhAnh = path
            };

            SqlParameter[] parameters = {
                new SqlParameter("@TenSanPham", s.TenSanPham),
                new SqlParameter("@MaLoai", s.MaLoai),
                new SqlParameter("@MoTa", s.MoTa),
                new SqlParameter("@Size", s.Size),
                new SqlParameter("@MauSac", s.MauSac),
                new SqlParameter("@HinhAnh", s.HinhAnh),
                new SqlParameter("@Gia", s.Gia),
                new SqlParameter("@SoLuongTonKho", s.SoLuongTonKho)
            };

            db.ExecuteProcNonQuery("AddSanPham", parameters);
            loadDataGridView();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                masp = int.Parse(row.Cells["MaSanPham"].Value.ToString());
                txt_Ten.Text = row.Cells["TenSanPham"].Value.ToString();
                cbo_loai.SelectedValue = int.Parse(row.Cells["MaLoai"].Value.ToString());
                cbo_mau.SelectedItem = row.Cells["MauSac"].Value.ToString();
                cbo_Size.SelectedItem = row.Cells["Size"].Value.ToString();
                txt_SoLuong.Text = row.Cells["SoLuongTonKho"].Value.ToString();
                txt_Gia.Text = row.Cells["Gia"].Value.ToString();
                txt_MoTa.Text = row.Cells["MoTa"].Value?.ToString();

                if (!string.IsNullOrEmpty(row.Cells["HinhAnh"].Value?.ToString()))
                {
                    string imagePath = Path.GetFullPath(Path.Combine(Application.StartupPath, "../..", "Images", row.Cells["HinhAnh"].Value.ToString()));
                    AnhSP.Image = Image.FromFile(imagePath);
                    
                }
                path = row.Cells["HinhAnh"].Value.ToString();

                btn_xoa.Enabled = true;
                btn_Huy.Enabled = true;
                btn_Luu.Enabled = true;
                btn_clear.Enabled = true;
                btn_sua.Enabled = true;
            }
        }

        //update
        private void uiButton3_Click(object sender, EventArgs e)
        {
            //lay thong tin da sua
            SanPham s = new SanPham();
            s.MaSanPham = masp;
            s.TenSanPham = txt_Ten.Text;
            s.MaLoai = int.Parse(cbo_loai.SelectedValue.ToString());
            s.MoTa = txt_MoTa.Text;
            s.Size = cbo_Size.SelectedItem.ToString();
            s.MauSac = cbo_mau.SelectedItem.ToString();
            s.Gia = decimal.Parse(txt_Gia.Text);
            s.SoLuongTonKho = int.Parse(txt_SoLuong.Text);
            s.HinhAnh = path;

            SqlParameter[] parameters = {
                new SqlParameter("@MaSanPham", s.MaSanPham),
                new SqlParameter("@TenSanPham", s.TenSanPham),
                new SqlParameter("@MaLoai", s.MaLoai),
                new SqlParameter("@MoTa", s.MoTa),
                new SqlParameter("@Size", s.Size),
                new SqlParameter("@MauSac", s.MauSac),
                new SqlParameter("@HinhAnh", s.HinhAnh),
                new SqlParameter("@Gia", s.Gia),
                new SqlParameter("@SoLuongTonKho", s.SoLuongTonKho)
            };

            db.ExecuteProcNonQuery("UpdateSanPham", parameters);
            loadDataGridView();

            

        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //foreach (SanPham i in sanPhamList)
            //{
                
                
            //        SanPham existingProduct = ql.SanPhams.FirstOrDefault(t=>t.MaSanPham==i.MaSanPham);
            //    if (existingProduct != null)
            //    {
            //        existingProduct.TenSanPham = i.TenSanPham;
            //        existingProduct.MauSac = i.MauSac;
            //        existingProduct.MaLoai = i.MaLoai;
            //        existingProduct.Size = i.Size;
            //        existingProduct.SoLuongTonKho = i.SoLuongTonKho;
            //        existingProduct.Gia = i.Gia;
            //        existingProduct.HinhAnh = i.HinhAnh;

            //    }
               
                
            //}
            //foreach(SanPham x in add_sp)
            //{
            //    ql.SanPhams.Add(x);
            //}    
            //add_sp = new List<SanPham>();
            //foreach (SanPham deletedItem in deletedSanPhamList)
            //{
            //    var i = ql.SanPhams.FirstOrDefault(t => t.MaSanPham ==deletedItem.MaSanPham );
            //    ql.SanPhams.Remove(i);
            //}
            //deletedSanPhamList = new List<SanPham>();
            //ql.SaveChanges();
            //btn_xoa.Enabled = false;
            //btn_Huy.Enabled = false;
            //btn_Luu.Enabled = false;
            //btn_clear.Enabled = false;
            //btn_sua.Enabled = false;
        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Title = "Chọn ảnh";
            a.Filter = "anh Files(*.JPG; *.PNG)|*.JPG;*.PNG";

            if (a.ShowDialog() == DialogResult.OK)
            {
                string imageName = Path.GetFileName(a.FileName); // Tên file ảnh
                string destinationPath = Path.Combine(Application.StartupPath, "../..", "Images", imageName);

                try
                {
                    File.Copy(a.FileName, destinationPath, true); // Sao chép file vào thư mục Images
                    path = imageName; // Chỉ lưu tên file
                    AnhSP.Image = Image.FromFile(destinationPath); // Hiển thị ảnh trong PictureBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loadData();
            btn_xoa.Enabled=false;
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;
        }


        //detele=========================
        private void uiButton2_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int masp = int.Parse(row.Cells["MaSanPham"].Value.ToString());
                SanPham i = sanPhamList.FirstOrDefault(t => t.MaSanPham == masp);

                if (i != null)
                {
                    // Xóa sản phẩm từ cơ sở dữ liệu
                    SqlParameter[] parameters = {
                        new SqlParameter("@MaSanPham", masp)
                    };
                    int rowsAffected = db.ExecuteProcNonQuery("DeleteSanPhamByID", parameters);

                    if(rowsAffected > 0)
                    {
                        // Xóa sản phẩm từ danh sách
                        sanPhamList.Remove(i);
                        deletedSanPhamList.Add(i);

                        // Cập nhật DataGridView
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = sanPhamList;
                        MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearInput();
                        clearButton();

                    }

                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sanPhamList;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

            clearInput();
            clearButton();
        }
        void clearButton()
        {
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;
        }

        void clearInput()
        {
            txt_Ten.Clear();
            txt_Gia.Clear();
            txt_SoLuong.Clear();
            txt_MoTa.Clear();
            cbo_loai.SelectedIndex = -1;
            cbo_mau.SelectedIndex = -1;
            cbo_Size.SelectedIndex = -1;
            AnhSP.Image = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            
            string ten = textBox1.Text;
            DatabaseHelper db = new DatabaseHelper();
            SqlParameter[] parameters = {
                new SqlParameter("@TenSanPham", ten)
            };
            dt = db.ExecuteStoredProcedure("SearchSanPhamByName", parameters);
            dataGridView1.DataSource = dt;

        }

        private void uiButtonThemLoai_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.ShowDialog();

            string tenLoaiSanPhamMoi =  inputForm.InputValue;
            if(tenLoaiSanPhamMoi != null)
            {
                SqlParameter[] parameters = {
                new SqlParameter("@TEN_LOAI_SP", tenLoaiSanPhamMoi)
            };
                db.ExecuteProcNonQuery("ThemLoaiSanPham", parameters);
                loadComboBoxLoai();
            }
            

        }
    }
}
