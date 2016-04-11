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
    public class ThongTinCongTy
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Connection conn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private Entities.ThongTinCongTy congty;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinCongTy()
        {
            conn = null;
            cmd = null;
            dr = null;
            congty = null;
            cn = null;
        }

        /// <summary>
        /// lay bang cong ty
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Entities.ThongTinCongTy sp_ThongTinCongTy(TruyenGiaTri ct)
        {
            Entities.ThongTinCongTy banghi = new Entities.ThongTinCongTy();
            try
            {
                string sql = "exec sp_ThongTinCongTy @MaCongTy";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaCongTy", SqlDbType.VarChar, 20).Value = ct.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                ArrayList arr = new ArrayList();
                while (dr.Read())
                {
                   
                    banghi.MaCongTy = dr[0].ToString();
                    banghi.TenCongTy = dr[1].ToString();
                    banghi.DiaChi = dr[2].ToString();
                    banghi.SoDienThoai = dr[3].ToString();
                    banghi.Email = dr[4].ToString();
                    banghi.Website = dr[5].ToString();
                    banghi.Fax = dr[6].ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); banghi = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return banghi;
        }
        #endregion
    }
}
