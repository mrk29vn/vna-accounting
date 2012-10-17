using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    public class Permission
    {
        public Permission() { }

        string permissionCode = string.Empty;
        string permissionName = string.Empty;

        public string PermissionCode
        {
            get { return permissionCode; }
            set { permissionCode = value; }
        }
        public string PermissionName
        {
            get { return permissionName; }
            set { permissionName = value; }
        }
    }
}
