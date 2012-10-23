using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;
//using VNA_Project.DAL;
using System.Data;

namespace VNA_Project.BIZ
{
    public class AccountBiz
    {
        public AccountBiz() { }

        public static List<Account> getListAccount()
        {
            List<Account> kq = new List<Account>();
            string sql = "SELECT [UserName],[PassWord],[PermissionCode],[EmployeeCode],[Administrator],[LockedAccount]  FROM  [VNAAccounting].[dbo].[Account]";
            DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Account temp = new Account();
                temp.UserName = dt.Rows[i]["UserName"].ToString();
                temp.PassWord = dt.Rows[i]["PassWord"].ToString();
                temp.PermissionCode = dt.Rows[i]["PermissionCode"].ToString();
                temp.EmployeeCode = dt.Rows[i]["EmployeeCode"].ToString();
                temp.Administrator = bool.Parse(dt.Rows[i]["Administrator"].ToString());
                temp.LockedAccount = bool.Parse(dt.Rows[i]["LockedAccount"].ToString());
                kq.Add(temp);
            }
            return kq;
        }
    }
}
