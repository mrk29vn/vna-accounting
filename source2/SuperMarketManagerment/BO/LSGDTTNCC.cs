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
  public  class LSGDTTNCC
    {
         /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.LSGDTTNCC tt;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.LSGDTTNCC thanhtoan;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public LSGDTTNCC()
        {
            tt = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            thanhtoan = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.LSGDTTNCC[] Select(Entities.LSGDTTNCC ct)
        {
            Entities.LSGDTTNCC[] arrC = null;
            try
            {
                tt = new Constants.LSGDTTNCC();
                Sql = new Constants.Sql();
                string sql = Sql.LSGDThanhToanNCC;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tt.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ct.MaNhaCungCap;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    thanhtoan = new Entities.LSGDTTNCC();
                    thanhtoan.MaNhaCungCap = dr[0].ToString();
                    thanhtoan.MaPhieuTTNCC = dr[1].ToString();
                    thanhtoan.NgayLap = Convert.ToDateTime(dr[2].ToString());
                    thanhtoan.TrangThai = dr[3].ToString();
                    thanhtoan.GhiChu = dr[4].ToString();
                    thanhtoan.ThanhToan = dr[5].ToString();
                    arr.Add(thanhtoan);
                    thanhtoan = null;

                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LSGDTTNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LSGDTTNCC)arr[i];
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
