using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Qios.DevSuite.Components;
using VNA_Project.Entity;

namespace VNA_Project
{
    public partial class VNAMain : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        public VNAMain()
        {
            InitializeComponent();
            List<Account> temp = BIZ.AccountBiz.getListAccount();
            //dataGridView1.DataSource = temp.ToArray();
        }

        //void FixDataGirdView()
        //{
        //    FixDataGirdView(dataGridView1);  //datagridVIEW
        //}
        void FixDataGirdView(System.Windows.Forms.DataGridView DataGridView)
        {
            for (int j = 1; j < DataGridView.ColumnCount; j++) DataGridView.Columns[j].Visible = false;
            DataGridView.ReadOnly = true;

            DataGridView.Columns["STT"].HeaderText = "STT";
            DataGridView.Columns["Chon"].HeaderText = "Chọn";
            DataGridView.Columns["TenTK"].HeaderText = "Tên tờ khai";
            DataGridView.Columns["KyTinhThueVIEW"].HeaderText = "Kỳ tính thuế";
            DataGridView.Columns["Loai"].HeaderText = "Loại";

            DataGridView.Columns["STT"].Visible = true;
            DataGridView.Columns["Chon"].Visible = true;
            DataGridView.Columns["TenTK"].Visible = true;
            DataGridView.Columns["KyTinhThueVIEW"].Visible = true;
            DataGridView.Columns["Loai"].Visible = true;

            DataGridView.Columns["STT"].Width = 45;
            DataGridView.Columns["Chon"].Width = 45;
            DataGridView.Columns["TenTK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridView.Columns["KyTinhThueVIEW"].Width = 90;
            DataGridView.Columns["Loai"].Width = 90;

            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.RowHeadersVisible = false;
        }

        private void btnDMNguonVon_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.NguonVonFolder.frmDMNguonVon frm = new DANHMUC.NguonVonFolder.frmDMNguonVon();
            frm.ShowDialog();
        }
    }
}