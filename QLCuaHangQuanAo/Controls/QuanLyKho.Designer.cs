namespace QLCuaHangQuanAo.UserCotrols
{
    partial class QuanLyKho
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.txt_Ten = new Sunny.UI.UITextBox();
            this.txt_Gia = new Sunny.UI.UITextBox();
            this.cbo_loai = new System.Windows.Forms.ComboBox();
            this.btn_them = new Sunny.UI.UIButton();
            this.btn_xoa = new Sunny.UI.UIButton();
            this.btn_sua = new Sunny.UI.UIButton();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.cbo_mau = new System.Windows.Forms.ComboBox();
            this.btn_Luu = new Sunny.UI.UIButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txt_SoLuong = new Sunny.UI.UITextBox();
            this.AnhSP = new System.Windows.Forms.PictureBox();
            this.btn_ChonAnh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbo_Size = new System.Windows.Forms.ComboBox();
            this.lal = new Sunny.UI.UILabel();
            this.txt_MoTa = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.btn_clear = new Sunny.UI.UIButton();
            this.btn_Huy = new Sunny.UI.UIButton();
            this.btnThemLoai = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnhSP)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1268, 405);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(16, 16);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(147, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Tên sản phẩm";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(21, 55);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "Loại";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(448, 16);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "Màu sắc";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(710, 55);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(153, 23);
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "Giá ";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel5.Click += new System.EventHandler(this.uiLabel5_Click);
            // 
            // txt_Ten
            // 
            this.txt_Ten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Ten.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ten.Location = new System.Drawing.Point(170, 9);
            this.txt_Ten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Ten.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Ten.ShowText = false;
            this.txt_Ten.Size = new System.Drawing.Size(225, 29);
            this.txt_Ten.TabIndex = 6;
            this.txt_Ten.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Ten.Watermark = "";
            // 
            // txt_Gia
            // 
            this.txt_Gia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Gia.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txt_Gia.Location = new System.Drawing.Point(852, 54);
            this.txt_Gia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Gia.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Gia.Name = "txt_Gia";
            this.txt_Gia.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Gia.ShowText = false;
            this.txt_Gia.Size = new System.Drawing.Size(153, 29);
            this.txt_Gia.TabIndex = 7;
            this.txt_Gia.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Gia.Watermark = "";
            // 
            // cbo_loai
            // 
            this.cbo_loai.FormattingEnabled = true;
            this.cbo_loai.Location = new System.Drawing.Point(170, 59);
            this.cbo_loai.Name = "cbo_loai";
            this.cbo_loai.Size = new System.Drawing.Size(119, 24);
            this.cbo_loai.TabIndex = 9;
            // 
            // btn_them
            // 
            this.btn_them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_them.Location = new System.Drawing.Point(141, 146);
            this.btn_them.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(100, 35);
            this.btn_them.TabIndex = 11;
            this.btn_them.Text = "Thêm";
            this.btn_them.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_them.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_xoa.Location = new System.Drawing.Point(267, 146);
            this.btn_xoa.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(100, 35);
            this.btn_xoa.TabIndex = 12;
            this.btn_xoa.Text = "Xoá ";
            this.btn_xoa.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_xoa.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sua.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_sua.Location = new System.Drawing.Point(396, 146);
            this.btn_sua.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(100, 35);
            this.btn_sua.TabIndex = 13;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_sua.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiButton4.Location = new System.Drawing.Point(1175, 146);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(100, 35);
            this.uiButton4.TabIndex = 14;
            this.uiButton4.Text = "Tìm kiếm";
            this.uiButton4.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // cbo_mau
            // 
            this.cbo_mau.FormattingEnabled = true;
            this.cbo_mau.Location = new System.Drawing.Point(554, 16);
            this.cbo_mau.Name = "cbo_mau";
            this.cbo_mau.Size = new System.Drawing.Size(172, 24);
            this.cbo_mau.TabIndex = 15;
            // 
            // btn_Luu
            // 
            this.btn_Luu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_Luu.Location = new System.Drawing.Point(517, 146);
            this.btn_Luu.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(100, 35);
            this.btn_Luu.TabIndex = 16;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(747, 17);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(147, 23);
            this.uiLabel4.TabIndex = 17;
            this.uiLabel4.Text = "Số lượng";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SoLuong.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txt_SoLuong.Location = new System.Drawing.Point(852, 17);
            this.txt_SoLuong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoLuong.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Padding = new System.Windows.Forms.Padding(5);
            this.txt_SoLuong.ShowText = false;
            this.txt_SoLuong.Size = new System.Drawing.Size(150, 29);
            this.txt_SoLuong.TabIndex = 18;
            this.txt_SoLuong.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_SoLuong.Watermark = "";
            // 
            // AnhSP
            // 
            this.AnhSP.Location = new System.Drawing.Point(1135, 9);
            this.AnhSP.Name = "AnhSP";
            this.AnhSP.Size = new System.Drawing.Size(140, 124);
            this.AnhSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AnhSP.TabIndex = 53;
            this.AnhSP.TabStop = false;
            // 
            // btn_ChonAnh
            // 
            this.btn_ChonAnh.Location = new System.Drawing.Point(1014, 9);
            this.btn_ChonAnh.Name = "btn_ChonAnh";
            this.btn_ChonAnh.Size = new System.Drawing.Size(115, 23);
            this.btn_ChonAnh.TabIndex = 52;
            this.btn_ChonAnh.Text = "Chọn ảnh";
            this.btn_ChonAnh.UseVisualStyleBackColor = true;
            this.btn_ChonAnh.Click += new System.EventHandler(this.btn_ChonAnh_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1027, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 22);
            this.textBox1.TabIndex = 54;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cbo_Size
            // 
            this.cbo_Size.FormattingEnabled = true;
            this.cbo_Size.Location = new System.Drawing.Point(554, 54);
            this.cbo_Size.Name = "cbo_Size";
            this.cbo_Size.Size = new System.Drawing.Size(172, 24);
            this.cbo_Size.TabIndex = 57;
            // 
            // lal
            // 
            this.lal.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lal.Location = new System.Drawing.Point(448, 54);
            this.lal.Name = "lal";
            this.lal.Size = new System.Drawing.Size(100, 23);
            this.lal.TabIndex = 56;
            this.lal.Text = "Size";
            this.lal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_MoTa
            // 
            this.txt_MoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MoTa.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MoTa.Location = new System.Drawing.Point(170, 91);
            this.txt_MoTa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MoTa.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_MoTa.Name = "txt_MoTa";
            this.txt_MoTa.Padding = new System.Windows.Forms.Padding(5);
            this.txt_MoTa.ShowText = false;
            this.txt_MoTa.Size = new System.Drawing.Size(780, 47);
            this.txt_MoTa.TabIndex = 59;
            this.txt_MoTa.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_MoTa.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(21, 98);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(147, 23);
            this.uiLabel6.TabIndex = 58;
            this.uiLabel6.Text = "Mô tả";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_clear
            // 
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_clear.Location = new System.Drawing.Point(773, 146);
            this.btn_clear.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(100, 35);
            this.btn_clear.TabIndex = 60;
            this.btn_clear.Text = "Clear";
            this.btn_clear.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Huy.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_Huy.Location = new System.Drawing.Point(636, 146);
            this.btn_Huy.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(100, 35);
            this.btn_Huy.TabIndex = 61;
            this.btn_Huy.Text = "Huỷ";
            this.btn_Huy.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btnThemLoai
            // 
            this.btnThemLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemLoai.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnThemLoai.Location = new System.Drawing.Point(309, 59);
            this.btnThemLoai.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThemLoai.Name = "btnThemLoai";
            this.btnThemLoai.Size = new System.Drawing.Size(86, 24);
            this.btnThemLoai.TabIndex = 11;
            this.btnThemLoai.Text = "Thêm Loại";
            this.btnThemLoai.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnThemLoai.Click += new System.EventHandler(this.uiButtonThemLoai_Click);
            // 
            // QuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.txt_MoTa);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.cbo_Size);
            this.Controls.Add(this.lal);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AnhSP);
            this.Controls.Add(this.btn_ChonAnh);
            this.Controls.Add(this.txt_SoLuong);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.cbo_mau);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btnThemLoai);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.cbo_loai);
            this.Controls.Add(this.txt_Gia);
            this.Controls.Add(this.txt_Ten);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QuanLyKho";
            this.Size = new System.Drawing.Size(1349, 777);
            this.Load += new System.EventHandler(this.QuanLyKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnhSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txt_Ten;
        private Sunny.UI.UITextBox txt_Gia;
        private System.Windows.Forms.ComboBox cbo_loai;
        private Sunny.UI.UIButton btn_them;
        private Sunny.UI.UIButton btn_xoa;
        private Sunny.UI.UIButton btn_sua;
        private Sunny.UI.UIButton uiButton4;
        private System.Windows.Forms.ComboBox cbo_mau;
        private Sunny.UI.UIButton btn_Luu;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txt_SoLuong;
        private System.Windows.Forms.PictureBox AnhSP;
        private System.Windows.Forms.Button btn_ChonAnh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbo_Size;
        private Sunny.UI.UILabel lal;
        private Sunny.UI.UITextBox txt_MoTa;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton btn_clear;
        private Sunny.UI.UIButton btn_Huy;
        private Sunny.UI.UIButton btnThemLoai;
    }
}
