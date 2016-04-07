using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI
{
    public class Luu
    {
        /// <summary>
        /// Biến này để xác định chương trình hiện tại là Server hay Client
        /// </summary>
        public static string Server;
        public static string IP;
        public static int Ports;
        public static Server_Client.Server maychu;
        public static string BienTam;

        /////////////////MRK
        public static bool KFULL = false;
        public static List<string> GKOK = new List<string>();
        ////////////////////
    }
    public class GiaTriCanLuu
    {
        public static string Loaitrave;
        public static string Ma;
        public static string Ten;
        public static string Giatri;
        public static string Giatri2;
        public static string TonKho;
        public static string MaNhanVien;
        public static string giatrigiatang;
        public static string makhachhang;
        public static string mahanghoa;
    }
    public class TimBaoCao
    {
        public static string tenbaocao;
        public static string macongty;
        public static int dieukienloc;
        public static string ngaybatdau;
        public static string ngayketthuc;
        public static Boolean trangthaithanhtoan;
        public static string nam;
        public static string thang;
        public static Entities.ThongTinCongTy congty;
    }
}
