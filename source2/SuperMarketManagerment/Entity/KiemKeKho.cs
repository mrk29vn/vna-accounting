using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KiemKeKho
    {
        #region hungvv===========================================================================================================
        private string hanhdong;
        private int phieuKiemKeKhoID;
        private string maKiemKe;
        private DateTime ngayKiemKe;
        private string maKho;
        private string tenkho;
        private string ghiChu;
        private Boolean deleted;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int PhieuKiemKeKhoID
        {
            get { return this.phieuKiemKeKhoID; }
            set
            {
                this.phieuKiemKeKhoID = value;
            }
        }
        public string MaKiemKe
        {
            get { return this.maKiemKe; }
            set
            {
                this.maKiemKe = value;
            }
        }
        public DateTime NgayKiemKe
        {
            get { return this.ngayKiemKe; }
            set { this.ngayKiemKe = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public string Tenkho
        {
            get { return tenkho; }
            set { tenkho = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

        public KiemKeKho() { }

        public KiemKeKho(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        private string manhanvien;
        private string tendangnhap;
        public string Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }
        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }

        public KiemKeKho(string hanhdong, string maKiemKe)
        {
            this.hanhdong = hanhdong;
            this.maKiemKe = maKiemKe;
        }

        public KiemKeKho(string hanhdong, string maKiemKe, DateTime ngayKiemKe, string maKho,string tenkho, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maKiemKe = maKiemKe;
            this.ngayKiemKe = ngayKiemKe;
            this.maKho = maKho;
            this.tenkho = tenkho;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        #endregion
    }
}
