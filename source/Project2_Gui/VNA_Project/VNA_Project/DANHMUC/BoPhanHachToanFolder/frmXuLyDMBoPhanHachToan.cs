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

namespace VNA_Project.DANHMUC.BoPhanHachToanFolder
{
    public partial class frmXuLyDMBoPhanHachToan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMBoPhanHachToan()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMBoPhanHachToan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                BoPhanHachToan temp = Utils.DataGridViewRow_to_BoPhanHachToan(dgvr);
                txtMa.Text = temp.MaBoPhanHachToan;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenBoPhanHachToan;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                BoPhanHachToan temp = new BoPhanHachToan();
                temp.MaBoPhanHachToan = txtMa.Text;
                temp.TenBoPhanHachToan = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = BoPhanHachToanBiz.AddBoPhanHachToan(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                BoPhanHachToan temp = new BoPhanHachToan();
                temp.MaBoPhanHachToan = txtMa.Text;
                temp.TenBoPhanHachToan = txtTen.Text;
                int kq = BoPhanHachToanBiz.EditBoPhanHachToan(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(BoPhanHachToan data)
        {
            bool kq = true;
            //mã bộ phận hạch toán rỗng
            if (string.IsNullOrEmpty(data.MaBoPhanHachToan))
            {
                MSG.ErrorStand("Bạn chưa nhập mã bộ phận hạch toán!");
                txtMa.Focus();
                return false;
            }
            //mã bộ phận hạch toán đã có trong cơ sở dữ liệu
            foreach (BoPhanHachToan item in frmDMBoPhanHachToan.Ldata)
            {
                if (item.MaBoPhanHachToan.ToUpper().Equals(txtMa.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã bộ phận hạch toán đã có trong cơ sở dữ liệu!");
                    txtMa.Focus();
                    return false;
                }
            }
            return kq;
        }
    }
}