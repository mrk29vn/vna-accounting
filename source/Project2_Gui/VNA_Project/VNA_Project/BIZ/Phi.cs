using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class PhiBiz
    {
        public PhiBiz() { }

        public static List<Phi> getListPhi()
        {
            List<Phi> kq = new List<Phi>();
            string sql = "SELECT [MaPhi],[TenPhi] FROM  [VNAAccounting].[dbo].[Phi]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Phi temp = new Phi();
                temp.MaPhi = dt.Rows[i]["MaPhi"].ToString();
                temp.TenPhi = dt.Rows[i]["TenPhi"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddPhi(Phi input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[Phi]([MaPhi],[TenPhi]) VALUES(N'" + input.MaPhi.ToUpper() + "',N'" + input.TenPhi + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditPhi(Phi input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[Phi] SET TenPhi = N'" + input.TenPhi + "' WHERE MaPhi = N'" + input.MaPhi.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeletePhi(Phi input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[Phi] WHERE MaPhi = N'" + input.MaPhi.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
