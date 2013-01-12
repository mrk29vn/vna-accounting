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
  public  class TheoHangHoa
    {
       /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.TheoHangHoa thh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.TheoHangHoa theohanghoa;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public TheoHangHoa()
        {
            thh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            theohanghoa = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.TheoHangHoa[] Select()
        {

            Entities.TheoHangHoa[] arrC = null;
            try
            {
                thh = new Constants.TheoHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.TheoHangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    theohanghoa = new Entities.TheoHangHoa();
                    theohanghoa.MaHangHoa = dr[thh.MaHangHoa].ToString();
                    theohanghoa.NgayBatDau = Convert.ToDateTime(dr[thh.NgayBatDau].ToString());
                    theohanghoa.NgayKetThuc =Convert.ToDateTime( dr[thh.NgayKetThuc].ToString());
                    theohanghoa.GiaBanBuon = dr[thh.GiaBanBuon].ToString();
                    theohanghoa.GiaBanLe = dr[thh.GiaBanLe].ToString();
                    theohanghoa.GhiChu = dr[thh.GhiChu].ToString();
                    arr.Add(theohanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TheoHangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TheoHangHoa)arr[i];
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
    }
}
