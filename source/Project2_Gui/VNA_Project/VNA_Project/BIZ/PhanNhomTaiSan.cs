using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class PhanNhomTaiSanBiz
    {
        public PhanNhomTaiSanBiz() { }

        public static List<PhanNhomTaiSan> getListPhanNhomTaiSan()
        {
            List<PhanNhomTaiSan> kq = new List<PhanNhomTaiSan>();
            string sql = "SELECT [MaPhanNhomTaiSan],[TenPhanNhomTaiSan],[KieuPhanNhomTaiSan] FROM  [VNAAccounting].[dbo].[PhanNhomTaiSan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhanNhomTaiSan temp = new PhanNhomTaiSan();
                temp.MaPhanNhomTaiSan = dt.Rows[i]["MaPhanNhomTaiSan"].ToString();
                temp.TenPhanNhomTaiSan = dt.Rows[i]["TenPhanNhomTaiSan"].ToString();
                temp.KieuPhanNhomTaiSan = dt.Rows[i]["KieuPhanNhomTaiSan"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddPhanNhomTaiSan(PhanNhomTaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[PhanNhomTaiSan]([MaPhanNhomTaiSan],[TenPhanNhomTaiSan],[KieuPhanNhomTaiSan]) VALUES(N'" + input.MaPhanNhomTaiSan.ToUpper() + "',N'" + input.TenPhanNhomTaiSan + "',N'" + input.KieuPhanNhomTaiSan + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditPhanNhomTaiSan(PhanNhomTaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[PhanNhomTaiSan] SET TenPhanNhomTaiSan = N'" + input.TenPhanNhomTaiSan + "', KieuPhanNhomTaiSan = N'" + input.KieuPhanNhomTaiSan + "' WHERE MaPhanNhomTaiSan = N'" + input.MaPhanNhomTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeletePhanNhomTaiSan(PhanNhomTaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[PhanNhomTaiSan] WHERE MaPhanNhomTaiSan = N'" + input.MaPhanNhomTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
