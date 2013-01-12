using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
namespace BizLogic
{
    public class CapNhat
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public CapNhat()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        //insert update
        public int XoaTheoMaHoaDon(Entities.TruyenGiaTri giatri)
        {
            int tra = 0;
            try
            {
                string sql = "exec sp_CapNhat @HanhDong ,@MaCapNhat";
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("HanhDong", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                cmd.Parameters.Add("MaCapNhat", SqlDbType.VarChar, 20).Value = giatri.Giatrithuhai;
                tra = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return tra;
        }
    }
}
