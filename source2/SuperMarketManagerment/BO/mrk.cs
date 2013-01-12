using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace BizLogic
{
    public class mrk
    {
        public mrk() { }
    }

    public class KhachHang_k
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public KhachHang_k() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        #region Thao Tác
        //============Thêm Sửa Xóa===================================================
        public int ThaoTac_KhachHang(string thaotac, Entities.KhachHang_k set, Entities.KhachHang_k filter)
        {
            int bg = 0;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_KhachHang_MRK @ThaoTac,@MaKH,@Ten,@DiaChi,@DienThoai,@Fax,@Email,@MST,@DuNo,@HanMucTT,@CongTy,@NgaySinh,@MaVung,@Mobi,@NgayThamGia,@GiaoDichCuoi,@NgungTheoDoi,@Website,@NgaySua,@GhiChu,@Deleted,@MaKHk,@Tenk,@DiaChik,@DienThoaik,@Faxk,@Emailk,@MSTk,@DuNok,@HanMucTTk,@CongTyk,@NgaySinhk,@MaVungk,@Mobik,@NgayThamGiak,@GiaoDichCuoik,@NgungTheoDoik,@Websitek,@NgaySuak,@GhiChuk,@Deletedk", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = thaotac;
                //set
                cmd.Parameters.Add("MaKH", SqlDbType.NVarChar).Value = set.MaKH;
                cmd.Parameters.Add("Ten", SqlDbType.NVarChar).Value = set.Ten;
                cmd.Parameters.Add("DiaChi", SqlDbType.NVarChar).Value = set.DiaChi;
                cmd.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = set.DienThoai;
                cmd.Parameters.Add("Fax", SqlDbType.NVarChar).Value = set.Fax;
                cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = set.Email;
                cmd.Parameters.Add("MST", SqlDbType.NVarChar).Value = set.MST;
                cmd.Parameters.Add("DuNo", SqlDbType.Float).Value = set.DuNo;
                cmd.Parameters.Add("HanMucTT", SqlDbType.Float).Value = set.HanMucTT;
                cmd.Parameters.Add("CongTy", SqlDbType.NVarChar).Value = set.CongTy;
                cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime).Value = set.NgaySinh;
                cmd.Parameters.Add("MaVung", SqlDbType.Int).Value = set.MaVung;
                cmd.Parameters.Add("Mobi", SqlDbType.NVarChar).Value = set.Mobi;
                cmd.Parameters.Add("NgayThamGia", SqlDbType.DateTime).Value = set.NgayThamGia;
                cmd.Parameters.Add("GiaoDichCuoi", SqlDbType.DateTime).Value = set.GiaoDichCuoi;
                cmd.Parameters.Add("NgungTheoDoi", SqlDbType.Bit).Value = set.NgungTheoDoi;
                cmd.Parameters.Add("Website", SqlDbType.VarChar).Value = set.Website;
                cmd.Parameters.Add("NgaySua", SqlDbType.DateTime).Value = set.NgaySua;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = set.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = set.Deleted;
                //filter
                cmd.Parameters.Add("MaKHk", SqlDbType.NVarChar).Value = filter.MaKH;
                cmd.Parameters.Add("Tenk", SqlDbType.NVarChar).Value = filter.Ten;
                cmd.Parameters.Add("DiaChik", SqlDbType.NVarChar).Value = filter.DiaChi;
                cmd.Parameters.Add("DienThoaik", SqlDbType.NVarChar).Value = filter.DienThoai;
                cmd.Parameters.Add("Faxk", SqlDbType.NVarChar).Value = filter.Fax;
                cmd.Parameters.Add("Emailk", SqlDbType.NVarChar).Value = filter.Email;
                cmd.Parameters.Add("MSTk", SqlDbType.NVarChar).Value = filter.MST;
                cmd.Parameters.Add("DuNok", SqlDbType.Float).Value = filter.DuNo;
                cmd.Parameters.Add("HanMucTTk", SqlDbType.Float).Value = filter.HanMucTT;
                cmd.Parameters.Add("CongTyk", SqlDbType.NVarChar).Value = filter.CongTy;
                cmd.Parameters.Add("NgaySinhk", SqlDbType.DateTime).Value = filter.NgaySinh;
                cmd.Parameters.Add("MaVungk", SqlDbType.Int).Value = filter.MaVung;
                cmd.Parameters.Add("Mobik", SqlDbType.NVarChar).Value = filter.Mobi;
                cmd.Parameters.Add("NgayThamGiak", SqlDbType.DateTime).Value = filter.NgayThamGia;
                cmd.Parameters.Add("GiaoDichCuoik", SqlDbType.DateTime).Value = filter.GiaoDichCuoi;
                cmd.Parameters.Add("NgungTheoDoik", SqlDbType.Bit).Value = filter.NgungTheoDoi;
                cmd.Parameters.Add("Websitek", SqlDbType.VarChar).Value = filter.Website;
                cmd.Parameters.Add("NgaySuak", SqlDbType.DateTime).Value = filter.NgaySua;
                cmd.Parameters.Add("GhiChuk", SqlDbType.NVarChar).Value = filter.GhiChu;
                cmd.Parameters.Add("Deletedk", SqlDbType.Bit).Value = filter.Deleted;
                bg = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                bg = 0;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();
            }
            if (bg == 0)
                return bg;
            return bg;
        }

        //==============Select========================
        public Entities.KhachHang_k[] SelectTheoDieuKien_KhachHang(string thaotac, Entities.KhachHang_k set, Entities.KhachHang_k filter)
        {
            Entities.KhachHang_k[] list = null;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_KhachHang_MRK @ThaoTac,@MaKH,@Ten,@DiaChi,@DienThoai,@Fax,@Email,@MST,@DuNo,@HanMucTT,@CongTy,@NgaySinh,@MaVung,@Mobi,@NgayThamGia,@GiaoDichCuoi,@NgungTheoDoi,@Website,@NgaySua,@GhiChu,@Deleted,@MaKHk,@Tenk,@DiaChik,@DienThoaik,@Faxk,@Emailk,@MSTk,@DuNok,@HanMucTTk,@CongTyk,@NgaySinhk,@MaVungk,@Mobik,@NgayThamGiak,@GiaoDichCuoik,@NgungTheoDoik,@Websitek,@NgaySuak,@GhiChuk,@Deletedk", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = thaotac;
                //set
                cmd.Parameters.Add("MaKH", SqlDbType.NVarChar).Value = set.MaKH;
                cmd.Parameters.Add("Ten", SqlDbType.NVarChar).Value = set.Ten;
                cmd.Parameters.Add("DiaChi", SqlDbType.NVarChar).Value = set.DiaChi;
                cmd.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = set.DienThoai;
                cmd.Parameters.Add("Fax", SqlDbType.NVarChar).Value = set.Fax;
                cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = set.Email;
                cmd.Parameters.Add("MST", SqlDbType.NVarChar).Value = set.MST;
                cmd.Parameters.Add("DuNo", SqlDbType.Float).Value = set.DuNo;
                cmd.Parameters.Add("HanMucTT", SqlDbType.Float).Value = set.HanMucTT;
                cmd.Parameters.Add("CongTy", SqlDbType.NVarChar).Value = set.CongTy;
                cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime).Value = set.NgaySinh;
                cmd.Parameters.Add("MaVung", SqlDbType.Int).Value = set.MaVung;
                cmd.Parameters.Add("Mobi", SqlDbType.NVarChar).Value = set.Mobi;
                cmd.Parameters.Add("NgayThamGia", SqlDbType.DateTime).Value = set.NgayThamGia;
                cmd.Parameters.Add("GiaoDichCuoi", SqlDbType.DateTime).Value = set.GiaoDichCuoi;
                cmd.Parameters.Add("NgungTheoDoi", SqlDbType.Bit).Value = set.NgungTheoDoi;
                cmd.Parameters.Add("Website", SqlDbType.VarChar).Value = set.Website;
                cmd.Parameters.Add("NgaySua", SqlDbType.DateTime).Value = set.NgaySua;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = set.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = set.Deleted;
                //filter
                cmd.Parameters.Add("MaKHk", SqlDbType.NVarChar).Value = filter.MaKH;
                cmd.Parameters.Add("Tenk", SqlDbType.NVarChar).Value = filter.Ten;
                cmd.Parameters.Add("DiaChik", SqlDbType.NVarChar).Value = filter.DiaChi;
                cmd.Parameters.Add("DienThoaik", SqlDbType.NVarChar).Value = filter.DienThoai;
                cmd.Parameters.Add("Faxk", SqlDbType.NVarChar).Value = filter.Fax;
                cmd.Parameters.Add("Emailk", SqlDbType.NVarChar).Value = filter.Email;
                cmd.Parameters.Add("MSTk", SqlDbType.NVarChar).Value = filter.MST;
                cmd.Parameters.Add("DuNok", SqlDbType.Float).Value = filter.DuNo;
                cmd.Parameters.Add("HanMucTTk", SqlDbType.Float).Value = filter.HanMucTT;
                cmd.Parameters.Add("CongTyk", SqlDbType.NVarChar).Value = filter.CongTy;
                cmd.Parameters.Add("NgaySinhk", SqlDbType.DateTime).Value = filter.NgaySinh;
                cmd.Parameters.Add("MaVungk", SqlDbType.Int).Value = filter.MaVung;
                cmd.Parameters.Add("Mobik", SqlDbType.NVarChar).Value = filter.Mobi;
                cmd.Parameters.Add("NgayThamGiak", SqlDbType.DateTime).Value = filter.NgayThamGia;
                cmd.Parameters.Add("GiaoDichCuoik", SqlDbType.DateTime).Value = filter.GiaoDichCuoi;
                cmd.Parameters.Add("NgungTheoDoik", SqlDbType.Bit).Value = filter.NgungTheoDoi;
                cmd.Parameters.Add("Websitek", SqlDbType.VarChar).Value = filter.Website;
                cmd.Parameters.Add("NgaySuak", SqlDbType.DateTime).Value = filter.NgaySua;
                cmd.Parameters.Add("GhiChuk", SqlDbType.NVarChar).Value = filter.GhiChu;
                cmd.Parameters.Add("Deletedk", SqlDbType.Bit).Value = filter.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.KhachHang_k row = new Entities.KhachHang_k();
                    row.MaKH = dr["MaKH"].ToString();
                    row.Ten = dr["Ten"].ToString();
                    row.DiaChi = dr["DiaChi"].ToString();
                    row.DienThoai = dr["DienThoai"].ToString();
                    row.Fax = dr["Fax"].ToString();
                    row.Email = dr["Email"].ToString();
                    row.MST = dr["MST"].ToString();
                    row.DuNo = float.Parse(dr["DuNo"].ToString());
                    row.HanMucTT = float.Parse(dr["HanMucTT"].ToString());
                    row.CongTy = dr["CongTy"].ToString();
                    row.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                    row.MaVung = int.Parse(dr["MaVung"].ToString());
                    row.Mobi = dr["Mobi"].ToString();
                    row.NgayThamGia = DateTime.Parse(dr["NgayThamGia"].ToString());
                    row.GiaoDichCuoi = DateTime.Parse(dr["GiaoDichCuoi"].ToString());
                    row.NgungTheoDoi = bool.Parse(dr["NgungTheoDoi"].ToString());
                    row.Website = dr["Website"].ToString();
                    row.NgaySua = DateTime.Parse(dr["NgaySua"].ToString());
                    row.GhiChu = dr["GhiChu"].ToString();
                    row.Deleted = bool.Parse(dr["Deleted"].ToString());
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) list = null;
                list = new Entities.KhachHang_k[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.KhachHang_k)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); list = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();
            }
            return list;
        }
        //======================================================================================================
        #endregion
    }

    public class UpdateDuNo
    {
        private Connection con;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        public UpdateDuNo() 
        {
            con = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }

        #region Thao Tác
        //============Thêm Sửa Xóa===================================================
        public int ThaoTac_UpdateDuNo(Entities.UpdateDuNoK29 k)
        {
            int bg = 0;
            try
            {
                con = new Connection();
                cn = con.openConnection();
                cmd = new SqlCommand("exec sp_UpdateDuNo_K29 @ThaoTac,@MaNhaCungCap,@MaKH,@SoLuong", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = k.ThaoTac;
                cmd.Parameters.Add("MaNhaCungCap", SqlDbType.VarChar).Value = k.MaNhaCungCap;
                cmd.Parameters.Add("MaKH", SqlDbType.VarChar).Value = k.MaKH;
                cmd.Parameters.Add("SoLuong", SqlDbType.Float).Value = k.SoLuong;
                bg = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                bg = 0;
            }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                con.closeConnection();
            }
            if (bg == 0)
                return bg;
            return bg;
        }
    #endregion
    }
}
