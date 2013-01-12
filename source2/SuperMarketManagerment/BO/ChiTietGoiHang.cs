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
    public class ChiTietGoiHang
    {
        private Constants.Sql.ChiTietGoiHang kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietGoiHang goihang;
        private SqlConnection cn;
        public ChiTietGoiHang()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        public Entities.ChiTietGoiHang[] Select()
        {
            Entities.ChiTietGoiHang[] list = null;
            try
            {
                string sql = Common.Constants.Sql.ChiTietGoiHang.SelectChiTietGoiHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietGoiHang row = new Entities.ChiTietGoiHang();
                    row.ChiTietGoiHangID = Convert.ToInt32(dr[Common.Constants.ChiTietGoiHang.ChiTietGoiHangID].ToString());
                    row.MaGoiHang = dr[Common.Constants.ChiTietGoiHang.MaGoiHang].ToString();
                    row.MaHangHoa = dr[Common.Constants.ChiTietGoiHang.MaHangHoa].ToString();
                    row.TenHangHoa = dr[Common.Constants.ChiTietGoiHang.TenHangHoa].ToString();
                    row.GiaNhap = dr[Common.Constants.ChiTietGoiHang.GiaNhap].ToString();
                    row.GiaBanBuon = dr[Common.Constants.ChiTietGoiHang.GiaBanBuon].ToString();
                    row.GiaBanLe = dr[Common.Constants.ChiTietGoiHang.GiaBanLe].ToString();
                    row.SoLuong = Convert.ToInt32(dr[Common.Constants.ChiTietGoiHang.SoLuong].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.ChiTietGoiHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.ChiTietGoiHang)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return list;
        }
        public int InsertUpdate(Entities.ChiTietGoiHang nhom)
        {
            int rt = 0;
            try
            {
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(Common.Constants.Sql.ChiTietGoiHang.InsertUpdateChiTietGoiHang, cn);
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.HanhDong, SqlDbType.NVarChar).Value = nhom.HanhDong;
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.ChiTietGoiHangID, SqlDbType.Int).Value = nhom.ChiTietGoiHangID;
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.MaGoiHang, SqlDbType.VarChar, 50).Value = nhom.MaGoiHang.ToUpper();
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.MaHangHoa, SqlDbType.NVarChar, 50).Value = nhom.MaHangHoa;
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.TenHangHoa, SqlDbType.NVarChar, 200).Value = nhom.TenHangHoa;
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.GiaNhap, SqlDbType.Float).Value = double.Parse(nhom.GiaNhap);
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.GiaBanBuon, SqlDbType.Float).Value = double.Parse(nhom.GiaBanBuon);
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.GiaBanLe, SqlDbType.Float).Value = double.Parse(nhom.GiaBanLe);
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.SoLuong, SqlDbType.Float).Value =double.Parse(nhom.SoLuong.ToString());
                rt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); rt = 0; }
            return rt;
        }
        public int InsertUpdate(Entities.ChiTietGoiHang[] chitietgoihang)
        {
            try
            {
                foreach (Entities.ChiTietGoiHang item in chitietgoihang)
                {
                    if (InsertUpdate(item) == 0)
                    {
                        return 0;
                    }
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        // Delete
        public int Delete(Entities.ChiTietGoiHang chitietgoihang)
        {
            int rt = 0;
            try
            {
                string sql = Common.Constants.Sql.ChiTietGoiHang.DeleteChiTietGoiHang;
                conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                //  cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.HanhDong, SqlDbType.NVarChar, 20).Value = chitietgoihang.HanhDong;
                cmd.Parameters.Add(Common.Constants.ChiTietGoiHang.MaGoiHang, SqlDbType.VarChar, 50).Value = chitietgoihang.MaGoiHang;
                rt = cmd.ExecuteNonQuery();
                return rt;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); return 0; }
        }
    }
}
