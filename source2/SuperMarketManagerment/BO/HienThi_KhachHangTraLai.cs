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
    public class HienThi_KhachHangTraLai
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public HienThi_KhachHangTraLai()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
       
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.HienThi_KhachHangTraLai[] sp_HoaDonBanHangTheoKhachHang(Entities.TruyenGiaTri lay)
        {
            Entities.HienThi_KhachHangTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_KhachHangTraLaiHang @MaKhachHang ,@MaHDBanHang,@LoaiHoaDon";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKhachHang", SqlDbType.NVarChar, 20).Value = "" + lay.Giatritruyen;
                cmd.Parameters.Add("MaHDBanHang", SqlDbType.VarChar, 20).Value =  ""+lay.Giatriba;
                cmd.Parameters.Add("LoaiHoaDon", SqlDbType.VarChar, 20).Value = ""+lay.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.HienThi_KhachHangTraLai bang = new Entities.HienThi_KhachHangTraLai();
                    bang.Mahoadonbanhang = dr[0].ToString();
                    bang.Ngayban = DateTime.Parse(dr[1].ToString());
                    bang.Tongtien = dr[2].ToString();
                    bang.Nohienthoi = dr[3].ToString();
                    bang.MaKho = dr[4].ToString();
                    arr.Add(bang);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.HienThi_KhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HienThi_KhachHangTraLai)arr[i];
                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gitri"></param>
        /// <returns></returns>
        public Entities.ThongTinKhachHang[] BindingKhachHangTralaiHang(Entities.TruyenGiaTri gitri)
        {
            Entities.ThongTinKhachHang[] list = null;
            try
            {
                string sql = "exec sp_BindingKhachHangTralaiHang @LoaiHoaDon";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("LoaiHoaDon", SqlDbType.VarChar,20).Value = gitri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ThongTinKhachHang khachhang = new Entities.ThongTinKhachHang();
                    khachhang.Makhachhang = dr[0].ToString();
                    khachhang.Tenkhachhang = dr[1].ToString();
                    khachhang.Diachi = dr[2].ToString();
                    khachhang.Duno = dr[3].ToString();
                    arr.Add(khachhang);
                }
                int n = arr.Count;
                if (n == 0) { list= null; }
                list = new Entities.ThongTinKhachHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.ThongTinKhachHang)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }

        public Entities.ThongTinDatHang[] ChiTietKhachHangTraLaiTheoDonBanHang(Entities.TruyenGiaTri gitri)
        {
            Entities.ThongTinDatHang[] list = null;
            try
            {
                string sql = "exec sp_ChiTietKhachHangTraLaiTheoDonBanHang @MaHDBanHang,@LoaiHoaDon";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHDBanHang", SqlDbType.NVarChar, 20).Value = gitri.Giatritruyen;
                cmd.Parameters.Add("LoaiHoaDon", SqlDbType.VarChar,20).Value = gitri.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ThongTinDatHang lay = new Entities.ThongTinDatHang();
                    lay.HanhDong = dr[0].ToString();
                    lay.MaHangHoa = dr[1].ToString();
                    lay.TenHangHoa = dr[2].ToString();
                    lay.GiaNhap = dr[3].ToString();
                    lay.Tonkho = dr[4].ToString();
                    lay.Giatrigiatang = dr[5].ToString();
                    arr.Add(lay);
                }
                int n = arr.Count;
                if (n == 0) { list= null; }
                list = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.ThongTinDatHang)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }

        /// <summary>
        /// vuong hung =================lay hang hoa theo ma hoa don ban hang================
        /// </summary>
        /// <returns></returns>
        public Entities.LayHangHoaTheoMaKhachHangTraLai[] sp_LayHangHoaTheoHoaDonBanHang(Entities.TruyenGiaTri lay)
        {
            Entities.LayHangHoaTheoMaKhachHangTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_KhachHangTraLaiHang @MaKhachHang ,@MaHDBanHang,@LoaiHoaDon";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKhachHang", SqlDbType.NVarChar, 20).Value = lay.Giatritruyen;
                cmd.Parameters.Add("MaHDBanHang", SqlDbType.VarChar, 20).Value = lay.Giatrithuhai;
                cmd.Parameters.Add("LoaiHoaDon", SqlDbType.VarChar, 20).Value = lay.Giatriba;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.LayHangHoaTheoMaKhachHangTraLai bang = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                    bang.Mahanghoa = dr[0].ToString();
                    bang.Tenhanghoa = dr[1].ToString();
                    bang.Soluong = int.Parse(dr[2].ToString());
                    bang.Giaban = dr[3].ToString();
                    bang.Phantramchietkhau = dr[4].ToString();
                    bang.Chietkhau = dr[5].ToString();
                    bang.Tongtien = dr[6].ToString();
                    bang.Thuegiatrigiatang = dr[7].ToString();
                    arr.Add(bang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }

        /// <summary>
        /// vuong hung =================lay hang hoa theo ma tra lai nha cung cap================
        /// </summary>
        /// <returns></returns>
        public Entities.HienThi_KhachHangTraLai[] sp_TimHoaDonNhapTheoMaNhaCungCap(Entities.TruyenGiaTri lay)
        {
            Entities.HienThi_KhachHangTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_TimHoaDonNhapTheoMaNhaCungCap @MaNhaCungCap,@MaHoaDonNhap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.NVarChar, 20).Value = lay.Giatritruyen;
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.VarChar, 20).Value = lay.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.HienThi_KhachHangTraLai bang = new Entities.HienThi_KhachHangTraLai();
                    bang.Mahoadonbanhang = dr[0].ToString();
                    bang.Ngayban = DateTime.Parse(dr[1].ToString());
                    bang.Tongtien = dr[2].ToString();
                    bang.Nohienthoi = dr[3].ToString();
                    bang.MaKho = dr[4].ToString();
                    arr.Add(bang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.HienThi_KhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HienThi_KhachHangTraLai)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }
        /// <summary>
        /// vuong hung =================lay hang hoa theo ma hoa don ban hang================
        /// </summary>
        /// <returns></returns>
        public Entities.LayHangHoaTheoMaKhachHangTraLai[] sp_LayHangHoaTheoMaHoaDonNhap(Entities.TruyenGiaTri lay)
        {
            Entities.LayHangHoaTheoMaKhachHangTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_TimHoaDonNhapTheoMaNhaCungCap @MaNhaCungCap,@MaHoaDonNhap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.NVarChar, 20).Value = lay.Giatritruyen;
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.VarChar, 20).Value = lay.Giatrithuhai;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.LayHangHoaTheoMaKhachHangTraLai bang = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                    bang.Mahanghoa = dr[0].ToString();
                    bang.Tenhanghoa = dr[1].ToString();
                    bang.Soluong = int.Parse(dr[2].ToString());
                    bang.Giaban = dr[3].ToString();
                    bang.Phantramchietkhau = dr[4].ToString();
                    bang.Chietkhau = dr[5].ToString();
                    bang.Tongtien = dr[6].ToString();
                    bang.Thuegiatrigiatang = dr[7].ToString();
                    arr.Add(bang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }
        /// <summary>
        /// lay hang hoa theo ma khach hang tra lai
        /// </summary>
        /// <param name="lay"></param>
        /// <returns></returns>
        //public Entities.LayHangHoaTheoMaKhachHangTraLai[] sp_LayHangHoaTheoMaKhachHangTraLai(Entities.TruyenGiaTri lay)
        //{
        //    Entities.LayHangHoaTheoMaKhachHangTraLai[] arrC = null;
        //    try
        //    {
        //        string sql = "exec sp_LayHangHoaTheoMaKhachHangTraLai @MaKhachHangTraLai,@LoaiHoaDon";
        //        conn = new Connection();
        //        cn = conn.openConnection();
        //        cmd = new SqlCommand(sql, cn);
        //        cmd.Parameters.Add("MaKhachHangTraLai", SqlDbType.VarChar, 20).Value = lay.Giatritruyen;
        //        cmd.Parameters.Add("LoaiHoaDon", SqlDbType.VarChar, 20).Value = lay.Giatrithuhai;
        //        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        arr = new ArrayList();
        //        while (dr.Read())
        //        {
        //            Entities.LayHangHoaTheoMaKhachHangTraLai bang = new Entities.LayHangHoaTheoMaKhachHangTraLai();
        //            bang.Mahanghoa = dr[0].ToString();
        //            bang.Tenhanghoa = dr[1].ToString();
        //            bang.Soluong = int.Parse(dr[2].ToString());
        //            bang.Giaban = dr[3].ToString();
        //            string phantram = "0";
        //            string chietkhau = "0";
        //            string tong = "0";
        //            if (Double.Parse(dr[4].ToString()) == 0)
        //            {
        //                tong = new Common.Utilities().FormatMoney(int.Parse(dr[2].ToString()) * Double.Parse(dr[3].ToString()));
        //                chietkhau = tong;
        //            }
        //            else
        //            {
        //                phantram = dr[4].ToString();
        //                tong = new Common.Utilities().FormatMoney(int.Parse(dr[2].ToString()) * Double.Parse(dr[3].ToString()));
        //                chietkhau = new Common.Utilities().FormatMoney(Double.Parse(tong) - ((Double.Parse(phantram) / 100 * Double.Parse(dr[3].ToString())) * int.Parse(dr[2].ToString())));
        //            }
        //            bang.Phantramchietkhau = phantram;
        //            bang.Thuegiatrigiatang = dr[5].ToString();
        //            bang.Chietkhau = chietkhau;
        //            bang.Tongtien = tong;
        //            arr.Add(bang);
        //        }
        //        int n = arr.Count;
        //        if (n == 0) { arrC= null; }
        //        arrC = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
        //        for (int i = 0; i < n; i++)
        //        {
        //            arrC[i] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[i];
        //        }
        //    }
        //    catch (Exception ex)
        //    { string s = ex.Message.ToString(); arrC = null; }
        //    finally
        //    {
        //        cmd.Connection.Dispose();
        //        cn.Close();
        //        conn.closeConnection();
        //    }
        //    return arrC;
        //}
        public Entities.LayHangHoaTheoMaKhachHangTraLai[] sp_LayHangHoaTheoMaKhachHangTraLai(Entities.TruyenGiaTri lay)
        {
            Entities.LayHangHoaTheoMaKhachHangTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_LayHangHoaTheoMaKhachHangTraLai @MaKhachHangTraLai,@MaKhachHang,@MaHDBanHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKhachHangTraLai", SqlDbType.VarChar, 20).Value = lay.Giatritruyen;
                cmd.Parameters.Add("MaKhachHang", SqlDbType.VarChar, 20).Value = lay.Giatrithuhai;
                cmd.Parameters.Add("MaHDBanHang", SqlDbType.VarChar, 20).Value = lay.Giatriba;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.LayHangHoaTheoMaKhachHangTraLai bang = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                    bang.Mahanghoa = dr[0].ToString();
                    bang.Tenhanghoa = dr[1].ToString();
                    bang.Soluong = int.Parse(dr[2].ToString());
                    bang.Giaban = dr[3].ToString();
                    string phantram = "0";
                    string chietkhau = "0";
                    string tong = "0";
                    if (Double.Parse(dr[4].ToString()) == 0)
                    {
                        tong = new Common.Utilities().FormatMoney(int.Parse(dr[2].ToString()) * Double.Parse(dr[3].ToString()));
                        chietkhau = tong;
                    }
                    else
                    {
                        phantram = dr[4].ToString();
                        tong = new Common.Utilities().FormatMoney(int.Parse(dr[2].ToString()) * Double.Parse(dr[3].ToString()));
                        chietkhau = new Common.Utilities().FormatMoney(Double.Parse(tong) - ((Double.Parse(phantram) / 100 * Double.Parse(dr[3].ToString())) * int.Parse(dr[2].ToString())));
                    }
                    bang.Phantramchietkhau = phantram;
                    bang.Thuegiatrigiatang = dr[5].ToString();
                    bang.Chietkhau = chietkhau;
                    bang.Tongtien = tong;
                    arr.Add(bang);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[i];
                }
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
        /// <summary>
        /// lay hang hoa theo ma tra lai nha cung cap
        /// </summary>
        /// <param name="truyen"></param>
        public Entities.LayHangHoaTheoMaKhachHangTraLai[] LayHangHoaTheoMaTraLaiNhaCungCap(Entities.TruyenGiaTri truyen)
        {
            Entities.LayHangHoaTheoMaKhachHangTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_LayHangHoaTheoMaTraLaiNhaCungCap @MaTraLaiNhaCungCap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaTraLaiNhaCungCap", SqlDbType.VarChar, 20).Value = truyen.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.LayHangHoaTheoMaKhachHangTraLai bang = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                    bang.Mahanghoa = dr[0].ToString();
                    bang.Tenhanghoa = dr[1].ToString();
                    bang.Soluong = int.Parse(dr[2].ToString());
                    bang.Giaban = dr[3].ToString();
                    string phantram = "0";
                    string chietkhau = "0";
                    string tong = "0";
                    if (Double.Parse(dr[4].ToString()) == 0)
                    {
                        tong = new Common.Utilities().FormatMoney(int.Parse(dr[2].ToString()) * Double.Parse(dr[3].ToString()));
                        chietkhau = tong;
                    }
                    else
                    {
                        phantram = dr[4].ToString();
                        tong = new Common.Utilities().FormatMoney(int.Parse(dr[2].ToString()) * Double.Parse(dr[3].ToString()));
                        chietkhau = new Common.Utilities().FormatMoney(Double.Parse(tong) - ((Double.Parse(phantram) / 100 * Double.Parse(dr[3].ToString())) * int.Parse(dr[2].ToString())));
                    }
                    bang.Phantramchietkhau = phantram;
                    bang.Thuegiatrigiatang = dr[5].ToString();
                    bang.Chietkhau = chietkhau;
                    bang.Tongtien = tong;
                    arr.Add(bang);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[i];
                }
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
        #endregion
    }
}
