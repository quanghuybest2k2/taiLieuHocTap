using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
    class ThueBaoDiDong : ThueBao
    {
        public ThueBaoDiDong() { }
        public ThueBaoDiDong(string line) : base(line) { }
        public ThueBaoDiDong(ThueBao thueBao) : base(thueBao) { }
        public override string ToString()
        {
            return base.ToString().Trim('\n').Trim('\r') + " - " +nhaMang + "\r\n";

        }
    }
}
