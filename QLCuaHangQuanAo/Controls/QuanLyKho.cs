using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class QuanLyKho : UserControl
     {
        string path;
        int masp;
   
        DataTable dt;
        QuanLyCuaHangQuanAo2Entities ql = new QuanLyCuaHangQuanAo2Entities();
        List<SanPham> sanPhamList=new List<SanPham>(); 
        private List<SanPham> deletedSanPhamList = new List<SanPham>();
        List<SanPham>add_sp=new List<SanPham>();

        public QuanLyKho()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {

            btn_xoa.Enabled = false;
            loaddata();
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;

        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SanPham s=new SanPham();
            s.TenSanPham = txt_Ten.Text;
            s.MauSac=cbo_mau.SelectedItem.ToString();
            s.Gia=decimal.Parse(txt_Gia.Text);

            s.MaLoai= int.Parse(cbo_loai.SelectedValue.ToString());
            
            s.SoLuongTonKho=int.Parse(txt_SoLuong.Text);
            s.MoTa=txt_MoTa.Text;
            s.Size=cbo_Size.SelectedItem.ToString();
            s.HinhAnh=path;
            SanPham x = new SanPham();
            x.TenSanPham = s.TenSanPham;
            x.MauSac = s.MauSac;
            x.MaLoai = s.MaLoai;
            x.Size = s.Size;
            x.SoLuongTonKho = s.SoLuongTonKho;
            x.Gia = s.Gia;
            x.HinhAnh = s.HinhAnh;
            sanPhamList = ql.SanPhams.ToList();
            
            sanPhamList.Add(s);
            add_sp.Add(x);
            sanPhamList[sanPhamList.Count - 1].MaSanPham = sanPhamList[sanPhamList.Count - 2].MaSanPham+1;
          

            dataGridView1.DataSource = null;
            dataGridView1.DataSource=sanPhamList;
           

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                masp = int.Parse(row.Cells[0].Value.ToString());
                txt_Ten.Text = row.Cells[1].Value.ToString();
                cbo_loai.SelectedValue = int.Parse(row.Cells[2].Value.ToString());

                cbo_mau.SelectedItem = row.Cells[5].Value.ToString();
                cbo_Size.SelectedItem = row.Cells[4].Value.ToString();
                txt_SoLuong.Text = row.Cells[8].Value.ToString();
                txt_Gia.Text = row.Cells[7].Value.ToString();
                txt_MoTa.Text = row.Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(row.Cells[6].Value?.ToString()))
                    AnhSP.Image = Image.FromFile(row.Cells[6].Value.ToString());
             
                btn_xoa.Enabled = true;
                btn_Huy.Enabled = true;
                btn_Luu.Enabled = true;
                btn_clear.Enabled = true;
                btn_sua.Enabled = true;
            }
            else
            { 
                

            }
            
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            SanPham s = sanPhamList.Find(t=>t.MaSanPham==masp);
            
            s.TenSanPham = txt_Ten.Text;
            s.MauSac = cbo_mau.SelectedItem.ToString();
            s.Gia = decimal.Parse(txt_Gia.Text);

            s.MaLoai = int.Parse(cbo_loai.SelectedValue.ToString());

            s.SoLuongTonKho = int.Parse(txt_SoLuong.Text);
            s.MoTa = txt_MoTa.Text;
            s.Size = cbo_Size.SelectedItem.ToString();
            s.HinhAnh=path;
            sanPhamList = ql.SanPhams.ToList();
      
            

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sanPhamList;
        }

        
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            foreach (SanPham i in sanPhamList)
            {
                
                
                    SanPham existingProduct = ql.SanPhams.FirstOrDefault(t=>t.MaSanPham==i.MaSanPham);
                if (existingProduct != null)
                {
                    existingProduct.TenSanPham = i.TenSanPham;
                    existingProduct.MauSac = i.MauSac;
                    existingProduct.MaLoai = i.MaLoai;
                    existingProduct.Size = i.Size;
                    existingProduct.SoLuongTonKho = i.SoLuongTonKho;
                    existingProduct.Gia = i.Gia;
                    existingProduct.HinhAnh = i.HinhAnh;

                }
               
                
            }
            foreach(SanPham x in add_sp)
            {
                ql.SanPhams.Add(x);
            }    
            add_sp = new List<SanPham>();
            foreach (SanPham deletedItem in deletedSanPhamList)
            {
                var i = ql.SanPhams.FirstOrDefault(t => t.MaSanPham ==deletedItem.MaSanPham );
                ql.SanPhams.Remove(i);
            }
            deletedSanPhamList = new List<SanPham>();
            ql.SaveChanges();
            btn_xoa.Enabled = false;
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;
        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Title = "Chọn ảnh";
            a.Filter = "anh Files(*.JPG; *.JPG; *.jpG; *.PnG; *.JPG)|*.JPG; *.JPG; *.jpG; *.PnG; *.JPG";
            if (a.ShowDialog() == DialogResult.OK)
            {
                 path = a.FileName;
                AnhSP.Image = Image.FromFile(a.FileName);

            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loaddata();
            btn_xoa.Enabled=false;
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;
        }

        private void loaddata()
        {
            using (QuanLyCuaHangQuanAo2Entities ql = new QuanLyCuaHangQuanAo2Entities())
            {
                try
                {
             
                    var loaiSanPham = ql.LoaiSanPhams.Select(l => new { l.MaLoai, l.TenLoai }).ToList();
                    var sizeSanPham = ql.SanPhams.Select(s => s.Size).ToList();
                    var mauSacSanPham = ql.SanPhams.Select(s => s.MauSac).ToList();


                    cbo_loai.DataSource = loaiSanPham;
                    cbo_loai.DisplayMember = "TenLoai";
                    cbo_loai.ValueMember = "MaLoai";

                    cbo_loai.SelectedValue = 1;

                   
                    cbo_mau.Items.Clear();
               
                    foreach (var color in mauSacSanPham)
                    {
                        cbo_mau.Items.Add(color);
                    }
                    cbo_mau.SelectedIndex = 0;

                    
                    cbo_Size.Items.Clear();
                   
                    foreach (var size in sizeSanPham)
                    {
                        cbo_Size.Items.Add(size);
                    }
                    cbo_Size.SelectedIndex = 0;

                 
                    sanPhamList = ql.SanPhams.ToList();
                    dataGridView1.DataSource = sanPhamList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo");
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
               
                int masp = int.Parse(row.Cells["MaSanPham"].Value.ToString());

                
                SanPham i = sanPhamList.FirstOrDefault(t=>t.MaSanPham == masp);

               
                if (i != null)
                {
                    sanPhamList.Remove(i);
                    deletedSanPhamList.Add(i); 
                }
            }
            dataGridView1.DataSource=null;
            dataGridView1.DataSource=sanPhamList;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
           txt_Ten.Clear();
             
           txt_Gia.Clear();


            txt_SoLuong.Clear();
            txt_MoTa.Clear();
          
            AnhSP.Image=null;

            btn_Huy.Enabled = false;
            btn_Luu.Enabled = false;
            btn_clear.Enabled = false;
            btn_sua.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            dataGridView1.DataSource = null;
           dataGridView1.DataSource=  ql.SanPhams.Where(t => t.TenSanPham.Contains(ten)).ToList();

        }
    }
}
