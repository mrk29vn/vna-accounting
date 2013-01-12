using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Common;
using Entities;
namespace BizLogic
{
    public class CongNo
    {
        private Constants.KhachHangTraLai khtl;
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private Entities.KhachHangTraLai khachhangtralai;
        private SqlConnection cn;
        private Constants.TraLaiNhaCungCap tlncc;
        private Entities.TraLaiNCC tralainhacungcap;
        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public CongNo()
        {
            khtl = null;
            Sql = null;
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            khachhangtralai = null;
            cn = null;
        }
        Constants.CongNo pt;
        Constants.Sql Sql;
        /// <summary>
        /// Select Bảng
        /// </summary>
        /// <returns></returns>
        public Entities.SoDuCongNo[] Select()
        {
            try
            {
                Sql = new Constants.Sql();
                pt = new Constants.CongNo();
                string sql = Sql.SelectSoDuCongNo;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //Insert Category into ArrayList
                ArrayList arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.SoDuCongNo phieuthu = new Entities.SoDuCongNo();
                    phieuthu.SoDuCongNoID = Convert.ToInt32(dr[pt.SoDuCongNoID].ToString());
                    phieuthu.MaSoDuCongNo = dr[pt.MaSoDuCongNo].ToString();
                    phieuthu.MaDoiTuong = dr[pt.MaDoiTuong].ToString();
                    phieuthu.TenDoiTuong = dr[pt.TenDoiTuong].ToString();
                    phieuthu.DiaChi = dr[pt.DiaChi].ToString();
                    phieuthu.SoDuDauKy = dr[pt.SoDuDauKy].ToString();
                    phieuthu.NgayKetChuyen = DateTime.Parse(dr[pt.NgayKetChuyen].ToString());
                    phieuthu.SoDuCuoiKy = dr[pt.SoDuCuoiKy].ToString();
                    phieuthu.LoaiDoiTuong = Boolean.Parse(dr[pt.LoaiDoiTuong].ToString());
                    phieuthu.TrangThai = Boolean.Parse(dr[pt.TrangThai].ToString());
                    arr.Add(phieuthu);
                }
                int n = arr.Count;
                if (n == 0) return null;

                Entities.SoDuCongNo[] arrC = new Entities.SoDuCongNo[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.SoDuCongNo)arr[i];
                }

