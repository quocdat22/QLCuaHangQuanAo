using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangQuanAo.Forms.MiniForms
{
    public partial class InputForm : Form
    {
        public string InputValue { get; private set; } // Giá trị từ TextBox
        private TextBox txtInput;
        private Button btnConfirm;
        private Button btnCancel;
        public InputForm()
        {
            InitializeComponent();
            settingForm();
        }

        void settingForm()
        {
            this.Text = "Nhập dữ liệu";
            this.Size = new System.Drawing.Size(300, 150);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Tạo TextBox
            txtInput = new TextBox
            {
                Location = new System.Drawing.Point(50, 20),
                Width = 200
            };
            this.Controls.Add(txtInput);

            // Tạo nút Xác nhận
            btnConfirm = new Button
            {
                Text = "Xác nhận",
                Location = new System.Drawing.Point(50, 70),
                Width = 80
            };
            btnConfirm.Click += BtnConfirm_Click; // Gắn sự kiện Click
            this.Controls.Add(btnConfirm);

            // Tạo nút Quay lại
            btnCancel = new Button
            {
                Text = "Quay lại",
                Location = new System.Drawing.Point(150, 70),
                Width = 80
            };
            btnCancel.Click += BtnCancel_Click; // Gắn sự kiện Click
            this.Controls.Add(btnCancel);
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox và đóng form
            InputValue = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Hủy bỏ hành động và đóng form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
