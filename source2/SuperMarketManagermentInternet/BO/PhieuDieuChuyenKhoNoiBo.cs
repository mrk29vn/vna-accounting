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
    public class PhieuDieuChuyenKhoNoiBo
    {
        private Constants.PhieuDieuChuyenKhoNoiBo pdcknb;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        public SqlDataReader dr;
        private SqlConnection cn;

        public PhieuDieuChuyenKhoNoiBo()
        {
            pdcknb = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }


        public Entities.PhieuDieuChuyenKhoNoiBo[] Select()
        {


            Entities.PhieuDieuChuyenKhoNoiBo[] arrC = null;
            try
            {
                pdcknb = new Constants.PhieuDieuChuyenKhoNoiBo();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllPhieuDieuChuyenKhoNoiBo;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.PhieuDieuChuyenKhoNoiBo phieudieuchuyen = new Entities.PhieuDieuChuyenKhoNoiBo();
                    phieudieuchuyen.PhieuDieuChuyenKhoID = Convert.ToInt32(dr[pdcknb.PhieuDieuChuyenKhoID].ToString());
                    phieudieuchuyen.MaPhieuDieuChuyenKho = dr[pdcknb.MaPhieuDieuChuyenKho].ToString();
                    phieudieuchuyen.NgayDieuChuyen = Convert.ToDateTime(dr[pdcknb.NgayDieuChuyen]);
                    phieudieuchuyen.TuKho = dr[pdcknb.TuKho].ToString();
                    phieudieuchuyen.DenKho = dr[pdcknb.DenKho].ToString();
                    phieudieuchuyen.MaHoaDonNhap = dr[pdcknb.MaHoaDonNhap].ToString();
                    phieudieuchuyen.XacNhan =(bool) dr[pdcknb.XacNhan];
                    phieudieuchuyen.GhiChu = dr[pdcknb.GhiChu].ToString();
                    phieudieuchuyen.Deleted = (Boolean)dr[pdcknb.Deleted];
                    arr.Add(phieudieuchuyen);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.PhieuDieuChuyenKhoNoiBo[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.PhieuDieuChuyenKhoNoiBo)arr[i];
                }
                for (int i = 0; i < n; i++)
                {
                    arrC[i].TenKhoDi = LayTenKho(arrC[i].TuKho);
                    arrC[i].TenKhoDen = LayTenKho(arrC[i].DenKho);
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

        public string LayTenKho(string maKho)
        {
            Entities.KhoHang [] kh=(Entities.KhoHang []) new BizLogic.KhoHang().sp_SelectKhoHangsAll();

            for (int i = 0; i < kh.Length; i++)
            {
                if (kh[i].MaKho==maKho)
                {
                    return kh[i].TenKho;
                }
            }
            return "";
        }

        public Entities.PhieuDieuChuyenKhoNoiBo[] SelectTheoMaKho(string MaKho)
        {


            Entities.PhieuDieuChuyenKhoNoiBo[] arrC = null;
            try
            {
                pdcknb = new Constants.PhieuDieuChuyenKhoNoiBo();
                string sql = "";
                sql = "Select * from PhieuDieuChuyenKho where TuKho='" + MaKho + "' and deleted =0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.PhieuDieuChuyenKhoNoiBo phieudieuchuyen = new Entities.PhieuDieuChuyenKhoNoiBo();
                    phieudieuchuyen.PhieuDieuChuyenKhoID = Convert.ToInt32(dr[pdcknb.PhieuDieuChuyenKhoID].ToString());
                    phieudieuchuyen.MaPhieuDieuChuyenKho = dr[pdcknb.MaPhieuDieuChuyenKho].ToString();
                    phieudieuchuyen.NgayDieuChuyen = Convert.ToDateTime(dr[pdcknb.NgayDieuChuyen]);
                    phieudieuchuyen.TuKho = dr[pdcknb.TuKho].ToString();
                    phieudieuchuyen.DenKho = dr[pdcknb.DenKho].ToString();
                    phieudieuchuyen.MaHoaDonNhap = dr[pdcknb.MaHoaDonNhap].ToString();
                    phieudieuchuyen.XacNhan = (bool)dr[pdcknb.XacNhan];
                    phieudieuchuyen.GhiChu = dr[pdcknb.GhiChu].ToString();
                    phieudieuchuyen.Deleted = (Boolean)dr[pdcknb.Deleted];
                    arr.Add(phieudieuchuyen);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.PhieuDieuChuyenKhoNoiBo[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.PhieuDieuChuyenKhoNoiBo)arr[i];
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

        public int InsertUpdate(Entities.PhieuDieuChuyenKhoNoiBo PhieuDCK)
        {
            try
            {
                pdcknb = new Constants.PhieuDieuChuyenKhoNoiBo();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdatePhieuDieuChuyenKhoNoiBo;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pdcknb.HanhDong, SqlDbType.NVarChar, 20).Value = PhieuDCK.HanhDong;
                cmd.Parameters.Add(pdcknb.PhieuDieuChuyenKhoID, SqlDbType.Int).Value = PhieuDCK.PhieuDieuChuyenKhoID;
                cmd.Parameters.Add(pdcknb.MaPhieuDieuChuyenKho, SqlDbType.NVarChar, 20).Value = PhieuDCK.MaPhieuDieuChuyenKho;
                cmd.Parameters.Add(pdcknb.NgayDieuChuyen, SqlDbType.DateTime).Value = PhieuDCK.NgayDieuChuyen;
                cmd.Parameters.Add(pdcknb.TuKho, SqlDbType.VarChar, 20).Value = PhieuDCK.TuKho;
                cmd.Parameters.Add(pdcknb.DenKho, SqlDbType.VarChar, 20).Value = PhieuDCK.DenKho;
                cmd.Parameters.Add(pdcknb.MaHoaDonNhap, SqlDbType.VarChar, 20).Value = PhieuDCK.MaHoaDonNhap;
                cmd.Parameters.Add(pdcknb.XacNhan, SqlDbType.Bit).Value = PhieuDCK.XacNhan;
                cmd.Parameters.Add(pdcknb.GhiChu, SqlDbType.NVarChar, 100).Value = PhieuDCK.GhiChu;
                cmd.Parameters.Add(pdcknb.Deleted, SqlDbType.Bit).Value = PhieuDCK.Deleted;

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

        public void Delete(Entities.PhieuDieuChuyenKhoNoiBo phieuDCK)
        {
            try
            {
                pdcknb = new Constants.PhieuDieuChuyenKhoNoiBo();
                Sql = new Constants.Sql();
                string sql = Sql.DeletePhieuDieuChuyenKhoNoiBo;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pdcknb.HanhDong, SqlDbType.NVarChar, 20).Value = phieuDCK.HanhDong;
                cmd.Parameters.Add(pdcknb.PhieuDieuChuyenKhoID, SqlDbType.Int).Value = phieuDCK.PhieuDieuChuyenKhoID;

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
