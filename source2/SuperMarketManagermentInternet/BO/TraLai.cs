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
   public class TraLai
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.TraLai tl;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.TraLai tralai;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public TraLai()
        {
            tl = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            tralai = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.TraLai[] Select(Entities.TraLai ct)
        {

            Entities.TraLai[] arrC = null;
            try
            {
                tl = new Constants.TraLai();
                Sql = new Constants.Sql();
                string sql = Sql.TraLai;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tl.MaKhachHang, SqlDbType.NVarChar, 20).Value = ct.MaKhachHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralai = new Entities.TraLai();
                    tralai.MaKhachHang = dr[0].ToString();
                    tralai.MaKhachHangTraLai = dr[1].ToString();
                    tralai.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    tralai.HinhThucThanhToan = dr[3].ToString();
                    tralai.GhiChu = dr[4].ToString();
                    tralai.ThanhToanNgay = dr[5].ToString();
                    arr.Add(tralai);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TraLai)arr[i];
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
