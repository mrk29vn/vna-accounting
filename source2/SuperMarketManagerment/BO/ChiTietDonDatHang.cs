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
    public class ChiTietDonDatHang
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ChiTietDonDatHang dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietDonDatHang dondathang;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietDonDatHang()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            dondathang = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietDonDatHang[] sp_LayBang_ChiTietDonDatHang()
        {
            Entities.ChiTietDonDatHang[] arrC = null;
            try
            {
                dh = new Constants.ChiTietDonDatHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ChiTietDonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ChiTietDonDatHang();
                    dondathang.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    dondathang.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    dondathang.TenHangHoa = dr["TenHangHoa"].ToString();
                    dondathang.SoLuong = int.Parse(0+dr[dh.SoLuong].ToString());
                    dondathang.DonGia = Double.Parse(0+dr[dh.DonGia].ToString()).ToString();
                    dondathang.Thue = Double.Parse(0 + dr[dh.Thue].ToString()).ToString();
                    dondathang.PhanTramChietKhau = Double.Parse(0+dr[dh.PhanTramChietKhau].ToString()).ToString();
                    dondathang.GhiChu = ""+dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietDonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietDonDatHang)arr[i];
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

        public Entities.ChiTietDonDatHang[] Select()
        {
            Entities.ChiTietDonDatHang[] arrC = null;
            try
            {
                dh = new Constants.ChiTietDonDatHang();
                Sql = new Constants.Sql();
                string sql = "Select * from ChiTietDonHang where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ChiTietDonDatHang();
                    dondathang.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    dondathang.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    dondathang.SoLuong = int.Parse(0 + dr[dh.SoLuong].ToString());
                    dondathang.DonGia = Double.Parse(0 + dr[dh.DonGia].ToString()).ToString();
                    dondathang.Thue = Double.Parse(0 + dr[dh.Thue].ToString()).ToString();
                    dondathang.PhanTramChietKhau = Double.Parse(0 + dr[dh.PhanTramChietKhau].ToString()).ToString();
                    dondathang.GhiChu = "" + dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietDonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietDonDatHang)arr[i];
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

        public Entities.ChiTietDonDatHang[] Select(string maDonDatHang)
        {
            Entities.ChiTietDonDatHang[] arrC = null;
            try
            {
                dh = new Constants.ChiTietDonDatHang();
                Sql = new Constants.Sql();
                string sql = "Select * from ChiTietDonHang where MaDonDatHang ='" + maDonDatHang+"'";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ChiTietDonDatHang();
                    dondathang.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    dondathang.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    dondathang.TenHangHoa = dr["TenHangHoa"].ToString();
                    dondathang.SoLuong = int.Parse(0 + dr[dh.SoLuong].ToString());
                    dondathang.DonGia = Double.Parse(0 + dr[dh.DonGia].ToString()).ToString();
                    dondathang.Thue = Double.Parse(0 + dr[dh.Thue].ToString()).ToString();
                    dondathang.PhanTramChietKhau = Double.Parse(0 + dr[dh.PhanTramChietKhau].ToString()).ToString();
                    dondathang.GhiChu = "" + dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietDonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietDonDatHang)arr[i];
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
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int sp_XuLy_ChiTietDonDatHang(Entities.ChiTietDonDatHang ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_ChiTietDonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.ChiTietDonDatHang();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaDonDatHang, SqlDbType.NVarChar, 20).Value = ddh.MaDonDatHang;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.NVarChar).Value = ddh.MaHangHoa;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar,200).Value = ddh.TenHangHoa;
                cmd.Parameters.Add(dh.SoLuong, SqlDbType.Int).Value = ddh.SoLuong;
                cmd.Parameters.Add(dh.DonGia, SqlDbType.Float, 20).Value = ddh.DonGia;
                cmd.Parameters.Add(dh.Thue, SqlDbType.Float, 20).Value = ddh.Thue;
                cmd.Parameters.Add(dh.PhanTramChietKhau, SqlDbType.Float, 20).Value = ddh.PhanTramChietKhau;
                cmd.Parameters.Add(dh.GhiChu, SqlDbType.NVarChar).Value = ddh.GhiChu;
                cmd.Parameters.Add(dh.Deleted, SqlDbType.Bit).Value = ddh.Deleted;
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
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int LuuLai(Entities.ChiTietDonDatHang[] ddh)
        {
            int Trave = 0;
            Entities.ChiTietDonDatHang tl = new Entities.ChiTietDonDatHang();
            for (int i = 0; i < ddh.Length; i++)
            {
                tl.Hanhdong = ddh[i].Hanhdong;
                tl.MaDonDatHang = ddh[i].MaDonDatHang;
                tl.MaHangHoa = ddh[i].MaHangHoa;
                tl.TenHangHoa = ddh[i].TenHangHoa;
                tl.SoLuong = ddh[i].SoLuong;
                tl.DonGia = ddh[i].DonGia;
                tl.Thue = ddh[i].Thue;
                tl.PhanTramChietKhau = ddh[i].PhanTramChietKhau;
                tl.GhiChu = ddh[i].GhiChu;
                tl.Deleted = ddh[i].Deleted;
                Trave = sp_XuLy_ChiTietDonDatHang(tl);
            }
            return Trave;
        }
        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int LuuLai(Entities.ChiTietHoaDonNhap[] ddh)
        {
            int Trave = 0;
            Entities.ChiTietHoaDonNhap tl = new Entities.ChiTietHoaDonNhap();
            for (int i = 0; i < ddh.Length; i++)
            {
                tl.Hanhdong = ddh[i].Hanhdong;
                tl.MaHoaDonNhap = ddh[i].MaHoaDonNhap;
                tl.MaHangHoa = ddh[i].MaHangHoa;
                tl.SoLuong = ddh[i].SoLuong;
                tl.DonGia = ddh[i].DonGia;
                tl.Thue = ddh[i].Thue;
                tl.PhanTramChietKhau = ddh[i].PhanTramChietKhau;
                tl.GhiChu = ddh[i].GhiChu;
                tl.Deleted = ddh[i].Deleted;
                Trave = sp_XuLy_ChiTietHoaDonNhap(tl);
            }
            return Trave;
        }
        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        private Common.Constants.ChiTietHoaDonNhap ha;
        public int sp_XuLy_ChiTietHoaDonNhap(Entities.ChiTietHoaDonNhap ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_ChiTietHoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                ha = new Constants.ChiTietHoaDonNhap();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ha.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(ha.MaHoaDonNhap, SqlDbType.NVarChar, 20).Value = ddh.MaHoaDonNhap;
                cmd.Parameters.Add(ha.MaHangHoa, SqlDbType.NVarChar).Value = ddh.MaHangHoa;
                cmd.Parameters.Add(ha.SoLuong, SqlDbType.Int).Value = ddh.SoLuong;
                cmd.Parameters.Add(ha.DonGia, SqlDbType.Float, 20).Value = ddh.DonGia;
                cmd.Parameters.Add(ha.Thue, SqlDbType.Float, 20).Value = ddh.Thue;
                cmd.Parameters.Add(ha.PhanTramChietKhau, SqlDbType.Float, 20).Value = ddh.PhanTramChietKhau;
                cmd.Parameters.Add(ha.GhiChu, SqlDbType.NVarChar).Value = ddh.GhiChu;
                cmd.Parameters.Add(ha.Deleted, SqlDbType.Bit).Value = ddh.Deleted;
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
        /// vuong hung =================================
        /// </summary>
        /// <param name="HanhDong"></param>
        /// <param name="PhieuThuID"></param>
        
        public int sp_Xoa_ChiTietDonDatHang(Entities.ChiTietDonDatHang ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_ChiTietDonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaDonDatHang, SqlDbType.Int).Value = ddh.MaDonDatHang;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.Int).Value = ddh.MaHangHoa;
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
        #endregion

    }
}
