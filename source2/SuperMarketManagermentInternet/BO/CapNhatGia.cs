using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace BizLogic
{
    public class CapNhatGia
    {
        private Constants.CapNhatGia cng;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.CapNhatGia capnhatgia;
        private SqlConnection cn;

        public CapNhatGia()
        {
            cng = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            capnhatgia = null;
            cn = null;
        }

        public Entities.CapNhatGia[] Select()
        {
            Entities.CapNhatGia[] arrC = null;
            try
            {
                cng = new Constants.CapNhatGia();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllCapNhatGia;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    capnhatgia = new Entities.CapNhatGia();
                    capnhatgia.CapNhatGiaID = Convert.ToInt32(dr[cng.CapNhatGiaID].ToString());
                    capnhatgia.MaCapNhatGia = dr[cng.MaCapNhatGia].ToString();
                    capnhatgia.NgayBatDau = Convert.ToDateTime(dr[cng.NgayBatDau].ToString());
                    capnhatgia.NgayKetThuc = Convert.ToDateTime(dr[cng.NgayKetThuc]);
                    capnhatgia.MaHangHoa = dr[cng.MaHangHoa].ToString();
                    capnhatgia.PhanTramGiaBanBuon =( dr[cng.PhanTramGiaBanBuon].ToString());
                    capnhatgia.PhanTramGiaBanLe = ( dr[cng.PhanTramGiaBanLe].ToString());
                    capnhatgia.GiaNhap = ( dr[cng.GiaNhap].ToString());
                    capnhatgia.Trangthai = (Boolean)dr[cng.Trangthai];
                    capnhatgia.GhiChu = dr[cng.GhiChu].ToString();
                    capnhatgia.Deleted = (Boolean)dr[cng.Deleted];
                    arr.Add(capnhatgia);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.CapNhatGia[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.CapNhatGia)arr[i];
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
        public int InsertUpdate(Entities.CapNhatGia cng1)
        {
            cng = new Constants.CapNhatGia();
            Sql = new Constants.Sql();
            string sql = Sql.InsertUpdateCapNhatGia;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(cng.HanhDong, SqlDbType.NVarChar, 20).Value = cng1.HanhDong;
            cmd.Parameters.Add(cng.CapNhatGiaID, SqlDbType.Int).Value = cng1.CapNhatGiaID;
            cmd.Parameters.Add(cng.MaCapNhatGia, SqlDbType.NVarChar, 20).Value = cng1.MaCapNhatGia;
            cmd.Parameters.Add(cng.NgayBatDau, SqlDbType.DateTime).Value = cng1.NgayBatDau;
            cmd.Parameters.Add(cng.NgayKetThuc, SqlDbType.DateTime).Value = cng1.NgayKetThuc;
            cmd.Parameters.Add(cng.MaHangHoa, SqlDbType.NVarChar,20).Value = cng1.MaHangHoa;
            cmd.Parameters.Add(cng.PhanTramGiaBanBuon, SqlDbType.Float).Value = cng1.PhanTramGiaBanBuon;
            cmd.Parameters.Add(cng.PhanTramGiaBanLe, SqlDbType.Float).Value = cng1.PhanTramGiaBanLe;
            cmd.Parameters.Add(cng.GiaNhap, SqlDbType.Float).Value = cng1.GiaNhap;
            cmd.Parameters.Add(cng.Trangthai, SqlDbType.Bit).Value = cng1.Trangthai;
            cmd.Parameters.Add(cng.GhiChu, SqlDbType.NVarChar, 100).Value = cng1.GhiChu;
            cmd.Parameters.Add(cng.Deleted, SqlDbType.Bit).Value = cng1.Deleted;

            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return i;
        }

        //delete
        public void Delete(Entities.CapNhatGia kh1)
        {
            cng = new Constants.CapNhatGia();
            Entities.CapNhatGia capnhatgia = new Entities.CapNhatGia();
            Sql = new Constants.Sql();
            string sql = Sql.DeleteKhoHang;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(cng.HanhDong, SqlDbType.NVarChar, 20).Value = kh1.HanhDong;
            cmd.Parameters.Add(cng.CapNhatGiaID, SqlDbType.Int).Value = kh1.CapNhatGiaID;

            cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
        }
    }
}
