using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class ChiTietTaiSanBiz
    {
        public ChiTietTaiSanBiz() { }

        public static List<ChiTietTaiSan> getListChiTietTaiSan()
        {
            List<ChiTietTaiSan> kq = new List<ChiTietTaiSan>();
            string sql = "SELECT [MaTaiSan],[MaNguonVon],[NgayChungTu],[SoChungTu],[NguyenGia],[GiaTriDaKhauHao],[GiaTriConLai],[GiaTriKhauHao1Ky],[DienGiai] FROM [VNAAccounting].[dbo].[ChiTietTaiSan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietTaiSan temp = new ChiTietTaiSan();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.MaNguonVon = dt.Rows[i]["MaNguonVon"].ToString();
                temp.NgayChungTu = DateTime.Parse(dt.Rows[i]["NgayChungTu"].ToString());
                temp.SoChungTu = dt.Rows[i]["SoChungTu"].ToString();
                temp.NguyenGia = double.Parse(dt.Rows[i]["NguyenGia"].ToString());
                temp.GiaTriDaKhauHao = double.Parse(dt.Rows[i]["GiaTriDaKhauHao"].ToString());
                temp.GiaTriConLai = double.Parse(dt.Rows[i]["GiaTriConLai"].ToString());
                temp.GiaTriKhauHao1Ky = double.Parse(dt.Rows[i]["GiaTriKhauHao1Ky"].ToString());
                temp.DienGiai = dt.Rows[i]["DienGiai"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
        public static List<ChiTietTaiSan> getListChiTietTaiSan(string MaTaiSan)
        {
            List<ChiTietTaiSan> kq = new List<ChiTietTaiSan>();
            string sql = "SELECT [MaTaiSan],[MaNguonVon],[NgayChungTu],[SoChungTu],[NguyenGia],[GiaTriDaKhauHao],[GiaTriConLai],[GiaTriKhauHao1Ky],[DienGiai] FROM [VNAAccounting].[dbo].[ChiTietTaiSan] WHERE MaTaiSan=N'" + MaTaiSan.ToUpper() + "'";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietTaiSan temp = new ChiTietTaiSan();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.MaNguonVon = dt.Rows[i]["MaNguonVon"].ToString();
                temp.NgayChungTu = DateTime.Parse(dt.Rows[i]["NgayChungTu"].ToString());
                temp.SoChungTu = dt.Rows[i]["SoChungTu"].ToString();
                temp.NguyenGia = double.Parse(dt.Rows[i]["NguyenGia"].ToString());
                temp.GiaTriDaKhauHao = double.Parse(dt.Rows[i]["GiaTriDaKhauHao"].ToString());
                temp.GiaTriConLai = double.Parse(dt.Rows[i]["GiaTriConLai"].ToString());
                temp.GiaTriKhauHao1Ky = double.Parse(dt.Rows[i]["GiaTriKhauHao1Ky"].ToString());
                temp.DienGiai = dt.Rows[i]["DienGiai"].ToString();
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddChiTietTaiSan(ChiTietTaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[ChiTietTaiSan]([MaTaiSan],[MaNguonVon],[NgayChungTu],[SoChungTu],[NguyenGia],[GiaTriDaKhauHao],[GiaTriConLai],[GiaTriKhauHao1Ky],[DienGiai]) VALUES(N'" + input.MaTaiSan.ToUpper() + "',N'" + input.MaNguonVon.ToUpper() + "'," + input.NgayChungTu.ToString("MM/dd/yyyy") + ",N'" + input.SoChungTu + "'," + input.NguyenGia + "," + input.GiaTriDaKhauHao + "," + input.GiaTriConLai + "," + input.GiaTriKhauHao1Ky + ",N'" + input.DienGiai + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditChiTietTaiSan(ChiTietTaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[ChiTietTaiSan] SET MaNguonVon = N'" + input.MaNguonVon.ToUpper() + "',NgayChungTu = " + input.NgayChungTu.ToString("MM/dd/yyyy") + ",SoChungTu = N'" + input.SoChungTu + "',NguyenGia = " + input.NguyenGia + ",GiaTriDaKhauHao = " + input.GiaTriDaKhauHao + ",GiaTriConLai = " + input.GiaTriConLai + ",GiaTriKhauHao1Ky = " + input.GiaTriKhauHao1Ky + ",DienGiai = N'" + input.DienGiai + "' WHERE MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteChiTietTaiSan(ChiTietTaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[ChiTietTaiSan] WHERE MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