                //Giai phong bo nho
                return arrC;
            }
            catch
            {
                return null;
            }
        }
        public Entities.TraLaiNCC[] SelectTLNCCTheoMaKho(string MaKho)
        {
            Entities.TraLaiNCC[] arrC = null;
            try
            {
                tlncc = new Constants.TraLaiNhaCungCap();

                string sql = "";
                sql = "Select * from TraLaiNCC where MaKho='" + MaKho + "' and Deleted=0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralainhacungcap = new Entities.TraLaiNCC();
                    tralainhacungcap.TraLaiNCCID = Convert.ToInt32(dr[tlncc.TraLaiNCCID].ToString());
                    tralainhacungcap.MaHDTraLaiNCC = dr[tlncc.MaHDTraLaiNCC].ToString();
                    tralainhacungcap.Ngaytra = Convert.ToDateTime(dr[tlncc.Ngaytra].ToString());
                    tralainhacungcap.MaNCC = dr[tlncc.MaNCC].ToString();
                    tralainhacungcap.NoHienThoi = dr[tlncc.NoHienThoi].ToString();
                    tralainhacungcap.NguoiNhanHang = dr[tlncc.NguoiNhanHang].ToString();
                    tralainhacungcap.HinhThucThanhToan = dr[tlncc.HinhThucThanhToan].ToString();
                    tralainhacungcap.MaHoaDonNhap = dr[tlncc.MaHoaDonNhap].ToString();
                    tralainhacungcap.MaKho = dr[tlncc.MaKho].ToString();
                    tralainhacungcap.MaTienTe = dr[tlncc.MaTienTe].ToString();
                    tralainhacungcap.TienBoiThuong = dr[tlncc.TienBoiThuong].ToString();
                    tralainhacungcap.ThanhToanNgay = dr[tlncc.ThanhToanNgay].ToString();
                    tralainhacungcap.ThueGTGT = dr[tlncc.ThueGTGT].ToString();
                    tralainhacungcap.GhiChu = dr[tlncc.GhiChu].ToString();
                    tralainhacungcap.Deleted = Convert.ToBoolean(dr[tlncc.Deleted].ToString());
                    arr.Add(tralainhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TraLaiNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TraLaiNCC)arr[i];
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
        public bool Insert(Entities.SoDuCongNo pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.CongNo();
                Sql = new Constants.Sql();
                string sql = Sql.InsertSoDuCongNo;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaSoDuCongNo, SqlDbType.VarChar, 20).Value = pxh.MaSoDuCongNo;
                cmd.Parameters.Add(pt.MaDoiTuong, SqlDbType.VarChar, 20).Value = pxh.MaDoiTuong;
                cmd.Parameters.Add(pt.TenDoiTuong, SqlDbType.NVarChar, 200).Value = pxh.TenDoiTuong;
                cmd.Parameters.Add(pt.DiaChi, SqlDbType.NVarChar, 200).Value = pxh.DiaChi;
                cmd.Parameters.Add(pt.SoDuDauKy, SqlDbType.Float).Value = pxh.SoDuDauKy;
                cmd.Parameters.Add(pt.NgayKetChuyen, SqlDbType.DateTime).Value = pxh.NgayKetChuyen;
                cmd.Parameters.Add(pt.SoDuCuoiKy, SqlDbType.Float).Value = pxh.SoDuCuoiKy;
                cmd.Parameters.Add(pt.LoaiDoiTuong, SqlDbType.Bit).Value = pxh.LoaiDoiTuong;
                cmd.Parameters.Add(pt.TrangThai, SqlDbType.Bit).Value = pxh.TrangThai;
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
                return false;
            }
        }

        /// <summary>
        /// Insert Update Bảng
        /// </summary>
        public bool Update(Entities.SoDuCongNo pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.CongNo();
                Sql = new Constants.Sql();
                string sql = Sql.UpdateTinhTrangSoDuCongNo;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaSoDuCongNo, SqlDbType.VarChar, 20).Value = pxh.MaSoDuCongNo;
                cmd.Parameters.Add(pt.SoDuCuoiKy, SqlDbType.Float).Value = pxh.SoDuCuoiKy;
                cmd.Parameters.Add(pt.LoaiDoiTuong, SqlDbType.Bit).Value = pxh.LoaiDoiTuong;
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
                return false;
            }
        }

        public bool Update(Entities.SoDuCongNo[] sdcn)
        {
            int soluong = 0;
            Entities.SoDuCongNo[] hienthi = Select();
            // nếu obj null
            int year1 = 0;
            int month1 = 0;
            if (hienthi == null)
            {
                hienthi = new SoDuCongNo[0];
            }
            else
            {
                bool k1 = false;
                Entities.SoDuCongNo[] sdc = new SoDuCongNo[hienthi.Length];
                // kiểm tra số dư hiện tại
                for (int i = 0; i < sdc.Length; i++)
                {
                    k1 = false;
                        
                    int nam1 = sdcn[0].NgayKetChuyen.Year;
                    int thang1 = sdcn[0].NgayKetChuyen.Month;
                    if (nam1 == hienthi[i].NgayKetChuyen.Year && thang1 == hienthi[i].NgayKetChuyen.Month && sdcn[0].LoaiDoiTuong == hienthi[i].LoaiDoiTuong)
                    {
                        k1 = true;
                        break;
                    }
                }
                
                if (k1 == true)
                {
                    for (int i = 0; i < sdc.Length; i++)
                    {
                        if (sdcn[0].NgayKetChuyen.Year == hienthi[i].NgayKetChuyen.Year && sdcn[0].NgayKetChuyen.Month == hienthi[i].NgayKetChuyen.Month && sdcn[0].LoaiDoiTuong == hienthi[i].LoaiDoiTuong)
                        {
                            year1 = sdcn[0].NgayKetChuyen.Year;
                            month1 = sdcn[0].NgayKetChuyen.Month;
                            sdc[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    hienthi = new SoDuCongNo[soluong];
                    for (int i = 0; i < soluong; i++)
                    {
                        hienthi[i] = sdc[i];
                    }
                }
                else
                {
                    for (int i = 0; i < sdc.Length; i++)
                    {
                        if (sdcn[0].NgayKetChuyen.Month != 1)
                        {
                            if (sdcn[0].NgayKetChuyen.Year == hienthi[i].NgayKetChuyen.Year && (sdcn[0].NgayKetChuyen.Month - 1) == hienthi[i].NgayKetChuyen.Month && sdcn[0].LoaiDoiTuong == hienthi[i].LoaiDoiTuong)
                            {
                                Convert.ToDateTime((hienthi[0].NgayKetChuyen.Month - 1).ToString() + "/01/" + (hienthi[0].NgayKetChuyen.Year).ToString());
                                year1 = hienthi[0].NgayKetChuyen.Year;
                                month1 = hienthi[0].NgayKetChuyen.Month-1;
                                sdc[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        else
                        {
                            if ((sdcn[0].NgayKetChuyen.Year - 1) == hienthi[i].NgayKetChuyen.Year && 12 == hienthi[i].NgayKetChuyen.Month && sdcn[0].LoaiDoiTuong == hienthi[i].LoaiDoiTuong)
                            {
                                year1 = hienthi[0].NgayKetChuyen.Year;
                                month1 = 12;
                                hienthi[i].NgayKetChuyen = Convert.ToDateTime(12.ToString() + "/01/" + year1.ToString());
                                sdc[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                    }
                    hienthi = new SoDuCongNo[soluong];
                    for (int i = 0; i < soluong; i++)
                    {
                        hienthi[i] = sdc[i];
                    }
                }
            }
            Entities.SoDuCongNo[] mangluu;
            int sotang = 0;
            // đếm số bản ghi tồn tại rồi
            for (int i = 0; i < hienthi.Length; i++)
            {
                if (hienthi[i].LoaiDoiTuong == sdcn[0].LoaiDoiTuong)
                {
                    if (sdcn[0].MaDoiTuong != null)
                        sotang++;
                }
            }

            if (hienthi.Length == 0)
                mangluu = new SoDuCongNo[sotang];
            else
                mangluu = new SoDuCongNo[hienthi.Length];
            sotang = 0;
            bool kt1 = true;
            // gán giá trị cho obj mangluu khởi tạo
            if (hienthi.Length == 0)
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].LoaiDoiTuong == sdcn[0].LoaiDoiTuong)
                    {
                        mangluu[sotang] = hienthi[i];
                        sotang++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    mangluu[i] = hienthi[i];
                }
            }
            bool kt = false;
            for (int i = 0; i < sdcn.Length; i++)
            {
                kt = false;
                for (int j = 0; j < mangluu.Length; j++)
                {
                    if (sdcn[i].MaDoiTuong == mangluu[j].MaDoiTuong && sdcn[0].LoaiDoiTuong == mangluu[j].LoaiDoiTuong)
                    {
                        kt = true;
                        break;
                    }
                }
                string maSoDuCongNo = "";
                Entities.LayID b = new LayID("", "SoDuCongNo");
                b = (Entities.LayID)new BizLogic.Lay_ID().Select(b);
                if (b == null)
                {
                    maSoDuCongNo = "SDCN_0001";
                }
                else
                {
                    maSoDuCongNo = new Common.Utilities().ProcessID(b.ID);
                }
                if (kt == true)
                {
                    sdcn[i].MaSoDuCongNo = hienthi[i].MaSoDuCongNo;
                    Update(sdcn[i]);
                    int nam = sdcn[i].NgayKetChuyen.Year;
                    int thang = sdcn[i].NgayKetChuyen.Month;
                    int namhientai=0;
                    int thanghientai=0;
                    if (hienthi.Length == 0)
                    {
                        namhientai = DateTime.Now.Year;
                        thanghientai = DateTime.Now.Month;
                    }
                    else
                    {
                        namhientai = hienthi[0].NgayKetChuyen.Year;
                        thanghientai = hienthi[0].NgayKetChuyen.Month;
                    }
                    Entities.SoDuCongNo a;
                    if (nam == namhientai && thang == thanghientai)
                    {
                        if (thang == 12)
                            a = new SoDuCongNo(maSoDuCongNo, sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, Convert.ToDateTime("01/01/" + (namhientai + 1).ToString()), "0", sdcn[i].LoaiDoiTuong, false);
                        else
                            a = new SoDuCongNo(maSoDuCongNo, sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, Convert.ToDateTime((thang + 1).ToString() + "/01/" + namhientai.ToString()), "0", sdcn[i].LoaiDoiTuong, false);
                    }
                    else
                        if (thanghientai == 12)
                            a = new SoDuCongNo(maSoDuCongNo, sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, Convert.ToDateTime(thang.ToString() + "/01/" + (namhientai + 1).ToString()), "0", sdcn[i].LoaiDoiTuong, false);
                        else
                            a = new SoDuCongNo(maSoDuCongNo, sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, DateTime.Now, "0", sdcn[i].LoaiDoiTuong, false);

                    Insert(a);
                }
                else
                {
                    int nam = sdcn[i].NgayKetChuyen.Year;
                    int thang = sdcn[i].NgayKetChuyen.Month;
                    int namhientai = DateTime.Now.Year;
                    int thanghientai = DateTime.Now.Month;
                    Entities.SoDuCongNo a;
                    if (sdcn[0].MaDoiTuong != null)
                    {
                        //a = new SoDuCongNo(maSoDuCongNo, sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, "0", Convert.ToDateTime(thang + "/01/" + nam), sdcn[i].SoDuCuoiKy, sdcn[i].LoaiDoiTuong, true);
                        a = new SoDuCongNo(maSoDuCongNo, sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, "0", new DateTime(nam, thang, 1), sdcn[i].SoDuCuoiKy, sdcn[i].LoaiDoiTuong, true);
                        Insert(a);
                        //if (nam == namhientai && thang == thanghientai)
                        //{
                        //    if (thang == 12)
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, Convert.ToDateTime("01/01/" + (namhientai + 1).ToString()), "0", sdcn[i].LoaiDoiTuong, false);
                        //    else
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, Convert.ToDateTime((thang + 1).ToString() + "/01/" + namhientai.ToString()), "0", sdcn[i].LoaiDoiTuong, false);
                        //}
                        //else
                        //    if (thang == 12)
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, Convert.ToDateTime(thang.ToString() + "/01/" + (namhientai).ToString()), "0", sdcn[i].LoaiDoiTuong, false);
                        //    else
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, DateTime.Now, "0", sdcn[i].LoaiDoiTuong, false);

                        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), sdcn[i].MaDoiTuong, sdcn[i].TenDoiTuong, sdcn[i].DiaChi, sdcn[i].SoDuCuoiKy, new DateTime(nam, thang, 1).AddMonths(1), "0", sdcn[i].LoaiDoiTuong, false);
                        Insert(a);
                    }
                    else
                    {//Có rồi thì update ngày kết chuyển = DateTime.Now
                        a = new SoDuCongNo(hienthi[i].MaSoDuCongNo, hienthi[i].MaDoiTuong, hienthi[i].TenDoiTuong, hienthi[i].DiaChi, "0", DateTime.Now, hienthi[i].SoDuDauKy, hienthi[i].LoaiDoiTuong, true);
                        Update(a);  //gán số dư cuối kỳ, trạng thái = 1 where mã số dư công nợ, loại đối tượng
                        //if (nam == namhientai && thang == thanghientai)
                        //{
                        //    if (thang == 12)
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), hienthi[i].MaDoiTuong, hienthi[i].TenDoiTuong, hienthi[i].DiaChi, hienthi[i].SoDuDauKy, Convert.ToDateTime("01/01/" + (namhientai + 1).ToString()), "0", hienthi[i].LoaiDoiTuong, false);
                        //    else
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), hienthi[i].MaDoiTuong, hienthi[i].TenDoiTuong, hienthi[i].DiaChi, hienthi[i].SoDuDauKy, Convert.ToDateTime((thang + 1).ToString() + "/01/" + namhientai.ToString()), "0", hienthi[i].LoaiDoiTuong, false);
                        //}
                        //else
                        //    if (thang == 12)
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), hienthi[i].MaDoiTuong, hienthi[i].TenDoiTuong, hienthi[i].DiaChi, hienthi[i].SoDuDauKy, Convert.ToDateTime(thang.ToString() + "/01/" + (namhientai).ToString()), "0", hienthi[i].LoaiDoiTuong, false);
                        //    else
                        //        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), hienthi[i].MaDoiTuong, hienthi[i].TenDoiTuong, hienthi[i].DiaChi, hienthi[i].SoDuDauKy, DateTime.Now, "0", hienthi[i].LoaiDoiTuong, false);

                        a = new SoDuCongNo(new Common.Utilities().ProcessID(maSoDuCongNo), hienthi[i].MaDoiTuong, hienthi[i].TenDoiTuong, hienthi[i].DiaChi, hienthi[i].SoDuDauKy, new DateTime(nam, thang, 1).AddMonths(1), "0", hienthi[i].LoaiDoiTuong, false);
                        Insert(a);
                    }
                }
            }
            return true;
        }

        public Entities.KhachHangTraLai[] SelectKHTL()
        {
            Entities.KhachHangTraLai[] arrC = null;
            try
            {
                khtl = new Constants.KhachHangTraLai();
                Sql = new Constants.Sql();
                string sql = "Select * from KhachHangTraLai";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    khachhangtralai = new Entities.KhachHangTraLai();
                    khachhangtralai.KhachHangTraLaiID = int.Parse(dr[0].ToString());
                    khachhangtralai.MaKhachHangTraLai = dr[1].ToString();
                    khachhangtralai.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                    khachhangtralai.MaKhachHang = dr[3].ToString();
                    khachhangtralai.NoHienThoi = dr[4].ToString();
                    khachhangtralai.NguoiTra = dr[5].ToString();
                    khachhangtralai.HinhThucThanhToan = dr[6].ToString();
                    khachhangtralai.HanThanhToan = Convert.ToDateTime(dr[7].ToString());
                    khachhangtralai.MaHoaDonMuaHang = dr[8].ToString();
                    khachhangtralai.MaKho = dr[9].ToString();
                    khachhangtralai.MaTienTe = dr[10].ToString();
                    khachhangtralai.TienBoiThuong = dr[11].ToString();
                    khachhangtralai.ThanhToanNgay = dr[12].ToString();
                    khachhangtralai.ThueGTGT = dr[13].ToString();
                    khachhangtralai.GhiChu = dr[14].ToString();
                    khachhangtralai.Deleted = Convert.ToBoolean(dr[15].ToString());
                    arr.Add(khachhangtralai);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.KhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.KhachHangTraLai)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); arrC = null; }
            finally
            {
                cmd.Connection.Dispose();
                cn.Close();
                conn.closeConnection();
            }
            return arrC;
        }
        /// <summary>
        /// vuong hung =================lay bang DonDatHang================
        /// </summary>
        /// <returns></returns>
        public Entities.TraLaiNCC[] SelectTLNCC()
        {
            Entities.TraLaiNCC[] arrC = null;
            try
            {
                tlncc = new Constants.TraLaiNhaCungCap();
                Sql = new Constants.Sql();
                string sql = "select * from TraLaiNCC where Deleted=0";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    tralainhacungcap = new Entities.TraLaiNCC();
                    tralainhacungcap.TraLaiNCCID = Convert.ToInt32(dr[tlncc.TraLaiNCCID].ToString());
                    tralainhacungcap.MaHDTraLaiNCC = dr[tlncc.MaHDTraLaiNCC].ToString();
                    tralainhacungcap.Ngaytra = Convert.ToDateTime(dr[tlncc.Ngaytra].ToString());
                    tralainhacungcap.MaNCC = dr[tlncc.MaNCC].ToString();
                    tralainhacungcap.NoHienThoi = dr[tlncc.NoHienThoi].ToString();
                    tralainhacungcap.NguoiNhanHang = dr[tlncc.NguoiNhanHang].ToString();
                    tralainhacungcap.HinhThucThanhToan = dr[tlncc.HinhThucThanhToan].ToString();
                    tralainhacungcap.MaHoaDonNhap = dr[tlncc.MaHoaDonNhap].ToString();
                    tralainhacungcap.MaKho = dr[tlncc.MaKho].ToString();
                    tralainhacungcap.MaTienTe = dr[tlncc.MaTienTe].ToString();
                    tralainhacungcap.TienBoiThuong = dr[tlncc.TienBoiThuong].ToString();
                    tralainhacungcap.ThanhToanNgay = dr[tlncc.ThanhToanNgay].ToString();
                    tralainhacungcap.ThueGTGT = dr[tlncc.ThueGTGT].ToString();
                    tralainhacungcap.GhiChu = dr[tlncc.GhiChu].ToString();
                    tralainhacungcap.Deleted = Convert.ToBoolean(dr[tlncc.Deleted].ToString());
                    arr.Add(tralainhacungcap);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                arrC = new Entities.TraLaiNCC[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.TraLaiNCC)arr[i];
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
        /// Delete Bảng
        /// </summary>
        public bool Delete(Entities.SoDuCongNo pxh)
        {
            try
            {
                bool kt = false;
                pt = new Constants.CongNo();
                Sql = new Constants.Sql();
                string sql = Sql.DeleteSoDuCongNo;
                Connection conn = new Connection();
                SqlConnection cn = conn.openConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(pt.MaSoDuCongNo, SqlDbType.VarChar, 20).Value = pxh.MaSoDuCongNo;
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
                return false;
            }
        }
    }
}
