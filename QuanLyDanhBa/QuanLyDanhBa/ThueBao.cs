using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
    enum GioiTinh
    {
        Nam,
        Nu
    }
    class ThueBao
    {
        // Thuoc tinh cua lop Thue Bao
        public string soCMND;
        public string hoTen;
        public string diaChi;
        public GioiTinh gioiTinh;
        public DateTime ngaySinh; // DateTime la kieu mm/dd/yy
        public string SDT;
        //public string ThanhPho;

         
        //public string ten
        //{
        //    get
        //    {
        //        int vt = hoTen.LastIndexOf(' ');
        //        return hoTen.Substring(vt + 1, hoTen.Length - vt - 1);
        //    }
        //}
        public int Thang
        {
            get { return ngaySinh.Month; }
        }
        // Ham khoi tao mac dinh - Phim tat go ctor -> Nhan tab -> tab
        public ThueBao()
        {

        }
        public ThueBao(string soCMND, string hoTen, string diaChi, GioiTinh gioiTinh, DateTime ngaySinh, string SDT/*, string ThanhPho*/)
        {
            this.soCMND = soCMND;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.SDT = SDT;
            //this.ThanhPho = ThanhPho;
        }
        public ThueBao(string line)
        {
            string[] Temp = line.Split(','); // tao ra mot mang de luu du lieu sau khi tach chuoi ~ ham split se tach chuoi moi khi gap dau phay
            this.soCMND = Temp[0].Trim();
            this.hoTen = Temp[1].Trim();
            this.diaChi = Temp[2].Trim();
            this.gioiTinh = Temp[3].Trim() == "Nam" ? GioiTinh.Nam : GioiTinh.Nu;
            this.ngaySinh = DateTime.Parse(Temp[4]);
            this.SDT = Temp[5].Trim();
            //this.ThanhPho = Temp[6].Trim();
        }
        ~ThueBao() { }
        public void Xuat()
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", soCMND, hoTen, diaChi, gioiTinh, ngaySinh, SDT/*, ThanhPho*/);
        }
        public override string ToString()
        {
            string Temp = "{0} | {1} | {2} | {3} | {4} | {5} |\n";
            return string.Format(Temp, soCMND.PadLeft(7), hoTen.PadRight(20), diaChi.PadRight(40), gioiTinh.ToString().PadRight(3), ngaySinh.ToShortDateString().PadRight(11), SDT.PadRight(11));
        }
    }
}
