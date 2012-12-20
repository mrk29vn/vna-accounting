using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class ThoiKhauHaoTaiSanBiz
    {
        public ThoiKhauHaoTaiSanBiz() { }

        public static List<ThoiKhauHaoTaiSan> getListThoiKhauHaoTaiSan()
        {
            return getListThoiKhauHaoTaiSan(string.Empty, 0);
        }
        public static List<ThoiKhauHaoTaiSan> getListThoiKhauHaoTaiSan(string MaTaiSan)
        {
            return getListThoiKhauHaoTaiSan(MaTaiSan, 1);
        }
        public static List<ThoiKhauHaoTaiSan> getListThoiKhauHaoTaiSan(string MaTaiSan, int select)
        {
            List<ThoiKhauHaoTaiSan> kq = new List<ThoiKhauHaoTaiSan>();
            string sql = string.Empty;
            if (select == 0) sql = "SELECT [ThoiKhauHaoTaiSanID],[MaThoiKhauHaoTaiSan],[MaTaiSan],[NgayThoiKhauHao] FROM [VNAAccounting].[dbo].[ThoiKhauHaoTaiSan]";
            else if (select == 1) sql = "SELECT [ThoiKhauHaoTaiSanID],[MaThoiKhauHaoTaiSan],[MaTaiSan],[NgayThoiKhauHao] FROM [VNAAccounting].[dbo].[ThoiKhauHaoTaiSan] WHERE MaTaiSan = '" + MaTaiSan + "'";

            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThoiKhauHaoTaiSan temp = new ThoiKhauHaoTaiSan();
                temp.ThoiKhauHaoTaiSanID = int.Parse(dt.Rows[i]["ThoiKhauHaoTaiSanID"].ToString());
                temp.MaThoiKhauHaoTaiSan = dt.Rows[i]["MaThoiKhauHaoTaiSan"].ToString();
                temp.MaTaiSan = dt.Rows[i]["MaTaiSan"].ToString();
                temp.NgayThoiKhauHao = DateTime.Parse(dt.Rows[i]["NgayThoiKhauHao"].ToString());
                kq.Add(temp);
            }
            return kq;
        }

        public static int AddThoiKhauHaoTaiSan(ThoiKhauHaoTaiSan input)
        {
            string sql = "INSERT INTO [VNAAccounting].[dbo].[ThoiKhauHaoTaiSan]([MaThoiKhauHaoTaiSan],[MaTaiSan],[NgayThoiKhauHao]) VALUES(N'" + input.MaThoiKhauHaoTaiSan.ToUpper() + "',N'" + input.MaTaiSan.ToUpper() + "','" + input.NgayThoiKhauHao.ToString("MM/dd/yyyyy") + "')";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int EditThoiKhauHaoTaiSan(ThoiKhauHaoTaiSan input)
        {
            string sql = "UPDATE [VNAAccounting].[dbo].[ThoiKhauHaoTaiSan] SET MaThoiKhauHaoTaiSan =N'" + input.MaThoiKhauHaoTaiSan.ToUpper() + "',MaTaiSan = N'" + input.MaTaiSan.ToUpper() + "',NgayThoiKhauHao = '" + input.NgayThoiKhauHao.ToString("MM/dd/yyyy") + "' WHERE ThoiKhauHaoTaiSanID = '" + input.ThoiKhauHaoTaiSanID + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }

        public static int DeleteThoiKhauHaoTaiSan(ThoiKhauHaoTaiSan input)
        {
            string sql = "DELETE FROM [VNAAccounting].[dbo].[ThoiKhauHaoTaiSan] WHERE ThoiKhauHaoTaiSanID = N'" + input.ThoiKhauHaoTaiSanID + "'";
            return DAL.CSDL.ThemSuaXoa(sql);
        }
    }
}
