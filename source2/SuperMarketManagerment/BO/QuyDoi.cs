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
    public class QuyDoi
    {
        private Constants.HoaDonNhap dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.HoaDonNhap cla;
        private SqlConnection cn;
        public QuyDoi()
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
        private string giabanbuon="0";
        private string giabanle="0";
        private string gianhap="0";
        private string thue = "0";
        private void HangHoa(string MaHangHoa)
        {
            try
            {
                Entities.HangHoa[] hanghoa = new BizLogic.HangHoa().Select();
                if (hanghoa!=null)
                {
                    for (int k = 0; k < hanghoa.Length; k++)
                    {
                        if (hanghoa[k].MaHangHoa == MaHangHoa)
                        {
                            thue = Thue(hanghoa[k].MaThueGiaTriGiaTang);
                            giabanbuon = hanghoa[k].GiaBanBuon;
                            giabanle = hanghoa[k].GiaBanLe;
                            gianhap = hanghoa[k].GiaNhap;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
    
            }
        }
        public Entities.HangHoaGoiHang Select(Entities.HangHoaGoiHang values)
        {
            Entities.HangHoaGoiHang data = null;
            try
            {
                Entities.QuyDoiDonViTinh[] quydoi = new BizLogic.QuyDoiDonViTinh().Select();
                if (quydoi!=null)
                {
                    for (int k = 0; k < quydoi.Length; k++)
                    {
                        if (quydoi[k].MaHangQuyDoi.ToUpper() == values.MaHang.ToUpper())
                        {
                            this.HangHoa(quydoi[k].MaHangDuocQuyDoi);
                            data = new Entities.HangHoaGoiHang();
                            data.TenHang = quydoi[k].TenHangDuocQuyDoi;
                            data.MaHang = quydoi[k].MaHangDuocQuyDoi;
                            data.SoLuong = quydoi[k].SoLuongDuocQuyDoi.ToString();
                            data.GiaNhap = this.gianhap;
                            data.GiaBanBuon = this.giabanbuon;
                            data.GiaBanLe = this.giabanle;
                            data.Thue = this.thue;
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
