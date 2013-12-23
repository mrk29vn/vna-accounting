using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BizLogic
{
    public class KhuyenMaiSoLuong
    {
        private Connection conn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private Entities.KhuyenMaiSoLuong kmsl;
        private SqlConnection cn;

        public KhuyenMaiSoLuong()
        {

            conn = null;
            cmd = null;
            dr = null;
            kmsl = null;
            cn = null;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <returns></returns>
        public Entities.KhuyenMaiSoLuong[] Select()
        {
            Entities.KhuyenMaiSoLuong[] list = null;
            try
            {
                string sql = "exec sp_SelectKMSL";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<Entities.KhuyenMaiSoLuong> arr = new List<Entities.KhuyenMaiSoLuong>();
                while (dr.Read())
                {
                    Entities.KhuyenMaiSoLuong row = new Entities.KhuyenMaiSoLuong();
                    row.Id = Convert.ToInt32(dr["Id"].ToString());
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.TenHangHoa = dr["TenHangHoa"].ToString();
                    row.SoLuong = double.Parse(dr["SoLuong"].ToString());
                    row.NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
                    row.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
                    row.GiaBanBuon = double.Parse(dr["GiaBanBuon"].ToString());
                    row.GiaBanLe = double.Parse(dr["GiaBanLe"].ToString());
                    arr.Add(row);
                }

                list = arr.ToArray();
            }
            catch
            {
                list = null;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }

            return list;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <returns></returns>
        public Entities.KhuyenMaiSoLuong[] Select(Entities.KhuyenMaiSoLuong item)
        {
            Entities.KhuyenMaiSoLuong[] list = null;
            try
            {
                string sql = "exec sp_SelectKMSLTheoMa @MaHangHoa";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = item.MaHangHoa;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<Entities.KhuyenMaiSoLuong> arr = new List<Entities.KhuyenMaiSoLuong>();
                while (dr.Read())
                {
                    Entities.KhuyenMaiSoLuong row = new Entities.KhuyenMaiSoLuong();
                    row.Id = Convert.ToInt32(dr["Id"].ToString());
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.TenHangHoa = dr["TenHangHoa"].ToString();
                    row.SoLuong = double.Parse(dr["SoLuong"].ToString());
                    row.NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
                    row.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
                    row.GiaBanBuon = double.Parse(dr["GiaBanBuon"].ToString());
                    row.GiaBanLe = double.Parse(dr["GiaBanLe"].ToString());
                    arr.Add(row);
                }

                list = arr.ToArray();
            }
            catch
            {
                list = null;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }

            return list;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Insert(Entities.KhuyenMaiSoLuong item)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                string sql = "exec sp_InsertKMSL @Id,@MaHangHoa,@TenHangHoa,@NgayBatDau,@NgayKetThuc,@SoLuong,@GiaBanBuon,@GiaBanLe";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = item.MaHangHoa;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar, 200).Value = item.TenHangHoa;
                cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = item.NgayBatDau;
                cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = item.NgayKetThuc;
                cmd.Parameters.Add("SoLuong", SqlDbType.Float).Value = item.SoLuong;
                cmd.Parameters.Add("GiaBanBuon", SqlDbType.Float).Value = item.GiaBanBuon;
                cmd.Parameters.Add("GiaBanLe", SqlDbType.Float).Value = item.GiaBanLe;
                rt = cmd.ExecuteNonQuery();
            }
            catch
            {
                rt = 0;
            }

            return rt;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Update(Entities.KhuyenMaiSoLuong item)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                string sql = "exec sp_UpdateKMSL @Id,@MaHangHoa,@TenHangHoa,@NgayBatDau,@NgayKetThuc,@SoLuong,@GiaBanBuon,@GiaBanLe";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = item.Id;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = item.MaHangHoa;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar, 200).Value = item.TenHangHoa;
                cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = item.NgayBatDau;
                cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = item.NgayKetThuc;
                cmd.Parameters.Add("SoLuong", SqlDbType.Float).Value = item.SoLuong;
                cmd.Parameters.Add("GiaBanBuon", SqlDbType.Float).Value = item.GiaBanBuon;
                cmd.Parameters.Add("GiaBanLe", SqlDbType.Float).Value = item.GiaBanLe;
                rt = cmd.ExecuteNonQuery();
            }
            catch
            {
                rt = 0;
            }

            return rt;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Delete(Entities.KhuyenMaiSoLuong item)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                string sql = "exec sp_DeleteKMSL @MaHangHoa";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = item.MaHangHoa;
                rt = cmd.ExecuteNonQuery();
            }
            catch
            {
                rt = 0;
            }

            return rt;
        }
    }
}
