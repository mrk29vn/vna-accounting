using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class PermissionDetailBiz
    {
        public PermissionDetailBiz() { }

        public static List<PermissionDetail> getListPermissionDetail()
        {
            List<PermissionDetail> kq = new List<PermissionDetail>();
            string sql = "SELECT [PermissionCode],[FormCode],[FormName],[PerView] FROM  [VNAAccounting].[dbo].[PermissionDetail]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PermissionDetail temp = new PermissionDetail();
                temp.PermissionCode = dt.Rows[i]["PermissionCode"].ToString();
                temp.FormCode = dt.Rows[i]["FormCode"].ToString();
                temp.FormName = dt.Rows[i]["FormName"].ToString();
                temp.PerView = bool.Parse(dt.Rows[i]["PerView"].ToString());
                kq.Add(temp);
            }
            return kq;
        }
    }
}
