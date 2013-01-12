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
   public class BaoCaoNhapHangTheoMatHang
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.BaoCapNhapHangTheoMatHang kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.BaoCaoNhapHangTheoMatHang khachhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BaoCaoNhapHangTheoMatHang()
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
        public Entities.BaoCaoNhapHangTheoMatHang[] Select()
        {

            Entities.BaoCaoNhapHangTheoMatHang[] arrC = null;
            try
            {
                kh = new Constants.BaoCapNhapHangTheoMatHang();
                Sql = new Constants.Sql();
                string sql = Sql.BaoCaoNhapHangTheoMatHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
            while (dr.Read())
            {
                Entities.BaoCaoNhapHangTheoMatHang khachhang = new Entities.BaoCaoNhapHangTheoMatHang();
                khachhang.MaKho = dr[kh.MaKho].ToString();
                khachhang.MaHoaDonNhap = dr[kh.MaHoaDonNhap].ToString();
                khachhang.TenHangHoa = dr[kh.TenHangHoa].ToString();
                khachhang.NgayNhap = Convert.ToDateTime(dr[kh.NgayNhap].ToString());
                khachhang.SoLuong =Convert.ToInt32( dr[kh.SoLuong].ToString());
                khachhang.TongTien =(float.Parse) (dr[kh.TongTien].ToString());
                arr.Add(khachhang);
            }
            int n = arr.Count;
            if (n == 0) { return null; }
            arrC = new Entities.BaoCaoNhapHangTheoMatHang[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BaoCaoNhapHangTheoMatHang)arr[i];
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
