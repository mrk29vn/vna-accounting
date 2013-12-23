using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class LogFile
    {
        private string maNhanVien;
        private string tenDangNhap;
        private string hanhDong;
        private string thoiGianThucHien;
        private string noiDung;

        public LogFile() { }
        public LogFile(string maNhanVien, string tenDangNhap, string hanhDong, string thoiGianThucHien, string noiDung)
        {
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.hanhDong = hanhDong;
            this.thoiGianThucHien = thoiGianThucHien;
            this.noiDung = noiDung;
        }

        public string MaNhanVien
        {
            get { return this.maNhanVien; }
            set { this.maNhanVien = value; }
        }
        public string TenDangNhap
        {
            get { return this.tenDangNhap; }
            set { this.tenDangNhap = value; }
        }
        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }
        public string NhoiGianThucHien
        {
            get { return this.thoiGianThucHien; }
            set { this.thoiGianThucHien = value; }
        }
        public string NoiDung
        {
            get { return this.noiDung; }
            set { this.noiDung = value; }
        }
    }
}
