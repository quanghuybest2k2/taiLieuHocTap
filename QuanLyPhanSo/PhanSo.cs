using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhanSo
{
    class PhanSo
    {
        public int tu;
        public int mau;
        public PhanSo()
        {
            mau = 1;
        }
        public PhanSo(int t, int m)
        {
            tu = t;
            mau = m;
        }

        public void Nhap()
        {
            Console.Write("Nhap tu: ");
            tu = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau: ");
            mau = int.Parse(Console.ReadLine());
        }
        public void Xuat()
        {
            Console.WriteLine("{0}/{1}", tu, mau);
        }
    }
}