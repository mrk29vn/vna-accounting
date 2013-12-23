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
    public class Lay_ID_Top_1
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public Lay_ID_Top_1()
        {
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        private Constants.SelectID lay;
        private Entities.Lay_ID_Top_1 top;
        public Entities.Lay_ID_Top_1 sp_Tim_ID(Entities.Lay_ID_Top_1 giatri)
        {
            Entities.Lay_ID_Top_1 trave = null;
            try
            {
                lay = new Constants.SelectID();
                Sql = new Constants.Sql();
                top = new Entities.Lay_ID_Top_1();
                string sql = Sql.sp_Lay_ID;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("table", SqlDbType.NVarChar, 50).Value = giatri.ColumnNameID;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    top.ColumnNameID = dr[0].ToString();
                }
                trave = new Entities.Lay_ID_Top_1();
                trave.ColumnNameID = dr[Sql.ColumnNameID].ToString();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return top;
        }
        /// <summary>
        /// hungvv ====================doc ID top 1 trong database gia tri phai truyen vao la ten cot ID va ten bang can tim=========================
        /// </summary>
        /// <param name="columnNameID"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Entities.Lay_ID_Top_1 sp_Tim_ID(string columnNameID, string tableName)
        {
            Entities.Lay_ID_Top_1 trave = null;
            //try
            //{

            Sql = new Constants.Sql();
            string sql = Sql.sp_Tim_ID;
            conn = new Connection();
            cn = conn.openConnection();
            cmd = new SqlCommand(sql, cn);
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                trave = new Entities.Lay_ID_Top_1();
                trave.ColumnNameID = dr[Sql.ColumnNameID].ToString();
            }
            //}
            //catch (Exception ex)
            //{ string s = ex.Message.ToString(); }
            //finally
            //{
            //    cmd.Connection.Dispose();
            //    cn.Close();
            //    conn.closeConnection();
            //}
            return trave;
        }

        /// <summary>
        /// hungvv==================== hungvv cat chuoi tim duoc va tra ve id tu trong database voi hai tham so truyen vao la ten cot  va ten bang=============================
        /// </summary>
        /// <param name="strChuoi"></param>
        /// <returns></returns>
        public string getColumnID(string columnNameID, string tableName)
        {
            string IDs = null;
            //try
            //{
            string strChuoi = null;
            Entities.Lay_ID_Top_1 trave = null;
            trave = sp_Tim_ID(columnNameID, tableName);
            strChuoi = trave.ColumnNameID;
            int i = strChuoi.LastIndexOf("_");
            int ID = Convert.ToInt32(strChuoi.Substring(i + 1));
            string IDdau = strChuoi.Substring(0, i);
            ID = ID + 1;
            string IDcuoi = ID.ToString();
            if (IDcuoi.Length == 1) { IDcuoi = "000" + IDcuoi; }
            else if (IDcuoi.Length == 2) { IDcuoi = "00" + IDcuoi; }
            else if (IDcuoi.Length == 3) { IDcuoi = "0" + IDcuoi; }
            IDs = IDdau + "_" + IDcuoi;
            //}
            //catch(Exception ex)
            //{
            //    string s = ex.Message.ToString();
            //    strChuoi = null;
            //}
            return IDs;
        }
    }
}
