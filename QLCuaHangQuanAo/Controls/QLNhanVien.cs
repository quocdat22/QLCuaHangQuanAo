using QLCuaHangQuanAo.Models;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

//using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class QLNhanVien : UserControl
    {
       
        List <NhanVien> list = new List <NhanVien> ();
        DatabaseHelper db;
        int maNhanVien;
        //List<NhanVien> deleteNV=new List<NhanVien> ();
        //List<NhanVien> add_nv=new List<NhanVien> ();
        public QLNhanVien()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            //list=ql.NhanViens.ToList();
            //uiButton5.Visible= false;
            //btn_QuayVe.Visible = false;
            load_data();
            load_cbo_chuvu();
            load_cbo_gt();
            load_cbo_trangthai();
        }
        private void load_data()
        {
            DataTable dt = db.ExecuteQuery("SELECT * FROM NhanVien");


            list = new List<NhanVien>();

            foreach (DataRow row in dt.Rows)
            {
                NhanVien nv = new NhanVien
                {
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    HoTen = row["HoTen"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    Email = row["Email"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    ChucVu = row["ChucVu"].ToString(),
                    NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]),
                    Luong = Convert.ToDecimal(row["Luong"]),
                    TrangThaiLamViec = row["TrangThaiLamViec"].ToString()
                };
                list.Add(nv);
            }

            dataGridView1.DataSource = list;
        }
        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }
        private void load_cbo_gt()
        {
            string[] s = new string[] { "Nam", "Nữ" };
            cbo_GT.DataSource=s;
            cbo_GT.SelectedIndex=-1;
        }

        

        private void load_cbo_trangthai()
        {
            //QuanLyCuaHangQuanAoEntities2 ql = new QuanLyCuaHangQuanAoEntities2();
            string[] s = new string[] { "Đang làm việc", "Đã nghỉ" };
            cbo_TrangThai.Items.AddRange(s);
            cbo_TrangThai.SelectedIndex= -1;
        }

        private void load_cbo_chuvu()
        {
            string[] s = new string[] { "Quản lý", "Nhân viên" };

            cbo_Chucvu.Items.AddRange(s);
            cbo_Chucvu.SelectedIndex=-1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                maNhanVien = int.Parse(row.Cells["MaNhanVien"].Value.ToString());
                txt_Ten.Text = (row.Cells["HoTen"].Value.ToString());
                cbo_GT.SelectedItem = row.Cells["GioiTinh"].Value.ToString();
                txt_Email.Text = (row.Cells["Email"].Value.ToString());
                txt_diachi.Text = (row.Cells["DiaChi"].Value.ToString());
                txt_SDT.Text = (row.Cells["SoDienThoai"].Value.ToString());
                cbo_Chucvu.SelectedItem = row.Cells["ChucVu"].Value.ToString();
                dateTimePicker1.Text = (row.Cells["NgayVaoLam"].Value.ToString());
                txtLuong.Text = (row.Cells["Luong"].Value.ToString());
                cbo_TrangThai.SelectedItem=row.Cells["TrangThaiLamViec"].Value.ToString();
               
            }
        }

        //insert empl=======================
        private void uiButton1_Click(object sender, EventArgs e)
        {
            
            NhanVien nhanVien = new NhanVien
            {
                HoTen = txt_Ten.Text,
                GioiTinh = cbo_GT.SelectedItem.ToString(),
                Email = txt_Email.Text,
                DiaChi = txt_diachi.Text,
                SoDienThoai = txt_SDT.Text,
                ChucVu = cbo_Chucvu.SelectedItem.ToString(),
                NgayVaoLam = DateTime.Parse(dateTimePicker1.Text),
                Luong = decimal.Parse(txtLuong.Text),
                TrangThaiLamViec = cbo_TrangThai.SelectedItem.ToString()
            };
            SqlParameter[] parameters = {
                new SqlParameter("@HoTen", nhanVien.HoTen),
                new SqlParameter("@GioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@Email", nhanVien.Email),
                new SqlParameter("@DiaChi", nhanVien.DiaChi),
                new SqlParameter("@SoDienThoai", nhanVien.SoDienThoai),
                new SqlParameter("@ChucVu", nhanVien.ChucVu),
                new SqlParameter("@NgayVaoLam", nhanVien.NgayVaoLam),
                new SqlParameter("@Luong", nhanVien.Luong),
                new SqlParameter("@TrangThaiLamViec", nhanVien.TrangThaiLamViec)
            };

            DataTable MaNhanVienMoiDt = db.ExecuteStoredProcedure("InsertNhanVien", parameters);
            int maNhanVienMoi = Convert.ToInt32(MaNhanVienMoiDt.Rows[0]["MaNhanVienMoi"]);
            nhanVien.MaNhanVien = maNhanVienMoi;

            list.Add(nhanVien);
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            clearInput();
            btn_QuayVe.Visible = false;
        }
        void clearInput()
        {
            txt_Ten.Text = "";
            cbo_GT.SelectedIndex = -1;
            txt_Email.Text = "";
            txt_diachi.Text = "";
            txt_SDT.Text = "";
            cbo_Chucvu.SelectedIndex = -1;
            dateTimePicker1.Text = "";
            txtLuong.Text = "";
            cbo_TrangThai.SelectedIndex = -1;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MaNhanVien", maNhanVien)
            };

            int result = db.ExecuteProcValueQuery("DeleteNhanVien", parameters);

            if (result == -1)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã tồn tại trong bảng hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == 0)
            {
                MessageBox.Show("Nhân viên đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNhanVien = maNhanVien;
            nhanVien.HoTen = txt_Ten.Text;
            nhanVien.GioiTinh = cbo_GT.SelectedItem.ToString();
            nhanVien.Email = txt_Email.Text;
            nhanVien.DiaChi = txt_diachi.Text;
            nhanVien.SoDienThoai = txt_SDT.Text;
            nhanVien.ChucVu = cbo_Chucvu.SelectedItem.ToString();
            nhanVien.NgayVaoLam = DateTime.Parse(dateTimePicker1.Text);
            nhanVien.Luong = decimal.Parse(txtLuong.Text);
            nhanVien.TrangThaiLamViec = cbo_TrangThai.SelectedItem.ToString();

            SqlParameter[] parameter =
            {
                new SqlParameter("@MaNhanVien", nhanVien.MaNhanVien),
                new SqlParameter("@HoTen", nhanVien.HoTen),
                new SqlParameter("@GioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@Email", nhanVien.Email),
                new SqlParameter("@DiaChi", nhanVien.DiaChi),
                new SqlParameter("@SoDienThoai", nhanVien.SoDienThoai),
                new SqlParameter("@ChucVu", nhanVien.ChucVu),
                new SqlParameter("@NgayVaoLam", nhanVien.NgayVaoLam),
                new SqlParameter("@Luong", nhanVien.Luong),
                new SqlParameter("@TrangThaiLamViec", nhanVien.TrangThaiLamViec)
            };

            db.ExecuteProcNonQuery("UpdateNhanVien", parameter);

            dataGridView1.DataSource = null;
            load_data();


            //NhanVien x=list.FirstOrDefault(t=>t.MaNhanVien==ma);
            //x.HoTen = txt_Ten.Text;
            //x.GioiTinh = cbo_GT.SelectedItem.ToString();
            //x.Email = txt_Email.Text;
            //x.DiaChi = txt_diachi.Text;
            //x.SoDienThoai = txt_SDT.Text;
            //x.ChucVu = cbo_Chucvu.SelectedItem.ToString();
            //x.NgayVaoLam = DateTime.Parse(dateTimePicker1.Text);
            //x.Luong = decimal.Parse(txtLuong.Text);
            //x.TrangThaiLamViec = cbo_TrangThai.SelectedItem.ToString();
            //dataGridView1 .DataSource = null;
            //dataGridView1.DataSource=list;
        }
        

        private void uiButton5_Click(object sender, EventArgs e)
        {
            //foreach(NhanVien nhanVien in list)
            //{
            //    NhanVien c = ql.NhanViens.FirstOrDefault(t => t.MaNhanVien == nhanVien.MaNhanVien);
            //    if (c != null)
            //    {
                  
                    
            //            ql.Entry(c).CurrentValues.SetValues(nhanVien);
                        
                    
                    
            //    }
                
            //}
            //foreach (NhanVien x in add_nv)
            //{
            //    ql.NhanViens.Add(x);
            //}    
            //add_nv = new List<NhanVien>();
            //foreach(NhanVien x in deleteNV)
            //{
            //    var deletedItem = ql.NhanViens.FirstOrDefault(t => t.MaNhanVien == x.MaNhanVien);
            //    ql.NhanViens.Remove(deletedItem);
            //}    
            //deleteNV=new List<NhanVien>();
            //ql.SaveChanges();
            //load_data();
        }

        

        private void uiButton4_Click(object sender, EventArgs e)
        {
            cbo_TrangThai.SelectedIndex = 0;
            //load_data();
            clearInput();
            //disable_button();
            //uiButton2.Disabled();
            //uiButton3.Disabled();
            //btn_QuayVe.Visible = true;
        }

        private void btn_QuayVe_Click(object sender, EventArgs e)
        {
            load_data();
            //clearInput();
            //btn_QuayVe.Visible = false;

            //uiButton2.SetEnabled();
            //uiButton3.SetEnabled();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButtonTimKiem_Click(object sender, EventArgs e)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Search", txt_TimKiem.Text)
            };

            DataTable dt = db.ExecuteStoredProcedure("timKiemNhanVien", sqlParameters);

            dataGridView1.DataSource = dt;
        }
    }
}
