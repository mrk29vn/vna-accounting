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
    public class TheVip
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public TheVip()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.TheVip[] Select()
        {
            Entities.TheVip[] arrC = null;
            try
            {
                string sql =new Common.Constants.Sql().selectTheVipAll;
                Constants.TheVip tv=new Constants.TheVip();
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TheVip tao = new Entities.TheVip();
                    tao.MaKhachHang = dr[tv.MaKhachHang].ToString().ToUpper();
                    tao.MaThe = dr[tv.MaThe].ToString().ToUpper();
                    tao.GiaTriThe = dr[tv.GiaTriThe].ToString();
                    tao.GiaTriConLai = dr[tv.GiaTriConLai].ToString();
                    tao.GhiChu = dr[tv.GhiChu].ToString();
                    tao.SoDiem = dr[tv.SoDiem].ToString();
                    tao.Deleted = (bool)dr[tv.Deleted];
                    arr.Add(tao);
                }
                //int n = arr.Count;
                //if (n == 0) { arrC = null; }
                //arrC = new Entities.TheVip[n];
                //for (int i = 0; i < n; i++)
                //{
                //    arrC[i] = (Entities.TheVip)arr[i];
                //}
                if (arr.Count > 0)
                {
                    arrC = (Entities.TheVip[])arr.ToArray(typeof(Entities.TheVip));
                }
                else
                    return new Entities.TheVip[0];
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

        public Entities.TheVip[] Select(Entities.TheVip thevip)
        {
            Entities.TheVip[] arrC = null;
            try
            {
                string sql = new Common.Constants.Sql().selectTheVipAll;
                Constants.TheVip tv = new Constants.TheVip();
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tv.MaKhachHang, SqlDbType.VarChar, 50).Value = thevip.MaKhachHang.ToUpper();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TheVip tao = new Entities.TheVip();
                    tao.MaKhachHang = dr[tv.MaKhachHang].ToString().ToUpper();
                    tao.MaThe = dr[tv.MaThe].ToString().ToUpper();
                    tao.GiaTriThe = dr[tv.GiaTriThe].ToString();
                    tao.GiaTriConLai = dr[tv.GiaTriConLai].ToString();
                    tao.GhiChu = dr[tv.GhiChu].ToString();
                    tao.SoDiem = dr[tv.SoDiem].ToString();
                    tao.Deleted = (bool)dr[tv.Deleted];
                    arr.Add(tao);
                }
                //int n = arr.Count;
                //if (n == 0) { arrC = null; }
                //arrC = new Entities.TheVip[n];
                //for (int i = 0; i < n; i++)
                //{
                //    arrC[i] = (Entities.TheVip)arr[i];
                //}
                if (arr.Count > 0)
                {
                    arrC = (Entities.TheVip[])arr.ToArray(typeof(Entities.TheVip));
                }
                else
                    return new Entities.TheVip[0];
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

        public bool Insert(Entities.TheVip thevip)
        {
            bool trave = false;
            try
            {

                string sql = new Common.Constants.Sql().insertTheVip;
                conn = new Connection();
                Constants.TheVip tv = new Constants.TheVip();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tv.MaKhachHang, SqlDbType.VarChar, 50).Value = thevip.MaKhachHang.ToUpper();
                cmd.Parameters.Add(tv.MaThe, SqlDbType.VarChar, 50).Value = thevip.MaThe.ToUpper();
                cmd.Parameters.Add(tv.GiaTriThe, SqlDbType.Float).Value = thevip.GiaTriThe;
                cmd.Parameters.Add(tv.GiaTriConLai, SqlDbType.Float).Value = thevip.GiaTriConLai;
                cmd.Parameters.Add(tv.GhiChu, SqlDbType.VarChar, 100).Value = thevip.GhiChu;
                cmd.Parameters.Add(tv.SoDiem, SqlDbType.VarChar, 100).Value = thevip.SoDiem;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    trave = true;
                }
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                
                
            }
            catch (Exception ex)
            { 
                string s = ex.Message.ToString();
                trave = false;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                
            }
            return trave;
        }
        public bool Update(Entities.TheVip thevip)
        {
            bool trave = false;
            try
            {

                string sql = new Common.Constants.Sql().updateTheVip;
                conn = new Connection();
                Constants.TheVip tv = new Constants.TheVip();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tv.MaThe, SqlDbType.VarChar, 50).Value = thevip.MaThe.ToUpper();
                cmd.Parameters.Add(tv.GiaTriConLai, SqlDbType.Float).Value = thevip.GiaTriConLai;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    trave = true;
                }
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();



            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                trave = false;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();

            }
            return trave;
        }

        public bool Delete(Entities.TheVip thevip)
        {
            bool trave = false;
            try
            {

                string sql = new Common.Constants.Sql().deleteTheVip;
                conn = new Connection();
                Constants.TheVip tv = new Constants.TheVip();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(tv.MaThe, SqlDbType.VarChar, 50).Value = thevip.MaThe.ToUpper();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    trave = true;
                }
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                


            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                trave = false;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();

            }
            return trave;
        }
    }
}
