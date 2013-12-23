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
    public class ThongTinKhachHang
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ThongTinKhachHang dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinKhachHang()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinKhachHang[] sp_LayBang_KhachHang(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinKhachHang[] arrC = null;
            try
            {
                dh = new Constants.ThongTinKhachHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ThongTinKhachHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKH", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ThongTinKhachHang khachhang= new Entities.ThongTinKhachHang();
                    khachhang.Makhachhang = dr[dh.MaKH].ToString();
                    khachhang.Tenkhachhang = dr[dh.Ten].ToString();
                    khachhang.Diachi = dr[dh.DiaChi].ToString();
                    khachhang.Duno = dr["DuNo"].ToString();
                    arr.Add(khachhang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinKhachHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinKhachHang)arr[i];
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
