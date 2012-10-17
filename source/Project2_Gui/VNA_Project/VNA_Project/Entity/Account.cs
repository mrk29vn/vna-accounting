using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    public class Account
    {
        public Account() { }

        string userName = string.Empty;
        string passWord = string.Empty;
        string permissionCode = string.Empty;
        string employeeCode = string.Empty;
        bool administrator = false;
        bool lockedAccount = false;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        public string PermissionCode
        {
            get { return permissionCode; }
            set { permissionCode = value; }
        }
        public string EmployeeCode
        {
            get { return employeeCode; }
            set { employeeCode = value; }
        }
        public bool Administrator
        {
            get { return administrator; }
            set { administrator = value; }
        }
        public bool LockedAccount
        {
            get { return lockedAccount; }
            set { lockedAccount = value; }
        }
    }
}
