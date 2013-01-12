using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCTonKhoTheoKhoDGV
    {
        private string hanhDong;
        private string maKho;
        private string tenKho;
        private string diaChi;
        private string soLuong;
        public BCTonKhoTheoKhoDGV() { }
        public BCTonKhoTheoKhoDGV(string hanhDong, string maKho, string tenkho, string diaChi,string soLuong)
        {
            this.hanhDong = hanhDong;
            this.maKho = maKho;
            this.tenKho = tenkho;
            this.diaChi = diaChi;
            this.soLuong = soLuong;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set
            {
                this.maKho = value;
            }
        }
        public string TenKho
        {
            get { return this.tenKho; }
            set
            {
                this.tenKho = value;
            }
        }
        public string DiaChi
        {
            get { return this.diaChi; }
            set { this.diaChi = value; }
        }
        public string SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
    }
}
