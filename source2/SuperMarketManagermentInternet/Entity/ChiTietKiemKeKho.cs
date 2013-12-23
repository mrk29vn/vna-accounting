using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietKiemKeKho
    {
        #region hungvv==========================================================================================================

        private bool isChange;

        public bool IsChange
        {
            get { return isChange; }
            set { isChange = value; }
        }

        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string maPhieuKiemKe;
        public string MaPhieuKiemKe
        {
            get { return this.maPhieuKiemKe; }
            set { this.maPhieuKiemKe = value; }
        }
        private string maHangHoa;
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }
        private string tenhanghoa;
        public string Tenhanghoa
        {
            get { return tenhanghoa; }
            set { tenhanghoa = value; }
        }
        
        private string tonSoSach;
        public string TonSoSach
        {
            get { return this.tonSoSach; }
            set
            {
                this.tonSoSach = value;
            }
        }
        private string tonThucTe;
        public string TonThucTe
        {
            get { return this.tonThucTe; }
            set
            {
                this.tonThucTe = value;
            }
        }
        private string chenhlech;
        public string Chenhlech
        {
            get { return chenhlech; }
            set { chenhlech = value; }
        }
        private string lyDo;
        public string LyDo
        {
            get { return this.lyDo; }
            set { this.lyDo = value; }
        }
        private string gianhap;
        public string Gianhap
        {
            get { return gianhap; }
            set { gianhap = value; }
        }
        private string giachenhlecth;
        
        public string Giachenhlecth
        {
            get { return giachenhlecth; }
            set { giachenhlecth = value; }
        }
        private string ghiChu;
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        private Boolean deleted;
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

        public ChiTietKiemKeKho() { }

        public ChiTietKiemKeKho(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ChiTietKiemKeKho(string hanhdong, string maPhieuKiemKe)
        {
            this.hanhdong = hanhdong;
            this.maPhieuKiemKe = maPhieuKiemKe;
        }
        public ChiTietKiemKeKho(string hanhdong, string maPhieuKiemKe, string maHangHoa)
        {
            this.hanhdong = hanhdong;
            this.maPhieuKiemKe = maPhieuKiemKe;
            this.maHangHoa = maHangHoa;
        }
        public ChiTietKiemKeKho(string hanhdong, string maPhieuKiemKe, string maHangHoa, string tonThucTe, string tonSoSach, string lyDo, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maPhieuKiemKe = maPhieuKiemKe;
            this.maHangHoa = maHangHoa;
            this.tonThucTe = tonThucTe;
            this.tonSoSach = tonSoSach;
            this.lyDo = lyDo;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public ChiTietKiemKeKho(string hanhdong, string maPhieuKiemKe, string maHangHoa, string tonThucTe, string chenhlech,string tonSoSach, string lyDo,string giagoc,string giachenhlech)
        {
            this.hanhdong = hanhdong;
            this.maPhieuKiemKe = maPhieuKiemKe;
            this.maHangHoa = maHangHoa;
            this.tonThucTe = tonThucTe;
            this.tonSoSach = tonSoSach;
            this.chenhlech = chenhlech;
            this.lyDo = lyDo;
            this.gianhap = giagoc;
            this.giachenhlecth = giachenhlech;
        }
        public ChiTietKiemKeKho(string hanhdong, string maPhieuKiemKe, string maHangHoa,string tenhang, string tonThucTe, string tonSoSach, string lyDo, string gia,string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maPhieuKiemKe = maPhieuKiemKe;
            this.maHangHoa = maHangHoa;
            this.tenhanghoa = tenhang;
            this.tonThucTe = tonThucTe;
            this.tonSoSach = tonSoSach;
            this.lyDo = lyDo;
            this.gianhap = gia;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        #endregion
    }
}
