using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;
using DAL;

namespace BizLogic
{
    public class HangHoa
    {
        private Constants.HangHoa hh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.HangHoa hanghoa;
        private SqlConnection cn;

        public HangHoa()
        {
            hh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            hanghoa = null;
            cn = null;
        }
        //Entities
        public Entities.HangHoa[] sp_SelectHangHoasAll(Entities.HangHoa input)
        {
            List<Entities.HangHoa> l = new List<Entities.HangHoa>();
            try
            {
                cn = new Connection().openConnection();
                cmd = new SqlCommand("exec sp_HangHoaFIX @ThaoTac,@MaHangHoa,@MaNhomHangHoa,@TenHangHoa,@MaDonViTinh,@GiaNhap,@GiaBanBuon,@GiaBanLe,@MaThueGiaTriGiaTang,@KieuHangHoa,@SeriLo,@MucDatHang,@MucTonToiThieu,@GhiChu,@Deleted", cn);
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = input.ThaoTac;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar).Value = input.MaHangHoa;
                cmd.Parameters.Add("MaNhomHangHoa", SqlDbType.NVarChar).Value = input.MaNhomHangHoa;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar).Value = input.TenHangHoa;
                cmd.Parameters.Add("MaDonViTinh", SqlDbType.NVarChar).Value = input.MaDonViTinh;
                cmd.Parameters.Add("GiaNhap", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("GiaBanBuon", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("GiaBanLe", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("MaThueGiaTriGiaTang", SqlDbType.NVarChar).Value = input.MaThueGiaTriGiaTang;
                cmd.Parameters.Add("KieuHangHoa", SqlDbType.NVarChar).Value = input.KieuHangHoa;
                cmd.Parameters.Add("SeriLo", SqlDbType.NVarChar).Value = input.SeriLo;
                cmd.Parameters.Add("MucDatHang", SqlDbType.NVarChar).Value = input.MucDatHang;
                cmd.Parameters.Add("MucTonToiThieu", SqlDbType.NVarChar).Value = input.MucTonToiThieu;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = input.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = input.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    hanghoa = new Entities.HangHoa();
                    hanghoa.HangHoaID = int.Parse(dr[Constants.HangHoaSTATIC.HangHoaID].ToString());
                    hanghoa.MaHangHoa = dr[Constants.HangHoaSTATIC.MaHangHoa].ToString();
                    hanghoa.MaNhomHangHoa = dr[Constants.HangHoaSTATIC.MaNhomHangHoa].ToString();
                    hanghoa.TenHangHoa = dr[Constants.HangHoaSTATIC.TenHangHoa].ToString();
                    hanghoa.MaDonViTinh = dr[Constants.HangHoaSTATIC.MaDonViTinh].ToString();
                    hanghoa.TenDonViTinh = dr[Constants.HangHoaSTATIC.TenDonViTinh].ToString();
                    hanghoa.GiaNhap = dr[Constants.HangHoaSTATIC.GiaNhap].ToString();
                    hanghoa.GiaBanBuon = dr[Constants.HangHoaSTATIC.GiaBanBuon].ToString();
                    hanghoa.GiaBanLe = dr[Constants.HangHoaSTATIC.GiaBanLe].ToString();
                    hanghoa.MaThueGiaTriGiaTang = dr[Constants.HangHoaSTATIC.MaThueGiaTriGiaTang].ToString();
                    hanghoa.KieuHangHoa = dr[Constants.HangHoaSTATIC.KieuHangHoa].ToString();
                    hanghoa.SeriLo = dr[Constants.HangHoaSTATIC.SeriLo].ToString();
                    hanghoa.MucDatHang = Convert.ToInt32(dr[Constants.HangHoaSTATIC.MucDatHang].ToString());
                    hanghoa.MucTonToiThieu = Convert.ToInt32(dr[Constants.HangHoaSTATIC.MucTonToiThieu].ToString());
                    hanghoa.GhiChu = dr[Constants.HangHoaSTATIC.GhiChu].ToString();
                    l.Add(hanghoa);
                }
            }
            catch { return null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
            }
            return l.ToArray();
        }

