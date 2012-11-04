using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class PhanXuongBiz
    {
        public PhanXuongBiz() { }

        public static List<PhanXuong> getListPhanXuong()
        {
            List<PhanXuong> kq = new List<PhanXuong>();
            string sql = "SELECT [MaPhanXuong],[TenPhanXuong] FROM  [VNAAccounting].[dbo].[PhanXuong]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhanXuong temp = new PhanXuong();
                temp.MaPhanXuong = dt.Rows[i]["MaPhanXuong"].ToString();
                temp.TenPhanXuong = dt.Rows[i]["TenPhanXuong"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddPhanXuong(PhanXuong input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[PhanXuong]([MaPhanXuong],[TenPhanXuong]) VALUES(N'" + input.MaPhanXuong.ToUpper() + "',N'" + input.TenPhanXuong + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditPhanXuong(PhanXuong input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[PhanXuong] SET TenPhanXuong = N'" + input.TenPhanXuong + "' WHERE MaPhanXuong = N'" + input.MaPhanXuong.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeletePhanXuong(PhanXuong input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[PhanXuong] WHERE MaPhanXuong = N'" + input.MaPhanXuong.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
