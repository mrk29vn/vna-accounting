using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class LyDoTangGiamTaiSanBiz
    {
        public LyDoTangGiamTaiSanBiz() { }

        public static List<LyDoTangGiamTaiSan> getListLyDoTangGiamTaiSan()
        {
            List<LyDoTangGiamTaiSan> kq = new List<LyDoTangGiamTaiSan>();
            string sql = "SELECT [LoaiTangGiamTaiSan],[MaLyDoTangGiamTaiSan],[TenLyDoTangGiamTaiSan] FROM  [VNAAccounting].[dbo].[LyDoTangGiamTaiSan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LyDoTangGiamTaiSan temp = new LyDoTangGiamTaiSan();
                temp.LoaiTangGiamTaiSan = bool.Parse(dt.Rows[i]["LoaiTangGiamTaiSan"].ToString());
                temp.LoaiTangGiamTaiSanVIEW = temp.LoaiTangGiamTaiSan ? "1" : "2";
                temp.MaLyDoTangGiamTaiSan = dt.Rows[i]["MaLyDoTangGiamTaiSan"].ToString();
                temp.TenLyDoTangGiamTaiSan = dt.Rows[i]["TenLyDoTangGiamTaiSan"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddLyDoTangGiamTaiSan(LyDoTangGiamTaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[LyDoTangGiamTaiSan]([LoaiTangGiamTaiSan],[MaLyDoTangGiamTaiSan],[TenLyDoTangGiamTaiSan]) VALUES(" + (input.LoaiTangGiamTaiSan ? "1" : "0") + ",N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "',N'" + input.TenLyDoTangGiamTaiSan + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditLyDoTangGiamTaiSan(LyDoTangGiamTaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[LyDoTangGiamTaiSan] SET LoaiTangGiamTaiSan = " + (input.LoaiTangGiamTaiSan ? "1" : "0") + ", TenLyDoTangGiamTaiSan = N'" + input.TenLyDoTangGiamTaiSan + "' WHERE MaLyDoTangGiamTaiSan = N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteLyDoTangGiamTaiSan(LyDoTangGiamTaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[LyDoTangGiamTaiSan] WHERE MaLyDoTangGiamTaiSan = N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        //Lấy danh sách Lý do tăng giảm tài sản theo mã
        public static List<LyDoTangGiamTaiSan> getListLyDoTangGiamTaiSan(string MaLyDoTangGiamTaiSan)
        {
            List<LyDoTangGiamTaiSan> kq = new List<LyDoTangGiamTaiSan>();
            string sql = "SELECT [LoaiTangGiamTaiSan],[MaLyDoTangGiamTaiSan],[TenLyDoTangGiamTaiSan] FROM [VNAAccounting].[dbo].[LyDoTangGiamTaiSan] WHERE MaLyDoTangGiamTaiSan = N'" + MaLyDoTangGiamTaiSan.ToUpper() + "'";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LyDoTangGiamTaiSan temp = new LyDoTangGiamTaiSan();
                temp.LoaiTangGiamTaiSan = bool.Parse(dt.Rows[i]["LoaiTangGiamTaiSan"].ToString());
                temp.LoaiTangGiamTaiSanVIEW = temp.LoaiTangGiamTaiSan ? "1" : "2";
                temp.MaLyDoTangGiamTaiSan = dt.Rows[i]["MaLyDoTangGiamTaiSan"].ToString();
                temp.TenLyDoTangGiamTaiSan = dt.Rows[i]["TenLyDoTangGiamTaiSan"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
    }
}