        public Entities.HangHoa[] SelectHHTheoKho(string maKho)
        {
            List<Entities.HangHoa> l = new List<Entities.HangHoa>();
            try
            {
                cn = new Connection().openConnection();
                cmd = new SqlCommand("exec sp_HangHoaFIX @ThaoTac,@MaHangHoa,@MaNhomHangHoa,@TenHangHoa,@MaDonViTinh,@GiaNhap,@GiaBanBuon,@GiaBanLe,@MaThueGiaTriGiaTang,@KieuHangHoa,@SeriLo,@MucDatHang,@MucTonToiThieu,@GhiChu,@Deleted", cn);
                Entities.HangHoa input = new Entities.HangHoa();
                input.ThaoTac = "select_TheoKho";
                input.GhiChu = maKho;
                cmd.Parameters.Add("ThaoTac", SqlDbType.NVarChar).Value = input.ThaoTac;
                cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar).Value = input.MaHangHoa;
                cmd.Parameters.Add("MaNhomHangHoa", SqlDbType.NVarChar).Value = input.MaNhomHangHoa;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar).Value = input.TenHangHoa;
                cmd.Parameters.Add("MaDonViTinh", SqlDbType.NVarChar).Value = input.MaDonViTinh;
                cmd.Parameters.Add("GiaNhap", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("GiaBanBuon", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("GiaBanLe", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("MaThueGiaTriGiaTang", SqlDbType.NVarChar).Value = input.MaThueGiaTriGiaTang;
                cmd.Parameters.Add("KieuHangHoa", SqlDbType.NVarChar).Value = input.KieuHangHoa;
                cmd.Parameters.Add("SeriLo", SqlDbType.NVarChar).Value = input.SeriLo;
                cmd.Parameters.Add("MucDatHang", SqlDbType.NVarChar).Value = input.MucDatHang;
                cmd.Parameters.Add("MucTonToiThieu", SqlDbType.NVarChar).Value = input.MucTonToiThieu;
                cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = input.GhiChu;
                cmd.Parameters.Add("Deleted", SqlDbType.Bit).Value = input.Deleted;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    hanghoa = new Entities.HangHoa();
                    hanghoa.MaHangHoa = dr[Constants.HangHoaSTATIC.MaHangHoa].ToString();
                    hanghoa.MaNhomHangHoa = dr[Constants.HangHoaSTATIC.MaNhomHangHoa].ToString();
                    hanghoa.TenHangHoa = dr[Constants.HangHoaSTATIC.TenHangHoa].ToString();
                    hanghoa.MaDonViTinh = dr[Constants.HangHoaSTATIC.MaDonViTinh].ToString();
                    hanghoa.TenDonViTinh = dr[Constants.HangHoaSTATIC.TenDonViTinh].ToString();
                    hanghoa.GiaNhap = dr[Constants.HangHoaSTATIC.GiaNhap].ToString();
                    hanghoa.GiaBanBuon = dr[Constants.HangHoaSTATIC.GiaBanBuon].ToString();
                    hanghoa.GiaBanLe = dr[Constants.HangHoaSTATIC.GiaBanLe].ToString();
                    hanghoa.MaThueGiaTriGiaTang = dr[Constants.HangHoaSTATIC.MaThueGiaTriGiaTang].ToString();
                    hanghoa.KieuHangHoa = dr[Constants.HangHoaSTATIC.KieuHangHoa].ToString();
                    hanghoa.SeriLo = dr[Constants.HangHoaSTATIC.SeriLo].ToString();
                    hanghoa.MucDatHang = Convert.ToInt32(dr[Constants.HangHoaSTATIC.MucDatHang].ToString());
                    hanghoa.MucTonToiThieu = Convert.ToInt32(dr[Constants.HangHoaSTATIC.MucTonToiThieu].ToString());
                    hanghoa.GhiChu = dr[Constants.HangHoaSTATIC.GhiChu].ToString();
                    l.Add(hanghoa);
                }
            }
            catch { return null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
            }
            return l.ToArray();
        }

        public Entities.HangHoa[] SelectAll()
        {
            Entities.HangHoa temp = new Entities.HangHoa(); temp.ThaoTac = "select";
            return sp_SelectHangHoasAll(temp);
        }
        public Entities.HangHoa[] Select()
        {
            return SelectAll();
        }
        public Entities.HangHoa[] SelectHangHoa_Theo_MaHangHoa(string mahanghoa)
        {
            Entities.HangHoa temp = new Entities.HangHoa(); temp.ThaoTac = "select_TheoMaHangHoa"; temp.MaHangHoa = mahanghoa.ToUpper();
            return sp_SelectHangHoasAll(temp);
        }
        public string LayNhomHangHoa(string MaNH)
        {
            try
            {
                Entities.NhomHang[] nh = new BizLogic.NhomHang().sp_SelectNhomHangsAll();
                if (nh == null)
                {
                    return "";
                }
                for (int i = 0; i < nh.Length; i++)
                {
                    if (nh[i].MaNhomHang == MaNH)
                    {
                        return nh[i].TenNhomHang;
                    }
                }
                return "";
            }
            catch { return ""; }
        }

