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
    public class ChiTietKhoHangTheoHoaHonNhap
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietKhoHangTheoHoaHonNhap hoadonnhap;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietKhoHangTheoHoaHonNhap()
        {
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hoadonnhap = null;
            cn = null;
        }
        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        /// 

        public Entities.ChiTietKhoHangTheoHoaHonNhap[] Select()
        {


            Entities.ChiTietKhoHangTheoHoaHonNhap[] arrC = null;
            try
            {

                Sql = new Constants.Sql();
                string sql = Sql.SelectAllChiTietKhoHang;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietKhoHangTheoHoaHonNhap ctkho = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                    ctkho.Makho = dr["MaKho"].ToString();
                    ctkho.Mahanghoa = dr["MaHangHoa"].ToString();
                    ctkho.Soluong = Convert.ToInt32(dr["SoLuong"].ToString());
                    ctkho.Ngaynhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    ctkho.Ngayhethan = DateTime.Parse(dr["HanSuDung"].ToString());
                    ctkho.Ghichu = dr["GhiChu"].ToString();
                    arr.Add(ctkho);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietKhoHangTheoHoaHonNhap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKhoHangTheoHoaHonNhap)arr[i];
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
        public int LuuLai(Entities.ChiTietKhoHangTheoHoaHonNhap[] ddh)
        {
            int tra = 0;
            List<int> error = new List<int>();
            try
            {
                for (int i = 0; i < ddh.Length; i++)
                {
                    Entities.ChiTietKhoHangTheoHoaHonNhap tl = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                    tl.Hanhdong = ddh[i].Hanhdong;
                    tl.Makho = ddh[i].Makho;
                    tl.Mahanghoa = ddh[i].Mahanghoa;
                    tl.Soluong = ddh[i].Soluong;
                    tl.Ngaynhap = ddh[i].Ngaynhap;
                    tl.Ngayhethan = ddh[i].Ngayhethan;
                    tl.Ghichu = ddh[i].Ghichu;
                    tl.Deleted = ddh[i].Deleted;
                    tl.Gia = ddh[i].Gia;
                    int _return = sp_XuLy_ChiTietHoaDonNhapKho(tl);
                    if (_return == 0)
                    {
                        error.Add(i);
                    }
                }
                if (error.Count == 0)
                {
                    tra = 1;    //Không có lỗi gì
                }
                else
                {
                    if (error.Count < ddh.Length)
                    {
                        tra = -1;   //Có một số lỗi
                    }
                }
            }
            catch { tra = 0; }
            return tra;
        }
        public int sp_XuLy_ChiTietHoaDonNhapKho(Entities.ChiTietKhoHangTheoHoaHonNhap dh)
        {
            int Trave = 0;
            try
            {
                string sql = "exec sp_XuLy_ChiTietHoaDonNhapKhoHangFIX @HanhDong,@MaKho,@MaHangHoa,@SoLuong,@NgayNhap,	@HanSuDung,@GhiChu,@Deleted,@Gia";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("HanhDong", SqlDbType.VarChar, 20).Value = dh.Hanhdong;
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = dh.Makho;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar).Value = dh.Mahanghoa;
                cmd.Parameters.Add("SoLuong", SqlDbType.Int).Value = dh.Soluong;
                cmd.Parameters.Add("NgayNhap", SqlDbType.DateTime).Value = dh.Ngaynhap;
                cmd.Parameters.Add("HanSuDung", SqlDbType.DateTime).Value = dh.Ngayhethan;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = dh.Ghichu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = dh.Deleted;
                cmd.Parameters.Add("Gia", SqlDbType.Float).Value = dh.Gia;
                Trave = cmd.ExecuteNonQuery();
            }
            catch { Trave = 0; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return Trave;
        }

        public int TruSoLuong(Entities.ChiTietKhoHangTheoHoaHonNhap dh)
        {
            int Trave = 0;
            try
            {
                string sql = "exec sp_TruSoLuong @MaKho,@MaHangHoa,@SoLuong";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = dh.Makho;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = dh.Mahanghoa;
                cmd.Parameters.Add("SoLuong", SqlDbType.Int).Value = dh.Soluong;
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

        public int CongSoLuong(Entities.ChiTietKhoHangTheoHoaHonNhap dh)
        {
            int Trave = 0;
            try
            {
                string sql = "exec sp_CongSoLuong_CHITIETKHOHANG_k29 @MaKho,@MaHangHoa,@SoLuong";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = dh.Makho;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = dh.Mahanghoa;
                cmd.Parameters.Add("SoLuong", SqlDbType.Int).Value = dh.Soluong;
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

        public int CongSoLuong(Entities.ChiTietKiemKeKho ctKiemKe)
        {
            int Trave = 0;
            try
            {
                string sql = "exec sp_CongSoLuong_CHITIETKHOHANG_k29 @MaKho,@MaHangHoa,@SoLuong";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaKho", SqlDbType.VarChar, 20).Value = ctKiemKe.MaKho;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar, 50).Value = ctKiemKe.MaHangHoa;
                int slChengLech = int.Parse(ctKiemKe.TonThucTe) - int.Parse(ctKiemKe.TonSoSach);
                cmd.Parameters.Add("SoLuong", SqlDbType.Int).Value = slChengLech;
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

        public int KiemTraLaySoLuongTrongKho(string maKho, string maHangHoa)
        {
            int sl = 0;
            Entities.ChiTietKhoHangTheoHoaHonNhap[] dh = Select();
            for (int j = 0; j < dh.Length; j++)
            {
                if (dh[j].Makho == maKho && dh[j].Mahanghoa == maHangHoa)
                {
                    return dh[j].Soluong;
                }
            }
            return sl;
        }
        public int TruSoLuong(Entities.ChiTietKhoHangTheoHoaHonNhap[] dh)
        {
            try
            {
                for (int i = 0; i < dh.Length; i++)
                {
                    if (dh[i].Mahanghoa != "")
                    {
                        TruSoLuong(dh[i]);
                    }
                }
            }
            catch
            {
                return 0;
            }
            return 1;
        }

        #endregion

        public int CongSoLuong(Entities.ChiTietKhoHangTheoHoaHonNhap[] dh)
        {
            try
            {
                for (int i = 0; i < dh.Length; i++)
                {
                    if (dh[i].Mahanghoa != "")
                    {
                        int tem0 = KiemTraLaySoLuongTrongKho(dh[i].Makho, dh[i].Mahanghoa);
                        int soluongupdate = dh[i].Soluong;
                        Entities.ChiTietKhoHangTheoHoaHonNhap dh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap(" ", dh[i].Makho, dh[i].Mahanghoa, soluongupdate);
                        CongSoLuong(dh1);
                    }
                }
            }
            catch
            {
                return 0;
            }
            return 1;
        }
        public Entities.ChiTietKhoHangTheoHoaHonNhap[] SelectTheoMaKho(String MaKho)
        {
            Entities.ChiTietKhoHangTheoHoaHonNhap[] arrC = null;
            try
            {
                string sql = "";
                sql = "Select * from ChiTietKhoHang where MaKho ='" + MaKho + "' and Deleted=0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ChiTietKhoHangTheoHoaHonNhap ctkho = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                    ctkho.Makho = dr["MaKho"].ToString();
                    ctkho.Mahanghoa = dr["MaHangHoa"].ToString();
                    ctkho.Soluong = Convert.ToInt32(dr["SoLuong"].ToString());
                    ctkho.Ngaynhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    ctkho.Ngayhethan = DateTime.Parse(dr["HanSuDung"].ToString());
                    ctkho.Ghichu = dr["GhiChu"].ToString();
                    arr.Add(ctkho);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietKhoHangTheoHoaHonNhap[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKhoHangTheoHoaHonNhap)arr[i];
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

        /// <summary>
        /// Select tat ca hang hoa trong kho
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietKhoHang[] SelectAll()
        {
            List<Entities.ChiTietKhoHang> arrC = new List<ChiTietKhoHang>();
            try
            {
                string sql = "";
                sql = "Select b.MaKho, b.MaHangHoa, a.TenHangHoa, b.NgayNhap,b.HanSuDung,b.SoLuong,b.GhiChu from HangHoa a join ChiTietKhoHang b on a.MaHangHoa=b.MaHangHoa where b.Deleted='false'";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Entities.ChiTietKhoHang ctkho = new Entities.ChiTietKhoHang();
                    ctkho.MaKho = dr["MaKho"].ToString();
                    ctkho.MaHangHoa = dr["MaHangHoa"].ToString();
                    ctkho.TenHangHoa = dr["TenHangHoa"].ToString();
                    ctkho.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());
                    ctkho.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    ctkho.HanSuDung = DateTime.Parse(dr["HanSuDung"].ToString());
                    ctkho.GhiChu = dr["GhiChu"].ToString();
                    arrC.Add(ctkho);
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

            return arrC.ToArray();

        }
    }
}
