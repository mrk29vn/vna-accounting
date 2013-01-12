using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TKNganHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int tKNganHangID;
        private string maTKNganHang;
        private string soTK;
        private string maTienTe;
        private int soDu;
        private string soSecKeTiep;
        private string nguoiLienHe;
        private string diaChi;
        private string dienThoai;
        private string email;
        private string website;
        private string ghichu;
        private float laisuat;
        private bool deleted;
        public TKNganHang()
        { }
        public TKNganHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public TKNganHang(int tKNganHangID, string maTKNganHang, string soTK, string maTienTe, int soDu, string soSecKeTiep, string nguoiLienHe, string diaChi, string dienThoai, string email, string website, string ghichu, float laisuat, bool deleted)
        {
            this.tKNganHangID = tKNganHangID;
            this.maTKNganHang = maTKNganHang;
            this.soTK = soTK;
            this.maTienTe = maTienTe;
            this.soDu = soDu;
            this.soSecKeTiep = soSecKeTiep;
            this.nguoiLienHe = nguoiLienHe;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.website = website;
            this.ghichu = ghichu;
            this.laisuat = laisuat;
            this.deleted = deleted;
        }
        public TKNganHang(string hanhDong, int tKNganHangID)
        {
            this.hanhDong = hanhDong;
            this.tKNganHangID = tKNganHangID;
        }

        public TKNganHang(string hanhDong, int tKNganHangID, string maTKNganHang, string soTK, string maTienTe, int soDu, string soSecKeTiep, string nguoiLienHe, string diaChi, string dienThoai, string email, string website, string ghichu, float laisuat, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.tKNganHangID = tKNganHangID;
            this.maTKNganHang = maTKNganHang;
            this.soTK = soTK;
            this.maTienTe = maTienTe;
            this.soDu = soDu;
            this.soSecKeTiep = soSecKeTiep;
            this.nguoiLienHe = nguoiLienHe;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.website = website;
            this.ghichu = ghichu;
            this.laisuat = laisuat;
            this.deleted = deleted;
        }

        public int TKNganHangID
        {
            get { return this.tKNganHangID; }
            set
            {
                this.tKNganHangID = value;
            }
        }
        public string MaTKNganHang
        {
            get { return this.maTKNganHang; }
            set
            {
                this.maTKNganHang = value;
            }
        }
        public string SoTK
        {
            get { return this.soTK; }
            set
            {
                this.soTK = value;
            }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public int SoDu
        {
            get { return soDu; }
            set { soDu = value; }
        }
        public string SoSecKeTiep
        {
            get { return soSecKeTiep; }
            set { soSecKeTiep = value; }
        }
        public string NguoiLienHe
        {
            get { return this.nguoiLienHe; }
            set { this.nguoiLienHe = value; }
        }
        public string DiaChi
        {
            get { return this.diaChi; }
            set { this.diaChi = value; }
        }
        public string DienThoai
        {
            get { return this.dienThoai; }
            set { this.dienThoai = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Website
        {
            get { return this.website; }
            set { this.website = value; }
        }
        public string Ghichu
        {
            get { return this.ghichu; }
            set { this.ghichu = value; }
        }
        public float Laisuat
        {
            get { return this.laisuat; }
            set { this.laisuat = value; }
        }
        public bool Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }
}
