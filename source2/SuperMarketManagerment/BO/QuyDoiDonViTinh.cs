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
    public class QuyDoiDonViTinh
    {
        private Constants.Sql.QuyDoiDonViTinh kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.QuyDoiDonViTinh goihang;
        private SqlConnection cn;
        public QuyDoiDonViTinh()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.QuyDoiDonViTinh[] Select()
        {
            Entities.QuyDoiDonViTinh[] list = null;
            try
            {
                string sql = Common.Constants.Sql.QuyDoiDonViTinh.SelectQuyDoiDonViTinh;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.QuyDoiDonViTinh row = new Entities.QuyDoiDonViTinh();
                    row.QuyDoiDonViTinhID = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.QuyDoiDonViTinhID].ToString());
                    row.MaQuyDoiDonViTinh = dr[Common.Constants.QuyDoiDonViTinh.MaQuyDoiDonViTinh].ToString();
                    row.MaHangQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaHangQuyDoi].ToString();
                    row.TenHangQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.TenHangQuyDoi].ToString();
                    row.MaDonViTinh = dr[Common.Constants.QuyDoiDonViTinh.MaDonViTinh].ToString();
                    row.SoLuongQuyDoi = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.SoLuongQuyDoi].ToString());
                    row.MaHangDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaHangDuocQuyDoi].ToString();
                    row.TenHangDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.TenHangDuocQuyDoi].ToString();
                    row.MaDonViTinhDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaDonViTinhDuocQuyDoi].ToString();
                    row.SoLuongDuocQuyDoi = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.SoLuongDuocQuyDoi].ToString());
                    row.Deleted = Boolean.Parse(dr[Common.Constants.QuyDoiDonViTinh.Deleted].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.QuyDoiDonViTinh[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.QuyDoiDonViTinh)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }

        public Entities.QuyDoiDonViTinh[] TimQuyDoi(Entities.QuyDoiDonViTinh giatri)
        {
            Entities.QuyDoiDonViTinh[] list = null;
            try
            {
                string sql = Common.Constants.Sql.QuyDoiDonViTinh.TimQuyDoi;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaDonViTinh, SqlDbType.NVarChar, 50).Value = giatri.MaDonViTinh;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaHangQuyDoi, SqlDbType.NVarChar, 50).Value = giatri.MaHangQuyDoi;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.QuyDoiDonViTinh row = new Entities.QuyDoiDonViTinh();
                    row.QuyDoiDonViTinhID = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.QuyDoiDonViTinhID].ToString());
                    row.MaQuyDoiDonViTinh = dr[Common.Constants.QuyDoiDonViTinh.MaQuyDoiDonViTinh].ToString();
                    row.MaHangQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaHangQuyDoi].ToString();
                    row.TenHangQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.TenHangQuyDoi].ToString();
                    row.MaDonViTinh = dr[Common.Constants.QuyDoiDonViTinh.MaDonViTinh].ToString();
                    row.SoLuongQuyDoi = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.SoLuongQuyDoi].ToString());
                    row.MaHangDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaHangDuocQuyDoi].ToString();
                    row.TenHangDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.TenHangDuocQuyDoi].ToString();
                    row.MaDonViTinhDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaDonViTinhDuocQuyDoi].ToString();
                    row.SoLuongDuocQuyDoi = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.SoLuongDuocQuyDoi].ToString());
                    row.Deleted = Boolean.Parse(dr[Common.Constants.QuyDoiDonViTinh.Deleted].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.QuyDoiDonViTinh[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.QuyDoiDonViTinh)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }
        public Entities.QuyDoiDonViTinh[] Select(Entities.QuyDoiDonViTinh hh)
        {
            Entities.QuyDoiDonViTinh[] list = null;
            try
            {
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(Common.Constants.Sql.QuyDoiDonViTinh.SelectQuyDoiDonViTinhTheoMa, cn);
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaHangDuocQuyDoi, SqlDbType.NVarChar, 50).Value = hh.MaHangDuocQuyDoi;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.QuyDoiDonViTinh row = new Entities.QuyDoiDonViTinh();
                    row.QuyDoiDonViTinhID = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.QuyDoiDonViTinhID].ToString());
                    row.MaQuyDoiDonViTinh = dr[Common.Constants.QuyDoiDonViTinh.MaQuyDoiDonViTinh].ToString();
                    row.MaHangQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaHangQuyDoi].ToString();
                    row.TenHangQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.TenHangQuyDoi].ToString();
                    row.MaDonViTinh = dr[Common.Constants.QuyDoiDonViTinh.MaDonViTinh].ToString();
                    row.SoLuongQuyDoi = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.SoLuongQuyDoi].ToString());
                    row.MaHangDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaHangDuocQuyDoi].ToString();
                    row.TenHangDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.TenHangDuocQuyDoi].ToString();
                    row.MaDonViTinhDuocQuyDoi = dr[Common.Constants.QuyDoiDonViTinh.MaDonViTinhDuocQuyDoi].ToString();
                    row.SoLuongDuocQuyDoi = int.Parse(dr[Common.Constants.QuyDoiDonViTinh.SoLuongDuocQuyDoi].ToString());
                    row.Deleted = Boolean.Parse(dr[Common.Constants.QuyDoiDonViTinh.Deleted].ToString());
                    arr.Add(row);
                }
                if (arr.Count > 0)
                {
                    list = (Entities.QuyDoiDonViTinh[])arr.ToArray(typeof(Entities.QuyDoiDonViTinh));
                }
                else
                {
                    list = new Entities.QuyDoiDonViTinh[0];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = new Entities.QuyDoiDonViTinh[0]; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }
        public int InsertUpdate(Entities.QuyDoiDonViTinh nhom)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(Common.Constants.Sql.QuyDoiDonViTinh.InsertUpdateQuyDoiDonViTinh, cn);
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.HanhDong, SqlDbType.NVarChar).Value = nhom.HanhDong;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.QuyDoiDonViTinhID, SqlDbType.Int).Value = nhom.QuyDoiDonViTinhID;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaQuyDoiDonViTinh, SqlDbType.NVarChar, 50).Value = nhom.MaQuyDoiDonViTinh;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaHangQuyDoi, SqlDbType.NVarChar, 50).Value = nhom.MaHangQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.TenHangQuyDoi, SqlDbType.NVarChar, 200).Value = nhom.TenHangQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaDonViTinh, SqlDbType.NVarChar, 50).Value = nhom.MaDonViTinh;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.SoLuongQuyDoi, SqlDbType.Int).Value = nhom.SoLuongQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaHangDuocQuyDoi, SqlDbType.NVarChar, 50).Value = nhom.MaHangDuocQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.TenHangDuocQuyDoi, SqlDbType.NVarChar, 200).Value = nhom.TenHangDuocQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.MaDonViTinhDuocQuyDoi, SqlDbType.NVarChar, 50).Value = nhom.MaDonViTinhDuocQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.SoLuongDuocQuyDoi, SqlDbType.Int).Value = nhom.SoLuongDuocQuyDoi;
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.Deleted, SqlDbType.Bit).Value = nhom.Deleted;
                rt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); rt = 0; }
            return rt;
        }

        public int Delete(Entities.QuyDoiDonViTinh nhom)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(Common.Constants.Sql.QuyDoiDonViTinh.DeleteQuyDoiDonViTinh, cn);
                cmd.Parameters.Add(Common.Constants.QuyDoiDonViTinh.QuyDoiDonViTinhID, SqlDbType.Int).Value = nhom.QuyDoiDonViTinhID;
                rt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); rt = 0; }
            return rt;
        }
    }
}
