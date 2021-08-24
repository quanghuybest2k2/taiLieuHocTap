using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyDanhBa
{
    class DanhBa
    {
        /*THUỘC TÍNH*/
        ThueBao[] a = new ThueBao[100];
        public int length = 0;


        /*PHƯƠNG THỨC*/
        public void Them(ThueBao tb)
        {
            a[length++] = tb;
        }

        public void NhapTuFile()
        {
            // string path = "D:\\data1.txt"; // Địa chỉ file
            string path = "data1.txt";
            StreamReader sr = new StreamReader(path);
            string str = "";
            /*
             Cho vòng lặp đọc cho đến khi gặp kí tự null (khoảng trắng cuối cùng) thì thoát ~ đọc xong dữ liệu
             */
            while ((str = sr.ReadLine()) != null)
            {
                Them(new ThueBao(str));
            }
        }

        public void Xuat()
        {
            for (int i = 0; i < length; i++)
            {
                a[i].Xuat();
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < length; i++)
            {
                int count = i + 1;
                s += count.ToString().PadLeft(2) + "|" + a[i];
            }
            return s;
        }

        public int DemSoDTTheoThueBao(string cmnd)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (a[i].soCMND == cmnd)
                    count++;
            }
            return count;
        }

        public int TimSoLanThueBaoXuatHienNhieuNhat()
        {
            int max = -1;
            for (int i = 0; i < length; i++)
            {
                int count = DemSoDTTheoThueBao(a[i].soCMND);
                if (count > max)
                    max = count;
            }
            return max;
        }

        bool CoChua(ThueBao tb)
        {
            for (int i = 0; i < length; i++)
            {
                if (a[i].soCMND == tb.soCMND)
                    return true;
            }
            return false;
        }
        public DanhBa TimThueBaoCoNhieuSDT()
        {
            DanhBa kq = new DanhBa();
            int max = TimSoLanThueBaoXuatHienNhieuNhat();
            for (int i = 0; i < length; i++)
            {
                if (DemSoDTTheoThueBao(a[i].soCMND) == max && !kq.CoChua(a[i]))
                    kq.Them(a[i]);
            }
            return kq;
        }
        public enum KieuSapXep
        {
            TangTheoHoTen,
            GiamTheoHoTen,
            TangTheoNgaySinh,
            GiamTheoNgaySinh
        }
        public int KiemTraDieuKien(ThueBao tb1, ThueBao tb2, KieuSapXep k)
        {
            if (k == KieuSapXep.TangTheoHoTen)
                return tb1.hoTen.CompareTo(tb2.hoTen);
            if (k == KieuSapXep.GiamTheoHoTen)
                return tb2.hoTen.CompareTo(tb1.hoTen);
            if (k == KieuSapXep.TangTheoNgaySinh)
                return tb1.ngaySinh.CompareTo(tb2.ngaySinh);
            if (k == KieuSapXep.GiamTheoNgaySinh)
                return tb2.ngaySinh.CompareTo(tb1.ngaySinh);
            return -1;
        }
        public void SapXep(KieuSapXep kieu)
        {
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (KiemTraDieuKien(a[i], a[j], kieu) == 1)
                    {
                        ThueBao trungGian = a[i];
                        a[i] = a[j];
                        a[j] = trungGian;
                    }
                }
            }
        }
        public void SapXepTheoChieuTangCuaTen()
        {
            SapXep(KieuSapXep.TangTheoHoTen);
        }
        public void SapXepGiamNgaySinh()
        {
            SapXep(KieuSapXep.GiamTheoNgaySinh);
        }
        public int DemThueBaoTheoThang(int thang)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (a[i].Thang == thang)
                    count++;
            }
            return count;
        }
        public int TimSoLuongThueBaoCaoNhat()
        {
            int max = -1;
            for (int i = 0; i < length; i++)
            {
                if (max < DemThueBaoTheoThang(a[i].Thang))
                    max = DemThueBaoTheoThang(a[i].Thang);
            }
            return max;
        }
        public int[] TimThangCoThueBaoCaoNhat(ref int len)
        {
            int[] kq = new int[100];
            int max = TimSoLanThueBaoXuatHienNhieuNhat();
            for (int i = 0; i < length; i++)
            {
                if (DemThueBaoTheoThang(a[i].Thang) == max)
                    kq[len++] = a[i].Thang;
            }
            return kq;
        }
        /*
        Kiểu dữ liệu List 

        */
        public List<int> TimThangCoThueBaoCaoNhat()
        {
            List<int> kq = new List<int>();
            int max = TimSoLanThueBaoXuatHienNhieuNhat();
            for (int i = 0; i < length; i++)
            {
                if (DemThueBaoTheoThang(a[i].Thang) == max && !kq.Contains(a[i].Thang)) // sau khi tim thay max thi contains kiem tra ton tai hay chua
                    kq.Add(a[i].Thang);
            }
            return kq;
        }
    }
}
