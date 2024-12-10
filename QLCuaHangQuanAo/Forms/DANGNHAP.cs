﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangQuanAo
{
    public partial class DANGNHAP : Form
    {
        public string username;
        public int id;
        private DatabaseHelper db;
        public DANGNHAP()
        {
            InitializeComponent();

            db = new DatabaseHelper();
        }



        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txt_UserName.Text;
            string password = txt_PassWord.Text;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TaiKhoan", taiKhoan),
                new SqlParameter("@Password", password)
            };

            DataTable dt = db.ExecuteStoredProcedure("ValidateUser",parameters);

            if (dt.Rows.Count > 0)
            {
                string user = dt.Rows[0]["HoTen"].ToString();
                int id = (int)dt.Rows[0]["MaNhanVien"];
                FORMCHINH f = new FORMCHINH(id,user);
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!!", "Đăng nhập thất bại");
                txt_PassWord.Clear();
            }

        }

        private void Btn_DangKy_Click(object sender, EventArgs e)
        {
            //DANGKY DangKy = new DANGKY();
       
            //DangKy.Show();
            //this.Hide();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}