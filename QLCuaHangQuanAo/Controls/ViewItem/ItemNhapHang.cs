using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QLCuaHangQuanAo.UserCotrols
{
    public partial class ItemNhapHang : UserControl
    {
        public string name;
        public string price;
        public string Imagess;
        public int Count=0;
        public string SizeSP1;
        public string color;
        public event EventHandler Selected =null;
      
        public ItemNhapHang()
        {
            InitializeComponent();
        }

        private void Item_Load(object sender, EventArgs e)
        {
          
        }

        public void SetSP(string ten, string anh,string size,string color)
        {
            this.SizeSP1 = size;
            this.color = color;
            this.name = ten;
            //this.price = gia;
            this.Imagess =anh;
            txt_SoLuong.Text = "0";

            //string imagePath = Path.Combine(Application.StartupPath, "Images", anh);
            string imagePath = Path.GetFullPath(Path.Combine(Application.StartupPath, "../..", "Images", anh));
            ImageSP.Image = Image.FromFile(imagePath);
            

            NameSP.Text = ten;
            
            //gia = GiaSP.Text ;
            ColorSP.Text = color;
            SizeSP.Text = size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             Selected?.Invoke(this,e);

        }

        private void Item_Click(object sender, EventArgs e)
        {
            
        }

        
        public event EventHandler OnAddItemHD;

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Count++;
            txt_SoLuong.Text = Count.ToString();
        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(price) || Count == 0)
            {
                MessageBox.Show("Vui lòng nhập giá và số lượng hợp lệ!");
                return;
            }
            OnAddItemHD?.Invoke(this, EventArgs.Empty);
        }

        private void GiaSP_Click(object sender, EventArgs e)
        {

        }

        private void btn_Giam_Click(object sender, EventArgs e)
        {
            if (Count == 0) {return;}
            Count--;
            txt_SoLuong.Text= Count.ToString();
            
        }

        private void GiaSP_TextChanged(object sender, EventArgs e)
        {
            price = txt_GiaNhap.Text;
        }
    }
}
