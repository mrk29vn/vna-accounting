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
    public class ChiTietTraLaiNhaCungCap
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ChiTieTraLaiNhaCungCap dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietTraLaiNhaCungCap tralainhacungcap;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietTraLaiNhaCungCap()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            tralainhacungcap = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietTraLaiNhaCungCap[] sp_LayBang_ChiTietTraLaiNhaCungCap()
        {
            Entities.ChiTietTraLaiNhaCungCap[] arrC = null;
            try
            {
                dh = new Constants.ChiTieTraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ChiTietTraLaiNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralainhacungcap = new Entities.ChiTietTraLaiNhaCungCap();
                    tralainhacungcap.MaHDTraLaiNCC = dr[dh.MaHDTraLaiNCC].ToString();
                    tralainhacungcap.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    tralainhacungcap.SoLuong = Convert.ToInt32(dr[dh.SoLuong].ToString());
                    tralainhacungcap.DonGia = dr[dh.DonGia].ToString();
                    tralainhacungcap.Thue = dr[dh.Thue].ToString();
                    tralainhacungcap.PhanTramChietKhau = dr[dh.PhanTramChietKhau].ToString();
                    tralainhacungcap.GhiChu = dr[dh.GhiChu].ToString();
                    tralainhacungcap.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(tralainhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietTraLaiNhaCungCap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietTraLaiNhaCungCap)arr[i];
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

        public Entities.ChiTietTraLaiNhaCungCap[] Select()
        {
            Entities.ChiTietTraLaiNhaCungCap[] arrC = null;
            try
            {
                dh = new Constants.ChiTieTraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = "Select * From ChiTietTraLaiNCC where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralainhacungcap = new Entities.ChiTietTraLaiNhaCungCap();
                    tralainhacungcap.MaHDTraLaiNCC = dr[dh.MaHDTraLaiNCC].ToString();
                    tralainhacungcap.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    tralainhacungcap.SoLuong = Convert.ToInt32(dr[dh.SoLuong].ToString());
                    tralainhacungcap.DonGia = dr[dh.DonGia].ToString();
                    tralainhacungcap.Thue = dr[dh.Thue].ToString();
                    tralainhacungcap.PhanTramChietKhau = dr[dh.PhanTramChietKhau].ToString();
                    tralainhacungcap.GhiChu = dr[dh.GhiChu].ToString();
                    tralainhacungcap.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(tralainhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietTraLaiNhaCungCap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietTraLaiNhaCungCap)arr[i];
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
        public int LuuLai(Entities.ChiTietTraLaiNhaCungCap[] ddh)
        {
            int Trave = 0;
            try
            {
                Entities.ChiTietTraLaiNhaCungCap tl = new Entities.ChiTietTraLaiNhaCungCap();
                for (int i = 0; i < ddh.Length; i++)
                {
                    tl.Hanhdong = ddh[i].Hanhdong;
                    tl.MaHDTraLaiNCC = ddh[i].MaHDTraLaiNCC;
                    tl.MaHangHoa = ddh[i].MaHangHoa;
                    tl.SoLuong = ddh[i].SoLuong;
                    tl.DonGia = ddh[i].DonGia;
                    tl.Thue = ddh[i].Thue;
                    tl.PhanTramChietKhau = ddh[i].PhanTramChietKhau;
                    tl.GhiChu = ddh[i].GhiChu;
                    tl.Deleted = ddh[i].Deleted;
                    tl.Makho = ddh[i].Makho;
                    Trave = sp_XuLy_ChiTietTraLaiNhaCungCap(tl);
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return Trave;
        }
      
        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int sp_XuLy_ChiTietTraLaiNhaCungCap(Entities.ChiTietTraLaiNhaCungCap ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_ChiTietTraLaiNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.ChiTieTraLaiNhaCungCap();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaHDTraLaiNCC, SqlDbType.VarChar, 20).Value = ddh.MaHDTraLaiNCC;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.VarChar,50).Value = ddh.MaHangHoa;
                cmd.Parameters.Add(dh.SoLuong, SqlDbType.Int).Value = ddh.SoLuong;
                cmd.Parameters.Add(dh.DonGia, SqlDbType.Float).Value = ddh.DonGia;
                cmd.Parameters.Add(dh.Thue, SqlDbType.Float).Value = ddh.Thue;
                cmd.Parameters.Add(dh.PhanTramChietKhau, SqlDbType.Float).Value = ddh.PhanTramChietKhau;
                cmd.Parameters.Add(dh.GhiChu, SqlDbType.NVarChar,100).Value = ddh.GhiChu;
                cmd.Parameters.Add(dh.Deleted, SqlDbType.Bit).Value = ddh.Deleted;
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar,20).Value = ddh.Makho;
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
        public int sp_Xoa_ChiTietTraLaiNhaCungCap(Entities.ChiTietTraLaiNhaCungCap ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_ChiTietTraLaiNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaHDTraLaiNCC, SqlDbType.Int).Value = ddh.MaHDTraLaiNCC;
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
