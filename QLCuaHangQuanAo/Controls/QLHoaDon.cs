using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public QLHoaDon()
        {
            InitializeComponent();
        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            QuanLyCuaHangQuanAoEntities2 ql = new QuanLyCuaHangQuanAoEntities2();
            dataGridView1.DataSource = ql.HoaDons.ToList();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            QuanLyCuaHangQuanAoEntities2 ql = new QuanLyCuaHangQuanAoEntities2();
            dataGridView1.DataSource = null;
            var x=ql.ChiTietHoaDons.Where(t=>t.MaHoaDon==ma).ToList();
            dataGridView1 .DataSource = x;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ma =int.Parse( row.Cells[0].Value.ToString());
            }    
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            QuanLyCuaHangQuanAoEntities2 ql = new QuanLyCuaHangQuanAoEntities2();
            dataGridView1.DataSource = ql.HoaDons.ToList();
        }
    }
}
