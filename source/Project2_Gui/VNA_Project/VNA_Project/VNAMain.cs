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
        }

        private void btnDMNguonVon_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.NguonVonFolder.frmDMNguonVon frm = new DANHMUC.NguonVonFolder.frmDMNguonVon();
            frm.ShowDialog();
        }

        private void btnDMLyDoTangGiamTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.LyDoTangGiamTaiSanFolder.frmDMLyDoTangGiamTaiSan frm = new DANHMUC.LyDoTangGiamTaiSanFolder.frmDMLyDoTangGiamTaiSan();
            frm.ShowDialog();
        }

        private void btnDMLoaiTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.LoaiTaiSanFolder.frmDMLoaiTaiSan frm = new DANHMUC.LoaiTaiSanFolder.frmDMLoaiTaiSan();
            frm.ShowDialog();
        }

        private void btnDMPhanNhomTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.PhanNhomTaiSanFolder.frmDMPhanNhomTaiSan frm = new DANHMUC.PhanNhomTaiSanFolder.frmDMPhanNhomTaiSan();
            frm.ShowDialog();
        }

        private void btnDMThietBi_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.ThietBiFolder.frmDMThietBi frm = new DANHMUC.ThietBiFolder.frmDMThietBi();
            frm.ShowDialog();
        }

        private void btnDMBoPhanSDTSCD_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.BoPhanSuDungFolder.frmDMBoPhanSuDung frm = new DANHMUC.BoPhanSuDungFolder.frmDMBoPhanSuDung();
            frm.ShowDialog();
        }
    }
}