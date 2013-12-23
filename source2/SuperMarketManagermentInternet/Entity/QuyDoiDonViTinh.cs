using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class QuyDoiDonViTinh
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int quyDoiDonViTinhID;
        private string maQuyDoiDonViTinh;
        private string maHangQuyDoi;
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
        private string tenHangQuyDoi;

        public string TenHangQuyDoi
        {
            get { return tenHangQuyDoi; }
            set { tenHangQuyDoi = value; }
        }
        private string maDonViTinh;

        public string MaDonViTinh
        {
            get { return maDonViTinh; }
            set { maDonViTinh = value; }
        }
        private int soLuongQuyDoi;
        private string maHangDuocQuyDoi;
        private string tenHangDuocQuyDoi;
        private string maDonViTinhDuocQuyDoi;
        private int soLuongDuocQuyDoi;
        private Boolean deleted;
        public QuyDoiDonViTinh()
        { }
        public QuyDoiDonViTinh(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public QuyDoiDonViTinh(string hanhdong, string mahangduocquydoi)
        {
            this.hanhDong = hanhdong;
            this.maHangDuocQuyDoi = mahangduocquydoi;
        }
        public QuyDoiDonViTinh(string hanhdong, int quyDoiDonViTinhID, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.quyDoiDonViTinhID = quyDoiDonViTinhID;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public QuyDoiDonViTinh(string hanhdong, int quyDoiDonViTinhID, string maQuyDoiDonViTinh, string maHangQuyDoi, string tenhangquydoi, string madonvitinh, int soLuongQuyDoi, string maHangDuocQuyDoi, string tenHangDuocQuyDoi, string maDonViTinhDuocQuyDoi, int soLuongDuocQuyDoi, Boolean deleted)
        {
            this.hanhDong = hanhdong;
            this.quyDoiDonViTinhID = quyDoiDonViTinhID;
            this.maQuyDoiDonViTinh = maQuyDoiDonViTinh;
            this.maHangQuyDoi = maHangQuyDoi;
            this.tenHangQuyDoi = tenhangquydoi;
            this.maDonViTinh = madonvitinh;
            this.soLuongQuyDoi = soLuongQuyDoi;
            this.maHangDuocQuyDoi = maHangDuocQuyDoi;
            this.tenHangDuocQuyDoi = tenHangDuocQuyDoi;
            this.maDonViTinhDuocQuyDoi = maDonViTinhDuocQuyDoi;
            this.soLuongDuocQuyDoi = soLuongDuocQuyDoi;
            this.deleted = deleted;
        }
        public QuyDoiDonViTinh(string hanhdong, int quyDoiDonViTinhID, string maQuyDoiDonViTinh, string maHangQuyDoi, string tenhangquydoi, string madonvitinh, int soLuongQuyDoi, string maHangDuocQuyDoi, string tenHangDuocQuyDoi, string maDonViTinhDuocQuyDoi, int soLuongDuocQuyDoi, Boolean deleted,string maNhanVien,string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.quyDoiDonViTinhID = quyDoiDonViTinhID;
            this.maQuyDoiDonViTinh = maQuyDoiDonViTinh;
            this.maHangQuyDoi = maHangQuyDoi;
            this.tenHangQuyDoi = tenhangquydoi;
            this.maDonViTinh = madonvitinh;
            this.soLuongQuyDoi = soLuongQuyDoi;
            this.maHangDuocQuyDoi = maHangDuocQuyDoi;
            this.tenHangDuocQuyDoi = tenHangDuocQuyDoi;
            this.maDonViTinhDuocQuyDoi = maDonViTinhDuocQuyDoi;
            this.soLuongDuocQuyDoi = soLuongDuocQuyDoi;
            this.deleted = deleted;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public int QuyDoiDonViTinhID
        {
            get { return this.quyDoiDonViTinhID; }
            set
            {
                this.quyDoiDonViTinhID = value;
            }
        }
        public string MaQuyDoiDonViTinh
        {
            get { return this.maQuyDoiDonViTinh; }
            set
            {
                this.maQuyDoiDonViTinh = value;
            }
        }
        public string MaHangQuyDoi
        {
            get { return this.maHangQuyDoi; }
            set
            {
                this.maHangQuyDoi = value;
            }
        }
        public int SoLuongQuyDoi
        {
            get { return this.soLuongQuyDoi; }
            set
            {
                this.soLuongQuyDoi = value;
            }
        }
        public string MaHangDuocQuyDoi
        {
            get { return this.maHangDuocQuyDoi; }
            set
            {
                this.maHangDuocQuyDoi = value;
            }
        }
        public string TenHangDuocQuyDoi
        {
            get { return this.tenHangDuocQuyDoi; }
            set
            {
                this.tenHangDuocQuyDoi = value;
            }
        }
        public string MaDonViTinhDuocQuyDoi
        {
            get { return this.maDonViTinhDuocQuyDoi; }
            set
            {
                this.maDonViTinhDuocQuyDoi = value;
            }
        }
        public int SoLuongDuocQuyDoi
        {
            get { return this.soLuongDuocQuyDoi; }
            set
            {
                this.soLuongDuocQuyDoi = value;
            }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }

}
