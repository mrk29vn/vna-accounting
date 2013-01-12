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
    public class DonHang
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.DonHang lsgd;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.DonHang lichsugiaodich;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public DonHang()
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
        public Entities.DonHang[] Select(Entities.DonHang ct)
        {

            Entities.DonHang[] arrC = null;
            try
            {
                lsgd = new Constants.DonHang();
                Sql = new Constants.Sql();
                string sql = Sql.DonHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(lsgd.MaKhachHang, SqlDbType.NVarChar, 20).Value = ct.MaKhachHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    lichsugiaodich = new Entities.DonHang();
                    lichsugiaodich.MaKhachHang = dr[0].ToString();
                    lichsugiaodich.MaDonDatHang = dr[1].ToString();
                    lichsugiaodich.NgayDonHang = Convert.ToDateTime(dr[2].ToString());
                    lichsugiaodich.HinhThucThanhToan = dr[3].ToString();
                    lichsugiaodich.GhiChu = dr[4].ToString();
                    lichsugiaodich.TongTienThanhToan = dr[5].ToString();
                    arr.Add(lichsugiaodich);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.DonHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.DonHang)arr[i];
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
