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
    public class BaoCaoNhapHangTheoTungMatHangTheoThoiGian
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
        public BaoCaoNhapHangTheoTungMatHangTheoThoiGian()
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
        public Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian[] Select(Entities.TruyenGiaTri giatri)
        {
            Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian[] arrC = null;
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
                    Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian tao = new Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian();
                    tao.MaHangHoa = dr[0].ToString();
                    tao.TenHangHoa = dr[1].ToString();
                    tao.GiaNhap = dr[2].ToString();
                    tao.SoLuong = dr[3].ToString();
                    tao.GiaBanBuon = dr[4].ToString();
                    tao.GiaBanLe = dr[5].ToString();
                    tao.MaHoaDonNhap = dr[6].ToString();
                    tao.NgayNhap = DateTime.Parse(dr[7].ToString());
                    tao.ThanhToanNgay = dr[8].ToString();
                    tao.ChietKhau = dr[9].ToString();
                    tao.ThueGTGT = dr[10].ToString();
                    tao.TongTien = dr[11].ToString();
                    tao.PhanTramChietKhau = dr[12].ToString();
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian)arr[i];
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
