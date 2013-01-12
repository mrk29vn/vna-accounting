using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class Lay_ID
    {
        Constants.Sql Sql;

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public object Select(Entities.LayID lid1)
        {
            Sql = new Constants.Sql();
            string sql = Sql.LayID;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@table", SqlDbType.NVarChar, 50).Value = lid1.TenBang;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            while (dr.Read())
            {
                Entities.LayID lid = new Entities.LayID();
                lid.ID = dr["ID"].ToString();
                arr.Add(lid);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.LayID arrC = new Entities.LayID();
            for (int i = 0; i < n; i++)
            {
                arrC = (Entities.LayID)arr[i];
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
