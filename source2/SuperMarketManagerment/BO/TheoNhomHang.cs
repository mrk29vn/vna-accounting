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
   public class TheoNhomHang
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.TheoNhomHang tnh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.TheoNhomHang theonhomhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public TheoNhomHang()
        {
            tnh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            theonhomhang = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.TheoNhomHang[] Select()
        {

            Entities.TheoNhomHang[] arrC = null;
            try
            {
                tnh = new Constants.TheoNhomHang();
                Sql = new Constants.Sql();
                string sql = Sql.TheoNhomHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    theonhomhang = new Entities.TheoNhomHang();
                    theonhomhang.MaNhomHangHoa = dr[tnh.MaNhomHangHoa].ToString();
                    theonhomhang.KieuHangHoa = dr[tnh.KieuHangHoa].ToString();
                    theonhomhang.NgayBatDau = Convert.ToDateTime(dr[tnh.NgayBatDau].ToString());
                    theonhomhang.NgayKetThuc = Convert.ToDateTime(dr[tnh.NgayKetThuc].ToString());
                    theonhomhang.GhiChu = dr[tnh.GhiChu].ToString();
                    arr.Add(theonhomhang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TheoNhomHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TheoNhomHang)arr[i];
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
