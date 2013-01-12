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
    public class BaoCaoNhapHangTheoTungNhomHangTheoThoiGian
    {
        #region Khởi Tạo------------------------------------------------------
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BaoCaoNhapHangTheoTungNhomHangTheoThoiGian()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        #endregion-------------------------------------------------------------
         /// <summary>
        /// báo cáo nhap hang theo tung mat hang
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        #region Xử Lý----------------------------------------------------------
        public Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian[] Select(Entities.TruyenGiaTri giatri)
        {
            Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian[] arrC = null;
            try
            {
                string sql = "exec sp_BaoCaoNhapHangTheoTungMatHangTheoThoiGian @TuNgay,@DenNgay";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("TuNgay", SqlDbType.DateTime).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DenNgay", SqlDbType.DateTime).Value = giatri.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian tao = new Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian();
                    tao.MaHangHoa = dr[0].ToString();
                    tao.TenHangHoa = dr[1].ToString();
                    tao.GiaNhap = dr[2].ToString();
                    tao.SoLuong = dr[3].ToString();
                    tao.MaHoaDonNhap = dr[4].ToString();
                    tao.NgayNhap = DateTime.Parse(dr[5].ToString());
                    tao.HanThanhToan = DateTime.Parse(dr[6].ToString());
                    tao.ThanhToanNgay = dr[7].ToString();
                    tao.PhanTramChietKhau = dr[8].ToString();
                    tao.ChietKhau = dr[9].ToString();
                    tao.ThueGTGT = dr[10].ToString();
                    tao.TongTien = dr[11].ToString();
                    tao.MaNhomHangHoa = dr[12].ToString();
                    tao.TenNhomHang = dr[13].ToString();
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); arrC = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }
        #endregion-------------------------------------------------------------
    }
}
