using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyHinhHoc
{
    class DanhSachHinhHoc
    {
        List<HinhHoc> collection = new List<HinhHoc>();
        List<string> listKieuHinhHoc;

        // Function      
        public void Them(HinhHoc hh)
        {
            collection.Add(hh);
        }
        public void NhapDuLieuTuFile()
        {
            string path = @"data.txt";
            StreamReader nhap = new StreamReader(path);
            string str = "";
            while ((str = nhap.ReadLine()) != null)
            {
                string[] data = str.Trim().Split(' ');
                if (data[0] == "HV")
                    Them(new HinhVuong(float.Parse(data[1])));
                else if (data[0] == "HT")
                    Them(new HinhTron(float.Parse(data[1])));
                else if (data[0] == "HCN")
                    Them(new HinhChuNhat(float.Parse(data[1]), float.Parse(data[2])));
            }
            listKieuHinhHoc = TimTatCaCacKieuHinhHocTrongDanhSach();
        }
        public void XuatDanhSachHinhHoc()
        {
            foreach (var item in collection)
                Console.WriteLine(item.KieuHinhHoc().PadRight(15) + item);
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in collection)
                s += "\n" + item;
            return s;
        }

        // Function xử lý hình học
        #region XuLyHinhHoc
        void HoanViList<KDL>(List<KDL> list, int index1, int index2)
        {
            KDL mid = list[index2];
            list[index2] = list[index1];
            list[index1] = mid;
        }
        enum KieuSapXep
        {
            SapXepHinhHocTangTheoDienTich,
            SapXepHinhHocGiamTheoDienTich,
            SapXepHinhHocTangTheoChuVi,
            SapXepHinhHocGiamTheoChuVi,
        }
        bool KiemTraDieuKienSapXep(KieuSapXep k, HinhHoc a, HinhHoc b)
        {
            if (k == KieuSapXep.SapXepHinhHocTangTheoDienTich)
            {
                if (a.TinhDT() > b.TinhDT())
                    return true;
            }
            else if (k == KieuSapXep.SapXepHinhHocGiamTheoDienTich)
            {
                if (a.TinhDT() < b.TinhDT())
                    return true;
            }
            else if (k == KieuSapXep.SapXepHinhHocTangTheoChuVi)
            {
                if (a.TinhCV() > b.TinhCV())
                    return true;
            }
            else if (k == KieuSapXep.SapXepHinhHocGiamTheoChuVi)
            {
                if (a.TinhCV() < b.TinhCV())
                    return true;
            }
            return false;
        }
        void SapXep<KDL>(KieuSapXep k)
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                    if (KiemTraDieuKienSapXep(k, collection[i], collection[j]) && collection[i] is KDL && collection[j] is KDL)
                        HoanViList<HinhHoc>(collection, i, j);
        }
        public float TinhTongDienTichCuaHinhHoc<KDL>()
        {
            float sum = 0;
            foreach (var item in collection)
                if (item is KDL)
                    sum += item.TinhDT();
            return sum;
        }
        public float TinhTongChuViCuaHinhHoc<KDL>()
        {
            float sum = 0;
            foreach (var item in collection)
                if (item is KDL)
                    sum += item.TinhCV();
            return sum;
        }
        public DanhSachHinhHoc TimHinhHocTheoDienTich<KDL>(float dt)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            foreach (var item in collection)
                if (item is KDL && item.TinhDT() == dt)
                    kq.Them(item);
            return kq;
        }
        public DanhSachHinhHoc TimHinhHocTheoChuVi<KDL>(float cv)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            foreach (var item in collection)
                if (item is KDL && item.TinhCV() == cv)
                    kq.Them(item);
            return kq;
        }
        public int DemSoLuongHinhHoc<KDL>()
        {
            int dem = 0;
            foreach (var item in collection)
                if (item is KDL)
                    dem++;
            return dem;
        }
        public void SapXepHinhHocTangTheoDienTich<KDL>()
        {
            SapXep<KDL>(KieuSapXep.SapXepHinhHocTangTheoDienTich);
        }
        public void SapXepHinhHocGiamTheoDienTich<KDL>()
        {
            SapXep<KDL>(KieuSapXep.SapXepHinhHocGiamTheoDienTich);
        }
        public void SapXepHinhHocTangTheoChuVi<KDL>()
        {
            SapXep<KDL>(KieuSapXep.SapXepHinhHocTangTheoChuVi);
        }
        public void SapXepHinhHocGiamTheoChuVi<KDL>()
        {
            SapXep<KDL>(KieuSapXep.SapXepHinhHocGiamTheoChuVi);
        }
        public DanhSachHinhHoc TimHinhHocCoChuViNhoNhat<KDL>()
        {
            return TimHinhHocTheoChuVi<KDL>(TimChuViHinhHocNhoNhat<KDL>());
        }
        public DanhSachHinhHoc TimHinhHocCoChuViLonNhat<KDL>()
        {
            return TimHinhHocTheoChuVi<KDL>(TimChuViHinhHocLonNhat<KDL>());
        }
        public DanhSachHinhHoc TimHinhHocCoDienTichLonNhat<KDL>()
        {
            return TimHinhHocTheoDienTich<KDL>(TimDienTichHinhHocLonNhat<KDL>());
        }
        public DanhSachHinhHoc TimHinhHocCoDienTichNhoNhat<KDL>()
        {
            return TimHinhHocTheoDienTich<KDL>(TimDienTichHinhHocNhoNhat<KDL>());
        }
        float TimChuViHinhHocNhoNhat<KDL>()
        {
            float min = int.MaxValue;
            foreach (var item in collection)
                if (item is KDL && item.TinhCV() < min)
                    min = item.TinhCV();
            return min;
        }
        float TimChuViHinhHocLonNhat<KDL>()
        {
            float max = 0;
            foreach (var item in collection)
                if (item is KDL && item.TinhCV() > max)
                    max = item.TinhCV();
            return max;
        }
        float TimDienTichHinhHocNhoNhat<KDL>()
        {
            float min = int.MaxValue;
            foreach (var item in collection)
                if (item is KDL && item.TinhDT() < min)
                    min = item.TinhDT();
            return min;
        }
        float TimDienTichHinhHocLonNhat<KDL>()
        {
            float max = 0;
            foreach (var item in collection)
                if (item is KDL && item.TinhDT() > max)
                    max = item.TinhDT();
            return max;
        }
        public void XoaCacHinhCoDienTichNhoNhat()
        {
            for (int i = 0; i < collection.Count; i++)
                if (collection[i].TinhDT() == collection.Min<HinhHoc>(y => y.TinhDT()))
                    collection.RemoveAt(i);
        }
        public void XoaCacHinhCoDienTichLonNhat()
        {
            for (int i = 0; i < collection.Count; i++)
                if (collection[i].TinhDT() == collection.Max<HinhHoc>(y => y.TinhDT()))
                    collection.RemoveAt(i);
        }
        public void XoaCacHinhCoChuViNhoNhat()
        {
            for (int i = 0; i < collection.Count; i++)
                if (collection[i].TinhCV() == TimChuViHinhHocNhoNhat<HinhHoc>())
                    collection.RemoveAt(i);
        }
        public void XoaCacHinhCoChuViLonNhat()
        {
            for (int i = 0; i < collection.Count; i++)
                if (collection[i].TinhCV() == TimChuViHinhHocLonNhat<HinhHoc>())
                    collection.RemoveAt(i);
        }
        public bool KiemTraViTriThem(int vt)
        {
            for (int i = 0; i <= collection.Count; i++)
                if (i == vt)
                    return true;
            return false;
        }
        public bool ThemHinhHocThuCongTaiViTri(int vt)
        {
            Console.Write("Nhập kiểu hình (HV, HT, HCN): ");
            string loai = Console.ReadLine();
            if (loai == "HV")
            {
                Console.Write("Nhập cạnh: ");
                float canh = float.Parse(Console.ReadLine());
                collection.Insert(vt, new HinhVuong(canh));
                return true;
            }
            else if (loai == "HT")
            {
                Console.Write("Nhập bán kính: ");
                float banKinh = float.Parse(Console.ReadLine());
                collection.Insert(vt, new HinhTron(banKinh));
                return true;
            }
            else if (loai == "HCN")
            {
                Console.Write("Nhập chiều dài: ");
                float chieuDai = float.Parse(Console.ReadLine());
                Console.Write("Nhập chiều rộng: ");
                float chieuRong = float.Parse(Console.ReadLine());
                collection.Insert(vt, new HinhChuNhat(chieuDai, chieuRong));
                return true;
            }
            return false;
        }
        public bool XoaHinhHocTaiViTri(int vt)
        {
            for (int i = 0; i < collection.Count; i++)
                if (i == vt)
                {
                    collection.RemoveAt(i);
                    return true;
                }
            return false;
        }
        public List<string> TimTatCaCacKieuHinhHocTrongDanhSach()
        {
            List<string> listKieuHinhHoc = new List<string>();
            foreach (var item in collection)
                if (!listKieuHinhHoc.Contains(item.KieuHinhHoc()))
                    listKieuHinhHoc.Add(item.KieuHinhHoc());
            return listKieuHinhHoc;
        }
        float TinhTongDienTichHinhHocTheoKieuHinhHoc<KDL>(string kieuHinhHoc)
        {
            float sum = 0;
            foreach (var item in collection)
                if (item is KDL && item.KieuHinhHoc() == kieuHinhHoc)
                    sum += item.TinhDT();
            return sum;
        }
        float TinhTongChuViHinhHocTheoKieuHinhHoc<KDL>(string kieuHinhHoc)
        {
            float sum = 0;
            foreach (var item in collection)
                if (item is KDL && item.KieuHinhHoc() == kieuHinhHoc)
                    sum += item.TinhCV();
            return sum;
        }
        public string TimKieuHinhHocCoTongDienTichLonNhat()
        {
            string kq = listKieuHinhHoc[0];
            float max = TinhTongDienTichHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[0]);
            for (int i = 1; i < listKieuHinhHoc.Count; i++)
                if (TinhTongDienTichHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]) > max)
                {
                    max = TinhTongDienTichHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]);
                    kq = listKieuHinhHoc[i];
                }
            return kq;
        }
        public string TimKieuHinhHocCoTongDienTichNhoNhat()
        {
            string kq = listKieuHinhHoc[0];
            float min = int.MaxValue;
            for (int i = 1; i < listKieuHinhHoc.Count; i++)
                if (TinhTongDienTichHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]) < min)
                {
                    min = TinhTongDienTichHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]);
                    kq = listKieuHinhHoc[i];
                }
            return kq;
        }
        public string TimKieuHinhHocCoTongChuViLonNhat()
        {
            string kq = listKieuHinhHoc[0];
            float max = TinhTongChuViHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[0]);
            for (int i = 1; i < listKieuHinhHoc.Count; i++)
                if (TinhTongChuViHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]) > max)
                {
                    max = TinhTongChuViHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]);
                    kq = listKieuHinhHoc[i];
                }
            return kq;
        }
        public string TimKieuHinhHocCoTongChuViNhoNhat()
        {
            string kq = listKieuHinhHoc[0];
            float min = int.MaxValue;
            for (int i = 1; i < listKieuHinhHoc.Count; i++)
                if (TinhTongChuViHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]) < min)
                {
                    min = TinhTongChuViHinhHocTheoKieuHinhHoc<HinhHoc>(listKieuHinhHoc[i]);
                    kq = listKieuHinhHoc[i];
                }
            return kq;
        }
        public void XuatDuLieuTheoKieuHinhHoc(List<string> listTenFile)
        {
            for (int a = 0, j = 0; a < listTenFile.Count; a++, j++)
            {
                StreamWriter xuat = new StreamWriter(@listTenFile[a], append: false);
                xuat.WriteLine("========== Danh Sách " + listKieuHinhHoc[j] + " ==========\n");
                foreach (var i in collection)
                    if (i.KieuHinhHoc() == listKieuHinhHoc[j])
                        xuat.WriteLine(i);
                xuat.Flush();
                xuat.Close();
            }
        }
        public void XuatDuLieuCacHinhRaFileRieng()
        {
            List<string> listTenFile = new List<string> { "hinhvuong.txt", "hinhtron.txt", "hinhchunhat.txt" };
            listTenFile.Sort();
            listKieuHinhHoc.Sort();
            XuatDuLieuTheoKieuHinhHoc(listTenFile);
        }
        public void XuatBangTongHopHinhHocRaFile()
        {
            listKieuHinhHoc = TimTatCaCacKieuHinhHocTrongDanhSach();
            StreamWriter xuat = new StreamWriter(@"xuat.txt", append: false);
            xuat.WriteLine("=================== BẢNG TỔNG HỢP THÔNG TIN ===================\n");
            xuat.WriteLine("1) Tổng số các đối tượng hình học là: " + collection.Count);
            for (int i = 0, stt = 2; i < listKieuHinhHoc.Count; i++, stt++)
            {
                xuat.WriteLine(stt + ") Tổng số " + listKieuHinhHoc[i] + ": " + collection.FindAll(x => x.KieuHinhHoc() == listKieuHinhHoc[i]).Count);
            }
            for (int i = 0; i < listKieuHinhHoc.Count; i++)
            {
                xuat.WriteLine("\n" + (char)(i + 65) + ". Danh sách " + listKieuHinhHoc[i] + " (theo chiều tăng diện tích):");
                collection.ForEach(delegate (HinhHoc item)
                {
                    if (item.KieuHinhHoc() == listKieuHinhHoc[i])
                        xuat.WriteLine(item);
                });
            }

            xuat.Flush();
            xuat.Close();
        }
        #endregion
        // Function xử lý riêng của mảng hình chữ nhật
        #region XuLyHinhChuNhat
        float TimChieuDaiHCNNhoNhat()
        {
            float min = int.MaxValue;
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuDai < min)
                    min = ((HinhChuNhat)item).chieuDai;
            return min;
        }
        float TimChieuDaiHCNLonNhat()
        {
            float max = 0;
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuDai > max)
                    max = ((HinhChuNhat)item).chieuDai;
            return max;
        }
        float TimChieuRongHCNNhoNhat()
        {
            float min = int.MaxValue;
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuRong < min)
                    min = ((HinhChuNhat)item).chieuRong;
            return min;
        }
        float TimChieuRongHCNLonNhat()
        {
            float max = 0;
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuRong > max)
                    max = ((HinhChuNhat)item).chieuRong;
            return max;
        }
        public DanhSachHinhHoc TimHCNCoChieuDaiLonNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimChieuDaiHCNLonNhat();
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuDai == max)
                    kq.Them(item);
            return kq;
        }
        public DanhSachHinhHoc TimHCNCoChieuDaiNhoNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float min = TimChieuDaiHCNNhoNhat();
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuDai == min)
                    kq.Them(item);
            return kq;
        }
        public DanhSachHinhHoc TimHCNCoChieuRongLonNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimChieuRongHCNLonNhat();
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuRong == max)
                    kq.Them(item);
            return kq;
        }
        public DanhSachHinhHoc TimHCNCoChieuRongNhoNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float min = TimChieuRongHCNNhoNhat();
            foreach (var item in collection)
                if (item is HinhChuNhat && ((HinhChuNhat)item).chieuRong == min)
                    kq.Them(item);
            return kq;
        }
        public DanhSachHinhHoc SaoChepDanhBa()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            foreach (var item in collection)
                kq.Them(item);
            return kq;
        }




        #endregion

    }
}
