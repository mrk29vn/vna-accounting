using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhomQuyen
    {
        private int nhomQuyenID;
        private string tenNhomQuyen;
        private bool isdeleted;
        public string MaNhanVien="";
        public string TenDangNhap="";
        
        public NhomQuyen()
        { }
        public NhomQuyen(string tenNhomQuyen){ this.tenNhomQuyen = tenNhomQuyen; }
        public NhomQuyen(int nhomQuyenID, string tenNhomQuyen,bool isdelete)
        {
            this.nhomQuyenID = nhomQuyenID;
            this.tenNhomQuyen = tenNhomQuyen;
            this.isdeleted = isdelete;
        }
        public int NhomQuyenID
        {
            get { return this.nhomQuyenID; }
            set
            {
                this.nhomQuyenID = value;
            }
        }
        public string TenNhomQuyen
        {
            get { return this.tenNhomQuyen; }
            set
            {
                this.tenNhomQuyen = value;
            }
        }
        public bool isDeleted
        {
            get { return this.isdeleted; }
            set { this.isdeleted = value; }
        }
        

    }
}
