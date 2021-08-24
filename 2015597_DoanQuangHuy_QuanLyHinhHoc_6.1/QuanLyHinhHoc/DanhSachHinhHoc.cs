using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace QuanLyHinhHoc
{
    class DanhSachHinhHoc
    {
        List<HinhHoc> collection = new List<HinhHoc>();
        List<string> listKieuHinhHoc;
        public void Them(HinhHoc hh)
        {
            collection.Add(hh);
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in collection)
            {
                s += "\n" + item;
            }
            return s;
        }
        public void NhapTuFile()
        {
            string path = @"data.txt";
            StreamReader sr = new StreamReader(path);
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                string[] Line = str.Trim().Split(' ');
                if (Line[0] == "HT") Them(new HinhTron(float.Parse(Line[1])));
                if (Line[0] == "HV") Them(new HinhVuong(float.Parse(Line[1])));
                if (Line[0] == "HCN") Them(new HinhChuNhat(float.Parse(Line[1]), (float.Parse(Line[2]))));
            }
        }
        float TimDienTichHinhVuongLonNhat()
        {
            float max = -1;
            foreach (var item in collection)
            {
                if (item is HinhVuong)
                {
                    float dt = ((HinhVuong)item).TinhDT();
                    if (dt > max)
                        max = dt;
                }
            }
            return max;
        }
        public DanhSachHinhHoc TimHinhVuongCoDTLonNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimDienTichHinhVuongLonNhat();
            foreach (var item in collection)
            {
                //if (item is HinhVuong && ((HinhVuong)item).TinhDT() == max)
                //    kq.Them(item);
                if (item.TinhDT() == max)
                    kq.Them(item);
            }
            return kq;
        }
        float TimDienTichLonNhat()
        {
            float max = float.MinValue;
            foreach (var item in collection)
            {
                float dt = 0;
                if (item is HinhVuong)
                    dt = ((HinhVuong)item).TinhDT();
                if (item is HinhTron)
                    dt = ((HinhTron)item).TinhDT();
                if (dt > max)
                    max = dt;
            }
            //return collection.max(x => x.TinhDT());
            return max;
        }
        public DanhSachHinhHoc TimHinhCoDTLonNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimDienTichLonNhat();
            foreach (var item in collection)
            {
                if (item is HinhVuong && ((HinhVuong)item).TinhDT() == max)
                    kq.Them(item);
                if (item is HinhTron && ((HinhTron)item).TinhDT() == max)
                    kq.Them(item);
            }
            return kq;
        }
        //Tìm tất cả hình vuông có diện tích, chu vi là x
        public DanhSachHinhHoc TimHVCoDTlaX(float dt)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimDienTichLonNhat();
            foreach (var item in collection)
            {
                if (item is HinhVuong && ((HinhVuong)item).TinhDT() == dt)
                    kq.Them(item);
            }
            return kq;
        }
        public DanhSachHinhHoc TimHVCoCVlaX(float cv)
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimDienTichLonNhat();
            foreach (var item in collection)
            {
                if (item is HinhVuong && ((HinhVuong)item).TinhCV() == cv)
                    kq.Them(item);
            }
            return kq;
        }
        //Tìm tất cả hình vuông có diện tích, chu vi nhỏ nhất
        float TimDienTichHinhVuongNhoNhat()
        {
            float min = float.MaxValue;
            foreach (var item in collection)
            {
                if (item is HinhVuong)
                {
                    float dt = ((HinhVuong)item).TinhDT();
                    if (dt < min)
                        min = dt;
                }
            }
            return min;
        }
        public DanhSachHinhHoc TimHinhVuongCoDTNhoNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float min = TimDienTichHinhVuongNhoNhat();
            foreach (var item in collection)
            {
                if (item is HinhVuong && ((HinhVuong)item).TinhDT() == min)
                    kq.Them(item);
            }
            return kq;
        }
        float TimChuViHinhVuongNhoNhat()
        {
            float min = float.MaxValue;
            foreach (var item in collection)
            {
                if (item is HinhVuong)
                {
                    float cv = ((HinhVuong)item).TinhCV();
                    if (cv < min)
                        min = cv;
                }
            }
            return min;
        }
        public DanhSachHinhHoc TimHinhVuongCoCVNhoNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float min = TimChuViHinhVuongNhoNhat();
            foreach (var item in collection)
            {
                if (item is HinhVuong && ((HinhVuong)item).TinhCV() == min)
                    kq.Them(item);
            }
            return kq;
        }
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
        //Tìm hình vuông có cạnh nhỏ nhất
        public float TimCanhHVNhoNhat()
        {
            return (from x in collection where x is HinhVuong select x).Min(x => ((HinhVuong)x).canh);
        }
        public DanhSachHinhHoc TimHVCanhMin()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float min = TimCanhHVNhoNhat();
            kq.collection = collection.FindAll(x => x is HinhVuong && ((HinhVuong)x).canh == min);
            return kq;
        }

        // Tìm hình vuông có cạnh lớn nhất
        public float TimCanhHVLonNhat()
        {
            return (from x in collection where x is HinhVuong select x).Max(x => ((HinhVuong)x).canh);
        }
        public DanhSachHinhHoc TimHVCanhMax()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimCanhHVLonNhat();
            kq.collection = collection.FindAll(x => x is HinhVuong && ((HinhVuong)x).canh == max);
            return kq;
        }

        public float TimBKMax()
        {
            return (from x in collection where x is HinhTron select x).Max(x => ((HinhTron)x).banKinh);
        }
        public DanhSachHinhHoc TimBKLonNhat()
        {
            DanhSachHinhHoc kq = new DanhSachHinhHoc();
            float max = TimBKMax();
            kq.collection = collection.FindAll(x => x is HinhTron && ((HinhTron)x).banKinh == max);
            return kq;
        }
        public float TinhTongDienTichCuaHinhHoc<KDL>()
        {
            
            return (from x in collection where x is KDL select x.TinhDT()).Sum();
            //float sum = 0;
            /* foreach (var item in collection)
                 if (item is KDL)
                     sum += item.TinhDT();
             return sum;*/
        }
        public float TinhTongChuViCuaHinhHoc<KDL>()
        {
            //float sum = 0;
            //foreach (var item in collection)
            //    if (item is KDL)
            //        sum += item.TinhCV();
            //return sum;
            return (from x in collection where x is KDL select x.TinhCV()).Sum();
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
            {
                if (item is KDL)
                {
                    dem++;
                }
                    
            }
                
            return dem;
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

        //Tìm các hình có chu vi nhỏ nhất
        float TimChuViHinhHocNhoNhat<KDL>()
        {
            float min = int.MaxValue;
            foreach (var item in collection)
                if (item is KDL && item.TinhCV() < min)
                    min = item.TinhCV();
            return min;
        }
        //Tìm các hình có chu vi lớn nhất
        float TimChuViHinhHocLonNhat<KDL>()
        {
            float max = 0;
            foreach (var item in collection)
                if (item is KDL && item.TinhCV() > max)
                    max = item.TinhCV();
            return max;
        }

        //Tìm các hình có diện tích nhỏ nhất
        float TimDienTichHinhHocNhoNhat<KDL>()
        {
            float min = int.MaxValue;
            foreach (var item in collection)
                if (item is KDL && item.TinhDT() < min)
                    min = item.TinhDT();
            return min;
        }
        //Tìm các hình có diện tích lớn nhất
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
       
    }
}