using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class MaVachThe
    {
        private string tenCongTy;
        private string tenThe;
        private string maKH;
        private string tenKH;
        private string maThe;
        private string ngayKetThuc;
        private string ngayBatDau;
        private byte[] maVach;
        private double giaTriThe;

        public string TenCongTy
        {
            get { return tenCongTy; }
            set { tenCongTy = value; }
        }


        public string TenThe
        {
            get { return tenThe; }
            set { tenThe = value; }
        }


        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }


        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }


        public string NgayBatDau
        {
            get { return ngayBatDau; }
            set { ngayBatDau = value; }
        }

        public string NgayKetThuc
        {
            get { return ngayKetThuc; }
            set { ngayKetThuc = value; }
        }

        public string MaThe
        {
            get { return maThe; }
            set { maThe = value; }
        }


        public byte[] MaVach
        {
            get { return maVach; }
            set { maVach = value; }
        }


        public double GiaTriThe
        {
            get { return giaTriThe; }
            set { giaTriThe = value; }
        }
    }
}
