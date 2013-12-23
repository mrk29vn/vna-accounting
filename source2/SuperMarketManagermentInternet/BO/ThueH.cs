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
  public  class ThueH
    {
       private Constants.ThueH dvt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.Thue donvitinh;
        private SqlConnection cn;

        public ThueH()
        {
            dvt = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            donvitinh = null;
            cn = null;
        }

        public Entities.Thue[] sp_SelectThuesAll()
        {
            Entities.Thue[] arrC = null;
            try
            {
                dvt = new Constants.ThueH();
                Sql = new Constants.Sql();
                string sql = Sql.SelectThue;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    donvitinh = new Entities.Thue();
                    donvitinh.ThueID = Convert.ToInt32(dr[dvt.ThueID].ToString());
                    donvitinh.MaThue = dr[dvt.MaThue].ToString();
                    donvitinh.GiaTriThue = dr[dvt.GiaTriThue].ToString();
                    donvitinh.TenThue = dr[dvt.TenThue].ToString();
                    donvitinh.GhiChu = dr[dvt.GhiChu].ToString();
                    donvitinh.Deleted = (Boolean)dr[dvt.Deleted];
                    arr.Add(donvitinh);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.Thue[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.Thue)arr[i];
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

        //insert update
        public int InsertUpdate(Entities.Thue dvt1)
        {
           try
           {
               dvt = new Constants.ThueH();
            Sql = new Constants.Sql();
            string sql = Sql.InsertUpdateThue;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(dvt.HanhDong, SqlDbType.NVarChar, 20).Value = dvt1.HanhDong;
            cmd.Parameters.Add(dvt.ThueID, SqlDbType.Int).Value = dvt1.ThueID;
            cmd.Parameters.Add(dvt.MaThue, SqlDbType.VarChar, 20).Value = dvt1.MaThue;
            cmd.Parameters.Add(dvt.GiaTriThue, SqlDbType.Float).Value = dvt1.GiaTriThue;
            cmd.Parameters.Add(dvt.TenThue, SqlDbType.NVarChar,100).Value = dvt1.TenThue;
            cmd.Parameters.Add(dvt.GhiChu, SqlDbType.NVarChar, 100).Value = dvt1.GhiChu;
            cmd.Parameters.Add(dvt.Deleted, SqlDbType.Bit).Value = dvt1.Deleted;

            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return i;
           }
           catch (Exception ex)
           {
               return 0;
           }
        }

        //delete
        public void Delete(Entities.Thue dvt1)
        {
            dvt = new Constants.ThueH();
            Entities.Thue loaihanghoa = new Entities.Thue();
            Sql = new Constants.Sql();
            string sql = Sql.DeleteThue;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(dvt.HanhDong, SqlDbType.NVarChar, 20).Value = dvt1.HanhDong;
            cmd.Parameters.Add(dvt.ThueID, SqlDbType.Int).Value = dvt1.ThueID;

            cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
        }
    }
}
