using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class NhanVienBiz
    {
        public NhanVienBiz() { }

        public static List<NhanVien> getListNhanVien()
        {
            List<NhanVien> kq = new List<NhanVien>();
            string sql = "SELECT [MaNhanVien],[TenNhanVien],[SCMND],[SoDienThoai],[Email],[GioiTinh],[NgaySinh],[DiaChi]  FROM  [VNAAccounting].[dbo].[NhanVien]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien temp = new NhanVien();
                temp.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                temp.TenNhanVien = dt.Rows[i]["TenNhanVien"].ToString();
                temp.SCMND = dt.Rows[i]["SCMND"].ToString();
                temp.SoDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
                temp.Email = dt.Rows[i]["Email"].ToString();
                temp.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                temp.NgaySinh = dt.Rows[i]["NgaySinh"].ToString();
                temp.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
    }
}
