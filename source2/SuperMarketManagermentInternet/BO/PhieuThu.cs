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
    public class PhieuThu
    {
        Constants.PhieuThu pt;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.PhieuThu[] Select()
        {
            Sql = new Constants.Sql();
            pt = new Constants.PhieuThu();
            string sql = Sql.SelectPhieuThu;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.PhieuThu phieuthu = new Entities.PhieuThu();
                phieuthu.PhieuThuID = Convert.ToInt32(dr[pt.PhieuThuID].ToString());
                phieuthu.MaPhieuThu = dr[pt.MaPhieuThu].ToString();
                phieuthu.NgayLap = Convert.ToDateTime(dr[pt.NgayLap].ToString());
                phieuthu.LoaiPhieu = dr[pt.LoaiPhieu].ToString();
                phieuthu.MaKho = dr[pt.MaKho].ToString();
                phieuthu.MaNhomHang = dr[pt.MaNhomHang].ToString();
                phieuthu.KhoanMuc = dr[pt.KhoanMuc].ToString();
                phieuthu.DoiTuong = dr[pt.DoiTuong].ToString();
                phieuthu.NguoiNopTien = dr[pt.NguoiNopTien].ToString();
                phieuthu.NguoiNhanTien = dr[pt.NguoiNhanTien].ToString();
                phieuthu.NoTaiKhoan = dr[pt.NoTaiKhoan].ToString();
                phieuthu.CoTaiKhoan = dr[pt.CoTaiKhoan].ToString();
                phieuthu.TongTienThanhToan = dr[pt.TongTienThanhToan].ToString();
                phieuthu.MaTienTe = dr[pt.MaTienTe].ToString();
                phieuthu.TrangThai = (Boolean)dr[pt.TrangThai];
                phieuthu.GhiChu = dr[pt.GhiChu].ToString();
                phieuthu.Deleted = (Boolean)dr[pt.Deleted];
                arr.Add(phieuthu);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.PhieuThu[] arrC = new Entities.PhieuThu[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.PhieuThu)arr[i];
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

        public Entities.PhieuThu[] Select(int id)
        {

            Sql = new Constants.Sql();
            pt = new Constants.PhieuThu();
            string sql = Sql.SelectPhieuThuTheoma;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.PhieuThu phieuthu = new Entities.PhieuThu();
                phieuthu.PhieuThuID = Convert.ToInt32(dr[pt.PhieuThuID].ToString());
                phieuthu.MaPhieuThu = dr[pt.MaPhieuThu].ToString();
                phieuthu.NgayLap = Convert.ToDateTime(dr[pt.NgayLap].ToString());
                phieuthu.LoaiPhieu = dr[pt.LoaiPhieu].ToString();
                phieuthu.MaKho = dr[pt.MaKho].ToString();
                phieuthu.MaNhomHang = dr[pt.MaNhomHang].ToString();
                phieuthu.KhoanMuc = dr[pt.KhoanMuc].ToString();
                phieuthu.DoiTuong = dr[pt.DoiTuong].ToString();
                phieuthu.NguoiNopTien = dr[pt.NguoiNopTien].ToString();
                phieuthu.NguoiNhanTien = dr[pt.NguoiNhanTien].ToString();
                phieuthu.NoTaiKhoan = dr[pt.NoTaiKhoan].ToString();
                phieuthu.CoTaiKhoan = dr[pt.CoTaiKhoan].ToString();
                phieuthu.TongTienThanhToan = dr[pt.TongTienThanhToan].ToString();
                phieuthu.MaTienTe = dr[pt.MaTienTe].ToString();
                phieuthu.TrangThai = (Boolean)dr[pt.TrangThai];
                phieuthu.GhiChu = dr[pt.GhiChu].ToString();
                phieuthu.Deleted = (Boolean)dr[pt.Deleted];
                arr.Add(phieuthu);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.PhieuThu[] arrC = new Entities.PhieuThu[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.PhieuThu)arr[i];
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
        public bool InsertUpdate(Entities.PhieuThu pt1)
        {
            try
            {
                pt = new Constants.PhieuThu();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdatePhieuThu;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pt1.HanhDong;
                cmd.Parameters.Add(pt.PhieuThuID, SqlDbType.Int).Value = pt1.PhieuThuID;
                cmd.Parameters.Add(pt.MaPhieuThu, SqlDbType.VarChar, 20).Value = pt1.MaPhieuThu;
                cmd.Parameters.Add(pt.NgayLap, SqlDbType.DateTime).Value = pt1.NgayLap;
                cmd.Parameters.Add(pt.LoaiPhieu, SqlDbType.NVarChar, 20).Value = pt1.LoaiPhieu;
                cmd.Parameters.Add(pt.MaKho, SqlDbType.NVarChar, 20).Value = pt1.MaKho;
                cmd.Parameters.Add(pt.MaNhomHang, SqlDbType.NVarChar, 20).Value = pt1.MaNhomHang;
                cmd.Parameters.Add(pt.KhoanMuc, SqlDbType.NVarChar, 200).Value = pt1.KhoanMuc;
                cmd.Parameters.Add(pt.DoiTuong, SqlDbType.NVarChar, 20).Value = pt1.DoiTuong;
                cmd.Parameters.Add(pt.NguoiNopTien, SqlDbType.NVarChar, 200).Value = pt1.NguoiNopTien;
                cmd.Parameters.Add(pt.NguoiNhanTien, SqlDbType.NVarChar, 20).Value = pt1.NguoiNhanTien;
                cmd.Parameters.Add(pt.NoTaiKhoan, SqlDbType.VarChar, 20).Value = pt1.NoTaiKhoan;
                cmd.Parameters.Add(pt.CoTaiKhoan, SqlDbType.VarChar, 20).Value = pt1.CoTaiKhoan;
                cmd.Parameters.Add(pt.TongTienThanhToan, SqlDbType.Float).Value = pt1.TongTienThanhToan;
                cmd.Parameters.Add(pt.MaTienTe, SqlDbType.VarChar, 20).Value = pt1.MaTienTe;
                cmd.Parameters.Add(pt.TrangThai, SqlDbType.Bit).Value = pt1.TrangThai;
                cmd.Parameters.Add(pt.GhiChu, SqlDbType.NVarChar, 100).Value = pt1.GhiChu;
                cmd.Parameters.Add(pt.Deleted, SqlDbType.Bit).Value = pt1.Deleted;

                int i = cmd.ExecuteNonQuery();
                bool kt = false;
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
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete Bảng
        /// </summary>
        public bool Delete(Entities.PhieuThu pt1)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuThu();
                Entities.PhieuThu phieuthu = new Entities.PhieuThu();
                Sql = new Constants.Sql();
                string sql = Sql.DeletePhieuThu;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pt1.HanhDong;
                cmd.Parameters.Add(pt.PhieuThuID, SqlDbType.Int).Value = pt1.PhieuThuID;

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
