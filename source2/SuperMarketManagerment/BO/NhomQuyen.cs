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
    public class NhomQuyen
    {
        private Constants.NhomQuyen nq;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.NhomQuyen nhomquyen;
        private SqlConnection cn;

        public NhomQuyen()
        {
            nq=null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            nhomquyen = null;
            cn = null;
        }
        public Entities.NhomQuyen[] selectNhomQuyen()
        {

            Entities.NhomQuyen[] arrC = null;
            try
            {
                nq = new Constants.NhomQuyen();
                Sql = new Constants.Sql();
                string sql = Sql.selectNhomQuyen;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    nhomquyen = new Entities.NhomQuyen();
                    nhomquyen.NhomQuyenID = Convert.ToInt32( dr[nq.NhomQuyenID].ToString());
                    nhomquyen.TenNhomQuyen = dr[nq.TenNhomQuyen].ToString();
                    nhomquyen.isDeleted = (bool)dr[nq.isDeleted];
                    arr.Add(nhomquyen);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhomQuyen[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhomQuyen)arr[i];
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

        public bool insertNhomQuyen(Entities.NhomQuyen nq1)
        {
            try
            {
                bool kt = false;
                nq = new Constants.NhomQuyen();
                Sql = new Constants.Sql();
                string sql = Sql.insertNhomQuyen;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(nq.TenNhomQuyen, SqlDbType.VarChar, 50).Value = nq1.TenNhomQuyen;

                int i = cmd.ExecuteNonQuery();
                if (i >=1)
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
        public bool deleteNhomQuyen(Entities.NhomQuyen nq1)
        {
            try
            {
                bool kt = false;
                nq = new Constants.NhomQuyen();
                Sql = new Constants.Sql();
                string sql = Sql.deleteNhomQuyen;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(nq.TenNhomQuyen, SqlDbType.VarChar, 50).Value = nq1.TenNhomQuyen;

                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
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
