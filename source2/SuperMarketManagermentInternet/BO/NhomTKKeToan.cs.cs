using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace BizLogic
{
    public class NhomTKKeToan1
    {
        private Constants.NhomTKKeToan ntkkt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public NhomTKKeToan1()
        {
            ntkkt = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.NhomTKKeToan[] Select()
        {

            Entities.NhomTKKeToan[] arrC = null;
            try
            {
                ntkkt = new Constants.NhomTKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllNhomTKKeToan;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.NhomTKKeToan nhomtkketoan = new Entities.NhomTKKeToan();
                    nhomtkketoan.NhomTKKeToanID = Convert.ToInt32(dr[ntkkt.NhomTKKeToanID].ToString());
                    nhomtkketoan.MaNhomTKKeToan = dr[ntkkt.MaNhomTKKeToan].ToString();
                    nhomtkketoan.TenNhomTKKeToan = dr[ntkkt.TenNhomTKKeToan].ToString();
                    nhomtkketoan.GhiChu = dr[ntkkt.GhiChu].ToString();
                    nhomtkketoan.Delete = (Boolean)dr[ntkkt.Deleted];
                    arr.Add(nhomtkketoan);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhomTKKeToan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhomTKKeToan)arr[i];
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


        public int InsertUpdate(Entities.NhomTKKeToan pb1)
        {
            try
            {
                ntkkt = new Constants.NhomTKKeToan();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateNhomTKKeToan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ntkkt.HanhDong, SqlDbType.NVarChar, 20).Value = pb1.HanhDong;
                cmd.Parameters.Add(ntkkt.NhomTKKeToanID, SqlDbType.Int).Value = pb1.NhomTKKeToanID;
                cmd.Parameters.Add(ntkkt.MaNhomTKKeToan, SqlDbType.NVarChar, 20).Value = pb1.MaNhomTKKeToan;
                cmd.Parameters.Add(ntkkt.TenNhomTKKeToan, SqlDbType.NVarChar, 200).Value = pb1.TenNhomTKKeToan;
                cmd.Parameters.Add(ntkkt.GhiChu, SqlDbType.NVarChar, 100).Value = pb1.GhiChu;
                cmd.Parameters.Add(ntkkt.Deleted, SqlDbType.Bit).Value = pb1.Delete;

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

        public void Delete(Entities.NhomTKKeToan pb1)
        {
            ntkkt = new Constants.NhomTKKeToan();
            Sql = new Constants.Sql();
            string sql = Sql.DeleteNhomTKKeToan;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(ntkkt.HanhDong, SqlDbType.NVarChar, 20).Value = pb1.HanhDong;
            cmd.Parameters.Add(ntkkt.NhomTKKeToanID, SqlDbType.Int).Value = pb1.NhomTKKeToanID;

            cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
        }
    }
}
