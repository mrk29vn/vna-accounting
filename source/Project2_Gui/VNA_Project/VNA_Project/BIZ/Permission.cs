using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class PermissionBiz
    {
        public PermissionBiz() { }

        public static List<Permission> getListPermission()
        {
            List<Permission> kq = new List<Permission>();
            string sql = "SELECT [PermissionCode],[PermissionName] FROM  [VNAAccounting].[dbo].[Permission]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Permission temp = new Permission();
                temp.PermissionCode = dt.Rows[i]["PermissionCode"].ToString();
                temp.PermissionName = dt.Rows[i]["PermissionName"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
    }
}
