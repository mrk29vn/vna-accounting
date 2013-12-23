using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BizLogic
{
    public class GiaVonBanHang
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        public bool Insert(Entities.GiaVonBanHang gv)
        {
            bool kt = false;
            try
            {
                string sql = Common.GiaVonBanHang.Insert;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(Common.GiaVonBanHang.MaHoaDon, SqlDbType.VarChar, 50).Value = gv.MaHoaDon;
                cmd.Parameters.Add(Common.GiaVonBanHang.MaHangHoa, SqlDbType.VarChar, 50).Value = gv.MaHangHoa;
                cmd.Parameters.Add(Common.GiaVonBanHang.GiaVon, SqlDbType.Float).Value = gv.GiaVon;
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
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        public Entities.GiaVonBanHang[] Select(Entities.GiaVonBanHang gv)
        {
            string sql = Common.GiaVonBanHang.Select;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(Common.GiaVonBanHang.HanhDong, SqlDbType.VarChar, 50).Value = gv.HanhDong;
            cmd.Parameters.Add(Common.GiaVonBanHang.MaHoaDon, SqlDbType.VarChar, 50).Value = gv.MaHoaDon;
            cmd.Parameters.Add(Common.GiaVonBanHang.MaHangHoa, SqlDbType.VarChar, 50).Value = gv.MaHangHoa;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            List<Entities.GiaVonBanHang> arr = new List<Entities.GiaVonBanHang>();
            while (dr.Read())
            {
                Entities.GiaVonBanHang item = new Entities.GiaVonBanHang();
                //item.HanhDong = dr[Common.GiaVonBanHang.HanhDong].ToString();
                item.MaHoaDon = dr[Common.GiaVonBanHang.MaHoaDon].ToString();
                item.MaHangHoa = dr[Common.GiaVonBanHang.MaHangHoa].ToString();
                item.GiaVon = double.Parse(dr[Common.GiaVonBanHang.GiaVon].ToString());
                arr.Add(item);
            }
            int n = arr.Count;
            if (n == 0)
                return null;

            //Giai phong bo nho
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arr.ToArray();
        }
    }
}
