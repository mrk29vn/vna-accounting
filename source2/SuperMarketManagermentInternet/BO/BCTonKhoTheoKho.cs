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
    public class BCTonKhoTheoKho
    {
        Constants.BCTonKhoTheoKho bctktk;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.BCTonKhoTheoKho[] Select(Entities.BCTonKhoTheoKho bctktk1)
        {

            Sql = new Constants.Sql();
            bctktk = new Constants.BCTonKhoTheoKho();
            string sql = Sql.selectBCTonKhoTheoKhoTheoMa;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@MaKho", SqlDbType.VarChar, 20).Value = bctktk1.MaKho;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCTonKhoTheoKho bctktkk = new Entities.BCTonKhoTheoKho();
                bctktkk.MaKho = dr[bctktk.MaKho].ToString();
                bctktkk.TenKho = dr[bctktk.TenKho].ToString();
                bctktkk.MaHangHoa = dr[bctktk.MaHangHoa].ToString();
                bctktkk.TenHangHoa = dr[bctktk.TenHangHoa].ToString();
                bctktkk.NgayNhap = DateTime.Parse(dr[bctktk.NgayNhap].ToString());
                bctktkk.HanSuDung = DateTime.Parse(dr[bctktk.HanSuDung].ToString());
                bctktkk.SoLuong = Convert.ToInt32(dr[bctktk.SoLuong].ToString());
                arr.Add(bctktkk);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCTonKhoTheoKho[] arrC = new Entities.BCTonKhoTheoKho[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCTonKhoTheoKho)arr[i];
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

        public Entities.BCTonKhoTheoKho[] Select()
        {

            Sql = new Constants.Sql();
            bctktk = new Constants.BCTonKhoTheoKho();
            string sql = Sql.SelectBCTonKhoTheoKho;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BCTonKhoTheoKho bctktkk = new Entities.BCTonKhoTheoKho();
                bctktkk.MaKho = dr[bctktk.MaKho].ToString();
                bctktkk.TenKho = dr[bctktk.TenKho].ToString();
                bctktkk.MaHangHoa = dr[bctktk.MaHangHoa].ToString();
                bctktkk.TenHangHoa = dr[bctktk.TenHangHoa].ToString();
                bctktkk.NgayNhap = DateTime.Parse(dr[bctktk.NgayNhap].ToString());
                bctktkk.HanSuDung = DateTime.Parse(dr[bctktk.HanSuDung].ToString());
                bctktkk.SoLuong = Convert.ToInt32(dr[bctktk.SoLuong].ToString());
                arr.Add(bctktkk);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCTonKhoTheoKho[] arrC = new Entities.BCTonKhoTheoKho[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCTonKhoTheoKho)arr[i];
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
