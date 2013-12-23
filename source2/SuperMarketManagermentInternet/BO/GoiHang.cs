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
    public class GoiHang
    {
        private Constants.GoiHang kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.GoiHang goihang;
        private SqlConnection cn;
        public GoiHang()
        {
            kh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            goihang = null;
            cn = null;
        }

        public Entities.GoiHang[] Select()
        {
            Entities.GoiHang[] list = null;
            try
            {
                string sql = Common.Constants.Sql.GoiHang.SelectGoiHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.GoiHang row = new Entities.GoiHang();
                    row.GoiHangID = Convert.ToInt32(dr[Common.Constants.GoiHang.GoiHangID].ToString());
                    row.MaKho = dr[Common.Constants.GoiHang.MaKho].ToString();
                    row.MaGoiHang = dr[Common.Constants.GoiHang.MaGoiHang].ToString();
                    row.TenGoiHang = dr[Common.Constants.GoiHang.TenGoiHang].ToString();
                    row.MaNhomHang = dr[Common.Constants.GoiHang.MaNhomHang].ToString();
                    row.TenNhomHang = dr[Common.Constants.GoiHang.TenNhomHang].ToString();
                    row.GiaNhap = dr[Common.Constants.GoiHang.GiaNhap].ToString();
                    row.GiaBanBuon = dr[Common.Constants.GoiHang.GiaBanBuon].ToString();
                    row.GiaBanLe = dr[Common.Constants.GoiHang.GiaBanLe].ToString();
                    row.Deleted = Boolean.Parse(dr[Common.Constants.GoiHang.Deleted].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.GoiHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.GoiHang)arr[i];
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

        public Entities.GoiHang[] Select(Entities.GoiHang hh)
        {
            Entities.GoiHang[] list = null;
            try
            {
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(Common.Constants.Sql.GoiHang.SelectTheoMaGoiHang, cn);
                cmd.Parameters.Add(Common.Constants.GoiHang.MaGoiHang, SqlDbType.VarChar, 50).Value = hh.MaGoiHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.GoiHang row = new Entities.GoiHang();
                    row.GoiHangID = int.Parse(dr[Common.Constants.GoiHang.GoiHangID].ToString());
                    row.MaKho = dr[Common.Constants.GoiHang.MaKho].ToString();
                    row.MaGoiHang = dr[Common.Constants.GoiHang.MaGoiHang].ToString();
                    row.TenGoiHang = dr[Common.Constants.GoiHang.TenGoiHang].ToString();
                    row.MaNhomHang = dr[Common.Constants.GoiHang.MaNhomHang].ToString();
                    row.TenNhomHang = dr[Common.Constants.GoiHang.TenNhomHang].ToString();
                    row.GiaBanBuon = dr[Common.Constants.GoiHang.GiaBanBuon].ToString();
                    row.GiaBanLe = dr[Common.Constants.GoiHang.GiaBanLe].ToString();
                    arr.Add(row);
                }
                if (arr.Count > 0)
                {
                    list = (Entities.GoiHang[])arr.ToArray(typeof(Entities.GoiHang));
                }
                else
                {
                    list = new Entities.GoiHang[0];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = new Entities.GoiHang[0]; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }
        public int InsertUpdate(Entities.GoiHang nhom)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(Common.Constants.Sql.GoiHang.InsertUpdateGoiHang, cn);
                cmd.Parameters.Add(Common.Constants.GoiHang.HanhDong, SqlDbType.NVarChar).Value = nhom.HanhDong;
                cmd.Parameters.Add(Common.Constants.GoiHang.GoiHangID, SqlDbType.Int).Value = nhom.GoiHangID;
                cmd.Parameters.Add(Common.Constants.GoiHang.MaKho, SqlDbType.VarChar, 20).Value = nhom.MaKho.ToUpper();
                cmd.Parameters.Add(Common.Constants.GoiHang.MaGoiHang, SqlDbType.VarChar, 50).Value = nhom.MaGoiHang.ToUpper();
                cmd.Parameters.Add(Common.Constants.GoiHang.TenGoiHang, SqlDbType.NVarChar, 200).Value = nhom.TenGoiHang;
                cmd.Parameters.Add(Common.Constants.GoiHang.MaNhomHang, SqlDbType.VarChar, 50).Value = nhom.MaNhomHang;
                cmd.Parameters.Add(Common.Constants.GoiHang.TenNhomHang, SqlDbType.NVarChar, 200).Value = nhom.TenNhomHang;
                cmd.Parameters.Add(Common.Constants.GoiHang.GiaNhap, SqlDbType.Float).Value = nhom.GiaNhap;
                cmd.Parameters.Add(Common.Constants.GoiHang.GiaBanBuon, SqlDbType.Float).Value = nhom.GiaBanBuon;
                cmd.Parameters.Add(Common.Constants.GoiHang.GiaBanLe, SqlDbType.Float).Value = nhom.GiaBanLe;
                cmd.Parameters.Add(Common.Constants.GoiHang.Deleted, SqlDbType.Bit).Value = nhom.Deleted;
                rt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); rt = 0; }
            return rt;
        }

        public int Delete(Entities.GoiHang nhom)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(Common.Constants.Sql.GoiHang.DeleteGoiHang, cn);
                cmd.Parameters.Add(Common.Constants.GoiHang.GoiHangID, SqlDbType.Int).Value = nhom.GoiHangID;
                rt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); rt = 0; }
            return rt;
        }
    }
}
