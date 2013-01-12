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
    public class PhongBan
    {
        private Constants.PhongBan pb;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public PhongBan()
        {
            pb = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.PhongBan[] Select()
        {

            Entities.PhongBan[] arrC = null;
            try
            {
                pb = new Constants.PhongBan();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllPhongBan;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.PhongBan phongban = new Entities.PhongBan();
                    phongban.PhongBanID = Convert.ToInt32(dr[pb.PhongBanID].ToString());
                    phongban.MaPhongBan = dr[pb.MaPhongBan].ToString();
                    phongban.TenPhongBan = dr[pb.TenPhongBan].ToString();
                    phongban.GhiChu = dr[pb.GhiChu].ToString();
                    phongban.Deleted = (Boolean)dr[pb.Deleted];
                    arr.Add(phongban);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.PhongBan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.PhongBan)arr[i];
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


        public int InsertUpdate(Entities.PhongBan pb1)
        {
            try
            {
                pb = new Constants.PhongBan();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdatePhongBan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pb.HanhDong, SqlDbType.NVarChar, 20).Value = pb1.HanhDong;
                cmd.Parameters.Add(pb.PhongBanID, SqlDbType.Int).Value = pb1.PhongBanID;
                cmd.Parameters.Add(pb.MaPhongBan, SqlDbType.NVarChar, 20).Value = pb1.MaPhongBan;
                cmd.Parameters.Add(pb.TenPhongBan, SqlDbType.NVarChar, 200).Value = pb1.TenPhongBan;
                cmd.Parameters.Add(pb.GhiChu, SqlDbType.NVarChar, 100).Value = pb1.GhiChu;
                cmd.Parameters.Add(pb.Deleted, SqlDbType.Bit).Value = pb1.Deleted;

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
                string s = ex.Message;
                return 0;
            }
        }

        public void Delete(Entities.PhongBan pb1)
        {
            pb = new Constants.PhongBan();
            Sql = new Constants.Sql();
            string sql = Sql.DeletePhongBan;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(pb.HanhDong, SqlDbType.NVarChar, 20).Value = pb1.HanhDong;
            cmd.Parameters.Add(pb.PhongBanID, SqlDbType.Int).Value = pb1.PhongBanID;

            cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
        }
    }
}
