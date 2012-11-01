using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class ThietBiBiz
    {
        public ThietBiBiz() { }

        public static List<ThietBi> getListThietBi()
        {
            List<ThietBi> kq = new List<ThietBi>();
            string sql = "SELECT [MaThietBi],[TenThietBi] FROM  [VNAAccounting].[dbo].[ThietBi]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThietBi temp = new ThietBi();
                temp.MaThietBi = dt.Rows[i]["MaThietBi"].ToString();
                temp.TenThietBi = dt.Rows[i]["TenThietBi"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddThietBi(ThietBi input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[ThietBi]([MaThietBi],[TenThietBi]) VALUES(N'" + input.MaThietBi.ToUpper() + "',N'" + input.TenThietBi + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditThietBi(ThietBi input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[ThietBi] SET TenThietBi = N'" + input.TenThietBi + "' WHERE MaThietBi = N'" + input.MaThietBi.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteThietBi(ThietBi input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[ThietBi] WHERE MaThietBi = N'" + input.MaThietBi.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
