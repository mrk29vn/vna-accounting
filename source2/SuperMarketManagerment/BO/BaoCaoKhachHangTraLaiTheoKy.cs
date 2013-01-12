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
    public class BaoCaoKhachHangTraLaiTheoKy
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BaoCaoKhachHangTraLaiTheoKy()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.BaoCaoKhachHangTraLaiTheoKy[] Select(Entities.TruyenGiaTri giatri)
        {
            Entities.BaoCaoKhachHangTraLaiTheoKy[] arrC = null;
            try
            {
                string sql = "exec sp_BaoCaoKhachHangTraLaiTheoKy @TuNgay,@DenNgay";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("TuNgay", SqlDbType.VarChar, 10).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DenNgay", SqlDbType.VarChar, 10).Value = giatri.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.BaoCaoKhachHangTraLaiTheoKy tao = new Entities.BaoCaoKhachHangTraLaiTheoKy();
                    tao.MaKhachHangTraLai = dr[0].ToString();
                    tao.NgayNhap = DateTime.Parse(dr[1].ToString());
                    tao.MaKhachHang = dr[2].ToString();
                    tao.MaHoaDonMuaHang = dr[3].ToString();
                    tao.MaKho = dr[4].ToString();
                    tao.MaHangHoa = dr[5].ToString();
                    tao.TenHangHoa = dr[6].ToString();
                    tao.GiaBanBuon = dr[7].ToString();
                    tao.GiaBanLe = dr[8].ToString();
                    tao.SoLuong = dr[9].ToString();
                    tao.PhanTramChietKhau = dr[10].ToString();
                    tao.TienBoiThuong = dr[11].ToString();
                    tao.ThueGTGT = dr[12].ToString();
                    tao.ThanhToanNgay = dr[13].ToString();
                    tao.Thue = dr[14].ToString();
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.BaoCaoKhachHangTraLaiTheoKy[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoKhachHangTraLaiTheoKy)arr[i];
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
    }
}
