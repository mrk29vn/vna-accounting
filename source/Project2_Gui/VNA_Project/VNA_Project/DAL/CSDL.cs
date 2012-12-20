using System;
using System.Data;
using System.Data.SqlClient;

namespace VNA_Project.DAL
{
    class CSDL
    {
        public static string strCon = @"Data Source=MAX-PC\MRKPC;Initial Catalog=VNAAccounting;User ID=sa;Password=123456";
        //public static string strCon = @"Data Source=NGOCANH-PC\VNAOK;Initial Catalog=VNAAccounting;User ID=sa;Password=123456";

        public static DataTable hienthi(string sql)
        {
            SqlConnection con = new SqlConnection(strCon); con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, strCon); DataSet ds = new DataSet();
            da.Fill(ds); con.Dispose(); con.Close();
            return ds.Tables[0];
        }

        public static int ThemSuaXoa(string sql)
        {
            SqlConnection con = new SqlConnection(strCon); con.Open();
            try { return new SqlCommand(sql, con).ExecuteNonQuery(); }
            catch (Exception ex) { return -1; }
            finally { con.Dispose(); con.Close(); }
        }
    }
}
