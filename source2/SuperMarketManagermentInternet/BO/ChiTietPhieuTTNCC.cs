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
    public class ChiTietPhieuTTNCC
    {
        Constants.ChiTietPhieuTTNCC ctpttncc;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietPhieuTTNCC[] Select(Entities.ChiTietPhieuTTNCC ctpttncc2)
        {

            Sql = new Constants.Sql();
            ctpttncc = new Constants.ChiTietPhieuTTNCC();
            string sql = Sql.SelectChiTietPhieuTTNCC;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(ctpttncc.MaPhieuTTNCC, SqlDbType.VarChar, 20).Value = ctpttncc2.MaPhieuTTNCC;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietPhieuTTNCC ctpttncc1 = new Entities.ChiTietPhieuTTNCC();
                ctpttncc1.MaHoaDonNhap = dr[ctpttncc.MaHoaDonNhap].ToString();
                ctpttncc1.MaPhieuTTNCC = dr[ctpttncc.MaPhieuTTNCC].ToString();
                ctpttncc1.TongTien = dr[ctpttncc.TongTien].ToString();
                ctpttncc1.TienNo = dr[ctpttncc.TienNo].ToString();
                ctpttncc1.ThanhToan = float.Parse(dr[ctpttncc.ThanhToan].ToString());
                ctpttncc1.TrangThai = (Boolean) dr[ctpttncc.TrangThai];
                ctpttncc1.GhiChu = dr[ctpttncc.GhiChu].ToString();
                ctpttncc1.Deleted = (Boolean)dr[ctpttncc.Deleted];
                arr.Add(ctpttncc1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietPhieuTTNCC[] arrC = new Entities.ChiTietPhieuTTNCC[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietPhieuTTNCC)arr[i];
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

        public Entities.ChiTietPhieuTTNCC[] Select()
        {

            Sql = new Constants.Sql();
            ctpttncc = new Constants.ChiTietPhieuTTNCC();
            string sql = "Select * From ChiTietPhieuTTNCC where Deleted = 0";
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietPhieuTTNCC ctpttncc1 = new Entities.ChiTietPhieuTTNCC();
                ctpttncc1.MaHoaDonNhap = dr[ctpttncc.MaHoaDonNhap].ToString();
                ctpttncc1.MaPhieuTTNCC = dr[ctpttncc.MaPhieuTTNCC].ToString();
                ctpttncc1.TongTien = dr[ctpttncc.TongTien].ToString();
                ctpttncc1.TienNo = dr[ctpttncc.TienNo].ToString();
                ctpttncc1.ThanhToan = float.Parse(dr[ctpttncc.ThanhToan].ToString());
                ctpttncc1.TrangThai = (Boolean)dr[ctpttncc.TrangThai];
                ctpttncc1.GhiChu = dr[ctpttncc.GhiChu].ToString();
                ctpttncc1.Deleted = (Boolean)dr[ctpttncc.Deleted];
                arr.Add(ctpttncc1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietPhieuTTNCC[] arrC = new Entities.ChiTietPhieuTTNCC[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietPhieuTTNCC)arr[i];
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
        public bool InsertUpdate(Entities.ChiTietPhieuTTNCC ctpttncc1)
        {
            try
            {
                bool kt = false;
                ctpttncc = new Constants.ChiTietPhieuTTNCC();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateChiTietPhieuTTNCC;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctpttncc.HanhDong, SqlDbType.VarChar, 20).Value = ctpttncc1.HanhDong;
                cmd.Parameters.Add(ctpttncc.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = ctpttncc1.MaHoaDonNhap;
                cmd.Parameters.Add(ctpttncc.MaPhieuTTNCC, SqlDbType.VarChar, 20).Value = ctpttncc1.MaPhieuTTNCC;
                cmd.Parameters.Add(ctpttncc.TongTien, SqlDbType.Float).Value = ctpttncc1.TongTien;
                cmd.Parameters.Add(ctpttncc.TienNo, SqlDbType.Float).Value = ctpttncc1.TienNo;
                cmd.Parameters.Add(ctpttncc.ThanhToan, SqlDbType.Float).Value = ctpttncc1.ThanhToan;
                cmd.Parameters.Add(ctpttncc.TrangThai, SqlDbType.Bit).Value = ctpttncc1.TrangThai;
                cmd.Parameters.Add(ctpttncc.GhiChu, SqlDbType.NVarChar, 20).Value = ctpttncc1.GhiChu;
                cmd.Parameters.Add(ctpttncc.Deleted, SqlDbType.Bit).Value = ctpttncc1.Deleted;

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

        public bool InsertUpdate(Entities.ChiTietPhieuTTNCC[] ctpttncc)
        {
            try
            {
                for (int i = 0; i < ctpttncc.Length; i++)
                {
                    if (ctpttncc[i].MaHoaDonNhap != "")
                    {
                        InsertUpdate(ctpttncc[i]);
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
        /// Delete Bảng
        /// </summary>
        public bool Delete(Entities.ChiTietPhieuTTNCC ctpttncc1)
        {
            try
            {
                bool kt = false;
                ctpttncc = new Constants.ChiTietPhieuTTNCC();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteChiTietPhieuTTNCC;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctpttncc.HanhDong, SqlDbType.VarChar, 20).Value = ctpttncc1.HanhDong;
                cmd.Parameters.Add(ctpttncc.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = ctpttncc1.MaHoaDonNhap;
                cmd.Parameters.Add(ctpttncc.MaPhieuTTNCC, SqlDbType.VarChar, 20).Value = ctpttncc1.MaPhieuTTNCC;

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



    }
}
