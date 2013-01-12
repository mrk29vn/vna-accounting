using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BizLogic
{
    public class TyLeTinh
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public TyLeTinh() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        #region Thao Tác
        //==============Insert========================
        public int InsertTyLeTinh(Entities.TyLeTinh input)
        {
            int bg = 0;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_TyLeTinh @ThaoTac,@MaTyLeTinh,@SoTien,@NgayNhap,@GhiChu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "insert";
                //set
                cmd.Parameters.Add("MaTyLeTinh", SqlDbType.VarChar).Value = input.MaTyLeTinh;
                cmd.Parameters.Add("SoTien", SqlDbType.Float).Value = input.SoTien;
                cmd.Parameters.Add("NgayNhap", SqlDbType.DateTime).Value = input.NgayNhap;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = input.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = input.Deleted;
                bg = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                bg = 0;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();
            }
            if (bg == 0)
                return bg;
            return bg;
        }

        //==============Select========================
        public Entities.TyLeTinh[] SelectTyLeTinh()
        {
            Entities.TyLeTinh[] list = null;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_TyLeTinh @ThaoTac,@MaTyLeTinh,@SoTien,@NgayNhap,@GhiChu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "select";
                Entities.TyLeTinh input = new Entities.TyLeTinh();
                //set
                cmd.Parameters.Add("MaTyLeTinh", SqlDbType.VarChar).Value = input.MaTyLeTinh;
                cmd.Parameters.Add("SoTien", SqlDbType.Float).Value = input.SoTien;
                cmd.Parameters.Add("NgayNhap", SqlDbType.DateTime).Value = input.NgayNhap;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = input.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = input.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.TyLeTinh row = new Entities.TyLeTinh();
                    row.MaTyLeTinh = dr["MaTyLeTinh"].ToString();
                    row.SoTien = double.Parse(dr["SoTien"].ToString());
                    row.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    row.GhiChu = dr["GhiChu"].ToString();
                    row.Deleted = bool.Parse(dr["Deleted"].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) list = null;
                list = new Entities.TyLeTinh[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.TyLeTinh)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();
            }
            return list;
        }
        //======================================================================================================
        #endregion
    }
}
