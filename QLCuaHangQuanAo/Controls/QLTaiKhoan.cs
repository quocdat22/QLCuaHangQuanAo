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
    public partial class QLTaiKhoan : UserControl
    {
        DatabaseHelper db;
        string maNhanVien;
        public QLTaiKhoan()
        {
            
            InitializeComponent();
            db = new DatabaseHelper();

            disableInput();
        }

        void disableInput()
        {
            txt_tenTK.ReadOnly = true;
            uiButton5.Visible = false;


        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            load_cbo_role();
            load_cbo_tt();
            load_cbo_nhanVien();


            load_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void load_data()
        {
            DataTable dt = db.ExecuteStoredProcedure("GetUsersWithName");
            dataGridView1.DataSource = dt;

        }
        private void load_cbo_tt()
        {
            string[] s = new string[] { "Active", "Not Active" };
            cbo_tt.DataSource = s;
        }
        
        private void load_cbo_nhanVien()
        {
            //nhan vien chua co tai khoan
            DataTable dt = db.ExecuteStoredProcedure("GetMaVaTenKhongCoTKCuaNV");

            //MaNhanVien, HoTen
            cbB_NhanVien.DataSource = dt;
            cbB_NhanVien.DisplayMember = "HoTen";
            cbB_NhanVien.ValueMember = "MaNhanVien";

            cbB_NhanVien.SelectedIndex = -1;
        }
        private void load_cbo_role()
        {
            List<ComboBoxItem> roles = new List<ComboBoxItem>
            {
                
                new ComboBoxItem { Value = 1, Text = "1.Quản lý" },
                new ComboBoxItem { Value = 2, Text = "2.Nhân viên" },

            };

            cbo_role.DataSource = roles;
            cbo_role.DisplayMember = "Text";
            cbo_role.ValueMember = "Value";

            cbo_role.SelectedIndex = -1;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                maNhanVien = (row.Cells["MaNhanVien"].Value.ToString());


                txt_tenTK.Text = (row.Cells[0].Value.ToString());
                txt_MatKhau.Text = row.Cells[4].Value.ToString();
                
                cbB_NhanVien.Text = row.Cells[2].Value.ToString();
                txt_hash.Text=row.Cells[3].Value.ToString();
                
                cbo_role.SelectedValue = Convert.ToInt32(row.Cells[5].Value);
                
                string status = row.Cells["Status"].Value?.ToString();
                cbo_tt.Text = status;

            }
        }
        

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TaiKhoan", txt_tenTK.Text),
                new SqlParameter("@MaNhanVien", int.Parse(cbB_NhanVien.SelectedValue.ToString())),
                new SqlParameter("@PasswordHash", txt_hash.Text),
                new SqlParameter("@PasswordSalt", txt_MatKhau.Text),
                new SqlParameter("@Quyen", int.Parse(cbo_role.SelectedValue.ToString())),
                new SqlParameter("@Status", cbo_tt.SelectedItem.ToString())
                
                
            };
            db.ExecuteProcNonQuery("InsertUser", parameters);
            load_data();
            MessageBox.Show("Thêm tài khoản thành công");   
            
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TaiKhoan", txt_tenTK.Text),
                //new SqlParameter("@MaNhanVien", int.Parse(cbB_NhanVien.SelectedValue.ToString())),
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@PasswordHash", txt_hash.Text),
                new SqlParameter("@PasswordSalt", txt_MatKhau.Text),
                new SqlParameter("@Quyen", int.Parse(cbo_role.SelectedValue.ToString())),
                new SqlParameter("@Status", cbo_tt.SelectedItem.ToString())
            };
            int row = db.ExecuteProcNonQuery("UpdateUser", parameters);
            if( row > 0)
            {
                load_data();
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản that bai");
            }
            
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                
                string tk = row.Cells["TaiKhoan"].Value.ToString();

                
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TaiKhoan", tk)
                };

                
                db.ExecuteProcNonQuery("DeleteUser", parameters);
                load_data();
                MessageBox.Show("Xóa tài khoản thành công");
                clearInput();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.");
            }
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            clearInput();
        }
        void clearInput()
        {
            txt_tenTK.Text = "";
            txt_MatKhau.Text = "";
            cbB_NhanVien.SelectedIndex = -1;
            txt_hash.Text = "";
            cbo_role.SelectedIndex = 0;
            cbo_tt.SelectedIndex = 0;
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string search = txtB_TimKiemTK.Text;

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Search", search)
            };

            DataTable dt = db.ExecuteStoredProcedure("TimKiemTKByTKVaHoTen", parameter);

            dataGridView1.DataSource = dt;
        }
    }
}