        public string LayDVT(string MaDVT)
        {
            try
            {
                Entities.DVT[] nh = new BizLogic.DVT().sp_SelectDVTsAll();
                if (nh == null)
                {
                    return "";
                }
                for (int i = 0; i < nh.Length; i++)
                {
                    if (nh[i].MaDonViTinh == MaDVT)
                    {
                        return nh[i].TenDonViTinh;
                    }
                }
                return "";
            }
            catch { return ""; }
        }

        public string LayThue(string MaThue)
        {
            try
            {
                Entities.Thue[] nh = new BizLogic.ThueH().sp_SelectThuesAll();
                if (nh == null)
                {
                    return "";
                }
                for (int i = 0; i < nh.Length; i++)
                {
                    if (nh[i].MaThue == MaThue)
                    {
                        return nh[i].TenThue;
                    }
                }
                return "";
            }
            catch { return ""; }

        }

        public Entities.HangHoa[] Select(string Cot, string Kieu, string Giatri, string maKho)
        {
            Entities.HangHoa[] arrC = null;
            try
            {
                hh = new Constants.HangHoa();
                Sql = new Constants.Sql();
                string sql = "";
                if (Kieu == "like")
                    sql = "select * from HangHoa join ChiTietKhoHang on HangHoa.MaHangHoa = ChiTietKhoHang.MaHangHoa where " + Cot + " " + Kieu + " '%" + Giatri + "%' and HangHoa.Deleted =0 and MaKho ='" + maKho + "'";
                else
                    sql = "select * from HangHoa join ChiTietKhoHang on HangHoa.MaHangHoa = ChiTietKhoHang.MaHangHoa where " + Cot + " " + Kieu + " '" + Giatri + "'  and HangHoa.Deleted =0 and MaKho ='" + maKho + "'";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    hanghoa = new Entities.HangHoa();
                    hanghoa.HangHoaID = Convert.ToInt32(dr[hh.HangHoaID].ToString());
                    hanghoa.MaHangHoa = dr[hh.MaHangHoa].ToString();
                    hanghoa.MaNhomHangHoa = dr[hh.MaNhomHangHoa].ToString();
                    hanghoa.TenHangHoa = dr[hh.TenHangHoa].ToString();
                    hanghoa.MaDonViTinh = dr[hh.MaDonViTinh].ToString();
                    hanghoa.TenDonViTinh = LayDVT(hanghoa.MaDonViTinh);
                    hanghoa.GiaNhap = dr[hh.GiaNhap].ToString();
                    hanghoa.GiaBanBuon = dr[hh.GiaBanBuon].ToString();
                    hanghoa.GiaBanLe = dr[hh.GiaBanLe].ToString();
                    hanghoa.MaThueGiaTriGiaTang = dr[hh.MaThueGiaTriGiaTang].ToString();
                    hanghoa.KieuHangHoa = dr[hh.KieuHangHoa].ToString();
                    hanghoa.SeriLo = dr[hh.SeriLo].ToString();
                    hanghoa.MucDatHang = Convert.ToInt32(dr[hh.MucDatHang].ToString());
                    hanghoa.MucTonToiThieu = Convert.ToInt32(dr[hh.MucTonToiThieu].ToString());
                    hanghoa.GhiChu = dr[hh.GhiChu].ToString();
                    hanghoa.Deleted = (Boolean)dr[hh.Deleted];
                    arr.Add(hanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.HangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HangHoa)arr[i];
                }
            }
            catch { }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }

