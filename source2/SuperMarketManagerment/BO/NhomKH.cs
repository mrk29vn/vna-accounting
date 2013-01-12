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
  public  class NhomKH
    {
      
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.NhomKH nkh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.NhomKH nhomkhachhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public NhomKH()
        {
            nkh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            nhomkhachhang = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.NhomKH[] Select()
        {

            Entities.NhomKH[] arrC = null;
            try
            {
                nkh = new Constants.NhomKH();
                Sql = new Constants.Sql();
                string sql = Sql.SelectNhomKHsAll;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                Entities.NhomKH nhomkh = null;
            while (dr.Read())
            {
                nhomkh = new Entities.NhomKH();
                nhomkh.NhomKHID = Convert.ToInt32(dr[nkh.NhomKHID].ToString());
                nhomkh.MaNhomKH = dr[nkh.MaNhomKH].ToString();
                nhomkh.TenNhomKH = dr[nkh.TenNhomKH].ToString();
                nhomkh.LoaiKH = Convert.ToBoolean(dr[nkh.LoaiKH].ToString());
                nhomkh.GhiChu = dr[nkh.GhiChu].ToString();
                nhomkh.Deleted = Convert.ToBoolean(dr[nkh.Deleted].ToString());
                arr.Add(nhomkh);
            }
            int n = arr.Count;
            if (n == 0) { return null; }
            arrC = new Entities.NhomKH[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.NhomKH)arr[i];
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
        /// Insert Update Bảng
        /// </summary>
        public int InsertUpdate(Entities.NhomKH nkh1)
        {
           int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateNhomKH;
                conn = new Connection();
                nkh = new Constants.NhomKH();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(nkh.HanhDong, SqlDbType.NVarChar, 20).Value =nkh1.Hanhdong;
            cmd.Parameters.Add(nkh.NhomKHID, SqlDbType.Int).Value =nkh1. NhomKHID;
            cmd.Parameters.Add(nkh.MaNhomKH, SqlDbType.NVarChar, 20).Value =nkh1. MaNhomKH;
            cmd.Parameters.Add(nkh.TenNhomKH, SqlDbType.NVarChar, 200).Value =nkh1. TenNhomKH;
            cmd.Parameters.Add(nkh.LoaiKH, SqlDbType.Bit).Value =nkh1. LoaiKH;
            cmd.Parameters.Add(nkh.GhiChu, SqlDbType.NVarChar, 200).Value =nkh1. GhiChu;
            cmd.Parameters.Add(nkh.Deleted, SqlDbType.Bit).Value = nkh1.Deleted;
            Trave = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;          
        }

        /// <summary>
        /// Delete Bảng
        /// </summary>
        public int Delete(Entities.NhomKH nkh2)
        {
            int Trave = 0;
            try
            {
                nkh = new Constants.NhomKH();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteNhomKH;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(nkh.HanhDong, SqlDbType.NVarChar, 20).Value = nkh2.Hanhdong.ToString();
                cmd.Parameters.Add(nkh.NhomKHID, SqlDbType.Int).Value = nkh2.NhomKHID;
                Trave = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }
    }
}
