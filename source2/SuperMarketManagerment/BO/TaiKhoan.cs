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
    public class TaiKhoan
    {
        //public static ArrayList TK = new ArrayList();

        private Constants.TaiKhoan tk;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.TaiKhoan taikhoan;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public TaiKhoan()
        {
            tk = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            taikhoan = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        /// 
        //public void LogOut(Entities.TaiKhoan tk1)
        //{
        //    if (tk1 == null)
        //        return;
        //    foreach (Object item in TK)
        //    {
        //        Entities.TaiKhoan temp = (Entities.TaiKhoan)item;
        //        if (temp.TenDangNhap.Equals(tk1.TenDangNhap))
        //        {
        //            TK.Remove(item);
        //            break;
        //        }

        //    }
        //}

        public Entities.TaiKhoan[] LogIn(Entities.TaiKhoan tk1)
        {

            Entities.TaiKhoan[] arrC = null;
            try
            {
                tk = new Constants.TaiKhoan();
                Sql = new Constants.Sql();
                string sql = Sql.LogIn;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tk.TenDangNhap, SqlDbType.NVarChar, 200).Value = tk1.TenDangNhap;
                cmd.Parameters.Add(tk.MatKhauDangNhap, SqlDbType.NVarChar, 200).Value = tk1.MatKhauDangNhap;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    taikhoan = new Entities.TaiKhoan();
                    taikhoan.TenDangNhap = dr[tk.TenDangNhap].ToString();
                    taikhoan.MatKhauDangNhap = dr[tk.MatKhauDangNhap].ToString();
                    taikhoan.KhoaTaiKhoan = (bool)dr[tk.KhoaTaiKhoan];
                    taikhoan.NhanVienID = dr[tk.NhanVienID].ToString();
                    taikhoan.Administrator = (bool)dr[tk.Administrator];
                    taikhoan.TenNhomQuyen = dr[tk.TenNhomQuyen].ToString();
                    taikhoan.TenNhanVien = dr[tk.TenNhanVien].ToString();
                    arr.Add(taikhoan);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TaiKhoan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TaiKhoan)arr[i];
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
            bool kt = true;
            
                return arrC;
        }

        public Entities.TaiKhoan[] selectTaiKhoan()
        {

            Entities.TaiKhoan[] arrC = null;
            try
            {
                tk = new Constants.TaiKhoan();
                Sql = new Constants.Sql();
                string sql = Sql.selectTaiKhoan;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    taikhoan = new Entities.TaiKhoan();
                    taikhoan.TenDangNhap = dr[tk.TenDangNhap].ToString();
                    taikhoan.MatKhauDangNhap = dr[tk.MatKhauDangNhap].ToString();
                    taikhoan.KhoaTaiKhoan = (bool)dr[tk.KhoaTaiKhoan];
                    taikhoan.NhanVienID = dr[tk.NhanVienID].ToString();
                    taikhoan.Administrator = (bool)dr[tk.Administrator];
                    taikhoan.TenNhomQuyen = dr[tk.TenNhomQuyen].ToString();
                    taikhoan.TenNhanVien = dr[tk.TenNhanVien].ToString();
                    arr.Add(taikhoan);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TaiKhoan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TaiKhoan)arr[i];
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

        public bool insertTaiKhoan(Entities.TaiKhoan tk1)
        {
            try
            {
                bool kt = false;
                tk = new Constants.TaiKhoan();
                Sql = new Constants.Sql();
                string sql = Sql.insertTaiKhoan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(tk.TenDangNhap, SqlDbType.VarChar, 200).Value = tk1.TenDangNhap;
                cmd.Parameters.Add(tk.MatKhauDangNhap, SqlDbType.VarChar, 200).Value = tk1.MatKhauDangNhap;
                cmd.Parameters.Add(tk.KhoaTaiKhoan, SqlDbType.Bit).Value = tk1.KhoaTaiKhoan;
                cmd.Parameters.Add(tk.NhanVienID, SqlDbType.VarChar, 20).Value = tk1.NhanVienID;
                cmd.Parameters.Add(tk.Administrator, SqlDbType.VarChar, 20).Value = tk1.Administrator;
                cmd.Parameters.Add(tk.TenNhomQuyen, SqlDbType.VarChar, 50).Value = tk1.TenNhomQuyen;

                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
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

        public bool updateTaiKhoan(Entities.TaiKhoan tk1)
        {
            try
            {
                bool kt = false;
                tk = new Constants.TaiKhoan();
                Sql = new Constants.Sql();
                string sql = Sql.updateTaiKhoan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(tk.TenDangNhap, SqlDbType.VarChar, 200).Value = tk1.TenDangNhap;
                cmd.Parameters.Add(tk.MatKhauDangNhap, SqlDbType.VarChar, 200).Value = tk1.MatKhauDangNhap;
                cmd.Parameters.Add(tk.KhoaTaiKhoan, SqlDbType.Bit).Value = tk1.KhoaTaiKhoan;
                cmd.Parameters.Add(tk.NhanVienID, SqlDbType.VarChar, 20).Value = tk1.NhanVienID;
                cmd.Parameters.Add(tk.Administrator, SqlDbType.VarChar, 20).Value = tk1.Administrator;
                cmd.Parameters.Add(tk.TenNhomQuyen, SqlDbType.VarChar, 50).Value = tk1.TenNhomQuyen;

                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
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
        public bool deleteTaiKhoan(Entities.TaiKhoan tk1)
        {
            try
            {
                bool kt = false;
                tk = new Constants.TaiKhoan();
                Sql = new Constants.Sql();
                string sql = Sql.deleteTaiKhoan;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(tk.TenDangNhap, SqlDbType.VarChar, 200).Value = tk1.TenDangNhap;

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
