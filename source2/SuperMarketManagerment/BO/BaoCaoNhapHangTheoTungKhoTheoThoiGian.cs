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
    public class BaoCaoNhapHangTheoTungKhoTheoThoiGian
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
        public BaoCaoNhapHangTheoTungKhoTheoThoiGian()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        #endregion-------------------------------------------------------------
        /// <summary>
        /// báo cáo nhap hang theo tung kho
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        #region Xử Lý----------------------------------------------------------
        public Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] Select(Entities.TruyenGiaTri giatri)
        {

            Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] arrC = null;
            try
            {
                string sql = "exec sp_BaoCaoNhapHangTheoTungKhoTheoThoiGian @TuNgay,@DenNgay";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("TuNgay", SqlDbType.VarChar,20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DenNgay", SqlDbType.VarChar,20).Value = giatri.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian tao = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian();
                    tao.MaHoaDonNhap = dr[0].ToString();
                    tao.NgayNhap = DateTime.Parse(dr[1].ToString());
                    tao.MaKho = dr[2].ToString();
                    tao.MaHangHoa = dr[3].ToString();
                    tao.TenHangHoa = dr[4].ToString();
                    tao.GiaNhap = dr[5].ToString();
                    tao.SoLuong = dr[6].ToString();
                    tao.PhanTramChietKhau = dr[7].ToString();
                    tao.ChietKhau = dr[8].ToString();
                    tao.ThueGTGT = dr[9].ToString();
                    tao.TongTien = dr[10].ToString();
                    tao.ThanhToanNgay = dr[11].ToString();
                    tao.Thue = dr[12].ToString();
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian)arr[i];
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
