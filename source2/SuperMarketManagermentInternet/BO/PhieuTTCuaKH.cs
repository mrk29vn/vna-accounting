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
    public class PhieuTTCuaKH
    {
        Constants.PhieuTTCuaKH pt;
        Constants.Sql Sql;
        Entities.KhachHang[] kh;
        public void SelectKH()
        {
            kh = new BizLogic.KhachHang().Select();
            if (kh == null)
            {
                kh = new Entities.KhachHang[0];
            }
        }
        public string TimTenKH(string maKhachHang)
        {
            for (int i = 0; i < kh.Length; i++)
            {
                if (kh[i].MaKH == maKhachHang)
                {
                    return kh[i].Ten;
                }
            }
            return "";
        }
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.PhieuTTCuaKH[] Select()
        {
            SelectKH();
            try
            {
                Sql = new Constants.Sql();
                pt = new Constants.PhieuTTCuaKH();
                string sql = Sql.SelectPhieuTTCuaKH;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //Insert Category into ArrayList
                ArrayList arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.PhieuTTCuaKH phieuttckh = new Entities.PhieuTTCuaKH();
                    phieuttckh.PhieuTTCuaKHID = Convert.ToInt32(dr[pt.PhieuTTCuaKHID].ToString());
                    phieuttckh.MaPhieuTTCuaKH = dr[pt.MaPhieuTTCuaKH].ToString();
                    phieuttckh.NgayLap = Convert.ToDateTime(dr[pt.NgayLap].ToString());
                    phieuttckh.MaKhachHang = dr[pt.MaKhachHang].ToString();
                    phieuttckh.TenKhachHang = TimTenKH(phieuttckh.MaKhachHang);
                    phieuttckh.NoHienThoi = dr[pt.NoHienThoi].ToString();
                    phieuttckh.NguoiNop = dr[pt.NguoiNop].ToString();
                    phieuttckh.MaTienTe = dr[pt.MaTienTe].ToString();
                    phieuttckh.GhiChu = dr[pt.GhiChu].ToString();
                    phieuttckh.Deleted = (Boolean)dr[pt.Deleted];
                    arr.Add(phieuttckh);
                }
                int n = arr.Count;
                if (n == 0) return null;

                Entities.PhieuTTCuaKH[] arrC = new Entities.PhieuTTCuaKH[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.PhieuTTCuaKH)arr[i];
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
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public bool InsertUpdate(Entities.PhieuTTCuaKH pttckh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuTTCuaKH();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdatePhieuTTCuaKH;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pttckh.HanhDong;
                cmd.Parameters.Add(pt.PhieuTTCuaKHID, SqlDbType.Int).Value = pttckh.PhieuTTCuaKHID;
                cmd.Parameters.Add(pt.MaPhieuTTCuaKH, SqlDbType.NVarChar, 20).Value = pttckh.MaPhieuTTCuaKH;
                cmd.Parameters.Add(pt.NgayLap, SqlDbType.DateTime).Value = pttckh.NgayLap;
                cmd.Parameters.Add(pt.MaKhachHang, SqlDbType.NVarChar, 20).Value = pttckh.MaKhachHang;
                cmd.Parameters.Add(pt.NoHienThoi, SqlDbType.Float).Value = pttckh.NoHienThoi;
                cmd.Parameters.Add(pt.NguoiNop, SqlDbType.NVarChar, 200).Value = pttckh.NguoiNop;
                cmd.Parameters.Add(pt.MaTienTe, SqlDbType.NVarChar, 20).Value = pttckh.MaTienTe;
                cmd.Parameters.Add(pt.GhiChu, SqlDbType.NVarChar, 100).Value = pttckh.GhiChu;
                cmd.Parameters.Add(pt.Deleted, SqlDbType.Bit).Value = pttckh.Deleted;

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
        public bool Delete(Entities.PhieuTTCuaKH pttckh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuTTCuaKH();
                Sql = new Constants.Sql();
                string sql = Sql.DeletePhieuTTCuaKH;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pttckh.HanhDong;
                cmd.Parameters.Add(pt.PhieuTTCuaKHID, SqlDbType.Int).Value = pttckh.PhieuTTCuaKHID;

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
