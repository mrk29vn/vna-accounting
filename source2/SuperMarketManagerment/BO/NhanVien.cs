using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAL;
using Common;
using Entities;
using System.Collections;

namespace BizLogic
{
    public class NhanVien
    {
        private Constants.NhanVien nv;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        public SqlDataReader dr;
        private SqlConnection cn;

        public NhanVien()
        {
            nv = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }


        public Entities.NhanVien[] Select()
        {


            Entities.NhanVien[] arrC = null;
            try
            {
                nv = new Constants.NhanVien();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllNhanVien;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.NhanVien nhanvien = new Entities.NhanVien();
                    nhanvien.NhanVienID = Convert.ToInt32(dr[nv.NhanVienID].ToString());
                    nhanvien.MaNhanVien = dr[nv.MaNhanVien].ToString();
                    nhanvien.TenNhanVien = dr[nv.TenNhanVien].ToString();
                    nhanvien.DCThuongTru = dr[nv.DCThuongTru].ToString();
                    nhanvien.DCTamTru = dr[nv.DCTamTru].ToString();
                    nhanvien.DienThoaiCD = dr[nv.DienThoaiCD].ToString();
                    nhanvien.DienThoaiDD = dr[nv.DienThoaiDD].ToString();
                    nhanvien.Email = dr[nv.Email].ToString();
                    nhanvien.CMND = dr[nv.CMND].ToString();
                    nhanvien.NgayCap = Convert.ToDateTime(dr[nv.NgayCap]);
                    nhanvien.NoiCap = (string)dr[nv.NoiCap];
                    nhanvien.NgaySinh = Convert.ToDateTime(dr[nv.NgaySinh]);
                    nhanvien.MaPhongBan = dr[nv.MaPhongBan].ToString();
                    nhanvien.GhiChu = dr[nv.GhiChu].ToString();
                    nhanvien.Deleted = (Boolean)dr[nv.Deleted];
                    arr.Add(nhanvien);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhanVien[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhanVien)arr[i];
                }

                for (int i = 0; i < n; i++)
                {
                    arrC[i].TenPhongBan = LayTenPhongBan(arrC[i].MaPhongBan);
                }
            }

            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;

        }

        public string LayTenPhongBan(string maPhongBan)
        {
            Entities.PhongBan[] pb = (Entities.PhongBan[])new BizLogic.PhongBan().Select();
            for (int i = 0; i < pb.Length; i++)
            {
                if (pb[i].MaPhongBan==maPhongBan)
                {
                    return pb[i].TenPhongBan;
                }
            }
            return "";
        }

        public Entities.NhanVien[] Select(string Cot, string Kieu, string Giatri)
        {


            Entities.NhanVien[] arrC = null;
            try
            {
                nv = new Constants.NhanVien();
                Sql = new Constants.Sql();
                string sql = "";
                if (Kieu == "like")
                    sql = "select * from NhanVien where " + Cot + " " + Kieu + " '%" + Giatri + "%' and Deleted =0";
                else
                    sql = "select * from NhanVien where " + Cot + " " + Kieu + " '" + Giatri + "' and Deleted =0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.NhanVien nhanvien = new Entities.NhanVien();
                    nhanvien.NhanVienID = Convert.ToInt32(dr[nv.NhanVienID].ToString());
                    nhanvien.MaNhanVien = dr[nv.MaNhanVien].ToString();
                    nhanvien.TenNhanVien = dr[nv.TenNhanVien].ToString();
                    nhanvien.DCThuongTru = dr[nv.DCThuongTru].ToString();
                    nhanvien.DCTamTru = dr[nv.DCTamTru].ToString();
                    nhanvien.DienThoaiCD = dr[nv.DienThoaiCD].ToString();
                    nhanvien.DienThoaiDD = dr[nv.DienThoaiDD].ToString();
                    nhanvien.Email = dr[nv.Email].ToString();
                    nhanvien.CMND = dr[nv.CMND].ToString();
                    nhanvien.NgayCap = Convert.ToDateTime(dr[nv.NgayCap]);
                    nhanvien.NoiCap = (string)dr[nv.NoiCap];
                    nhanvien.NgaySinh = Convert.ToDateTime(dr[nv.NgaySinh]);
                    nhanvien.MaPhongBan = dr[nv.MaPhongBan].ToString();
                    nhanvien.GhiChu = dr[nv.GhiChu].ToString();
                    nhanvien.Deleted = (Boolean)dr[nv.Deleted];
                    arr.Add(nhanvien);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.NhanVien[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.NhanVien)arr[i];
                }
            }

            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;

        }

        public int InsertUpdate(Entities.NhanVien nv1)
        {
            try
            {
                nv = new Constants.NhanVien();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateNhanVien;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(nv.HanhDong, SqlDbType.NVarChar, 20).Value = nv1.HanhDong;
                cmd.Parameters.Add(nv.NhanVienID, SqlDbType.Int).Value = nv1.NhanVienID;
                cmd.Parameters.Add(nv.MaNhanVien, SqlDbType.NVarChar, 20).Value = nv1.MaNhanVien;
                cmd.Parameters.Add(nv.TenNhanVien, SqlDbType.NVarChar, 200).Value = nv1.TenNhanVien;
                cmd.Parameters.Add(nv.MaPhongBan, SqlDbType.VarChar, 20).Value = nv1.MaPhongBan;
                cmd.Parameters.Add(nv.DCThuongTru, SqlDbType.NVarChar, 200).Value = nv1.DCThuongTru;
                cmd.Parameters.Add(nv.DCTamTru, SqlDbType.NVarChar, 200).Value = nv1.DCTamTru;
                cmd.Parameters.Add(nv.DienThoaiCD, SqlDbType.NVarChar, 20).Value = nv1.DienThoaiCD;
                cmd.Parameters.Add(nv.DienThoaiDD, SqlDbType.NVarChar, 20).Value = nv1.DienThoaiDD;
                cmd.Parameters.Add(nv.Email, SqlDbType.NVarChar, 20).Value = nv1.Email;
                cmd.Parameters.Add(nv.CMND, SqlDbType.NVarChar, 200).Value = nv1.CMND;
                cmd.Parameters.Add(nv.NgayCap, SqlDbType.DateTime).Value = nv1.NgayCap;
                cmd.Parameters.Add(nv.NoiCap, SqlDbType.NVarChar, 200).Value = nv1.NoiCap;
                cmd.Parameters.Add(nv.NgaySinh, SqlDbType.DateTime).Value = nv1.NgaySinh;
                cmd.Parameters.Add(nv.GhiChu, SqlDbType.NVarChar, 100).Value = nv1.GhiChu;
                cmd.Parameters.Add(nv.Deleted, SqlDbType.Bit).Value = nv1.Deleted;

                int i = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return i;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return 0;
            }

        }

        public void Delete(Entities.NhanVien nv1)
        {
            try
            {
                nv = new Constants.NhanVien();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteNhanVien;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(nv.HanhDong, SqlDbType.NVarChar, 20).Value = nv1.HanhDong;
                cmd.Parameters.Add(nv.NhanVienID, SqlDbType.Int).Value = nv1.NhanVienID;

                cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
            }
            catch (Exception ex) { string s = ex.Message; }
        }
    }


}
