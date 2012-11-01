using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VNA_Project.Entity;
using VNA_Project.BIZ;
using Qios.DevSuite.Components;

namespace VNA_Project.DANHMUC.LyDoTangGiamTaiSanFolder
{
    public partial class frmXuLyDMLyDoTangGiamTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMLyDoTangGiamTaiSan()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMLyDoTangGiamTaiSan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                LyDoTangGiamTaiSan temp = Utils.DataGridViewRow_to_LyDoTangGiamTaiSan(dgvr);
                txtMa.Text = temp.MaLyDoTangGiamTaiSan;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenLyDoTangGiamTaiSan;
                cbbLoaiTangGiamTaiSan.SelectedIndex = temp.LoaiTangGiamTaiSan ? 0 : 1;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                LyDoTangGiamTaiSan temp = new LyDoTangGiamTaiSan();
                temp.LoaiTangGiamTaiSan = cbbLoaiTangGiamTaiSan.SelectedIndex == 0 ? true : false;
                temp.LoaiTangGiamTaiSanVIEW = temp.LoaiTangGiamTaiSan ? "1" : "2";
                temp.MaLyDoTangGiamTaiSan = txtMa.Text;
                temp.TenLyDoTangGiamTaiSan = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = LyDoTangGiamTaiSanBiz.AddLyDoTangGiamTaiSan(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                LyDoTangGiamTaiSan temp = new LyDoTangGiamTaiSan();
                temp.LoaiTangGiamTaiSan = cbbLoaiTangGiamTaiSan.SelectedIndex == 0 ? true : false;
                temp.LoaiTangGiamTaiSanVIEW = temp.LoaiTangGiamTaiSan ? "1" : "2";
                temp.MaLyDoTangGiamTaiSan = txtMa.Text;
                temp.TenLyDoTangGiamTaiSan = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = LyDoTangGiamTaiSanBiz.EditLyDoTangGiamTaiSan(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(LyDoTangGiamTaiSan data)
        {
            bool kq = true;
            if (Them)
            {
                //mã lý do tăng giảm tài sản rỗng
                if (string.IsNullOrEmpty(data.MaLyDoTangGiamTaiSan))
                {
                    MSG.ErrorStand("Bạn chưa nhập mã lý do tăng giảm tài sản!");
                    txtMa.Focus();
                    return false;
                }
                //mã lý do tăng giảm tài sản đã có trong cơ sở dữ liệu
                foreach (LyDoTangGiamTaiSan item in frmDMLyDoTangGiamTaiSan.Ldata)
                {
                    if (item.MaLyDoTangGiamTaiSan.ToUpper().Equals(txtMa.Text.ToUpper()))
                    {
                        MSG.ErrorStand("Mã lý do tăng giảm tài sản đã có trong cơ sở dữ liệu!");
                        txtMa.Focus();
                        return false;
                    }
                }
            }
            //Loại tăng giảm tài sản chỉ có thể là 1 hoặc 2
            List<string> IN = new List<string>() { "1", "2" };
            if (!IN.Contains(cbbLoaiTangGiamTaiSan.Text))
            {
                MSG.ErrorStand("Loại tăng giảm tài sản chỉ có thể nhận một trong hai giá trị 1 hoặc 2");
                cbbLoaiTangGiamTaiSan.Focus();
                return false;
            }
            return kq;
        }
    }
}