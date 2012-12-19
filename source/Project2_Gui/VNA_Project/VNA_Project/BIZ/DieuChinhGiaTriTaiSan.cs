using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class DieuChinhGiaTriTaiSanBiz
    {
        public DieuChinhGiaTriTaiSanBiz() { }

        public static List<DieuChinhGiaTriTaiSan> getListDieuChinhGiaTriTaiSan()
        {
            List<DieuChinhGiaTriTaiSan> kq = new List<DieuChinhGiaTriTaiSan>();
            string sql = "SELECT [Loai],[MaTaiSan],[Nam],[Ky],[NgayChungTu],[SoChungTu],[MaNguonVon],[MaLyDoTangGiamTaiSan],[NguyenGia],[GiaTriDaKhauHao],[GiaTriConLai],[GiaTriKhauHao1Ky],[DienGiai] FROM [VNAAccounting].[dbo].[DieuChinhGiaTriTaiSan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DieuChinhGiaTriTaiSan temp = new DieuChinhGiaTriTaiSan();
                temp.Loai = bool.Parse(dt.Rows[i]["Loai"].ToString());
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.Nam = dt.Rows[i]["Nam"].ToString();
                temp.Ky = dt.Rows[i]["Ky"].ToString();
                temp.NgayChungTu = DateTime.Parse(dt.Rows[i]["NgayChungTu"].ToString());
                temp.SoChungTu = dt.Rows[i]["SoChungTu"].ToString();
                temp.MaNguonVon = dt.Rows[i]["MaNguonVon"].ToString();
                temp.MaLyDoTangGiamTaiSan = dt.Rows[i]["MaLyDoTangGiamTaiSan"].ToString();
                temp.NguyenGia = double.Parse(dt.Rows[i]["NguyenGia"].ToString());
                temp.GiaTriDaKhauHao = double.Parse(dt.Rows[i]["GiaTriDaKhauHao"].ToString());
                temp.GiaTriConLai = double.Parse(dt.Rows[i]["GiaTriConLai"].ToString());
                temp.GiaTriKhauHao1Ky = double.Parse(dt.Rows[i]["GiaTriKhauHao1Ky"].ToString());
                temp.DienGiai = dt.Rows[i]["DienGiai"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
        public static List<DieuChinhGiaTriTaiSan> getListDieuChinhGiaTriTaiSan(string MaTaiSan)
        {
            List<DieuChinhGiaTriTaiSan> kq = new List<DieuChinhGiaTriTaiSan>();
            string sql = "SELECT [Loai],[Nam],[Ky],[NgayChungTu],[SoChungTu],[MaNguonVon],[MaLyDoTangGiamTaiSan],[NguyenGia],[GiaTriDaKhauHao],[GiaTriConLai],[GiaTriKhauHao1Ky],[DienGiai] FROM [VNAAccounting].[dbo].[DieuChinhGiaTriTaiSan] WHERE MaTaiSan = '" + MaTaiSan + "'";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DieuChinhGiaTriTaiSan temp = new DieuChinhGiaTriTaiSan();
                temp.Loai = bool.Parse(dt.Rows[i]["Loai"].ToString());
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.Nam = dt.Rows[i]["Nam"].ToString();
                temp.Ky = dt.Rows[i]["Ky"].ToString();
                temp.NgayChungTu = DateTime.Parse(dt.Rows[i]["NgayChungTu"].ToString());
                temp.SoChungTu = dt.Rows[i]["SoChungTu"].ToString();
                temp.MaNguonVon = dt.Rows[i]["MaNguonVon"].ToString();
                temp.MaLyDoTangGiamTaiSan = dt.Rows[i]["MaLyDoTangGiamTaiSan"].ToString();
                temp.NguyenGia = double.Parse(dt.Rows[i]["NguyenGia"].ToString());
                temp.GiaTriDaKhauHao = double.Parse(dt.Rows[i]["GiaTriDaKhauHao"].ToString());
                temp.GiaTriConLai = double.Parse(dt.Rows[i]["GiaTriConLai"].ToString());
                temp.GiaTriKhauHao1Ky = double.Parse(dt.Rows[i]["GiaTriKhauHao1Ky"].ToString());
                temp.DienGiai = dt.Rows[i]["DienGiai"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddDieuChinhGiaTriTaiSan(DieuChinhGiaTriTaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[DieuChinhGiaTriTaiSan]([Loai],[Nam],[Ky],[NgayChungTu],[SoChungTu],[MaNguonVon],[MaLyDoTangGiamTaiSan],[NguyenGia],[GiaTriDaKhauHao],[GiaTriConLai],[GiaTriKhauHao1Ky],[DienGiai]) VALUES(" + input.Loai + ",N'" + input.MaTaiSan.ToUpper() + "',N'" + input.Nam + "',N'" + input.Ky + "','" + input.NgayChungTu.ToString("MM/dd/yyyy") + "',N'" + input.SoChungTu + "',N'" + input.MaNguonVon.ToUpper() + "',N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "'," + input.NguyenGia + "," + input.GiaTriDaKhauHao + "," + input.GiaTriConLai + "," + input.GiaTriKhauHao1Ky + ",N'" + input.DienGiai + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditDieuChinhGiaTriTaiSan(DieuChinhGiaTriTaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[DieuChinhGiaTriTaiSan] SET Loai=" + input.Loai + ",Nam = N'" + input.Nam + "',Ky = N'" + input.Ky + "',NgayChungTu = '" + input.NgayChungTu.ToString("MM/dd/yyyy") + "',SoChungTu = N'" + input.SoChungTu + "',MaNguonVon = N'" + input.MaNguonVon.ToUpper() + "',MaNguonVon = N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "',NguyenGia = " + input.NguyenGia + ",GiaTriDaKhauHao = " + input.GiaTriDaKhauHao + ",GiaTriConLai = " + input.GiaTriConLai + ",GiaTriKhauHao1Ky = " + input.GiaTriKhauHao1Ky + ",DienGiai = N'" + input.DienGiai + "' WHERE MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteDieuChinhGiaTriTaiSan(DieuChinhGiaTriTaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[DieuChinhGiaTriTaiSan] WHERE MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
