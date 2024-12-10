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
using QLCuaHangQuanAo;
using QLCuaHangQuanAo.Models;
using Sunny.UI;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class QLKhachHang : UserControl
    {
        List<KhachHang> listKH = new List<KhachHang>();
        DatabaseHelper db;
        int maKH;


        public QLKhachHang()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            uiButton5.Visible = false;

            load_data();
            load_cbo_gt();
        }


        private void load_data()
        {
            DataTable dt = db.ExecuteQuery("select * from KhachHang");

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[6].Width = 150;
        }
        private void load_cbo_gt()
        {
            string[] genders = new string[] { "Nam", "Nữ" };


            cbo_gt.DataSource = genders;
            cbo_gt.SelectedIndex = -1;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                maKH = int.Parse(row.Cells[0].Value.ToString());
                txt_ten.Text = row.Cells[1].Value.ToString();
                txt_email.Text = row.Cells[2].Value.ToString();
                txt_sdt.Text = row.Cells[3].Value.ToString();
                cbo_gt.SelectedItem = row.Cells[4].Value.ToString();
                dateTimePicker1.Text = row.Cells[5].Value.ToString();
                txt_DiaChi.Text = row.Cells[6].Value.ToString();
            }
        }
        //them moi
        private void uiButton6_Click(object sender, EventArgs e)
        {
            clearInput();
            txt_ten.Focus();


        }

        void clearInput()
        {
            txt_ten.Text = "";
            txt_email.Text = "";
            txt_sdt.Text = "";
            cbo_gt.SelectedIndex = -1;
            txt_DiaChi.Text = "";


        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HoTen", txt_ten.Text),
                new SqlParameter("@Email", txt_email.Text),
                new SqlParameter("@SoDienThoai", txt_sdt.Text),
                new SqlParameter("@GioiTinh", cbo_gt.SelectedItem.ToString()),
                new SqlParameter("@NgaySinh", DateTime.Parse(dateTimePicker1.Text)),
                new SqlParameter("@DiaChi", txt_DiaChi.Text)
            };
            db.ExecuteProcNonQuery("InsertKhachHang", parameters);
            load_data();
            MessageBox.Show("Thêm thành công");
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

            SqlParameter[] parameters = {
                new SqlParameter("@MaKhachHang", maKH)
            };

            int result = db.ExecuteProcValueQuery("DeleteKhachHang", parameters);

            if (result == -1)
            {
                MessageBox.Show("Không thể xóa khách hang này vì đã tồn tại trong bảng hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == 0)
            {
                MessageBox.Show("Khách Hàng đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhachHang", maKH),
                new SqlParameter("@HoTen", txt_ten.Text),
                new SqlParameter("@Email", txt_email.Text),
                new SqlParameter("@SoDienThoai", txt_sdt.Text),
                new SqlParameter("@GioiTinh", cbo_gt.SelectedItem.ToString()),
                new SqlParameter("@NgaySinh", DateTime.Parse(dateTimePicker1.Text)),
                new SqlParameter("@DiaChi", txt_DiaChi.Text)
            };
            int rowsAffected = db.ExecuteProcNonQuery("UpdateKhachHang", parameters);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có thông tin nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
            load_data();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            //foreach (KhachHang nhanVien in list)
            //{
            //    KhachHang c = ql.KhachHangs.FirstOrDefault(t => t.MaKhachHang == nhanVien.MaKhachHang);
            //    if (c != null)
            //    {


            //        ql.Entry(c).CurrentValues.SetValues(nhanVien);



            //    }

            //}
            //foreach (KhachHang x in addkh)
            //{
            //    ql.KhachHangs.Add(x);
            //}
            //addkh = new List<KhachHang>();
            //foreach (KhachHang x in delete)
            //{
            //    var deletedItem = ql.KhachHangs.FirstOrDefault(t => t.MaKhachHang == x.MaKhachHang);
            //    ql.KhachHangs.Remove(deletedItem);
            //}
            //delete = new List<KhachHang>();
            //ql.SaveChanges();
            //load_data();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string search = txtB_timKiem.Text;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SearchTerm", search)
            };

            DataTable dt = db.ExecuteStoredProcedure("SearchKhachHang", parameters);
            dataGridView1.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
