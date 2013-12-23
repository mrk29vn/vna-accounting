using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class SaoLuuHeThong
    {
        private string name;
        private string thoiGian;
        private long dungLuong;
        public string TenDangNhap;
        public string MaNhanVien;
        
        public SaoLuuHeThong() { }
        public SaoLuuHeThong(string name,string thoiGian, long dungLuong)
        {
            this.name = name;
            this.thoiGian = thoiGian;
            this.dungLuong = dungLuong;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string ThoiGian
        {
            get { return this.thoiGian; }
            set { this.thoiGian = value; }
        }
        public long DungLuong
        {
            get { return this.dungLuong; }
            set { this.dungLuong = value; }
        }
        
    }
}
