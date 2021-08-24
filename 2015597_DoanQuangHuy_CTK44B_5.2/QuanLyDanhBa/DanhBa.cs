using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Thư viện hỗ trợ nhập xuất dữ liệu file

namespace QuanLyDanhBa
{
    // Kiểu sắp xếp chỉ cần gọi tên
    enum KieuSapXep
    {
        TangTheoHoTen,
        GiamTheoHoTen,
        TangTheoSDTSoHuu,
        GiamTheoSDTSoHuu,
        ThanhPhoTangTheoSoLuongThueBao,
        ThanhPhoGiamTheoSoLuongThueBao
    }
    class DanhBa
    {
        ThueBao[] danhBa = new ThueBao[100]; // Tạo ra một danh bạ
        int length = 0; // số lượng thuê bao
        ThueBaoCoDinh[] danhBaCoDinh = new ThueBaoCoDinh[100]; // Tạo ra một danh bạ gồm các thuê bao cố định
        int lengthCD = 0; // số lượng thuê bao cố định
        ThueBaoDiDong[] danhBaDiDong = new ThueBaoDiDong[100]; // // Tạo ra một danh bạ gồm các thuê bao di động
        int lengthDD = 0; // số lượng thuê bao cố định

        // Hàm khởi tạo không có tham số truyền vào
        public DanhBa() { }

