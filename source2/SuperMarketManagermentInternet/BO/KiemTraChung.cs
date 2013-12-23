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
    public class KiemTraChung
    {

        #region hungvv================================khai bao - khoi tao=====================================================================

        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public KiemTraChung()
        {
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        private Entities.KiemTraChung ve;
        public Entities.KiemTraChung KiemTraMa(Entities.KiemTraChung giatri)
        {
            ve = new Entities.KiemTraChung();
            try
            {
                SqlDataReader read = null;
                Common.Constants.BienChung conten = new Common.Constants.BienChung();
                Sql = new Constants.Sql();
                string sql = Sql.sp_KiemTraMa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = giatri.Khoachinh;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar, 50).Value = giatri.Name;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ve.Hanhdong = read["ThongBao"].ToString();
                }
                read.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return ve;
        }
        /// <summary>
        /// lay ID
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.KiemTraChung[] LayCombox(Entities.KiemTraChung giatri)
        {
            Entities.KiemTraChung[] matrave=null;
            try
            {
                SqlDataReader read = null;
                Common.Constants.BienChung conten = new Common.Constants.BienChung();
                Sql = new Constants.Sql();
                string sql = "exec sp_LayCombox @tableName,@columnID,@columnName";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@tableName", SqlDbType.NVarChar, 20).Value = giatri.Name;
                cmd.Parameters.Add("@columnID", SqlDbType.NVarChar, 20).Value = giatri.Khoachinh;
                cmd.Parameters.Add("@columnName", SqlDbType.NVarChar, 20).Value = giatri.Giatri;
                read = cmd.ExecuteReader();
                ArrayList arr = new ArrayList();
                while (read.Read())
                {
                    Entities.KiemTraChung kt = new Entities.KiemTraChung();
                    kt.Khoachinh = read[0].ToString().ToUpper();
                    kt.Giatri = read[1].ToString();
                    arr.Add(kt);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                matrave = new Entities.KiemTraChung[n];
                for (int i = 0; i < n; i++)
                {
                    matrave[i] = (Entities.KiemTraChung)arr[i];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return matrave;
        }
        /// <summary>
        /// lay ID
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.KiemTraChung[] LayThongTinTienTe()
        {
            Entities.KiemTraChung[] matrave = null;
            try
            {
                SqlDataReader read = null;
                Common.Constants.BienChung conten = new Common.Constants.BienChung();
                Sql = new Constants.Sql();
                string sql = "exec sp_LayThongTinTienTe";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                read = cmd.ExecuteReader();
                ArrayList arr = new ArrayList();
                while (read.Read())
                {
                    Entities.KiemTraChung kt = new Entities.KiemTraChung();
                    kt.Khoachinh = read[0].ToString().ToUpper();
                    kt.Giatri = read[1].ToString();
                    kt.Giatri2 = read[2].ToString();
                    arr.Add(kt);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                matrave = new Entities.KiemTraChung[n];
                for (int i = 0; i < n; i++)
                {
                    matrave[i] = (Entities.KiemTraChung)arr[i];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return matrave;
        }
        /// <summary>
        /// kiem tra trang loai don dat hang theo ma don hang
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.TruyenGiaTri KiemTraDonDatHang(Entities.TruyenGiaTri giatri)
        {
            Entities.TruyenGiaTri ve = null;
            try
            {
                SqlDataReader read = null;
                Sql = new Constants.Sql();
                string sql = "exec sp_KiemTraDonDatHang @HanhDong,@MaDonDatHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("HanhDong", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("MaDonDatHang", SqlDbType.VarChar, 20).Value = giatri.Giatrithuhai;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ve= new Entities.TruyenGiaTri();
                    ve.Giatritruyen = read[0].ToString();
                    ve.Giatrithuhai = read[1].ToString();
                }
                read.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ve = null;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return ve;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public int CapNhatDuNoKhachHang(Entities.TruyenGiaTri giatri)
        {
            int tra = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = "exec sp_CapNhatDuNoKhachHang @MaKhachHang,@DuNo";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKhachHang", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DuNo", SqlDbType.Float).Value = giatri.Giatrithuhai;
                tra = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                tra = 0;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return tra;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public int CapNhatDuNoNhaCungCap(Entities.TruyenGiaTri giatri)
        {
            int tra = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = "exec sp_CapNhatDuNoNhaCungCap @MaNhaCungCap,@DuNo";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DuNo", SqlDbType.Float).Value = giatri.Giatrithuhai;
                tra = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                tra = 0;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return tra;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.KiemTraChung[] LaySoLuongDaTraLaiTheoHoaDonBanHang(Entities.TruyenGiaTri giatri)
        {
            Entities.KiemTraChung[] tra = null;
            try
            {
                SqlDataReader read = null;
                string sql = "exec sp_LaySoLuongDaTraLaiTheoHoaDonBanHang @MaHoaDonMuaHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonMuaHang", SqlDbType.NVarChar, 20).Value = giatri.Giatritruyen;
                read = cmd.ExecuteReader();
                ArrayList arr = new ArrayList();
                while (read.Read())
                {
                    Entities.KiemTraChung banghi = new Entities.KiemTraChung();
                    banghi.Giatri = read[0].ToString();
                    banghi.Giatri2 = read[1].ToString();
                    arr.Add(banghi);
                }
                read.Close();
                int n = arr.Count;
                if (n == 0) { tra = null; }
                tra = new Entities.KiemTraChung[n];
                for (int i = 0; i < n; i++)
                {
                    tra[i] = (Entities.KiemTraChung)arr[i];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString(); tra = null;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return tra;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.KiemTraChung[] LaySoLuongDaTraLaiTheoHoaDonNhap(Entities.TruyenGiaTri giatri)
        {
            Entities.KiemTraChung[] tra = null;
            try
            {
                SqlDataReader read = null;
                string sql = "exec sp_LaySoLuongDaTraLaiTheoHoaDonNhap @MaHoaDonNhap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.NVarChar, 20).Value = giatri.Giatritruyen;
                read = cmd.ExecuteReader();
                ArrayList arr = new ArrayList();
                while (read.Read())
                {
                    Entities.KiemTraChung banghi = new Entities.KiemTraChung();
                    banghi.Giatri = read[0].ToString();
                    banghi.Giatri2 = read[1].ToString();
                    arr.Add(banghi);
                }
                read.Close();
                int n = arr.Count;
                if (n == 0) { tra= null; }
                tra = new Entities.KiemTraChung[n];
                for (int i = 0; i < n; i++)
                {
                    tra[i] = (Entities.KiemTraChung)arr[i];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString(); tra = null;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return tra;
        }
        #endregion
    }
}
