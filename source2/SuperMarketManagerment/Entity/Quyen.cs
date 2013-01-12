using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    class Quyen
    {
        private int quyenID;
        private string tenForm;
        private string ten;
        public Quyen()
        { }
        public Quyen(int quyenID, string tenForm,string ten)
        {
            this.quyenID = quyenID;
            this.tenForm = tenForm;
            this.ten = ten;
        }
        public int QuyenID
        {
            get { return this.quyenID; }
            set
            {

                this.quyenID = value;
            }
        }
        public string TenForm
        {
            get { return this.tenForm; }
            set
            {

                this.tenForm = value;
            }
        }
        public string Ten
        {
            get { return this.ten; }
            set
            {

                this.ten = value;
            }
        }

    }
}
