using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class HinhTron : HinhHoc
    {
        // Field
        public float banKinh;
        public string kieuHinhHoc = "Hình tròn";

        // Constructor
        public HinhTron()
        { }
        public HinhTron(float r)
        {
            banKinh = r;
        }

        // Function
        public override string KieuHinhHoc()
        {
            return kieuHinhHoc;
        }
        public override float TinhCV()
        {
            return (float)Math.Round(2 * Math.PI * banKinh);
        }
        public override float TinhDT()
        {
            return (float)Math.Round(Math.PI * banKinh * banKinh, 0);
        }
        public override string ToString()
        {
            return ("Bán kính: " + banKinh.ToString()).PadRight(20) + ("Chu vi: " + TinhCV().ToString()).PadRight(20) + ("Diện tích: " + TinhDT().ToString()).PadRight(20);
        }

    }
}

