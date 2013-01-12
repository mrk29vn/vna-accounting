using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public  class TenChungTu
    {
        private string tenCT;
        private string kyHieu;
        public string TenCT
        {
            get { return tenCT; }
            set { tenCT = value; }
        }
        public string KyHieu
        {
            get { return this.kyHieu; }
            set { this.kyHieu = value; }
        }
        public TenChungTu(string tenCT, string kyHieu)
        {
            this.tenCT = tenCT;
            this.kyHieu = kyHieu;
        }
    }
}
