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
    public class ThongTinMaVach
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ThongTinMaVach mavach;
        private SqlConnection cn;

        public ThongTinMaVach()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            mavach = null;
            cn = null;
        }
        //Entities
        public Entities.ThongTinMaVach[] sp_LayBang_ThongTinMaVachHangHoa()
        {
            Entities.ThongTinMaVach[] arrC = null;
            try
            {
                string sql = "exec sp_LayBang_ThongTinMaVachHangHoa";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    mavach = new Entities.ThongTinMaVach();
                    mavach.ChonIn = false;
                    mavach.MaHangHoa = dr[0].ToString();
                    mavach.TenHangHoa = dr[1].ToString();
                    mavach.GiaNhap = dr[2].ToString();
                    mavach.GiaBanBuon = dr[3].ToString();
                    mavach.GiaBanLe = dr[4].ToString();
                    mavach.GhiChu = "";
                    arr.Add(mavach);
                }
                int n = arr.Count;
                if (n == 0) { arrC= null; }
                arrC = new Entities.ThongTinMaVach[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinMaVach)arr[i];
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

        public Entities.ThongTinMaVach[] sp_LayBang_ThongTinMaVachTheVip()
        {
            Entities.ThongTinMaVach[] arrC = null;
            try
            {
                string sql = "exec sp_LayBang_ThongTinMaVachTheVip";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    mavach = new Entities.ThongTinMaVach();
                    mavach.ChonIn = false;
                    mavach.MaHangHoa = dr[0].ToString();    //TheVip.MaThe
                    mavach.TenHangHoa = dr[1].ToString();   //KhachHang.Ten
                    mavach.GiaNhap = dr[2].ToString();      //TheVip.GiaTriThe
                    mavach.GiaBanBuon = dr[3].ToString();   //TheVip.GiaTriConLai
                    mavach.GiaBanLe = dr[4].ToString();     //TheVip.GhiChu
                    mavach.GhiChu = dr[5].ToString();       //TheVip.MaKhachHang
                    arr.Add(mavach);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.ThongTinMaVach[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinMaVach)arr[i];
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

        public Entities.ThongTinMaVach[] sp_LayBang_ThongTinMaVachTheGiaTri()
        {
            Entities.ThongTinMaVach[] arrC = null;
            try
            {
                string sql = "exec sp_LayBang_ThongTinMaVachTheGiaTri";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    mavach = new Entities.ThongTinMaVach();
                    mavach.ChonIn = false;
                    mavach.MaHangHoa = dr[0].ToString();    //TheGiamGia.MaTheGiamGia
                    mavach.TenHangHoa = dr[1].ToString();   //KhachHang.Ten
                    mavach.GiaNhap = dr[2].ToString();      //TheGiamGia.GiaTriThe
                    mavach.GiaBanBuon = dr[3].ToString();   //TheGiamGia.GiaTriConLai
                    mavach.GiaBanLe = "";                   // ""
                    mavach.GhiChu = dr[4].ToString();       //TheGiamGia.MaKhachHang
                    arr.Add(mavach);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.ThongTinMaVach[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinMaVach)arr[i];
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