        public Entities.HangHoa[] Select(string Cot, string Kieu, string Giatri)
        {
            Entities.HangHoa[] arrC = null;
            try
            {
                hh = new Constants.HangHoa();
                Sql = new Constants.Sql();
                string sql = "";
                if (Kieu == "like")
                    sql = "select * from HangHoa where " + Cot + " " + Kieu + " '%" + Giatri + "%' and Deleted =0 ";
                else
                    sql = "select * from HangHoa where " + Cot + " " + Kieu + " '" + Giatri + "'  and Deleted =0 ";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    hanghoa = new Entities.HangHoa();
                    hanghoa.HangHoaID = Convert.ToInt32(dr[hh.HangHoaID].ToString());
                    hanghoa.MaHangHoa = dr[hh.MaHangHoa].ToString();
                    hanghoa.MaNhomHangHoa = dr[hh.MaNhomHangHoa].ToString();
                    hanghoa.TenHangHoa = dr[hh.TenHangHoa].ToString();
                    hanghoa.MaDonViTinh = dr[hh.MaDonViTinh].ToString();
                    hanghoa.TenDonViTinh = LayDVT(hanghoa.MaDonViTinh);
                    hanghoa.GiaNhap = dr[hh.GiaNhap].ToString();
                    hanghoa.GiaBanBuon = dr[hh.GiaBanBuon].ToString();
                    hanghoa.GiaBanLe = dr[hh.GiaBanLe].ToString();
                    hanghoa.MaThueGiaTriGiaTang = dr[hh.MaThueGiaTriGiaTang].ToString();
                    hanghoa.KieuHangHoa = dr[hh.KieuHangHoa].ToString();
                    hanghoa.SeriLo = dr[hh.SeriLo].ToString();
                    hanghoa.MucDatHang = Convert.ToInt32(dr[hh.MucDatHang].ToString());
                    hanghoa.MucTonToiThieu = Convert.ToInt32(dr[hh.MucTonToiThieu].ToString());
                    hanghoa.GhiChu = dr[hh.GhiChu].ToString();
                    hanghoa.Deleted = (Boolean)dr[hh.Deleted];
                    arr.Add(hanghoa);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.HangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.HangHoa)arr[i];
                }
            }

            catch { }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }

        //insert update
        public int InsertUpdate(Entities.HangHoa hh1)
        {
            try
            {
                hh = new Constants.HangHoa();
                Sql = new Constants.Sql();
                string sql = Sql.InsertUpdateHangHoa;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(hh.HanhDong, SqlDbType.NVarChar, 20).Value = hh1.HanhDong;
                cmd.Parameters.Add(hh.MaHangHoa, SqlDbType.NVarChar, 50).Value = hh1.MaHangHoa;
                cmd.Parameters.Add(hh.MaNhomHangHoa, SqlDbType.NVarChar, 20).Value = hh1.MaNhomHangHoa;
                cmd.Parameters.Add(hh.TenHangHoa, SqlDbType.NVarChar, 200).Value = hh1.TenHangHoa;
                cmd.Parameters.Add(hh.MaDonViTinh, SqlDbType.NVarChar, 20).Value = hh1.MaDonViTinh;
                cmd.Parameters.Add(hh.GiaNhap, SqlDbType.Float).Value = hh1.GiaNhap;
                cmd.Parameters.Add(hh.GiaBanBuon, SqlDbType.Float).Value = hh1.GiaBanBuon;
                cmd.Parameters.Add(hh.GiaBanLe, SqlDbType.Float).Value = hh1.GiaBanLe;
                cmd.Parameters.Add(hh.MaThueGiaTriGiaTang, SqlDbType.NVarChar, 20).Value = hh1.MaThueGiaTriGiaTang;
                cmd.Parameters.Add(hh.KieuHangHoa, SqlDbType.NVarChar, 20).Value = hh1.KieuHangHoa;
                cmd.Parameters.Add(hh.SeriLo, SqlDbType.NVarChar, 20).Value = hh1.SeriLo;
                cmd.Parameters.Add(hh.MucDatHang, SqlDbType.Int).Value = hh1.MucDatHang;
                cmd.Parameters.Add(hh.MucTonToiThieu, SqlDbType.Int).Value = hh1.MucTonToiThieu;
                cmd.Parameters.Add(hh.GhiChu, SqlDbType.NVarChar, 100).Value = hh1.GhiChu;
                cmd.Parameters.Add(hh.Deleted, SqlDbType.Bit).Value = hh1.Deleted;

                int i = cmd.ExecuteNonQuery();
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
                cn = null;
                conn = null;
                return i;
            }
            catch { return 0; }
        }
        //delete
        public int Delete(Entities.HangHoa hh1)
        {
            hh = new Constants.HangHoa();
            Entities.HangHoa hanghoa = new Entities.HangHoa();
            Sql = new Constants.Sql();
            string sql = Sql.DeleteHangHoa;
            Connection conn = new Connection();
            SqlConnection cn = conn.openConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(hh.HanhDong, SqlDbType.NVarChar, 20).Value = hh1.HanhDong;
            cmd.Parameters.Add(hh.HangHoaID, SqlDbType.Int).Value = hh1.HangHoaID;

            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Dispose();
            cn.Close();
            conn.closeConnection();
            cn = null;
            conn = null;
            return i;
        }

    }
}
