using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinKhachHang
    {
        private string hanhdong;
        private string makhachhang;
        private string tenkhachhang;
        private string diachi;
        private string duno;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public string Makhachhang
        {
            get { return makhachhang; }
            set { makhachhang = value; }
        }
        public string Tenkhachhang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string Duno
        {
            get { return duno; }
            set { duno = value; }
        }
       
        public ThongTinKhachHang() { }
        public ThongTinKhachHang(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ThongTinKhachHang(string hanhdong, string makhachhang, string tenkhachhang)
        {
            this.hanhdong = hanhdong;
            this.makhachhang = makhachhang;
            this.tenkhachhang = tenkhachhang;
        }
        public ThongTinKhachHang(string hanhdong, string makhachhang, string tenkhachhang,string diachi,string duno)
        {
            this.hanhdong = hanhdong;
            this.makhachhang = makhachhang;
            this.tenkhachhang = tenkhachhang;
            this.diachi = diachi;
            this.duno = duno;
        }
    }
}