        public void ThemThueBao(ThueBao thueBaoNew)
        {
            danhBa[length++] = thueBaoNew;
        }
        public void NhapTuFile()
        {
            string path = @"data1.txt";
            StreamReader sr = new StreamReader(path);
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                ThemThueBao(new ThueBao(str));
            }
        }
        // Chèn thêm một cột STT
        public override string ToString()
        {
            string duLieu = "";
            int count = 0; // Biến đếm
            for (int i = 0; i < length; i++)
            {
                count++;
                duLieu += count.ToString().PadLeft(2) + ")".PadRight(2) + danhBa[i] + "\r";
            }
            return duLieu;
        }
        // Hàm xuất List theo dữ liệu truyền vào
        public void XuatList<kdl>(List<kdl> duLieu)
        {
            foreach (var item in duLieu)
                Console.Write("  " + item);
        }
        public int DemSoLanXuatHienThanhPho(string thanhPho)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].thanhPho == thanhPho) 
                    count++;
            }
            return count;
        }
        public int TimMaxThanhPho()
        {
            int max = -1; // Tạo biến max bằng một số nhỏ 
            for (int i = 0; i < length; i++)
            {
                // Nếu max < số lần xuất hiện của thành phố trong danh bạ thì 
                if (DemSoLanXuatHienThanhPho(danhBa[i].thanhPho) > max) 
                    max = DemSoLanXuatHienThanhPho(danhBa[i].thanhPho); // gán số lần xuất hiện cao nhất cho biến max
            }
            return max; // trả về giá trị max là số lần xuất hiện nhiều nhất của thành phố nào đó
        }
        public int TimMinThanhPho()
        {
            int min = int.MaxValue;
            for (int i = 0; i < length; i++)
            {
                if (DemSoLanXuatHienThanhPho(danhBa[i].thanhPho) < min) 
                    min = DemSoLanXuatHienThanhPho(danhBa[i].thanhPho);
            }
            return min;
        }
        public void HoanVi(ref ThueBao thueBao1, ref ThueBao thueBao2)
        {
            ThueBao trungGian = thueBao1;
            thueBao1 = thueBao2;
            thueBao2 = trungGian;
        }
        public List<string> TimCacThanhPhoCoNhieuThueBaoNhat()
        {
            List<string> kq = new List<string>();
            int max = TimMaxThanhPho();
            for (int i = 0; i < length; i++)
            {
                if (DemSoLanXuatHienThanhPho(danhBa[i].thanhPho) == max && !kq.Contains(danhBa[i].thanhPho)) 
                    kq.Add(danhBa[i].thanhPho);
            }
            return kq;
        }
        public List<string> TimCacThanhPhoCoItThueBaoNhat()
        {
            List<string> kq = new List<string>();
            int min = TimMinThanhPho();
            for (int i = 0; i < length; i++)
            {
                if (DemSoLanXuatHienThanhPho(danhBa[i].thanhPho) == min && !kq.Contains(danhBa[i].thanhPho)) 
                    kq.Add(danhBa[i].thanhPho);
            }
            return kq;
        }
        public int DemThueBao(string CMND)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].soCMND == CMND) 
                    count++;
            }
            return count;
        }
        public int TimMinSDT()
        {
            int min = int.MaxValue;
            for (int i = 0; i < length; i++)
            {
                if (DemThueBao(danhBa[i].soCMND) < min) 
                    min = DemThueBao(danhBa[i].soCMND);
            }
            return min;
        }
        public List<ThueBao> TimDanhSachCacThueBaoCoItSDTNhat()
        {
            List<ThueBao> kq = new List<ThueBao>();
            int min = TimMinSDT();
            for (int i = 0; i < length; i++)
            {
                if (DemThueBao(danhBa[i].soCMND) == min) 
                    kq.Add(danhBa[i]);
            }
            return kq;
        }

        // Kiểm tra điều kiện và trả về 1 hoặc -1
        public int KiemTraDieuKien(ThueBao a, ThueBao b, KieuSapXep kieu)
        {
            if (kieu == KieuSapXep.TangTheoHoTen)
                return a.hoTen.CompareTo(b.hoTen);
            if (kieu == KieuSapXep.GiamTheoHoTen)
                return -a.hoTen.CompareTo(b.hoTen);
            if (kieu == KieuSapXep.TangTheoSDTSoHuu)
                return DemThueBao(a.soCMND).CompareTo(DemThueBao(b.soCMND));
            if (kieu == KieuSapXep.GiamTheoSDTSoHuu)
                return -DemThueBao(a.soCMND).CompareTo(DemThueBao(b.soCMND));
            if (kieu == KieuSapXep.ThanhPhoTangTheoSoLuongThueBao)
                return DemSoLanXuatHienThanhPho(a.thanhPho).CompareTo(DemSoLanXuatHienThanhPho(b.thanhPho));
            if (kieu == KieuSapXep.ThanhPhoGiamTheoSoLuongThueBao)
                return -DemSoLanXuatHienThanhPho(a.thanhPho).CompareTo(DemSoLanXuatHienThanhPho(b.thanhPho));
            return -1;
        }
        // Hàm sắp xếp theo điều kiện <Truyền kiểu sắp xếp vào>
        public void SapXep(KieuSapXep kieu)
        {
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (KiemTraDieuKien(danhBa[i], danhBa[j], kieu) == 1) 
                        HoanVi(ref danhBa[i], ref danhBa[j]);
                }
            }
        }
        public void SapXepTangTheoHoTen()
        {
            SapXep(KieuSapXep.TangTheoHoTen);
        }
        public void SapXepGiamTheoHoTen()
        {
            SapXep(KieuSapXep.GiamTheoHoTen);
        }
        public void SapXepTangTheoSoDienThoaiSoHuu()
        {
            SapXep(KieuSapXep.TangTheoSDTSoHuu);
        }
        public void SapXepGiamTheoSoDienThoaiSoHuu()
        {
            SapXep(KieuSapXep.GiamTheoSDTSoHuu);
        }
        public List<string> TimDanhSachTatCaCacThanhPhoTheoChieuTang()
        {
            List<string> kq = new List<string>();
            SapXep(KieuSapXep.ThanhPhoTangTheoSoLuongThueBao);

            for (int i = 0; i < length; i++)
            {
                if (kq.Contains(danhBa[i].thanhPho)) continue;
                kq.Add(danhBa[i].thanhPho);
            }
            return kq;
        }
        public void HienThiDanhSachCacThanhPhoTheoChieuTangCuaSoLuongThueBao()
        {
            List<string> kq = TimDanhSachTatCaCacThanhPhoTheoChieuTang();

            foreach (var item in kq)
            {
                Console.WriteLine(item);
                for (int i = 0; i < length; i++)
                {
                    if (danhBa[i].thanhPho == item)
                    {
                        SapXep(KieuSapXep.TangTheoHoTen);
                        Console.Write(danhBa[i]);
                    }
                }
            }
        }
        public List<string> TimDanhSachTatCaCacThanhPhoTheoChieuGiam()
        {
            List<string> kq = new List<string>();
            SapXep(KieuSapXep.ThanhPhoGiamTheoSoLuongThueBao);

            for (int i = 0; i < length; i++)
            {
                if (kq.Contains(danhBa[i].thanhPho)) continue;
                kq.Add(danhBa[i].thanhPho);
            }
            return kq;
        }
        public void HienThiDanhSachCacThanhPhoTheoChieuGiamCuaSoLuongThueBao()
        {
            List<string> kq = TimDanhSachTatCaCacThanhPhoTheoChieuGiam();

            foreach (var item in kq)
            {
                Console.WriteLine(item);
                for (int i = 0; i < length; i++)
                {
                    if (danhBa[i].thanhPho == item)
                    {
                        SapXep(KieuSapXep.TangTheoHoTen);
                        Console.Write(danhBa[i]);
                    }
                }
            }
        }
        public List<int> TimCacThangDangKyTrongMang()
        {
            List<int> kq = new List<int>();
            for (int i = 0; i < length; i++)
            {
                if (kq.Contains(danhBa[i].thangDangKy)) continue;
                kq.Add(danhBa[i].thangDangKy);
            }
            return kq;
        }
        public List<int> TimThangKhongCoThueBaoNaoDangKy()
        {
            List<int> kq = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                if (!TimCacThangDangKyTrongMang().Contains(i)) 
                    kq.Add(i);
            }
            return kq;
        }
        public List<ThueBao> TimKhachHangTheoGioiTinh(string gioiTinh)
        {
            List<ThueBao> kq = new List<ThueBao>();
            for (int i = 0; i < length; i++)
            {
                if (string.Compare(danhBa[i].gioiTinh.ToString(), gioiTinh, true) == 0) 
                    kq.Add(danhBa[i]);
            }
            return kq;
        }
        public List<ThueBao> TimKhachHangTheoGioiTinhNam()
        {
            return TimKhachHangTheoGioiTinh("Nam");
        }
        public List<ThueBao> TimKhachHangTheoGioiTinhNu()
        {
            return TimKhachHangTheoGioiTinh("Nu");
        }
        public int XoaTaiViTri(int viTriXoa)
        {
            for (int i = viTriXoa; i < length - 1; i++)
            {
                danhBa[i] = danhBa[i + 1];
            }
            length--;
            return -1;
        }
        public void XoaKhachHangTheoTinh(string tinh)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                if (string.Compare(danhBa[i].tinh, tinh.Trim(), true) == 0) 
                    XoaTaiViTri(i);
            }
        }
        public bool CoChua(ThueBao tb)
        {
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].soCMND == tb.soCMND) 
                    return true;
            }
            return false;
        }
        public DanhBa TimNhungNguoiSinhThang1()
        {
            DanhBa kq = new DanhBa();
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].thangSinh == 1 && !kq.CoChua(danhBa[i]))
                {
                    danhBa[i].SDT = danhBa[i].soCMND;
                    kq.ThemThueBao(danhBa[i]);
                }
            }
            return kq;
        }
        public int DemSoNgayDangKy(int ngayDangKy)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].ngayDangKy == ngayDangKy)
                    count++;
            }
            return count;
        }
        public int TimMaxNgayDangKy()
        {
            int max = -1;
            for (int i = 0; i < length; i++)
            {
                if (DemSoNgayDangKy(danhBa[i].ngayDangKy) > max) 
                    max = DemSoNgayDangKy(danhBa[i].ngayDangKy);
            }
            return max;
        }
        public List<int> TimNgayDangKyNhieuNhat()
        {
            int max = TimMaxNgayDangKy();
            List<int> kq = new List<int>();
            for (int i = 0; i < length; i++)
            {
                if (DemSoNgayDangKy(danhBa[i].ngayDangKy) == max && !kq.Contains(danhBa[i].ngayDangKy))
                    kq.Add(danhBa[i].ngayDangKy);
            }
            return kq;
        }
        public List<string> TimTatCaCacTinh()
        {
            List<string> kq = new List<string>();
            for (int i = 0; i < length; i++)
            {
                if (kq.Contains(danhBa[i].tinh)) kq.Remove(danhBa[i].tinh);
                kq.Add(danhBa[i].tinh);
            }
            return kq;
        }
        public List<string> TimDanhSachThanhPhoHienThiTheoTinh(string tinh)
        {
            List<string> kq = new List<string>();
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].tinh.CompareTo(tinh) == 0 && !kq.Contains(danhBa[i].thanhPho)) 
                    kq.Add(danhBa[i].thanhPho);
            }
            return kq;
        }

        public DanhBa TimDanhSachThueBaoHienThiTheoThanhPho(string thanhPho)
        {
            DanhBa kq = new DanhBa();
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].thanhPho.CompareTo(thanhPho) == 0) 
                    kq.ThemThueBao(danhBa[i]);
            }
            return kq;
        }
        public int DemSoThueBaoCuaMotTinh(string tinh)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].tinh.CompareTo(tinh) == 0)
                    count++;
            }
            return count;
        }
        public void HienThiDanhSachTinhThanhPho()
        {
            foreach (var item in TimTatCaCacTinh())
            {
                Console.WriteLine("\nTỉnh: {0} (Tổng số thuê bao: {1})", item, DemSoThueBaoCuaMotTinh(item));

                foreach (var item2 in TimDanhSachThanhPhoHienThiTheoTinh(item))
                {
                    Console.Write("\tThành phố: " + item2);

                    Console.WriteLine(" (Tổng số thuê bao {0})", TimDanhSachThueBaoHienThiTheoThanhPho(item2).length);
                    Console.WriteLine(TimDanhSachThueBaoHienThiTheoThanhPho(item2));
                }
            }
        }
        public void ThemTBCoDinh(ThueBaoCoDinh coDinh)
        {

            danhBaCoDinh[lengthCD++] = coDinh;
            danhBa = danhBaCoDinh;
            length = lengthCD;
        }
        public void ThemTBDiDong(ThueBaoDiDong diDong)
        {

            danhBaDiDong[lengthDD++] = diDong;
            danhBa = danhBaDiDong;
            length = lengthDD;
        }
        public DanhBa DanhBaThueBaoCoDinh()
        {
            DanhBa kq = new DanhBa();
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].kieuThueBao == "TBCD") 
                    kq.ThemTBCoDinh(new ThueBaoCoDinh(danhBa[i]));
            }
            return kq;
        }
        public DanhBa DanhBaThueBaoDiDong()
        {
            DanhBa kq = new DanhBa();
            for (int i = 0; i < length; i++)
            {
                if (danhBa[i].kieuThueBao == "TBDD") 
                    kq.ThemTBDiDong(new ThueBaoDiDong(danhBa[i]));
            }
            return kq;
        }
        public List<string> TimDanhSachCacThanhPhoCoNhieuThueBaoCoDinhNhat()
        {
            return DanhBaThueBaoCoDinh().TimCacThanhPhoCoNhieuThueBaoNhat();
        }
        public List<string> TimDanhSachCacThanhPhoCoItThueBaoDiDongNhat()
        {
            return DanhBaThueBaoDiDong().TimCacThanhPhoCoItThueBaoNhat();
        }
        public List<ThueBao> TimThueBaoSoHuuItSoDienThoaiCoDinhNhat()
        {
            List<ThueBao> kq = DanhBaThueBaoCoDinh().TimDanhSachCacThueBaoCoItSDTNhat();
            return kq;
        }
        public List<int> TimThangKhongCoThueBaoNaoDangKySoCoDinh()
        {
            List<int> kq = DanhBaThueBaoCoDinh().TimThangKhongCoThueBaoNaoDangKy();
            return kq;
        }
        public List<int> TimThangKhongCoThueBaoNaoDangKySoDiDong()
        {
            List<int> kq = DanhBaThueBaoDiDong().TimThangKhongCoThueBaoNaoDangKy();
            return kq;
        }
        public List<ThueBao> TimCacThueBaoDiDongTheoGioiTinh(string gioiTinh)
        {

            List<ThueBao> kq = DanhBaThueBaoDiDong().TimKhachHangTheoGioiTinh(gioiTinh);
            return kq;
        }
        public void XoaTatCaCacThueBaoCoDinhTheoNgayLapDat(int ngayXoa)
        {
            for (int i = lengthCD - 1; i >= 0; i--)
            {
                if (danhBaCoDinh[i].ngayLapDat == ngayXoa) 
                    XoaTaiViTri(i);
            }
        }
    }
}
