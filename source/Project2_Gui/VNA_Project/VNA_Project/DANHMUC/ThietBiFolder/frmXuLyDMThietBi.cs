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

namespace VNA_Project.DANHMUC.ThietBiFolder
{
    public partial class frmXuLyDMThietBi : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMThietBi()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMThietBi(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                ThietBi temp = Utils.DataGridViewRow_to_ThietBi(dgvr);
                txtMa.Text = temp.MaThietBi;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenThietBi;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                ThietBi temp = new ThietBi();
                temp.MaThietBi = txtMa.Text;
                temp.TenThietBi = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = ThietBiBiz.AddThietBi(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                ThietBi temp = new ThietBi();
                temp.MaThietBi = txtMa.Text;
                temp.TenThietBi = txtTen.Text;
                int kq = ThietBiBiz.EditThietBi(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(ThietBi data)
        {
            bool kq = true;
            //mã thiết bị rỗng
            if (string.IsNullOrEmpty(data.MaThietBi))
            {
                MSG.ErrorStand("Bạn chưa nhập mã thiết bị!");
                txtMa.Focus();
                return false;
            }
            //mã thiết bị đã có trong cơ sở dữ liệu
            foreach (ThietBi item in frmDMThietBi.Ldata)
            {
                if (item.MaThietBi.ToUpper().Equals(txtMa.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã thiết bị đã có trong cơ sở dữ liệu!");
                    txtMa.Focus();
                    return false;
                }
            }
            return kq;
        }
    }
}