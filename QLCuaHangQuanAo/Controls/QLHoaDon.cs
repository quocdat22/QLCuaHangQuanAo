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

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class QLHoaDon : UserControl
    {
        int ma;
        DatabaseHelper db;

        public QLHoaDon()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void load_data()
        {
            DataTable dt = db.ExecuteStoredProcedure("GetHoaDonKHNV");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Width = 150;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHoaDon", ma)
            };

            DataTable dt = db.ExecuteStoredProcedure("GetChiTietHoaDonByMaHoaDon", parameters);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ma = int.Parse(row.Cells[0].Value.ToString());
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btn_Seacrh_Click(object sender, EventArgs e)
        {
            string searchValue = txt_TimKiem.Text;
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            SqlParameter[] sqlParameter =
            {
                new SqlParameter("@Search", searchValue)
            };
            DataTable dataTable = db.ExecuteStoredProcedure("timKiemHoaDonKHNV", sqlParameter);

            dataGridView1.DataSource = dataTable;

        }
    }
}
