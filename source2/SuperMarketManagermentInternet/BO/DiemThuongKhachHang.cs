using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BizLogic
{
    public class DiemThuongKhachHang
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public DiemThuongKhachHang() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        #region Thao Tác
        //==============Insert========================
        public int ThemSuaXoaDiemThuongKhachHang(Entities.DiemThuongKhachHang input)
        {
            int bg = 0;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_DiemThuongKhachHang @ThaoTac,@MaDiemThuongKhachHang,@MaKhachHang,@TenKhachHang,@TongDiem,@DiemDaDung,@DiemConLai,@GhiChu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = input.ThaoTac;
                //set
                cmd.Parameters.Add("MaDiemThuongKhachHang", SqlDbType.VarChar).Value = input.MaDiemThuongKhachHang;
                cmd.Parameters.Add("MaKhachHang", SqlDbType.VarChar).Value = input.MaKhachHang;
                cmd.Parameters.Add("TenKhachHang", SqlDbType.NVarChar).Value = input.TenKhachHang;
                cmd.Parameters.Add("TongDiem", SqlDbType.Int).Value = input.TongDiem;
                cmd.Parameters.Add("DiemDaDung", SqlDbType.Int).Value = input.DiemDaDung;
                cmd.Parameters.Add("DiemConLai", SqlDbType.Int).Value = input.DiemConLai;
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
        public Entities.DiemThuongKhachHang[] SelectDiemThuongKhachHang(Entities.DiemThuongKhachHang input)
        {
            Entities.DiemThuongKhachHang[] list = null;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_DiemThuongKhachHang @ThaoTac,@MaDiemThuongKhachHang,@MaKhachHang,@TenKhachHang,@TongDiem,@DiemDaDung,@DiemConLai,@GhiChu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = input.ThaoTac;
                //set
                cmd.Parameters.Add("MaDiemThuongKhachHang", SqlDbType.VarChar).Value = input.MaDiemThuongKhachHang;
                cmd.Parameters.Add("MaKhachHang", SqlDbType.VarChar).Value = input.MaKhachHang;
                cmd.Parameters.Add("TenKhachHang", SqlDbType.NVarChar).Value = input.TenKhachHang;
                cmd.Parameters.Add("TongDiem", SqlDbType.Int).Value = input.TongDiem;
                cmd.Parameters.Add("DiemDaDung", SqlDbType.Int).Value = input.DiemDaDung;
                cmd.Parameters.Add("DiemConLai", SqlDbType.Int).Value = input.DiemConLai;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = input.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = input.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.DiemThuongKhachHang row = new Entities.DiemThuongKhachHang();
                    row.MaDiemThuongKhachHang = dr["MaDiemThuongKhachHang"].ToString();
                    row.MaKhachHang = dr["MaKhachHang"].ToString();
                    row.TenKhachHang = dr["TenKhachHang"].ToString();
                    row.TongDiem = int.Parse(dr["TongDiem"].ToString());
                    row.DiemDaDung = int.Parse(dr["DiemDaDung"].ToString());
                    row.DiemConLai = int.Parse(dr["DiemConLai"].ToString());
                    row.GhiChu = dr["GhiChu"].ToString();
                    row.Deleted = bool.Parse(dr["Deleted"].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) list = null;
                list = new Entities.DiemThuongKhachHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.DiemThuongKhachHang)arr[i];
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
