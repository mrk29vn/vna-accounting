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
    public class BaoCaoBanBuonBanLeTheoKy
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri 
        /// </summary>
        public BaoCaoBanBuonBanLeTheoKy()
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
        public Entities.BaoCaoBanBuonBanLeTheoKy[] Select(Entities.TruyenGiaTri giatri)
        {
            Entities.BaoCaoBanBuonBanLeTheoKy[] arrC = null;
            try
            {
                string sql = "exec sp_BaoCaoBanBuonBanLeTheoKy @TuNgay,@DenNgay,@Loai";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("TuNgay", SqlDbType.VarChar, 10).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DenNgay", SqlDbType.VarChar, 10).Value = giatri.Giatrithuhai;
                cmd.Parameters.Add("Loai", SqlDbType.VarChar, 20).Value = giatri.Giatriba;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.BaoCaoBanBuonBanLeTheoKy tao = new Entities.BaoCaoBanBuonBanLeTheoKy();
                    tao.MaHDBanHang = dr[0].ToString();
                    tao.NgayBan = DateTime.Parse(dr[1].ToString());
                    tao.MaKho = dr[2].ToString();
                    tao.MaHangHoa = dr[3].ToString();
                    tao.TenHangHoa = dr[4].ToString();
                    tao.GiaBan = dr[5].ToString();
                    tao.SoLuong = int.Parse(dr[6].ToString());
                    tao.PhanTramChietKhau = dr[7].ToString();
                    tao.ChietKhau = dr[8].ToString();
                    tao.ThueGTGT = dr[9].ToString();
                    tao.ThanhToanNgay = dr[10].ToString();
                    tao.TongTienThanhToan = dr[11].ToString();
                    tao.GiaTriThue = dr[12].ToString();
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.BaoCaoBanBuonBanLeTheoKy[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoBanBuonBanLeTheoKy)arr[i];
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
