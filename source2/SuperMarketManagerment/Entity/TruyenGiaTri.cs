using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class TruyenGiaTri
    {
        private string hanhdong;
        private DateTime date;

        DateTime giatritruyenTU;

        public DateTime GiatritruyenTU
        {
            get { return giatritruyenTU; }
            set { giatritruyenTU = value; }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
         private string giatritruyen;

         public string Giatritruyen
         {
             get { return giatritruyen; }
             set { giatritruyen = value; }
         }
         private string giatrithuhai;

         public string Giatrithuhai
         {
             get { return giatrithuhai; }
             set { giatrithuhai = value; }
         }

         private string giatriba;

         public string Giatriba
         {
             get { return giatriba; }
             set { giatriba = value; }
         }
         public TruyenGiaTri() { }
         public TruyenGiaTri(string hanhdong)
         {
             this.hanhdong = hanhdong;
         }
         public TruyenGiaTri(string hanhdong, string giatritruyen)
         {
             this.hanhdong = hanhdong;
             this.giatritruyen = giatritruyen;
         }
         public TruyenGiaTri(string hanhdong, DateTime giatritruyenTU)
         {
             this.hanhdong = hanhdong;
             this.giatritruyenTU = giatritruyenTU;
         }
         public TruyenGiaTri(string hanhdong, string giatritruyen, string giatrithuhai)
         {
             this.hanhdong = hanhdong;
             this.giatritruyen = giatritruyen;
             this.giatrithuhai = giatrithuhai;
         }
         public TruyenGiaTri(string hanhdong, DateTime giatritruyenTU, string giatrithuhai)
         {
             this.hanhdong = hanhdong;
             this.giatritruyenTU = giatritruyenTU;
             this.giatrithuhai = giatrithuhai;
         }
         //public TruyenGiaTri(string hanhdong, string giatritruyen,string giatrithuhai)
         //{
         //    this.hanhdong = hanhdong;
         //    this.giatritruyen = giatritruyen;
         //    this.giatrithuhai = giatrithuhai;
         //}
         public TruyenGiaTri(string hanhdong, string giatritruyen, string giatrithuhai,string giatriba)
         {
             this.hanhdong = hanhdong;
             this.giatritruyen = giatritruyen;
             this.giatrithuhai = giatrithuhai;
             this.giatriba = giatriba;
         }
         public TruyenGiaTri(string hanhdong, DateTime giatritruyenTU, string giatrithuhai, string giatriba)
         {
             this.hanhdong = hanhdong;
             this.giatritruyenTU = giatritruyenTU;
             this.giatrithuhai = giatrithuhai;
             this.giatriba = giatriba;
         }
    }
}
