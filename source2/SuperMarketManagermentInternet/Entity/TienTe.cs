using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TienTe
    {
        public string NhanVienID;
        public string TenDangNhap;
        private int tienteID;
        private string maTienTe;
        private string tenTienTe;
        private string tenTienTeChan;
        private string tenTienTeLe;
        private string bieuTuong;
        private int donViLamTron;
        private string ghiChu;
        private Boolean deleted;
        private string hanhDong = null;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public TienTe()
        { }
        public TienTe(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public TienTe(string tenTienTe, Boolean deleted)
        {
            this.tenTienTe = tenTienTe;
            this.deleted = deleted;
        }
        public TienTe(string Hanhdong, int tienteID)
        {
            this.hanhDong = Hanhdong;
            this.tienteID = tienteID;
        }
        public TienTe(string hanhDong, int tienteID, string maTienTe, string tenTienTe, string tenTienTeChan, string tenTienTeLe, string bieuTuong, int donViLamTron, string ghiChu, Boolean deleted, string nhanVienID, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.tienteID = tienteID;
            this.maTienTe = maTienTe;
            this.tenTienTe = tenTienTe;
            this.tenTienTeChan = tenTienTeChan;
            this.tenTienTeLe = tenTienTeLe;
            this.bieuTuong = bieuTuong;
            this.donViLamTron = donViLamTron;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.NhanVienID = nhanVienID;
            this.TenDangNhap=tenDangNhap;
        }

        public TienTe(int tienteID, string maTienTe, string tenTienTe, string tenTienTeChan, string tenTienTeLe, string bieuTuong, int donViLamTron, string ghiChu, Boolean deleted)
        {
            this.tienteID = tienteID;
            this.maTienTe = maTienTe;
            this.tenTienTe = tenTienTe;
            this.tenTienTeChan = tenTienTeChan;
            this.tenTienTeLe = tenTienTeLe;
            this.bieuTuong = bieuTuong;
            this.donViLamTron = donViLamTron;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public int TienteID
        {
            get { return this.tienteID; }
            set
            {
                this.tienteID = value;
            }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set
            {
                this.maTienTe = value;
            }
        }
        public string TenTienTe
        {
            get { return this.tenTienTe; }
            set
            {
                this.tenTienTe = value;
            }
        }
        public string TenTienTeChan
        {
            get { return this.tenTienTeChan; }
            set { this.tenTienTeChan = value; }
        }
        public string TenTienTeLe
        {
            get { return this.tenTienTeLe; }
            set { this.tenTienTeLe = value; }
        }
        public string BieuTuong
        {
            get { return this.bieuTuong; }
            set { this.bieuTuong = value; }
        }
        public int DonViLamTron
        {
            get { return this.donViLamTron; }
            set { this.donViLamTron = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }
    }
}
