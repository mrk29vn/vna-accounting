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
    public class SoLuongTraLai
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public SoLuongTraLai()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        /// <summary>
        /// lay so luong khach hang tra lai theo hoa don ban hang
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.SoLuongTraLai[] sp_LaySoLuongKhachHangTraLaiTheoHoaDonBanHang(Entities.TruyenGiaTri giatri)
        {
            Entities.SoLuongTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_LaySoLuongKhachHangTraLaiTheoHoaDonBanHang @MaHoaDonMuaHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonMuaHang", SqlDbType.NVarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.SoLuongTraLai tao = new Entities.SoLuongTraLai();
                    tao.MaHangHoa = dr[0].ToString();
                    tao.SoLuong = int.Parse(dr[1].ToString());
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.SoLuongTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.SoLuongTraLai)arr[i];
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
        /// lay so lupong mua theo hoa don ban hang
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.SoLuongTraLai[] sp_LaySoLuongDaMuaTheoHoaDonBanHang(Entities.TruyenGiaTri giatri)
        {
            Entities.SoLuongTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_LaySoLuongDaMuaTheoHoaDonBanHang @MaHDBanHang";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHDBanHang", SqlDbType.NVarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.SoLuongTraLai tao = new Entities.SoLuongTraLai();
                    tao.MaHangHoa = dr[0].ToString();
                    tao.SoLuong = int.Parse(dr[1].ToString());
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.SoLuongTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.SoLuongTraLai)arr[i];
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
        /// lay so luong tra lai nha cung cap theo hoa don nhap hang
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.SoLuongTraLai[] sp_LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang(Entities.TruyenGiaTri giatri)
        {
            Entities.SoLuongTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang @MaHoaDonNhap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.SoLuongTraLai tao = new Entities.SoLuongTraLai();
                    tao.MaHangHoa = dr[0].ToString();
                    tao.SoLuong = int.Parse(dr[1].ToString());
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.SoLuongTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.SoLuongTraLai)arr[i];
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
        /// lay so luong theo hoa don nhap
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.SoLuongTraLai[] sp_LaySoLuongDaNhapTheoHoaDonNhap(Entities.TruyenGiaTri giatri)
        {
            Entities.SoLuongTraLai[] arrC = null;
            try
            {
                string sql = "exec sp_LaySoLuongDaNhapTheoHoaDonNhap @MaHoaDonNhap";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaHoaDonNhap", SqlDbType.VarChar, 20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.SoLuongTraLai tao = new Entities.SoLuongTraLai();
                    tao.MaHangHoa = dr[0].ToString();
                    tao.SoLuong = int.Parse(dr[1].ToString());
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.SoLuongTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.SoLuongTraLai)arr[i];
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
