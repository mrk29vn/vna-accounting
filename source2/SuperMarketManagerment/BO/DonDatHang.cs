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
    public class DonDatHang
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.DonDatHang dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.DonDatHang dondathang;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public DonDatHang()
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
        public Entities.DonDatHang[] sp_LayBang_DonDatHang(Entities.DonDatHang giatri)
        {
            List<Entities.DonDatHang> arr = null;
            try
            {
                dh = new Constants.DonDatHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_DonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaDonDatHang", SqlDbType.VarChar, 20).Value = giatri.MaDonDatHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new List<Entities.DonDatHang>();
                while (dr.Read())
                {
                    dondathang = new Entities.DonDatHang();
                    dondathang.DonDatHangID = Convert.ToInt32(dr[dh.DonDatHangID].ToString());
                    dondathang.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    dondathang.LoaiDonDatHang = Convert.ToBoolean(dr[dh.LoaiDonDatHang].ToString());
                    dondathang.NgayDonHang = Convert.ToDateTime(dr[dh.NgayDonHang].ToString());
                    dondathang.MaNhaCungCap = dr[dh.MaNhaCungCap].ToString();
                    dondathang.NoHienThoi = dr[dh.NoHienThoi].ToString();
                    dondathang.TrangThaiDonDatHang = dr[dh.TrangThaiDonDatHang].ToString();
                    dondathang.NgayNhapDuKien = Convert.ToDateTime(dr[dh.NgayNhapDuKien].ToString());
                    dondathang.HinhThucThanhToan = dr[dh.HinhThucThanhToan].ToString();
                    dondathang.MaKho = dr[dh.MaKho].ToString().ToUpper();
                    dondathang.MaNhanVien = dr[dh.MaNhanVien].ToString().ToUpper();
                    dondathang.MaTienTe = dr[dh.MaTienTe].ToString().ToUpper();
                    dondathang.ThueGTGT = Double.Parse(0 + dr[dh.ThueGTGT].ToString()).ToString();
                    dondathang.Phivanchuyen = Double.Parse(0 + dr[dh.Phivanchuyen].ToString()).ToString();
                    dondathang.PhiKhac = Double.Parse(0 + dr[dh.PhiKhac].ToString()).ToString();
                    dondathang.GhiChu = "" + dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    dondathang.Makhachhang = dr[dh.MaKhachHang].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0)
                {
                    return null;
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
            return arr.ToArray();
        }

        public Entities.DonDatHang[] Select()
        {
            List<Entities.DonDatHang> arr = null;
            try
            {
                dh = new Constants.DonDatHang();
                Sql = new Constants.Sql();
                string sql = "select * from DonDatHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new List<Entities.DonDatHang>();
                while (dr.Read())
                {
                    dondathang = new Entities.DonDatHang();
                    dondathang.DonDatHangID = Convert.ToInt32(dr[dh.DonDatHangID].ToString());
                    dondathang.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    dondathang.LoaiDonDatHang = Convert.ToBoolean(dr[dh.LoaiDonDatHang].ToString());
                    dondathang.NgayDonHang = Convert.ToDateTime(dr[dh.NgayDonHang].ToString());
                    dondathang.MaNhaCungCap = dr[dh.MaNhaCungCap].ToString();
                    dondathang.NoHienThoi = dr[dh.NoHienThoi].ToString();
                    dondathang.TrangThaiDonDatHang = dr[dh.TrangThaiDonDatHang].ToString();
                    dondathang.NgayNhapDuKien = Convert.ToDateTime(dr[dh.NgayNhapDuKien].ToString());
                    dondathang.HinhThucThanhToan = dr[dh.HinhThucThanhToan].ToString();
                    dondathang.MaKho = dr[dh.MaKho].ToString().ToUpper();
                    dondathang.MaNhanVien = dr[dh.MaNhanVien].ToString().ToUpper();
                    dondathang.MaTienTe = dr[dh.MaTienTe].ToString().ToUpper();
                    dondathang.ThueGTGT = Double.Parse(0 + dr[dh.ThueGTGT].ToString()).ToString();
                    dondathang.Phivanchuyen = Double.Parse(0 + dr[dh.Phivanchuyen].ToString()).ToString();
                    dondathang.PhiKhac = Double.Parse(0 + dr[dh.PhiKhac].ToString()).ToString();
                    dondathang.GhiChu = "" + dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    dondathang.Makhachhang = dr[dh.MaKhachHang].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0)
                {
                    arr = null;
                }
            }
            catch
            {
                arr = null;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arr.ToArray();
        }

        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int sp_XuLy_DonDatHang(Entities.DonDatHang ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_DonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.DonDatHang();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.DonDatHangID, SqlDbType.Int, 20).Value = ddh.DonDatHangID;
                cmd.Parameters.Add(dh.MaDonDatHang, SqlDbType.NVarChar, 20).Value = ddh.MaDonDatHang;
                cmd.Parameters.Add(dh.LoaiDonDatHang, SqlDbType.Bit).Value = ddh.LoaiDonDatHang;
                cmd.Parameters.Add(dh.NgayDonHang, SqlDbType.DateTime).Value = ddh.NgayDonHang;
                cmd.Parameters.Add(dh.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ddh.MaNhaCungCap;
                cmd.Parameters.Add(dh.NoHienThoi, SqlDbType.Float).Value = ddh.NoHienThoi;
                cmd.Parameters.Add(dh.TrangThaiDonDatHang, SqlDbType.NVarChar, 20).Value = ddh.TrangThaiDonDatHang;
                cmd.Parameters.Add(dh.NgayNhapDuKien, SqlDbType.DateTime).Value = ddh.NgayNhapDuKien;
                cmd.Parameters.Add(dh.HinhThucThanhToan, SqlDbType.NVarChar, 20).Value = ddh.HinhThucThanhToan;
                cmd.Parameters.Add(dh.MaKho, SqlDbType.NVarChar, 20).Value = ddh.MaKho;
                cmd.Parameters.Add(dh.MaNhanVien, SqlDbType.NVarChar, 20).Value = ddh.MaNhanVien;
                cmd.Parameters.Add(dh.MaTienTe, SqlDbType.NVarChar, 20).Value = ddh.MaTienTe;
                cmd.Parameters.Add(dh.ThueGTGT, SqlDbType.Float).Value = ddh.ThueGTGT;
                cmd.Parameters.Add(dh.Phivanchuyen, SqlDbType.Float).Value = ddh.Phivanchuyen;
                cmd.Parameters.Add(dh.PhiKhac, SqlDbType.Float).Value = ddh.PhiKhac;
                cmd.Parameters.Add(dh.GhiChu, SqlDbType.NVarChar, 50).Value = ddh.GhiChu;
                cmd.Parameters.Add(dh.Deleted, SqlDbType.Bit).Value = ddh.Deleted;
                cmd.Parameters.Add(dh.MaKhachHang, SqlDbType.NVarChar).Value = ddh.Makhachhang;
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
        /// vuong hung xoa don dat hang
        /// </summary>
        /// <param name="HanhDong"></param>
        /// <param name="PhieuThuID"></param>
        public int sp_Xoa_DonDatHang(Entities.DonDatHang ddh)
        {
            int Trave = 0;
            try
            {
                dh = new Constants.DonDatHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_DonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaDonDatHang, SqlDbType.VarChar, 20).Value = ddh.MaDonDatHang;
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
        /// cap nhat lai trang thai don dat hang
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public string CapNhatTrangThaiDonDatHang(Entities.DonDatHang dat)
        {
            string tralai = "";
            string sql = "exec sp_CapNhatTrangThaiDonDatHang @HanhDong,@MaDonDatHang,@TrangThaiDonDatHang";
            conn = new Connection();
            cn = conn.openConnection();
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("HanhDong", SqlDbType.NVarChar, 20).Value = dat.Hanhdong;
            cmd.Parameters.Add("MaDonDatHang", SqlDbType.VarChar, 20).Value = dat.MaDonDatHang;
            cmd.Parameters.Add("TrangThaiDonDatHang", SqlDbType.NVarChar, 20).Value = dat.TrangThaiDonDatHang;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                tralai = dr[0].ToString();
            }
            return tralai;
        }

        /// <summary>
        /// lay ID tu tang
        /// </summary>
        private Constants.SelectID lay;
        private Entities.Lay_ID_Top_1 top;
        public Entities.Lay_ID_Top_1 sp_Tim_ID()
        {
            try
            {
                lay = new Constants.SelectID();
                Sql = new Constants.Sql();
                top = new Entities.Lay_ID_Top_1();
                string sql = Sql.sp_Tim_ID;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    top.ColumnNameID = dr[0].ToString();
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
            return top;
        }
        /// <summary>
        /// lay ban ghi cuoi cung
        /// </summary>
        public Entities.DonDatHang sp_LayBang_TheoTenBang(Entities.TruyenGiaTri truyen)
        {
            Entities.DonDatHang giatri = new Entities.DonDatHang();
            try
            {
                string sql = "exec sp_LayBang_TheoTenBang @table,@values";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("table", SqlDbType.NVarChar, 100).Value = truyen.Giatritruyen;
                cmd.Parameters.Add("values", SqlDbType.NVarChar, 50).Value = truyen.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    giatri.DonDatHangID = int.Parse(dr[0].ToString());
                    giatri.MaDonDatHang = dr[1].ToString();
                    giatri.LoaiDonDatHang = Boolean.Parse(dr[2].ToString());
                    giatri.NgayDonHang = DateTime.Parse(dr[3].ToString());
                    giatri.MaNhaCungCap = dr[4].ToString();
                    giatri.NoHienThoi = dr[5].ToString();
                    giatri.TrangThaiDonDatHang = dr[6].ToString();
                    giatri.NgayNhapDuKien = DateTime.Parse(dr[7].ToString());
                    giatri.HinhThucThanhToan = dr[8].ToString();
                    giatri.MaKho = dr[9].ToString();
                    giatri.MaNhanVien = dr[10].ToString();
                    giatri.MaTienTe = dr[11].ToString();
                    giatri.ThueGTGT = dr[12].ToString();
                    giatri.Phivanchuyen = dr[13].ToString();
                    giatri.PhiKhac = dr[14].ToString();
                    giatri.GhiChu = dr[15].ToString();
                    giatri.Deleted = Boolean.Parse(dr[16].ToString());
                    giatri.Makhachhang = dr[17].ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); giatri = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return giatri;
        }
        #endregion

    }
}
