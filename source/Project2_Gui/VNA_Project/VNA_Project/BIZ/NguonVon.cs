using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;

namespace VNA_Project.BIZ
{
    public class NguonVonBiz
    {
        public NguonVonBiz() { }

        public static List<NguonVon> getListNguonVon()
        {
            List<NguonVon> kq = new List<NguonVon>();
            string sql = "SELECT [MaNguonVon],[TenNguonVon] FROM  [VNAAccounting].[dbo].[NguonVon]";
            System.Data.DataTable dt = DAL.CSDL.hienthi(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NguonVon temp = new NguonVon();
                temp.MaNguonVon = dt.Rows[i]["MaNguonVon"].ToString();
                temp.TenNguonVon = dt.Rows[i]["TenNguonVon"].ToString();
                kq.Add(temp);
            }
            return kq;
        }
    }
}
