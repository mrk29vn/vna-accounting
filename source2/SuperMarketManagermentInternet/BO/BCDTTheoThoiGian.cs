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
    public class BCDTTheoThoiGian
    {
        Constants.BCDTTheoThoiGian dtttg;
        Constants.Sql Sql;

        public Entities.BCDTTheoThoiGian[] Select(DateTime ngay)
        {

            Sql = new Constants.Sql();
            dtttg = new Constants.BCDTTheoThoiGian();
            string sql = Sql.BCDTTheoNgay;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Ngay", SqlDbType.DateTime).Value = ngay;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoThoiGian bcdttg1 = new Entities.BCDTTheoThoiGian();
                bcdttg1.MaHDBanHang = dr[dtttg.MaHDBanHang].ToString();
                bcdttg1.NgayBan = Convert.ToDateTime(dr[dtttg.NgayBan].ToString());
                bcdttg1.ThanhToanNgay = float.Parse(dr[dtttg.ThanhToanNgay].ToString());
                bcdttg1.ThanhToanKhiLapPhieu=double.Parse(dr[dtttg.ThanhToanKhiLapPhieu].ToString());
                bcdttg1.TongTienThanhToan = double.Parse(dr["TongTienThanhToan"].ToString());
                arr.Add(bcdttg1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoThoiGian[] arrC = new Entities.BCDTTheoThoiGian[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoThoiGian)arr[i];
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

        public Entities.BCDTTheoThoiGian[] Select(int thang, int nam)
        {

            Sql = new Constants.Sql();
            dtttg = new Constants.BCDTTheoThoiGian();
            string sql = Sql.BCDTTheoThang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoThoiGian bcdttg1 = new Entities.BCDTTheoThoiGian();
                bcdttg1.MaHDBanHang = dr[dtttg.MaHDBanHang].ToString();
                bcdttg1.NgayBan = Convert.ToDateTime(dr[dtttg.NgayBan].ToString());
                bcdttg1.ThanhToanNgay = float.Parse(dr[dtttg.ThanhToanNgay].ToString());
                bcdttg1.ThanhToanKhiLapPhieu = double.Parse(dr[dtttg.ThanhToanKhiLapPhieu].ToString());
                bcdttg1.TongTienThanhToan = double.Parse(dr["TongTienThanhToan"].ToString());
                arr.Add(bcdttg1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoThoiGian[] arrC = new Entities.BCDTTheoThoiGian[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoThoiGian)arr[i];
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

        public Entities.BCDTTheoThoiGian[] Select(DateTime truoc, DateTime sau)
        {

            Sql = new Constants.Sql();
            dtttg = new Constants.BCDTTheoThoiGian();
            string sql = Sql.BCDTTheoKhoangThoiGian;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Truoc", SqlDbType.DateTime).Value = truoc;
            cmd.Parameters.Add("@Sau", SqlDbType.DateTime).Value = sau;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoThoiGian bcdttg1 = new Entities.BCDTTheoThoiGian();
                bcdttg1.MaHDBanHang = dr[dtttg.MaHDBanHang].ToString();
                bcdttg1.NgayBan = Convert.ToDateTime(dr[dtttg.NgayBan].ToString());
                bcdttg1.ThanhToanNgay = float.Parse(dr[dtttg.ThanhToanNgay].ToString());
                bcdttg1.ThanhToanKhiLapPhieu = double.Parse(dr[dtttg.ThanhToanKhiLapPhieu].ToString());
                bcdttg1.TongTienThanhToan = double.Parse(dr["TongTienThanhToan"].ToString());
                arr.Add(bcdttg1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoThoiGian[] arrC = new Entities.BCDTTheoThoiGian[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoThoiGian)arr[i];
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
