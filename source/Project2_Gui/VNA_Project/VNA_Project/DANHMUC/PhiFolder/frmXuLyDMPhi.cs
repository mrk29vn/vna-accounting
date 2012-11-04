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

namespace VNA_Project.DANHMUC.PhiFolder
{
    public partial class frmXuLyDMPhi : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMPhi()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMPhi(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                Phi temp = Utils.DataGridViewRow_to_Phi(dgvr);
                txtMa.Text = temp.MaPhi;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenPhi;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                Phi temp = new Phi();
                temp.MaPhi = txtMa.Text;
                temp.TenPhi = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = PhiBiz.AddPhi(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                Phi temp = new Phi();
                temp.MaPhi = txtMa.Text;
                temp.TenPhi = txtTen.Text;
                int kq = PhiBiz.EditPhi(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(Phi data)
        {
            bool kq = true;
            //mã phí rỗng
            if (string.IsNullOrEmpty(data.MaPhi))
            {
                MSG.ErrorStand("Bạn chưa nhập mã phí!");
                txtMa.Focus();
                return false;
            }
            //mã phí đã có trong cơ sở dữ liệu
            foreach (Phi item in frmDMPhi.Ldata)
            {
                if (item.MaPhi.ToUpper().Equals(txtMa.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã phí đã có trong cơ sở dữ liệu!");
                    txtMa.Focus();
                    return false;
                }
            }
            return kq;
        }
    }
}