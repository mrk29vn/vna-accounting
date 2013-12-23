using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietQuyen
    {
        private string tenNhomQuyen;
        private string tenForm;
        private string ten;
        private bool quyenThem;
        private bool quyenSua;
        private bool quyenXoa;
        private bool quyenXem;
        private bool saoLuuDuLieu;
        private bool capNhatDuLieu;
        public ChiTietQuyen()
        { }
        public ChiTietQuyen(string tenNhomQuyen) { this.tenNhomQuyen = tenNhomQuyen; }
        public ChiTietQuyen(string tenNhomQuyen, string tenForm,string ten, bool quyenThem, bool quyenSua, bool quyenXoa, bool quyenXem, bool saoLuuDuLieu, bool capNhatDuLieu)
        {
            this.tenNhomQuyen = tenNhomQuyen;
            this.tenForm = tenForm;
            this.ten = ten;
            this.quyenThem = quyenThem;
            this.quyenSua = quyenSua;
            this.quyenXoa = quyenXoa;
            this.quyenXem = quyenXem;
            this.saoLuuDuLieu = saoLuuDuLieu;
            this.capNhatDuLieu = capNhatDuLieu;
        }
        public string TenNhomQuyen
        {
            get { return this.tenNhomQuyen; }
            set
            {
                this.tenNhomQuyen = value;
            }
        }
        public string TenForm
        {
            get { return this.tenForm; }
            set
            {
                this.tenForm = value;
            }
        }
        public string Ten
        {
            get { return this.ten; }
            set { this.ten = value; }
        }
        public bool QuyenThem
        {
            get { return this.quyenThem; }
            set { this.quyenThem = value; }
        }
        public bool QuyenSua
        {
            get { return this.quyenSua; }
            set { this.quyenSua = value; }
        }
        public bool QuyenXoa
        {
            get { return this.quyenXoa; }
            set { this.quyenXoa = value; }
        }
        public bool QuyenXem
        {
            get { return this.quyenXem; }
            set { this.quyenXem = value; }
        }
        public bool SaoLuuDuLieu
        {
            get { return this.saoLuuDuLieu; }
            set { this.saoLuuDuLieu = value; }
        }
        public bool CapNhatDuLieu
        {
            get { return this.capNhatDuLieu; }
            set { this.capNhatDuLieu = value; }
        }
        

    }
}
