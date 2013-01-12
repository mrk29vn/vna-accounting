using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCNhapHangTheoThoiGian
    {
        private string maChungTu;
        private string tenChungTu;
        private DateTime ngayLap;
        private int soLuong;
        public string MaChungTu
        {
            get { return maChungTu; }
            set { maChungTu = value; }
        }
        public string TenChungTu
        {
            get { return tenChungTu; }
            set { tenChungTu = value; }
        }
        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public BCNhapHangTheoThoiGian()
        {
        }
        public BCNhapHangTheoThoiGian(string maChungTu, string tenChungTu, DateTime ngayLap, int soLuong)
        {
            this.maChungTu = maChungTu;
            this.tenChungTu = tenChungTu;
            this.ngayLap = ngayLap;
            this.soLuong = soLuong;
        }

    }
}
