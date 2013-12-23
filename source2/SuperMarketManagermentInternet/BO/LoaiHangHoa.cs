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
    public class LoaiHangHoa
    {
        private Constants.LoaiHangHoa lhh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.LoaiHangHoa loaihanghoa;
        private SqlConnection cn;

        public LoaiHangHoa()
        {
            lhh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            loaihanghoa = null;
            cn = null;
        }
        //Entities
        public Entities.LoaiHangHoa[] sp_SelectLoaiHangHoasAll()
        {

            Entities.LoaiHangHoa[] arrC = null;
            try
            {
                lhh = new Constants.LoaiHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllLoaiHangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    loaihanghoa = new Entities.LoaiHangHoa();
                    loaihanghoa.LoaiHangID = Convert.ToInt32(dr[lhh.LoaiHangID].ToString());
                    loaihanghoa.MaLoaiHang = dr[lhh.MaLoaiHang].ToString();
                    loaihanghoa.TenLoaiHang = dr[lhh.TenLoaiHang].ToString();
                    loaihanghoa.GhiChu = dr[lhh.GhiChu].ToString();
                    loaihanghoa.Deleted = (Boolean)dr[lhh.Deleted];
                    arr.Add(loaihanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LoaiHangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LoaiHangHoa)arr[i];
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

        public Entities.LoaiHangHoa[] Select()
        {

            Entities.LoaiHangHoa[] arrC = null;
            try
            {
                lhh = new Constants.LoaiHangHoa();
                Sql = new Constants.Sql();
                string sql = "Select * from LoaiHang where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    loaihanghoa = new Entities.LoaiHangHoa();
                    loaihanghoa.LoaiHangID = Convert.ToInt32(dr[lhh.LoaiHangID].ToString());
                    loaihanghoa.MaLoaiHang = dr[lhh.MaLoaiHang].ToString();
                    loaihanghoa.TenLoaiHang = dr[lhh.TenLoaiHang].ToString();
                    loaihanghoa.GhiChu = dr[lhh.GhiChu].ToString();
                    loaihanghoa.Deleted = (Boolean)dr[lhh.Deleted];
                    arr.Add(loaihanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LoaiHangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LoaiHangHoa)arr[i];
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
        public int InsertUpdate(Entities.LoaiHangHoa lhh1)
        {
            try
            {
                lhh = new Constants.LoaiHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateLoaiHangHoa;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(lhh.HanhDong, SqlDbType.NVarChar, 20).Value = lhh1.HanhDong;
                cmd.Parameters.Add(lhh.LoaiHangID, SqlDbType.Int).Value = lhh1.LoaiHangID;
                cmd.Parameters.Add(lhh.MaLoaiHang, SqlDbType.NVarChar, 20).Value = lhh1.MaLoaiHang;
                cmd.Parameters.Add(lhh.TenLoaiHang, SqlDbType.NVarChar, 200).Value = lhh1.TenLoaiHang;
                cmd.Parameters.Add(lhh.GhiChu, SqlDbType.NVarChar, 250).Value = lhh1.GhiChu;
                cmd.Parameters.Add(lhh.Deleted, SqlDbType.Bit).Value = lhh1.Deleted;

                int i = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return i;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        //delete
        public void Delete(Entities.LoaiHangHoa lhh1)
        {
                lhh = new Constants.LoaiHangHoa();
                Entities.LoaiHangHoa loaihanghoa = new Entities.LoaiHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteLoaiHangHoa;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(lhh.HanhDong, SqlDbType.NVarChar, 20).Value = lhh1.HanhDong;
                cmd.Parameters.Add(lhh.LoaiHangID, SqlDbType.Int).Value = lhh1.LoaiHangID;

                cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
        }

    }
}
