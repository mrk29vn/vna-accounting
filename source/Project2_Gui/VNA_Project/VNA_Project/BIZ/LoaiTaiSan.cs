using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class LoaiTaiSanBiz
    {
        public LoaiTaiSanBiz() { }

        public static List<LoaiTaiSan> getListLoaiTaiSan()
        {
            List<LoaiTaiSan> kq = new List<LoaiTaiSan>();
            string sql = "SELECT [MaLoaiTaiSan],[TenLoaiTaiSan] FROM  [VNAAccounting].[dbo].[LoaiTaiSan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiTaiSan temp = new LoaiTaiSan();
                temp.MaLoaiTaiSan = dt.Rows[i]["MaLoaiTaiSan"].ToString();
                temp.TenLoaiTaiSan = dt.Rows[i]["TenLoaiTaiSan"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddLoaiTaiSan(LoaiTaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[LoaiTaiSan]([MaLoaiTaiSan],[TenLoaiTaiSan]) VALUES(N'" + input.MaLoaiTaiSan.ToUpper() + "',N'" + input.TenLoaiTaiSan + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditLoaiTaiSan(LoaiTaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[LoaiTaiSan] SET TenLoaiTaiSan = N'" + input.TenLoaiTaiSan + "' WHERE MaLoaiTaiSan = N'" + input.MaLoaiTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteLoaiTaiSan(LoaiTaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[LoaiTaiSan] WHERE MaLoaiTaiSan = N'" + input.MaLoaiTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
