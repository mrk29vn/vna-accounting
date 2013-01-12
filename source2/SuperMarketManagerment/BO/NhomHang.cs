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
    public class NhomHang
    {
        private Constants.NhomHangHoa nhh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.NhomHang nhomhanghoa;
        private SqlConnection cn;

        public NhomHang()
        {
            nhh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            nhomhanghoa = null;
            cn = null;
        }
        Entities.LoaiHangHoa[] lhh;
        public void SelectLH()
        {
            lhh = new BizLogic.LoaiHangHoa().sp_SelectLoaiHangHoasAll();
            if (lhh == null)
            {
                lhh = new Entities.LoaiHangHoa[0];
            }
        }
        public string TimTenLoaiHH(string maLoaiHangHoa)
        {
            for (int i = 0; i < lhh.Length; i++)
            {
                if (lhh[i].MaLoaiHang == maLoaiHangHoa)
                {
                    return lhh[i].TenLoaiHang;
                }
            }
            return "";
        }
        //Entities
        public Entities.NhomHang[] sp_SelectNhomHangsAll()
        {
            SelectLH();
            Entities.NhomHang[] arrC = null;
            try
            {
                nhh = new Constants.NhomHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllNhomHangHoa;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    nhomhanghoa = new Entities.NhomHang();
                    nhomhanghoa.NhomHangID = Convert.ToInt32(dr[nhh.NhomHangID].ToString());
                    nhomhanghoa.MaNhomHang = dr[nhh.MaNhomHang].ToString();
                    nhomhanghoa.MaLoaiHang = dr[nhh.MaLoaiHang].ToString();
                    nhomhanghoa.TenLoaiHang = TimTenLoaiHH(nhomhanghoa.MaLoaiHang);
                    nhomhanghoa.TenNhomHang = dr[nhh.TenNhomHang].ToString();
                    nhomhanghoa.GhiChu = dr[nhh.GhiChu].ToString();
                    nhomhanghoa.Deleted = (Boolean)dr[nhh.Deleted];
                    arr.Add(nhomhanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhomHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhomHang)arr[i];
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

        public Entities.NhomHang[] Select()
        {
            SelectLH();
            Entities.NhomHang[] arrC = null;
            try
            {
                nhh = new Constants.NhomHangHoa();
                Sql = new Constants.Sql();
                string sql = "Select * from NhomHang where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    nhomhanghoa = new Entities.NhomHang();
                    nhomhanghoa.NhomHangID = Convert.ToInt32(dr[nhh.NhomHangID].ToString());
                    nhomhanghoa.MaNhomHang = dr[nhh.MaNhomHang].ToString();
                    nhomhanghoa.MaLoaiHang = dr[nhh.MaLoaiHang].ToString();
                    nhomhanghoa.TenLoaiHang = TimTenLoaiHH(nhomhanghoa.MaLoaiHang);
                    nhomhanghoa.TenNhomHang = dr[nhh.TenNhomHang].ToString();
                    nhomhanghoa.GhiChu = dr[nhh.GhiChu].ToString();
                    nhomhanghoa.Deleted = (Boolean)dr[nhh.Deleted];
                    arr.Add(nhomhanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhomHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhomHang)arr[i];
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

        //insert update
        public bool InsertUpdate(Entities.NhomHang nh)
        {

            bool kt = false;
            try
            {
                nhh = new Constants.NhomHangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateNhomHangHoa;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(nhh.HanhDong, SqlDbType.NVarChar, 20).Value = nh.HanhDong;
                cmd.Parameters.Add(nhh.NhomHangID, SqlDbType.Int).Value = nh.NhomHangID;
                cmd.Parameters.Add(nhh.MaNhomHang, SqlDbType.VarChar, 20).Value = nh.MaNhomHang;
                cmd.Parameters.Add(nhh.MaLoaiHang, SqlDbType.VarChar, 20).Value = nh.MaLoaiHang;
                cmd.Parameters.Add(nhh.TenNhomHang, SqlDbType.NVarChar, 200).Value = nh.TenNhomHang;
                cmd.Parameters.Add(nhh.GhiChu, SqlDbType.NVarChar, 100).Value = nh.GhiChu;
                cmd.Parameters.Add(nhh.Deleted, SqlDbType.Bit).Value = nh.Deleted;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    kt = true;
                }
                else
                {
                    kt = false;
                }
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch
            {
                return kt;
            }

        }
        //delete
        public bool Delete(Entities.NhomHang NhomHang)
        {
            bool kt = false;
            try
            {
                nhh = new Constants.NhomHangHoa();
                Entities.NhomHang nhomhanghoa = new Entities.NhomHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteNhomHangHoa;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(nhh.HanhDong, SqlDbType.NVarChar, 20).Value = NhomHang.HanhDong;
                cmd.Parameters.Add(nhh.NhomHangID, SqlDbType.Int).Value = NhomHang.NhomHangID;

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    kt = true;
                else
                    kt = false;
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return kt;
            }
            catch
            {
                return kt;
            }
        }

    }
}
