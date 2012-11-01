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

namespace VNA_Project.DANHMUC.PhanNhomTaiSanFolder
{
    public partial class frmXuLyDMPhanNhomTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMPhanNhomTaiSan()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMPhanNhomTaiSan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                PhanNhomTaiSan temp = Utils.DataGridViewRow_to_PhanNhomTaiSan(dgvr);
                txtMa.Text = temp.MaPhanNhomTaiSan;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenPhanNhomTaiSan;
                txtKieuPhanNhomTS.Text = temp.KieuPhanNhomTaiSan;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                PhanNhomTaiSan temp = new PhanNhomTaiSan();
                temp.MaPhanNhomTaiSan = txtMa.Text;
                temp.TenPhanNhomTaiSan = txtTen.Text;
                temp.KieuPhanNhomTaiSan = txtKieuPhanNhomTS.Text;

                if (!CheckLoi(temp)) return;

                int kq = PhanNhomTaiSanBiz.AddPhanNhomTaiSan(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                PhanNhomTaiSan temp = new PhanNhomTaiSan();
                temp.MaPhanNhomTaiSan = txtMa.Text;
                temp.TenPhanNhomTaiSan = txtTen.Text;
                temp.KieuPhanNhomTaiSan = txtKieuPhanNhomTS.Text;

                if (!CheckLoi(temp)) return;

                int kq = PhanNhomTaiSanBiz.EditPhanNhomTaiSan(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(PhanNhomTaiSan data)
        {
            bool kq = true;
            if (Them)
            {
                //mã phân nhóm tài sản rỗng
                if (string.IsNullOrEmpty(data.MaPhanNhomTaiSan))
                {
                    MSG.ErrorStand("Bạn chưa nhập mã phân nhóm tài sản!");
                    txtMa.Focus();
                    return false;
                }
                //mã phân nhóm tài sản đã có trong cơ sở dữ liệu
                foreach (PhanNhomTaiSan item in frmDMPhanNhomTaiSan.Ldata)
                {
                    if (item.MaPhanNhomTaiSan.ToUpper().Equals(txtMa.Text.ToUpper()))
                    {
                        MSG.ErrorStand("Mã phân nhóm tài sản đã có trong cơ sở dữ liệu!");
                        txtMa.Focus();
                        return false;
                    }
                }
            }
            //kiểm tra kiểu phân nhóm tài sản chỉ là 1,2,3
            List<string> IN = new List<string>() { "1", "2", "3" };
            if (!string.IsNullOrEmpty(txtKieuPhanNhomTS.Text) && !IN.Contains(txtKieuPhanNhomTS.Text))
            {
                MSG.ErrorStand("Kiểu phân nhóm tài sản chỉ có thể là 1 hoặc 2 hoặc 3!");
                txtKieuPhanNhomTS.Focus();
                return false;
            }
            return kq;
        }
    }
}