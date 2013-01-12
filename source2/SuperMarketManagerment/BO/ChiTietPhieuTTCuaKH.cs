using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class ChiTietPhieuTTCuaKH
    {
        Constants.ChiTietPhieuTTCuaKH ctpttckh;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietPhieuTTCuaKH[] Select(Entities.ChiTietPhieuTTCuaKH ctpttckh2)
        {

            Sql = new Constants.Sql();
            ctpttckh = new Constants.ChiTietPhieuTTCuaKH();
            string sql = Sql.SelectChiTietPhieuTTCuaKH;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(ctpttckh.MaPhieuTTCuaKH, SqlDbType.VarChar, 20).Value = ctpttckh2.MaPhieuTTCuaKH;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietPhieuTTCuaKH ctpttckh1 = new Entities.ChiTietPhieuTTCuaKH();
                ctpttckh1.MaHDBanHang = dr[ctpttckh.MaHDBanHang].ToString();
                ctpttckh1.MaPhieuTTCuaKH = dr[ctpttckh.MaPhieuTTCuaKH].ToString();
                ctpttckh1.TongTien = dr[ctpttckh.TongTien].ToString();
                ctpttckh1.TienNo = dr[ctpttckh.TienNo].ToString();
                ctpttckh1.ThanhToan = float.Parse(dr[ctpttckh.ThanhToan].ToString());
                ctpttckh1.TrangThai = (Boolean)dr[ctpttckh.TrangThai];
                ctpttckh1.GhiChu = dr[ctpttckh.GhiChu].ToString();
                ctpttckh1.Deleted = (Boolean)dr[ctpttckh.Deleted];
                arr.Add(ctpttckh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietPhieuTTCuaKH[] arrC = new Entities.ChiTietPhieuTTCuaKH[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietPhieuTTCuaKH)arr[i];
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

        public Entities.ChiTietPhieuTTCuaKH[] Select()
        {

            Sql = new Constants.Sql();
            ctpttckh = new Constants.ChiTietPhieuTTCuaKH();
            string sql = "Select * from ChiTietPhieuTTCuaKH where Deleted = 0";
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietPhieuTTCuaKH ctpttckh1 = new Entities.ChiTietPhieuTTCuaKH();
                ctpttckh1.MaHDBanHang = dr[ctpttckh.MaHDBanHang].ToString();
                ctpttckh1.MaPhieuTTCuaKH = dr[ctpttckh.MaPhieuTTCuaKH].ToString();
                ctpttckh1.TongTien = dr[ctpttckh.TongTien].ToString();
                ctpttckh1.TienNo = dr[ctpttckh.TienNo].ToString();
                ctpttckh1.ThanhToan = float.Parse(dr[ctpttckh.ThanhToan].ToString());
                ctpttckh1.TrangThai = (Boolean)dr[ctpttckh.TrangThai];
                ctpttckh1.GhiChu = dr[ctpttckh.GhiChu].ToString();
                ctpttckh1.Deleted = (Boolean)dr[ctpttckh.Deleted];
                arr.Add(ctpttckh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietPhieuTTCuaKH[] arrC = new Entities.ChiTietPhieuTTCuaKH[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietPhieuTTCuaKH)arr[i];
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

        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public bool InsertUpdate(Entities.ChiTietPhieuTTCuaKH ctpttncc1)
        {
            try
            {
                bool kt = false;
                ctpttckh = new Constants.ChiTietPhieuTTCuaKH();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateChiTietPhieuTTCuaKH;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctpttckh.HanhDong, SqlDbType.VarChar, 20).Value = ctpttncc1.HanhDong;
                cmd.Parameters.Add(ctpttckh.MaHDBanHang, SqlDbType.VarChar, 20).Value = ctpttncc1.MaHDBanHang;
                cmd.Parameters.Add(ctpttckh.MaPhieuTTCuaKH, SqlDbType.VarChar, 20).Value = ctpttncc1.MaPhieuTTCuaKH;
                cmd.Parameters.Add(ctpttckh.TongTien, SqlDbType.Float).Value = ctpttncc1.TongTien;
                cmd.Parameters.Add(ctpttckh.TienNo, SqlDbType.Float).Value = ctpttncc1.TienNo;
                cmd.Parameters.Add(ctpttckh.ThanhToan, SqlDbType.Float).Value = ctpttncc1.ThanhToan;
                cmd.Parameters.Add(ctpttckh.TrangThai, SqlDbType.Bit).Value = ctpttncc1.TrangThai;
                cmd.Parameters.Add(ctpttckh.GhiChu, SqlDbType.NVarChar, 20).Value = ctpttncc1.GhiChu;
                cmd.Parameters.Add(ctpttckh.Deleted, SqlDbType.Bit).Value = ctpttncc1.Deleted;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }

        public bool InsertUpdate(Entities.ChiTietPhieuTTCuaKH[] ctpttncc1)
        {
            try
            {
                for (int i = 0; i < ctpttncc1.Length; i++)
                {
                    if (ctpttncc1[i].MaHDBanHang != "")
                    {
                        bool kt = InsertUpdate(ctpttncc1[i]);
                        if (kt == false)
                        {        
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Update Bảng
        /// </summary>
        public bool Delete(Entities.ChiTietPhieuTTCuaKH ctpttncc1)
        {
            try
            {
                bool kt = false;
                ctpttckh = new Constants.ChiTietPhieuTTCuaKH();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteChiTietPhieuTTCuaKH;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctpttckh.HanhDong, SqlDbType.VarChar, 20).Value = ctpttncc1.HanhDong;
                cmd.Parameters.Add(ctpttckh.MaHDBanHang, SqlDbType.VarChar, 20).Value = ctpttncc1.MaHDBanHang;
                cmd.Parameters.Add(ctpttckh.MaPhieuTTCuaKH, SqlDbType.VarChar, 20).Value = ctpttncc1.MaPhieuTTCuaKH;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }
    }
}
