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

namespace VNA_Project.DANHMUC.LoaiTaiSanFolder
{
    public partial class frmXuLyDMLoaiTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMLoaiTaiSan()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMLoaiTaiSan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                LoaiTaiSan temp = Utils.DataGridViewRow_to_LoaiTaiSan(dgvr);
                txtMa.Text = temp.MaLoaiTaiSan;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenLoaiTaiSan;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                LoaiTaiSan temp = new LoaiTaiSan();
                temp.MaLoaiTaiSan = txtMa.Text;
                temp.TenLoaiTaiSan = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = LoaiTaiSanBiz.AddLoaiTaiSan(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                LoaiTaiSan temp = new LoaiTaiSan();
                temp.MaLoaiTaiSan = txtMa.Text;
                temp.TenLoaiTaiSan = txtTen.Text;
                int kq = LoaiTaiSanBiz.EditLoaiTaiSan(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(LoaiTaiSan data)
        {
            bool kq = true;
            //mã loại tài sản rỗng
            if (string.IsNullOrEmpty(data.MaLoaiTaiSan))
            {
                MSG.ErrorStand("Bạn chưa nhập mã loại tài sản!");
                txtMa.Focus();
                return false;
            }
            //mã loại tài sản đã có trong cơ sở dữ liệu
            foreach (LoaiTaiSan item in frmDMLoaiTaiSan.Ldata)
            {
                if (item.MaLoaiTaiSan.ToUpper().Equals(txtMa.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã loại tài sản đã có trong cơ sở dữ liệu!");
                    txtMa.Focus();
                    return false;
                }
            }
            return kq;
        }
    }
}