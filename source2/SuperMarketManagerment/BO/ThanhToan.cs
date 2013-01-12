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
  public  class ThanhToan
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ThanhToan tt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThanhToan thanhtoan;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThanhToan()
        {
            tt = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            thanhtoan = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.ThanhToan[] Select(Entities.ThanhToan ct)
        {

            Entities.ThanhToan[] arrC = null;
            try
            {
                tt = new Constants.ThanhToan();
                Sql = new Constants.Sql();
                string sql = Sql.ThanhToan;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tt.MaKhachHang, SqlDbType.NVarChar, 20).Value = ct.MaKhachHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                   thanhtoan = new Entities.ThanhToan();
                   thanhtoan.MaKhachHang = dr[tt.MaKhachHang].ToString();
                   thanhtoan.MaphieuTTcuaKH = dr[tt.MaPhieuTTCuaKH].ToString();
                   thanhtoan.NgayLap = Convert.ToDateTime(dr[tt.NgayLap].ToString());
                   thanhtoan.TrangThai = dr[tt.TrangThai].ToString();
                   thanhtoan.GhiChu = dr[tt.GhiChu].ToString();
                   thanhtoan.ThanhToan1 = dr[tt.Thanhtoan].ToString();
                   arr.Add(thanhtoan);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThanhToan[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThanhToan)arr[i];
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
