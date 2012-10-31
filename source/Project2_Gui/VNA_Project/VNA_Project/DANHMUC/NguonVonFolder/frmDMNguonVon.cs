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
    public partial class frmDMNguonVon : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        List<NguonVon> Ldata = new List<NguonVon>();
        #endregion

        public frmDMNguonVon()
        {
            InitializeComponent();
        }

        private void frmDMNguonVon_Load(object sender, EventArgs e)
        {
            try
            {
                //Ldata = NguonVonBiz.getListNguonVon();
                //DataGridView.DataSource = Ldata.ToArray();
                //FixDataGirdView();
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Function
        void FixDataGirdView()
        {
            FixDataGirdView(DataGridView);
        }
        void FixDataGirdView(System.Windows.Forms.DataGridView DataGridView)
        {
            for (int j = 1; j < DataGridView.ColumnCount; j++) DataGridView.Columns[j].Visible = false;
            DataGridView.ReadOnly = true;

            DataGridView.Columns["MaNguonVon"].HeaderText = "Mã nguồn vốn";
            DataGridView.Columns["TenNguonVon"].HeaderText = "Tên nguồn vốn";

            DataGridView.Columns["MaNguonVon"].Visible = true;
            DataGridView.Columns["TenNguonVon"].Visible = true;

            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.RowHeadersVisible = false;
        }
        #endregion
    }
}