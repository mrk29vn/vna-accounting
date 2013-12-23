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
    public class BaoCaoXuatHangTheoKho
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.BaoCaoXuatHangTheoKho xuatkho;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BaoCaoXuatHangTheoKho()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            xuatkho = null;
            cn = null;
        }

        public Entities.BaoCaoXuatHangTheoKho[] sp_BaoCao_XuatTheoKho(Entities.TruyenGiaTri nhom)
        {
            Entities.BaoCaoXuatHangTheoKho[] arrC = null;
            try
            {
                string sql = "exec sp_BaoCao_XuatTheoKho @MaKho,@NgayBan";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = nhom.Giatritruyen;
                cmd.Parameters.Add("NgayBan", SqlDbType.DateTime).Value = nhom.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    xuatkho = new Entities.BaoCaoXuatHangTheoKho();
                    xuatkho.MaKho = dr[0].ToString();
                    xuatkho.MaKho = dr[1].ToString();
                    xuatkho.MaKho = dr[2].ToString();
                    xuatkho.MaKho = dr[3].ToString();
                    xuatkho.MaKho = dr[4].ToString();
                    arr.Add(xuatkho);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.BaoCaoXuatHangTheoKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoXuatHangTheoKho)arr[i];
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
