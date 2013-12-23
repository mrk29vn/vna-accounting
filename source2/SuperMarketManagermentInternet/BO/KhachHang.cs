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
    public class KhachHang
    {
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.KhachHang kh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.KhachHang khachhang;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public KhachHang()
        {
            kh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khachhang = null;
            cn = null;
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.KhachHang[] Select()
        {
            List<Entities.KhachHang> arr = null;
            try
            {
                kh = new Constants.KhachHang();
                Sql = new Constants.Sql();
                string sql = Sql.SelectKhachHangsAll;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new List<Entities.KhachHang>();
                while (dr.Read())
                {
                    Entities.KhachHang khachhang = new Entities.KhachHang();
                    khachhang.KhachHangID = Convert.ToInt32(dr[kh.KhachHangID].ToString());
                    khachhang.MaKH = dr[kh.MaKH].ToString();
                    khachhang.Ten = dr[kh.Ten].ToString();
                    khachhang.DiaChi = dr[kh.DiaChi].ToString();
                    khachhang.DienThoai = dr[kh.DienThoai].ToString();
                    khachhang.Fax = dr[kh.Fax].ToString();
                    khachhang.Email = dr[kh.Email].ToString();
                    khachhang.MST = dr[kh.MST].ToString();
                    khachhang.DuNo = dr[kh.DuNo].ToString();
                    khachhang.HanMucTT = dr[kh.HanMucTT].ToString();
                    khachhang.CongTy = dr[kh.CongTy].ToString();
                    khachhang.NgaySinh = Convert.ToDateTime(dr[kh.NgaySinh].ToString());
                    khachhang.MaVung = Convert.ToInt32(dr[kh.MaVung].ToString());
                    khachhang.Mobi = dr[kh.Mobi].ToString();
                    //khachhang.NgayThamGia = Convert.ToDateTime(dr[kh.Ngaythamgia].ToString());
                    //khachhang.GiaoDichCuoi = Convert.ToDateTime(dr[kh.Giaodichcuoi].ToString());
                    khachhang.NgungTheoDoi = Convert.ToBoolean(dr[kh.Ngungtheodoi].ToString());
                    khachhang.Website = dr[kh.Website].ToString();
                    //khachhang.NgaySua = Convert.ToDateTime(dr[kh.Ngaysua].ToString());
                    khachhang.GhiChu = dr[kh.GhiChu].ToString();
                    khachhang.Deleted = Convert.ToBoolean(dr[kh.Deleted].ToString());
                    arr.Add(khachhang);
                }
                int n = arr.Count;
                if (n == 0)
                {
                    return null;
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

            return arr.ToArray();
        }

        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.KhachHang[] Select(string Cot, string Kieu, string Giatri)
        {

            Entities.KhachHang[] arrC = null;
            try
            {
                kh = new Constants.KhachHang();
                Sql = new Constants.Sql();
                string sql = "";
                if (Kieu == "like")
                    sql = "select * from KhachHang where " + Cot + " " + Kieu + " '%" + Giatri + "%'  and Deleted =0";
                else
                    sql = "select * from KhachHang where " + Cot + " " + Kieu + " '" + Giatri + "'  and Deleted =0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.KhachHang khachhang = new Entities.KhachHang();
                    khachhang.KhachHangID = Convert.ToInt32(dr[kh.KhachHangID].ToString());
                    khachhang.MaKH = dr[kh.MaKH].ToString();
                    khachhang.Ten = dr[kh.Ten].ToString();
                    khachhang.DiaChi = dr[kh.DiaChi].ToString();
                    khachhang.DienThoai = dr[kh.DienThoai].ToString();
                    khachhang.Fax = dr[kh.Fax].ToString();
                    khachhang.Email = dr[kh.Email].ToString();
                    khachhang.MST = dr[kh.MST].ToString();
                    khachhang.DuNo = dr[kh.DuNo].ToString();
                    khachhang.HanMucTT = dr[kh.HanMucTT].ToString();
                    khachhang.CongTy = dr[kh.CongTy].ToString();
                    khachhang.NgaySinh = Convert.ToDateTime(dr[kh.NgaySinh].ToString());
                    khachhang.MaVung = Convert.ToInt32(dr[kh.MaVung].ToString());
                    khachhang.Mobi = dr[kh.Mobi].ToString();
                    khachhang.NgayThamGia = Convert.ToDateTime(dr[kh.Ngaythamgia].ToString());
                    khachhang.GiaoDichCuoi = Convert.ToDateTime(dr[kh.Giaodichcuoi].ToString());
                    khachhang.NgungTheoDoi = Convert.ToBoolean(dr[kh.Ngungtheodoi].ToString());
                    khachhang.Website = dr[kh.Website].ToString();
                    khachhang.NgaySua = Convert.ToDateTime(dr[kh.Ngaysua].ToString());
                    khachhang.GhiChu = dr[kh.GhiChu].ToString();
                    khachhang.Deleted = Convert.ToBoolean(dr[kh.Deleted].ToString());
                    arr.Add(khachhang);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.KhachHang[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KhachHang)arr[i];
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


        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public int InsertUpdate(Entities.KhachHang kh1)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateKhachHang;
                conn = new Connection();
                kh = new Constants.KhachHang();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.KhachHangID, SqlDbType.Int).Value = kh1.KhachHangID;
                cmd.Parameters.Add(kh.MaKH, SqlDbType.NVarChar, 20).Value = kh1.MaKH;
                cmd.Parameters.Add(kh.Ten, SqlDbType.NVarChar, 200).Value = kh1.Ten;
                cmd.Parameters.Add(kh.DiaChi, SqlDbType.NVarChar, 200).Value = kh1.DiaChi;
                cmd.Parameters.Add(kh.DienThoai, SqlDbType.NVarChar, 20).Value = kh1.DienThoai;
                cmd.Parameters.Add(kh.Fax, SqlDbType.NVarChar, 20).Value = kh1.Fax;
                cmd.Parameters.Add(kh.Email, SqlDbType.NVarChar, 50).Value = kh1.Email;
                cmd.Parameters.Add(kh.MST, SqlDbType.NVarChar, 20).Value = kh1.MST;
                cmd.Parameters.Add(kh.DuNo, SqlDbType.Float).Value = kh1.DuNo;
                cmd.Parameters.Add(kh.HanMucTT, SqlDbType.Float).Value = kh1.HanMucTT;
                cmd.Parameters.Add(kh.CongTy, SqlDbType.NVarChar, 200).Value = kh1.CongTy;
                cmd.Parameters.Add(kh.NgaySinh, SqlDbType.DateTime).Value = kh1.NgaySinh.ToShortDateString();
                cmd.Parameters.Add(kh.MaVung, SqlDbType.Int).Value = kh1.MaVung;
                cmd.Parameters.Add(kh.Mobi, SqlDbType.NVarChar, 100).Value = kh1.Mobi;
                //cmd.Parameters.Add(kh.Ngaythamgia, SqlDbType.DateTime).Value = kh1.NgayThamGia.ToShortDateString();
                //cmd.Parameters.Add(kh.Giaodichcuoi, SqlDbType.DateTime).Value = kh1.GiaoDichCuoi.ToShortDateString();
                cmd.Parameters.Add(kh.Ngungtheodoi, SqlDbType.Bit).Value = kh1.NgungTheoDoi;
                cmd.Parameters.Add(kh.Website, SqlDbType.NVarChar, 200).Value = kh1.Website;
                //cmd.Parameters.Add(kh.Ngaysua, SqlDbType.DateTime).Value = kh1.NgaySua.ToShortDateString();
                cmd.Parameters.Add(kh.GhiChu, SqlDbType.NVarChar, 200).Value = kh1.GhiChu;
                cmd.Parameters.Add(kh.Deleted, SqlDbType.Bit).Value = kh1.Deleted;
                Trave = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }

        public bool Update(Entities.KhachHang kh1)
        {
            bool Trave = false;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.UpdateDuNo;
                conn = new Connection();
                kh = new Constants.KhachHang();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.MaKH, SqlDbType.NVarChar, 20).Value = kh1.MaKH;
                cmd.Parameters.Add(kh.DuNo, SqlDbType.Float).Value = kh1.DuNo;
                int i = cmd.ExecuteNonQuery();
                if (i == 1) Trave = true;
                else Trave = false;

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }

        public bool UpdateKH(Entities.KhachHang kh1)
        {
            bool Trave = false;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.UpdateDuNoKH;
                conn = new Connection();
                kh = new Constants.KhachHang();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.MaKH, SqlDbType.NVarChar, 20).Value = kh1.MaKH;
                cmd.Parameters.Add(kh.DuNo, SqlDbType.Float).Value = kh1.DuNo;
                int i = cmd.ExecuteNonQuery();
                if (i == 1) Trave = true;
                else Trave = false;

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }
        /// <summary>
        /// Delete Bảng
        /// </summary>
        public int Delete(Entities.KhachHang kh1)
        {
            int Trave = 0;
            try
            {
                kh = new Constants.KhachHang();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteKhachHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(kh.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
                cmd.Parameters.Add(kh.KhachHangID, SqlDbType.Int).Value = kh1.KhachHangID;
                Trave = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }
    }
}
