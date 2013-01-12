using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TraLaiNCC
    {
        #region hungvv======================================================================================================================
        private string hanhdong;
        private int traLaiNCCID;
        private string maHDTraLaiNCC;
        private DateTime ngaytra;
        private string maNCC;
        private string noHienThoi;
        private string nguoiNhanHang;
        private string hinhThucThanhToan;
        private string maHoaDonNhap;
        private string maKho;
        private string maTienTe;
        private string tienBoiThuong;
        private string thanhToanNgay;
        private string thueGTGT;
        private string ghiChu;
        private Boolean deleted;
        string tenNCC;


        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int TraLaiNCCID
        {
            get { return this.traLaiNCCID; }
            set
            {
                this.traLaiNCCID = value;
            }
        }
        public string MaHDTraLaiNCC
        {
            get { return this.maHDTraLaiNCC; }
            set
            {
                this.maHDTraLaiNCC = value;
            }
        }
        public DateTime Ngaytra
        {
            get { return this.ngaytra; }
            set { this.ngaytra = value; }
        }
        public string MaNCC
        {
            get { return this.maNCC; }
            set { this.maNCC = value; }
        }
        public string NoHienThoi
        {
            get { return this.noHienThoi; }
            set { this.noHienThoi = value; }
        }
        public string NguoiNhanHang
        {
            get { return this.nguoiNhanHang; }
            set { this.nguoiNhanHang = value; }
        }
        public string HinhThucThanhToan
        {
            get { return this.hinhThucThanhToan; }
            set { this.hinhThucThanhToan = value; }
        }

        public string MaHoaDonNhap
        {
            get { return this.maHoaDonNhap; }
            set { this.maHoaDonNhap = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public string TienBoiThuong
        {
            get { return this.tienBoiThuong; }
            set { this.tienBoiThuong = value; }
        }
        public string ThanhToanNgay
        {
            get { return this.thanhToanNgay; }
            set { this.thanhToanNgay = value; }
        }
        public string ThueGTGT
        {
            get { return this.thueGTGT; }
            set { this.thueGTGT = value; }
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

        private string manhanvien;
        private string tendangnhap;
        public string Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }
        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        public string TenNCC
        {
            get { return this.tenNCC; }
            set { this.tenNCC = value; }
        }

        #endregion hungvv======================================================================================================================

        #region hungvv======================================================================================================================
        public TraLaiNCC() { }

        public TraLaiNCC(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public TraLaiNCC(string hanhdong, string maKho,int i)
        {
            this.hanhdong = hanhdong;
            this.maKho = maKho;
        }

        public TraLaiNCC(string hanhdong, string maHDTraLaiNCC)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
        }

        public TraLaiNCC(string hanhdong, string maHDTraLaiNCC, DateTime ngaytra, string maNCC, string noHienThoi, string nguoiNhanHang, string hinhThucThanhToan, string maHoaDonNhap, string maKho, string maTienTe, string tienBoiThuong, string thanhToanNgay, string thueGTGT, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.ngaytra = ngaytra;
            this.maNCC = maNCC;
            this.noHienThoi = noHienThoi;
            this.nguoiNhanHang = nguoiNhanHang;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maHoaDonNhap = maHoaDonNhap;
            this.maKho = maKho;
            this.maTienTe = maTienTe;
            this.tienBoiThuong = tienBoiThuong;
            this.thanhToanNgay = thanhToanNgay;
            this.thueGTGT = thueGTGT;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        #endregion hungvv======================================================================================================================

    }
}
