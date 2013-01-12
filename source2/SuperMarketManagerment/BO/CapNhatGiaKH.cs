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
    public class CapNhatGiaKH
    {

        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.CapNhatGiaKH kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.CapNhatGiaKhachHang khachhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public CapNhatGiaKH()
        {
            kh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khachhang = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.CapNhatGiaKhachHang[] Select(Entities.CapNhatGiaKhachHang ct)
        {

            Entities.CapNhatGiaKhachHang[] arrC = null;
            try
            {
                kh = new Constants.CapNhatGiaKH();
                Sql = new Constants.Sql();
                string sql = Sql.CapNhatGiaKH;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.MaKhachHang, SqlDbType.NVarChar, 20).Value = ct.MaKhachHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.CapNhatGiaKhachHang khachhang = new Entities.CapNhatGiaKhachHang();
                    khachhang.CapNhatGiaKhachHangID = Convert.ToInt32(dr[kh.CapNhatGiaKhachHangID].ToString());
                    khachhang.MaCapNhatGiaKhachHang = dr[kh.MaCapNhatGiaKhachHang].ToString();
                    khachhang.MaHangHoa = dr[kh.MaHangHoa].ToString();
                    khachhang.MaKhachHang = dr[kh.MaKhachHang].ToString();
                    khachhang.NgayBatDau = Convert.ToDateTime(dr[kh.NgayBatDau].ToString());
                    khachhang.NgayKetThuc = Convert.ToDateTime(dr[kh.NgayKetThuc].ToString());
                    khachhang.PhanTramChietKhau = float.Parse(dr[kh.PhanTramChietKhau].ToString());
                    khachhang.Deleted = Convert.ToBoolean(dr[kh.Deleted].ToString());
                    if (!khachhang.Deleted)
                        arr.Add(khachhang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.CapNhatGiaKhachHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.CapNhatGiaKhachHang)arr[i];
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

        public Entities.CapNhatGiaKhachHang[] Select()
        {

            Entities.CapNhatGiaKhachHang[] arrC = null;
            try
            {
                kh = new Constants.CapNhatGiaKH();
                Sql = new Constants.Sql();
                string sql = "Select * from CapNhatGiaKhachHang where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.CapNhatGiaKhachHang khachhang = new Entities.CapNhatGiaKhachHang();
                    khachhang.CapNhatGiaKhachHangID = Convert.ToInt32(dr[kh.CapNhatGiaKhachHangID].ToString());
                    khachhang.MaCapNhatGiaKhachHang = dr[kh.MaCapNhatGiaKhachHang].ToString();
                    khachhang.MaHangHoa = dr[kh.MaHangHoa].ToString();
                    khachhang.MaKhachHang = dr[kh.MaKhachHang].ToString();
                    khachhang.NgayBatDau = Convert.ToDateTime(dr[kh.NgayBatDau].ToString());
                    khachhang.NgayKetThuc = Convert.ToDateTime(dr[kh.NgayKetThuc].ToString());
                    khachhang.PhanTramChietKhau = float.Parse(dr[kh.PhanTramChietKhau].ToString());
                    khachhang.Deleted = Convert.ToBoolean(dr[kh.Deleted].ToString());
                    arr.Add(khachhang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.CapNhatGiaKhachHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.CapNhatGiaKhachHang)arr[i];
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
        public int InsertUpdate(Entities.CapNhatGiaKhachHang kh1)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.InsertCapNhatGiaKH;
                conn = new Connection();
                kh = new Constants.CapNhatGiaKH();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.CapNhatGiaKhachHangID, SqlDbType.Int).Value = kh1.CapNhatGiaKhachHangID;
                cmd.Parameters.Add(kh.MaCapNhatGiaKhachHang, SqlDbType.VarChar, 20).Value = kh1.MaCapNhatGiaKhachHang;
                cmd.Parameters.Add(kh.MaHangHoa, SqlDbType.VarChar, 50).Value = kh1.MaHangHoa;
                cmd.Parameters.Add(kh.MaKhachHang, SqlDbType.NVarChar, 20).Value = kh1.MaKhachHang;
                cmd.Parameters.Add(kh.NgayBatDau, SqlDbType.DateTime).Value = kh1.NgayBatDau;
                cmd.Parameters.Add(kh.NgayKetThuc, SqlDbType.DateTime).Value = kh1.NgayKetThuc;
                cmd.Parameters.Add(kh.PhanTramChietKhau, SqlDbType.Float).Value = kh1.PhanTramChietKhau;
                cmd.Parameters.Add(kh.Deleted, SqlDbType.Bit).Value = kh1.Deleted;
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

        /// <summary>
        /// Delete Bảng
        /// </summary>
        public int Delete(Entities.CapNhatGiaKhachHang kh1)
        {
            int Trave = 0;
            try
            {
                kh = new Constants.CapNhatGiaKH();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteCapNhatGiaKH;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.CapNhatGiaKhachHangID, SqlDbType.Int).Value = kh1.CapNhatGiaKhachHangID;
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
