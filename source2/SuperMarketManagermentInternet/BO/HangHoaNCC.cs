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
    public class HangHoaNCC
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.HangHoaNCC lsgd;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.HangHoaNCC lichsugiaodich;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public HangHoaNCC()
        {
            lsgd = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            lichsugiaodich = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.HangHoaNCC[] Select(Entities.HangHoaNCC ct)
        {

            Entities.HangHoaNCC[] arrC = null;
            try
            {
                lsgd = new Constants.HangHoaNCC();
                Sql = new Constants.Sql();
                string sql = Sql.LSGDHangHoaNCC;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(lsgd.MaNhaCungCap, SqlDbType.NVarChar, 20).Value = ct.MaNhaCungCap;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    lichsugiaodich = new Entities.HangHoaNCC();
                    lichsugiaodich.MaNhaCungCap = dr[0].ToString();
                    lichsugiaodich.MaHangHoa = dr[1].ToString();
                    lichsugiaodich.TenHangHoa = dr[2].ToString();
                    lichsugiaodich.MaDonViTinh = dr[3].ToString();
                    lichsugiaodich.SoLuong = Convert.ToInt32(dr[4].ToString());
                    lichsugiaodich.ThueGTGT = dr[5].ToString();
                    lichsugiaodich.TongTien = dr[6].ToString();
                    arr.Add(lichsugiaodich);
                    lichsugiaodich = null;

                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.HangHoaNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HangHoaNCC)arr[i];
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
