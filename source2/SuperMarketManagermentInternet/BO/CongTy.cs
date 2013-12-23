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
  public  class CongTy
    {
      /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.CongTy ncc;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThongTinCongTy nhacungcap;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public CongTy()
        {
            ncc = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            nhacungcap = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinCongTy[] Select()
        {

            Entities.ThongTinCongTy[] arrC = null;
            try
            {
                ncc = new Constants.CongTy();
                Sql = new Constants.Sql();
                string sql = Sql.SelectCongTy;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
            while (dr.Read())
            {
                Entities.ThongTinCongTy nhacungcap= new Entities.ThongTinCongTy();
                nhacungcap.CongTyID = Convert.ToInt32(dr[ncc.CongTyID].ToString());
                nhacungcap.MaCongTy = dr[ncc.MaCongTy].ToString();
                nhacungcap.TenCongTy = dr[ncc.TenCongTy].ToString();
                nhacungcap.DiaChi = dr[ncc.DiaChi].ToString();
                nhacungcap.SoDienThoai = dr[ncc.SoDienThoai].ToString();
                nhacungcap.Email = dr[ncc.Email].ToString();
                nhacungcap.Website = dr[ncc.Website].ToString();
                nhacungcap.Fax = dr[ncc.Fax].ToString();

                arr.Add(nhacungcap);
            }
            int n = arr.Count;
            if (n == 0) { return null; }
            arrC = new Entities.ThongTinCongTy[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.ThongTinCongTy)arr[i];
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
        /// Insert Update Bảng
        /// </summary>
        public Entities.ThongTinCongTy InsertUpdate(Entities.ThongTinCongTy ncc1)
        {
            Entities.ThongTinCongTy nhacungcap = null;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateCongTy;
                conn = new Connection();
                ncc = new Constants.CongTy();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ncc.HanhDong, SqlDbType.NVarChar, 20).Value = ncc1.HanhDong;
                cmd.Parameters.Add(ncc.CongTyID, SqlDbType.Int).Value =ncc1.CongTyID;
                cmd.Parameters.Add(ncc.MaCongTy, SqlDbType.NVarChar, 20).Value =ncc1.MaCongTy;
                cmd.Parameters.Add(ncc.TenCongTy, SqlDbType.NVarChar, 200).Value =ncc1.TenCongTy;
                cmd.Parameters.Add(ncc.DiaChi, SqlDbType.NVarChar, 200).Value =ncc1. DiaChi;
                cmd.Parameters.Add(ncc.SoDienThoai, SqlDbType.NVarChar, 20).Value =ncc1.SoDienThoai;
                cmd.Parameters.Add(ncc.Email, SqlDbType.NVarChar, 50).Value =ncc1. Email;
                cmd.Parameters.Add(ncc.Website, SqlDbType.NVarChar, 50).Value = ncc1.Website;
                cmd.Parameters.Add(ncc.Fax, SqlDbType.NVarChar, 20).Value =ncc1.Fax;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    nhacungcap = new Entities.ThongTinCongTy();
                    nhacungcap.MaCongTy = dr[0].ToString();
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
            return nhacungcap;   
        }
    }
}
