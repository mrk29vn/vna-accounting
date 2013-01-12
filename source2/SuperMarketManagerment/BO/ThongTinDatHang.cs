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
    public class ThongTinDatHang
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ThongTinDatHang dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThongTinDatHang dondathang;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinDatHang()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            dondathang = null;
            cn = null;
        }
        #endregion
        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_LayBang_HangHoa(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                dh = new Constants.ThongTinDatHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_HangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.MaHangHoa = dr[0].ToString();
                    dondathang.TenHangHoa = dr[1].ToString();
                    dondathang.GiaNhap = dr[2].ToString();
                    dondathang.Tonkho = dr[3].ToString();
                    dondathang.Giabanbuon = dr[4].ToString();
                    dondathang.Giabanle = dr[5].ToString();
                    dondathang.Giatrigiatang = dr[6].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_LayBang_HangHoaTheoMaKhoHang(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                string sql = "exec sp_LayBang_HangHoaTheoMaKhoHang @MaKho";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 50).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.MaHangHoa = dr[0].ToString();
                    dondathang.TenHangHoa = dr[1].ToString();
                    dondathang.GiaNhap = dr[2].ToString();
                    dondathang.Tonkho = dr[3].ToString();
                    dondathang.Giabanbuon = dr[4].ToString();
                    dondathang.Giabanle = dr[5].ToString();
                    dondathang.Giatrigiatang = dr[6].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_KiemKeHangHoa(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinDatHang[] list = null;
            try
            {
                dh = new Constants.ThongTinDatHang();
                Sql = new Constants.Sql();
                string sql = "exec sp_KiemKeHangHoa @MaKho";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.HanhDong = string.Empty;
                    dondathang.MaHangHoa = dr["MaHangHoa"].ToString();
                    dondathang.TenHangHoa = dr["TenHangHoa"].ToString();
                    dondathang.GiaNhap = dr["GiaNhap"].ToString();
                    dondathang.Tonkho = dr["SoLuong"].ToString();
                    dondathang.Giabanbuon = dr["GiaBanBuon"].ToString();
                    dondathang.Giabanle = dr["GiaBanLe"].ToString();
                    dondathang.Giatrigiatang = dr["GiaTriThue"].ToString();
                    arr.Add(dondathang);
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
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] KiemKeHangHoa(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                dh = new Constants.ThongTinDatHang();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_HangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.MaHangHoa = dr[0].ToString();
                    dondathang.TenHangHoa = dr[1].ToString();
                    dondathang.GiaNhap = dr[2].ToString();
                    dondathang.Tonkho = dr[3].ToString();
                    dondathang.Giabanbuon = dr[4].ToString();
                    dondathang.Giabanle = dr[5].ToString();
                    dondathang.Giatrigiatang = dr[6].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
        /// lay thong tin hoa don ban hang - khach hang
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_LayThongTinHoaDonBanHang()
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                Sql = new Constants.Sql();
                string sql = "exec sp_ThongTinHoaDonBanHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.MaHangHoa = dr[0].ToString();
                    dondathang.TenHangHoa = dr[1].ToString();
                    dondathang.GiaNhap = dr[2].ToString();
                    dondathang.Tonkho = dr[3].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
        /// hungvv lay thong tin don dat hang tra lai nha cung cap
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_LayDonDatHangNhaCungCap()
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                Sql = new Constants.Sql();
                string sql = "exec sp_LayDonDatHangNhaCungCap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.MaHangHoa = dr[0].ToString();
                    dondathang.TenHangHoa = dr[1].ToString();
                    string soluong =  dr[2].ToString();
                    string giagoc =  dr[3].ToString();
                    string  phantram = dr[4].ToString();
                    string tong = "0";
                    if (phantram == "0")
                    {
                        tong = (Double.Parse(giagoc) * Double.Parse(soluong)).ToString();
                    }
                    else
                    { 
                        tong = ((Double.Parse(soluong) * Double.Parse(giagoc))-((Double.Parse(phantram)/100) * Double.Parse(giagoc))).ToString();
                    }
                    dondathang.GiaNhap = tong;
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
        /// 
        /// </summary>
        /// <param name="dathang"></param>
        /// <returns></returns>
        public Entities.ThongTinDatHang[] sp_LayChiTietTraLaiNhaCungCap(Entities.ThongTinDatHang dathang)
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                Sql = new Constants.Sql();
                string sql = "exec sp_LayChiTietTraLaiNhaCungCap @MaNhaCungCap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.NVarChar, 20).Value = dathang.MaHangHoa;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.Tonkho = dr[0].ToString();
                    dondathang.MaHangHoa = dr[1].ToString();
                    dondathang.TenHangHoa = dr[2].ToString();
                    dondathang.GiaNhap = dr[3].ToString();
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
        #endregion

        public Entities.ThongTinDatHang[] ThongTinTraLaiNhaCungCap(Entities.ThongTinDatHang dathang)
        {
            Entities.ThongTinDatHang[] arrC = null;
            try
            {
                Sql = new Constants.Sql();
                string sql = "exec sp_ThongTinTraLaiNhaCungCap @MaHoaDonNhap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.VarChar, 20).Value = dathang.MaHangHoa;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    dondathang = new Entities.ThongTinDatHang();
                    dondathang.HanhDong = dr[0].ToString();//ma hoa don nhap
                    dondathang.MaHangHoa = dr[1].ToString();
                    dondathang.TenHangHoa = dr[2].ToString();
                    dondathang.GiaNhap = dr[3].ToString();//gianhap
                    dondathang.Tonkho = dr[4].ToString();//so luong
                    dondathang.Giabanbuon = dr[5].ToString();//thue giatrigiatang
                    arr.Add(dondathang);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.ThongTinDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinDatHang)arr[i];
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
    }
}
