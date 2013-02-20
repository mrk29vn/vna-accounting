using System;

namespace Accounting.Core.Domain
{
    public class Bank
    {
        int bankID = 0;
        string bankCode = string.Empty;
        string bankName = string.Empty;
        string bankNameEnglish = string.Empty;
        string address = string.Empty;
        string description = string.Empty;
        bool isHasServiceOnline = false;
        byte[] icon = new byte[0];
        bool inactive = false;

        public virtual int BankID
        {
            get { return bankID; }
            set { bankID = value; }
        }
        public virtual string BankCode
        {
            get { return bankCode; }
            set { bankCode = value; }
        }
        public virtual string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
        public virtual string BankNameEnglish
        {
            get { return bankNameEnglish; }
            set { bankNameEnglish = value; }
        }
        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }
        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }
        public virtual bool IsHasServiceOnline
        {
            get { return isHasServiceOnline; }
            set { isHasServiceOnline = value; }
        }
        public virtual byte[] Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        public virtual bool Inactive
        {
            get { return inactive; }
            set { inactive = value; }
        }
    }
}
