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
    public class TraLaiNhaCungCap
    {
        #region hungvv=============================================khai bao - khoi tao==============================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.TraLaiNhaCungCap tlncc;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.TraLaiNCC tralainhacungcap;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public TraLaiNhaCungCap()
        {
            tlncc = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            tralainhacungcap = null;
            cn = null;
        }
        #endregion

        #region hungvv===============================================Xu Ly========================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.TraLaiNCC[] sp_LayBang_tralainhacungcap(Entities.TraLaiNCC cc)
        {
            Entities.TraLaiNCC[] arrC = null;
            try
            {
                tlncc = new Constants.TraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_TraLaiNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tlncc.MaHDTraLaiNCC, SqlDbType.VarChar, 20).Value = cc.MaHDTraLaiNCC;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralainhacungcap = new Entities.TraLaiNCC();
                    tralainhacungcap.TraLaiNCCID = Convert.ToInt32(dr[tlncc.TraLaiNCCID].ToString());
                    tralainhacungcap.MaHDTraLaiNCC = dr[tlncc.MaHDTraLaiNCC].ToString();
                    tralainhacungcap.Ngaytra = Convert.ToDateTime(dr[tlncc.Ngaytra].ToString());
                    tralainhacungcap.MaNCC = dr[tlncc.MaNCC].ToString();
                    tralainhacungcap.NoHienThoi = dr[tlncc.NoHienThoi].ToString();
                    tralainhacungcap.NguoiNhanHang = dr[tlncc.NguoiNhanHang].ToString();
                    tralainhacungcap.HinhThucThanhToan = dr[tlncc.HinhThucThanhToan].ToString();
                    tralainhacungcap.MaHoaDonNhap = dr[tlncc.MaHoaDonNhap].ToString();
                    tralainhacungcap.MaKho = dr[tlncc.MaKho].ToString();
                    tralainhacungcap.MaTienTe = dr[tlncc.MaTienTe].ToString();
                    tralainhacungcap.TienBoiThuong = dr[tlncc.TienBoiThuong].ToString();
                    tralainhacungcap.ThanhToanNgay = dr[tlncc.ThanhToanNgay].ToString();
                    tralainhacungcap.ThueGTGT = dr[tlncc.ThueGTGT].ToString();
                    tralainhacungcap.GhiChu = dr[tlncc.GhiChu].ToString();
                    tralainhacungcap.Deleted = Convert.ToBoolean(dr[tlncc.Deleted].ToString());
                    arr.Add(tralainhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TraLaiNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TraLaiNCC)arr[i];
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

        public Entities.TraLaiNCC[] Select()
        {
            Entities.TraLaiNCC[] arrC = null;
            try
            {
                Entities.NhaCungCap[] ncc = new BizLogic.NhaCungCap().Select();
                tlncc = new Constants.TraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = "select * from  TraLaiNCC where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralainhacungcap = new Entities.TraLaiNCC();
                    tralainhacungcap.TraLaiNCCID = Convert.ToInt32(dr[tlncc.TraLaiNCCID].ToString());
                    tralainhacungcap.MaHDTraLaiNCC = dr[tlncc.MaHDTraLaiNCC].ToString();
                    tralainhacungcap.Ngaytra = Convert.ToDateTime(dr[tlncc.Ngaytra].ToString());
                    tralainhacungcap.MaNCC = dr[tlncc.MaNCC].ToString();
                    tralainhacungcap.TenNCC ="";
                    foreach (Entities.NhaCungCap item in ncc)
                    {
                        if (item.MaNhaCungCap == tralainhacungcap.MaNCC)
                        {
                            tralainhacungcap.TenNCC = item.TenNhaCungCap;
                            break;
                        }
                    }
                  
                    tralainhacungcap.NoHienThoi = dr[tlncc.NoHienThoi].ToString();
                    tralainhacungcap.NguoiNhanHang = dr[tlncc.NguoiNhanHang].ToString();
                    tralainhacungcap.HinhThucThanhToan = dr[tlncc.HinhThucThanhToan].ToString();
                    tralainhacungcap.MaHoaDonNhap = dr[tlncc.MaHoaDonNhap].ToString();
                    tralainhacungcap.MaKho = dr[tlncc.MaKho].ToString();
                    tralainhacungcap.MaTienTe = dr[tlncc.MaTienTe].ToString();
                    tralainhacungcap.TienBoiThuong = dr[tlncc.TienBoiThuong].ToString();
                    tralainhacungcap.ThanhToanNgay = dr[tlncc.ThanhToanNgay].ToString();
                    tralainhacungcap.ThueGTGT = dr[tlncc.ThueGTGT].ToString();
                    tralainhacungcap.GhiChu = dr[tlncc.GhiChu].ToString();
                    tralainhacungcap.Deleted = Convert.ToBoolean(dr[tlncc.Deleted].ToString());
                    arr.Add(tralainhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TraLaiNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TraLaiNCC)arr[i];
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
        public int sp_XuLy_TraLaiNhaCungCap(Entities.TraLaiNCC ncc)
        {
            int Trave = 0;
            try
            {
                tlncc = new Constants.TraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_TraLaiNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tlncc.HanhDong, SqlDbType.NVarChar, 20).Value = ncc.Hanhdong;
                cmd.Parameters.Add(tlncc.TraLaiNCCID, SqlDbType.Int).Value = ncc.TraLaiNCCID;
                cmd.Parameters.Add(tlncc.MaHDTraLaiNCC, SqlDbType.NVarChar, 20).Value = ncc.MaHDTraLaiNCC;
                cmd.Parameters.Add(tlncc.Ngaytra, SqlDbType.DateTime).Value = ncc.Ngaytra;
                cmd.Parameters.Add(tlncc.MaNCC, SqlDbType.NVarChar, 20).Value = ncc.MaNCC;
                cmd.Parameters.Add(tlncc.NoHienThoi, SqlDbType.Float).Value = ncc.NoHienThoi;
                cmd.Parameters.Add(tlncc.NguoiNhanHang, SqlDbType.NVarChar, 200).Value = ncc.NguoiNhanHang;
                cmd.Parameters.Add(tlncc.HinhThucThanhToan, SqlDbType.NVarChar, 200).Value = ncc.HinhThucThanhToan;
                cmd.Parameters.Add(tlncc.MaHoaDonNhap, SqlDbType.NVarChar, 20).Value = ncc.MaHoaDonNhap;
                cmd.Parameters.Add(tlncc.MaKho, SqlDbType.NVarChar, 20).Value = ncc.MaKho;
                cmd.Parameters.Add(tlncc.MaTienTe, SqlDbType.NVarChar, 20).Value = ncc.MaTienTe;
                cmd.Parameters.Add(tlncc.TienBoiThuong, SqlDbType.Float).Value = ncc.TienBoiThuong;
                cmd.Parameters.Add(tlncc.ThanhToanNgay, SqlDbType.Float).Value = ncc.ThanhToanNgay;
                cmd.Parameters.Add(tlncc.ThueGTGT, SqlDbType.Float).Value = ncc.ThueGTGT;
                cmd.Parameters.Add(tlncc.GhiChu, SqlDbType.NVarChar, 100).Value = ncc.GhiChu;
                cmd.Parameters.Add(tlncc.Deleted, SqlDbType.Bit).Value = ncc.Deleted;
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
        public int sp_Xoa_TraLaiNhaCungCap(Entities.TraLaiNCC ncc)
        {
            int Trave = 0;
            try
            {
                tlncc = new Constants.TraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_TraLaiNhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tlncc.HanhDong, SqlDbType.NVarChar, 20).Value = ncc.Hanhdong;
                cmd.Parameters.Add(tlncc.MaHDTraLaiNCC, SqlDbType.VarChar, 20).Value = ncc.MaHDTraLaiNCC;
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
        /// lay ban ghi kiem tra khi update
        /// </summary>
        /// <param name="truyen"></param>
        /// <returns></returns>
        public Entities.TraLaiNCC CheckTraLaiNhaCungCap(Entities.TruyenGiaTri truyen)
        {
            Entities.TraLaiNCC giatri = new Entities.TraLaiNCC();
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
                    giatri.TraLaiNCCID = Convert.ToInt32(dr[0].ToString());
                    giatri.MaHDTraLaiNCC = dr[1].ToString();
                    giatri.Ngaytra = Convert.ToDateTime(dr[2].ToString());
                    giatri.MaNCC = dr[3].ToString();
                    giatri.NoHienThoi = dr[4].ToString();
                    giatri.NguoiNhanHang = dr[5].ToString();
                    giatri.HinhThucThanhToan = dr[6].ToString();
                    giatri.MaHoaDonNhap = dr[7].ToString();
                    giatri.MaKho = dr[8].ToString();
                    giatri.MaTienTe = dr[9].ToString();
                    giatri.TienBoiThuong = dr[10].ToString();
                    giatri.ThanhToanNgay = dr[11].ToString();
                    giatri.ThueGTGT = dr[12].ToString();
                    giatri.GhiChu = dr[13].ToString();
                    giatri.Deleted = Convert.ToBoolean(dr[14].ToString());
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
