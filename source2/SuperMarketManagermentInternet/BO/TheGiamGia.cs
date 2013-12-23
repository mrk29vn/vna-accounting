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

    public class TheGiamGia
    {
        private Constants.TheGiamGia pb;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public Entities.TheGiamGia[] Select()
        {

            Entities.TheGiamGia[] arrC = null;
            try
            {
                pb = new Constants.TheGiamGia();
                Sql = new Constants.Sql();
                string sql = Sql.SelectTheGiamGia;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TheGiamGia TheGiamGia = new Entities.TheGiamGia();
                    TheGiamGia.MaTheGiamGia = dr[pb.MaTheGiamGia].ToString();
                    TheGiamGia.MaKhachHang = dr[pb.MaKhachHang].ToString();
                    TheGiamGia.GiaTriThe = dr[pb.GiaTriThe].ToString();
                    TheGiamGia.GiaTriConLai = dr[pb.GiaTriConLai].ToString();
                    TheGiamGia.NgayBatDau = DateTime.Parse(dr[pb.NgayBatDau].ToString());
                    TheGiamGia.NgayKetThuc = DateTime.Parse(dr[pb.NgayKetThuc].ToString());
                    TheGiamGia.Deleted = (Boolean)dr[pb.Deleted];
                    arr.Add(TheGiamGia);
                }
                int n = arr.Count;
                if (n == 0) { arrC = new Entities.TheGiamGia[0]; }
                arrC = new Entities.TheGiamGia[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TheGiamGia)arr[i];
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

        public int Insert(Entities.TheGiamGia pb1)
        {
            try
            {
                pb = new Constants.TheGiamGia();
                Sql = new Constants.Sql();
                string sql = Sql.InsertTheGiamGia;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pb.HanhDong, SqlDbType.NVarChar, 50).Value = pb1.HanhDong;
                cmd.Parameters.Add(pb.MaTheGiamGia, SqlDbType.VarChar, 50).Value = pb1.MaTheGiamGia;
                cmd.Parameters.Add(pb.MaKhachHang, SqlDbType.VarChar, 50).Value = pb1.MaKhachHang;
                cmd.Parameters.Add(pb.GiaTriThe, SqlDbType.Float).Value = pb1.GiaTriThe;
                cmd.Parameters.Add(pb.NgayBatDau, SqlDbType.DateTime).Value = pb1.NgayBatDau;
                cmd.Parameters.Add(pb.NgayKetThuc, SqlDbType.DateTime).Value = pb1.NgayKetThuc;
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

        public int Update(Entities.TheGiamGia pb1)
        {
            try
            {
                pb = new Constants.TheGiamGia();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateTheGiamGia;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pb.MaTheGiamGia, SqlDbType.VarChar, 50).Value = pb1.MaTheGiamGia;
                cmd.Parameters.Add(pb.GiaTriConLai, SqlDbType.Float).Value = pb1.GiaTriConLai;

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

        public int Delete(Entities.TheGiamGia pb1)
        {
            try
            {
                pb = new Constants.TheGiamGia();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteTheGiamGia;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pb.MaTheGiamGia, SqlDbType.VarChar, 50).Value = pb1.MaTheGiamGia;

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
    }
}
