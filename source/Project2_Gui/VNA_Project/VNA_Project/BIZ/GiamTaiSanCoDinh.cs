using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class GiamTaiSanCoDinhBiz
    {
        public GiamTaiSanCoDinhBiz() { }

        public static List<GiamTaiSanCoDinh> getListGiamTaiSanCoDinh()
        {
            return getListGiamTaiSanCoDinh(string.Empty, 0);
        }
        public static List<GiamTaiSanCoDinh> getListGiamTaiSanCoDinh(string MaTaiSan)
        {
            return getListGiamTaiSanCoDinh(MaTaiSan, 1);
        }
        public static List<GiamTaiSanCoDinh> getListGiamTaiSanCoDinh(string MaTaiSan, int select)
        {
            List<GiamTaiSanCoDinh> kq = new List<GiamTaiSanCoDinh>();
            string sql = string.Empty;
            if (select == 0) sql = "SELECT [GiamTaiSanCoDinhID],[MaGiamTaiSanCoDinh],[MaTaiSan],[MaLyDoTangGiamTaiSan],[NgayGiam],[NgayKetThucKhauHao],[SoChungTu],[LyDo] FROM [VNAAccounting].[dbo].[GiamTaiSanCoDinh]";
            else if (select == 1) sql = "SELECT [GiamTaiSanCoDinhID],[MaGiamTaiSanCoDinh],[MaTaiSan],[MaLyDoTangGiamTaiSan],[NgayGiam],[NgayKetThucKhauHao],[SoChungTu],[LyDo] FROM [VNAAccounting].[dbo].[GiamTaiSanCoDinh] WHERE MaTaiSan = '" + MaTaiSan + "'";

            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GiamTaiSanCoDinh temp = new GiamTaiSanCoDinh();
                temp.GiamTaiSanCoDinhID = int.Parse(dt.Rows[i]["GiamTaiSanCoDinhID"].ToString());
                temp.MaGiamTaiSanCoDinh = dt.Rows[i]["MaGiamTaiSanCoDinh"].ToString();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.MaLyDoTangGiamTaiSan = dt.Rows[i]["MaLyDoTangGiamTaiSan"].ToString();
                temp.NgayGiam = DateTime.Parse(dt.Rows[i]["NgayGiam"].ToString());
                temp.NgayKetThucKhauHao = DateTime.Parse(dt.Rows[i]["NgayKetThucKhauHao"].ToString());
                temp.SoChungTu = dt.Rows[i]["SoChungTu"].ToString();
                temp.LyDo = dt.Rows[i]["LyDo"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddGiamTaiSanCoDinh(GiamTaiSanCoDinh input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[GiamTaiSanCoDinh]([MaGiamTaiSanCoDinh],[MaTaiSan],[MaLyDoTangGiamTaiSan],[NgayGiam],[NgayKetThucKhauHao],[SoChungTu],[LyDo]) VALUES(N'" + input.MaGiamTaiSanCoDinh.ToUpper() + "',N'" + input.MaTaiSan.ToUpper() + "',N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "','" + input.NgayGiam.ToString("MM/dd/yyyy") + "','" + input.NgayKetThucKhauHao.ToString("MM/dd/yyyy") + "',N'" + input.SoChungTu + "',N'" + input.LyDo + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditGiamTaiSanCoDinh(GiamTaiSanCoDinh input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[GiamTaiSanCoDinh] SET MaGiamTaiSanCoDinh =N'" + input.MaGiamTaiSanCoDinh.ToUpper() + "',MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "',MaLyDoTangGiamTaiSan = N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "',NgayGiam = '" + input.NgayGiam.ToString("MM/dd/yyyy") + "',NgayKetThucKhauHao = '" + input.NgayKetThucKhauHao.ToString("MM/dd/yyyy") + "',SoChungTu = N'" + input.SoChungTu + "',LyDo = N'" + input.LyDo + "' WHERE GiamTaiSanCoDinhID = '" + input.GiamTaiSanCoDinhID + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteGiamTaiSanCoDinh(GiamTaiSanCoDinh input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[GiamTaiSanCoDinh] WHERE GiamTaiSanCoDinhID = N'" + input.GiamTaiSanCoDinhID + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
