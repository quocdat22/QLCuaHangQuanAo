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

namespace QLCuaHangQuanAo.Forms.MiniForms
{
    public partial class ThemNhaCungCap : Form
    {
        private Label lblTenNhaCungCap;
        private TextBox txtTenNhaCungCap;
        private Label lblNguoiLienHe;
        private TextBox txtNguoiLienHe;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Button btnSave;
        private Button btnCancel;

        DatabaseHelper db;

        public ThemNhaCungCap()
        {
            InitializeComponent();
            InitializeCustomComponents();

            db = new DatabaseHelper();
        }

        private void InitializeCustomComponents()
        {
            this.ClientSize = new Size(400, 300);
            // Initialize Labels
            lblTenNhaCungCap = new Label();
            lblTenNhaCungCap.Text = "Tên Nhà Cung Cấp";
            lblTenNhaCungCap.Location = new Point(20, 20);
            lblTenNhaCungCap.AutoSize = true;

            lblNguoiLienHe = new Label();
            lblNguoiLienHe.Text = "Người Liên Hệ";
            lblNguoiLienHe.Location = new Point(20, 60);
            lblNguoiLienHe.AutoSize = true;

            lblDiaChi = new Label();
            lblDiaChi.Text = "Địa Chỉ";
            lblDiaChi.Location = new Point(20, 100);
            lblDiaChi.AutoSize = true;

            lblSoDienThoai = new Label();
            lblSoDienThoai.Text = "Số Điện Thoại";
            lblSoDienThoai.Location = new Point(20, 140);
            lblSoDienThoai.AutoSize = true;

            // Initialize TextBoxes
            txtTenNhaCungCap = new TextBox();
            txtTenNhaCungCap.Location = new Point(150, 20);
            txtTenNhaCungCap.Width = 200;

            txtNguoiLienHe = new TextBox();
            txtNguoiLienHe.Location = new Point(150, 60);
            txtNguoiLienHe.Width = 200;

            txtDiaChi = new TextBox();
            txtDiaChi.Location = new Point(150, 100);
            txtDiaChi.Width = 200;

            txtSoDienThoai = new TextBox();
            txtSoDienThoai.Location = new Point(150, 140);
            txtSoDienThoai.Width = 200;

            // Initialize Buttons
            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(150, 180);
            btnSave.Click += new EventHandler(btnSave_Click);

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(250, 180);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            // Add controls to the form
            this.Controls.Add(lblTenNhaCungCap);
            this.Controls.Add(txtTenNhaCungCap);
            this.Controls.Add(lblNguoiLienHe);
            this.Controls.Add(txtNguoiLienHe);
            this.Controls.Add(lblDiaChi);
            this.Controls.Add(txtDiaChi);
            this.Controls.Add(lblSoDienThoai);
            this.Controls.Add(txtSoDienThoai);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save logic here
            string tenNhaCungCap = txtTenNhaCungCap.Text;
            string nguoiLienHe = txtNguoiLienHe.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;

            SqlParameter[] sqlParameter =
            {
                new SqlParameter("@Ten", tenNhaCungCap),
                new SqlParameter("@NguoiLH", nguoiLienHe),
                new SqlParameter("@DiaChi", diaChi),
                new SqlParameter("@SDT", soDienThoai)
            };

            db.ExecuteStoredProcedure("themNhaCungCap", sqlParameter);

            MessageBox.Show("Thêm nhà cung cấp thành công");

            this.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
