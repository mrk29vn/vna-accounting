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
    public class BCDTTheoNhomHang
    {
        Constants.BCDTTheoNhomHang dttnh;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.BCDTTheoNhomHang[] Select(Entities.BCDTTheoNhomHang bcdtt)
        {

            Sql = new Constants.Sql();
            dttnh = new Constants.BCDTTheoNhomHang();
            string sql = Sql.BCDTTheoNhomHangTheoma;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = bcdtt.MaNhomHang;
            cmd.Parameters.Add("@Truoc", SqlDbType.DateTime).Value = bcdtt.Truoc;
            cmd.Parameters.Add("@Sau", SqlDbType.DateTime).Value = bcdtt.Sau;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoNhomHang bcdtnh1 = new Entities.BCDTTheoNhomHang();
                bcdtnh1.MaHangHoa = dr[dttnh.MaHangHoa].ToString();
                bcdtnh1.TenHangHoa = dr[dttnh.TenHangHoa].ToString();
                bcdtnh1.MaNhomHang = dr[dttnh.MaNhomHang].ToString();
                bcdtnh1.TenNhomHang = dr[dttnh.TenNhomHang].ToString();
                bcdtnh1.NgayBan = Convert.ToDateTime(dr[dttnh.NgayBan].ToString());
                bcdtnh1.MaHDBanHang = dr[dttnh.MaHDBanHang].ToString();
                bcdtnh1.ThanhToanNgay = double.Parse(dr[dttnh.ThanhToanNgay].ToString());
                arr.Add(bcdtnh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoNhomHang[] arrC = new Entities.BCDTTheoNhomHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoNhomHang)arr[i];
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

        public Entities.BCDTTheoNhomHang[] Select()
        {

            Sql = new Constants.Sql();
            dttnh = new Constants.BCDTTheoNhomHang();
            string sql = Sql.BCDTTheoNhomHang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCDTTheoNhomHang bcdtnh1 = new Entities.BCDTTheoNhomHang();
                bcdtnh1.MaHangHoa = dr[dttnh.MaHangHoa].ToString();
                bcdtnh1.TenHangHoa = dr[dttnh.TenHangHoa].ToString();
                bcdtnh1.MaNhomHang = dr[dttnh.MaNhomHang].ToString();
                bcdtnh1.NgayBan = Convert.ToDateTime(dr[dttnh.NgayBan].ToString());
                bcdtnh1.MaHDBanHang = dr[dttnh.MaHDBanHang].ToString();
                bcdtnh1.ThanhToanNgay = double.Parse(dr[dttnh.ThanhToanNgay].ToString());
                arr.Add(bcdtnh1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCDTTheoNhomHang[] arrC = new Entities.BCDTTheoNhomHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCDTTheoNhomHang)arr[i];
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
