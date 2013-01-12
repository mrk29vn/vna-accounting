using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class PhieuTTNCC
    {
        Constants.PhieuTTNCC pt;
        Constants.HoaDonNhap hoadonnhap;
        Constants.Sql Sql;
        Entities.NhaCungCap[] ncc;
        public void SelectNCC()
        {
            ncc = new BizLogic.NhaCungCap().Select();
            if (ncc == null)
                ncc = new Entities.NhaCungCap[0];
        }
        public string TimTenNCC(string maNCC)
        {
            for (int i = 0; i < ncc.Length; i++)
            {
                if (ncc[i].MaNhaCungCap == maNCC)
                {
                    return ncc[i].TenNhaCungCap;
                }
            }
            return "";
        }
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.PhieuTTNCC[] Select()
        {
            SelectNCC();
            pt = new Constants.PhieuTTNCC();
            Sql = new Constants.Sql();

            string sql = Sql.SelectPhieuTTNCC;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.PhieuTTNCC phieuttncc = new Entities.PhieuTTNCC();
                phieuttncc.PhieuTTNCCID = Convert.ToInt32(dr[pt.PhieuTTNCCID].ToString());
                phieuttncc.MaPhieuTTNCC = dr[pt.MaPhieuTTNCC].ToString();
                phieuttncc.NgayLap = Convert.ToDateTime(dr[pt.NgayLap].ToString());
                phieuttncc.MaNCC = dr[pt.MaNCC].ToString();
                phieuttncc.TenNhaCungCap = TimTenNCC(phieuttncc.MaNCC);
                phieuttncc.NoHienThoi = dr[pt.NoHienThoi].ToString();
                phieuttncc.Nguoinhan = dr[pt.Nguoinhan].ToString();
                phieuttncc.MaTienTe = dr[pt.MaTienTe].ToString();
                phieuttncc.GhiChu = dr[pt.GhiChu].ToString();
                phieuttncc.Deleted = (Boolean)dr[pt.Deleted];
                arr.Add(phieuttncc);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.PhieuTTNCC[] arrC = new Entities.PhieuTTNCC[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.PhieuTTNCC)arr[i];
            }

            //Giai phong bo nho
            arr = null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arrC;
        }

        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public bool InsertUpdate(Entities.PhieuTTNCC pttncc)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuTTNCC();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdatePhieuTTNCC;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pttncc.HanhDong;
                cmd.Parameters.Add(pt.PhieuTTNCCID, SqlDbType.Int).Value = pttncc.PhieuTTNCCID;
                cmd.Parameters.Add(pt.MaPhieuTTNCC, SqlDbType.NVarChar, 20).Value = pttncc.MaPhieuTTNCC;
                cmd.Parameters.Add(pt.NgayLap, SqlDbType.DateTime).Value = pttncc.NgayLap;
                cmd.Parameters.Add(pt.MaNCC, SqlDbType.NVarChar, 20).Value = pttncc.MaNCC;
                cmd.Parameters.Add(pt.NoHienThoi, SqlDbType.Float).Value = pttncc.NoHienThoi;
                cmd.Parameters.Add(pt.Nguoinhan, SqlDbType.NVarChar, 200).Value = pttncc.Nguoinhan;
                cmd.Parameters.Add(pt.MaTienTe, SqlDbType.NVarChar, 20).Value = pttncc.MaTienTe;
                cmd.Parameters.Add(pt.GhiChu, SqlDbType.NVarChar, 100).Value = pttncc.GhiChu;
                cmd.Parameters.Add(pt.Deleted, SqlDbType.Bit).Value = pttncc.Deleted;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Bảng
        /// </summary>
        public bool Delete(Entities.PhieuTTNCC pttncc)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuTTNCC();
                Sql = new Constants.Sql();
                string sql = Sql.DeletePhieuTTNCC;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pttncc.HanhDong;
                cmd.Parameters.Add(pt.PhieuTTNCCID, SqlDbType.Int).Value = pttncc.PhieuTTNCCID;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Thanh toán sau lập phiếu
        /// </summary>
        /// <returns></returns>

        public bool InsertUpdateSauKhiLapPhieu(Entities.HoaDonNhap hdn)
        {
            try
            {
                bool kt = false;
                hoadonnhap = new Constants.HoaDonNhap();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateThanhToanNgayHoaDonNhap;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hoadonnhap.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = hdn.MaHoaDonNhap;
                cmd.Parameters.Add(hoadonnhap.ThanhToanNgay, SqlDbType.Float).Value = hdn.ThanhToanSauKhiLapPhieu;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch
            {
                return false;
            }
        }
    }
}
