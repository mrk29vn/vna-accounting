using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Lay_ID_Top_1
    {
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }

        private string columnNameID;
        public string ColumnNameID
        {
            get { return columnNameID; }
            set { columnNameID = value; }
        }

        public Lay_ID_Top_1(string hanhdong, string columnNameID)
        {
            this.columnNameID = columnNameID;
            this.hanhdong = hanhdong;
        }
        public Lay_ID_Top_1(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public Lay_ID_Top_1() { }
    }
}
