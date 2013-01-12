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
  public  class XuatHang
    {
          /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.XuatHang xh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.XuatHang xuathang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public XuatHang()
        {
            xh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            xuathang = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.XuatHang[] Select(Entities.XuatHang ct)
        {

            Entities.XuatHang[] arrC = null;
            try
            {
                xh = new Constants.XuatHang();
                Sql = new Constants.Sql();
                string sql = Sql.XuatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(xh.MaKhachHang, SqlDbType.NVarChar, 20).Value = ct.MaKhachHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    xuathang = new Entities.XuatHang();
                    xuathang.MaKhachHang = dr[xh.MaKhachHang].ToString();
                    xuathang.MaHDBanHang = dr[xh.MaHDBanHang].ToString();
                    xuathang.NgayBan = Convert.ToDateTime(dr[xh.NgayBan].ToString());
                    xuathang.HinhThucThanhToan = dr[xh.HinhThucThanhToan].ToString();
                    xuathang.GhiChu = dr[xh.GhiChu].ToString();
                    xuathang.TongTienThanhToan = dr[xh.TongTienThanhToan].ToString();
                    arr.Add(xuathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.XuatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.XuatHang)arr[i];
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
