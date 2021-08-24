using System;
using System.IO;

namespace QuanLyPhanSo
{
    enum Menu
    {
        Thoat = 10,
        Nhap = 1,
        Xuat = 2,
        NhapFile = 3,
        NhapRandom = 4,
        TimMax = 5,
        TimTheoMau = 6
    }
    class Program
    {
        static void Main(string[] args)
        {
            MangPhanSo ds = new MangPhanSo();
            while (true)
            {
                Console.WriteLine("Nhan {0} de thoat ", (int)Menu.Thoat);
                Console.WriteLine("Nhan {0} de Nhap File ", (int)Menu.Nhap);
                Console.WriteLine("Nhan {0} de Xuat File ", (int)Menu.Xuat);
                Console.WriteLine("Nhan {0} de Nhap tu File ", (int)Menu.NhapFile);
                Console.WriteLine("Nhan {0} de Nhap Ngau Nhien ", (int)Menu.NhapRandom);
                Console.WriteLine("Nhan {0} de Tim Max ", (int)Menu.TimMax);
                Console.WriteLine("Nhan {0} de tim phan so co mau la x ", (int)Menu.TimTheoMau);

                Menu menu = (Menu)int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case Menu.Thoat: return;
                    case Menu.Nhap:
                        ds.Nhap();
                        break;
                    case Menu.Xuat:
                        ds.Xuat();
                        break;
                    case Menu.NhapFile:
                        ds.NhapTuFile();
                        ds.Xuat();
                        break;
                    case Menu.NhapRandom:
                        ds.NhapNgauNhien();
                        ds.Xuat();
                        break;
                    case Menu.TimMax:
                        ds.TimMax();
                        ds.Xuat();
                        break;
                    case Menu.TimTheoMau:
                        ds.TimPhanSoCoMauLa();
                        ds.Xuat();
                        break;
                }
            }
        }
    }
}
