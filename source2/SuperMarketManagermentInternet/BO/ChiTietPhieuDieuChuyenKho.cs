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
    public class ChiTietPhieuDieuChuyenKho
    {
        private Constants.ChiTietPhieuDieuChuyenKho ctpdck;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        public SqlDataReader dr;
        private SqlConnection cn;

        public ChiTietPhieuDieuChuyenKho()
        {
            ctpdck = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }


        public Entities.ChiTietPhieuDieuChuyenKho[] Select()
        {


            Entities.ChiTietPhieuDieuChuyenKho[] arrC = null;
            try
            {
                ctpdck = new Constants.ChiTietPhieuDieuChuyenKho();
                Sql = new Constants.Sql();
                string sql = Sql.SelectAllChiTietPhieuDieuChuyenKho;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietPhieuDieuChuyenKho CTphieudieuchuyen = new Entities.ChiTietPhieuDieuChuyenKho();
                    CTphieudieuchuyen.MaPhieuDieuChuyenKho = dr[ctpdck.MaPhieuDieuChuyenKho].ToString();
                    CTphieudieuchuyen.MaHangHoa = dr[ctpdck.MaHangHoa].ToString();
                    CTphieudieuchuyen.TenHangHoa = dr["TenHangHoa"].ToString();
                    CTphieudieuchuyen.SoLuong = int.Parse(dr[ctpdck.SoLuong].ToString());
                    CTphieudieuchuyen.GhiChu = dr[ctpdck.GhiChu].ToString();
                    CTphieudieuchuyen.Deleted = (Boolean)dr[ctpdck.Deleted];
                    arr.Add(CTphieudieuchuyen);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietPhieuDieuChuyenKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietPhieuDieuChuyenKho)arr[i];
                }
                for (int i = 0; i < n; i++)
                {
                    arrC[i].NgayHetHan = LayHSD(arrC[i].MaPhieuDieuChuyenKho,arrC[i].MaHangHoa);
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

        public Entities.ChiTietPhieuDieuChuyenKho[] SelectTheoMaPhieu(string maPDCK)
        {


            Entities.ChiTietPhieuDieuChuyenKho[] arrC = null;
            try
            {
                ctpdck = new Constants.ChiTietPhieuDieuChuyenKho();
               
                string sql = "";
                sql = "select * from ChiTietPhieuDieuChuyenKho where MaPhieuDieuChuyenKho='"+maPDCK+"' and Deleted=0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietPhieuDieuChuyenKho CTphieudieuchuyen = new Entities.ChiTietPhieuDieuChuyenKho();
                    CTphieudieuchuyen.MaPhieuDieuChuyenKho = dr[ctpdck.MaPhieuDieuChuyenKho].ToString();
                    CTphieudieuchuyen.MaHangHoa = dr[ctpdck.MaHangHoa].ToString();
                    CTphieudieuchuyen.SoLuong = int.Parse(dr[ctpdck.SoLuong].ToString());
                    CTphieudieuchuyen.GhiChu = dr[ctpdck.GhiChu].ToString();
                    CTphieudieuchuyen.Deleted = (Boolean)dr[ctpdck.Deleted];
                    arr.Add(CTphieudieuchuyen);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietPhieuDieuChuyenKho[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietPhieuDieuChuyenKho)arr[i];
                }
                for (int i = 0; i < n; i++)
                {
                    arrC[i].NgayHetHan = LayHSD(arrC[i].MaPhieuDieuChuyenKho, arrC[i].MaHangHoa);
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

        public DateTime LayHSD(string maPhieuDieuChuyen, string maHangHoa)
        {
            Entities.PhieuDieuChuyenKhoNoiBo[] pdck=new BizLogic.PhieuDieuChuyenKhoNoiBo().Select();
            string makho="";
            if (pdck!=null)
            {
                for (int i = 0; i < pdck.Length; i++)
                {
                    if (pdck[i].MaPhieuDieuChuyenKho ==maPhieuDieuChuyen)
                    {
                        makho = pdck[i].TuKho;
                        break;
                    }
                }
            }

            Entities.ChiTietKhoHangTheoHoaHonNhap[] khohang = new BizLogic.ChiTietKhoHangTheoHoaHonNhap().Select();
            for (int i = 0; i < khohang.Length; i++)
            {
                if (khohang[i].Makho==makho && khohang[i].Mahanghoa==maHangHoa)
                {
                    return khohang[i].Ngayhethan;
                }  
            }
            return new DateTime(2001,01,01);
        }

        public int InsertUpdate(Entities.ChiTietPhieuDieuChuyenKho CTPhieuDCK)
        {
            try
            {
                ctpdck = new Constants.ChiTietPhieuDieuChuyenKho();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateChiTietPhieuDieuChuyenKho;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ctpdck.HanhDong, SqlDbType.NVarChar, 20).Value = CTPhieuDCK.HanhDong;
                cmd.Parameters.Add(ctpdck.MaPhieuDieuChuyenKho, SqlDbType.NVarChar, 20).Value = CTPhieuDCK.MaPhieuDieuChuyenKho;
                cmd.Parameters.Add(ctpdck.MaHangHoa, SqlDbType.NVarChar, 50).Value = CTPhieuDCK.MaHangHoa;
                cmd.Parameters.Add(ctpdck.SoLuong, SqlDbType.Int).Value = CTPhieuDCK.SoLuong;
                cmd.Parameters.Add(ctpdck.GhiChu, SqlDbType.NVarChar, 100).Value = CTPhieuDCK.GhiChu;
                cmd.Parameters.Add(ctpdck.Deleted, SqlDbType.Bit).Value = CTPhieuDCK.Deleted;

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

        public int Delete(Entities.ChiTietPhieuDieuChuyenKho CTphieuDCK)
        {
            try
            {
                ctpdck = new Constants.ChiTietPhieuDieuChuyenKho();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteChiTietPhieuDieuChuyenKho;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(ctpdck.HanhDong, SqlDbType.NVarChar, 20).Value = CTphieuDCK.HanhDong;
                cmd.Parameters.Add(ctpdck.MaPhieuDieuChuyenKho, SqlDbType.VarChar,20).Value = CTphieuDCK.MaPhieuDieuChuyenKho;

               int i= cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return i;
            }
            catch (Exception ex) { string s = ex.Message; return 0; }
        }

    }
}
