using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class SoDuKho
    {
        string hanhDong;   
        int soDuKhoID;
        string maSoDuKho;
        string maKho;
        string maHangHoa;
        string tenHangHoa;
        int soDuDauKy;
        int soDuCuoiKy;
        DateTime ngayKetChuyen;
        int phatSinhNo;
        int phatSinhCo;
        bool trangThai;

        public SoDuKho(string hanhDong, int soDuKhoID, string maSoDuKho,string maKho, string maHangHoa, int soDuDauKy, int soDuCuoiKy,
        DateTime NgayKetChuyen,int phatSinhNo,int phatSinhCo,bool trangThai )
        {
            this.hanhDong = hanhDong;
            this.soDuKhoID = soDuKhoID;
            this.maSoDuKho = maSoDuKho;
            this.maKho = maKho;
            this.maHangHoa = maHangHoa;
            this.soDuCuoiKy = soDuCuoiKy;
            this.soDuDauKy = soDuDauKy;
            this.phatSinhCo= phatSinhCo;
            this.phatSinhNo= phatSinhNo;
            this.trangThai = trangThai;
            this.ngayKetChuyen = NgayKetChuyen;
        }

        public SoDuKho(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public SoDuKho()
        {
            
        }

        public SoDuKho(string hanhDong, int soDuKhoID)
        {
            this.hanhDong = hanhDong;
            this.soDuKhoID = soDuKhoID;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public int SoDuKhoID
        {
            get { return soDuKhoID; }
            set { soDuKhoID = value; }
        }

        public string MaSoDuKho
        {
            get { return maSoDuKho; }
            set { maSoDuKho = value; }
        }

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
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
    
        public int PhatSinhNo
        {
            get { return phatSinhNo; }
            set { phatSinhNo = value; }
        }

        public int PhatSinhCo
        {
            get { return phatSinhCo; }
            set { phatSinhCo = value; }
        }

        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    }
}
