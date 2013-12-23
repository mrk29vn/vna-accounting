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
    public class QuayThuNgan
    {
        Constants.QuayThuNgan pt;
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.QuayThuNgan[] Select()
        {

            Sql = new Constants.Sql();
            pt = new Constants.QuayThuNgan();
            string sql = Sql.SelectQuayThuNgan;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.QuayThuNgan phieuthu = new Entities.QuayThuNgan();
                phieuthu.QuayThuNganID = Convert.ToInt32(dr[pt.QuayThuNganID].ToString());
                phieuthu.TenQuayThuNgan = dr[pt.TenQuayThuNgan].ToString();
                phieuthu.DiaDiem =dr[pt.DiaDiem].ToString();
                phieuthu.GhiChu = dr[pt.GhiChu].ToString();
                phieuthu.Deleted = (Boolean)dr[pt.Deleted];
                arr.Add(phieuthu);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.QuayThuNgan[] arrC = new Entities.QuayThuNgan[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.QuayThuNgan)arr[i];
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
