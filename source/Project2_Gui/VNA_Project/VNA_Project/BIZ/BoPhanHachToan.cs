using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class BoPhanHachToanBiz
    {
        public BoPhanHachToanBiz() { }

        public static List<BoPhanHachToan> getListBoPhanHachToan()
        {
            List<BoPhanHachToan> kq = new List<BoPhanHachToan>();
            string sql = "SELECT [MaBoPhanHachToan],[TenBoPhanHachToan] FROM  [VNAAccounting].[dbo].[BoPhanHachToan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BoPhanHachToan temp = new BoPhanHachToan();
                temp.MaBoPhanHachToan = dt.Rows[i]["MaBoPhanHachToan"].ToString();
                temp.TenBoPhanHachToan = dt.Rows[i]["TenBoPhanHachToan"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddBoPhanHachToan(BoPhanHachToan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[BoPhanHachToan]([MaBoPhanHachToan],[TenBoPhanHachToan]) VALUES(N'" + input.MaBoPhanHachToan.ToUpper() + "',N'" + input.TenBoPhanHachToan + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditBoPhanHachToan(BoPhanHachToan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[BoPhanHachToan] SET TenBoPhanHachToan = N'" + input.TenBoPhanHachToan + "' WHERE MaBoPhanHachToan = N'" + input.MaBoPhanHachToan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteBoPhanHachToan(BoPhanHachToan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[BoPhanHachToan] WHERE MaBoPhanHachToan = N'" + input.MaBoPhanHachToan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
