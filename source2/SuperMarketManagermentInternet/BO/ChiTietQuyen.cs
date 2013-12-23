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
    public class ChiTietQuyen
    {
        private Constants.ChiTietQuyen ctq;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietQuyen chitietquyen;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietQuyen()
        {
            ctq = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            chitietquyen = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        /// 

        public Entities.ChiTietQuyen[] selectChiTietQuyen(Entities.ChiTietQuyen ctq1)
        {

            Entities.ChiTietQuyen[] arrC = null;
            try
            {
                ctq = new Constants.ChiTietQuyen();
                Sql = new Constants.Sql();
                string sql = Sql.selectChiTietQuyen;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ctq.TenNhomQuyen, SqlDbType.NVarChar, 50).Value = ctq1.TenNhomQuyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    chitietquyen = new Entities.ChiTietQuyen();
                    chitietquyen.TenNhomQuyen = dr[ctq.TenNhomQuyen].ToString();
                    chitietquyen.TenForm = dr[ctq.TenForm].ToString();
                    chitietquyen.Ten = dr[ctq.Ten].ToString();
                    chitietquyen.QuyenSua = (bool)dr[ctq.QuyenSua];
                    chitietquyen.QuyenThem = (bool)dr[ctq.QuyenThem];
                    chitietquyen.QuyenXem = (bool)dr[ctq.QuyenXem];
                    chitietquyen.QuyenXoa = (bool)dr[ctq.QuyenXoa];
                    chitietquyen.SaoLuuDuLieu = (bool)dr[ctq.SaoLuuDuLieu];
                    chitietquyen.CapNhatDuLieu = (bool)dr[ctq.CapNhatDuLieu];
                    arr.Add(chitietquyen);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietQuyen[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietQuyen)arr[i];
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
        /// update bang Chi tiet Quyen
        /// </summary>
        /// <param name="ctq1"></param>
        /// <returns></returns>
        public bool update(Entities.ChiTietQuyen[] ctq1)
        {
            try
            {
                if (ctq1.Length!=null)
                {
                    foreach (Entities.ChiTietQuyen item in ctq1)
                    {
                        bool kt = updateChiTietQuyen(item);
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool updateChiTietQuyen(Entities.ChiTietQuyen ctq1)
        {
            try
            {
                bool kt = false;
                ctq = new Constants.ChiTietQuyen();
                Sql = new Constants.Sql();
                string sql = Sql.updateChiTietQuyen;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add(ctq.TenNhomQuyen, SqlDbType.VarChar, 50).Value = ctq1.TenNhomQuyen;
                cmd.Parameters.Add(ctq.TenForm, SqlDbType.VarChar, 50).Value = ctq1.TenForm;
                cmd.Parameters.Add(ctq.QuyenSua, SqlDbType.Bit).Value = ctq1.QuyenSua;
                cmd.Parameters.Add(ctq.QuyenThem, SqlDbType.Bit).Value = ctq1.QuyenThem;
                cmd.Parameters.Add(ctq.QuyenXem, SqlDbType.Bit).Value = ctq1.QuyenXem;
                cmd.Parameters.Add(ctq.QuyenXoa, SqlDbType.Bit).Value = ctq1.QuyenXoa;
                cmd.Parameters.Add(ctq.SaoLuuDuLieu, SqlDbType.Bit).Value = ctq1.SaoLuuDuLieu;
                cmd.Parameters.Add(ctq.CapNhatDuLieu, SqlDbType.Bit).Value = ctq1.CapNhatDuLieu;


                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
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

