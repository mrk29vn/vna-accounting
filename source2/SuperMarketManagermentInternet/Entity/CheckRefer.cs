using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class CheckRefer
    {
        string tenTruong;
        string maTruong;

        public CheckRefer() { }
        public CheckRefer(string tenTruong)
        {
            this.tenTruong = tenTruong;
        }
        public CheckRefer(string tenTruong, string maTruong)
        {
            this.tenTruong = tenTruong;
            this.maTruong = maTruong;
        }
        public string TenTruong
        {
            get { return tenTruong; }
            set { tenTruong = value; }
        }
        public string MaTruong
        {
            get { return maTruong; }
            set { maTruong = value; }
        }
            
    }
}
