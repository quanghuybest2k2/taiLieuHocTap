using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class HinhVuong : HinhHoc
    {
        // Field
        public float canh;
        public string kieuHinhHoc = "Hình vuông";

        // Constructor
        public HinhVuong()
        { }
        public HinhVuong(float c)
        {
            canh = c;
        }

        // Function
        public override string KieuHinhHoc()
        {
            return kieuHinhHoc;
        }
        public override float TinhCV()
        {
            return (float)Math.Round(canh * 4);
        }
        public override float TinhDT()
        {
            return (float)Math.Round(canh * canh, 0);
        }
        public override string ToString()
        {
            return ("Cạnh: " + canh.ToString()).PadRight(20) + ("Chu vi: " + TinhCV().ToString()).PadRight(20) + ("Diện tích: " + TinhDT().ToString()).PadRight(20);
        }

    }
}