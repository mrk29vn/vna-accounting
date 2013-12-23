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
  public  class LSGDHangHoa
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.LSGDHangHoa hh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.LSGDHangHoa hanghoa;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public LSGDHangHoa()
        {
            hh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hanghoa = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.LSGDHangHoa[] Select(Entities.LSGDHangHoa ct)
        {

            Entities.LSGDHangHoa[] arrC = null;
            try
            {
                hh = new Constants.LSGDHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.LSGDHangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hh.MaKhachHang, SqlDbType.NVarChar, 20).Value = ct.MaKhachHang;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                   hanghoa = new Entities.LSGDHangHoa();
                   hanghoa.MaKhachHang = dr[0].ToString();
                   hanghoa.MaHangHoa = dr[1].ToString();
                   hanghoa.TenHangHoa = dr[2].ToString();
                   hanghoa.MaDonViTinh = dr[3].ToString();
                   hanghoa.SoLuong = Convert.ToInt32(dr[4].ToString());
                   hanghoa.MaThueGiaTriGiaTang = dr[5].ToString();
                   hanghoa.TongTienThanhToan = dr[6].ToString();
                   arr.Add(hanghoa);
                   hanghoa = null;
                   
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LSGDHangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LSGDHangHoa)arr[i];
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
