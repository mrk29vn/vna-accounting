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
    public class HangHoaGoiHang
    {
        private Constants.HoaDonNhap dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.HoaDonNhap cla;
        private SqlConnection cn;
        public HangHoaGoiHang()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cla = null;
            cn = null;
        }
        private string Thue(string mathue)
        {
            string data = "0";
            try
            {
                Entities.Thue[] thue = new BizLogic.Thue().Select();
                if (thue!=null)
                {
                    for (int k = 0; k < thue.Length; k++)
                    {
                        if (thue[k].MaThue == mathue)
                        {
                            data = thue[k].GiaTriThue;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                data = null;
            }
            return data;
        }
        public Entities.HangHoaGoiHang[] Select()
        {
            Entities.HangHoaGoiHang[] data = null;
            try
            {
                ArrayList list = new ArrayList();
                Entities.GoiHang[] goi = new BizLogic.GoiHang().Select();
                Entities.HangHoa[] hanghoa = new BizLogic.HangHoa().Select();
                if (goi!= null)
                {
                    for (int k = 0; k < goi.Length; k++)
                    {
                        Entities.HangHoaGoiHang row = new Entities.HangHoaGoiHang();
                        row.TenHang = goi[k].TenGoiHang;
                        row.MaHang = goi[k].MaGoiHang;
                        row.GiaNhap = goi[k].GiaNhap;
                        row.GiaBanBuon = goi[k].GiaBanBuon;
                        row.GiaBanLe = goi[k].GiaBanLe;
                        row.Thue = "0";
                        list.Add(row);
                    }
                }
                if (hanghoa!=null)
                {
                    for (int k = 0; k < hanghoa.Length; k++)
                    {
                        Entities.HangHoaGoiHang row = new Entities.HangHoaGoiHang();
                        row.TenHang = hanghoa[k].TenHangHoa;
                        row.MaHang = hanghoa[k].MaHangHoa;
                        row.GiaNhap = hanghoa[k].GiaNhap;
                        row.GiaBanBuon = hanghoa[k].GiaBanBuon;
                        row.GiaBanLe = hanghoa[k].GiaBanLe;
                        row.Thue =Thue(hanghoa[k].MaThueGiaTriGiaTang);
                        list.Add(row);
                    }
                }
                int n = list.Count;
                if (n == 0) { data = null; }
                data = new Entities.HangHoaGoiHang[n];
                for (int i = 0; i < n; i++)
                {
                    data[i] = (Entities.HangHoaGoiHang)list[i];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                data = null; 
            }
            return data;
        }
        public Entities.HienThi_ChiTiet_DonDatHang Select(string mahang)
        {
            Entities.HienThi_ChiTiet_DonDatHang data = null;
            try
            {
                Entities.GoiHang[] goi = new BizLogic.GoiHang().Select();
                Entities.HangHoa[] hanghoa = new BizLogic.HangHoa().Select();
                if (goi!=null)
                {
                    for (int k = 0; k < goi.Length; k++)
                    {
                        if (goi[k].MaGoiHang.ToUpper() == mahang.ToUpper())
                        {
                            data = new Entities.HienThi_ChiTiet_DonDatHang();
                            data.MaHangHoa = goi[k].MaGoiHang;
                            data.TenHangHoa = goi[k].TenGoiHang;
                            data.SoLuongDat = 1;
                            data.GiaGoc = goi[k].GiaNhap;
                            data.GiaNhap = goi[k].GiaNhap;
                            data.Giabanbuon = goi[k].GiaBanBuon;
                            data.Giabanle = goi[k].GiaBanLe;
                            data.PhanTramChietKhau = "0";
                            data.Thuegiatrigiatang = "0";
                            data.ChietKhau = "0";
                            break;
                        }
                    }
                }
                if (hanghoa!=null)
                {
                    for (int k = 0; k < hanghoa.Length; k++)
                    {
                        if (hanghoa[k].MaHangHoa.ToUpper() == mahang.ToUpper())
                        {
                            data = new Entities.HienThi_ChiTiet_DonDatHang();
                            data.MaHangHoa = hanghoa[k].MaHangHoa;
                            data.TenHangHoa = hanghoa[k].TenHangHoa;
                            data.SoLuongDat = 1;
                            data.GiaGoc = hanghoa[k].GiaNhap;
                            data.GiaNhap = hanghoa[k].GiaNhap;
                            data.Giabanbuon = hanghoa[k].GiaBanBuon;
                            data.Giabanle = hanghoa[k].GiaBanLe;
                            data.PhanTramChietKhau = "0";
                            data.Thuegiatrigiatang = Thue(hanghoa[k].MaThueGiaTriGiaTang);
                            data.ChietKhau = "0";
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                data = null;
            }
            return data;
        }
    }
}
