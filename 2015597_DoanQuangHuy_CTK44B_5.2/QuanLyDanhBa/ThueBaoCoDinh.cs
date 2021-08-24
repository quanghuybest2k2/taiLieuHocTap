using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
    class ThueBaoCoDinh : ThueBao
    {
        // Thuộc tính
        public int ngayLapDat
        {
            get
            {
                return ngayThangNamLapDat.Day;
            }
        }
        public ThueBaoCoDinh()
        {

        }
        public ThueBaoCoDinh(string line) : base(line) { }
        public ThueBaoCoDinh(ThueBao thueBao) : base(thueBao) { }

        public override string ToString()
        {
            return base.ToString().Trim('\n').Trim('\r') + " - " +ngayThangNamLapDat.ToShortDateString() + "\r\n";
        }

    }
}
