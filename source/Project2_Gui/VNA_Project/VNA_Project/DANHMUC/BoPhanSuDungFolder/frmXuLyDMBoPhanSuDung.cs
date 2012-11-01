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

namespace VNA_Project.DANHMUC.BoPhanSuDungFolder
{
    public partial class frmXuLyDMBoPhanSuDung : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMBoPhanSuDung()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMBoPhanSuDung(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                BoPhanSuDung temp = Utils.DataGridViewRow_to_BoPhanSuDung(dgvr);
                txtMa.Text = temp.MaBoPhanSuDung;
                txtMa.Enabled = false;
                txtTen.Text = temp.TenBoPhanSuDung;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                BoPhanSuDung temp = new BoPhanSuDung();
                temp.MaBoPhanSuDung = txtMa.Text;
                temp.TenBoPhanSuDung = txtTen.Text;

                if (!CheckLoi(temp)) return;

                int kq = BoPhanSuDungBiz.AddBoPhanSuDung(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                BoPhanSuDung temp = new BoPhanSuDung();
                temp.MaBoPhanSuDung = txtMa.Text;
                temp.TenBoPhanSuDung = txtTen.Text;
                int kq = BoPhanSuDungBiz.EditBoPhanSuDung(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(BoPhanSuDung data)
        {
            bool kq = true;
            //mã bộ phận sử dụng rỗng
            if (string.IsNullOrEmpty(data.MaBoPhanSuDung))
            {
                MSG.ErrorStand("Bạn chưa nhập mã bộ phận sử dụng!");
                txtMa.Focus();
                return false;
            }
            //mã bộ phận sử dụng đã có trong cơ sở dữ liệu
            foreach (BoPhanSuDung item in frmDMBoPhanSuDung.Ldata)
            {
                if (item.MaBoPhanSuDung.ToUpper().Equals(txtMa.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã bộ phận sử dụng đã có trong cơ sở dữ liệu!");
                    txtMa.Focus();
                    return false;
                }
            }
            return kq;
        }
    }
}