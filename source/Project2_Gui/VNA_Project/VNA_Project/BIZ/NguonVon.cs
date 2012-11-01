using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class NguonVonBiz
    {
        public NguonVonBiz() { }

        public static List<NguonVon> getListNguonVon()
        {
            List<NguonVon> kq = new List<NguonVon>();
            string sql = "SELECT [MaNguonVon],[TenNguonVon] FROM  [VNAAccounting].[dbo].[NguonVon]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NguonVon temp = new NguonVon();
                temp.MaNguonVon = dt.Rows[i]["MaNguonVon"].ToString();
                temp.TenNguonVon = dt.Rows[i]["TenNguonVon"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddNguonVon(NguonVon input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[NguonVon]([MaNguonVon],[TenNguonVon]) VALUES(N'" + input.MaNguonVon.ToUpper() + "',N'" + input.TenNguonVon + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditNguonVon(NguonVon input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[NguonVon] SET TenNguonVon = N'" + input.TenNguonVon + "' WHERE MaNguonVon = N'" + input.MaNguonVon.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteNguonVon(NguonVon input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[NguonVon] WHERE MaNguonVon = N'" + input.MaNguonVon.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
