using QLCuaHangQuanAo.UserCotrols;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLCuaHangQuanAo
{
    public partial class DANGKY : Form
    {
        private DatabaseHelper db;

        public DANGKY()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        

        private bool kt()
        {
            //SqlParameter[] parameters = {
            //    new SqlParameter("@TaiKhoan", txt_username.Text)
            //};

            //int userCount = (int)db.ExecuteProcValueQuery("CheckUsernameExists", parameters);

            //if (userCount > 0)
            //{
            //    MessageBox.Show("Tên tài khoản đã tồn tại trong hệ thống vui lòng đặt tên tài khoản khác!!", "Lỗi");
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_pass.Text) || string.IsNullOrEmpty(txt_repass.Text) || string.IsNullOrEmpty(txt_sdt.Text) || string.IsNullOrEmpty(txt_username.Text) || !(chk_Nam.Checked || chk_Nu.Checked))
            //{
            //    MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin!!", "Lỗi");
            //    return false;
            //}

            //if (txt_pass.Text.Length < 8 || txt_username.Text.Length < 5)
            //{
            //    MessageBox.Show("Tên tài khoản dài hơn 4 kí tự, mật khẩu từ 8 ký tự trở lên", "Lỗi");
            //    return false;
            //}

            //if (txt_pass.Text != txt_repass.Text)
            //{
            //    MessageBox.Show("Mật khẩu và Nhập lại mật khẩu không khớp!!", "Lỗi");
            //    return false;
            //}

            return true;
        }

        private void Btn_DangKy_Click(object sender, EventArgs e)
        {
            if (kt())
            {
                try
                {
                    string gt = chk_Nam.Checked ? "Nam" : "Nữ";

                    SqlParameter[] nvParameters = {
                        new SqlParameter("@HoTen", ""),
                        new SqlParameter("@ChucVu", "Nhân viên"),
                        new SqlParameter("@NgayVaoLam", DateTime.Now),
                        new SqlParameter("@Email", txt_email.Text),
                        new SqlParameter("@SoDienThoai", txt_sdt.Text),
                        new SqlParameter("@GioiTinh", gt)
                    };

                    DataTable nvResult = db.ExecuteStoredProcedure("ThemNhanVien", nvParameters);
                    int maNhanVien = Convert.ToInt32(nvResult.Rows[0]["MaNhanVien"]);

                    SqlParameter[] userParameters = {
                        new SqlParameter("@TaiKhoan", txt_username.Text),
                        new SqlParameter("@MaNhanVien", maNhanVien),
                        new SqlParameter("@PasswordHash", txt_pass.Text.Substring(4)),
                        new SqlParameter("@PasswordSalt", txt_pass.Text.Substring(0, 4)),
                        new SqlParameter("@Quyen", 2),
                        new SqlParameter("@Status", "Not Active")
                    };

                    db.ExecuteStoredProcedure("ThemUser", userParameters);

                    MessageBox.Show("Bạn đã đăng ký thành công! Vui lòng chờ quản lý Active tài khoản để đăng nhập!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
                }
            }
            else
            {
                txt_username.Clear();
                txt_pass.Clear();
                txt_repass.Clear();
                txt_email.Clear();
                txt_sdt.Clear();
                chk_Nam.Checked = false;
                chk_Nu.Checked = false;
            }
        }

        private void panel13_Paint(object sender, PaintEventArgs e) { }

        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            DANGNHAP fdn = new DANGNHAP();
            fdn.Show();
            this.Hide();
        }

        #region empty code
        private void uiLabel1_Click(object sender, EventArgs e) { }

        private void uiLabel1_Click_1(object sender, EventArgs e) { }

        private void uiTextBox2_TextChanged(object sender, EventArgs e) { }

        private void uiTextBox1_TextChanged(object sender, EventArgs e) { }

        private void uiTextBox1_MouseClick(object sender, MouseEventArgs e) { }

        private void uiTextBox1_MouseHover(object sender, EventArgs e) { }

        private void uiTextBox3_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void uiLabel6_Click(object sender, EventArgs e) { }

        private void panel12_Paint(object sender, PaintEventArgs e) { }

        private void uiTextBox5_TextChanged(object sender, EventArgs e) { }

        private void uiLabel5_Click(object sender, EventArgs e) { }

        private void panel11_Paint(object sender, EventArgs e) { }

        private void uiTextBox4_TextChanged(object sender, EventArgs e) { }

        private void uiLabel4_Click(object sender, EventArgs e) { }

        private void panel10_Paint(object sender, PaintEventArgs e) { }

        private void panel5_Paint(object sender, PaintEventArgs e) { }

        private void uiLabel2_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void uiSmoothLabel1_Click(object sender, EventArgs e) { }

        private void panel8_Paint(object sender, PaintEventArgs e) { }

        private void panel6_Paint(object sender, PaintEventArgs e) { }

        private void panel7_Paint(object sender, PaintEventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void uiLabel3_Click(object sender, EventArgs e) { }

        private void panel4_Paint(object sender, PaintEventArgs e) { }

        private void panel9_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox7_Click(object sender, EventArgs e) { }

        private void pictureBox6_Click(object sender, EventArgs e) { }

        private void pictureBox8_Click(object sender, EventArgs e) { }

        private void pictureBox5_Click(object sender, EventArgs e) { }

        private void pictureBox4_Click(object sender, EventArgs e) { }

        private void pictureBox3_Click(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        #endregion


    }
}
