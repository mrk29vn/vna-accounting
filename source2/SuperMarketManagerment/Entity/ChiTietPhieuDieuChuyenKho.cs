using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]

    public class ChiTietPhieuDieuChuyenKho
    {
        #region hungvv====================================================
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maPhieuDieuChuyenKho;
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuong;
        private DateTime ngayHetHan;
        private string ghiChu;
        private bool deleted;
        public ChiTietPhieuDieuChuyenKho()
        { }

        public ChiTietPhieuDieuChuyenKho(string hanhDong,string maPhieuDieuChuyenKho)
        {
            this.hanhDong = hanhDong;
            this.maPhieuDieuChuyenKho = maPhieuDieuChuyenKho;
        }

        public ChiTietPhieuDieuChuyenKho(string maPhieuDieuChuyenKho, string maHangHoa, int soLuong, string ghiChu, bool deleted)
        {
            this.maPhieuDieuChuyenKho = maPhieuDieuChuyenKho;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public ChiTietPhieuDieuChuyenKho(string hanhDong, string maPhieuDieuChuyenKho, string maHangHoa, int soLuong, DateTime ngayHetHan, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.maPhieuDieuChuyenKho = maPhieuDieuChuyenKho;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.ngayHetHan = ngayHetHan;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public ChiTietPhieuDieuChuyenKho(string hanhDong, string maPhieuDieuChuyenKho, string maHangHoa)
        {
            this.hanhDong = hanhDong;
            this.maPhieuDieuChuyenKho = maPhieuDieuChuyenKho;
            this.maHangHoa = maHangHoa;
        }

        public ChiTietPhieuDieuChuyenKho(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }

        public string MaPhieuDieuChuyenKho
        {
            get { return this.maPhieuDieuChuyenKho; }
            set { this.maPhieuDieuChuyenKho = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        
        public int SoLuong
        {
            get { return this.soLuong; }
            set
            {
                this.soLuong = value;
            }
        }
        public DateTime NgayHetHan
        {
            get { return ngayHetHan; }
            set { ngayHetHan = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public bool Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }
        #endregion
    }
}
