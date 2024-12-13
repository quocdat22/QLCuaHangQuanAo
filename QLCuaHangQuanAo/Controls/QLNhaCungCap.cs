using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLCuaHangQuanAo.Models;
using Sunny.UI;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class QLNhaCungCap : UserControl
    {
        DatabaseHelper db;
        string maNhaCC;
        public QLNhaCungCap()
        {
            
            InitializeComponent();
            db = new DatabaseHelper();

            
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {

            load_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void load_data()
        {
            DataTable dt = db.ExecuteQuery("Select * from NhaCungCap");
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                maNhaCC = (row.Cells["MaNhaCungCap"].Value.ToString());
                txt_tenNhaCC.Text = (row.Cells["TenNhaCungCap"].Value.ToString());
                txt_DiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txt_NguoiLienHe.Text=row.Cells["NguoiLienHe"].Value.ToString();
                txt_SoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();

            }
        }
        

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@TaiKhoan", txt_tenNhaCC.Text),
            //    new SqlParameter("@MaNhanVien", int.Parse(cbB_NhanVien.SelectedValue.ToString())),
            //    new SqlParameter("@PasswordHash", txt_NguoiLienHe.Text),
            //    new SqlParameter("@PasswordSalt", txt_DiaChi.Text),
            //    new SqlParameter("@Quyen", int.Parse(cbo_role.SelectedValue.ToString())),
            //    new SqlParameter("@Status", cbo_tt.SelectedItem.ToString())
                
                
            //};
            //db.ExecuteProcNonQuery("InsertUser", parameters);
            //load_data();
            //MessageBox.Show("Thêm tài khoản thành công");   
            //txt_tenNhaCC.Enabled = false;

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@TaiKhoan", txt_tenNhaCC.Text),
            //    //new SqlParameter("@MaNhanVien", int.Parse(cbB_NhanVien.SelectedValue.ToString())),
            //    new SqlParameter("@MaNhanVien", maNhanVien),
            //    new SqlParameter("@PasswordHash", txt_NguoiLienHe.Text),
            //    new SqlParameter("@PasswordSalt", txt_DiaChi.Text),
            //    new SqlParameter("@Quyen", int.Parse(cbo_role.SelectedValue.ToString())),
            //    new SqlParameter("@Status", cbo_tt.SelectedItem.ToString())
            //};
            //int row = db.ExecuteProcNonQuery("UpdateUser", parameters);
            //if( row > 0)
            //{
            //    load_data();
            //    MessageBox.Show("Cập nhật tài khoản thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật tài khoản that bai");
            //}
            
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
                
            //    DataGridViewRow row = dataGridView1.SelectedRows[0];

                
            //    string tk = row.Cells["TaiKhoan"].Value.ToString();

                
            //    SqlParameter[] parameters = new SqlParameter[]
            //    {
            //        new SqlParameter("@TaiKhoan", tk)
            //    };

                
            //    db.ExecuteProcNonQuery("DeleteUser", parameters);
            //    load_data();
            //    MessageBox.Show("Xóa tài khoản thành công");
            //    clearInput();
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một tài khoản để xóa.");
            //}
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            load_data();
            txtB_TimKiemTK.Text = "";
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            clearInput();
            txt_tenNhaCC.Enabled = true;
        }
        void clearInput()
        {
            txt_tenNhaCC.Text = "";
            txt_DiaChi.Text = "";
            txt_NguoiLienHe.Text = "";
            txt_SoDienThoai.Text = "";
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string search = txtB_TimKiemTK.Text;
            string query = $"SELECT * FROM timKiemNhaCungCap('{search}')";

            DataTable dt = db.ExecuteQuery(query);

            dataGridView1.DataSource = dt;
        }
    }
}
