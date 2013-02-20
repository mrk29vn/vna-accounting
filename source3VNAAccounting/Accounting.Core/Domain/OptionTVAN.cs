using System;

namespace Accounting.Core.Domain
{
    public class OptionTVAN
    {
        private int _ID;
        private string _Name;
        private int _Status;
        private string _Description;

        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public virtual string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public virtual int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public virtual string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


    }
}
