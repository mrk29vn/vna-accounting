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
    public class KiemKeKho
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.KiemKeKho dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.KiemKeKho dondathang;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public KiemKeKho()
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
        Entities.KhoHang[] kh;
        public string TimTenKH(string maKhachHang)
        {
            string tra = "";
            try
            {
                for (int i = 0; i < kh.Length; i++)
                {
                    if (kh[i].MaKho == maKhachHang)
                    {
                        tra= kh[i].TenKho;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = ""; }
            return tra;
        }
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.KiemKeKho[] sp_LayBang_KiemKeKho(Entities.KiemKeKho kk)
        {
            Entities.KiemKeKho[] arrC = null;
            try
            {
                dh = new Constants.KiemKeKho();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_KiemKeKho;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.MaKiemKe, SqlDbType.VarChar, 20).Value = kk.MaKiemKe;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.KiemKeKho();
                    dondathang.PhieuKiemKeKhoID = Convert.ToInt32(dr[dh.PhieuKiemKeKhoID].ToString());
                    dondathang.MaKiemKe = ""+dr[dh.MaKiemKe].ToString();
                    dondathang.NgayKiemKe = System.Convert.ToDateTime(""+dr[dh.NgayKiemKe].ToString());
                    dondathang.MaKho = dr[dh.MaKho].ToString();
                    dondathang.Tenkho = dr[dh.TenKho].ToString();
                    dondathang.GhiChu = ""+dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.KiemKeKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KiemKeKho)arr[i];
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

        public Entities.KiemKeKho[] Select()
        {
            Entities.KiemKeKho[] arrC = null;
            try
            {
                dh = new Constants.KiemKeKho();
                Sql = new Constants.Sql();
                string sql = "Select * from KiemKeKho where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.KiemKeKho();
                    dondathang.PhieuKiemKeKhoID = Convert.ToInt32(dr[dh.PhieuKiemKeKhoID].ToString());
                    dondathang.MaKiemKe = "" + dr[dh.MaKiemKe].ToString();
                    dondathang.NgayKiemKe = System.Convert.ToDateTime("" + dr[dh.NgayKiemKe].ToString());
                    dondathang.MaKho = dr[dh.MaKho].ToString();
                    dondathang.Tenkho = dr[dh.TenKho].ToString();
                    dondathang.GhiChu = "" + dr[dh.GhiChu].ToString();
                    dondathang.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.KiemKeKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KiemKeKho)arr[i];
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
        public int sp_XuLy_KiemKeKho(Entities.KiemKeKho ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_KiemKeKho;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.KiemKeKho();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.PhieuKiemKeKhoID, SqlDbType.Int).Value = ddh.PhieuKiemKeKhoID;
                cmd.Parameters.Add(dh.MaKiemKe, SqlDbType.VarChar, 20).Value = ddh.MaKiemKe;
                cmd.Parameters.Add(dh.NgayKiemKe, SqlDbType.DateTime).Value = ddh.NgayKiemKe;
                cmd.Parameters.Add(dh.MaKho, SqlDbType.VarChar).Value = ddh.MaKho;
                cmd.Parameters.Add(dh.GhiChu, SqlDbType.NVarChar, 100).Value = ddh.GhiChu;
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
        public int sp_Xoa_KiemKeKho(Entities.KiemKeKho ddh)
        {
            int Trave = 0;
            try
            {
                dh = new Constants.KiemKeKho();
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_KiemKeKho;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaKiemKe, SqlDbType.VarChar).Value = ddh.MaKiemKe;
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
        /// lay ban ghi cuoi cung
        /// </summary>
        public Entities.KiemKeKho sp_LayBang_TheoTenBang(Entities.TruyenGiaTri chuyen)
        {
            Entities.KiemKeKho giatri = new Entities.KiemKeKho();
            try
            {
                string sql = "exec sp_LayBang_TheoTenBang @table,@values";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("table", SqlDbType.NVarChar, 100).Value = chuyen.Giatritruyen;
                cmd.Parameters.Add("values", SqlDbType.NVarChar, 50).Value = chuyen.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    giatri.PhieuKiemKeKhoID = int.Parse(dr[0].ToString());
                    giatri.MaKiemKe = dr[1].ToString();
                    giatri.NgayKiemKe = DateTime.Parse(dr[2].ToString());
                    giatri.MaKho = dr[3].ToString();
                    giatri.GhiChu = dr[4].ToString();
                    giatri.Deleted = Boolean.Parse(dr[5].ToString());
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
        public Entities.Lay_ID_Top_1 sp_Tim_ID()
        {
            Entities.Lay_ID_Top_1 trave = null;
            try
            {

                Sql = new Constants.Sql();
                string sql = Sql.sp_Tim_ID;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    trave = new Entities.Lay_ID_Top_1();
                    trave.ColumnNameID = dr[Sql.ColumnNameID].ToString();
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
            return trave;
        }
        #endregion
    }
}
