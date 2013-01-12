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
   public class BCChiTietHangHoa
    {
       /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.BCChiTietHangHoa kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.rptBCChiTietHangHoa khachhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BCChiTietHangHoa()
        {
            kh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khachhang = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.rptBCChiTietHangHoa[] Select()
        {

            Entities.rptBCChiTietHangHoa[] arrC = null;
            try
            {
                kh = new Constants.BCChiTietHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.SelectChiTietHangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
            while (dr.Read())
            {
                Entities.rptBCChiTietHangHoa khachhang = new Entities.rptBCChiTietHangHoa();
                khachhang.MaHangHoa = dr[kh.MaHangHoa].ToString();
                khachhang.TenNhomHang = dr[kh.TenNhomHang].ToString();
                khachhang.TenHangHoa = dr[kh.TenHangHoa].ToString();
                khachhang.TenDonViTinh =dr[kh.TenDonViTinh].ToString();
                khachhang.GiaNhap =(double.Parse)(dr[kh.GiaNhap].ToString());
                khachhang.GiaBanBuon = (double.Parse)(dr[kh.GiaBanBuon].ToString());
                khachhang.GiaBanLe = (double.Parse)(dr[kh.GiaBanLe].ToString());
                khachhang.MucDatHang = Convert.ToInt32(dr[kh.MucDatHang].ToString());
                khachhang.MucTonToiThieu = Convert.ToInt32(dr[kh.MucTonToiThieu].ToString());  
                arr.Add(khachhang);
            }
            int n = arr.Count;
            if (n == 0) { return null; }
            arrC = new Entities.rptBCChiTietHangHoa[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.rptBCChiTietHangHoa)arr[i];
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
