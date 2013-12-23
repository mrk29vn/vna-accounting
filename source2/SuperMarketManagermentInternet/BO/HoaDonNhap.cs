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
    public class HoaDonNhap
    {
        #region hungvv==============================khai bao - khoi tao===========================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.HoaDonNhap dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.HoaDonNhap cla;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public HoaDonNhap()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cla = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu Ly======================================================================================
        public Entities.HoaDonNhap[] Select()
        {
            Entities.HoaDonNhap[] arrC = null;
            try
            {
                dh = new Constants.HoaDonNhap();
                Sql = new Constants.Sql();
                string sql = "Select * from HoaDonNhap ";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    cla = new Entities.HoaDonNhap();
                    cla.HoaDonNhapID = System.Convert.ToInt32(dr[dh.HoaDonNhapID].ToString());
                    cla.MaHoaDonNhap = dr[dh.MaHoaDonNhap].ToString();
                    cla.NgayNhap = Convert.ToDateTime(dr[dh.NgayNhap].ToString());
                    cla.MaHoaDonNhap = dr[dh.MaHoaDonNhap].ToString();
                    cla.NgayNhap = Convert.ToDateTime(dr[dh.NgayNhap].ToString());
                    cla.MaNhaCungCap = "" + dr[dh.MaNhaCungCap].ToString();
                    cla.NoHienThoi = dr[dh.NoHienThoi].ToString();
                    cla.NguoiGiaoHang = dr[dh.NguoiGiaoHang].ToString();
                    cla.HinhThucThanhToan = dr[dh.HinhThucThanhToan].ToString();
                    cla.MaKho = dr[dh.MaKho].ToString();
                    cla.HanThanhToan = Convert.ToDateTime(dr[dh.HanThanhToan].ToString());
                    cla.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    cla.MaTienTe = dr[dh.MaTienTe].ToString();
                    cla.ChietKhau = Double.Parse(0 + dr[dh.ChietKhau].ToString()).ToString();
                    cla.ThanhToanNgay = Double.Parse(0 + dr[dh.ThanhToanNgay].ToString()).ToString();
                    cla.ThueGTGT = Double.Parse(0 + dr[dh.ThueGTGT].ToString()).ToString();
                    cla.TongTien = Double.Parse(0 + dr[dh.TongTien].ToString()).ToString();
                    cla.GhiChu = dr[dh.GhiChu].ToString();
                    cla.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    cla.ThanhToanSauKhiLapPhieu = dr["ThanhToanSauKhiLapPhieu"].ToString();
                    arr.Add(cla);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.HoaDonNhap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HoaDonNhap)arr[i];
                }

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); arrC = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }
        /// <summary>
        /// vuong hung ========================hien thi hoa don nhap===================
        /// </summary>
        /// <returns></returns>
        public Entities.HoaDonNhap[] sp_LayBang_HoaDonNhap(Entities.HoaDonNhap hoadon)
        {
            Entities.HoaDonNhap[] arrC = null;
            try
            {
                dh = new Constants.HoaDonNhap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_HoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = hoadon.MaHoaDonNhap;
                cmd.Parameters.Add(dh.MaKho, SqlDbType.VarChar, 20).Value = hoadon.MaKho;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    cla = new Entities.HoaDonNhap();
                    cla.HoaDonNhapID = System.Convert.ToInt32(dr[dh.HoaDonNhapID].ToString());
                    cla.MaHoaDonNhap = dr[dh.MaHoaDonNhap].ToString();
                    cla.NgayNhap = Convert.ToDateTime(dr[dh.NgayNhap].ToString());
                    cla.MaHoaDonNhap = dr[dh.MaHoaDonNhap].ToString();
                    cla.NgayNhap = Convert.ToDateTime(dr[dh.NgayNhap].ToString());
                    cla.MaNhaCungCap = dr[dh.MaNhaCungCap].ToString();
                    cla.NoHienThoi = dr[dh.NoHienThoi].ToString();
                    cla.NguoiGiaoHang = dr[dh.NguoiGiaoHang].ToString();
                    cla.HinhThucThanhToan = dr[dh.HinhThucThanhToan].ToString();
                    cla.MaKho = dr[dh.MaKho].ToString();
                    cla.HanThanhToan = Convert.ToDateTime(dr[dh.HanThanhToan].ToString());
                    cla.MaDonDatHang = dr[dh.MaDonDatHang].ToString();
                    cla.MaTienTe = dr[dh.MaTienTe].ToString();
                    cla.ChietKhau = Double.Parse(0 + dr[dh.ChietKhau].ToString()).ToString();
                    cla.ThanhToanNgay = Double.Parse(0 + dr[dh.ThanhToanNgay].ToString()).ToString();
                    cla.ThueGTGT = Double.Parse(0 + dr[dh.ThueGTGT].ToString()).ToString();
                    cla.TongTien = Double.Parse(0 + dr[dh.TongTien].ToString()).ToString();
                    cla.GhiChu = dr[dh.GhiChu].ToString();
                    cla.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    cla.ThanhToanSauKhiLapPhieu = dr["ThanhToanSauKhiLapPhieu"].ToString();
                    arr.Add(cla);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.HoaDonNhap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HoaDonNhap)arr[i];
                }

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); arrC = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }

        /// <summary>
        /// vuong hung ===================== them sua HoaDonNhap=====================
        /// </summary>
        public int sp_XuLy_HoaDonNhap(Entities.HoaDonNhap hdn)
        {
            int Trave = 0;
            try
            {
                dh = new Constants.HoaDonNhap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_HoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = hdn.Hanhdong;
                cmd.Parameters.Add(dh.HoaDonNhapID, SqlDbType.Int).Value = hdn.HoaDonNhapID;
                cmd.Parameters.Add(dh.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = hdn.MaHoaDonNhap;
                cmd.Parameters.Add(dh.NgayNhap, SqlDbType.DateTime).Value = hdn.NgayNhap;
                cmd.Parameters.Add(dh.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = hdn.MaNhaCungCap;
                cmd.Parameters.Add(dh.NoHienThoi, SqlDbType.Float).Value = hdn.NoHienThoi;
                cmd.Parameters.Add(dh.NguoiGiaoHang, SqlDbType.NVarChar, 20).Value = hdn.NguoiGiaoHang;
                cmd.Parameters.Add(dh.HinhThucThanhToan, SqlDbType.NVarChar).Value = hdn.HinhThucThanhToan;
                cmd.Parameters.Add(dh.MaKho, SqlDbType.VarChar, 20).Value = hdn.MaKho;
                cmd.Parameters.Add(dh.HanThanhToan, SqlDbType.DateTime).Value = hdn.HanThanhToan;
                cmd.Parameters.Add(dh.MaDonDatHang, SqlDbType.VarChar, 20).Value = hdn.MaDonDatHang;
                cmd.Parameters.Add(dh.MaTienTe, SqlDbType.VarChar, 20).Value = hdn.MaTienTe;
                cmd.Parameters.Add(dh.ChietKhau, SqlDbType.Float).Value = hdn.ChietKhau;
                cmd.Parameters.Add(dh.ThanhToanNgay, SqlDbType.Float).Value = hdn.ThanhToanNgay;
                cmd.Parameters.Add(dh.ThueGTGT, SqlDbType.Float).Value = hdn.ThueGTGT;
                cmd.Parameters.Add(dh.TongTien, SqlDbType.Float).Value = hdn.TongTien;
                cmd.Parameters.Add(dh.GhiChu, SqlDbType.NVarChar).Value = hdn.GhiChu;
                cmd.Parameters.Add(dh.Deleted, SqlDbType.Bit).Value = hdn.Deleted;
                cmd.Parameters.Add("ThanhToanSauKhiLapPhieu", SqlDbType.Float).Value = hdn.ThanhToanSauKhiLapPhieu;
                Trave = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); Trave = 0; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }


        public bool UpdateThanhToanNgay(Entities.HoaDonNhap hdn)
        {
            bool Trave = false;
            try
            {
                dh = new Constants.HoaDonNhap();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateThanhToanNgayHoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = hdn.MaHoaDonNhap;
                cmd.Parameters.Add("@ThanhToanSauKhiLapPhieu", SqlDbType.Float).Value = hdn.ThanhToanSauKhiLapPhieu;
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    Trave = true;
                else
                    Trave = false;
                return Trave;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); return Trave; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public int UpdateDuNo(Entities.TruyenGiaTri giatri)
        {
            int Trave = 0;
            try
            {
                string sql = "exec sp_CapNhatNoNhaCungCap @MaNhaCungCap,@DuNo";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DuNo", SqlDbType.Float).Value = giatri.Giatrithuhai;
                Trave = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); return Trave; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdn"></param>
        /// <returns></returns>
        public bool UpdateThanhToanNgay(Entities.HoaDonNhap[] hdn)
        {
            try
            {
                for (int i = 0; i < hdn.Length; i++)
                {
                    if (hdn[i].MaHoaDonNhap != "")
                    {
                        UpdateThanhToanNgay(hdn[i]);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// vuong hung =================================
        /// </summary>
        /// <param name="HanhDong"></param>
        /// <param name="PhieuThuID"></param>
        public int sp_Xoa_HoaDonNhap(Entities.HoaDonNhap hdn)
        {
            int Trave = 0;
            try
            {
                dh = new Constants.HoaDonNhap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_HoaDonNhap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = hdn.Hanhdong;
                cmd.Parameters.Add(dh.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = hdn.MaHoaDonNhap;
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

        private Constants.SelectID lay;
        private Entities.Lay_ID_Top_1 top;
        public Entities.Lay_ID_Top_1 sp_Tim_ID()
        {
            try
            {
                lay = new Constants.SelectID();
                Sql = new Constants.Sql();
                top = new Entities.Lay_ID_Top_1();
                string sql = Sql.sp_Tim_ID_HoaDonNhap;
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

        private Constants.ThongTinMaDonDatHang ma;
        private Entities.ThongTinMaDonDatHang madon;
        public Entities.ThongTinMaDonDatHang[] sp_LayBang_ThongTinMaDonDatHang()
        {
            Entities.ThongTinMaDonDatHang[] arrC = null;
            try
            {
                ma = new Constants.ThongTinMaDonDatHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ThongTinMaDonDatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    madon = new Entities.ThongTinMaDonDatHang();
                    madon.MaDonDatHang = dr[ma.MaDonDatHang].ToString();
                    madon.NgayDonHang = Convert.ToDateTime(dr[ma.NgayDonHang].ToString());
                    madon.TongTien = ((Double.Parse(dr[ma.GiaNhap].ToString()) - (((Double)System.Convert.ToInt32(dr[ma.PhanTramChietKhau].ToString()) / (Double)System.Convert.ToInt32(dr[ma.GiaNhap].ToString())) * 100)) * Double.Parse(dr[ma.SoLuong].ToString())).ToString();
                    arr.Add(madon);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinMaDonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinMaDonDatHang)arr[i];
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
        /// lay ban ghi cuoi cung
        /// </summary>
        public Entities.HoaDonNhap LayHoaDonNhap(Entities.TruyenGiaTri truyen)
        {
            Entities.HoaDonNhap giatri = null;
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
                    giatri = new Entities.HoaDonNhap();
                    giatri.Hanhdong = "";
                    giatri.HoaDonNhapID = int.Parse(dr[0].ToString());
                    giatri.MaHoaDonNhap = dr[1].ToString();
                    giatri.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    giatri.MaNhaCungCap = dr[3].ToString();
                    giatri.NoHienThoi = dr[4].ToString();
                    giatri.NguoiGiaoHang = dr[5].ToString();
                    giatri.HinhThucThanhToan = dr[6].ToString();
                    giatri.MaKho = dr[7].ToString();
                    giatri.HanThanhToan = Convert.ToDateTime(dr[8].ToString());
                    giatri.MaDonDatHang = dr[9].ToString();
                    giatri.MaTienTe = dr[10].ToString();
                    giatri.ChietKhau = dr[11].ToString();
                    giatri.ThanhToanNgay = dr[12].ToString();
                    giatri.ThueGTGT = dr[13].ToString();
                    giatri.TongTien = dr[14].ToString();
                    giatri.GhiChu = dr[15].ToString();
                    giatri.Deleted = Convert.ToBoolean(dr[16].ToString());
                    cla.ThanhToanSauKhiLapPhieu = dr[17].ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); return null; }
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
