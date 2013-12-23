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
    public class PhieuXuatHuy
    {
        Constants.PhieuXuatHuy pt;
        Constants.Sql Sql;
        Entities.NhanVien[] nv;
        public void SelectNV()
        {
            nv = new BizLogic.NhanVien().Select();
            if (nv == null)
                nv = new Entities.NhanVien[0];
        }
        public string TimTenNV(string maNhanVien)
        {
            for (int i = 0; i < nv.Length; i++)
            {
                if (nv[i].MaNhanVien == maNhanVien)
                    return nv[i].TenNhanVien;
            }
            return "";
        }
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.PhieuXuatHuy[] Select()
        {
            SelectNV();
            Sql = new Constants.Sql();
            pt = new Constants.PhieuXuatHuy();
            string sql = Sql.SelectPhieuXuatHuy;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.PhieuXuatHuy phieuxuathuy = new Entities.PhieuXuatHuy();
                phieuxuathuy.PhieuXuatHuyID = Convert.ToInt32(dr[pt.PhieuXuatHuyID].ToString());
                phieuxuathuy.MaPhieuXuatHuy = dr[pt.MaPhieuXuatHuy].ToString();
                phieuxuathuy.NgayLap = Convert.ToDateTime(dr[pt.NgayLap].ToString());
                phieuxuathuy.MaNhanVien = dr[pt.MaNhanVien].ToString();
                phieuxuathuy.TenNhanVien = TimTenNV(phieuxuathuy.MaNhanVien);
                phieuxuathuy.MaKho = dr[pt.MaKho].ToString();
                phieuxuathuy.TrangThai = (Boolean) dr[pt.TrangThai];
                phieuxuathuy.Tongtien = dr[pt.Tongtien].ToString();
                phieuxuathuy.GhiChu = dr[pt.GhiChu].ToString();
                phieuxuathuy.Deleted = (Boolean) dr[pt.Deleted];
                arr.Add(phieuxuathuy);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.PhieuXuatHuy[] arrC = new Entities.PhieuXuatHuy[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.PhieuXuatHuy)arr[i];
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
        public Entities.PhieuXuatHuy[] SelectTheoMaKho(string MaKho)
        {
            SelectNV();
            pt = new Constants.PhieuXuatHuy();
            string sql = "";
            sql = "Select * from PhieuXuatHuy where MaKho='" + MaKho + "' and deleted=0";
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.PhieuXuatHuy phieuxuathuy = new Entities.PhieuXuatHuy();
                phieuxuathuy.PhieuXuatHuyID = Convert.ToInt32(dr[pt.PhieuXuatHuyID].ToString());
                phieuxuathuy.MaPhieuXuatHuy = dr[pt.MaPhieuXuatHuy].ToString();
                phieuxuathuy.NgayLap = Convert.ToDateTime(dr[pt.NgayLap].ToString());
                phieuxuathuy.MaNhanVien = dr[pt.MaNhanVien].ToString();
                phieuxuathuy.TenNhanVien = TimTenNV(phieuxuathuy.MaNhanVien);
                phieuxuathuy.MaKho = dr[pt.MaKho].ToString();
                phieuxuathuy.TrangThai = (Boolean)dr[pt.TrangThai];
                phieuxuathuy.Tongtien = dr[pt.Tongtien].ToString();
                phieuxuathuy.GhiChu = dr[pt.GhiChu].ToString();
                phieuxuathuy.Deleted = (Boolean)dr[pt.Deleted];
                arr.Add(phieuxuathuy);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.PhieuXuatHuy[] arrC = new Entities.PhieuXuatHuy[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.PhieuXuatHuy)arr[i];
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
        public bool InsertUpdate(Entities.PhieuXuatHuy pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuXuatHuy();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdatePhieuXuatHuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pxh.HanhDong;
                cmd.Parameters.Add(pt.PhieuXuatHuyID, SqlDbType.Int).Value = pxh.PhieuXuatHuyID;
                cmd.Parameters.Add(pt.MaPhieuXuatHuy, SqlDbType.NVarChar, 20).Value = pxh.MaPhieuXuatHuy;
                cmd.Parameters.Add(pt.NgayLap, SqlDbType.DateTime).Value = pxh.NgayLap;
                cmd.Parameters.Add(pt.MaNhanVien, SqlDbType.NVarChar, 20).Value = pxh.MaNhanVien;
                cmd.Parameters.Add(pt.MaKho, SqlDbType.NVarChar, 20).Value = pxh.MaKho;
                cmd.Parameters.Add(pt.TrangThai, SqlDbType.Bit).Value = pxh.TrangThai;
                cmd.Parameters.Add(pt.Tongtien, SqlDbType.Money).Value = pxh.Tongtien;
                cmd.Parameters.Add(pt.GhiChu, SqlDbType.NVarChar, 100).Value = pxh.GhiChu;
                cmd.Parameters.Add(pt.Deleted, SqlDbType.Bit).Value = pxh.Deleted;

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
        /// Insert Update Bảng
        /// </summary>
        public bool UpdateTinhTrang(Entities.PhieuXuatHuy pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuXuatHuy();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateTinhTrang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaPhieuXuatHuy, SqlDbType.VarChar,20).Value = pxh.MaPhieuXuatHuy;
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

        public bool UpdateTinhTrang(Entities.PhieuXuatHuy[] pxh)
        {
            try
            {
                for (int i = 0; i < pxh.Length; i++)
                {
                    if (pxh[i].MaPhieuXuatHuy != "")
                    {
                       UpdateTinhTrang(pxh[i]);
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
        /// Delete Bảng
        /// </summary>
        public bool Delete(Entities.PhieuXuatHuy pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.PhieuXuatHuy();
                Sql = new Constants.Sql();
                string sql = Sql.DeletePhieuXuatHuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(pt.HanhDong, SqlDbType.NVarChar, 20).Value = pxh.HanhDong;
                cmd.Parameters.Add(pt.PhieuXuatHuyID, SqlDbType.Int).Value = pxh.PhieuXuatHuyID;

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
