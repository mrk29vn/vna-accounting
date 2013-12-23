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
    public class TienTe
    {

        private Constants.TienTe tt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;

        private SqlConnection cn;

        public TienTe()
        {
            tt = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.TienTe[] Select()
        {

            Entities.TienTe[] arrC = null;
            try
            {
                tt = new Constants.TienTe();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllTienTe;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TienTe tiente = new Entities.TienTe();
                    tiente.TienteID = Convert.ToInt32(dr[tt.TienteID].ToString());
                    tiente.MaTienTe = dr[tt.MaTienTe].ToString();
                    tiente.TenTienTe = dr[tt.TenTienTe].ToString();
                    tiente.TenTienTeChan = dr[tt.TenTienTeChan].ToString();
                    tiente.TenTienTeLe = dr[tt.TenTienTeLe].ToString();
                    tiente.TenTienTe = dr[tt.TenTienTe].ToString();
                    tiente.BieuTuong = dr[tt.BieuTuong].ToString();
                    tiente.DonViLamTron = (int)dr[tt.DonViLamTron];
                    tiente.GhiChu = dr[tt.GhiChu].ToString();
                    tiente.Deleted = (Boolean)dr[tt.Deleted];
                    arr.Add(tiente);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TienTe[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TienTe)arr[i];
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

        public int InsertUpdate(Entities.TienTe tt1)
        {
            try
            {
                tt = new Constants.TienTe();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateTienTe;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tt.HanhDong, SqlDbType.NVarChar, 20).Value = tt1.HanhDong;
                cmd.Parameters.Add(tt.TienteID, SqlDbType.Int).Value = tt1.TienteID;
                cmd.Parameters.Add(tt.MaTienTe, SqlDbType.NVarChar, 20).Value = tt1.MaTienTe;
                cmd.Parameters.Add(tt.TenTienTe, SqlDbType.NVarChar, 200).Value = tt1.TenTienTe;
                cmd.Parameters.Add(tt.TenTienTeChan, SqlDbType.NVarChar, 200).Value = tt1.TenTienTeChan;
                cmd.Parameters.Add(tt.TenTienTeLe, SqlDbType.NVarChar, 200).Value = tt1.TenTienTeLe;
                cmd.Parameters.Add(tt.BieuTuong, SqlDbType.NVarChar, 20).Value = tt1.BieuTuong;
                cmd.Parameters.Add(tt.DonViLamTron, SqlDbType.Int).Value = tt1.DonViLamTron;
                cmd.Parameters.Add(tt.GhiChu, SqlDbType.NVarChar, 100).Value = tt1.GhiChu;
                cmd.Parameters.Add(tt.Deleted, SqlDbType.Bit).Value = tt1.Deleted;

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

        public void Delete(Entities.TienTe tt1)
        {
            try
            {
                tt = new Constants.TienTe();
                Entities.TienTe tiente = new Entities.TienTe();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteTienTe;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tt.HanhDong, SqlDbType.NVarChar, 20).Value = tt1.HanhDong;
                cmd.Parameters.Add(tt.TienteID, SqlDbType.Int).Value = tt1.TienteID;

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
