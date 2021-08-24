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
            Thoat,
            NhapTuFile,
            XemDanhBa,
            TimThanhPhoCoNhieuThueBaoNhat,
            TimThanhPhoCoItThueBaoNhat,
            SapXepTangTheoHoTen,
            SapXepGiamTheoHoTen,
            SapXepTangSLTB,
            SapXepGiamSLTB,
            TimThueBaoSoHuuItSDTNhat,
            HienThiTPTangTheoTB,
            HienThiTPGiamTheoTB,
            TimThangKhongCoTBNaoDangKy,
            TimTatCaKhachHangTheoGioiTinhNam,
            TimTatCaKhachHangTheoGioiTinhNu,
            XoaTatCaKhachHangTheoTinhNaoDo,
            TangSDTKhachHangSinhThang1,
            TimNgayCoNhieuKhachHangDangKyNhat,
            ThongKeVaHienThiDuLieu,
            XemDanhSachTBCoDinh,
            XemDanhSachTBDidong,
            TimTPCoNhieuTBCoDinhNhat,
            TimTPCoItTBDiDongNhat,
            TimTBSoHuuItSoDienThoaiCoDinhNhat,
            TimThangKhongCoThueBaoNaoDangKySoCoDinh,
            TimThangKhongCoThueBaoNaoDangKySoDiDong,
            TimTatCaThueBaoDiDongTheoGioiTinh,
            XoaTatCaThueBaoCoDinhTheoNgayLapDat
        }
        static void Main(string[] args)
        {
            DanhBa danhBa = new DanhBa();
            DanhBa danhBa1 = new DanhBa();
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("========================================= MENU =========================================");
                Console.WriteLine("\t\t\t\t\t  QUẢN LÝ DANH BẠ");
                Console.WriteLine("{0}. Thoát", (int)Menu.Thoat);
                Console.WriteLine("{0}. Nhập dữ liệu từ file", (int)Menu.NhapTuFile);
                Console.WriteLine("{0}. Xem danh bạ", (int)Menu.XemDanhBa);
                Console.WriteLine("{0}. Tìm kiếm thành phố có nhiều thuê bao nhất", (int)Menu.TimThanhPhoCoNhieuThueBaoNhat);
                Console.WriteLine("{0}. Tìm kiếm thành phố có ít thuê bao nhất", (int)Menu.TimThanhPhoCoItThueBaoNhat);
                Console.WriteLine("{0}. Sắp xếp danh sách tăng theo họ tên", (int)Menu.SapXepTangTheoHoTen);
                Console.WriteLine("{0}. Sắp xếp danh sách giảm theo họ tên", (int)Menu.SapXepGiamTheoHoTen);
                Console.WriteLine("{0}. Sắp xếp danh sách tăng theo số lượng thuê bao", (int)Menu.SapXepTangSLTB);
                Console.WriteLine("{0}. Sắp xếp danh sách giảm theo số lượng thuê bao", (int)Menu.SapXepGiamSLTB);
                Console.WriteLine("{0}. Tìm thuê bao sở hữu ít SDT nhất", (int)Menu.TimThueBaoSoHuuItSDTNhat);
                Console.WriteLine("{0}. Hiển thị danh sách thành phố theo chiều tăng của số lượng thuê bao", (int)Menu.HienThiTPTangTheoTB);
                Console.WriteLine("{0}. Hiển thị danh sách thành phố theo chiều giảm của số lượng thuê bao", (int)Menu.HienThiTPGiamTheoTB);
                Console.WriteLine("{0}. Tìm các tháng không có thuê bao nào đăng ký", (int)Menu.TimThangKhongCoTBNaoDangKy);
                Console.WriteLine("{0}. Tìm các khách hàng theo giới tính Nam", (int)Menu.TimTatCaKhachHangTheoGioiTinhNam);
                Console.WriteLine("{0}. Tìm các khách hàng theo giới tính Nữ", (int)Menu.TimTatCaKhachHangTheoGioiTinhNu);
                Console.WriteLine("{0}. Xóa khách hàng theo tỉnh", (int)Menu.XoaTatCaKhachHangTheoTinhNaoDo);
                Console.WriteLine("{0}. Tặng SDT là số chứng mình cho khách hàng sinh tháng 1", (int)Menu.TangSDTKhachHangSinhThang1);
                Console.WriteLine("{0}. Tìm ngày có nhiều khách hàng đăng ký thuê bao nhất", (int)Menu.TimNgayCoNhieuKhachHangDangKyNhat);
                Console.WriteLine("{0}. Thống kế dữ liệu theo thành phố và tỉnh", (int)Menu.ThongKeVaHienThiDuLieu);
                Console.WriteLine("{0}. Xem danh bạ cố định", (int)Menu.XemDanhSachTBCoDinh);
                Console.WriteLine("{0}. Xem danh bạ di động", (int)Menu.XemDanhSachTBDidong);
                Console.WriteLine("{0}. Tìm thành phố có nhiều thuê bao cố định nhất", (int)Menu.TimTPCoNhieuTBCoDinhNhat);
                Console.WriteLine("{0}. Tìm thành phố có ít thuê bao cố di động", (int)Menu.TimTPCoItTBDiDongNhat);
                Console.WriteLine("{0}. Tìm thuê bao sỡ hữu ít SDT cố định nhất", (int)Menu.TimTBSoHuuItSoDienThoaiCoDinhNhat);
                Console.WriteLine("{0}. Tìm tháng không có thuê bao nào đăng ký SDT cố định", (int)Menu.TimThangKhongCoThueBaoNaoDangKySoCoDinh);
                Console.WriteLine("{0}. Tìm tháng không có thuê bao nào đăng ký SDT di động", (int)Menu.TimThangKhongCoThueBaoNaoDangKySoDiDong);
                Console.WriteLine("{0}. Tìm thuê bao di động theo giới tính", (int)Menu.TimTatCaThueBaoDiDongTheoGioiTinh);
                Console.WriteLine("{0}. Xóa tất cả thuê bao cố định theo ngày lắp đặt", (int)Menu.XoaTatCaThueBaoCoDinhTheoNgayLapDat);
                Console.WriteLine("Cre: Đoàn Quang Huy - 2015597");
                Console.WriteLine("=============================================================================================");
                Console.Write("Mời bạn chọn chức năng: ");
                Menu menu = (Menu)int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (menu)
                {
                    case Menu.Thoat:
                        return;
                    case Menu.NhapTuFile:
                        danhBa.NhapTuFile();
                        Console.WriteLine("Nhập dữ liệu thành công!");
                        break;
                    case Menu.XemDanhBa:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        break;
                    case Menu.TimThanhPhoCoNhieuThueBaoNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.Write("Các thành phố có {0} thuê bao là nhiều nhất gồm những thành phố :", danhBa.TimMaxThanhPho());
                        danhBa.XuatList(danhBa.TimCacThanhPhoCoNhieuThueBaoNhat());
                        break;
                    case Menu.TimThanhPhoCoItThueBaoNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.Write("Các thành phố có {0} thuê bao là ít nhất gồm những thành phố :", danhBa.TimMinThanhPho());
                        danhBa.XuatList(danhBa.TimCacThanhPhoCoItThueBaoNhat());
                        break;
                    case Menu.SapXepTangTheoHoTen:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.SapXepTangTheoHoTen();
                        Console.WriteLine("Danh bạ sau khi sắp xếp tăng theo chiều họ tên là: \n" + danhBa);
                        break;
                    case Menu.SapXepGiamTheoHoTen:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.SapXepGiamTheoHoTen();
                        Console.WriteLine("Danh bạ sau khi sắp xếp giảm theo chiều họ tên là: \n"+ danhBa);
                        break;
                    case Menu.SapXepTangSLTB:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.SapXepTangTheoSoDienThoaiSoHuu();
                        Console.WriteLine("Danh bạ sau khi sắp xếp tăng theo SĐT sở hữu là: \n" + danhBa);
                        break;
                    case Menu.SapXepGiamSLTB:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.SapXepGiamTheoSoDienThoaiSoHuu();
                        Console.WriteLine("Danh bạ sau khi sắp xếp giảm theo SĐT sở hữu là: \n" + danhBa);
                        break;
                    case Menu.TimThueBaoSoHuuItSDTNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Các thuê bao có {0} SĐT ít nhất là: ", danhBa.TimMinSDT());
                        danhBa.XuatList(danhBa.TimDanhSachCacThueBaoCoItSDTNhat());
                        break;
                    case Menu.HienThiTPTangTheoTB:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.HienThiDanhSachCacThanhPhoTheoChieuTangCuaSoLuongThueBao();
                        break;
                    case Menu.HienThiTPGiamTheoTB:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.HienThiDanhSachCacThanhPhoTheoChieuGiamCuaSoLuongThueBao();
                        break;
                    case Menu.TimThangKhongCoTBNaoDangKy:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.Write("Tháng không có thuê bao nào đăng ký SĐT là : ");
                        danhBa.XuatList(danhBa.TimThangKhongCoThueBaoNaoDangKy());
                        break;
                    case Menu.TimTatCaKhachHangTheoGioiTinhNam:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.XuatList(danhBa.TimKhachHangTheoGioiTinhNam());
                        break;
                    case Menu.TimTatCaKhachHangTheoGioiTinhNu:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.XuatList(danhBa.TimKhachHangTheoGioiTinhNu());
                        break;
                    case Menu.XoaTatCaKhachHangTheoTinhNaoDo:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.Write("Nhập tỉnh tên muốn xóa thuê bao: ");
                        string tinh = Console.ReadLine();
                        danhBa.XoaKhachHangTheoTinh(tinh);
                        Console.WriteLine("\nDanh bạ sau xóa: \n" + danhBa);
                        break;
                    case Menu.TangSDTKhachHangSinhThang1:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.Write("Những khách hàng sinh tháng 1 được tặng SĐT là: \n" + danhBa.TimNhungNguoiSinhThang1());
                        break;
                    case Menu.TimNgayCoNhieuKhachHangDangKyNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Ngày có nhiều người đăng ký thuê bao nhất là : ");
                        danhBa.XuatList(danhBa.TimNgayDangKyNhieuNhat());
                        break;
                    case Menu.ThongKeVaHienThiDuLieu:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa.HienThiDanhSachTinhThanhPho();
                        break;
                    case Menu.XemDanhSachTBCoDinh:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa1 = danhBa.DanhBaThueBaoCoDinh();
                        Console.WriteLine("Danh bạ thuê bao cố định :\n" +danhBa1);
                        break;
                    case Menu.XemDanhSachTBDidong:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        danhBa1 = danhBa.DanhBaThueBaoDiDong();
                        Console.WriteLine("Danh bạ thuê bao di động :\n" + danhBa1);
                        break;
                    case Menu.TimTPCoNhieuTBCoDinhNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Thành phố có nhiều thuê bao cố định nhất là : ");
                        danhBa.XuatList(danhBa.TimDanhSachCacThanhPhoCoNhieuThueBaoCoDinhNhat());
                        break;
                    case Menu.TimTPCoItTBDiDongNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Thành phố có ít thuê bao di động nhất là :");
                        danhBa.XuatList(danhBa.TimDanhSachCacThanhPhoCoItThueBaoDiDongNhat());
                        break;
                    case Menu.TimTBSoHuuItSoDienThoaiCoDinhNhat:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Thuê bao số hữu ít số điện thoại cố định nhất là :");
                        danhBa.XuatList(danhBa.TimThueBaoSoHuuItSoDienThoaiCoDinhNhat());
                        break;
                    case Menu.TimThangKhongCoThueBaoNaoDangKySoCoDinh:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Tháng không có thuê bao nào đăng ký SĐT cố định là :");
                        danhBa.XuatList(danhBa.TimThangKhongCoThueBaoNaoDangKySoCoDinh());
                        break;
                    case Menu.TimThangKhongCoThueBaoNaoDangKySoDiDong:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.WriteLine("Tháng không có thuê bao nào đăng ký SĐT di động là :");
                        danhBa.XuatList(danhBa.TimThangKhongCoThueBaoNaoDangKySoDiDong());
                        break;
                    case Menu.TimTatCaThueBaoDiDongTheoGioiTinh:
                        Console.WriteLine("Danh bạ : \n" + danhBa);
                        Console.Write("Nhập giới tính cần tìm SĐT di động: ");
                        string gt = Console.ReadLine();
                        Console.WriteLine("Tất cả thuê bao di động có giới tính là {0} là : ", gt);
                        danhBa.XuatList(danhBa.TimCacThueBaoDiDongTheoGioiTinh(gt));
                        break;
                    case Menu.XoaTatCaThueBaoCoDinhTheoNgayLapDat:
                        danhBa1 = danhBa.DanhBaThueBaoCoDinh();
                        Console.WriteLine(danhBa1);
                        Console.Write("Nhập ngày lắp đặt để xóa thuê bao cố định: ");
                        int ngayXoa = int.Parse(Console.ReadLine());
                        danhBa1.XoaTatCaCacThueBaoCoDinhTheoNgayLapDat(ngayXoa);
                        Console.Write("Danh bạ sau khi xóa theo ngày {0} lắp đặt là :\n", ngayXoa);
                        Console.WriteLine(danhBa1);
                        break;
                    default:
                        break;
                }
                Console.Write("\nNhấn một phím để tiếp tục!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
