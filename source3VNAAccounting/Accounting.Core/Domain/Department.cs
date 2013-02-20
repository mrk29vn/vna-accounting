using System;

namespace Accounting.Core.Domain
{
    public class Department
    {
        int departmentID = 0;
        string codeDepartment = string.Empty;
        string nameDepartment = string.Empty;
        string interpretation = string.Empty;
        string wageCostsAccount = string.Empty;
        bool stopFollowing = false;

        public virtual int DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }
        public virtual string CodeDepartment
        {
            get { return codeDepartment; }
            set { codeDepartment = value; }
        }
        public virtual string NameDepartment
        {
            get { return nameDepartment; }
            set { nameDepartment = value; }
        }
        public virtual string Interpretation
        {
            get { return interpretation; }
            set { interpretation = value; }
        }
        public virtual string WageCostsAccount
        {
            get { return wageCostsAccount; }
            set { wageCostsAccount = value; }
        }
        public virtual bool StopFollowing
        {
            get { return stopFollowing; }
            set { stopFollowing = value; }
        }
    }
}
