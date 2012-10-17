using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class NhanVien
    {
        public NhanVien() { }

        string maNhanVien = string.Empty;
        string tenNhanVien = string.Empty;
        string sCMND = string.Empty;
        string soDienThoai = string.Empty;
        string email = string.Empty;
        string gioiTinh = string.Empty;
        string ngaySinh = string.Empty;
        string diaChi = string.Empty;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }
        public string SCMND
        {
            get { return sCMND; }
            set { sCMND = value; }
        }
        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        public string NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
    }
}
