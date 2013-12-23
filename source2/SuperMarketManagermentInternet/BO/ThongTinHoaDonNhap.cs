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
    public class ThongTinHoaDonNhap
    {
         #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ThongTinDatHang dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThongTinDatHang hoadonnhap;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinHoaDonNhap()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hoadonnhap = null;
            cn = null;
        }

        /// <summary>
        /// vuong hung =================lay bang hoa don nhap================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_LayBang_HoaDonNhap(Entities.ThongTinDatHang lay)
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                dh = new Constants.ThongTinDatHang();
                Sql = new Constants.Sql();
                string sql = "exec sp_LayBang_ThongTinHoaDonnhap @MaNhaCungCap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.VarChar, 20).Value = lay.MaHangHoa;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    hoadonnhap = new Entities.ThongTinDatHang();
                    hoadonnhap.MaHangHoa = dr[0].ToString().ToUpper();
                    hoadonnhap.TenHangHoa = dr[1].ToString();
                    hoadonnhap.GiaNhap =  dr[2].ToString();
                    arr.Add(hoadonnhap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
       
        #endregion
    }
}
