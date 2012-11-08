using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNA_Project.Entity;
using System.Windows.Forms;

namespace VNA_Project
{
    public class Utils
    {
        #region Bảo mật
        public static string EnCrypt(string strEnCrypt)
        {
            return EnCrypt(strEnCrypt, "Đặng Đức Kiên");
        }
        private static string EnCrypt(string strEnCrypt, string key)
        {
            try
            {
                byte[] keyArr;
                byte[] EnCryptArr = UTF8Encoding.UTF8.GetBytes(strEnCrypt);
                System.Security.Cryptography.MD5CryptoServiceProvider MD5Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                System.Security.Cryptography.TripleDESCryptoServiceProvider tripDes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
                return Convert.ToBase64String(arrResult, 0, arrResult.Length);
            }
            catch (Exception ex) { }
            return string.Empty;
        }

        public static string DeCrypt(string strEnCrypt)
        {
            return DeCrypt(strEnCrypt, "Đặng Đức Kiên");
        }
        private static string DeCrypt(string strDecypt, string key)
        {
            try
            {
                byte[] keyArr;
                byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
                System.Security.Cryptography.MD5CryptoServiceProvider MD5Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                System.Security.Cryptography.TripleDESCryptoServiceProvider tripDes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] arrResult = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length);
                return UTF8Encoding.UTF8.GetString(arrResult);
            }
            catch (Exception ex) { }
            return string.Empty;
        }
        #endregion

        #region Convert
        public static NguonVon DataGridViewRow_to_NguonVon(System.Windows.Forms.DataGridViewRow Input)
        {
            NguonVon kq = new NguonVon();
            kq.MaNguonVon = Input.Cells["MaNguonVon"].Value.ToString();
            kq.TenNguonVon = Input.Cells["TenNguonVon"].Value.ToString();
            return kq;
        }
        public static LyDoTangGiamTaiSan DataGridViewRow_to_LyDoTangGiamTaiSan(System.Windows.Forms.DataGridViewRow Input)
        {
            LyDoTangGiamTaiSan kq = new LyDoTangGiamTaiSan();
            //1- tăng tài sản (TRUE), 2- giảm tài sản (FALSE)
            kq.LoaiTangGiamTaiSan = bool.Parse(Input.Cells["LoaiTangGiamTaiSan"].Value.ToString());
            kq.MaLyDoTangGiamTaiSan = Input.Cells["MaLyDoTangGiamTaiSan"].Value.ToString();
            kq.TenLyDoTangGiamTaiSan = Input.Cells["TenLyDoTangGiamTaiSan"].Value.ToString();
            return kq;
        }
        public static LoaiTaiSan DataGridViewRow_to_LoaiTaiSan(System.Windows.Forms.DataGridViewRow Input)
        {
            LoaiTaiSan kq = new LoaiTaiSan();
            kq.MaLoaiTaiSan = Input.Cells["MaLoaiTaiSan"].Value.ToString();
            kq.TenLoaiTaiSan = Input.Cells["TenLoaiTaiSan"].Value.ToString();
            return kq;
        }
        public static PhanNhomTaiSan DataGridViewRow_to_PhanNhomTaiSan(System.Windows.Forms.DataGridViewRow Input)
        {
            PhanNhomTaiSan kq = new PhanNhomTaiSan();
            kq.MaPhanNhomTaiSan = Input.Cells["MaPhanNhomTaiSan"].Value.ToString();
            kq.TenPhanNhomTaiSan = Input.Cells["TenPhanNhomTaiSan"].Value.ToString();
            kq.KieuPhanNhomTaiSan = Input.Cells["KieuPhanNhomTaiSan"].Value.ToString();
            return kq;
        }
        public static ThietBi DataGridViewRow_to_ThietBi(System.Windows.Forms.DataGridViewRow Input)
        {
            ThietBi kq = new ThietBi();
            kq.MaThietBi = Input.Cells["MaThietBi"].Value.ToString();
            kq.TenThietBi = Input.Cells["TenThietBi"].Value.ToString();
            return kq;
        }
        public static BoPhanSuDung DataGridViewRow_to_BoPhanSuDung(System.Windows.Forms.DataGridViewRow Input)
        {
            BoPhanSuDung kq = new BoPhanSuDung();
            kq.MaBoPhanSuDung = Input.Cells["MaBoPhanSuDung"].Value.ToString();
            kq.TenBoPhanSuDung = Input.Cells["TenBoPhanSuDung"].Value.ToString();
            return kq;
        }
        public static Phi DataGridViewRow_to_Phi(System.Windows.Forms.DataGridViewRow Input)
        {
            Phi kq = new Phi();
            kq.MaPhi = Input.Cells["MaPhi"].Value.ToString();
            kq.TenPhi = Input.Cells["TenPhi"].Value.ToString();
            return kq;
        }
        public static PhanXuong DataGridViewRow_to_PhanXuong(System.Windows.Forms.DataGridViewRow Input)
        {
            PhanXuong kq = new PhanXuong();
            kq.MaPhanXuong = Input.Cells["MaPhanXuong"].Value.ToString();
            kq.TenPhanXuong = Input.Cells["TenPhanXuong"].Value.ToString();
            return kq;
        }
        public static BoPhanHachToan DataGridViewRow_to_BoPhanHachToan(System.Windows.Forms.DataGridViewRow Input)
        {
            BoPhanHachToan kq = new BoPhanHachToan();
            kq.MaBoPhanHachToan = Input.Cells["MaBoPhanHachToan"].Value.ToString();
            BoPhanHachToan tmp = DANHMUC.BoPhanHachToanFolder.frmDMBoPhanHachToan.Ldata.SingleOrDefault(k => k.MaBoPhanHachToan.ToUpper().Equals(kq.MaBoPhanHachToan.ToUpper())).Copy() ?? new BoPhanHachToan();
            return kq;
        }
        public static TaiSan DataGridViewRow_to_TaiSan(System.Windows.Forms.DataGridViewRow Input)
        {
            string MA = Input.Cells["MaTaiSan"].Value.ToString();
            return DANHMUC.TaiSanFolder.frmDMTaiSan.Ldata.SingleOrDefault(k => k.MaTaiSan.ToUpper().Equals(MA.ToUpper())).Copy() ?? new TaiSan();
        }
        #endregion
    }

    public class MSG
    {
        public static string TieuDe = "Tiêu Đề";

        #region MessageBox
        public static DialogResult ThemThanhCong()
        {
            return MESSAGE("Thêm thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ThemThatBai()
        {
            return MESSAGE("Thêm thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult SuaThanhCong()
        {
            return MESSAGE("Sửa thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult SuaThatBai()
        {
            return MESSAGE("Sửa thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult XoaThanhCong()
        {
            return MESSAGE("Xóa thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult XoaThatBai()
        {
            return MESSAGE("Xóa thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult BanCoChacChanMuonXoaKhong()
        {
            return MESSAGE("Bạn có chắc chắn muốn xóa không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult BanCoChacChanMuonThoatKhong()
        {
            return MESSAGE("Bạn có chắc chắn muốn thoát không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Error(Exception ex)
        {//hàm thông báo lỗi dành cho trường hợp bắt ngoại lệ try...catch
            return MESSAGE("Có lỗi xảy ra:\r\n\r\n" + ex.Message + "\r\n" + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ErrorStand(string ex)
        {//hàm thông báo lỗi dành cho trường hợp bắt bằng tay
            return MESSAGE("Có lỗi xảy ra:\r\n\r\n" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult MESSAGE(string msg, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            return MessageBox.Show(msg, MSG.TieuDe, MessageBoxButtons, MessageBoxIcon);
        }
        #endregion
    }
}
