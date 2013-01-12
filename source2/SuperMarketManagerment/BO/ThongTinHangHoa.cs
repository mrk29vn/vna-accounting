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
    public class ThongTinHangHoa
    {
        private Connection conn;
        private SqlCommand cmd;
        private ArrayList arr;
        private SqlDataReader dr;
        private SqlConnection cn;

        /// <summary>
        /// khoi tao gia tri
        /// </summary>
        public ThongTinHangHoa()
        {
            conn = null;
            cmd = null;
            arr = null;
            dr = null;
            cn = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kiemtra"></param>
        /// <returns></returns>
        public Entities.HienThiBaoCao[] KiemTraNhomHangHoa(Entities.HienThiBaoCao[] kiemtra)
        {
            Entities.HienThiBaoCao[] tra = null;
            try
            {
                ArrayList arr = new ArrayList();
                for (int i = 0; i < kiemtra.Length; i++)
                {
                    Entities.TruyenGiaTri giatri = new TruyenGiaTri("", kiemtra[i].Ma);
                    Entities.ThongTinHangHoa[] data = Select(giatri);
                    if (data.Length > 0)
                    {
                        arr.Add(kiemtra[i]);
                    }
                    else
                    { continue; }
                }
                int n = arr.Count;
                if (n == 0) { tra = null; }
                tra = new Entities.HienThiBaoCao[n];
                for (int i = 0; i < n; i++)
                {
                    tra[i] = (Entities.HienThiBaoCao)arr[i];
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = null; }
            return tra;
        }
        /// <summary>
        /// lay hang hoa theo ma nhom hang
        /// </summary>
        /// <param name="giatri"></param>
        /// <returns></returns>
        public Entities.ThongTinHangHoa[] Select(Entities.TruyenGiaTri giatri)
        {
            Entities.ThongTinHangHoa[] arrC = null;
            try
            {
                string sql = "exec sp_TimHangHoaTheoMaNhomHang @MaNhomHangHoa";
                conn = new Connection();
                cn = conn.openConnection();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("MaNhomHangHoa", SqlDbType.NVarChar,20).Value = giatri.Giatritruyen;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                arr = new ArrayList();
                while (dr.Read())
                {
                    Entities.ThongTinHangHoa tao = new Entities.ThongTinHangHoa();
                    tao.MaNhomHangHoa = dr[0].ToString();
                    tao.MaHangHoa = dr[1].ToString();
                    tao.TenHangHoa = dr[2].ToString();
                    tao.GiaNhap = dr[3].ToString();
                    tao.GiaBanBuon = dr[4].ToString();
                    tao.GiaBanLe = dr[5].ToString();
                    arr.Add(tao);
                }
                int n = arr.Count;
                if (n == 0) { arrC = null; }
                arrC = new Entities.ThongTinHangHoa[n];
                for (int i = 0; i < n; i++)
                {
                    arrC[i] = (Entities.ThongTinHangHoa)arr[i];
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
    }
}
