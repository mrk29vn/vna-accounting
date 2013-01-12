using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;


namespace BizLogic
{
    public class Thue
    {
        Constants.Thue pt;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.Thue[] Select()
        {

            Sql = new Constants.Sql();
            pt = new Constants.Thue();
            string sql = Sql.SelectAllThue;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.Thue phieuthu = new Entities.Thue();
                phieuthu.ThueID = Convert.ToInt32(dr[pt.ThueID].ToString());
                phieuthu.MaThue = dr[pt.MaThue].ToString();
                phieuthu.TenThue = dr[pt.TenThue].ToString();
                phieuthu.GiaTriThue = dr["GiaTriThue"].ToString();
                phieuthu.GhiChu = dr[pt.GhiChu].ToString();
                phieuthu.Deleted = (Boolean)dr[pt.Deleted];
                arr.Add(phieuthu);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.Thue[] arrC = new Entities.Thue[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.Thue)arr[i];
            }

            //Giai phong bo nho
            arr = null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arrC;
        }
    }
}
