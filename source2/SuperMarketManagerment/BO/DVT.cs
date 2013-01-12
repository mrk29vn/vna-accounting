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
    public class DVT
    {
        private Constants.DVT dvt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.DVT donvitinh;
        private SqlConnection cn;

        public DVT()
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

        public Entities.DVT[] sp_SelectDVTsAll()
        {
            Entities.DVT[] arrC = null;
            try
            {
                dvt = new Constants.DVT();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllDVT;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    donvitinh = new Entities.DVT();
                    donvitinh.DVTID = Convert.ToInt32(dr[dvt.DVTID].ToString());
                    donvitinh.MaDonViTinh = dr[dvt.MaDonViTinh].ToString();
                    donvitinh.TenDonViTinh = dr[dvt.TenDonViTinh].ToString();
                    donvitinh.GhiChu = dr[dvt.GhiChu].ToString();
                    donvitinh.Deleted = (Boolean)dr[dvt.Deleted];
                    arr.Add(donvitinh);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.DVT[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.DVT)arr[i];
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
        public int InsertUpdate(Entities.DVT dvt1)
        {
           try
           {
            dvt = new Constants.DVT();
            Sql = new Constants.Sql();
            string sql = Sql.InsertUpdateDVT;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(dvt.HanhDong, SqlDbType.NVarChar, 20).Value = dvt1.HanhDong;
            cmd.Parameters.Add(dvt.DVTID, SqlDbType.Int).Value = dvt1.DVTID;
            cmd.Parameters.Add(dvt.MaDonViTinh, SqlDbType.NVarChar, 20).Value = dvt1.MaDonViTinh;
            cmd.Parameters.Add(dvt.TenDonViTinh, SqlDbType.NVarChar, 20).Value = dvt1.TenDonViTinh;
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
        public void Delete(Entities.DVT dvt1)
        {
            dvt = new Constants.DVT();
            Entities.DVT loaihanghoa = new Entities.DVT();
            Sql = new Constants.Sql();
            string sql = Sql.DeleteDVT;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(dvt.HanhDong, SqlDbType.NVarChar, 20).Value = dvt1.HanhDong;
            cmd.Parameters.Add(dvt.DVTID, SqlDbType.Int).Value = dvt1.DVTID;

            cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
        }
    }
}
