using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class ChiTietHDBanHang
    {
        Constants.ChiTietHDBanHang cthdbh;
        Constants.Sql Sql;
        public Entities.ChiTietHDBanHang[] Select(Entities.ChiTietHDBanHang hdbh1)
        {

            Sql = new Constants.Sql();
            cthdbh = new Constants.ChiTietHDBanHang();
            string sql = Sql.SelectChiTietHDBanHang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(cthdbh.MaHDBanHang, SqlDbType.VarChar).Value = hdbh1.MaHDBanHang;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietHDBanHang cthdbh1 = new Entities.ChiTietHDBanHang();
                cthdbh1.MaHDBanHang = dr[cthdbh.MaHDBanHang].ToString();
                cthdbh1.MaHangHoa = dr[cthdbh.MaHangHoa].ToString();
                cthdbh1.TenHangHoa = dr[cthdbh.TenHangHoa].ToString();
                cthdbh1.SoLuong = int.Parse(dr[cthdbh.SoLuong].ToString());
                cthdbh1.DonGia = (dr[cthdbh.DonGia].ToString());
                cthdbh1.Thue = (dr[cthdbh.Thue].ToString());
                cthdbh1.PhanTramChietKhau = float.Parse(dr[cthdbh.PhanTramChietKhau].ToString());
                cthdbh1.GhiChu = dr[cthdbh.GhiChu].ToString();
                cthdbh1.Deleted = (Boolean)dr[cthdbh.Deleted];
                arr.Add(cthdbh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietHDBanHang[] arrC = new Entities.ChiTietHDBanHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietHDBanHang)arr[i];
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

        public Entities.ChiTietHDBanHang[] Select()
        {

            Sql = new Constants.Sql();
            cthdbh = new Constants.ChiTietHDBanHang();
            string sql = "Select * from ChiTietHDBanHang where Deleted = 0";
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ChiTietHDBanHang cthdbh1 = new Entities.ChiTietHDBanHang();
                cthdbh1.MaHDBanHang = dr[cthdbh.MaHDBanHang].ToString();
                cthdbh1.MaHangHoa = dr[cthdbh.MaHangHoa].ToString();
                cthdbh1.TenHangHoa = dr[cthdbh.TenHangHoa].ToString();
                cthdbh1.SoLuong = int.Parse(dr[cthdbh.SoLuong].ToString());
                cthdbh1.DonGia = (dr[cthdbh.DonGia].ToString());
                cthdbh1.Thue = (dr[cthdbh.Thue].ToString());
                cthdbh1.PhanTramChietKhau = float.Parse(dr[cthdbh.PhanTramChietKhau].ToString());
                cthdbh1.GhiChu = dr[cthdbh.GhiChu].ToString();
                cthdbh1.Deleted = (Boolean)dr[cthdbh.Deleted];
                arr.Add(cthdbh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.ChiTietHDBanHang[] arrC = new Entities.ChiTietHDBanHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ChiTietHDBanHang)arr[i];
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

        public bool InsertUpdate(Entities.ChiTietHDBanHang hdbh1)
        {
            try
            {
                bool kt = false;
                cthdbh = new Constants.ChiTietHDBanHang();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateChiTietHDBanHangMang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(cthdbh.HanhDong, SqlDbType.NVarChar, 20).Value = hdbh1.HanhDong;
                cmd.Parameters.Add(cthdbh.MaHDBanHang, SqlDbType.VarChar).Value = hdbh1.MaHDBanHang;
                cmd.Parameters.Add(cthdbh.MaHangHoa, SqlDbType.VarChar, 50).Value = hdbh1.MaHangHoa;
                cmd.Parameters.Add(cthdbh.TenHangHoa, SqlDbType.NVarChar, 200).Value = hdbh1.TenHangHoa;
                cmd.Parameters.Add(cthdbh.SoLuong, SqlDbType.Int).Value = hdbh1.SoLuong;
                cmd.Parameters.Add(cthdbh.DonGia, SqlDbType.Float).Value = hdbh1.DonGia;
                cmd.Parameters.Add(cthdbh.Thue, SqlDbType.Float).Value = hdbh1.Thue;
                cmd.Parameters.Add(cthdbh.PhanTramChietKhau, SqlDbType.Float).Value = hdbh1.PhanTramChietKhau;
                cmd.Parameters.Add(cthdbh.GhiChu, SqlDbType.NVarChar, 100).Value = hdbh1.GhiChu;
                cmd.Parameters.Add(cthdbh.Deleted, SqlDbType.Bit).Value = hdbh1.Deleted;

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
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }

        public bool InsertUpdate(Entities.ChiTietHDBanHang[] ctxh2)
        {
            try
            {
                for (int i = 0; i < ctxh2.Length; i++)
                {
                    if (ctxh2[i].MaHDBanHang != "")
                        InsertUpdate(ctxh2[i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Entities.ChiTietHDBanHang[] ctxh2)
        {
            try
            {
                for (int i = 0; i < ctxh2.Length; i++)
                {
                    if (ctxh2[i].MaHDBanHang != "")
                        Delete(ctxh2[i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Entities.ChiTietHDBanHang hdbh1)
        {
            try
            {
                cthdbh = new Constants.ChiTietHDBanHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteChiTietBanHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(cthdbh.HanhDong, SqlDbType.NVarChar, 20).Value = hdbh1.HanhDong;
                cmd.Parameters.Add(cthdbh.MaHDBanHang, SqlDbType.Int).Value = hdbh1.MaHDBanHang;
                cmd.Parameters.Add(cthdbh.MaHangHoa, SqlDbType.VarChar, 50).Value = hdbh1.MaHangHoa;

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
    }
}
