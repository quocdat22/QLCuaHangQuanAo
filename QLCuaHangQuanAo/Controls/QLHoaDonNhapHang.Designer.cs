﻿namespace QLCuaHangQuanAo.UserCotrols
{
    partial class QLHoaDonNhapHang
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
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_TimKiem = new Sunny.UI.UITextBox();
            this.btn_Seacrh = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiTextBox1.Location = new System.Drawing.Point(108, -32);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(150, 29);
            this.uiTextBox1.TabIndex = 30;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(-46, -32);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(147, 23);
            this.uiLabel1.TabIndex = 29;
            this.uiLabel1.Text = "Tên tài khoản";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(85, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1098, 558);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimKiem.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txt_TimKiem.Location = new System.Drawing.Point(528, 16);
            this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TimKiem.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Padding = new System.Windows.Forms.Padding(5);
            this.txt_TimKiem.ShowText = false;
            this.txt_TimKiem.Size = new System.Drawing.Size(263, 29);
            this.txt_TimKiem.TabIndex = 32;
            this.txt_TimKiem.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_TimKiem.Watermark = "";
            // 
            // btn_Seacrh
            // 
            this.btn_Seacrh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Seacrh.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_Seacrh.Location = new System.Drawing.Point(811, 11);
            this.btn_Seacrh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Seacrh.Name = "btn_Seacrh";
            this.btn_Seacrh.Size = new System.Drawing.Size(109, 35);
            this.btn_Seacrh.TabIndex = 33;
            this.btn_Seacrh.Text = "Tìm kiếm";
            this.btn_Seacrh.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_Seacrh.Click += new System.EventHandler(this.btn_Seacrh_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiButton2.Location = new System.Drawing.Point(1087, 13);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(96, 35);
            this.uiButton2.TabIndex = 34;
            this.uiButton2.Text = "Quay lại";
            this.uiButton2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // QLHoaDonNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.btn_Seacrh);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QLHoaDonNhapHang";
            this.Size = new System.Drawing.Size(1375, 662);
            this.Load += new System.EventHandler(this.QLHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Sunny.UI.UITextBox txt_TimKiem;
        private Sunny.UI.UIButton btn_Seacrh;
        private Sunny.UI.UIButton uiButton2;
    }
}
