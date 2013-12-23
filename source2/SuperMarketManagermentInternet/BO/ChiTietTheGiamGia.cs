using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BizLogic
{
    public class ChiTietTheGiamGia
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public ChiTietTheGiamGia() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        #region Thao Tác
        //==============Insert========================
        public int ThemSuaXoaChiTietTheGiamGia(Entities.ChiTietTheGiamGia input)
        {
            int bg = 0;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_ChiTietTheGiamGia @ThaoTac,@MaTheGiamGia,@MaKhachHang,@TenKhachHang,@GiaTriThe,@NgayThu,@MaPhieuThu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = input.ThaoTac;
                //set
                cmd.Parameters.Add("MaTheGiamGia", SqlDbType.VarChar).Value = input.MaTheGiamGia;
                cmd.Parameters.Add("MaKhachHang", SqlDbType.VarChar).Value = input.MaKhachHang;
                cmd.Parameters.Add("TenKhachHang", SqlDbType.NVarChar).Value = input.TenKhachHang;
                cmd.Parameters.Add("GiaTriThe", SqlDbType.Float).Value = input.GiaTriThe;
                cmd.Parameters.Add("NgayThu", SqlDbType.DateTime).Value = input.NgayThu;
                cmd.Parameters.Add("MaPhieuThu", SqlDbType.VarChar).Value = input.MaPhieuThu;
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
        public Entities.ChiTietTheGiamGia[] SelectChiTietTheGiamGia(Entities.ChiTietTheGiamGia input)
        {
            Entities.ChiTietTheGiamGia[] list = null;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_ChiTietTheGiamGia @ThaoTac,@MaTheGiamGia,@MaKhachHang,@TenKhachHang,@GiaTriThe,@NgayThu,@MaPhieuThu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = input.ThaoTac;
                //set
                cmd.Parameters.Add("MaTheGiamGia", SqlDbType.VarChar).Value = input.MaTheGiamGia;
                cmd.Parameters.Add("MaKhachHang", SqlDbType.VarChar).Value = input.MaKhachHang;
                cmd.Parameters.Add("TenKhachHang", SqlDbType.NVarChar).Value = input.TenKhachHang;
                cmd.Parameters.Add("GiaTriThe", SqlDbType.Float).Value = input.GiaTriThe;
                cmd.Parameters.Add("NgayThu", SqlDbType.DateTime).Value = input.NgayThu;
                cmd.Parameters.Add("MaPhieuThu", SqlDbType.VarChar).Value = input.MaPhieuThu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = input.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietTheGiamGia row = new Entities.ChiTietTheGiamGia();
                    row.MaTheGiamGia = dr["MaTheGiamGia"].ToString();
                    row.MaKhachHang = dr["MaKhachHang"].ToString();
                    row.TenKhachHang = dr["TenKhachHang"].ToString();
                    row.GiaTriThe = float.Parse(dr["GiaTriThe"].ToString());
                    row.NgayThu = DateTime.Parse(dr["NgayThu"].ToString());
                    row.MaPhieuThu = dr["MaPhieuThu"].ToString();
                    row.Deleted = bool.Parse(dr["Deleted"].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) list = null;
                list = new Entities.ChiTietTheGiamGia[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.ChiTietTheGiamGia)arr[i];
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
