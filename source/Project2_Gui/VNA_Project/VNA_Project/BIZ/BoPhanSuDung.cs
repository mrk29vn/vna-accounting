using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class BoPhanSuDungBiz
    {
        public BoPhanSuDungBiz() { }

        public static List<BoPhanSuDung> getListBoPhanSuDung()
        {
            List<BoPhanSuDung> kq = new List<BoPhanSuDung>();
            string sql = "SELECT [MaBoPhanSuDung],[TenBoPhanSuDung] FROM  [VNAAccounting].[dbo].[BoPhanSuDung]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BoPhanSuDung temp = new BoPhanSuDung();
                temp.MaBoPhanSuDung = dt.Rows[i]["MaBoPhanSuDung"].ToString();
                temp.TenBoPhanSuDung = dt.Rows[i]["TenBoPhanSuDung"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddBoPhanSuDung(BoPhanSuDung input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[BoPhanSuDung]([MaBoPhanSuDung],[TenBoPhanSuDung]) VALUES(N'" + input.MaBoPhanSuDung.ToUpper() + "',N'" + input.TenBoPhanSuDung + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditBoPhanSuDung(BoPhanSuDung input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[BoPhanSuDung] SET TenBoPhanSuDung = N'" + input.TenBoPhanSuDung + "' WHERE MaBoPhanSuDung = N'" + input.MaBoPhanSuDung.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteBoPhanSuDung(BoPhanSuDung input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[BoPhanSuDung] WHERE MaBoPhanSuDung = N'" + input.MaBoPhanSuDung.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
