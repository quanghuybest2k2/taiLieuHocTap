using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
    class Program
    {
        static DanhSachHinhHoc ds = new DanhSachHinhHoc();
        static void Main(string[] args)
        {
            Console.Title = "Chuong trinh quan ly hinh hoc";
            Console.OutputEncoding = Encoding.Unicode;
            ChayChuongTrinh();
        }
        enum Menu
        {
            ThoatChuongTrinh,
            NhapDuLieuTuFile,
            XemDanhSachHinhHoc,
            TimHinhHocCoDienTichLonNhat,
            TimHinhVuongCoDTLonNhat,
            // Hình vuông
            TimHinhVuongTheoChuViX,
            TimHinhVuongTheoDienTichX,
            TimHinhVuongCoDienTichChuViNhoNhat,
            SapXepHinhVuongTangGiamTheoDienTich,
            TimHinhVuongCoCanhNhoNhatLonNhat,
            TinhTongDienTichVaChuViCuaTatCaHinhVuong,
            // Hình tròn
            TimHinhTronTheoChuViX,
            TimHinhTronTheoDienTichX,
            TimHinhTronCoDienTichChuViNhoNhat,
            SapXepHinhTronTangGiamTheoDienTich,
            TimHinhTronCoCanhNhoNhatLonNhat,
            TinhTongDienTichVaChuViCuaTatCaHinhTron,
            // Hình chữ nhật
            TimHinhChuNhatTheoChuViX,
            TimHinhChuNhatTheoDienTichX,
            TimHinhChuNhatCoDienTichChuViNhoNhat,
            SapXepHinhChuNhatTangGiamTheoDienTich,
            TimHinhChuNhatCoCanhNhoNhatLonNhat,
            TinhTongDienTichVaChuViCuaTatCaHinhChuNhat,

            HienThiSoLuongMoiLoaiHinhHoc,
            SapXepHinhVuongTangGiamTheoChuVi,
            SapXepHinhTronTangGiamTheoChuVi,
            SapXepHinhChuNhatTangGiamTheoChuVi,
            TimHinhHocCoDienTichNhoNhat,
            TimHinhHocCoChuViNhoNhatLonNhat,
            SapTangGiamTatCaCacHinhTheoDienTich,
            SapTangGiamTatCaCacHinhTheoChuVi,
            XoaCacHinhCoDienTichNhoNhat,
            XoaCacHinhCoDienTichLonNhat,
            XoaCacHinhCoChuViNhoNhat,
            XoaCacHinhCoChuViLonNhat,
            ThemHinhHocThuCongTaiViTri,
            XoaHinhTaiViTri,
            TinhTongDienTichVaChuViTatCaCacHinh,
            TimKieuHinhCoTongDienTichChuViLonNhatNhoNhat,
            XuatCacHinhRaFileRieng,
            XuatBangTongHopHinhHocRaFile
        }
        static void XuatMenu()
        {
            Console.WriteLine("\n======================= MENU =======================");
            Console.WriteLine("0".PadLeft(3) + ". Thoát chương trình!");
            Console.WriteLine("1".PadLeft(3) + ". Nhập dữ liệu từ file");
            Console.WriteLine("2".PadLeft(3) + ". Xem danh sách hình học");
            Console.WriteLine("3".PadLeft(3) + ". Tìm hình học có diện tích lớn nhất");
            Console.WriteLine("4".PadLeft(3) + ". Tìm hình vuông có diện tích lớn nhất");
            // Hình vuông
            Console.WriteLine("5".PadLeft(3) + ". Tìm tất cả hình vuông có chu vi x");
            Console.WriteLine("6".PadLeft(3) + ". Tìm tất cả hình vuông có diện tích x");
            Console.WriteLine("7".PadLeft(3) + ". Tìm tất cả hình vuông có diện tích và chu vi nhỏ nhất");
            Console.WriteLine("8".PadLeft(3) + ". Sắp xếp hình vuông tăng giảm theo diện tích");
            Console.WriteLine("9".PadLeft(3) + ". Tìm hình vuông có cạnh nhỏ nhất, lớn nhất");
            Console.WriteLine("10".PadLeft(3) + ". Tính tổng diện tích và chu vi của tất cả hình vuông");
            // Hình tròn
            Console.WriteLine("11".PadLeft(3) + ". Tìm tất cả hình tròn có chu vi x");
            Console.WriteLine("12".PadLeft(3) + ". Tìm tất cả hình tròn có diện tích x");
            Console.WriteLine("13".PadLeft(3) + ". Tìm tất cả hình tròn có diện tích và chu vi nhỏ nhất");
            Console.WriteLine("14".PadLeft(3) + ". Sắp xếp hình tròn tăng giảm theo diện tích");
            Console.WriteLine("15".PadLeft(3) + ". Tìm hình tròn có bán kính nhỏ nhất, lớn nhất");
            Console.WriteLine("16".PadLeft(3) + ". Tính tổng diện tích và chu vi của tất cả hình tròn");
            // Hình chữ nhật
            Console.WriteLine("17".PadLeft(3) + ". Tìm tất cả hình chữ nhật có chu vi x");
            Console.WriteLine("18".PadLeft(3) + ". Tìm tất cả hình chữ nhật có diện tích x");
            Console.WriteLine("19".PadLeft(3) + ". Tìm tất cả hình chữ nhật có diện tích và chu vi nhỏ nhất");
            Console.WriteLine("20".PadLeft(3) + ". Sắp xếp hình chữ nhật tăng giảm theo diện tích");
            Console.WriteLine("21".PadLeft(3) + ". Tìm hình chữ nhật có chiều dài và chiều rộng nhỏ nhất, lớn nhất");
            Console.WriteLine("22".PadLeft(3) + ". Tính tổng diện tích và chu vi của tất cả hình chữ nhật");

            Console.WriteLine("23".PadLeft(3) + ". Hiển thị số lượng từng loại hình trong danh sách");
            Console.WriteLine("24".PadLeft(3) + ". Sắp xếp hình vuông tăng giảm theo chu vi");
            Console.WriteLine("25".PadLeft(3) + ". Sắp xếp hình tròn tăng giảm theo chu vi");
            Console.WriteLine("26".PadLeft(3) + ". Sắp xếp hình chữ nhật tăng giảm theo chu vi");
            Console.WriteLine("27".PadLeft(3) + ". Tìm hình học có diện tích nhỏ nhất");
            Console.WriteLine("28".PadLeft(3) + ". Tìm hình học có chu vi nhỏ nhất, lớn nhất");
            Console.WriteLine("29".PadLeft(3) + ". Sắp xếp tăng giảm tất cả các hình theo diện tích");
            Console.WriteLine("30".PadLeft(3) + ". Sắp xếp tăng giảm tất cả các hình theo chu vi");
            Console.WriteLine("31".PadLeft(3) + ". Xóa các hình có diện tích nhỏ nhất");
            Console.WriteLine("32".PadLeft(3) + ". Xóa các hình có diện tích lớn nhất");
            Console.WriteLine("33".PadLeft(3) + ". Xóa các hình có chu vi nhỏ nhất");
            Console.WriteLine("34".PadLeft(3) + ". Xóa các hình có chi vi lớn nhất");
            Console.WriteLine("35".PadLeft(3) + ". Thêm hình học thủ công tại vị trí");
            Console.WriteLine("36".PadLeft(3) + ". Xóa hình tại vị trí");
            Console.WriteLine("37".PadLeft(3) + ". Tính tổng diện tích và chu vi của tất cả các hình");
            Console.WriteLine("38".PadLeft(3) + ". Tìm kiểu hình có tổng (diện tích, chu vi) lớn nhất, nhỏ nhất");
            Console.WriteLine("39".PadLeft(3) + ". Xuất các hình ra file riêng");
            Console.WriteLine("40".PadLeft(3) + ". Xuất bảng tổng hợp hình học ra file \"xuat.txt\"");
            Console.WriteLine("\n======================= END ========================");
            Console.ResetColor();
        }
        static void ChayChuongTrinh()
        {
            bool isInputData = false;
            while (true)
            {
                Console.Clear();
                XuatMenu();
                Console.Write(">>>CHỌN CHỨC NĂNG: ");
                string kt = Console.ReadLine();
                if (String.IsNullOrEmpty(kt))
                    continue;
                Menu stt = (Menu)int.Parse(kt);

                Console.WriteLine("\nCHƯƠNG TRÌNH ĐÃ XỬ LÝ XONG\n" +
                                  "====================================================");

                switch (stt)
                {
                    case Menu.ThoatChuongTrinh:
                        Console.WriteLine("0. Thoát chương trình!");
                        return;
                    case Menu.NhapDuLieuTuFile:
                        {
                            Console.WriteLine("1. Nhập dữ liệu từ file");
                            if (!isInputData)
                            {
                                ds.NhapDuLieuTuFile();
                                Console.WriteLine("Dữ liệu vừa nhập là:");
                                ds.XuatDanhSachHinhHoc();
                                isInputData = true;
                            }
                            else
                                Console.WriteLine("Chỉ cho phép nhập dữ liệu từ file 1 lần duy nhất\n" +
                                    "Nếu bạn muốn nhập lại dữ liệu thì hãy khởi động lại chương trình!");
                            break;
                        }
                    case Menu.XemDanhSachHinhHoc:
                        {
                            Console.WriteLine("2. Xem danh sách hình học");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhHocCoDienTichLonNhat:
                        {
                            Console.WriteLine("3. Tìm hình học có diện tích lớn nhất");
                            DanhSachHinhHoc kq = ds.TimHinhHocCoDienTichLonNhat<HinhHoc>();
                            Console.WriteLine("Hình học có diện tích lớn nhất là:");
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhVuongCoDTLonNhat:
                        {
                            Console.WriteLine("4. Tìm hình vuông có diện tích lớn nhất");
                            DanhSachHinhHoc kq = ds.TimHinhHocCoDienTichLonNhat<HinhVuong>();
                            Console.WriteLine("Hình vuông có diện tích lớn nhất là:");
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhVuongTheoChuViX:
                        {
                            Console.WriteLine("5. Tìm tất cả hình vuông có chu vi x");
                            Console.Write("Nhập chu vi: ");
                            float cv = float.Parse(Console.ReadLine());
                            DanhSachHinhHoc kq = ds.TimHinhHocTheoChuVi<HinhVuong>(cv);
                            Console.WriteLine("Danh sách hình vuông có chu vi = " + cv);
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhVuongTheoDienTichX:
                        {
                            Console.WriteLine("6. Tìm tất cả hình vuông có diện tích x");
                            Console.Write("Nhập diện tích: ");
                            float dt = float.Parse(Console.ReadLine());
                            DanhSachHinhHoc kq = ds.TimHinhHocTheoDienTich<HinhVuong>(dt);
                            Console.WriteLine("Danh sách hình vuông có diện tích = " + dt);
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhVuongCoDienTichChuViNhoNhat:
                        {
                            Console.WriteLine("7. Tìm tất cả hình vuông có diện tích và chu vi nhỏ nhất");
                            DanhSachHinhHoc kq = ds.TimHinhHocCoDienTichNhoNhat<HinhVuong>();
                            Console.WriteLine("\nDanh sách hình vuông có diện tích và chu vi nhỏ nhất là:");
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapXepHinhVuongTangGiamTheoDienTich:
                        {
                            Console.WriteLine("8. Sắp xếp hình vuông tăng giảm theo diện tích");
                            ds.SapXepHinhHocTangTheoDienTich<HinhVuong>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoDienTich<HinhVuong>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhVuongCoCanhNhoNhatLonNhat:
                        {
                            Console.WriteLine("9. Tìm hình vuông có cạnh nhỏ nhất, lớn nhất");
                            // Hình vuông có diện tích nhỏ nhất cũng chính là hình vuông có cạnh nhỏ nhất và tương tự lớn nhất cũng như vậy

                            DanhSachHinhHoc nn = ds.TimHinhHocCoDienTichNhoNhat<HinhVuong>();
                            Console.WriteLine("\nHình vuông có cạnh nhỏ nhất là:");
                            nn.XuatDanhSachHinhHoc();

                            DanhSachHinhHoc ln = ds.TimHinhHocCoDienTichLonNhat<HinhVuong>();
                            Console.WriteLine("\n\nHình vuông có cạnh lớn nhất là:");
                            ln.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TinhTongDienTichVaChuViCuaTatCaHinhVuong:
                        {
                            Console.WriteLine("10. Tính tổng diện tích và chu vi của tất cả hình vuông");
                            Console.WriteLine("\nTổng diện tích của tất cả hình vuông là: " + ds.TinhTongDienTichCuaHinhHoc<HinhVuong>());
                            Console.WriteLine("\nTổng chu vi của tất cả hình vuông là: " + ds.TinhTongChuViCuaHinhHoc<HinhVuong>());
                            break;
                        }
                    case Menu.TimHinhTronTheoChuViX:
                        {
                            Console.WriteLine("11. Tìm tất cả hình tròn có chu vi x");
                            Console.Write("Nhập chu vi: ");
                            float cv = float.Parse(Console.ReadLine());
                            DanhSachHinhHoc kq = ds.TimHinhHocTheoChuVi<HinhTron>(cv);
                            Console.WriteLine("Danh sách hình tròn có chu vi = " + cv);
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhTronTheoDienTichX:
                        {
                            Console.WriteLine("12. Tìm tất cả hình tròn có diện tích x");
                            Console.Write("Nhập diện tích: ");
                            float dt = float.Parse(Console.ReadLine());
                            DanhSachHinhHoc kq = ds.TimHinhHocTheoDienTich<HinhTron>(dt);
                            Console.WriteLine("Danh sách hình tròn có diện tích = " + dt);
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhTronCoDienTichChuViNhoNhat:
                        {
                            Console.WriteLine("13. Tìm tất cả hình tròn có diện tích và chu vi nhỏ nhất");
                            DanhSachHinhHoc kq = ds.TimHinhHocCoDienTichNhoNhat<HinhTron>();
                            Console.WriteLine("\nDanh sách hình tròn có diện tích và chu vi nhỏ nhất là:");
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapXepHinhTronTangGiamTheoDienTich:
                        {
                            Console.WriteLine("14. Sắp xếp hình tròn tăng giảm theo diện tích");
                            ds.SapXepHinhHocTangTheoDienTich<HinhTron>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoDienTich<HinhTron>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhTronCoCanhNhoNhatLonNhat:
                        {
                            Console.WriteLine("15. Tìm hình tròn có bán kính nhỏ nhất, lớn nhất");
                            // Hình tròn có diện tích nhỏ nhất cũng chính là hình tròn có bán kính nhỏ nhất và tương tự lớn nhất cũng như vậy

                            DanhSachHinhHoc nn = ds.TimHinhHocCoDienTichNhoNhat<HinhTron>();
                            Console.WriteLine("\nHình tròn có bán kính nhỏ nhất là:");
                            nn.XuatDanhSachHinhHoc();

                            DanhSachHinhHoc ln = ds.TimHinhHocCoDienTichLonNhat<HinhTron>();
                            Console.WriteLine("\n\nHình tròn có bán kính lớn nhất là:");
                            ln.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TinhTongDienTichVaChuViCuaTatCaHinhTron:
                        {
                            Console.WriteLine("16. Tính tổng diện tích và chu vi của tất cả hình tròn");
                            Console.WriteLine("\nTổng diện tích của tất cả hình tròn là: " + ds.TinhTongDienTichCuaHinhHoc<HinhTron>());
                            Console.WriteLine("\nTổng chu vi của tất cả hình tròn là: " + ds.TinhTongChuViCuaHinhHoc<HinhTron>());
                            break;
                        }
                    case Menu.TimHinhChuNhatTheoChuViX:
                        {
                            Console.WriteLine("17. Tìm tất cả hình chữ nhật có chu vi x");
                            Console.Write("Nhập chu vi: ");
                            float cv = float.Parse(Console.ReadLine());
                            DanhSachHinhHoc kq = ds.TimHinhHocTheoChuVi<HinhChuNhat>(cv);
                            Console.WriteLine("Danh sách hình chữ nhật có chu vi = " + cv);
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhChuNhatTheoDienTichX:
                        {
                            Console.WriteLine("18. Tìm tất cả hình chữ nhật có diện tích x");
                            Console.Write("Nhập diện tích: ");
                            float dt = float.Parse(Console.ReadLine());
                            DanhSachHinhHoc kq = ds.TimHinhHocTheoDienTich<HinhChuNhat>(dt);
                            Console.WriteLine("Danh sách hình chữ nhật có diện tích = " + dt);
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhChuNhatCoDienTichChuViNhoNhat:
                        {
                            Console.WriteLine("19. Tìm tất cả hình chữ nhật có diện tích và chu vi nhỏ nhất");
                            DanhSachHinhHoc kq = ds.TimHinhHocCoDienTichNhoNhat<HinhChuNhat>();
                            Console.WriteLine("\nDanh sách hình chữ nhật có diện tích và chu vi nhỏ nhất là:");
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapXepHinhChuNhatTangGiamTheoDienTich:
                        {
                            Console.WriteLine("20. Sắp xếp hình chữ nhật tăng giảm theo diện tích");
                            ds.SapXepHinhHocTangTheoDienTich<HinhChuNhat>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoDienTich<HinhChuNhat>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhChuNhatCoCanhNhoNhatLonNhat:
                        {
                            Console.WriteLine("21. Tìm hình chữ nhật có chiều dài và chiều rộng nhỏ nhất, lớn nhất");

                            DanhSachHinhHoc cdnn = ds.TimHCNCoChieuDaiNhoNhat();
                            Console.WriteLine("\nHình chữ nhật có chiều dài nhỏ nhất là:");
                            cdnn.XuatDanhSachHinhHoc();

                            DanhSachHinhHoc cdln = ds.TimHCNCoChieuDaiLonNhat();
                            Console.WriteLine("\n\nHình chữ nhật có chiều dài lớn nhất là:");
                            cdln.XuatDanhSachHinhHoc();

                            DanhSachHinhHoc crnn = ds.TimHCNCoChieuRongNhoNhat();
                            Console.WriteLine("\n\nHình chữ nhật có chiều rộng nhỏ nhất là:");
                            crnn.XuatDanhSachHinhHoc();

                            DanhSachHinhHoc crln = ds.TimHCNCoChieuRongLonNhat();
                            Console.WriteLine("\n\nHình chữ nhật có chiều rộng lớn nhất là:");
                            crln.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TinhTongDienTichVaChuViCuaTatCaHinhChuNhat:
                        {
                            Console.WriteLine("22. Tính tổng diện tích và chu vi của tất cả hình chữ nhật");
                            Console.WriteLine("\nTổng diện tích của tất cả hình chữ nhật là: " + ds.TinhTongDienTichCuaHinhHoc<HinhChuNhat>());
                            Console.WriteLine("\nTổng chu vi của tất cả hình chữ nhật là: " + ds.TinhTongChuViCuaHinhHoc<HinhChuNhat>());
                            break;
                        }
                    case Menu.HienThiSoLuongMoiLoaiHinhHoc:
                        {
                            Console.WriteLine("23. Hiển thị số lượng từng loại hình trong danh sách");
                            Console.WriteLine("Số lượng hình vuông trong danh sách là: " + ds.DemSoLuongHinhHoc<HinhVuong>());
                            Console.WriteLine("Số lượng hình tròn trong danh sách là: " + ds.DemSoLuongHinhHoc<HinhTron>());
                            Console.WriteLine("Số lượng hình chữ nhật trong danh sách là: " + ds.DemSoLuongHinhHoc<HinhChuNhat>());
                            break;
                        }
                    case Menu.SapXepHinhVuongTangGiamTheoChuVi:
                        {
                            // Sắp xếp hình vuông tăng giảm theo diện tích ở câu 8 trên Menu
                            Console.WriteLine("24. Sắp xếp hình vuông tăng giảm theo chu vi");
                            ds.SapXepHinhHocTangTheoChuVi<HinhVuong>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoChuVi<HinhVuong>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapXepHinhTronTangGiamTheoChuVi:
                        {
                            // Sắp xếp hình tròn tăng giảm theo diện tích ở câu 14 trên Menu
                            Console.WriteLine("25. Sắp xếp hình tròn tăng giảm theo chu vi");
                            ds.SapXepHinhHocTangTheoChuVi<HinhTron>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoChuVi<HinhTron>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapXepHinhChuNhatTangGiamTheoChuVi:
                        {
                            // Sắp xếp hình chữ nhật tăng giảm theo diện tích ở câu 20 trên Menu
                            Console.WriteLine("26. Sắp xếp hình chữ nhật tăng giảm theo chu vi");
                            ds.SapXepHinhHocTangTheoChuVi<HinhChuNhat>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng là:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoChuVi<HinhChuNhat>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm là:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhHocCoDienTichNhoNhat:
                        {
                            // Tìm hình học có diện tích lớn nhất ở câu 3 trên Menu
                            Console.WriteLine("27. Tìm hình học có diện tích nhỏ nhất");
                            DanhSachHinhHoc kq = ds.TimHinhHocCoDienTichNhoNhat<HinhHoc>();
                            Console.WriteLine("Hình học có diện tích nhỏ nhất là:");
                            kq.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.TimHinhHocCoChuViNhoNhatLonNhat:
                        {
                            Console.WriteLine("28. Tìm hình học có chu vi nhỏ nhất, lớn nhất");
                            DanhSachHinhHoc nn = ds.TimHinhHocCoChuViNhoNhat<HinhHoc>();
                            Console.WriteLine("\nHình học có chu vi nhỏ nhất là:");
                            nn.XuatDanhSachHinhHoc();

                            DanhSachHinhHoc ln = ds.TimHinhHocCoChuViLonNhat<HinhHoc>();
                            Console.WriteLine("\n\nHình học có chu vi lớn nhất là:");
                            ln.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapTangGiamTatCaCacHinhTheoDienTich:
                        {
                            Console.WriteLine("29. Sắp xếp tăng giảm tất cả các hình theo diện tích");
                            ds.SapXepHinhHocTangTheoDienTich<HinhHoc>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoDienTich<HinhHoc>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.SapTangGiamTatCaCacHinhTheoChuVi:
                        {
                            Console.WriteLine("30. Sắp xếp tăng giảm tất cả các hình theo chu vi");
                            ds.SapXepHinhHocTangTheoChuVi<HinhHoc>();
                            Console.WriteLine("\nDanh sách sau khi sắp tăng:");
                            ds.XuatDanhSachHinhHoc();

                            ds.SapXepHinhHocGiamTheoChuVi<HinhHoc>();
                            Console.WriteLine("\n\nDanh sách sau khi sắp giảm:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.XoaCacHinhCoDienTichNhoNhat:
                        {
                            Console.WriteLine("31. Xóa các hình có diện tích nhỏ nhất");
                            ds.XoaCacHinhCoDienTichNhoNhat();
                            Console.WriteLine("Danh sách sau khi xóa:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.XoaCacHinhCoDienTichLonNhat:
                        {
                            Console.WriteLine("32. Xóa các hình có diện tích lớn nhất");
                            ds.XoaCacHinhCoDienTichLonNhat();
                            Console.WriteLine("Danh sách sau khi xóa:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.XoaCacHinhCoChuViNhoNhat:
                        {
                            Console.WriteLine("33. Xóa các hình có chu vi nhỏ nhất");
                            ds.XoaCacHinhCoChuViNhoNhat();
                            Console.WriteLine("Danh sách sau khi xóa:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.XoaCacHinhCoChuViLonNhat:
                        {
                            Console.WriteLine("34. Xóa các hình có chi vi lớn nhất");
                            ds.XoaCacHinhCoChuViLonNhat();
                            Console.WriteLine("Danh sách sau khi xóa:");
                            ds.XuatDanhSachHinhHoc();
                            break;
                        }
                    case Menu.ThemHinhHocThuCongTaiViTri:
                        {
                            Console.WriteLine("35. Thêm hình học thủ công tại vị trí");
                            Console.Write("Nhập vị trí (0 -> " + ds.DemSoLuongHinhHoc<HinhHoc>() + "): ");
                            int vt = int.Parse(Console.ReadLine());
                            if (ds.KiemTraViTriThem(vt))
                            {
                                if (ds.ThemHinhHocThuCongTaiViTri(vt))
                                {
                                    Console.WriteLine("Danh sách sau khi thêm:");
                                    ds.XuatDanhSachHinhHoc();
                                }
                                else
                                    Console.WriteLine("Hãy nhập đúng kiểu hình (HV, HT, HCN)!");
                            }
                            else
                                Console.WriteLine("Bạn hãy nhập đúng vị trí của mảng!");
                            break;
                        }
                    case Menu.XoaHinhTaiViTri:
                        {
                            Console.WriteLine("36. Xóa hình học tại vị trí");
                            Console.Write("Nhập vị trí (0 -> " + (ds.DemSoLuongHinhHoc<HinhHoc>() - 1) + "): ");
                            int vt = int.Parse(Console.ReadLine());
                            if (ds.XoaHinhHocTaiViTri(vt))
                            {
                                Console.WriteLine("Danh sách sau khi xóa:");
                                ds.XuatDanhSachHinhHoc();
                            }
                            else
                                Console.WriteLine("Không tìm thấy vị trí!");
                            break;
                        }
                    case Menu.TinhTongDienTichVaChuViTatCaCacHinh:
                        {
                            Console.WriteLine("37. Tính tổng diện tích và chu vi của tất cả các hình");
                            Console.WriteLine("Tổng diện tích của tất cả các hình là: " + ds.TinhTongDienTichCuaHinhHoc<HinhHoc>());
                            Console.WriteLine("Tổng diện tích của tất cả các hình là: " + ds.TinhTongChuViCuaHinhHoc<HinhHoc>());
                            break;
                        }
                    case Menu.TimKieuHinhCoTongDienTichChuViLonNhatNhoNhat:
                        {
                            Console.WriteLine("38. Tìm kiểu hình có tổng (diện tích, chu vi) lớn nhất, nhỏ nhất");
                            Console.WriteLine("Kiểu hình học có tổng diện tích lớn nhất là: " + ds.TimKieuHinhHocCoTongDienTichLonNhat());
                            Console.WriteLine("Kiểu hình học có tổng diện tích nhỏ nhất là: " + ds.TimKieuHinhHocCoTongDienTichNhoNhat());
                            Console.WriteLine("Kiểu hình học có tổng chu vi lớn nhất là: " + ds.TimKieuHinhHocCoTongChuViLonNhat());
                            Console.WriteLine("Kiểu hình học có tổng chu vi nhỏ nhất là: " + ds.TimKieuHinhHocCoTongChuViNhoNhat());
                            break;
                        }
                    case Menu.XuatCacHinhRaFileRieng:
                        {
                            Console.WriteLine("39. Xuất các hình ra file riêng");
                            try
                            {
                                ds.XuatDuLieuCacHinhRaFileRieng();
                                Console.WriteLine(@"Xuất dữ liệu thành công! Hãy kiểm tra file ở thư mục bin\debug");
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Lỗi! Bạn chưa nhập dữ liệu!");
                            }
                            break;
                        }
                    case Menu.XuatBangTongHopHinhHocRaFile:
                        {
                            Console.WriteLine("40. Xuất bảng tổng hợp hình học ra file \"xuat.txt\"");
                            try
                            {
                                DanhSachHinhHoc temp = ds.SaoChepDanhBa();
                                temp.SapXepHinhHocTangTheoDienTich<HinhHoc>();
                                temp.XuatBangTongHopHinhHocRaFile();
                                Console.WriteLine("Xuất dữ liệu bảng tổng hợp ra file thành công!\n" +
                                    "Bạn hãy kiểm tra file \"xuat.txt\" trong thư mục bin\\debug");
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Lỗi! Bạn chưa nhập dữ liệu!");
                            }
                            break;
                        }


                }
                Console.WriteLine("\nEnter any key to back Menu...");
                Console.ReadKey();
            }
        }
    }
}