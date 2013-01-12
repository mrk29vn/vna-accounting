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
    public class HienThi_ChiTiet_DonDatHang
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.HienThi_ChiTiet_DonDatHang dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.HienThi_ChiTiet_DonDatHang hienthi;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public HienThi_ChiTiet_DonDatHang()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hienthi = null;
            cn = null;
            ar = new ArrayList();
        }
        #endregion

        ArrayList ar;

        public bool KiemTraHangHoa(Entities.ChiTietDonDatHang chitietdonhang)
        {
            bool kiemtra = false;
            Entities.HangHoa[] hh = new BizLogic.HangHoa().Select();
            for (int i = 0; i < hh.Length; i++)
            {
                if (hh[i].MaHangHoa == chitietdonhang.MaHangHoa)
                {
                    Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                    row.MaHangHoa = chitietdonhang.MaHangHoa;
                    row.TenHangHoa = hh[i].TenHangHoa;
                    row.SoLuongDat = chitietdonhang.SoLuong;
                    row.GiaGoc = chitietdonhang.DonGia;
                    row.Giabanbuon = hh[i].GiaBanBuon;
                    row.Giabanle = hh[i].GiaBanLe;
                    row.PhanTramChietKhau = chitietdonhang.PhanTramChietKhau;
                    row.Thuegiatrigiatang = chitietdonhang.Thue;
                    ar.Add(row);
                    kiemtra = true;
                    break;
                }

            }
            return kiemtra;
        }
        public string LayThue(string mathue)
        {
            string a = "0";
            Entities.Thue[] goihang = new BizLogic.Thue().Select();
            for (int i = 0; i < goihang.Length; i++)
            {
                if (goihang[i].MaThue == mathue)
                {
                    a = goihang[i].GiaTriThue;
                    break;
                }

            }
            return a;
        }
        public bool KiemTraGoiHang(Entities.ChiTietDonDatHang chitietdonhang)
        {
            bool kiemtra = false;
            Entities.GoiHang[] goihang = new BizLogic.GoiHang().Select();
            for (int i = 0; i < goihang.Length; i++)
            {
                if (goihang[i].MaGoiHang == chitietdonhang.MaHangHoa)
                {
                    Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                    row.MaHangHoa = chitietdonhang.MaHangHoa;
                    row.TenHangHoa = goihang[i].TenGoiHang;
                    row.SoLuongDat = chitietdonhang.SoLuong;
                    row.GiaGoc = chitietdonhang.DonGia;
                    row.Giabanbuon = goihang[i].GiaBanBuon;
                    row.Giabanle = goihang[i].GiaBanLe;
                    row.PhanTramChietKhau = chitietdonhang.PhanTramChietKhau;
                    row.Thuegiatrigiatang = "0";
                    ar.Add(row);
                    kiemtra = true;
                    break;
                }

            }
            return kiemtra;
        }

        public Entities.HienThi_ChiTiet_DonDatHang[] SelectChiTietDonHang(string madonhang)
        {
            Entities.HienThi_ChiTiet_DonDatHang[] dh2 = null;
            Entities.ChiTietDonDatHang[] donhang = new BizLogic.ChiTietDonDatHang().sp_LayBang_ChiTietDonDatHang();
            for (int i = 0; i < donhang.Length; i++)
            {
                if (donhang[i].MaDonDatHang == madonhang)
                {
                    this.KiemTraHangHoa(donhang[i]);
                    this.KiemTraGoiHang(donhang[i]);
                }

            }
            int n = ar.Count;
            if (n == 0) { dh2 = null; }
            dh2 = new Entities.HienThi_ChiTiet_DonDatHang[n];
            for (int i = 0; i < n; i++)
            {
                dh2[i] = (Entities.HienThi_ChiTiet_DonDatHang)ar[i];
            }
            return dh2;
        }
        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.HienThi_ChiTiet_DonDatHang[] sp_LayBang_ThongTinDonDatHang(Entities.TruyenGiaTri giatri)
        {
            Entities.HienThi_ChiTiet_DonDatHang[] arrC = null;
            try
            {
                arrC = this.SelectChiTietDonHang(giatri.Giatritruyen);
                //dh = new Constants.HienThi_ChiTiet_DonDatHang();
                //Sql = new Constants.Sql();
                //string sql = Sql.sp_LayBang_ThongTinDonDatHang;
                //conn = new Connection();
                //cn = conn.openConnection();
                //cmd = new SqlCommand(sql, cn);
                //cmd.Parameters.Add(dh.MaDonDatHang, SqlDbType.NVarChar, 20).Value = giatri.Giatritruyen;
                //dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //arr = new ArrayList();
                //while (dr.Read())
                //{
                //    hienthi = new Entities.HienThi_ChiTiet_DonDatHang();
                //    hienthi.MaHangHoa = dr[0].ToString();
                //    hienthi.TenHangHoa = dr[1].ToString();
                //    hienthi.SoLuongDat = int.Parse(0+dr[2].ToString());
                //    hienthi.GiaGoc = Double.Parse(0+dr[3].ToString()).ToString();
                //    hienthi.Giabanbuon = Double.Parse(0 + dr[4].ToString()).ToString();
                //    hienthi.Giabanle = Double.Parse(0+dr[5].ToString()).ToString();
                //    hienthi.PhanTramChietKhau = Double.Parse(0 + dr[6].ToString()).ToString();
                //    hienthi.Thuegiatrigiatang = Double.Parse(0 + dr[7].ToString()).ToString();
                //    arr.Add(hienthi);
                //}
                //int n = arr.Count;
                //if (n == 0) { arrC= null; }
                //arrC = new Entities.HienThi_ChiTiet_DonDatHang[n];
                //for (int i = 0; i < n; i++)
                //{
                //    arrC[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
                //}
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); arrC = null; }
            //finally
            //{
            //    cmd.Connection.Dispose();
            //    cn.Close();
            //    conn.closeConnection();
            //}
            return arrC;
        }
        /// <summary>
        /// lay hang hóa theo ma hang hoa
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.HienThi_ChiTiet_DonDatHang sp_LayHangHoaTheoMaHangHoa(Entities.HienThi_ChiTiet_DonDatHang giatri)
        {
            Entities.HienThi_ChiTiet_DonDatHang data = null;
            try
            {
                data = new BizLogic.HangHoaGoiHang().Select(giatri.MaHangHoa);
                //string sql = "exec sp_LayHangHoaTheoMaHangHoa @MaHangHoa";
                //conn = new Connection();
                //cn = conn.openConnection();
                //cmd = new SqlCommand(sql, cn);
                //cmd.Parameters.Add("MaHangHoa", SqlDbType.NVarChar, 50).Value = giatri.MaHangHoa;
                //dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //while (dr.Read())
                //{
                //    data.MaHangHoa = dr[0].ToString();
                //    data.TenHangHoa = dr[1].ToString();
                //    data.SoLuongDat = 1;
                //    data.GiaGoc = dr[2].ToString();
                //    data.GiaNhap = dr[2].ToString();
                //    data.Giabanbuon = dr[3].ToString();
                //    data.Giabanle = dr[4].ToString();
                //    data.PhanTramChietKhau = "0";
                //    data.Thuegiatrigiatang = dr[5].ToString();
                //    data.ChietKhau = "0";
                //}
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); data = null; }
            return data;
        }
        #endregion
    }
}
