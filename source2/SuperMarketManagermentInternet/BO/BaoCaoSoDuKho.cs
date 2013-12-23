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
    public class BaoCaoSoDuKho
    {
         private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public BaoCaoSoDuKho()
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
        public Entities.BaoCaoSoDuKho[] Select(Entities.TruyenGiaTri giatri)
        {
            Entities.BaoCaoSoDuKho[] arrC = null;
            try
            {
                string sql = "exec sp_LaySoDuKho @TuNgay,@DenNgay";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("TuNgay", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("DenNgay", SqlDbType.VarChar, 20).Value = giatri.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.BaoCaoSoDuKho tao = new Entities.BaoCaoSoDuKho();
                    tao.MaSoDuKho = dr[0].ToString();
                    tao.MaHangHoa = dr[1].ToString();
                    tao.SoDuDauKy = int.Parse(dr[2].ToString());
                    tao.SoDuCuoiKy = int.Parse(dr[3].ToString());
                    tao.NgayKetChuyen = DateTime.Parse(dr[4].ToString());
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.BaoCaoSoDuKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.BaoCaoSoDuKho)arr[i];
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
