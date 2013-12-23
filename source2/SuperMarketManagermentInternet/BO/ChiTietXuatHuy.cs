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
    public class ChiTietXuatHuy
    {
        Constants.ChiTietXuatHuy ctxh;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietXuatHuy[] Select(Entities.ChiTietXuatHuy ctxh2)
        {

            Sql = new Constants.Sql();
            ctxh = new Constants.ChiTietXuatHuy();
            string sql = Sql.SelectChiTietXuatHuy;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(ctxh.MaPhieuXuatHuy, SqlDbType.VarChar, 20).Value = ctxh2.MaPhieuXuatHuy;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietXuatHuy ctxh1 = new Entities.ChiTietXuatHuy();
                ctxh1.MaPhieuXuatHuy = dr[ctxh.MaPhieuXuatHuy].ToString();
                ctxh1.MaHangHoa = dr[ctxh.MaHangHoa].ToString();
                ctxh1.SoLuong = (int)dr[ctxh.SoLuong];
                ctxh1.GhiChu = dr[ctxh.GhiChu].ToString();
                ctxh1.Deleted = (Boolean)dr[ctxh.Deleted];
                arr.Add(ctxh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietXuatHuy[] arrC = new Entities.ChiTietXuatHuy[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietXuatHuy)arr[i];
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

        public Entities.ChiTietXuatHuy[] Select()
        {

            Sql = new Constants.Sql();
            ctxh = new Constants.ChiTietXuatHuy();
            string sql = "Select * from ChiTietXuatHuy where Deleted = 0";
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietXuatHuy ctxh1 = new Entities.ChiTietXuatHuy();
                ctxh1.MaPhieuXuatHuy = dr[ctxh.MaPhieuXuatHuy].ToString();
                ctxh1.MaHangHoa = dr[ctxh.MaHangHoa].ToString();
                ctxh1.SoLuong = (int)dr[ctxh.SoLuong];
                ctxh1.GhiChu = dr[ctxh.GhiChu].ToString();
                ctxh1.Deleted = (Boolean)dr[ctxh.Deleted];
                arr.Add(ctxh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietXuatHuy[] arrC = new Entities.ChiTietXuatHuy[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietXuatHuy)arr[i];
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
        public bool InsertUpdate(Entities.ChiTietXuatHuy ctxh1)
        {
            try
            {
                bool kt = false;
                ctxh = new Constants.ChiTietXuatHuy();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateChiTietXuatHuyMang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctxh.HanhDong, SqlDbType.VarChar, 20).Value = ctxh1.HanhDong;
                cmd.Parameters.Add(ctxh.MaPhieuXuatHuy, SqlDbType.VarChar, 20).Value = ctxh1.MaPhieuXuatHuy;
                cmd.Parameters.Add(ctxh.MaHangHoa, SqlDbType.VarChar, 50).Value = ctxh1.MaHangHoa;
                cmd.Parameters.Add(ctxh.SoLuong, SqlDbType.Int, 20).Value = ctxh1.SoLuong;
                cmd.Parameters.Add(ctxh.GhiChu, SqlDbType.NVarChar, 20).Value = ctxh1.GhiChu;
                cmd.Parameters.Add(ctxh.Deleted, SqlDbType.Bit).Value = ctxh1.Deleted;

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

        public bool InsertUpdate(Entities.ChiTietXuatHuy[] ctxh2)
        {
            try
            {
                for (int i = 0; i < ctxh2.Length; i++)
                {
                    if (ctxh2[i].MaPhieuXuatHuy != "")
                        InsertUpdate(ctxh2[i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Entities.ChiTietXuatHuy[] ctxh2)
        {
            try
            {
                for (int i = 0; i < ctxh2.Length; i++)
                {
                    if (ctxh2[i].MaPhieuXuatHuy != "")
                        Delete(ctxh2[i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Deleted Update Bảng
        /// </summary>
        public bool Delete(Entities.ChiTietXuatHuy ctxh1)
        {
            try
            {
                bool kt = false;
                ctxh = new Constants.ChiTietXuatHuy();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteChiTietXuatHuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctxh.HanhDong, SqlDbType.VarChar, 20).Value = ctxh1.HanhDong;
                cmd.Parameters.Add(ctxh.MaPhieuXuatHuy, SqlDbType.VarChar, 20).Value = ctxh1.MaPhieuXuatHuy;
                cmd.Parameters.Add(ctxh.MaHangHoa, SqlDbType.VarChar, 50).Value = ctxh1.MaHangHoa;

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
