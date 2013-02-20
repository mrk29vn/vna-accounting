using System;

namespace IdentityManagement.Domain
{
    public class UserProfile
    {
        private int _ProfileID;
        private int _UserId;
        private string _PropertyName;
        private string _PropertyValuesString;
        private byte[] _PropertyValuesBinary;
        private DateTime _LastUpdateDate = DateTime.Now ;

        public virtual int ProfileID
        {
            get { return _ProfileID; }
            set { _ProfileID = value; }
        }
        public virtual int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public virtual string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; }
        }

        public virtual string PropertyValuesString
        {
            get { return _PropertyValuesString; }
            set { _PropertyValuesString = value; }
        }

        public virtual byte[] PropertyValuesBinary
        {
            get { return _PropertyValuesBinary; }
            set { _PropertyValuesBinary = value; }
        }

        public virtual DateTime LastUpdateDate
        {
            get { return _LastUpdateDate; }
            set { _LastUpdateDate = value; }
        }

        public UserProfile(string _PropertyName, object _PropertyValues)
        {
            PropertyName = _PropertyName;
            if (_PropertyValues is byte[])
            {
                PropertyValuesBinary = _PropertyValues as byte[];
            }
            else PropertyValuesString = _PropertyValues.ToString();
        }

        public UserProfile()
        { }

    }
}
