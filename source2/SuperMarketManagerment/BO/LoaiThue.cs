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
    public class LoaiThue
    {
        private Constants.LoaiThue lt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.LoaiThue loaithue;
        private SqlConnection cn;

        public LoaiThue()
        {
            lt = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            loaithue = null;
            cn = null;
        }
        //Entities
        public Entities.LoaiThue[] sp_SelectLoaiThuesAll()
        {

            Entities.LoaiThue[] arrC = null;
            try
            {
                lt = new Constants.LoaiThue();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllLoaiThue;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    loaithue = new Entities.LoaiThue();
                    loaithue.LoaiThueID = Convert.ToInt32(dr[lt.LoaiThueID].ToString());
                    loaithue.MaLoaiThue = dr[lt.MaLoaiThue].ToString();
                    loaithue.TenLoaiThue = dr[lt.TenLoaiThue].ToString();
                    loaithue.GhiChu = dr[lt.GhiChu].ToString();
                    loaithue.Deleted = (Boolean)dr[lt.Deleted];
                    arr.Add(loaithue);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LoaiThue[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LoaiThue)arr[i];
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
        public int InsertUpdate(Entities.LoaiThue lt1)
        {
            lt = new Constants.LoaiThue();
            Sql = new Constants.Sql();
            string sql = Sql.InsertUpdateLoaiThue;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(lt.HanhDong, SqlDbType.NVarChar, 20).Value = lt1.HanhDong;
            cmd.Parameters.Add(lt.LoaiThueID, SqlDbType.Int).Value = lt1.LoaiThueID;
            cmd.Parameters.Add(lt.MaLoaiThue, SqlDbType.NVarChar, 20).Value = lt1.MaLoaiThue;
            cmd.Parameters.Add(lt.TenLoaiThue, SqlDbType.NVarChar, 200).Value = lt1.TenLoaiThue;
            cmd.Parameters.Add(lt.GhiChu, SqlDbType.NVarChar, 100).Value = lt1.GhiChu;
            cmd.Parameters.Add(lt.Deleted, SqlDbType.Bit).Value = lt1.Deleted;

            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return i;
        }
        //delete
        public void Delete(Entities.LoaiThue LoaiThue)
        {
            lt = new Constants.LoaiThue();
            Entities.LoaiThue loaithue = new Entities.LoaiThue();
            Sql = new Constants.Sql();
            string sql = Sql.DeleteLoaiThue;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(lt.HanhDong, SqlDbType.NVarChar, 20).Value = LoaiThue.HanhDong;
            cmd.Parameters.Add(lt.LoaiThueID, SqlDbType.Int).Value = LoaiThue.LoaiThueID;

            cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
        }
    }
}
