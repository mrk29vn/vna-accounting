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

    public class SoQuy
    {
        Constants.SoQuy pt;
        Constants.Sql Sql;
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.SoDuSoQuy[] Select()
        {
            try
            {
                Sql = new Constants.Sql();
                pt = new Constants.SoQuy();
                string sql = Sql.SelectSoDuSoQuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //Insert Category into ArrayList
                ArrayList arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.SoDuSoQuy phieuthu = new Entities.SoDuSoQuy();
                    phieuthu.SoDuSoQuyID = Convert.ToInt32(dr[pt.SoDuSoQuyID].ToString());
                    phieuthu.MaSoDuSoQuy = dr[pt.MaSoDuSoQuy].ToString();
                    phieuthu.SoDuDauKy = dr[pt.SoDuDauKy].ToString();
                    phieuthu.NgayKetChuyen = Convert.ToDateTime(dr[pt.NgayKetChuyen].ToString());
                    phieuthu.SoDuCuoiKy = dr[pt.SoDuCuoiKy].ToString();
                    phieuthu.TrangThai = Boolean.Parse(dr[pt.TrangThai].ToString());
                    arr.Add(phieuthu);
                }
                int n = arr.Count;
                if (n == 0) return null;

                Entities.SoDuSoQuy[] arrC = new Entities.SoDuSoQuy[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.SoDuSoQuy)arr[i];
                }

                //Giai phong bo nho
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
        public bool Insert(Entities.SoDuSoQuy pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.SoQuy();
                Sql = new Constants.Sql();
                string sql = Sql.InsertSoDuSoQuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaSoDuSoQuy, SqlDbType.VarChar, 20).Value = pxh.MaSoDuSoQuy;
                cmd.Parameters.Add(pt.SoDuDauKy, SqlDbType.Float).Value = pxh.SoDuDauKy;
                cmd.Parameters.Add(pt.NgayKetChuyen, SqlDbType.DateTime).Value = pxh.NgayKetChuyen;
                cmd.Parameters.Add(pt.SoDuCuoiKy, SqlDbType.Float).Value = pxh.SoDuCuoiKy;
                cmd.Parameters.Add(pt.TrangThai, SqlDbType.Bit).Value = pxh.TrangThai;
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
        public bool Update(Entities.SoDuSoQuy pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.SoQuy();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateSoDuSoQuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaSoDuSoQuy, SqlDbType.VarChar, 20).Value = pxh.MaSoDuSoQuy;
                cmd.Parameters.Add(pt.SoDuDauKy, SqlDbType.VarChar, 20).Value = pxh.SoDuDauKy;
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
        public bool UpdateTrangThai(Entities.SoDuSoQuy pxh)
        {
            try
            {
                if (pxh.SoDuSoQuyID == 0)
                {
                    Entities.SoDuSoQuy sdsq = new Entities.SoDuSoQuy("", pxh.MaSoDuSoQuy, "0", pxh.NgayKetChuyen, pxh.SoDuCuoiKy, true);
                    return Insert(sdsq);
                }
                bool kt = false;
                pt = new Constants.SoQuy();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateSoDuSoQuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.SoDuSoQuyID, SqlDbType.Int).Value = pxh.SoDuSoQuyID;
                cmd.Parameters.Add(pt.SoDuCuoiKy, SqlDbType.Float).Value = pxh.SoDuDauKy;
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
                Insert(pxh);
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
        public bool Delete(Entities.SoDuSoQuy pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.SoQuy();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteSoDuSoQuy;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaSoDuSoQuy, SqlDbType.VarChar,20).Value = pxh.MaSoDuSoQuy;

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
