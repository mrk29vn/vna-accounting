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
   public class BaoCaoNhapHangTheoNhomHang
    {
       /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.BaoCapNhapHangTheoNhomHang kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.BaoCaoNhapHangTheoNhomHang khachhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BaoCaoNhapHangTheoNhomHang()
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
        public Entities.BaoCaoNhapHangTheoNhomHang[] Select()
        {

            Entities.BaoCaoNhapHangTheoNhomHang[] arrC = null;
            try
            {
                kh = new Constants.BaoCapNhapHangTheoNhomHang();
                Sql = new Constants.Sql();
                string sql = Sql.BaoCaoNhapHangTheoNhomHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BaoCaoNhapHangTheoNhomHang khachhang = new Entities.BaoCaoNhapHangTheoNhomHang();
                khachhang.MaNhomHang = dr[kh.MaNhomHang].ToString();
                khachhang.TenKho = dr[kh.TenKho].ToString();
                khachhang.TenHangHoa = dr[kh.TenHangHoa].ToString();
                khachhang.NgayNhap =Convert.ToDateTime(dr[kh.NgayNhap].ToString());             
                khachhang.SoLuong =Convert.ToInt32( dr[kh.SoLuong].ToString());
                khachhang.TongTien =(float.Parse)(dr[kh.TongTien].ToString());
                arr.Add(khachhang);
            }
            int n = arr.Count;
            if (n == 0) { return null; }
            arrC = new Entities.BaoCaoNhapHangTheoNhomHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BaoCaoNhapHangTheoNhomHang)arr[i];
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
