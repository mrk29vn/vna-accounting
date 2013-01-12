using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhomTKKeToan
    {
        public string NhanVienID;
        public string TenDangNhap;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int nhomTKKeToanID;
        private string maNhomTKKeToan;
        private string tenNhomTKKeToan;
        private string ghiChu;
        private bool delete;
        public NhomTKKeToan() { }
        public NhomTKKeToan(string hanhDong) { this.hanhDong = hanhDong; }

        public NhomTKKeToan(int nhomtKKeToan, string maNhomTKKeToan, string tenNhomTKKeToan, string ghiChu, bool delete)
        {
            this.nhomTKKeToanID = nhomtKKeToan;
            this.maNhomTKKeToan = maNhomTKKeToan;
            this.tenNhomTKKeToan = tenNhomTKKeToan;
            this.ghiChu = ghiChu;
            this.delete = delete;
        }

        public NhomTKKeToan(string hanhDong, int nhomtKKeToan, string maNhomTKKeToan, string tenNhomTKKeToan, string ghiChu, bool delete, string nhanVienID, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.nhomTKKeToanID = nhomtKKeToan;
            this.maNhomTKKeToan = maNhomTKKeToan;
            this.tenNhomTKKeToan = tenNhomTKKeToan;
            this.ghiChu = ghiChu;
            this.delete = delete;
            this.NhanVienID = nhanVienID;
            this.TenDangNhap = tenDangNhap;
        }

        public int NhomTKKeToanID
        {
            get { return nhomTKKeToanID; }
            set { nhomTKKeToanID = value; }
        }
        public string MaNhomTKKeToan
        {
            get { return maNhomTKKeToan; }
            set { maNhomTKKeToan = value; }
        }
        public string TenNhomTKKeToan
        {
            get { return tenNhomTKKeToan; }
            set { tenNhomTKKeToan = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public bool Delete
        {
            get { return delete; }
            set { delete = value; }
        }
    }
}
