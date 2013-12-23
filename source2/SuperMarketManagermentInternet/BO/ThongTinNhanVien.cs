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
    public class ThongTinNhanVien
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ThongTinNhanVien dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThongTinNhanVien nhanvien;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinNhanVien()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            nhanvien = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinNhanVien[] sp_LayBang_ThongTinNhanVien()
        {
            Entities.ThongTinNhanVien[] arrC = null;
            try
            {
                dh = new Constants.ThongTinNhanVien();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_NhanViens;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    nhanvien = new Entities.ThongTinNhanVien();
                    nhanvien.Manhanvien = dr[dh.MaNhanVien].ToString();
                    nhanvien.Tennhanvien = dr[dh.TenNhanVien].ToString();
                    arr.Add(nhanvien);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinNhanVien[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinNhanVien)arr[i];
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
