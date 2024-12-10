using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangQuanAo.Models
{
    internal class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text; // Hiển thị thuộc tính Text trong ComboBox
        }
    }
}
