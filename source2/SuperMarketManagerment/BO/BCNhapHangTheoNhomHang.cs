using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BizLogic
{
    public class BCNhapHangTheoNhomHang
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public BCNhapHangTheoNhomHang() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.BCNhapHangTheoNhomHang Select()
        {
            Entities.BCNhapHangTheoNhomHang list = null;
            try
            {
                list = new Entities.BCNhapHangTheoNhomHang();

                ////Lấy hóa đơn nhập
                //con = new Connection();
                //cn = con.openConnection();
                //List<Entities.HoaDonNhap> HoaDonNhap = new List<Entities.HoaDonNhap>();
                //cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                //cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "HoaDonNhap";
                //dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //while (dr.Read())
                //{
                //    Entities.HoaDonNhap row = new Entities.HoaDonNhap();
                //    row.MaHoaDonNhap = dr["MaHoaDonNhap"].ToString();
                //    row.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                //    HoaDonNhap.Add(row);
                //}
                //list.HoaDonNhap = HoaDonNhap;
                //cmd.Connection.Dispose();
                //cn.Close();
                //con.closeConnection();

                //Lấy chi tiết hóa đơn nhập
                con = new Connection();
                cn = con.openConnection();
                List<Entities.ChiTietHoaDonNhap> ChiTietHoaDonNhap = new List<Entities.ChiTietHoaDonNhap>();
                cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "ChiTietHoaDonNhap";
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.ChiTietHoaDonNhap row = new Entities.ChiTietHoaDonNhap();
                    row.MaHoaDonNhap = dr["MaHoaDonNhap"].ToString();
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    row.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    ChiTietHoaDonNhap.Add(row);
                }
                list.ChiTietHoaDonNhap = ChiTietHoaDonNhap;
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();

                ////Lấy khách hàng trả lại
                //con = new Connection();
                //cn = con.openConnection();
                //List<Entities.KhachHangTraLai> KhachHangTraLai = new List<Entities.KhachHangTraLai>();
                //cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                //cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "KhachHangTraLai";
                //dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //while (dr.Read())
                //{
                //    Entities.KhachHangTraLai row = new Entities.KhachHangTraLai();
                //    row.MaKhachHangTraLai = dr["MaKhachHangTraLai"].ToString();
                //    row.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                //    KhachHangTraLai.Add(row);
                //}
                //list.KhachHangTraLai = KhachHangTraLai;
                //cmd.Connection.Dispose();
                //cn.Close();
                //con.closeConnection();

                //Lấy chi tiết khách hàng trả lại
                con = new Connection();
                cn = con.openConnection();
                List<Entities.ChiTietKhachHangTraLai> ChiTietKhachHangTraLai = new List<Entities.ChiTietKhachHangTraLai>();
                cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "ChiTietKhachHangTraLai";
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.ChiTietKhachHangTraLai row = new Entities.ChiTietKhachHangTraLai();
                    row.MaKhachHangTraLai = dr["MaKhachHangTraLai"].ToString();
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    row.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    ChiTietKhachHangTraLai.Add(row);
                }
                list.ChiTietKhachHangTraLai = ChiTietKhachHangTraLai;
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();

                //Lấy hàng hóa nhóm hàng
                con = new Connection();
                cn = con.openConnection();
                List<Entities.HangHoa> HangHoa = new List<Entities.HangHoa>();
                cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "HangHoaNhomHang";
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.HangHoa row = new Entities.HangHoa();
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.TenHangHoa = dr["TenHangHoa"].ToString();
                    row.MaNhomHangHoa = dr["MaNhomHang"].ToString();
                    row.TenNhomHangHoa = dr["TenNhomHang"].ToString();
                    HangHoa.Add(row);
                }
                list.HangHoa = HangHoa;
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();

                //Lấy nhóm hàng
                con = new Connection();
                cn = con.openConnection();
                List<Entities.NhomHang> NhomHang = new List<Entities.NhomHang>();
                cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "NhomHang";
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.NhomHang row = new Entities.NhomHang();
                    row.MaNhomHang = dr["MaNhomHang"].ToString();
                    row.TenNhomHang = dr["TenNhomHang"].ToString();
                    NhomHang.Add(row);
                }
                list.NhomHang = NhomHang;
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();

                //Lấy gói hàng
                con = new Connection();
                cn = con.openConnection();
                List<Entities.GoiHang> GoiHang = new List<Entities.GoiHang>();
                cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "GoiHang";
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.GoiHang row = new Entities.GoiHang();
                    row.MaGoiHang = dr["MaGoiHang"].ToString();
                    GoiHang.Add(row);
                }
                list.GoiHang = GoiHang;
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();

                //Lấy chi tiết gói hàng
                con = new Connection();
                cn = con.openConnection();
                List<Entities.ChiTietGoiHang> ChiTietGoiHang = new List<Entities.ChiTietGoiHang>();
                cmd = new SqlCommand("exec sp_BCNhapHangTheoNhomHangFIX @ThaoTac", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = "ChiTietGoiHang";
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.ChiTietGoiHang row = new Entities.ChiTietGoiHang();
                    row.MaGoiHang = dr["MaGoiHang"].ToString();
                    row.MaHangHoa = dr["MaHangHoa"].ToString();
                    row.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    ChiTietGoiHang.Add(row);
                }
                list.ChiTietGoiHang = ChiTietGoiHang;
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();

            }
            catch { return null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();
            }
            return list;
        }
    }
}
