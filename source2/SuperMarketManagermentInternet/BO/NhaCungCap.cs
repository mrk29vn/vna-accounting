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
   public class NhaCungCap
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.NhaCungCap ncc;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.NhaCungCap nhacungcap;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public NhaCungCap()
        {
            ncc = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            nhacungcap = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.NhaCungCap[] Select()
        {

            Entities.NhaCungCap[] arrC = null;
            try
            {
                ncc = new Constants.NhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.SelectNhaCungCapsAll;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
            while (dr.Read())
            {
                Entities.NhaCungCap nhacungcap= new Entities.NhaCungCap();
                nhacungcap.NhaCungCapID = Convert.ToInt32(dr[ncc.NhaCungCapID].ToString());
                nhacungcap.MaNhaCungCap = dr[ncc.MaNhaCungCap].ToString();
                nhacungcap.TenNhaCungCap = dr[ncc.TenNhaCungCap].ToString();
                nhacungcap.DiaChi = dr[ncc.DiaChi].ToString();
                nhacungcap.DienThoai = dr[ncc.DienThoai].ToString();
                nhacungcap.Email = dr[ncc.Email].ToString();
                nhacungcap.Fax = dr[ncc.Fax].ToString();
                nhacungcap.NguoiLienHe = dr[ncc.NguoiLienHe].ToString();
                nhacungcap.MST = dr[ncc.MST].ToString();
                nhacungcap.DuNo = dr[ncc.DuNo].ToString();
                nhacungcap.Website=dr[ncc.Website].ToString();
                nhacungcap.GhiChu = dr[ncc.GhiChu].ToString();
                nhacungcap.Deleted = Convert.ToBoolean( dr[ncc.Deleted].ToString());
                arr.Add(nhacungcap);
            }
            int n = arr.Count;
            if (n == 0) { return null; }
            arrC = new Entities.NhaCungCap[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.NhaCungCap)arr[i];
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

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.NhaCungCap[] Select(string Cot, string Kieu, string Giatri)
        {

            Entities.NhaCungCap[] arrC = null;
            try
            {
                ncc = new Constants.NhaCungCap();
                Sql = new Constants.Sql();
                string sql = "";
                if (Kieu == "like")
                    sql = "select * from NhaCungCap where " + Cot + " " + Kieu + " '%" + Giatri + "%'";
                else
                    sql = "select * from NhaCungCap where " + Cot + " " + Kieu + " '" + Giatri + "'";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.NhaCungCap nhacungcap = new Entities.NhaCungCap();
                    nhacungcap.NhaCungCapID = Convert.ToInt32(dr[ncc.NhaCungCapID].ToString());
                    nhacungcap.MaNhaCungCap = dr[ncc.MaNhaCungCap].ToString();
                    nhacungcap.TenNhaCungCap = dr[ncc.TenNhaCungCap].ToString();
                    nhacungcap.DiaChi = dr[ncc.DiaChi].ToString();
                    nhacungcap.DienThoai = dr[ncc.DienThoai].ToString();
                    nhacungcap.Email = dr[ncc.Email].ToString();
                    nhacungcap.Fax = dr[ncc.Fax].ToString();
                    nhacungcap.NguoiLienHe = dr[ncc.NguoiLienHe].ToString();
                    nhacungcap.MST = dr[ncc.MST].ToString();
                    nhacungcap.DuNo = dr[ncc.DuNo].ToString();
                    nhacungcap.Website = dr[ncc.Website].ToString();
                    nhacungcap.GhiChu = dr[ncc.GhiChu].ToString();
                    nhacungcap.Deleted = Convert.ToBoolean(dr[ncc.Deleted].ToString());
                    arr.Add(nhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhaCungCap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhaCungCap)arr[i];
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

        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public int InsertUpdate(Entities.NhaCungCap ncc1)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateNhaCungCap;
                conn = new Connection();
                ncc = new Constants.NhaCungCap();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ncc.HanhDong, SqlDbType.NVarChar, 20).Value = ncc1.HanhDong;
                cmd.Parameters.Add(ncc.NhaCungCapID, SqlDbType.Int).Value =ncc1. NhaCungCapID;
                cmd.Parameters.Add(ncc.MaNhaCungCap, SqlDbType.NVarChar, 20).Value =ncc1. MaNhaCungCap;
                cmd.Parameters.Add(ncc.TenNhaCungCap, SqlDbType.NVarChar, 200).Value =ncc1. TenNhaCungCap;
                cmd.Parameters.Add(ncc.DiaChi, SqlDbType.NVarChar, 200).Value =ncc1. DiaChi;
                cmd.Parameters.Add(ncc.DienThoai, SqlDbType.NVarChar, 20).Value =ncc1. DienThoai;
                cmd.Parameters.Add(ncc.Email, SqlDbType.NVarChar, 50).Value =ncc1. Email;
                cmd.Parameters.Add(ncc.Fax, SqlDbType.NVarChar, 20).Value =ncc1. Fax;
                cmd.Parameters.Add(ncc.NguoiLienHe, SqlDbType.NVarChar, 200).Value =ncc1. NguoiLienHe;
                cmd.Parameters.Add(ncc.MST, SqlDbType.NVarChar, 20).Value =ncc1. MST;
                cmd.Parameters.Add(ncc.DuNo, SqlDbType.Float).Value =ncc1. DuNo;
                cmd.Parameters.Add(ncc.Website, SqlDbType.NVarChar, 200).Value=ncc1.Website;
                cmd.Parameters.Add(ncc.GhiChu, SqlDbType.NVarChar, 200).Value =ncc1. GhiChu;
                cmd.Parameters.Add(ncc.Deleted, SqlDbType.Bit).Value =ncc1. Deleted;
                Trave = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;   
        }

        public bool UpdateDuNo(Entities.NhaCungCap ncc1)
        {
            bool kt = false;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.UpdateDuNoNCC;
                conn = new Connection();
                ncc = new Constants.NhaCungCap();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ncc.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ncc1.MaNhaCungCap;
                cmd.Parameters.Add(ncc.DuNo, SqlDbType.Float).Value = ncc1.DuNo;
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                return kt;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); return false; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
        }

        public bool UpdateDuNoNCC(Entities.NhaCungCap ncc1)
        {
            bool kt = false;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.UpdateDuNoNCCC;
                conn = new Connection();
                ncc = new Constants.NhaCungCap();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ncc.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ncc1.MaNhaCungCap;
                cmd.Parameters.Add(ncc.DuNo, SqlDbType.Float).Value = ncc1.DuNo;
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                return kt;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); return false; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
        }
        /// <summary>
        /// Delete Bảng
        /// </summary>
        public int Delete(Entities.NhaCungCap ncc1)
        {

            int Trave = 0;
            try
            {
                ncc = new Constants.NhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ncc.HanhDong, SqlDbType.NVarChar, 20).Value =ncc1. HanhDong;
                cmd.Parameters.Add(ncc.NhaCungCapID, SqlDbType.Int).Value = ncc1.NhaCungCapID;
                Trave = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }
    }
}
