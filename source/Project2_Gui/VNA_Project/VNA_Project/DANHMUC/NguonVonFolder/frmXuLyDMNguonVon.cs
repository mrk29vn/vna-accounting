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

namespace VNA_Project.DANHMUC.NguonVonFolder
{
    public partial class frmXuLyDMNguonVon : Qios.DevSuite.Components.Ribbon.QRibbonForm 
    {
        #region khai báo
        bool Them = true;
        #endregion

        public frmXuLyDMNguonVon()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyDMNguonVon(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                NguonVon temp = Utils.DataGridViewRow_to_NguonVon(dgvr);
                txtMaNguonVon.Text = temp.MaNguonVon;
                txtMaNguonVon.Enabled = false;
                txtTenNguonVon.Text = temp.TenNguonVon;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
                NguonVon temp = new NguonVon();
                temp.MaNguonVon = txtMaNguonVon.Text;
                temp.TenNguonVon = txtTenNguonVon.Text;
                int kq = NguonVonBiz.AddNguonVon(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                NguonVon temp = new NguonVon();
                temp.MaNguonVon = txtMaNguonVon.Text;
                temp.TenNguonVon = txtTenNguonVon.Text;
                int kq = NguonVonBiz.EditNguonVon(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(NguonVon data)
        {
            bool kq = false;
            if (string.IsNullOrEmpty(data.MaNguonVon))
            {
                MSG.ErrorStand("Bạn chưa nhập mã nguồn vốn!");
                txtMaNguonVon.Focus();
                return false;
            }
            return kq;
        }
    }
}