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
    public class ChiTietKhachHangTraLai
    {
        #region hungvv================================khai bao - khoi tao=====================================================================
        /// <summary>
        /// khai bao bien
        /// </summary>
        private Constants.ChiTietKhachHangTraLai dh;
        private Constants.Sql Sql;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.ChiTietKhachHangTraLai khachhangtralai;
        private SqlConnection cn;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ChiTietKhachHangTraLai()
        {
            dh = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khachhangtralai = null;
            cn = null;
        }
        #endregion

        #region hungvv==================================Xu ly=====================================================================================
        /// <summary>
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int LuuLai(Entities.ChiTietKhachHangTraLai[] ddh)
        {
            int Trave = 0;
            Entities.ChiTietKhachHangTraLai tl = new Entities.ChiTietKhachHangTraLai();
            for (int i = 0; i < ddh.Length; i++)
            {
                tl.Hanhdong = ddh[i].Hanhdong;
                tl.MaKhachHangTraLai = ddh[i].MaKhachHangTraLai;
                tl.MaHangHoa = ddh[i].MaHangHoa;
                tl.TenHangHoa = ddh[i].TenHangHoa;
                tl.SoLuong = ddh[i].SoLuong;
                tl.PhanTramChietKhau = ddh[i].PhanTramChietKhau;
                tl.DonGia = ddh[i].DonGia;
                tl.Thue = ddh[i].Thue;
                tl.GhiChu = ddh[i].GhiChu;
                tl.Deleted = ddh[i].Deleted;
                tl.Makho = ddh[i].Makho;
                Trave = sp_XuLy_ChiTietKhachHangTraLai(tl);
            }
            try
            {
                this.Binding(ddh);
            }
            catch { }
            if (Trave != 0)
            {
                try
                {
                    for (int k = 0; k < DanhSach.Length; k++)
                    {
                        conn = new Connection();
                        cn = conn.openConnection();
                        cmd = new SqlCommand(new Constants.Sql().sp_CongKho, cn);
                        cmd.Parameters.Add("MaKho", SqlDbType.VarChar).Value = DanhSach[k].Makho;
                        cmd.Parameters.Add("MaHangHoa", SqlDbType.VarChar).Value = DanhSach[k].MaHangHoa;
                        cmd.Parameters.Add("SoLuong", SqlDbType.Int).Value = DanhSach[k].SoLuong;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
            return Trave;
        }

        #region Doi Goi Hang
        private Entities.GoiHang[] goihang;
        private Entities.ChiTietGoiHang[] chitietgoihang;
        private Entities.HangHoa[] hanghoa;
        private Entities.ChiTietKhachHangTraLai[] DanhSach;
        private ArrayList list;
        private void Binding(Entities.ChiTietKhachHangTraLai[] chitiet)
        {
            try
            {
                try
                {
                    this.goihang = new BizLogic.GoiHang().Select();
                }
                catch { }
                try
                {
                    this.chitietgoihang = new BizLogic.ChiTietGoiHang().Select();
                }
                catch { }
                try
                {
                    this.hanghoa = new BizLogic.HangHoa().Select();
                }
                catch { }
                try
                {
                    this.ChiTietHoaDon(chitiet);
                }
                catch { }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private Boolean KiemTraMaGoiHang(string mahanghoa)
        {
            Boolean kt = false;
            try
            {
                for (int k = 0; k < chitietgoihang.Length; k++)
                {
                    if (chitietgoihang[k].MaGoiHang.ToUpper() == mahanghoa.ToUpper())
                    {
                        kt = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                kt = false;
            }
            return kt;
        }
        private string LaySoLuong(string mahanghoa, string magoi)
        {
            string soluong = "0";
            try
            {
                for (int k = 0; k < chitietgoihang.Length; k++)
                {
                    if (chitietgoihang[k].MaGoiHang.ToUpper() == magoi.ToUpper() && chitietgoihang[k].MaHangHoa.ToString().ToUpper() == mahanghoa.ToUpper())
                    {
                        soluong = chitietgoihang[k].SoLuong.ToString();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; soluong = "0"; }
            return soluong;
        }

        private void getChiTiet(Entities.ChiTietKhachHangTraLai chitiet, string mahanghoa)
        {
            try
            {
                for (int y = 0; y < hanghoa.Length; y++)
                {
                    if (hanghoa[y].MaHangHoa.ToUpper() == mahanghoa.ToUpper())
                    {
                        Entities.ChiTietKhachHangTraLai row = new Entities.ChiTietKhachHangTraLai();
                        row.Makho = chitiet.Makho;
                        row.MaHangHoa = mahanghoa;
                        row.SoLuong = chitiet.SoLuong * int.Parse(this.LaySoLuong(hanghoa[y].MaHangHoa, chitiet.MaHangHoa));
                        list.Add(row);
                        break;
                    }
                }

            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void Add(Entities.ChiTietKhachHangTraLai chitiet, string magoi)
        {
            try
            {
                for (int k = 0; k < chitietgoihang.Length; k++)
                {
                    if (chitietgoihang[k].MaGoiHang.ToUpper() == magoi.ToUpper())
                    {
                        this.getChiTiet(chitiet, chitietgoihang[k].MaHangHoa);
                    }
                    else
                    { continue; }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void ChiTietHoaDon(Entities.ChiTietKhachHangTraLai[] chitiet)
        {
            try
            {
                list = new ArrayList();
                for (int x = 0; x < chitiet.Length; x++)
                {
                    if (this.KiemTraMaGoiHang(chitiet[x].MaHangHoa) == true)
                    {
                        this.Add(chitiet[x], chitiet[x].MaHangHoa);
                    }
                    else
                    {
                        list.Add(chitiet[x]);
                    }
                }
                int n = list.Count;
                if (n == 0) { list = null; }
                DanhSach = new Entities.ChiTietKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    DanhSach[i] = (Entities.ChiTietKhachHangTraLai)list[i];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                DanhSach = null;
            }
        }
        #endregion

        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.ChiTietKhachHangTraLai[] sp_LayBang_ChiTietKhachHangTraLai()
        {
            Entities.ChiTietKhachHangTraLai[] arrC = null;
            try
            {
                dh = new Constants.ChiTietKhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = Sql.sp_LayBang_ChiTietKhachHangTraLai;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    khachhangtralai = new Entities.ChiTietKhachHangTraLai();
                    khachhangtralai.MaKhachHangTraLai = dr[dh.MaKhachHangTraLai].ToString();
                    khachhangtralai.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    khachhangtralai.SoLuong = Convert.ToInt32(0+dr[dh.SoLuong].ToString());
                    khachhangtralai.PhanTramChietKhau = 0+dr[dh.PhanTramChietKhau].ToString();
                    khachhangtralai.DonGia = dr[dh.DonGia].ToString();
                    khachhangtralai.Thue = dr[dh.Thue].ToString();
                    khachhangtralai.GhiChu = dr[dh.GhiChu].ToString();
                    khachhangtralai.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(khachhangtralai);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKhachHangTraLai)arr[i];
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

        public Entities.ChiTietKhachHangTraLai[] Select()
        {
            Entities.ChiTietKhachHangTraLai[] arrC = null;
            try
            {
                dh = new Constants.ChiTietKhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = "Select * From ChiTietKhachHangTraLai where Deleted = 0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    khachhangtralai = new Entities.ChiTietKhachHangTraLai();
                    khachhangtralai.MaKhachHangTraLai = dr[dh.MaKhachHangTraLai].ToString();
                    khachhangtralai.MaHangHoa = dr[dh.MaHangHoa].ToString();
                    khachhangtralai.TenHangHoa = dr["TenHangHoa"].ToString();
                    khachhangtralai.SoLuong = Convert.ToInt32(0 + dr[dh.SoLuong].ToString());
                    khachhangtralai.PhanTramChietKhau = 0 + dr[dh.PhanTramChietKhau].ToString();
                    khachhangtralai.DonGia = dr[dh.DonGia].ToString();
                    khachhangtralai.Thue = dr[dh.Thue].ToString();
                    khachhangtralai.GhiChu = dr[dh.GhiChu].ToString();
                    khachhangtralai.Deleted = Convert.ToBoolean(dr[dh.Deleted].ToString());
                    arr.Add(khachhangtralai);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.ChiTietKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ChiTietKhachHangTraLai)arr[i];
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
        /// vuong hung =================xu ly don dat hang================
        /// </summary>
        /// <returns></returns>
        public int sp_XuLy_ChiTietKhachHangTraLai(Entities.ChiTietKhachHangTraLai ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_XuLy_ChiTietKhachHangTraLai;
                conn = new Connection();
                cn = conn.openConnection();
                dh = new Constants.ChiTietKhachHangTraLai();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaKhachHangTraLai, SqlDbType.NVarChar).Value = ddh.MaKhachHangTraLai;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.NVarChar).Value = ddh.MaHangHoa;
                cmd.Parameters.Add("TenHangHoa", SqlDbType.NVarChar, 200).Value = ddh.TenHangHoa;
                cmd.Parameters.Add(dh.SoLuong, SqlDbType.Int).Value = ddh.SoLuong;
                cmd.Parameters.Add(dh.PhanTramChietKhau, SqlDbType.Float).Value = ddh.PhanTramChietKhau;
                cmd.Parameters.Add(dh.DonGia,SqlDbType.Float).Value = ddh.DonGia;
                cmd.Parameters.Add(dh.Thue, SqlDbType.Float).Value = ddh.Thue;
                cmd.Parameters.Add(dh.GhiChu, SqlDbType.NVarChar).Value = ddh.GhiChu;
                cmd.Parameters.Add(dh.Deleted, SqlDbType.Bit).Value = ddh.Deleted;
                cmd.Parameters.Add(dh.MaKho, SqlDbType.VarChar).Value = ddh.Makho;
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

        /// <summary>
        /// vuong hung =================================
        /// </summary>
        /// <param name="HanhDong"></param>
        /// <param name="PhieuThuID"></param>
        public int sp_Xoa_ChiTietKhachHangTraLai(Entities.ChiTietKhachHangTraLai ddh)
        {
            int Trave = 0;
            try
            {
                Sql = new Constants.Sql();
                string sql = Sql.sp_Xoa_ChiTietKhachHangTraLai;
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(dh.HanhDong, SqlDbType.NVarChar, 20).Value = ddh.Hanhdong;
                cmd.Parameters.Add(dh.MaKhachHangTraLai, SqlDbType.Int).Value = ddh.MaKhachHangTraLai;
                cmd.Parameters.Add(dh.MaHangHoa, SqlDbType.Int).Value = ddh.MaHangHoa;
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
        #endregion
    
    }
}
