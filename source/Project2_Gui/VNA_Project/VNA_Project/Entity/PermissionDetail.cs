using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class PermissionDetail
    {
        public PermissionDetail() { }

        string permissionCode = string.Empty;
        string formCode = string.Empty;
        string formName = string.Empty;
        bool perView = false;

        public string PermissionCode
        {
            get { return permissionCode; }
            set { permissionCode = value; }
        }
        public string FormCode
        {
            get { return formCode; }
            set { formCode = value; }
        }
        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }
        public bool PerView
        {
            get { return perView; }
            set { perView = value; }
        }

        public PermissionDetail Copy()
        {
            PermissionDetail kq = new PermissionDetail();
            kq.PermissionCode = permissionCode;
            kq.FormCode = formCode;
            kq.FormName = formName;
            kq.PerView = perView;
            return kq;
        }
    }
}
