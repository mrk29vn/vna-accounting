using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BizLogic
{
    public class GiaVon
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public GiaVon() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        #region Thao Tác
        //============Thêm Sửa Xóa===================================================
        /// <summary>
        /// ThaoTac_GiaVon:
        /// - Select_GIAVON
        /// - Insert_GIAVON
        /// - Update_TheoMaKhoVaMaHangHoa_GIAVON
        /// - Delete_TheoMaKhoVaMaHangHoa_GIAVON
        /// </summary>
        /// <param name="thaotac"></param>
        /// <param name="set"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int ThaoTac_GiaVon(string thaotac, Entities.GiaVon set, Entities.GiaVon filter)
        {
            int bg = 0;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_GiaVon @ThaoTac,@MaKho,@MaHangHoa,@SoLuong,@Gia,@MaKhok,@MaHangHoak,@SoLuongk,@Giak", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = thaotac;
                //set
                cmd.Parameters.Add("MaKho", SqlDbType.NVarChar).Value = set.MaKho;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.NVarChar).Value = set.MaHangHoa;
                cmd.Parameters.Add("SoLuong", SqlDbType.NVarChar).Value = set.SoLuong;
                cmd.Parameters.Add("Gia", SqlDbType.NVarChar).Value = set.Gia;
                //filter
                cmd.Parameters.Add("MaKhok", SqlDbType.NVarChar).Value = filter.MaKho;
                cmd.Parameters.Add("MaHangHoak", SqlDbType.NVarChar).Value = filter.MaHangHoa;
                cmd.Parameters.Add("SoLuongk", SqlDbType.NVarChar).Value = filter.SoLuong;
                cmd.Parameters.Add("Giak", SqlDbType.NVarChar).Value = filter.Gia;
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
        /// <summary>
        /// SelectTheoDieuKien_GiaVon:
        /// - Select_GIAVON
        /// - Insert_GIAVON
        /// - Update_TheoMaKhoVaMaHangHoa_GIAVON
        /// - Delete_TheoMaKhoVaMaHangHoa_GIAVON
        /// </summary>
        /// <param name="thaotac"></param>
        /// <param name="set"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Entities.GiaVon[] SelectTheoDieuKien_GiaVon(string thaotac, Entities.GiaVon set, Entities.GiaVon filter)
        {
            Entities.GiaVon[] list = null;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_GiaVon @ThaoTac,@MaKho,@MaHangHoa,@SoLuong,@Gia,@MaKhok,@MaHangHoak,@SoLuongk,@Giak", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = thaotac;
                //set
                cmd.Parameters.Add("MaKho", SqlDbType.NVarChar).Value = set.MaKho;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.NVarChar).Value = set.MaHangHoa;
                cmd.Parameters.Add("SoLuong", SqlDbType.NVarChar).Value = set.SoLuong;
                cmd.Parameters.Add("Gia", SqlDbType.NVarChar).Value = set.Gia;
                //filter
                cmd.Parameters.Add("MaKhok", SqlDbType.NVarChar).Value = filter.MaKho;
                cmd.Parameters.Add("MaHangHoak", SqlDbType.NVarChar).Value = filter.MaHangHoa;
                cmd.Parameters.Add("SoLuongk", SqlDbType.NVarChar).Value = filter.SoLuong;
                cmd.Parameters.Add("Giak", SqlDbType.NVarChar).Value = filter.Gia;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.GiaVon row = new Entities.GiaVon();
                    row.MaKho = dr["MaKho"].ToString();
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    row.Gia = float.Parse(dr["Gia"].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) list = null;
                list = new Entities.GiaVon[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.GiaVon)arr[i];
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
