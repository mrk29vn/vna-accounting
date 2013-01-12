using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace BizLogic
{
    public class SoDuKho
    {
        Constants.SoDuKho sdk;
        Constants.Sql Sql;
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.SoDuKho[] Select()
        {
            try
            {
                List<Entities.SoDuKho> L = new List<Entities.SoDuKho>();
                SqlCommand cmd = new SqlCommand("exec sp_SelectSoDuKhosAll", new Connection().openConnection());
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.SoDuKho sdk = new Entities.SoDuKho();
                    sdk.MaSoDuKho = dr["MaSoDuKho"].ToString();
                    sdk.MaKho = dr["MaKho"].ToString();
                    sdk.MaHangHoa = dr["MaHangHoa"].ToString();
                    sdk.TenHangHoa = dr["TenHangHoa"].ToString();
                    sdk.SoDuDauKy = Convert.ToInt32(dr["SoDuDauKy"].ToString());
                    sdk.NgayKetChuyen = Convert.ToDateTime(dr["NgayKetChuyen"].ToString());
                    sdk.SoDuCuoiKy = Convert.ToInt32(dr["SoDuCuoiKy"].ToString());
                    sdk.TrangThai = Boolean.Parse(dr["TrangThai"].ToString());
                    L.Add(sdk);
                }
                cmd.Connection.Dispose();
                //Giai phong bo nho
                return L.ToArray();
            }
            catch { return null; }
        }
        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public bool Insert(Entities.SoDuKho pxh)
        {
            try
            {
                bool kt = false;
                sdk = new Constants.SoDuKho();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateSoDuKho;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(sdk.HanhDong, SqlDbType.VarChar, 20).Value = pxh.HanhDong;
                cmd.Parameters.Add(sdk.SoDuKhoID, SqlDbType.Int).Value = pxh.SoDuKhoID;
                cmd.Parameters.Add(sdk.MaSoDuKho, SqlDbType.VarChar, 20).Value = pxh.MaSoDuKho;
                cmd.Parameters.Add(sdk.MaKho, SqlDbType.VarChar, 20).Value = pxh.MaKho;
                cmd.Parameters.Add(sdk.MaHangHoa, SqlDbType.VarChar, 50).Value = pxh.MaHangHoa;
                cmd.Parameters.Add(sdk.SoDuDauKy, SqlDbType.Int).Value = pxh.SoDuDauKy;
                cmd.Parameters.Add(sdk.NgayKetChuyen, SqlDbType.DateTime).Value = pxh.NgayKetChuyen;
                cmd.Parameters.Add(sdk.SoDuCuoiKy, SqlDbType.Int).Value = pxh.SoDuCuoiKy;
                cmd.Parameters.Add(sdk.TrangThai, SqlDbType.Bit).Value = pxh.TrangThai;
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
        public bool InsertArr(Entities.SoDuKho[] pxh)
        {
            try
            {
                bool kt = true;
                for (int i = 0; i < pxh.Length; i++)
                {
                    bool kt1 = Insert(pxh[i]);
                    if (!kt1)
                    {
                        kt = false;
                    }

                }
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
        ////public bool Update(Entities.SoDuKho pxh)
        ////{
        ////    try
        ////    {
        ////        bool kt = false;
        ////        sdk = new Constants.SoDuKho();
        ////        Sql = new Constants.Sql();
        ////        string sql = Sql.UpdateSoDuSoQuy;
        ////        Connection conn = new Connection();
        ////        SqlConnection cn = conn.openConnection();
        ////        SqlCommand cmd = new SqlCommand(sql, cn);
        ////        cmd.Parameters.Add(sdk.MaSoDuKho, SqlDbType.VarChar, 20).Value = pxh.MaSoDuSoQuy;
        ////        cmd.Parameters.Add(sdk.SoDuDauKy, SqlDbType.VarChar, 20).Value = pxh.SoDuDauKy;
        ////        int i = cmd.ExecuteNonQuery();
        ////        if (i == 1)
        ////            kt = true;
        ////        else
        ////            kt = false;
        ////        cmd.Connection.Dispose();
        ////        cn.Close();
        ////        conn.closeConnection();
        ////        cn = null;
        ////        conn = null;
        ////        return kt;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}
        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        ////public bool UpdateTrangThai(Entities.SoDuKho pxh)
        ////{
        ////    try
        ////    {
        ////        if (pxh.SoDuKhoID == 0)
        ////        {
        ////            Entities.SoDuKho sdsq = new Entities.SoDuKho("",1, pxh.MaSoDuKho, 0, pxh.NgayKetChuyen, pxh.SoDuCuoiKy, true);
        ////            return Insert(sdsq);
        ////        }
        ////        bool kt = false;
        ////        sdk = new Constants.SoDuKho();
        ////        Sql = new Constants.Sql();
        ////        string sql = Sql.UpdateSoDuSoQuy;
        ////        Connection conn = new Connection();
        ////        SqlConnection cn = conn.openConnection();
        ////        SqlCommand cmd = new SqlCommand(sql, cn);
        ////        cmd.Parameters.Add(sdk.SoDuKhoID, SqlDbType.Int).Value = pxh.SoDuSoQuyID;
        ////        cmd.Parameters.Add(sdk.SoDuCuoiKy, SqlDbType.Float).Value = pxh.SoDuDauKy;
        ////        int i = cmd.ExecuteNonQuery();
        ////        if (i == 1)
        ////            kt = true;
        ////        else
        ////            kt = false;
        ////        cmd.Connection.Dispose();
        ////        cn.Close();
        ////        conn.closeConnection();
        ////        cn = null;
        ////        conn = null;
        ////        Insert(pxh);
        ////        return kt;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}
        //// <summary>
        //// Delete Bảng
        //// </summary>
        public bool Delete(Entities.SoDuKho pxh)
        {
            try
            {
                bool kt = false;
                sdk = new Constants.SoDuKho();
                Sql = new Constants.Sql();
                string sql = "exec sp_DeleteSoDuKho @MaSoDuKho";
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(sdk.MaSoDuKho, SqlDbType.VarChar, 20).Value = pxh.MaSoDuKho;
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
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
        public bool DeleteArr(Entities.SoDuKho[] pxh)
        {
            try
            {
                bool kt = true;
                for (int i = 0; i < pxh.Length; i++)
                {
                    bool kt1 = Delete(pxh[i]);
                    if (!kt1)
                    {
                        kt = false;
                    }
                }
                return kt;
            }
            catch
            {
                return false;
            }
        }
    }
}
