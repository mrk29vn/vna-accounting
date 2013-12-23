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
    public class KhoHang
    {
        private Constants.KhoHang kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.KhoHang khohang;
        private SqlConnection cn;

        public KhoHang()
        {
            kh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khohang = null;
            cn = null;
        }

        /// <summary>
        /// lay thong tin cac kho hang
        /// </summary>
        /// <returns></returns>
        public Entities.KhoHang[] sp_SelectKhoHangsAll()
        {
            List<Entities.KhoHang> L = new List<Entities.KhoHang>();
            try
            {
                kh = new Constants.KhoHang();
                cn = new Connection().openConnection();
                cmd = new SqlCommand("exec sp_SelectKhoHangsAll", cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    khohang = new Entities.KhoHang();
                    khohang.MaKho = dr[kh.MaKho].ToString();
                    khohang.TenKho = dr[kh.TenKho].ToString();
                    khohang.DiaChi = dr[kh.DiaChi].ToString();
                    khohang.DienThoai = dr[kh.DienThoai].ToString();
                    khohang.MaNhanVien = dr[kh.MaNhanVien].ToString();
                    khohang.GhiChu = dr[kh.GhiChu].ToString();
                    L.Add(khohang);
                }
            }
            catch { return null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
            }
            return L.ToArray();
        }

        public Entities.KhoHang[] Select()
        {
            return sp_SelectKhoHangsAll();
        }

        //insert update
        public Entities.KhoHang InsertUpdate(Entities.KhoHang kh1)
        {
            Entities.KhoHang k = new Entities.KhoHang();
            try
            {
                kh = new Constants.KhoHang();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateKhoHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.KhoHangID, SqlDbType.Int).Value = kh1.KhoHangID;
                cmd.Parameters.Add(kh.MaKho, SqlDbType.VarChar, 20).Value = kh1.MaKho;
                cmd.Parameters.Add(kh.TenKho, SqlDbType.NVarChar, 200).Value = kh1.TenKho;
                cmd.Parameters.Add(kh.DiaChi, SqlDbType.NVarChar, 200).Value = kh1.DiaChi;
                cmd.Parameters.Add(kh.DienThoai, SqlDbType.NVarChar, 200).Value = kh1.DienThoai;
                cmd.Parameters.Add(kh.MaNhanVien, SqlDbType.NVarChar, 200).Value = kh1.MaNhanVien;
                cmd.Parameters.Add(kh.GhiChu, SqlDbType.NVarChar, 100).Value = kh1.GhiChu;
                cmd.Parameters.Add(kh.Deleted, SqlDbType.Bit).Value = kh1.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    k.GhiChu = dr[0].ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); k.GhiChu = null; }
            return k;
        }

        //delete
        public int Delete(Entities.KhoHang kh1)
        {
            int tra = 0;
            try
            {
                kh = new Constants.KhoHang();
                Entities.KhoHang khohang = new Entities.KhoHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteKhoHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.KhoHangID, SqlDbType.Int).Value = kh1.KhoHangID;
                tra = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
            }
            catch (Exception ex)
            { string s = ex.Message; tra = 0; }
            return tra;
        }

        /// <summary>
        /// lay ban ghi dang update
        /// </summary>
        public Entities.KhoHang sp_LayBang_TheoTenBang(Entities.TruyenGiaTri chuyen)
        {
            Entities.KhoHang giatri = new Entities.KhoHang();
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
                    giatri.KhoHangID = int.Parse(dr[0].ToString());
                    giatri.MaKho = dr[1].ToString();
                    giatri.TenKho = dr[2].ToString();
                    giatri.DiaChi =  dr[3].ToString();
                    giatri.DienThoai = dr[4].ToString();
                    giatri.MaNhanVien = dr[5].ToString();
                    giatri.GhiChu = ""+dr[6].ToString();
                    giatri.Deleted = Boolean.Parse(dr[7].ToString());
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
    }
}
