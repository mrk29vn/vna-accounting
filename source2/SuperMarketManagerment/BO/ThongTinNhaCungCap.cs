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
    public class ThongTinNhaCungCap
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ThongTinNhaCungCap dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThongTinNhaCungCap cungcap;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinNhaCungCap()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cungcap = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinNhaCungCap[] sp_LayBang_NhaCungCap(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinNhaCungCap[] arrC = null;
            try
            {
                dh = new Constants.ThongTinNhaCungCap();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_NhaCungCap;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    cungcap = new Entities.ThongTinNhaCungCap();
                    cungcap.Manhacungcap = dr[0].ToString();
                    cungcap.Tennhacungcap = dr[1].ToString();
                    cungcap.Diachi = dr[2].ToString();
                    cungcap.Nohienthoi = dr[3].ToString();
                    arr.Add(cungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinNhaCungCap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinNhaCungCap)arr[i];
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
