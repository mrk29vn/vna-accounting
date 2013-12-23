using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
      [Serializable]
    public class ThongTinKiemKeKho
    {
        private string mahang;
        private string tenhang;
        private string tonsosach;
        private string tonthucte;
        private string chenhlech;
        private string lydo;
        private string giavon;
        private string giachechlech;
          public string Mahang
          {
              get { return mahang; }
              set { mahang = value; }
          }
          public string Tenhang
          {
              get { return tenhang; }
              set { tenhang = value; }
          }
          public string Tonsosach
          {
              get { return tonsosach; }
              set { tonsosach = value; }
          }
          public string Tonthucte
          {
              get { return tonthucte; }
              set { tonthucte = value; }
          }
          public string Chenhlech
          {
              get { return chenhlech; }
              set { chenhlech = value; }
          }
          public string Lydo
          {
              get { return lydo; }
              set { lydo = value; }
          }
          public string Giavon
          {
              get { return giavon; }
              set { giavon = value; }
          }
          public string Giachechlech
          {
              get { return giachechlech; }
              set { giachechlech = value; }
          }
          public ThongTinKiemKeKho() { }
          public ThongTinKiemKeKho(string mahang, string tenhang, string tonsosach, string tonthucte, string chenhlech, string lydo, string giavon, string giachechlech, string Mahang) 
          {
              this.mahang = mahang;
              this.tenhang = tenhang;
              this.tonsosach = tonsosach;
              this.tonthucte = tonthucte;
              this.chenhlech = chenhlech;
              this.lydo = lydo;
              this.giavon = giavon;
              this.giachechlech = giachechlech;
              this.mahang = mahang;
          }
    }
}
