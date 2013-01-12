using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class BCDTTheoHangHoa
    {
        Constants.BCDTTheoHangHoa dtthh;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.BCDTTheoHangHoa[] Select(Entities.BCDTTheoHangHoa bcdtt)
        {

            Sql = new Constants.Sql();
            dtthh = new Constants.BCDTTheoHangHoa();
            string sql = Sql.BCDTTheoHangHoaTheoMa;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = bcdtt.MaHangHoa;
            cmd.Parameters.Add("@Truoc", SqlDbType.DateTime).Value = bcdtt.Truoc;
            cmd.Parameters.Add("@Sau", SqlDbType.DateTime).Value = bcdtt.Sau;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoHangHoa bcdthh1 = new Entities.BCDTTheoHangHoa();
                bcdthh1.MaHangHoa = dr[dtthh.MaHangHoa].ToString();
                bcdthh1.TenHangHoa = dr[dtthh.TenHangHoa].ToString();
                bcdthh1.MaHDBanHang = dr[dtthh.MaHDBanHang].ToString();
                bcdthh1.NgayBan =Convert.ToDateTime( dr[dtthh.NgayBan].ToString());
                bcdthh1.ThanhToanNgay =double.Parse(dr[dtthh.ThanhToanNgay].ToString());
                arr.Add(bcdthh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoHangHoa[] arrC = new Entities.BCDTTheoHangHoa[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoHangHoa)arr[i];
            }

            //Giai phong bo nho
            arr = null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arrC;
        }
        public Entities.BCDTTheoHangHoa[] Select()
        {

            Sql = new Constants.Sql();
            dtthh = new Constants.BCDTTheoHangHoa();
            string sql = Sql.BCDTTheoHangHoa;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoHangHoa bcdthh1 = new Entities.BCDTTheoHangHoa();
                bcdthh1.MaHangHoa = dr[dtthh.MaHangHoa].ToString();
                bcdthh1.TenHangHoa = dr[dtthh.TenHangHoa].ToString();
                bcdthh1.MaHDBanHang = dr[dtthh.MaHDBanHang].ToString();
                bcdthh1.NgayBan = Convert.ToDateTime(dr[dtthh.NgayBan].ToString());
                bcdthh1.ThanhToanNgay = double.Parse(dr[dtthh.ThanhToanNgay].ToString());
                arr.Add(bcdthh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoHangHoa[] arrC = new Entities.BCDTTheoHangHoa[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoHangHoa)arr[i];
            }

            //Giai phong bo nho
            arr = null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arrC;
        }
    }
}
