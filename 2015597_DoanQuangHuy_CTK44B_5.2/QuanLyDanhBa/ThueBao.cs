using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
    /* 
     * Enum giới tính
     */
    enum GioiTinh
    {
        Nam,
        Nu
    }
    class ThueBao
    {
        /*
         *THUỘC TÍNH 
         */
        public string soCMND;
        public string hoTen;
        public GioiTinh gioiTinh; // Dùng enum để tạo ra kdl Giới Tính
        public DateTime ngayThangNamSinh; // ngày tháng năm sinh của thuê bao
        public string diaChi;
        public string thanhPho;
        public string tinh;
        public DateTime ngayThangNamDangKy; // ngày tháng năm đăng ký thuê bao
        public string SDT;
        public string kieuThueBao;
        public DateTime ngayThangNamLapDat;
        public string nhaMang;

        public int thangDangKy
        {
            get
            {
                return ngayThangNamDangKy.Month;
            }
        }
        public int thangSinh
        {
            get
            {
                return ngayThangNamSinh.Month;
            }
        }
        public int ngayDangKy
        {
            get
            {
                return ngayThangNamDangKy.Day;
            }
        }

        /*
         *PHƯƠNG THỨC
         */
        // Hàm khởi tạo mặc định không tham số truyền vào
        public ThueBao()
        {

        }

        // Hàm khởi tạo có tham số thuộc tính truyền vào
        public ThueBao(string soCMND, string hoTen, GioiTinh gioiTinh, DateTime ngayThangNamSinh, 
            string diaChi, string thanhPho, string tinh, DateTime ngayThangNamDangKy, string SDT, 
            string kieuThueBao, DateTime ngayThangNamLapDat, string nhaMang)
        {
            // Con trỏ this chỉ đến đối tượng của lớp Thuê Bao
            // Khắc phục vấn đề trùng tên biến giữa thuộc tính của 
            // class và tham số truyền vào
            this.soCMND = soCMND;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.ngayThangNamSinh = ngayThangNamSinh;
            this.diaChi = diaChi;
            this.thanhPho = thanhPho;
            this.tinh = tinh;
            this.ngayThangNamDangKy = ngayThangNamDangKy;
            this.SDT = SDT;
            this.kieuThueBao = kieuThueBao;
            this.ngayThangNamLapDat = ngayThangNamLapDat;
            this.nhaMang = nhaMang;
        }
        // dữ liệu truyền vào là 1 thông tin thuê bao
        public ThueBao(ThueBao thueBao)
        {
            this.soCMND = thueBao.soCMND;
            this.hoTen = thueBao.hoTen;
            this.gioiTinh = thueBao.gioiTinh;
            this.ngayThangNamSinh = thueBao.ngayThangNamSinh;
            this.diaChi = thueBao.diaChi;
            this.thanhPho = thueBao.thanhPho;
            this.tinh = thueBao.tinh;
            this.ngayThangNamDangKy = thueBao.ngayThangNamDangKy;
            this.SDT = thueBao.SDT;
            this.kieuThueBao = thueBao.kieuThueBao;
            this.ngayThangNamLapDat = thueBao.ngayThangNamLapDat;
            this.nhaMang = thueBao.nhaMang;
        }
        public ThueBao(string line)
        {
            string[] s = line.Split(','); // cắt chuỗi theo dấu phẩy
            this.soCMND = s[0].Trim();
            this.hoTen = s[1].Trim();
            this.gioiTinh = s[2].Trim() == "Nam" ? GioiTinh.Nam : GioiTinh.Nu; // Toán tử 3 ngôi - Nếu chuỗi trong s[2] = Nam thì là Nam ngược lại Nữ
            this.ngayThangNamSinh = DateTime.Parse(s[3].Trim());
            this.diaChi = s[4].Trim();
            this.thanhPho = s[5].Trim();
            this.tinh = s[6].Trim();
            this.ngayThangNamDangKy = DateTime.Parse(s[7].Trim());
            this.SDT = s[8].Trim();

            string[] loaiHinhDangKy = s[9].Trim().Split('-');
            this.ngayThangNamLapDat = DateTime.Parse(loaiHinhDangKy[0]);
            this.kieuThueBao = loaiHinhDangKy[1];
            this.nhaMang = loaiHinhDangKy[2];
        }
        public override string ToString()
        {
            string s = "{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}\r\n";
            return string.Format(s, soCMND.PadRight(8), hoTen.PadRight(20), gioiTinh.ToString().PadRight(4),
                ngayThangNamSinh.ToShortDateString().PadRight(12), diaChi.PadRight(26), thanhPho.PadRight(12), tinh.PadRight(15),
                ngayThangNamDangKy.ToShortDateString().PadRight(12), SDT.PadRight(11));
        }
    }
}
