using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class DieuChuyenBoPhanSuDungBiz
    {
        public DieuChuyenBoPhanSuDungBiz() { }

        public static List<DieuChuyenBoPhanSuDung> getListDieuChuyenBoPhanSuDung()
        {
            return getListDieuChuyenBoPhanSuDung(string.Empty, 0);
        }
        public static List<DieuChuyenBoPhanSuDung> getListDieuChuyenBoPhanSuDung(string MaTaiSan)
        {
            return getListDieuChuyenBoPhanSuDung(MaTaiSan, 1);
        }
        public static List<DieuChuyenBoPhanSuDung> getListDieuChuyenBoPhanSuDung(string MaTaiSan, int select)
        {
            List<DieuChuyenBoPhanSuDung> kq = new List<DieuChuyenBoPhanSuDung>();
            string sql = string.Empty;
            if (select == 0) sql = "SELECT [DieuChuyenBoPhanSuDungID],[MaDieuChuyenBoPhanSuDung],[MaTaiSan],[Nam],[Ky],[MaBoPhanSuDung],[TKTaiSan],[TKKhauHao],[TKChiPhi] FROM [VNAAccounting].[dbo].[DieuChuyenBoPhanSuDung]";
            else if (select == 1) sql = "SELECT [DieuChuyenBoPhanSuDungID],[MaDieuChuyenBoPhanSuDung],[MaTaiSan],[Nam],[Ky],[MaBoPhanSuDung],[TKTaiSan],[TKKhauHao],[TKChiPhi] FROM [VNAAccounting].[dbo].[DieuChuyenBoPhanSuDung] WHERE MaTaiSan = '" + MaTaiSan + "'";

            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DieuChuyenBoPhanSuDung temp = new DieuChuyenBoPhanSuDung();
                temp.DieuChuyenBoPhanSuDungID = int.Parse(dt.Rows[i]["DieuChuyenBoPhanSuDungID"].ToString());
                temp.MaDieuChuyenBoPhanSuDung = dt.Rows[i]["MaDieuChuyenBoPhanSuDung"].ToString();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.Nam = dt.Rows[i]["Nam"].ToString();
                temp.Ky = dt.Rows[i]["Ky"].ToString();
                temp.MaBoPhanSuDung = dt.Rows[i]["MaBoPhanSuDung"].ToString();
                temp.TKTaiSan = dt.Rows[i]["TKTaiSan"].ToString();
                temp.TKKhauHao = dt.Rows[i]["TKKhauHao"].ToString();
                temp.TKChiPhi = dt.Rows[i]["TKChiPhi"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddDieuChuyenBoPhanSuDung(DieuChuyenBoPhanSuDung input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[DieuChuyenBoPhanSuDung]([MaDieuChuyenBoPhanSuDung],[MaTaiSan],[Nam],[Ky],[MaBoPhanSuDung],[TKTaiSan],[TKKhauHao],[TKChiPhi]) VALUES(N'" + input.MaDieuChuyenBoPhanSuDung.ToUpper() + "',N'" + input.MaTaiSan.ToUpper() + "',N'" + input.Nam + "',N'" + input.Ky + "',N'" + input.MaBoPhanSuDung.ToUpper() + "',N'" + input.TKTaiSan + "',N'" + input.TKKhauHao + "',N'" + input.TKChiPhi + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditDieuChuyenBoPhanSuDung(DieuChuyenBoPhanSuDung input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[DieuChuyenBoPhanSuDung] SET MaDieuChuyenBoPhanSuDung =N'" + input.MaDieuChuyenBoPhanSuDung.ToUpper() + "',MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "',Nam = N'" + input.Nam + "',Ky = N'" + input.Ky + "',MaBoPhanSuDung = N'" + input.MaBoPhanSuDung + "',TKTaiSan = N'" + input.TKTaiSan + "',TKKhauHao = N'" + input.TKKhauHao + "',TKChiPhi = N'" + input.TKChiPhi + "' WHERE DieuChuyenBoPhanSuDungID = '" + input.DieuChuyenBoPhanSuDungID + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteDieuChuyenBoPhanSuDung(DieuChuyenBoPhanSuDung input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[DieuChuyenBoPhanSuDung] WHERE DieuChuyenBoPhanSuDungID = N'" + input.DieuChuyenBoPhanSuDungID + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
