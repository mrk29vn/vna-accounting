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
    public class ChiTietKiemKeKho
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ChiTietKiemKeKho dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietKiemKeKho()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietKiemKeKho[] sp_LayBang_ChiTietKiemKeKho(Entities.ChiTietKiemKeKho kk)
        {
            Entities.ChiTietKiemKeKho[] arrC = null;
            try
            {
                dh = new Constants.ChiTietKiemKeKho();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ChiTietKiemKeKho;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaPhieuKiemKe", SqlDbType.NVarChar, 20).Value = kk.MaPhieuKiemKe;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                if (kk.MaPhieuKiemKe.Length <= 0)
                {
                    while (dr.Read())
                    {
                        Entities.ChiTietKiemKeKho chitietkiemkekho = new Entities.ChiTietKiemKeKho();
                        chitietkiemkekho.MaPhieuKiemKe = dr[dh.MaPhieuKiemKe].ToString().ToUpper();
                        chitietkiemkekho.MaHangHoa = dr[dh.MaHangHoa].ToString().ToUpper();
                        chitietkiemkekho.TonThucTe = int.Parse(0 + dr[dh.TonThucTe].ToString()).ToString();
                        chitietkiemkekho.TonSoSach = int.Parse(0 + dr[dh.TonSoSach].ToString()).ToString();
                        chitietkiemkekho.LyDo = "" + dr[dh.LyDo].ToString();
                        chitietkiemkekho.GhiChu = "" + dr[dh.GhiChu].ToString();
                        chitietkiemkekho.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                        arr.Add(chitietkiemkekho);
                    }
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietKiemKeKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKiemKeKho)arr[i];
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

        public Entities.ChiTietKiemKeKho[] Select()
        {
            Entities.ChiTietKiemKeKho[] arrC = null;
            try
            {
                dh = new Constants.ChiTietKiemKeKho();
                Sql = new Constants.Sql();
                string sql = "select * from ChiTietKiemKeKho where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietKiemKeKho chitietkiemkekho = new Entities.ChiTietKiemKeKho();
                    chitietkiemkekho.MaPhieuKiemKe = dr[dh.MaPhieuKiemKe].ToString().ToUpper();
                    chitietkiemkekho.MaHangHoa = dr[dh.MaHangHoa].ToString().ToUpper();
                    chitietkiemkekho.TonThucTe = int.Parse(0 + dr[dh.TonThucTe].ToString()).ToString();
                    chitietkiemkekho.TonSoSach = int.Parse(0 + dr[dh.TonSoSach].ToString()).ToString();
                    chitietkiemkekho.LyDo = "" + dr[dh.LyDo].ToString();
                    chitietkiemkekho.GhiChu = "" + dr[dh.GhiChu].ToString();
                    chitietkiemkekho.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(chitietkiemkekho);
                }

                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietKiemKeKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKiemKeKho)arr[i];
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
        /// vuong hung =================lay bang kiem ke thao ma kiem ke================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinKiemKeKho[] sp_LayKiemKeKhoTheoMa(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinKiemKeKho[] arrC = null;
            try
            {
                string sql = "exec sp_LayTheoMaKiemKeKho @MaPhieuKiemKe";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaPhieuKiemKe", SqlDbType.NVarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ThongTinKiemKeKho chitietkiemkekho = new Entities.ThongTinKiemKeKho();
                    chitietkiemkekho.Mahang = dr[0].ToString();
                    chitietkiemkekho.Tenhang = dr[1].ToString();
                    chitietkiemkekho.Tonsosach = dr[2].ToString();
                    chitietkiemkekho.Tonthucte = dr[3].ToString().ToString();
                    chitietkiemkekho.Chenhlech = dr[4].ToString().ToString();
                    chitietkiemkekho.Lydo = dr[5].ToString();
                    chitietkiemkekho.Giavon = dr[6].ToString();
                    chitietkiemkekho.Giachechlech = dr[7].ToString();
                    arr.Add(chitietkiemkekho);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.ThongTinKiemKeKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinKiemKeKho)arr[i];
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
        public int LuuLai(Entities.ChiTietKiemKeKho[] kkk)
        {
            int Trave = 0;
            try
            {
                Entities.ChiTietKiemKeKho tl = new Entities.ChiTietKiemKeKho();
                for (int i = 0; i < kkk.Length; i++)
                {
                    tl.Hanhdong = kkk[i].Hanhdong;
                    tl.MaPhieuKiemKe = kkk[i].MaPhieuKiemKe.ToUpper();
                    tl.MaHangHoa = kkk[i].MaHangHoa.ToUpper();
                    tl.TonThucTe = 0 + kkk[i].TonThucTe;
                    tl.TonSoSach = 0 + kkk[i].TonSoSach;
                    tl.LyDo = "" + kkk[i].LyDo;
                    tl.GhiChu = "" + kkk[i].GhiChu;
                    tl.Deleted = kkk[i].Deleted;
                    Trave = sp_XuLy_ChiTietKiemKeKho(tl);
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return Trave;
        }
        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int sp_XuLy_ChiTietKiemKeKho(Entities.ChiTietKiemKeKho ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_ChiTietKiemKeKho;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.ChiTietKiemKeKho();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaPhieuKiemKe, SqlDbType.VarChar, 20).Value = ddh.MaPhieuKiemKe;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.VarChar).Value = ddh.MaHangHoa;
                cmd.Parameters.Add(dh.TonThucTe, SqlDbType.Int).Value = ddh.TonThucTe;
                cmd.Parameters.Add(dh.TonSoSach, SqlDbType.Float, 20).Value = ddh.TonSoSach;
                cmd.Parameters.Add(dh.LyDo, SqlDbType.NVarChar).Value = ddh.LyDo;
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
        public int sp_Xoa_ChiTietTraLaiNhaCungCap(Entities.ChiTietKiemKeKho ddh)
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
                cmd.Parameters.Add(dh.MaPhieuKiemKe, SqlDbType.VarChar).Value = ddh.MaPhieuKiemKe;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.VarChar).Value = ddh.MaHangHoa;
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
        /// Delete
        /// </summary>
        /// <param name="maKiemKe"></param>
        /// <returns></returns>
        public int Delete(string maKiemKe)
        {
            int retVal = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_ChiTietKiemKeKho;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.ChiTietKiemKeKho();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = "MaPhieuKiemKe";
                cmd.Parameters.Add(dh.MaPhieuKiemKe, SqlDbType.VarChar, 20).Value = maKiemKe;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.VarChar).Value = string.Empty;
                retVal = cmd.ExecuteNonQuery();
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        #endregion

    }
}
