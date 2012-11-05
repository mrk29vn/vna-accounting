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

namespace VNA_Project.DANHMUC.PhanXuongFolder
{
    public partial class frmXuLyDMPhanXuong : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMPhanXuong()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMPhanXuong(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                PhanXuong temp = Utils.DataGridViewRow_to_PhanXuong(dgvr);
                txtMa.Text = temp.MaPhanXuong;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenPhanXuong;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                PhanXuong temp = new PhanXuong();
                temp.MaPhanXuong = txtMa.Text;
                temp.TenPhanXuong = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = PhanXuongBiz.AddPhanXuong(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                PhanXuong temp = new PhanXuong();
                temp.MaPhanXuong = txtMa.Text;
                temp.TenPhanXuong = txtTen.Text;
                int kq = PhanXuongBiz.EditPhanXuong(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(PhanXuong data)
        {
            bool kq = true;
            //mã phân xưởng rỗng
            if (string.IsNullOrEmpty(data.MaPhanXuong))
            {
                MSG.ErrorStand("Bạn chưa nhập mã phân xưởng!");
                txtMa.Focus();
                return false;
            }
            //mã phân xưởng đã có trong cơ sở dữ liệu
            foreach (PhanXuong item in frmDMPhanXuong.Ldata)
            {
                if (item.MaPhanXuong.ToUpper().Equals(txtMa.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã phân xưởng đã có trong cơ sở dữ liệu!");
                    txtMa.Focus();
                    return false;
                }
            }
            return kq;
        }
    }
}