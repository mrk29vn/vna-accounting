using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class ThoiKhauHaoTaiSan
    {
        public ThoiKhauHaoTaiSan() { }

        int thoiKhauHaoTaiSanID = 0;
        string maThoiKhauHaoTaiSan = string.Empty;
        string maTaiSan = string.Empty;
        DateTime ngayThoiKhauHao = new DateTime(1753, 1, 1);

        public int ThoiKhauHaoTaiSanID
        {
            get { return thoiKhauHaoTaiSanID; }
            set { thoiKhauHaoTaiSanID = value; }
        }
        public string MaThoiKhauHaoTaiSan
        {
            get { return maThoiKhauHaoTaiSan; }
            set { maThoiKhauHaoTaiSan = value; }
        }
        public string MaTaiSan
        {
            get { return maTaiSan; }
            set { maTaiSan = value; }
        }
        public DateTime NgayThoiKhauHao
        {
            get { return ngayThoiKhauHao; }
            set { ngayThoiKhauHao = value; }
        }

        public ThoiKhauHaoTaiSan Copy()
        {
            ThoiKhauHaoTaiSan kq = new ThoiKhauHaoTaiSan();
            kq.ThoiKhauHaoTaiSanID = thoiKhauHaoTaiSanID;
            kq.MaThoiKhauHaoTaiSan = maThoiKhauHaoTaiSan;
            kq.MaTaiSan = maTaiSan;
            kq.NgayThoiKhauHao = ngayThoiKhauHao;
            return kq;
        }
    }
}
