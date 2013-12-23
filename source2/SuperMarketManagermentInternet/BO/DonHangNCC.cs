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
   public class DonHangNCC
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.DonHangNCC hh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.DonHangNCC hanghoa;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public DonHangNCC()
        {
            hh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hanghoa = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.DonHangNCC[] Select(Entities.DonHangNCC ct)
        {

            Entities.DonHangNCC[] arrC = null;
            try
            {
                hh = new Constants.DonHangNCC();
                Sql = new Constants.Sql();
                string sql = Sql.DonHangNCC;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hh.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ct.MaNhaCungCap;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    hanghoa = new Entities.DonHangNCC();
                   hanghoa.MaNhaCungCap = dr[0].ToString();
                   hanghoa.MaDonDatHang = dr[1].ToString();
                   hanghoa.NgayDonHang = Convert.ToDateTime(dr[2].ToString());
                   hanghoa.TrangThaiDonDatHang = dr[3].ToString();
                   hanghoa.HinhThucThanhToan = dr[4].ToString();
                   hanghoa.TongTien = dr[5].ToString();
                   arr.Add(hanghoa);
                   hanghoa = null;
                   
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.DonHangNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.DonHangNCC)arr[i];
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
