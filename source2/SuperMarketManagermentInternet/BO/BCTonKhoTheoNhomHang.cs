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
    public class BCTonKhoTheoNhomHang
    {
        Constants.BCTonKhoTheoNhomHang bctknh;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.BCTonKhoTheoNhomHang[] Select(Entities.BCTonKhoTheoNhomHang bctktnh)
        {

            Sql = new Constants.Sql();
            bctknh = new Constants.BCTonKhoTheoNhomHang();
            string sql = Sql.selectBCTonKhoTheoNhomHangTheoMa;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@MaNhomHang", SqlDbType.VarChar, 20).Value = bctktnh.MaNhomHang;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCTonKhoTheoNhomHang bctktkk = new Entities.BCTonKhoTheoNhomHang();
                bctktkk.MaNhomHang = dr[bctknh.MaNhomHang].ToString();
                bctktkk.TenNhomHang = dr[bctknh.TenNhomHang].ToString();
                bctktkk.MaHangHoa= dr[bctknh.MaHangHoa].ToString();
                bctktkk.TenHangHoa = dr[bctknh.TenHangHoa].ToString();
                bctktkk.TenKho = dr[bctknh.TenKho].ToString();
                bctktkk.HanSuDung = DateTime.Parse(dr[bctknh.HanSuDung].ToString());
                bctktkk.SoLuong = Convert.ToInt32(dr[bctknh.SoLuong].ToString());
                arr.Add(bctktkk);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCTonKhoTheoNhomHang[] arrC = new Entities.BCTonKhoTheoNhomHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCTonKhoTheoNhomHang)arr[i];
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
        public Entities.BCTonKhoTheoNhomHang[] Select()
        {

            Sql = new Constants.Sql();
            bctknh = new Constants.BCTonKhoTheoNhomHang();
            string sql = Sql.selectBCTonKhoTheoNhomHang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCTonKhoTheoNhomHang bctktkk = new Entities.BCTonKhoTheoNhomHang();
                bctktkk.MaNhomHang = dr[bctknh.MaNhomHang].ToString();
                bctktkk.TenNhomHang = dr[bctknh.TenNhomHang].ToString();
                bctktkk.MaHangHoa = dr[bctknh.MaHangHoa].ToString();
                bctktkk.TenHangHoa = dr[bctknh.TenHangHoa].ToString();
                bctktkk.TenKho = dr[bctknh.TenKho].ToString();
                bctktkk.HanSuDung = DateTime.Parse(dr[bctknh.HanSuDung].ToString());
                bctktkk.SoLuong = Convert.ToInt32(dr[bctknh.SoLuong].ToString());
                arr.Add(bctktkk);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCTonKhoTheoNhomHang[] arrC = new Entities.BCTonKhoTheoNhomHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCTonKhoTheoNhomHang)arr[i];
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
