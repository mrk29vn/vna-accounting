using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class PhuTungKemTheoBiz
    {
        public PhuTungKemTheoBiz() { }

        public static List<PhuTungKemTheo> getListPhuTungKemTheo()
        {
            List<PhuTungKemTheo> kq = new List<PhuTungKemTheo>();
            string sql = "SELECT [MaTaiSan],[MaPhuTungKemTheo],[TenPhuTungKemTheo],[DVT],[SoLuong],[GiaTri],[GhiChu] FROM [VNAAccounting].[dbo].[PhuTungKemTheo]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhuTungKemTheo temp = new PhuTungKemTheo();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.MaPhuTungKemTheo = dt.Rows[i]["MaPhuTungKemTheo"].ToString();
                temp.TenPhuTungKemTheo = dt.Rows[i]["TenPhuTungKemTheo"].ToString();
                temp.DVT = dt.Rows[i]["DVT"].ToString();
                temp.SoLuong = double.Parse(dt.Rows[i]["SoLuong"].ToString());
                temp.GiaTri = double.Parse(dt.Rows[i]["GiaTri"].ToString());
                temp.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
        public static List<PhuTungKemTheo> getListPhuTungKemTheo(string MaTaiSan)
        {
            List<PhuTungKemTheo> kq = new List<PhuTungKemTheo>();
            string sql = "SELECT [MaTaiSan],[MaPhuTungKemTheo],[TenPhuTungKemTheo],[DVT],[SoLuong],[GiaTri],[GhiChu] FROM [VNAAccounting].[dbo].[PhuTungKemTheo] WHERE MaTaiSan=N'" + MaTaiSan.ToUpper() + "'";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhuTungKemTheo temp = new PhuTungKemTheo();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.MaPhuTungKemTheo = dt.Rows[i]["MaPhuTungKemTheo"].ToString();
                temp.TenPhuTungKemTheo = dt.Rows[i]["TenPhuTungKemTheo"].ToString();
                temp.DVT = dt.Rows[i]["DVT"].ToString();
                temp.SoLuong = double.Parse(dt.Rows[i]["SoLuong"].ToString());
                temp.GiaTri = double.Parse(dt.Rows[i]["GiaTri"].ToString());
                temp.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddPhuTungKemTheo(PhuTungKemTheo input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[PhuTungKemTheo]([MaTaiSan],[MaPhuTungKemTheo],[TenPhuTungKemTheo],[DVT],[SoLuong],[GiaTri],[GhiChu]) VALUES(N'" + input.MaTaiSan.ToUpper() + "',N'" + input.MaPhuTungKemTheo.ToUpper() + "',N'" + input.TenPhuTungKemTheo + "',N'" + input.DVT + "'," + input.SoLuong + "," + input.GiaTri + ",N'" + input.GhiChu + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditPhuTungKemTheo(PhuTungKemTheo input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[PhuTungKemTheo] SET TenPhuTungKemTheo = N'" + input.TenPhuTungKemTheo + "',DVT = N'" + input.DVT + "',SoLuong = " + input.SoLuong + ",GiaTri = " + input.GiaTri + ",GhiChu = N'" + input.GhiChu + "' WHERE (MaPhuTungKemTheo = N'" + input.MaPhuTungKemTheo.ToUpper() + "') AND (MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeletePhuTungKemTheo(PhuTungKemTheo input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[PhuTungKemTheo] WHERE (MaPhuTungKemTheo = N'" + input.MaPhuTungKemTheo.ToUpper() + "') AND (MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
