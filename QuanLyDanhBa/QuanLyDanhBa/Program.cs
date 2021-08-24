using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
    class Program
    {
        enum Menu
        {
            Thoat = 0,
            NhapDuLieuTuFile,
            XemDanhBa,
            ThueBaoCoNhieuSDT,
            SapXepTangTheoTen,
            SapXepGiamTheoNTNS
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhBa db = new DanhBa();
            while (true)
            {
                Console.WriteLine("__________________MENU TÙY CHỌN____________________");
                Console.WriteLine("Quan ly danh ba phan I - 5.1");
                Console.WriteLine("{0}. Thoat", (int)Menu.Thoat);
                Console.WriteLine("{0}. Nhap du lieu tu file", (int)Menu.NhapDuLieuTuFile);
                Console.WriteLine("{0}. Xem danh ba", (int)Menu.XemDanhBa);
                Console.WriteLine("{0}. Tim kiem thue bao co nhieu so dien thoai nhat", (int)Menu.ThueBaoCoNhieuSDT);
                Console.WriteLine("{0}. Sap xep danh ba tang dan theo ten", (int)Menu.SapXepTangTheoTen);
                Console.WriteLine("{0}. Sap xep danh ba giam dan theo ngay thang nam sinh", (int)Menu.SapXepGiamTheoNTNS);
                Console.WriteLine("___________________________________________________");
                Console.Write("Mời bạn chọn chức năng >> ");
                Menu menu = (Menu)int.Parse(Console.ReadLine());
                Console.WriteLine("______________________OUTPUT_______________________");
                switch (menu)
                {
                    case Menu.Thoat:
                        Console.WriteLine("Cam on vi da su dung!");
                        return;
                    case Menu.NhapDuLieuTuFile:
                        db.NhapTuFile();
                        Console.WriteLine("====================================================DANH BA====================================================");
                        Console.WriteLine(db.ToString());
                        break;
                    case Menu.XemDanhBa:
                        Console.WriteLine("====================================================DANH BA====================================================");
                        Console.WriteLine(db.ToString());
                        break;
                    case Menu.ThueBaoCoNhieuSDT:
                        Console.WriteLine("Thue bao co nhieu so dien thoai nhieu nhat la : \n{0}" ,db.TimThueBaoCoNhieuSDT());
                        break;
                    case Menu.SapXepTangTheoTen:
                        db.SapXepTheoChieuTangCuaTen();
                        Console.WriteLine("====================================================DANH BA====================================================");
                        Console.WriteLine(db.ToString());
                        break;
                    case Menu.SapXepGiamTheoNTNS:
                        db.SapXepGiamNgaySinh();
                        Console.WriteLine("====================================================DANH BA===================================================");
                        Console.WriteLine(db.ToString());
                        break;
                    default:
                        Console.WriteLine("Không có tùy chọn menu >> {0}", menu);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                Console.Write("\nNhấn một phím bất kì để tiếp tục chương trình!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
