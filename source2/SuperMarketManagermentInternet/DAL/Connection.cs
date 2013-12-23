using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class Connection
    {
        #region Mrk
        static string _strCon;
        static string StrCon
        {
            get
            {
                _strCon = string.IsNullOrEmpty(_strCon) ? BuildConfig() : _strCon;
                return _strCon;
            }
        }
        static string BuildConfig()
        {
            SQL sql = new Common.Utilities().ConnectionsName();
            return "Data Source=" + sql.ServerName + ";User ID=" + sql.UserName + ";password=" + sql.Password + ";Initial Catalog=" + sql.DatabaseName;
        }
        public static System.Data.DataTable GetDataBySql(string sql)
        {
            SqlConnection con = new SqlConnection(StrCon); con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, StrCon); System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds); con.Dispose(); con.Close();
            return ds.Tables[0];
        }
        #endregion

        private SqlConnection cnn;
        /// <summary>
        /// chuoi ket noi
        /// </summary>
        private string strConnect;
        public string StrConnect
        {
            get { return strConnect; }
            set { strConnect = value; }
        }

        /// <summary>
        /// lay gia tri tu file xml
        /// </summary>
        public Connection()
        {
            Entities.SQL sql = new Entities.SQL();
            Common.Utilities com = new Common.Utilities();
            sql = com.ConnectionsName();
            strConnect = "Data Source=" + sql.ServerName + ";User ID=" + sql.UserName + ";password=" + sql.Password + ";Initial Catalog=" + sql.DatabaseName;
        }

        /// <summary>
        /// lay gia tri truyen vaodang lam gi
        /// </summary>
        /// <param name="connectionString"></param>
        public Connection(string connectionString)
        {
            strConnect = connectionString;
        }

        /// <summary>
        /// mo connectipn
        /// </summary>
        /// <returns></returns>
        public SqlConnection openConnection()
        {
            cnn = new SqlConnection(strConnect);
            cnn.Open();
            return cnn;
        }

        /// <summary>
        /// dong connection
        /// </summary>
        public void closeConnection()
        {
            cnn.Close();
        }

        /// <summary>
        /// chay cau lenh
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int executeSQL(string sql)
        {
            int num = 0;
            cnn = new SqlConnection(strConnect);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            num = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            cnn.Close();
            return num;
        }
    }
}
