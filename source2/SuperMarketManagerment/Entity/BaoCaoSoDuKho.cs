using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoSoDuKho
    {
        private string maSoDuKho;
        private string maHangHoa;
        private int soDuDauKy;
        private int soDuCuoiKy;
        private DateTime ngayKetChuyen;

        public BaoCaoSoDuKho(string maSoDuKho, string maHangHoa, int soDuDauKy, int soDuCuoiKy,DateTime NgayKetChuyen)
        {
            this.maSoDuKho = maSoDuKho;
            this.maHangHoa = maHangHoa;
            this.soDuCuoiKy = soDuCuoiKy;
            this.soDuDauKy = soDuDauKy;
            this.ngayKetChuyen = NgayKetChuyen;
        }

        public BaoCaoSoDuKho() { }
        public string MaSoDuKho
        {
            get { return maSoDuKho; }
            set { maSoDuKho = value; }
        }

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }

        public int SoDuDauKy
        {
            get { return soDuDauKy; }
            set { soDuDauKy = value; }
        }

        public int SoDuCuoiKy
        {
            get { return soDuCuoiKy; }
            set { soDuCuoiKy = value; }
        }

        public DateTime NgayKetChuyen
        {
            get { return ngayKetChuyen; }
            set { ngayKetChuyen = value; }
        }  
    }
}
