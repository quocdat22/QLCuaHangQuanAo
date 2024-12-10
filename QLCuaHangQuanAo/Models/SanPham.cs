using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangQuanAo.Models
{
    internal class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MauSac { get; set; }
        public decimal Gia { get; set; }
        public int MaLoai { get; set; }
        public int SoLuongTonKho { get; set; }
        public string MoTa { get; set; }
        public string Size { get; set; }
        public string HinhAnh { get; set; }

        
    }
}
