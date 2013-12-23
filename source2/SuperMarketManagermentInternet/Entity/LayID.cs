using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class LayID
    {
        private string id;
        public string ID
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }
        private string hanhDong;
        public string HanhDong
        {
            get { return this.hanhDong; }
            set
            {
                this.hanhDong = value;
            }
        }
        private string tenBang;
        public string TenBang
        {
            get { return this.tenBang; }
            set
            {
                this.tenBang = value;
            }
        }
        public LayID() { }
        public LayID(string hanhDong, string tenBang)
        {
            this.hanhDong = hanhDong;
            this.tenBang = tenBang;
        }
    }
}
