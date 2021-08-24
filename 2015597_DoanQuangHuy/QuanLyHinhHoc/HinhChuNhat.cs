using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class HinhChuNhat : HinhHoc
    {
        // Field
        public float chieuDai, chieuRong;
        public string kieuHinhHoc = "Hình chữ nhật";

        // Constructor
        public HinhChuNhat()
        { }
        public HinhChuNhat(float cd, float cr)
        {
            chieuDai = cd;
            chieuRong = cr;
        }

        // Function
        public override string KieuHinhHoc()
        {
            return kieuHinhHoc;
        }
        public override float TinhCV()
        {
            return (float)Math.Round(chieuDai + chieuRong);
        }
        public override float TinhDT()
        {
            return (float)Math.Round(chieuDai * chieuRong);
        }
        public override string ToString()
        {
            return ("Chiều dài: " + chieuDai.ToString()).PadRight(20) + ("Chiều rộng: " + chieuRong.ToString()).PadRight(20) + ("Chu vi: " + TinhCV().ToString()).PadRight(20) + ("Diện tích: " + TinhDT().ToString()).PadRight(20);
        }

    }
}
