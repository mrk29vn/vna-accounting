using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class TaiSanBiz
    {
        public TaiSanBiz() { }

        public static List<TaiSan> getListTaiSan()
        {
            List<TaiSan> kq = new List<TaiSan>();
            string sql = "SELECT * FROM  [VNAAccounting].[dbo].[TaiSan]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiSan temp = new TaiSan();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.TenTaiSan = dt.Rows[i]["TenTaiSan"].ToString();
                temp.MaLoaiTaiSan = dt.Rows[i]["MaLoaiTaiSan"].ToString();
                temp.MaLyDoTangGiamTaiSan = dt.Rows[i]["MaLyDoTangGiamTaiSan"].ToString();
                temp.NgayTangTaiSan = DateTime.Parse(dt.Rows[i]["NgayTangTaiSan"].ToString());
                temp.NgayTinhKhauHao = DateTime.Parse(dt.Rows[i]["NgayTinhKhauHao"].ToString());
                temp.SoKyKhauHao = dt.Rows[i]["SoKyKhauHao"].ToString();
                temp.MaBoPhanHachToan = dt.Rows[i]["MaBoPhanHachToan"].ToString();
                temp.MaPhanXuong = dt.Rows[i]["MaPhanXuong"].ToString();
                temp.MaPhi = dt.Rows[i]["MaPhi"].ToString();
                temp.MaBoPhanSuDung = dt.Rows[i]["MaBoPhanSuDung"].ToString();
                temp.TKTaiSan = dt.Rows[i]["TKTaiSan"].ToString();
                temp.TKKhauHao = dt.Rows[i]["TKKhauHao"].ToString();
                temp.TKChiPhi = dt.Rows[i]["TKChiPhi"].ToString();
                temp.PhanNhom1 = dt.Rows[i]["PhanNhom1"].ToString();
                temp.PhanNhom2 = dt.Rows[i]["PhanNhom2"].ToString();
                temp.PhanNhom3 = dt.Rows[i]["PhanNhom3"].ToString();
                temp.TenKhac = dt.Rows[i]["TenKhac"].ToString();
                temp.SoHieuTaiSan = dt.Rows[i]["SoHieuTaiSan"].ToString();
                temp.ThongSoKyThuat = dt.Rows[i]["ThongSoKyThuat"].ToString();
                temp.NuocSanXuat = dt.Rows[i]["NuocSanXuat"].ToString();
                temp.NamSanXuat = dt.Rows[i]["NamSanXuat"].ToString();
                temp.NgayDuaVaoSuDung = DateTime.Parse(dt.Rows[i]["NgayDuaVaoSuDung"].ToString());
                temp.NgayDinhChiSuDung = DateTime.Parse(dt.Rows[i]["NgayDinhChiSuDung"].ToString());
                temp.LyDoDinhChi = dt.Rows[i]["LyDoDinhChi"].ToString();
                temp.GhiChu = dt.Rows[i]["GhiChu"].ToString();

                temp.Lchitiettaisan = ChiTietTaiSanBiz.getListChiTietTaiSan(temp.MaTaiSan.ToUpper());
                temp.Lphutungkemtheo = PhuTungKemTheoBiz.getListPhuTungKemTheo(temp.MaTaiSan.ToUpper());

                kq.Add(temp);
            }
            return kq;
        }

        public static int AddTaiSan(TaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[TaiSan]([MaTaiSan],[TenTaiSan],[MaLoaiTaiSan],[MaLyDoTangGiamTaiSan],[NgayTangTaiSan],[NgayTinhKhauHao],[SoKyKhauHao],[MaBoPhanHachToan],[MaPhanXuong],[MaPhi],[MaBoPhanSuDung],[TKTaiSan],[TKKhauHao],[TKChiPhi],[PhanNhom1],[PhanNhom2],[PhanNhom3],[TenKhac],[SoHieuTaiSan],[ThongSoKyThuat],[NuocSanXuat],[NamSanXuat],[NgayDuaVaoSuDung],[NgayDinhChiSuDung],[LyDoDinhChi],[GhiChu]) ";
            sql += "VALUES(";
            sql += "N'" + input.MaTaiSan.ToUpper() + "',N'" + input.TenTaiSan + "',N'" + input.MaLoaiTaiSan.ToUpper() + "',N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "','" + input.NgayTangTaiSan.ToString("MM/dd/yyyy") + "',";
            sql += "'" + input.NgayTinhKhauHao.ToString("MM/dd/yyyy") + "',N'" + input.SoKyKhauHao + "',N'" + input.MaBoPhanHachToan.ToUpper() + "',N'" + input.MaPhanXuong.ToUpper() + "',N'" + input.MaPhi.ToUpper() + "',";
            sql += "N'" + input.MaBoPhanSuDung.ToUpper() + "',N'" + input.TKTaiSan.ToUpper() + "',N'" + input.TKKhauHao.ToUpper() + "',N'" + input.TKChiPhi.ToUpper() + "',N'" + input.PhanNhom1 + "',";
            sql += "N'" + input.PhanNhom2 + "',N'" + input.PhanNhom3 + "',N'" + input.TenKhac + "',N'" + input.SoHieuTaiSan.ToUpper() + "',N'" + input.ThongSoKyThuat + "',";
            sql += "N'" + input.NuocSanXuat + "',N'" + input.NamSanXuat + "','" + input.NgayDuaVaoSuDung.ToString("MM/dd/yyyy") + "','" + input.NgayDinhChiSuDung.ToString("MM/dd/yyyy") + "',N'" + input.LyDoDinhChi + "',N'" + input.GhiChu + "'";
            sql += ")";
            int kq = DAL.CSDL.ThemSuaXoa(sql);
            if (kq > 0)
            {
                //Insert chi tiết tài sản
                foreach (ChiTietTaiSan item in input.Lchitiettaisan)
                {
                    ChiTietTaiSanBiz.AddChiTietTaiSan(item);
                }
                //Insert phụ tùng kèm theo
                foreach (PhuTungKemTheo item in input.Lphutungkemtheo)
                {
                    PhuTungKemTheoBiz.AddPhuTungKemTheo(item);
                }
            }
            return kq;
        }

        public static int EditTaiSan(TaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[TaiSan] SET ";
            sql += "TenTaiSan = N'" + input.TenTaiSan + "',MaLoaiTaiSan = N'" + input.MaLoaiTaiSan.ToUpper() + "',MaLyDoTangGiamTaiSan = N'" + input.MaLyDoTangGiamTaiSan.ToUpper() + "',NgayTangTaiSan = '" + input.NgayTangTaiSan.ToString("MM/dd/yyyy") + "',NgayTinhKhauHao = '" + input.NgayTinhKhauHao.ToString("MM/dd/yyyy") + "',";
            sql += "SoKyKhauHao = N'" + input.SoKyKhauHao + "',MaBoPhanHachToan = N'" + input.MaBoPhanHachToan.ToUpper() + "',MaPhanXuong = N'" + input.MaPhanXuong.ToUpper() + "',MaPhi = N'" + input.MaPhi.ToUpper() + "',MaBoPhanSuDung = N'" + input.MaBoPhanSuDung.ToUpper() + "',";
            sql += "TKTaiSan = N'" + input.TKTaiSan.ToUpper() + "',TKKhauHao = N'" + input.TKKhauHao.ToUpper() + "',TKChiPhi = N'" + input.TKChiPhi.ToUpper() + "',PhanNhom1 = N'" + input.PhanNhom1 + "',PhanNhom2 = N'" + input.PhanNhom2 + "',";
            sql += "PhanNhom3 = N'" + input.PhanNhom3 + "',TenKhac = N'" + input.TenKhac + "',SoHieuTaiSan = N'" + input.SoHieuTaiSan.ToUpper() + "',ThongSoKyThuat = N'" + input.ThongSoKyThuat + "',NuocSanXuat = N'" + input.NuocSanXuat + "',";
            sql += "NamSanXuat = N'" + input.NamSanXuat + "',NgayDuaVaoSuDung = '" + input.NgayDuaVaoSuDung.ToString("MM/dd/yyyy") + "',NgayDinhChiSuDung = '" + input.NgayDinhChiSuDung.ToString("MM/dd/yyyy") + "',LyDoDinhChi = N'" + input.LyDoDinhChi + "',GhiChu = N'" + input.GhiChu + "'";
            sql += " WHERE MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "'";
            int kq = DAL.CSDL.ThemSuaXoa(sql);
            if (kq > 0)
            {
                //Delete chi tiết tài sản
                ChiTietTaiSan xoactts = new ChiTietTaiSan(); xoactts.MaTaiSan = input.MaTaiSan;
                ChiTietTaiSanBiz.DeleteChiTietTaiSan(xoactts);
                //Delete phụ tùng kèm theo
                PhuTungKemTheo xoaptkt = new PhuTungKemTheo(); xoaptkt.MaTaiSan = input.MaTaiSan;
                PhuTungKemTheoBiz.DeletePhuTungKemTheo(xoaptkt);

                //Insert chi tiết tài sản
                foreach (ChiTietTaiSan item in input.Lchitiettaisan)
                {
                    ChiTietTaiSanBiz.AddChiTietTaiSan(item);
                }
                //Insert phụ tùng kèm theo
                foreach (PhuTungKemTheo item in input.Lphutungkemtheo)
                {
                    PhuTungKemTheoBiz.AddPhuTungKemTheo(item);
                }
            }
            return kq;
        }

        public static int DeleteTaiSan(TaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[TaiSan] WHERE MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "'";
            //Delete chi tiết tài sản
            ChiTietTaiSan xoactts = new ChiTietTaiSan(); xoactts.MaTaiSan = input.MaTaiSan;
            ChiTietTaiSanBiz.DeleteChiTietTaiSan(xoactts);
            //Delete phụ tùng kèm theo
            PhuTungKemTheo xoaptkt = new PhuTungKemTheo(); xoaptkt.MaTaiSan = input.MaTaiSan;
            PhuTungKemTheoBiz.DeletePhuTungKemTheo(xoaptkt);
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
