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
        public rptBCChiTietHangHoa[] Select()
        {

            rptBCChiTietHangHoa[] arrC = null;
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
                    rptBCChiTietHangHoa rptBcChiTietHangHoa = new rptBCChiTietHangHoa
                                                                 {
                                                                     MaHangHoa = dr[kh.MaHangHoa].ToString(),
                                                                     TenNhomHang = dr[kh.TenNhomHang].ToString(),
                                                                     TenHangHoa = dr[kh.TenHangHoa].ToString(),
                                                                     TenDonViTinh = dr[kh.TenDonViTinh].ToString(),
                                                                     GiaNhap = double.Parse(dr[kh.GiaNhap].ToString()),
                                                                     GiaBanBuon = double.Parse(dr[kh.GiaBanBuon].ToString()),
                                                                     GiaBanLe = double.Parse(dr[kh.GiaBanLe].ToString()),
                                                                     MucDatHang = Convert.ToInt32(dr[kh.MucDatHang].ToString()),
                                                                     MucTonToiThieu = Convert.ToInt32(dr[kh.MucTonToiThieu].ToString())
                                                                 };
                    arr.Add(rptBcChiTietHangHoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new rptBCChiTietHangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (rptBCChiTietHangHoa)arr[i];
                }
            }

            catch (Exception)
            {
            }
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
