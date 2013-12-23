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
    public class ChiTietKhoHangTheoMa
    {
          #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietKhoHangTheoMa kh;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietKhoHangTheoMa()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            kh = null;
            cn = null;
        }
        /// <summary>
        /// xuat hang theo tung nhom hang hungvv
        /// </summary>
        /// <param name="nhom"></param>
        /// <returns></returns>
        public Entities.ChiTietKhoHangTheoMa[] sp_ChiTietKhoHangTheoMa(Entities.TruyenGiaTri nhom)
        {
            Entities.ChiTietKhoHangTheoMa[] arrC = null;
            try
            {
                string sql = "exec sp_XemKhoHang @MaKho";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.NVarChar, 20).Value = nhom.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    kh = new Entities.ChiTietKhoHangTheoMa();
                    kh.Makho = dr[0].ToString();
                    kh.Tenkho = dr[1].ToString();
                    kh.Tenhang = dr[2].ToString();
                    kh.Gianhap = dr[3].ToString();
                    kh.Soluong = int.Parse(dr[4].ToString());
                    kh.Ngaynhap = DateTime.Parse(dr[5].ToString());
                    kh.Ngayhethan = DateTime.Parse(dr[6].ToString());
                    kh.TongTien = new Common.Utilities().FormatMoney(Double.Parse(dr[7].ToString()));
                    kh.MaHangHoa = dr[8].ToString();
                    arr.Add(kh);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.ChiTietKhoHangTheoMa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKhoHangTheoMa)arr[i];
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
        #endregion
        public Entities.ChiTietKhoHangTheoMa[] sp_ChiTietKhoHangTheoMaKho(string maKho)
        {
            Entities.ChiTietKhoHangTheoMa[] arrC = null;
            try
            {
                string sql = "exec sp_XemKhoHang @MaKho";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.NVarChar, 20).Value = maKho;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    kh = new Entities.ChiTietKhoHangTheoMa();
                    kh.Makho = dr[0].ToString();
                    kh.Tenkho = dr[1].ToString();
                    kh.Tenhang = dr[2].ToString();
                    kh.Gianhap = dr[3].ToString();
                    kh.Soluong = int.Parse(dr[4].ToString());
                    kh.Ngaynhap = DateTime.Parse(dr[5].ToString());
                    kh.Ngayhethan = DateTime.Parse(dr[6].ToString());
                    kh.TongTien = new Common.Utilities().FormatMoney(Double.Parse(dr[7].ToString()));
                    arr.Add(kh);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.ChiTietKhoHangTheoMa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKhoHangTheoMa)arr[i];
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
