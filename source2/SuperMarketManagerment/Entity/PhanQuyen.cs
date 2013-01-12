using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhanQuyen
    {
        private int nhomQuyenID;
        private int chiTietQuyenID;
        private string quyenThem;
        private string quyenSua;
        private string quyenXoa;
        private string quyenXem;
        private string saoLuuDuLieu;
        private string capNhatDuLieu;
        public PhanQuyen()
        { }
        public PhanQuyen(int nhomQuyenID, int chiTietQuyenID, string quyenThem, string quyenSua, string quyenXoa, string quyenXem, string saoLuuDuLieu, string capNhatDuLieu)
        {
            this.nhomQuyenID = nhomQuyenID;
            this.chiTietQuyenID = chiTietQuyenID;
            this.quyenThem = quyenThem;
            this.quyenSua = quyenSua;
            this.quyenXoa = quyenXoa;
            this.quyenXem = quyenXem;
            this.saoLuuDuLieu = saoLuuDuLieu;
            this.capNhatDuLieu = capNhatDuLieu;
        }

        public int NhomQuyenID
        {
            get { return this.nhomQuyenID; }
            set
            {
                this.nhomQuyenID = value;
            }
        }
        public int ChiTietQuyenID
        {
            get { return this.chiTietQuyenID; }
            set
            {
                this.chiTietQuyenID = value;
            }
        }
        public string QuyenThem
        {
            get { return this.quyenThem; }
            set { this.quyenThem = value; }
        }
        public string QuyenSua
        {
            get { return this.quyenSua; }
            set { this.quyenSua = value; }
        }
        public string QuyenXoa
        {
            get { return this.quyenXoa; }
            set { this.quyenXoa = value; }
        }
        public string QuyenXem
        {
            get { return this.quyenXem; }
            set { this.quyenXem = value; }
        }
        public string SaoLuuDuLieu
        {
            get { return this.saoLuuDuLieu; }
            set { this.saoLuuDuLieu = value; }
        }
        public string CapNhatDuLieu
        {
            get { return this.capNhatDuLieu; }
            set { this.capNhatDuLieu = value; }
        }
	
    }
}
