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
   public class LSGDNhapMua
    {
       /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.LSGDNhapMua lsgd;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.LSGDNhapMua lichsugiaodich;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public LSGDNhapMua()
        {
            lsgd = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            lichsugiaodich = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.LSGDNhapMua[] Select(Entities.LSGDNhapMua ct)
        {

            Entities.LSGDNhapMua[] arrC = null;
            try
            {
                lsgd = new Constants.LSGDNhapMua();
                Sql = new Constants.Sql();
                string sql = Sql.LSGDNhapMua;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(lsgd.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ct.MaNhaCungCap;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    lichsugiaodich = new Entities.LSGDNhapMua();
                    lichsugiaodich.MaNhaCungCap = dr[0].ToString();
                    lichsugiaodich.MaHoaDonNhap = dr[1].ToString();
                    lichsugiaodich.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    lichsugiaodich.HinhThucThanhToan = dr[3].ToString();
                    lichsugiaodich.GhiChu = dr[4].ToString();
                    lichsugiaodich.TongTien = dr[5].ToString();  
                    arr.Add(lichsugiaodich);
                    lichsugiaodich = null;
                
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LSGDNhapMua[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LSGDNhapMua)arr[i];
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
    }
}
