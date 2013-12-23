using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;

namespace BizLogic
{
    public class BCHDBanHang
    {
        Constants.BCHDBanLe dtttg;
        Constants.BCHDBanBuon hdbb;
        Constants.Sql Sql;

        public Entities.BCHDBanLe[] Select(Entities.BCHDBanLe bchdbl)
        {
            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            Entities.ChiTietHDBanHang chitiet = new Entities.ChiTietHDBanHang();
            chitiet.MaHDBanHang = bchdbl.MaHDBanHang;
            Entities.ChiTietHDBanHang[] chitiethdbanhang = new BizLogic.ChiTietHDBanHang().Select(chitiet);
            foreach (Entities.ChiTietHDBanHang ite in chitiethdbanhang)
            {
                Entities.BCHDBanLe bcdttg1 = new Entities.BCHDBanLe();
                bcdttg1.MaHDBanHang = ite.MaHDBanHang;
                bcdttg1.TenHangHoa = ite.TenHangHoa;
                bcdttg1.SoLuong = ite.SoLuong;
                bcdttg1.GiaBanLe = double.Parse(ite.DonGia);
                bcdttg1.Thue = double.Parse(ite.Thue);
                bcdttg1.ChietKhau = double.Parse(ite.PhanTramChietKhau.ToString());
                bcdttg1.TongTienThanhToan = bcdttg1.SoLuong * bcdttg1.GiaBanLe;
                arr.Add(bcdttg1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCHDBanLe[] arrC = new Entities.BCHDBanLe[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCHDBanLe)arr[i];
            }

            return arrC;
        }

        public Entities.BCHDBanBuon[] Select(Entities.BCHDBanBuon bchdbl)
        {

            //Insert Category into ArrayList
            ArrayList arr = new ArrayList();
            Entities.ChiTietHDBanHang chitiet = new Entities.ChiTietHDBanHang();
            chitiet.MaHDBanHang = bchdbl.MaHDBanHang;
            Entities.ChiTietHDBanHang[] chitiethdbanhang = new BizLogic.ChiTietHDBanHang().Select(chitiet);

            foreach (Entities.ChiTietHDBanHang ite in chitiethdbanhang)
            {
                Entities.BCHDBanBuon bcdttg1 = new Entities.BCHDBanBuon();
                bcdttg1.MaHDBanHang = ite.MaHDBanHang;
                bcdttg1.TenHangHoa = ite.TenHangHoa;
                bcdttg1.SoLuong = ite.SoLuong;
                bcdttg1.GiaBanBuon = int.Parse(ite.DonGia);
                bcdttg1.ChietKhau = ite.PhanTramChietKhau.ToString();
                bcdttg1.Thue = ite.Thue;
                bcdttg1.TongTienThanhToan = bcdttg1.SoLuong * bcdttg1.GiaBanBuon;
                arr.Add(bcdttg1);
            }
            int n = arr.Count;
            if (n == 0) return null;

            Entities.BCHDBanBuon[] arrC = new Entities.BCHDBanBuon[n];
            for (int i = 0; i < n; i++)
            {
                arrC[i] = (Entities.BCHDBanBuon)arr[i];
            }

            return arrC;
        }
    }
}
