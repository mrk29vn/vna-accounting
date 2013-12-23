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
using System.IO;
using System.Windows.Forms;

namespace BizLogic
{

    public class SaoLuuHeThong
    {
        public static string duongdanFolder = Application.StartupPath + "\\BackUpDatabaseSuperMarketDHT";

        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public void BackUp(string duongdan)
        {
            try
            {
                if (duongdan.Equals(""))
                {
                    if (!Directory.Exists(duongdanFolder))
                    {
                        Directory.CreateDirectory(duongdanFolder);
                    }
                    duongdan = duongdanFolder + "\\BUSuperMarketDHT-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".bak";
                }
                string sql = "BACKUP DATABASE [SupermarketManagementDHT] TO DISK=N'" + duongdan + "'";
                conn = new Connection();
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn.openConnection();
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                cmd.Connection.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
                conn.closeConnection();
            }
        }

        public void BackUp()
        {
            try
            {
                string path = duongdanFolder;
                DirectoryInfo FI = new DirectoryInfo(path);
                string fileName = "BUSuperMarketDHT" + DateTime.Now.ToString().Replace('/', '-').Replace(" ","_").Replace(":","_");
                string sql = "BACKUP DATABASE [SupermarketManagementDHT] TO DISK=N'" + path + @"\" + fileName + "'";
                if (!FI.Exists)
                {
                    FI.Create();
                }
                conn = new Connection();
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn.openConnection();
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                cmd.Connection.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
                conn.closeConnection();
            }
        }
        public Entities.SaoLuuHeThong[] LayBackUp()
        {
            try
            {
                string path = duongdanFolder;
                DirectoryInfo DI = new DirectoryInfo(path);
                if (!DI.Exists)
                {
                    return null;
                }
                FileInfo[] FI = DI.GetFiles("BUSuperMarketDHT*");
                Entities.SaoLuuHeThong[] slht = new Entities.SaoLuuHeThong[FI.Length];
                int j = 0;
                for (int i = FI.Length - 1; i >= 0; i--)
                {
                    slht[j] = new Entities.SaoLuuHeThong(FI[i].Name, FI[i].LastWriteTime.ToShortDateString(), FI[i].Length);
                    j++;
                }
                return slht;
            }
            catch
            {
                return null;
            }
        }

        public bool Restore(string duongdan)
        {
            try
            {
                try
                {
                    SqlConnection.ClearAllPools();
                    string sql = "ALTER DATABASE SupermarketManagementDHT ";
                    sql += "SET SINGLE_USER WITH ROLLBACK IMMEDIATE ";
                    sql += " use master ";
                    sql += "restore DATABASE SupermarketManagementDHT from DISK='" + duongdan + "' with replace";
                    sql += " ALTER DATABASE SupermarketManagementDHT ";
                    sql += "SET MULTI_USER";
                    conn = new Connection();
                    cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn.openConnection();

                    cmd.ExecuteNonQuery();

                    cmd.Connection.Dispose();
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
                catch
                { return false; }
                finally
                {
                    cmd.Connection.Dispose();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    conn.closeConnection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Restore(Entities.SaoLuuHeThong slht1)
        {
            try
            {
                try
                {
                    SqlConnection.ClearAllPools();
                    string path = duongdanFolder;
                    DirectoryInfo FI = new DirectoryInfo(path);
                    string fileName = "BUSuperMarketDHT" + slht1.Name;
                    string sql = "ALTER DATABASE SupermarketManagementDHT ";
                    sql += "SET SINGLE_USER WITH ROLLBACK IMMEDIATE ";
                    sql += " use master ";
                    //sql += "while((select COUNT(spid) from master..sysprocesses where DBid=DB_ID('SupermarketManagement'))>0)";
                    //sql += "begin ";
                    //sql += "declare @id smallint=(select top(1)spid from master..sysprocesses where DBid=DB_ID('SupermarketManagement')) ";
                    //sql += "declare @sql nvarchar(100)=N'kill @i' ";
                    //sql += "exec sp_executesql @sql,N'@i smallint',@i=@id ";
                    //sql += "end ";
                    sql += "restore DATABASE SupermarketManagementDHT from DISK='" + path + "\\" + slht1.Name + "' with replace";
                    sql += " ALTER DATABASE SupermarketManagementDHT ";
                    sql += "SET MULTI_USER";

                    if (!FI.Exists)
                    {
                        return false;
                    }
                    conn = new Connection();
                    cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn.openConnection();

                    cmd.ExecuteNonQuery();

                    cmd.Connection.Dispose();
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
                catch
                { return false; }
                finally
                {
                    cmd.Connection.Dispose();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    conn.closeConnection();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
