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
    public class KMThuChi
    {
        private Constants.KMThuChi Kmtc;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public KMThuChi()
        {
            Kmtc = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.KMThuChi[] Select()
        {

            Entities.KMThuChi[] arrC = null;
            try
            {
                Kmtc = new Constants.KMThuChi();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllKMThuChi;

                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.KMThuChi kmtc = new Entities.KMThuChi();
                    kmtc.ThuChiID = Convert.ToInt32(dr[Kmtc.ThuChiID].ToString());
                    kmtc.MaKhoanMuc = dr[Kmtc.MaKhoanMuc].ToString();
                    kmtc.TenKhoanMuc = dr[Kmtc.TenKhoanMuc].ToString();
                    kmtc.LoaiKM = (bool)dr[Kmtc.LoaiKM];
                    kmtc.DoiTuong = dr[Kmtc.DoiTuong].ToString();
                    kmtc.NoTK = dr[Kmtc.NoTK].ToString();
                    kmtc.CoTK = dr[Kmtc.CoTK].ToString();
                    kmtc.GhiChu = dr[Kmtc.GhiChu].ToString();
                    kmtc.Deleted = (Boolean)dr[Kmtc.Deleted];
                    arr.Add(kmtc);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.KMThuChi[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KMThuChi)arr[i];
                }
                for (int i = 0; i < n; i++)
                {
                    if (arrC[i].LoaiKM==true)
                    {
                        arrC[i].TenLoaiKhoanMuc = "Khoản Mục Thu";
                    }
                    else
                    {
                        arrC[i].TenLoaiKhoanMuc = "Khoản Mục Chi";
                    }
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
        /// Lấy Khoản mục thu chi
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public Entities.KMThuChi[] LayKMThuChi(Boolean bl)
        {
            Entities.KMThuChi[] arrC = null;
            try
            {
                Kmtc = new Constants.KMThuChi();
                Sql = new Constants.Sql();
                string sql = Sql.LayKMThuChi;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@Loai", SqlDbType.Bit).Value = bl;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.KMThuChi kmtc = new Entities.KMThuChi();
                    kmtc.ThuChiID = Convert.ToInt32(dr[Kmtc.ThuChiID].ToString());
                    kmtc.MaKhoanMuc = dr[Kmtc.MaKhoanMuc].ToString();
                    kmtc.TenKhoanMuc = dr[Kmtc.TenKhoanMuc].ToString();
                    kmtc.LoaiKM = (bool)dr[Kmtc.LoaiKM];
                    kmtc.DoiTuong = dr[Kmtc.DoiTuong].ToString();
                    kmtc.NoTK = dr[Kmtc.NoTK].ToString();
                    kmtc.CoTK = dr[Kmtc.CoTK].ToString();
                    kmtc.GhiChu = dr[Kmtc.GhiChu].ToString();
                    Boolean kt = kmtc.Deleted = (Boolean)dr[Kmtc.Deleted];
                    if (kt == false)
                    {
                        arr.Add(kmtc);
                    }
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.KMThuChi[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KMThuChi)arr[i];
                }
            }

            catch
            { }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;

        }

        public int InsertUpdate(Entities.KMThuChi km1)
        {
            try
            {
                Kmtc = new Constants.KMThuChi();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateKMThuChi;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(Kmtc.HanhDong, SqlDbType.NVarChar, 20).Value = km1.HanhDong;
                cmd.Parameters.Add(Kmtc.ThuChiID, SqlDbType.Int).Value = km1.ThuChiID;
                cmd.Parameters.Add(Kmtc.MaKhoanMuc, SqlDbType.NVarChar, 20).Value = km1.MaKhoanMuc;
                cmd.Parameters.Add(Kmtc.TenKhoanMuc, SqlDbType.NVarChar, 200).Value = km1.TenKhoanMuc;
                cmd.Parameters.Add(Kmtc.LoaiKM, SqlDbType.Bit).Value = km1.LoaiKM;
                cmd.Parameters.Add(Kmtc.DoiTuong, SqlDbType.NVarChar, 200).Value = km1.DoiTuong;
                cmd.Parameters.Add(Kmtc.NoTK, SqlDbType.VarChar, 20).Value = km1.NoTK;
                cmd.Parameters.Add(Kmtc.CoTK, SqlDbType.VarChar, 20).Value = km1.CoTK;
                cmd.Parameters.Add(Kmtc.GhiChu, SqlDbType.NVarChar, 200).Value = km1.GhiChu;
                cmd.Parameters.Add(Kmtc.Deleted, SqlDbType.Bit).Value = km1.Deleted;

                int i = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return i;
            }
            catch (Exception ex) { string s = ex.Message; return 0; }
        }

        public void Delete(Entities.KMThuChi km1)
        {
            try
            {
                Kmtc = new Constants.KMThuChi();
                Entities.TKNganHang TKNganHang = new Entities.TKNganHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteKMThuChi;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(Kmtc.HanhDong, SqlDbType.NVarChar, 20).Value = km1.HanhDong;
                cmd.Parameters.Add(Kmtc.ThuChiID, SqlDbType.Int).Value = km1.ThuChiID;
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
