using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class BCDTTheoNhanVien
    {
        Constants.BCDTTheoNhanVien dttnv;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.BCDTTheoNhanVien[] Select(Entities.BCDTTheoNhanVien bcdtt)
        {

            Sql = new Constants.Sql();
            dttnv = new Constants.BCDTTheoNhanVien();
            string sql = Sql.BCDTTheoNhanVienTheoMa;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,20).Value = bcdtt.MaNhanVien;
            cmd.Parameters.Add("@Truoc", SqlDbType.DateTime).Value = bcdtt.Truoc;
            cmd.Parameters.Add("@Sau", SqlDbType.DateTime).Value = bcdtt.Sau;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoNhanVien bcdtnv1 = new Entities.BCDTTheoNhanVien();
                bcdtnv1.MaNhanVien = dr[dttnv.MaNhanVien].ToString();
                bcdtnv1.TenNhanVien = dr[dttnv.TenNhanVien].ToString();
                bcdtnv1.MaHDBanHang = dr[dttnv.MaHDBanHang].ToString();
                bcdtnv1.NgayBan = Convert.ToDateTime(dr[dttnv.NgayBan].ToString());
                bcdtnv1.ThanhToanNgay = double.Parse(dr[dttnv.ThanhToanNgay].ToString());
                bcdtnv1.ThanhToanKhiLapPhieu = double.Parse(dr[dttnv.ThanhToanKhiLapPhieu].ToString());
                bcdtnv1.TongTienThanhToan = double.Parse(dr["TongTienThanhToan"].ToString());
                bcdtnv1.GiaTriThe = double.Parse(dr["GiaTriThe"].ToString());
                bcdtnv1.GiaTriTheGiaTri = double.Parse(dr["GiaTriTheGiaTri"].ToString());
                arr.Add(bcdtnv1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoNhanVien[] arrC = new Entities.BCDTTheoNhanVien[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoNhanVien)arr[i];
            }

            //Giai phong bo nho
            arr = null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arrC;
        }
        public Entities.BCDTTheoNhanVien[] Select()
        {

            Sql = new Constants.Sql();
            dttnv = new Constants.BCDTTheoNhanVien();
            string sql = Sql.BCDTTheoNhanVien;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoNhanVien bcdtnv1 = new Entities.BCDTTheoNhanVien();
                bcdtnv1.MaNhanVien = dr[dttnv.MaNhanVien].ToString();
                bcdtnv1.TenNhanVien = dr[dttnv.TenNhanVien].ToString();
                bcdtnv1.MaHDBanHang = dr[dttnv.MaHDBanHang].ToString();
                bcdtnv1.NgayBan = Convert.ToDateTime(dr[dttnv.NgayBan].ToString());
                bcdtnv1.ThanhToanNgay = double.Parse(dr[dttnv.ThanhToanNgay].ToString());
                bcdtnv1.ThanhToanKhiLapPhieu = double.Parse(dr[dttnv.ThanhToanKhiLapPhieu].ToString());
                bcdtnv1.TongTienThanhToan = double.Parse(dr["TongTienThanhToan"].ToString());
                bcdtnv1.GiaTriThe = double.Parse(dr["GiaTriThe"].ToString());
                bcdtnv1.GiaTriTheGiaTri = double.Parse(dr["GiaTriTheGiaTri"].ToString());
                arr.Add(bcdtnv1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoNhanVien[] arrC = new Entities.BCDTTheoNhanVien[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoNhanVien)arr[i];
            }

            //Giai phong bo nho
            arr = null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arrC;
        }
    }
}
