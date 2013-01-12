using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;
using System.Collections;

namespace BizLogic
{
    public class TKKeToan
    {
        private Constants.TKKeToan TKKT;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public TKKeToan()
        {
            TKKT = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.TKKeToan[] Select()
        {

            Entities.TKKeToan[] arrC = null;
            try
            {
                TKKT = new Constants.TKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllTKKeToan;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TKKeToan tkketoan = new Entities.TKKeToan();
                    tkketoan.TKKeToanID = Convert.ToInt32(dr[TKKT.TKKeToanID].ToString());
                    tkketoan.MaTKKeToan = dr[TKKT.MaTKKeToan].ToString();
                    tkketoan.TenTaiKhoan = dr[TKKT.TenTaiKhoan].ToString();
                    tkketoan.NhomTKKT = dr[TKKT.MaNhomTKKT].ToString();
                    tkketoan.GhiChu = dr[TKKT.GhiChu].ToString();
                    tkketoan.Deleted = (Boolean)dr[TKKT.Deleted];
                    arr.Add(tkketoan);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TKKeToan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TKKeToan)arr[i];
                }
            }

            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;

        }
        /// <summary>
        /// Lấy Nợ Tài Khoản
        /// </summary>
        /// <returns></returns>
        public Entities.TKKeToan[] LayNoTK()
        {
            Entities.TKKeToan[] arrC = null;
            try
            {
                TKKT = new Constants.TKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.LayNoTK;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TKKeToan tkketoan = new Entities.TKKeToan();
                    tkketoan.MaTKKeToan = dr[TKKT.MaTKKeToan].ToString();
                    Boolean kt = tkketoan.Deleted = (Boolean)dr[TKKT.Deleted];
                    if (kt == false)
                    {

                        arr.Add(tkketoan);
                    }
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TKKeToan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TKKeToan)arr[i];
                }
            }

            catch
            { }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;

        }

        /// <summary>
        /// Lấy có TK
        /// </summary>
        /// <returns></returns>
        public Entities.TKKeToan[] LayCoTK()
        {

            Entities.TKKeToan[] arrC = null;
            try
            {
                TKKT = new Constants.TKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.LayCoTK;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TKKeToan tkketoan = new Entities.TKKeToan();
                    tkketoan.MaTKKeToan = dr[TKKT.MaTKKeToan].ToString();
                    Boolean kt = tkketoan.Deleted = (Boolean)dr[TKKT.Deleted];
                    if (kt == false)
                    {
                        arr.Add(tkketoan);
                    }
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TKKeToan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TKKeToan)arr[i];
                }
            }
            catch
            { }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }

        public int InsertUpdate(Entities.TKKeToan tk1)
        {
                TKKT = new Constants.TKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateTKKeToan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(TKKT.HanhDong, SqlDbType.NVarChar, 20).Value = tk1.HanhDong;
                cmd.Parameters.Add(TKKT.TKKeToanID, SqlDbType.Int).Value = tk1.TKKeToanID;
                cmd.Parameters.Add(TKKT.MaTKKeToan, SqlDbType.NVarChar, 20).Value = tk1.MaTKKeToan;
                cmd.Parameters.Add(TKKT.MaNhomTKKT, SqlDbType.NVarChar, 20).Value = tk1.NhomTKKT;
                cmd.Parameters.Add(TKKT.TenTaiKhoan, SqlDbType.NVarChar, 200).Value = tk1.TenTaiKhoan;
                cmd.Parameters.Add(TKKT.GhiChu, SqlDbType.NVarChar, 100).Value = tk1.GhiChu;
                cmd.Parameters.Add(TKKT.Deleted, SqlDbType.Bit).Value = tk1.Deleted;

                int i = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return i;
        }

        public void Delete(Entities.TKKeToan tk1)
        {
            try
            {
                TKKT = new Constants.TKKeToan();
                Entities.TKKeToan phieuthu = new Entities.TKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteTKKeToan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(TKKT.HanhDong, SqlDbType.NVarChar, 20).Value = tk1.HanhDong;
                cmd.Parameters.Add(TKKT.TKKeToanID, SqlDbType.Int).Value = tk1.TKKeToanID;

                cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}
