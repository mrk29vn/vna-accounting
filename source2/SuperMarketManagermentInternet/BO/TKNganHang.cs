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
    public class TKNganHang
    {
        private Constants.TKNganHang TKNH;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public TKNganHang()
        {
            TKNH = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.TKNganHang[] Select()
        {

            Entities.TKNganHang[] arrC = null;
            try
            {
                TKNH = new Constants.TKNganHang();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllTKNganHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TKNganHang tknganhang = new Entities.TKNganHang();
                    tknganhang.TKNganHangID = Convert.ToInt32(dr[TKNH.TKNganHangID]);
                    tknganhang.MaTKNganHang = dr[TKNH.MaTKNganHang].ToString();
                    tknganhang.SoTK = dr[TKNH.SoTK].ToString();
                    tknganhang.MaTienTe = dr[TKNH.MaTienTe].ToString();
                    tknganhang.SoDu = (int)dr[TKNH.SoDu];
                    tknganhang.SoSecKeTiep = dr[TKNH.SoSecKeTiep].ToString();
                    tknganhang.NguoiLienHe = dr[TKNH.NguoiLienHe].ToString();
                    tknganhang.DiaChi = dr[TKNH.DiaChi].ToString();
                    tknganhang.DienThoai = dr[TKNH.DienThoai].ToString();
                    tknganhang.Email = dr[TKNH.Email].ToString();
                    tknganhang.Website = dr[TKNH.Website].ToString();
                    tknganhang.Ghichu = dr[TKNH.GhiChu].ToString();
                    tknganhang.Laisuat = float.Parse(dr[TKNH.Laisuat].ToString());
                    tknganhang.Deleted = Boolean.Parse(dr[TKNH.Deleted].ToString());
                    arr.Add(tknganhang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TKNganHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TKNganHang)arr[i];
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

        public int InsertUpdate(Entities.TKNganHang tk1)
        {
            TKNH = new Constants.TKNganHang();
            Sql = new Constants.Sql();
            string sql = Sql.InsertUpdateTKNganHang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(TKNH.HanhDong, SqlDbType.NVarChar, 20).Value = tk1.HanhDong;
            cmd.Parameters.Add(TKNH.TKNganHangID, SqlDbType.Int).Value = tk1.TKNganHangID;
            cmd.Parameters.Add(TKNH.MaTKNganHang, SqlDbType.NVarChar, 20).Value = tk1.MaTKNganHang;
            cmd.Parameters.Add(TKNH.SoTK, SqlDbType.NVarChar, 20).Value = tk1.SoTK;
            cmd.Parameters.Add(TKNH.MaTienTe, SqlDbType.NVarChar, 200).Value = tk1.MaTienTe;
            cmd.Parameters.Add(TKNH.SoDu, SqlDbType.Int).Value = tk1.SoDu;
            cmd.Parameters.Add(TKNH.SoSecKeTiep, SqlDbType.NVarChar, 20).Value = tk1.SoSecKeTiep;
            cmd.Parameters.Add(TKNH.NguoiLienHe, SqlDbType.NVarChar, 200).Value = tk1.NguoiLienHe;
            cmd.Parameters.Add(TKNH.DiaChi, SqlDbType.NVarChar, 200).Value = tk1.DiaChi;
            cmd.Parameters.Add(TKNH.DienThoai, SqlDbType.NVarChar, 20).Value = tk1.DienThoai;
            cmd.Parameters.Add(TKNH.Email, SqlDbType.NVarChar, 20).Value = tk1.Email;
            cmd.Parameters.Add(TKNH.Website, SqlDbType.NVarChar, 20).Value = tk1.Website;
            cmd.Parameters.Add(TKNH.GhiChu, SqlDbType.NVarChar, 200).Value = tk1.Ghichu;
            cmd.Parameters.Add(TKNH.Laisuat, SqlDbType.Float).Value = tk1.Laisuat;
            cmd.Parameters.Add(TKNH.Deleted, SqlDbType.Bit).Value = tk1.Deleted;

            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return i;
        }

        public void Delete(Entities.TKNganHang tk1)
        {
            try
            {
                TKNH = new Constants.TKNganHang();
                Entities.TKNganHang TKNganHang = new Entities.TKNganHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteTKNganHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(TKNH.HanhDong, SqlDbType.NVarChar, 20).Value = tk1.HanhDong;
                cmd.Parameters.Add(TKNH.TKNganHangID, SqlDbType.Int).Value = tk1.TKNganHangID;

                cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}
