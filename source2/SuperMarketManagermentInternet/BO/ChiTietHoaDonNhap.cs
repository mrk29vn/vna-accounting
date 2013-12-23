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
    public class ChiTietHoaDonNhap
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ChiTietHoaDonNhap dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietHoaDonNhap hoadonnhap;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietHoaDonNhap()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hoadonnhap = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietHoaDonNhap[] sp_LayBang_ChiTietHoaDonNhap()
        {
            Entities.ChiTietHoaDonNhap[] arrC = null;
            try
            {
                dh = new Constants.ChiTietHoaDonNhap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ChiTietHoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    hoadonnhap = new Entities.ChiTietHoaDonNhap();
                    hoadonnhap.MaHoaDonNhap = dr[dh.MaHoaDonNhap].ToString();
                    hoadonnhap.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    hoadonnhap.SoLuong = int.Parse(0 + dr[dh.SoLuong].ToString());
                    hoadonnhap.PhanTramChietKhau = Double.Parse(0 + dr[dh.PhanTramChietKhau].ToString()).ToString();
                    hoadonnhap.DonGia = dr[dh.DonGia].ToString();
                    hoadonnhap.Thue = dr[dh.Thue].ToString();
                    hoadonnhap.GhiChu = dr[dh.GhiChu].ToString();
                    hoadonnhap.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(hoadonnhap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietHoaDonNhap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietHoaDonNhap)arr[i];
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

        public Entities.ChiTietHoaDonNhap[] Select()
        {
            Entities.ChiTietHoaDonNhap[] arrC = null;
            try
            {
                dh = new Constants.ChiTietHoaDonNhap();
                Sql = new Constants.Sql();
                string sql = "Select * from ChiTietHoaDonNhap where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    hoadonnhap = new Entities.ChiTietHoaDonNhap();
                    hoadonnhap.MaHoaDonNhap = dr[dh.MaHoaDonNhap].ToString();
                    hoadonnhap.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    hoadonnhap.SoLuong = int.Parse(0 + dr[dh.SoLuong].ToString());
                    hoadonnhap.PhanTramChietKhau = Double.Parse(0 + dr[dh.PhanTramChietKhau].ToString()).ToString();
                    hoadonnhap.DonGia = dr[dh.DonGia].ToString();
                    hoadonnhap.Thue = dr[dh.Thue].ToString();
                    hoadonnhap.GhiChu = dr[dh.GhiChu].ToString();
                    hoadonnhap.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(hoadonnhap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietHoaDonNhap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietHoaDonNhap)arr[i];
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
                tl.PhanTramChietKhau = ddh[i].PhanTramChietKhau;
                tl.DonGia = ddh[i].DonGia;
                tl.Thue = ddh[i].Thue;
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
        public int sp_XuLy_ChiTietHoaDonNhap(Entities.ChiTietHoaDonNhap ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_ChiTietHoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.ChiTietHoaDonNhap();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaHoaDonNhap, SqlDbType.NVarChar, 20).Value = ddh.MaHoaDonNhap;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.NVarChar).Value = ddh.MaHangHoa;
                cmd.Parameters.Add(dh.SoLuong, SqlDbType.Int).Value = ddh.SoLuong;
                cmd.Parameters.Add(dh.PhanTramChietKhau, SqlDbType.Float, 20).Value = ddh.PhanTramChietKhau;
                cmd.Parameters.Add(dh.DonGia, SqlDbType.Float).Value = ddh.DonGia;
                cmd.Parameters.Add(dh.Thue, SqlDbType.Float).Value = ddh.Thue;
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
        /// vuong hung =================================
        /// </summary>
        /// <param name="HanhDong"></param>
        /// <param name="PhieuThuID"></param>
        public int sp_Xoa_ChiTietHoaDonNhap(Entities.ChiTietHoaDonNhap ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_ChiTietHoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaHoaDonNhap, SqlDbType.Int).Value = ddh.MaHoaDonNhap;
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

        /// <summary>
        /// thong tin hoa don nhap
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.HienThi_ChiTiet_DonDatHang[] sp_LayBang_ThongTinHoaDonNhap(Entities.HienThi_ChiTiet_DonDatHang giatri)
        {
            Entities.HienThi_ChiTiet_DonDatHang[] arrC = null;
            try
            {
                Constants.HienThi_ChiTiet_DonDatHang dh = new Constants.HienThi_ChiTiet_DonDatHang();
                Sql = new Constants.Sql();
                string sql = "exec sp_ThongTinHienThiHoaDonNhap @MaHoaDonNhap,@MaKho";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.VarChar, 20).Value = giatri.MaHangHoa;
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = giatri.TenHangHoa;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                Entities.HienThi_ChiTiet_DonDatHang hienthi = null;
                while (dr.Read())
                {
                    hienthi = new Entities.HienThi_ChiTiet_DonDatHang();
                    hienthi.MaHangHoa = dr[0].ToString().ToUpper();
                    hienthi.TenHangHoa = "" + dr[1].ToString();
                    hienthi.SoLuongDat = int.Parse(0 + dr[2].ToString());
                    hienthi.GiaGoc = Double.Parse(0 + dr[3].ToString()).ToString();
                    hienthi.Giabanbuon = Double.Parse(0 + dr[4].ToString()).ToString();
                    hienthi.Giabanle = Double.Parse(0 + dr[5].ToString()).ToString();
                    hienthi.PhanTramChietKhau = Double.Parse(0 + dr[6].ToString()).ToString();
                    hienthi.Thuegiatrigiatang = Double.Parse(0 + dr[7].ToString()).ToString();
                    hienthi.Ngayhethan = new Common.Utilities().XuLy(2, dr[8].ToString());
                    arr.Add(hienthi);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.HienThi_ChiTiet_DonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
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
        #endregion

    }
}
