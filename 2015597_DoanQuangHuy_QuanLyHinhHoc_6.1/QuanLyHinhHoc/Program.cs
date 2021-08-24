using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class Program
    {
        enum Menu
        {
            Thoat = 0,
            NhapTuFile,
            TimHVDTMax,
            TimHinhDTMax,
            TimHVCoDTlaX,
            TimHVCoCVlaX,
            TimHVDTmin,
            TimHVCVmin,
            SapXepHinhVuongTangGiamTheoDienTich,
            TimCanhHVMin,
            TimCanhHVMax,
            TimBKMax,
            TongDTvaCV_HV,
            DemSoLuongHV,
            SapXepHinhVuongTangGiamTheoChuVi,
            TimHinhCoDienTichMaxMin,
            TimHinhCoChuViMaxMin
    }
        static void Main(string[] args)
        {
            bool isCheck = false;
            DanhSachHinhHoc ds = new DanhSachHinhHoc();
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("================================ MENU ================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t  DANH SÁCH HÌNH HỌC");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Nhấn {0} Thoát", (int)Menu.Thoat);
                Console.WriteLine("Nhấn {0} Nhập dữ liệu từ file", (int)Menu.NhapTuFile);
                Console.WriteLine("Nhấn {0} Tìm hình vuông có diện tích lớn nhất", (int)Menu.TimHVDTMax);
                Console.WriteLine("Nhấn {0} Tìm hình có diện tích lớn nhất", (int)Menu.TimHinhDTMax);
                Console.WriteLine("Nhấn {0} Tìm tất cả hình vuông có diện tích X", (int)Menu.TimHVCoDTlaX);
                Console.WriteLine("Nhấn {0} Tìm tất cả hình vuông có chu vi X", (int)Menu.TimHVCoCVlaX);
                Console.WriteLine("Nhấn {0} Tìm tất cả hình vuông có diện tích nhỏ nhất", (int)Menu.TimHVDTmin);
                Console.WriteLine("Nhấn {0} Tìm tất cả hình vuông có chu vi nhỏ nhất", (int)Menu.TimHVCVmin);
                Console.WriteLine("Nhấn {0} Sắp xếp hình vuông tăng giảm Theo diện tích", (int)Menu.SapXepHinhVuongTangGiamTheoDienTich);
                Console.WriteLine("Nhấn {0} Tìm hình vuông có cạnh nhỏ nhất", (int)Menu.TimCanhHVMin);
                Console.WriteLine("Nhấn {0} Tìm hình vuông có cạnh lớn nhất", (int)Menu.TimCanhHVMax);
                Console.WriteLine("Nhấn {0} Tìm hình tròn có bán kính lớn nhất", (int)Menu.TimBKMax);
                Console.WriteLine("Nhấn {0} Tính tổng diện tích và chu vi hình vuông", (int)Menu.TongDTvaCV_HV);
                Console.WriteLine("Nhấn {0} Đếm số lượng hình vuông", (int)Menu.DemSoLuongHV);
                Console.WriteLine("Nhấn {0} Sắp xếp hình vuông tăng giảm Theo chu vi", (int)Menu.SapXepHinhVuongTangGiamTheoChuVi);
                Console.WriteLine("Nhấn {0} Tìm các hình có diện tích lớn nhất và nhỏ nhất", (int)Menu.TimHinhCoDienTichMaxMin);
                Console.WriteLine("Nhấn {0} Tìm các hình có chu vi lớn nhất và nhỏ nhất", (int)Menu.TimHinhCoChuViMaxMin);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("======================================================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Mời bạn chọn chức năng: ");
                Console.ResetColor();
                Menu menu = (Menu)int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (menu)
                {
                    case Menu.Thoat:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chương trình đã thoát!");
                        Console.ResetColor();
                        return;
                    case Menu.NhapTuFile:
                       if (!isCheck)
                        {
                            ds.NhapTuFile();
                            Console.WriteLine("Nhập dữ liệu thành công!");
                            Console.WriteLine(ds.ToString());
                            isCheck = true;
                        }
                        else
                        {
                            Console.WriteLine("Dữ liệu chỉ được nhập một lần duy nhất!");
                        }
                        break;
                    case Menu.TimHVDTMax:
                        Console.WriteLine(ds.TimHinhVuongCoDTLonNhat());
                        break;

                    case Menu.TimHinhDTMax:
                        Console.WriteLine(ds.TimHinhCoDTLonNhat());
                        break;
                    case Menu.TimHVCoDTlaX:
                        Console.WriteLine("Nhập diện tích hình vuông cần tìm: ");
                        float dt = float.Parse(Console.ReadLine());
                        Console.WriteLine(ds.TimHVCoDTlaX(dt));
                        break;
                    case Menu.TimHVCoCVlaX:
                        Console.WriteLine("Nhập chu vi hình vuông cần tìm: ");
                        float cv = float.Parse(Console.ReadLine());
                        Console.WriteLine(ds.TimHVCoCVlaX(cv));
                        break;
                    case Menu.TimHVDTmin:
                        Console.WriteLine("Hình vuông có diện tích nhỏ nhất là: ");
                        Console.WriteLine(ds.TimHinhVuongCoDTNhoNhat());
                        break;
                    case Menu.TimHVCVmin:
                        Console.WriteLine("Hình vuông có chu vi nhỏ nhất là: ");
                        Console.WriteLine(ds.TimHinhVuongCoCVNhoNhat());
                        break;
                    case Menu.SapXepHinhVuongTangGiamTheoDienTich:
                           ds.SapXepHinhHocTangTheoDienTich<HinhVuong>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                        Console.WriteLine(ds.ToString());
                        ds.SapXepHinhHocGiamTheoDienTich<HinhVuong>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là: ");
                        Console.WriteLine(ds.ToString());
                        break;
                    case Menu.TimCanhHVMin:
                        Console.Write("Hình vuông có cạnh nhỏ nhất là: ");
                        Console.WriteLine(ds.TimCanhHVNhoNhat());
                        break;
                    case Menu.TimCanhHVMax:
                        Console.Write("Hình vuông có cạnh lớn nhất là: ");
                        Console.WriteLine(ds.TimCanhHVLonNhat());
                        break;
                    case Menu.TimBKMax:
                        Console.Write("Hình tròn có bán kính lớn nhất là: ");
                        Console.WriteLine(ds.TimBKLonNhat());
                        break;
                    case Menu.TongDTvaCV_HV:
                        Console.Write("Tổng diện tích hình vuông là: ");
                        Console.WriteLine(ds.TinhTongDienTichCuaHinhHoc<HinhVuong>());
                        Console.Write("Tổng chu vi hình vuông là: ");
                        Console.WriteLine(ds.TinhTongChuViCuaHinhHoc<HinhVuong>());
                        break;
                    case Menu.DemSoLuongHV:
                        Console.Write("Tổng số lượng hình vuông là: ");
                        Console.WriteLine(ds.DemSoLuongHinhHoc<HinhVuong>().ToString());
                        break;
                    case Menu.SapXepHinhVuongTangGiamTheoChuVi:
                        ds.SapXepHinhHocTangTheoChuVi<HinhVuong>();
                        Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                        Console.WriteLine(ds.ToString());
                        ds.SapXepHinhHocGiamTheoChuVi<HinhVuong>();
                        Console.WriteLine("\n\nDanh sách sau khi sắp giảm là: ");
                        Console.WriteLine(ds.ToString());
                        break;
                    case Menu.TimHinhCoDienTichMaxMin:
                        Console.WriteLine("Các hình có diện tích lớn nhất là: ");
                        Console.WriteLine(ds.TimHinhHocCoDienTichLonNhat<HinhHoc>());
                        Console.WriteLine("Các hình có diện tích nhỏ nhất: ");
                        Console.WriteLine(ds.TimHinhHocCoDienTichNhoNhat<HinhHoc>());
                        break;
                    case Menu.TimHinhCoChuViMaxMin:
                        Console.WriteLine("Các hình có chu vi lớn nhất là: ");
                        Console.WriteLine(ds.TimHinhHocCoChuViLonNhat<HinhHoc>()) ;
                        Console.WriteLine("Các hình có chu vi nhỏ nhất là: ");
                        Console.WriteLine(ds.TimHinhHocCoChuViNhoNhat<HinhHoc>());
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nNhấn một phím để tiếp tục!");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}

