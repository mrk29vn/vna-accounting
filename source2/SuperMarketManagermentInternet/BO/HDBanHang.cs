using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class HDBanHang
    {
        Constants.HDBanHang hdbh;
        Constants.Sql Sql;
        Entities.KhachHang[] kh;
        public void SelectKH()
        {
            kh = new BizLogic.KhachHang().Select();
            if (kh == null)
            {
                kh = new Entities.KhachHang[0];
            }
        }
        public string TimTenKH(string maKhachHang)
        {
            for (int i = 0; i < kh.Length; i++)
            {
                if (kh[i].MaKH == maKhachHang)
                {
                    return kh[i].Ten;
                }
            }
            return "";
        }
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.HDBanHang[] Select()
        {
            SelectKH();
            Sql = new Constants.Sql();
            hdbh = new Constants.HDBanHang();
            string sql = Sql.SelectHDBanHang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            List<Entities.HDBanHang> arr = new List<Entities.HDBanHang>();
            while (dr.Read())
            {
                Entities.HDBanHang hdbanhang = new Entities.HDBanHang();
                hdbanhang.HDBanHangID = Convert.ToInt32(dr[hdbh.HDBanHangID].ToString());
                hdbanhang.MaHDBanHang = dr[hdbh.MaHDBanHang].ToString();
                hdbanhang.NgayBan = DateTime.Parse(dr[hdbh.NgayBan].ToString());
                hdbanhang.MaKhachHang = dr[hdbh.MaKhachHang].ToString();
                hdbanhang.TenKhachHang = TimTenKH(dr[hdbh.MaKhachHang].ToString());
                hdbanhang.NoHienThoi = dr[hdbh.NoHienThoi].ToString();
                hdbanhang.NguoiNhanHang = dr[hdbh.NguoiNhanHang].ToString();
                hdbanhang.HinhThucThanhToan = dr[hdbh.HinhThucThanhToan].ToString();
                hdbanhang.MaKho = dr[hdbh.MaKho].ToString();
                hdbanhang.HanThanhToam = DateTime.Parse(dr[hdbh.HanThanhToam].ToString());
                hdbanhang.MaDonDatHang = dr[hdbh.MaDonDatHang].ToString();
                hdbanhang.MaNhanVien = dr[hdbh.MaNhanVien].ToString();
                hdbanhang.MaTienTe = dr[hdbh.MaTienTe].ToString();
                hdbanhang.ChietKhau = dr[hdbh.ChietKhau].ToString();
                hdbanhang.ThanhToanNgay = dr[hdbh.ThanhToanNgay].ToString();
                hdbanhang.ThanhToanKhiLapPhieu = dr[hdbh.ThanhToanKhiLapPhieu].ToString();
                hdbanhang.ThueGTGT = dr[hdbh.ThueGTGT].ToString();
                hdbanhang.TongTienThanhToan = dr[hdbh.TongTienThanhToan].ToString();
                hdbanhang.LoaiHoaDon = (Boolean)dr[hdbh.LoaiHoaDon];
                hdbanhang.MaThe = dr[hdbh.MaThe].ToString();
                hdbanhang.GiaTriThe = dr[hdbh.GiaTriThe].ToString();
                hdbanhang.GhiChu = dr[hdbh.GhiChu].ToString();
                hdbanhang.Deleted = (Boolean)dr[hdbh.Deleted];
                hdbanhang.KhachTra = dr["KhachTra"].ToString();
                hdbanhang.ChietKhauTongHoaDon = dr["ChietKhauTongHoaDon"].ToString();
                hdbanhang.MaTheGiaTri = dr[hdbh.MaTheGiaTri].ToString();
                hdbanhang.GiaTriTheGiaTri = dr[hdbh.GiaTriTheGiaTri].ToString();
                arr.Add(hdbanhang);
            }
            int n = arr.Count;
            if (n == 0) return null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arr.ToArray();
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.HDBanHang[] Select(string Cot, string Kieu, string Giatri, string makh)
        {
            hdbh = new Constants.HDBanHang();
            Sql = new Constants.Sql();
            string sql = "";
            if (Kieu == "like")
                sql = "select * from HDBanHang where " + Cot + " " + Kieu + " '%" + Giatri + "%' and MaKhachHang ='" + makh + "' and Deleted =0";
            else
                sql = "select * from HDBanHang where " + Cot + " " + Kieu + " '" + Giatri + "' and MaKhachHang ='" + makh + "'  and Deleted =0";
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            List<Entities.HDBanHang> arr = new List<Entities.HDBanHang>();
            while (dr.Read())
            {
                Entities.HDBanHang hdbanhang = new Entities.HDBanHang();
                hdbanhang.HDBanHangID = Convert.ToInt32(dr[hdbh.HDBanHangID].ToString());
                hdbanhang.MaHDBanHang = dr[hdbh.MaHDBanHang].ToString();
                hdbanhang.NgayBan = DateTime.Parse(dr[hdbh.NgayBan].ToString());
                hdbanhang.MaKhachHang = dr[hdbh.MaKhachHang].ToString();
                hdbanhang.NoHienThoi = dr[hdbh.NoHienThoi].ToString();
                hdbanhang.NguoiNhanHang = dr[hdbh.NguoiNhanHang].ToString();
                hdbanhang.HinhThucThanhToan = dr[hdbh.HinhThucThanhToan].ToString();
                hdbanhang.MaKho = dr[hdbh.MaKho].ToString();
                hdbanhang.HanThanhToam = DateTime.Parse(dr[hdbh.HanThanhToam].ToString());
                hdbanhang.MaDonDatHang = dr[hdbh.MaDonDatHang].ToString();
                hdbanhang.MaNhanVien = dr[hdbh.MaNhanVien].ToString();
                hdbanhang.MaTienTe = dr[hdbh.MaTienTe].ToString();
                hdbanhang.ChietKhau = dr[hdbh.ChietKhau].ToString();
                hdbanhang.ThanhToanNgay = dr[hdbh.ThanhToanNgay].ToString();
                hdbanhang.ThueGTGT = dr[hdbh.ThueGTGT].ToString();
                hdbanhang.TongTienThanhToan = dr[hdbh.TongTienThanhToan].ToString();
                hdbanhang.LoaiHoaDon = (Boolean)dr[hdbh.LoaiHoaDon];
                hdbanhang.GhiChu = dr[hdbh.GhiChu].ToString();
                hdbanhang.Deleted = (Boolean)dr[hdbh.Deleted];
                arr.Add(hdbanhang);
            }
            int n = arr.Count;
            if (n == 0) return null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arr.ToArray();
        }
        public Entities.HDBanHang[] Select_TheoMaKho(string makho)
        {
            hdbh = new Constants.HDBanHang();
            Sql = new Constants.Sql();
            string sql = "";

            sql = "select * from HDBanHang where MaKho ='" + makho + "' and Deleted =0";

            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //Insert Category into ArrayList
            List<Entities.HDBanHang> arr = new List<Entities.HDBanHang>();
            while (dr.Read())
            {
                Entities.HDBanHang hdbanhang = new Entities.HDBanHang();
                hdbanhang.HDBanHangID = Convert.ToInt32(dr[hdbh.HDBanHangID].ToString());
                hdbanhang.MaHDBanHang = dr[hdbh.MaHDBanHang].ToString();
                hdbanhang.NgayBan = DateTime.Parse(dr[hdbh.NgayBan].ToString());
                hdbanhang.MaKhachHang = dr[hdbh.MaKhachHang].ToString();
                hdbanhang.NoHienThoi = dr[hdbh.NoHienThoi].ToString();
                hdbanhang.NguoiNhanHang = dr[hdbh.NguoiNhanHang].ToString();
                hdbanhang.HinhThucThanhToan = dr[hdbh.HinhThucThanhToan].ToString();
                hdbanhang.MaKho = dr[hdbh.MaKho].ToString();
                hdbanhang.HanThanhToam = DateTime.Parse(dr[hdbh.HanThanhToam].ToString());
                hdbanhang.MaDonDatHang = dr[hdbh.MaDonDatHang].ToString();
                hdbanhang.MaNhanVien = dr[hdbh.MaNhanVien].ToString();
                hdbanhang.MaTienTe = dr[hdbh.MaTienTe].ToString();
                hdbanhang.ChietKhau = dr[hdbh.ChietKhau].ToString();
                hdbanhang.ThanhToanNgay = dr[hdbh.ThanhToanNgay].ToString();
                hdbanhang.ThueGTGT = dr[hdbh.ThueGTGT].ToString();
                hdbanhang.TongTienThanhToan = dr[hdbh.TongTienThanhToan].ToString();
                hdbanhang.LoaiHoaDon = (Boolean)dr[hdbh.LoaiHoaDon];
                hdbanhang.MaThe = dr[hdbh.MaThe].ToString();
                hdbanhang.GiaTriThe = dr[hdbh.GiaTriThe].ToString();
                hdbanhang.GhiChu = dr[hdbh.GhiChu].ToString();
                hdbanhang.Deleted = (Boolean)dr[hdbh.Deleted];
                arr.Add(hdbanhang);
            }
            int n = arr.Count;
            if (n == 0) return null;
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return arr.ToArray();
        }
        public bool InsertUpdate(Entities.HDBanHang hdbh1)
        {
            try
            {
                hdbh = new Constants.HDBanHang();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateHDBanHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hdbh.HanhDong, SqlDbType.NVarChar, 20).Value = hdbh1.HanhDong;
                cmd.Parameters.Add(hdbh.HDBanHangID, SqlDbType.Int).Value = hdbh1.HDBanHangID;
                cmd.Parameters.Add(hdbh.MaHDBanHang, SqlDbType.VarChar, 20).Value = hdbh1.MaHDBanHang;
                cmd.Parameters.Add(hdbh.NgayBan, SqlDbType.DateTime).Value = hdbh1.NgayBan;
                cmd.Parameters.Add(hdbh.MaKhachHang, SqlDbType.NVarChar, 20).Value = hdbh1.MaKhachHang;
                cmd.Parameters.Add(hdbh.NoHienThoi, SqlDbType.Float).Value = hdbh1.NoHienThoi;
                cmd.Parameters.Add(hdbh.NguoiNhanHang, SqlDbType.NVarChar, 200).Value = hdbh1.NguoiNhanHang;
                cmd.Parameters.Add(hdbh.HinhThucThanhToan, SqlDbType.NVarChar, 200).Value = hdbh1.HinhThucThanhToan;
                cmd.Parameters.Add(hdbh.MaKho, SqlDbType.VarChar, 20).Value = hdbh1.MaKho;
                cmd.Parameters.Add(hdbh.HanThanhToam, SqlDbType.DateTime).Value = hdbh1.HanThanhToam;
                cmd.Parameters.Add(hdbh.MaDonDatHang, SqlDbType.VarChar, 20).Value = hdbh1.MaDonDatHang;
                cmd.Parameters.Add(hdbh.MaNhanVien, SqlDbType.VarChar, 20).Value = hdbh1.MaNhanVien;
                cmd.Parameters.Add(hdbh.MaTienTe, SqlDbType.VarChar, 20).Value = hdbh1.MaTienTe;
                cmd.Parameters.Add(hdbh.ChietKhau, SqlDbType.Float).Value = hdbh1.ChietKhau;
                cmd.Parameters.Add(hdbh.ThanhToanNgay, SqlDbType.Float).Value = hdbh1.ThanhToanNgay;
                cmd.Parameters.Add(hdbh.ThanhToanKhiLapPhieu, SqlDbType.Float).Value = hdbh1.ThanhToanKhiLapPhieu;
                cmd.Parameters.Add(hdbh.ThueGTGT, SqlDbType.Float).Value = hdbh1.ThueGTGT;
                cmd.Parameters.Add(hdbh.TongTienThanhToan, SqlDbType.Float).Value = hdbh1.TongTienThanhToan;
                cmd.Parameters.Add(hdbh.LoaiHoaDon, SqlDbType.Bit).Value = hdbh1.LoaiHoaDon;
                cmd.Parameters.Add(hdbh.MaThe, SqlDbType.VarChar).Value = hdbh1.MaThe;
                cmd.Parameters.Add(hdbh.GiaTriThe, SqlDbType.Float).Value = hdbh1.GiaTriThe;
                cmd.Parameters.Add(hdbh.GhiChu, SqlDbType.NVarChar, 100).Value = hdbh1.GhiChu;
                cmd.Parameters.Add(hdbh.Deleted, SqlDbType.Bit).Value = hdbh1.Deleted;
                cmd.Parameters.Add(hdbh.KhachTra, SqlDbType.Float).Value = hdbh1.KhachTra;
                cmd.Parameters.Add(hdbh.ChietKhauTongHoaDon, SqlDbType.Float).Value = hdbh1.ChietKhauTongHoaDon;
                cmd.Parameters.Add(hdbh.MaTheGiaTri, SqlDbType.VarChar, 20).Value = hdbh1.MaTheGiaTri;
                cmd.Parameters.Add(hdbh.GiaTriTheGiaTri, SqlDbType.Float).Value = hdbh1.GiaTriTheGiaTri;
                int i = cmd.ExecuteNonQuery();
                bool kt = false;
                if (i == 1)
                    kt = true;
                else
                    kt = false;

                // trừ số lượng
                new BizLogic.ChiTietKhoHangTheoHoaHonNhap().TruSoLuong(hdbh1.ChiTietKhoHangTheoHoaHonNhap);
                // insert chi tiết hóa đơn
                new BizLogic.ChiTietHDBanHang().InsertUpdate(hdbh1.ChiTietHDBanHang);
                if (!hdbh1.LoaiHoaDon)
                {
                    // cập nhật trạng thái
                    if (hdbh1.DonDatHang != null)
                    {
                        new BizLogic.DonDatHang().CapNhatTrangThaiDonDatHang(hdbh1.DonDatHang);
                    }
                    // update dư nợ
                    if (hdbh1.KhachHang != null)
                    {
                        new BizLogic.KhachHang().Update(hdbh1.KhachHang);
                    }

                }
                else
                {
                    // update thẻ vip
                    if (hdbh1.TheVip != null)
                    {
                        new BizLogic.TheVip().Update(hdbh1.TheVip);
                    }
                    if (hdbh1.TheGiamGia != null)
                    {
                        new BizLogic.TheGiamGia().Update(hdbh1.TheGiamGia);
                    }
                }

                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }

        public bool UpdateThanhToanNgay(Entities.HDBanHang hdbh1)
        {
            try
            {
                hdbh = new Constants.HDBanHang();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateThanhToanngay;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hdbh.HanhDong, SqlDbType.NVarChar, 20).Value = hdbh1.HanhDong;
                cmd.Parameters.Add(hdbh.MaHDBanHang, SqlDbType.VarChar, 20).Value = hdbh1.MaHDBanHang;
                cmd.Parameters.Add(hdbh.ThanhToanNgay, SqlDbType.Float).Value = hdbh1.ThanhToanNgay;
                int i = cmd.ExecuteNonQuery();
                bool kt = false;
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }
        public bool UpdateThanhToanNgay(Entities.HDBanHang[] hdbh1)
        {
            try
            {
                for (int i = 0; i < hdbh1.Length; i++)
                {
                    if (hdbh1[i].MaHDBanHang != "")
                    {
                        UpdateThanhToanNgay(hdbh1[i]);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(Entities.HDBanHang hdbh1)
        {
            try
            {
                bool kt = false;
                hdbh = new Constants.HDBanHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteHDBangHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hdbh.HanhDong, SqlDbType.NVarChar, 20).Value = hdbh1.HanhDong;
                cmd.Parameters.Add(hdbh.HDBanHangID, SqlDbType.Int).Value = hdbh1.HDBanHangID;
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }
        public bool Delete(string maHDBanHang)
        {
            try
            {
                bool kt = false;
                hdbh = new Constants.HDBanHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteHDBanHang;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@maHDBanHang", SqlDbType.VarChar, 20).Value = maHDBanHang;
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
        }
    }
}
