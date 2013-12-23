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
    public class KhachHangTraLai
    {
        #region hungvv=====================================khai bao - khoi tao=======================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.KhachHangTraLai khtl;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.KhachHangTraLai khachhangtralai;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public KhachHangTraLai()
        {
            khtl = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khachhangtralai = null;
            cn = null;
        }
        #endregion

        #region hungvv=======================================?Xu Ly===================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.KhachHangTraLai[] sp_LayBang_KhachHangTraLai(Entities.KhachHangTraLai KH)
        {
            Entities.KhachHangTraLai[] arrC = null;
            try
            {
                khtl = new Constants.KhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_KhachHangTraLai;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(khtl.MaKhachHangTraLai, SqlDbType.NVarChar, 20).Value = KH.MaKhachHangTraLai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    khachhangtralai = new Entities.KhachHangTraLai();
                    khachhangtralai.KhachHangTraLaiID = int.Parse(dr[0].ToString());
                    khachhangtralai.MaKhachHangTraLai = dr[1].ToString();
                    khachhangtralai.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    khachhangtralai.MaKhachHang = dr[3].ToString();
                    khachhangtralai.NoHienThoi = dr[4].ToString();
                    khachhangtralai.NguoiTra = dr[5].ToString();
                    khachhangtralai.HinhThucThanhToan = dr[6].ToString();
                    khachhangtralai.HanThanhToan = Convert.ToDateTime(dr[7].ToString());
                    khachhangtralai.MaHoaDonMuaHang = dr[8].ToString();
                    khachhangtralai.MaKho = dr[9].ToString();
                    khachhangtralai.MaTienTe = dr[10].ToString();
                    khachhangtralai.TienBoiThuong = dr[11].ToString();
                    khachhangtralai.ThanhToanNgay = dr[12].ToString();
                    khachhangtralai.ThueGTGT = dr[13].ToString();
                    khachhangtralai.GhiChu = dr[14].ToString();
                    khachhangtralai.Deleted = Convert.ToBoolean(dr[15].ToString());
                    arr.Add(khachhangtralai);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.KhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KhachHangTraLai)arr[i];
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

        public Entities.KhachHangTraLai[] Select()
        {
            Entities.KhachHangTraLai[] arrC = null;
            try
            {
                Entities.KhachHang[] kh = new BizLogic.KhachHang().Select();
                khtl = new Constants.KhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = "Select * from KhachHangTraLai where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    khachhangtralai = new Entities.KhachHangTraLai();
                    khachhangtralai.KhachHangTraLaiID = int.Parse(dr[0].ToString());
                    khachhangtralai.MaKhachHangTraLai = dr[1].ToString();
                    khachhangtralai.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    khachhangtralai.MaKhachHang = dr[3].ToString();
                    khachhangtralai.TenKhachHang = "";
                    foreach (Entities.KhachHang item in kh)
                    {
                        if (item.MaKH == khachhangtralai.MaKhachHang)
                        {
                            khachhangtralai.TenKhachHang = item.Ten;
                            break;
                        }
                    }
                    khachhangtralai.NoHienThoi = dr[4].ToString();
                    khachhangtralai.NguoiTra = dr[5].ToString();
                    khachhangtralai.HinhThucThanhToan = dr[6].ToString();
                    khachhangtralai.HanThanhToan = Convert.ToDateTime(dr[7].ToString());
                    khachhangtralai.MaHoaDonMuaHang = dr[8].ToString();
                    khachhangtralai.MaKho = dr[9].ToString();
                    khachhangtralai.MaTienTe = dr[10].ToString();
                    khachhangtralai.TienBoiThuong = dr[11].ToString();
                    khachhangtralai.ThanhToanNgay = dr[12].ToString();
                    khachhangtralai.ThueGTGT = dr[13].ToString();
                    khachhangtralai.GhiChu = dr[14].ToString();
                    khachhangtralai.Deleted = Convert.ToBoolean(dr[15].ToString());
                    arr.Add(khachhangtralai);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.KhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KhachHangTraLai)arr[i];
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
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int sp_XuLy_KhachHangTraLai(Entities.KhachHangTraLai kkt)
        {
            int Trave = 0;
            try
            {
                khtl = new Constants.KhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_KhachHangTraLai;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(khtl.HanhDong, SqlDbType.NVarChar, 20).Value = kkt.Hanhdong;
                cmd.Parameters.Add("KhachHangTraLaiID", SqlDbType.Int).Value = kkt.KhachHangTraLaiID;
                cmd.Parameters.Add(khtl.MaKhachHangTraLai, SqlDbType.NVarChar, 20).Value = kkt.MaKhachHangTraLai;
                cmd.Parameters.Add(khtl.NgayNhap, SqlDbType.DateTime).Value = kkt.NgayNhap;
                cmd.Parameters.Add(khtl.MaKhachHang, SqlDbType.NVarChar, 20).Value = kkt.MaKhachHang;
                cmd.Parameters.Add(khtl.NoHienThoi, SqlDbType.Float).Value = kkt.NoHienThoi;
                cmd.Parameters.Add(khtl.NguoiTra, SqlDbType.NVarChar, 200).Value = kkt.NguoiTra;
                cmd.Parameters.Add(khtl.HinhThucThanhToan, SqlDbType.NVarChar, 200).Value = kkt.HinhThucThanhToan;
                cmd.Parameters.Add(khtl.HanThanhToan, SqlDbType.DateTime).Value = kkt.HanThanhToan;
                cmd.Parameters.Add(khtl.MaHoaDonMuaHang, SqlDbType.NVarChar, 20).Value = kkt.MaHoaDonMuaHang;
                cmd.Parameters.Add(khtl.MaKho, SqlDbType.NVarChar, 20).Value = kkt.MaKho;
                cmd.Parameters.Add(khtl.MaTienTe, SqlDbType.NVarChar, 20).Value = kkt.MaTienTe;
                cmd.Parameters.Add(khtl.TienBoiThuong, SqlDbType.Float).Value = kkt.TienBoiThuong;
                cmd.Parameters.Add(khtl.ThanhToanNgay, SqlDbType.Float).Value = kkt.ThanhToanNgay;
                cmd.Parameters.Add(khtl.ThueGTGT, SqlDbType.Float).Value = kkt.ThueGTGT;
                cmd.Parameters.Add(khtl.GhiChu, SqlDbType.NVarChar, 100).Value = kkt.GhiChu;
                cmd.Parameters.Add(khtl.Deleted, SqlDbType.Bit).Value = kkt.Deleted;
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
        public int sp_Xoa_KhachHangTraLai(Entities.KhachHangTraLai kkt)
        {
            int Trave = 0;
            try
            {
                khtl = new Constants.KhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_KhachHangTraLai;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(khtl.HanhDong, SqlDbType.NVarChar, 20).Value = kkt.Hanhdong;
                cmd.Parameters.Add(khtl.MaKhachHangTraLai, SqlDbType.VarChar).Value = kkt.MaKhachHangTraLai;
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

        private Entities.Lay_ID_Top_1 top;
        public Entities.Lay_ID_Top_1 sp_Tim_ID()
        {
            try
            {
                Sql = new Constants.Sql();
                top = new Entities.Lay_ID_Top_1();
                string sql = Sql.sp_LayID_KhachHangTraLai;
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

        public Entities.KhachHangTraLai CheckKhachHangTraLai(Entities.TruyenGiaTri truyen)
        {
            Entities.KhachHangTraLai giatri = null;
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
                    giatri = new Entities.KhachHangTraLai();
                    giatri.KhachHangTraLaiID = int.Parse(dr[0].ToString());
                    giatri.MaKhachHangTraLai = dr[1].ToString();
                    giatri.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    giatri.MaKhachHang = dr[3].ToString();
                    giatri.NoHienThoi = dr[4].ToString();
                    giatri.NguoiTra = dr[5].ToString();
                    giatri.HinhThucThanhToan = dr[6].ToString();
                    giatri.HanThanhToan = Convert.ToDateTime(dr[7].ToString());
                    giatri.MaHoaDonMuaHang = dr[8].ToString();
                    giatri.MaKho = dr[9].ToString();
                    giatri.MaTienTe = dr[10].ToString();
                    giatri.TienBoiThuong = dr[11].ToString();
                    giatri.ThanhToanNgay = dr[12].ToString();
                    giatri.ThueGTGT = dr[13].ToString();
                    giatri.GhiChu = dr[14].ToString();
                    giatri.Deleted = Convert.ToBoolean(dr[15].ToString());
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); giatri= null; }
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
