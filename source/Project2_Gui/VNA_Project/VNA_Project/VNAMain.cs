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
            DM_NguonVon();
        }
        private void mnDM_NguonVon_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_NguonVon();
        }

        private void btnDMLyDoTangGiamTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_LyDoTangGiamTS();
        }
        private void mnDM_LyDoTangGiamTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_LyDoTangGiamTS();
        }

        private void btnDMLoaiTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_LoaiTS();
        }
        private void mnDM_LoaiTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_LoaiTS();
        }

        private void btnDMPhanNhomTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_PhanNhomTS();
        }
        private void mnDM_PhanNhomTS_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_PhanNhomTS();
        }

        private void btnDMThietBi_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_ThietBi();
        }
        private void mnDM_ThietBi_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_ThietBi();
        }

        private void btnDMBoPhanSDTSCD_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_BoPhanSDTSCD();
        }
        private void mnDM_BoPhanSDTSCD_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_BoPhanSDTSCD();
        }

        private void mnDM_BoPhanHachToan_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_BoPhanHachToan();
        }

        private void mnDM_PhanXuong_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_PhanXuong();
        }

        private void mnDM_Phi_ItemActivated(object sender, QCompositeEventArgs e)
        {
            DM_Phi();
        }

        #region Function
        private static void DM_NguonVon()
        {
            VNA_Project.DANHMUC.NguonVonFolder.frmDMNguonVon frm = new DANHMUC.NguonVonFolder.frmDMNguonVon();
            frm.ShowDialog();
        }
        private static void DM_LyDoTangGiamTS()
        {
            VNA_Project.DANHMUC.LyDoTangGiamTaiSanFolder.frmDMLyDoTangGiamTaiSan frm = new DANHMUC.LyDoTangGiamTaiSanFolder.frmDMLyDoTangGiamTaiSan();
            frm.ShowDialog();
        }
        private static void DM_LoaiTS()
        {
            VNA_Project.DANHMUC.LoaiTaiSanFolder.frmDMLoaiTaiSan frm = new DANHMUC.LoaiTaiSanFolder.frmDMLoaiTaiSan();
            frm.ShowDialog();
        }
        private static void DM_PhanNhomTS()
        {
            VNA_Project.DANHMUC.PhanNhomTaiSanFolder.frmDMPhanNhomTaiSan frm = new DANHMUC.PhanNhomTaiSanFolder.frmDMPhanNhomTaiSan();
            frm.ShowDialog();
        }
        private static void DM_ThietBi()
        {
            VNA_Project.DANHMUC.ThietBiFolder.frmDMThietBi frm = new DANHMUC.ThietBiFolder.frmDMThietBi();
            frm.ShowDialog();
        }
        private static void DM_BoPhanSDTSCD()
        {
            VNA_Project.DANHMUC.BoPhanSuDungFolder.frmDMBoPhanSuDung frm = new DANHMUC.BoPhanSuDungFolder.frmDMBoPhanSuDung();
            frm.ShowDialog();
        }
        //------------------------------------------
        private static void DM_BoPhanHachToan()
        {
            VNA_Project.DANHMUC.BoPhanHachToanFolder.frmDMBoPhanHachToan frm = new DANHMUC.BoPhanHachToanFolder.frmDMBoPhanHachToan();
            frm.ShowDialog();
        }
        private static void DM_PhanXuong()
        {
            VNA_Project.DANHMUC.PhanXuongFolder.frmDMPhanXuong frm = new DANHMUC.PhanXuongFolder.frmDMPhanXuong();
            frm.ShowDialog();
        }
        private static void DM_Phi()
        {
            VNA_Project.DANHMUC.PhiFolder.frmDMPhi frm = new DANHMUC.PhiFolder.frmDMPhi();
            frm.ShowDialog();
        }
        #endregion

        private void btnNVTaiSan_ItemActivated(object sender, QCompositeEventArgs e)
        {
            VNA_Project.DANHMUC.TaiSanFolder.frmDMTaiSan frm = new DANHMUC.TaiSanFolder.frmDMTaiSan();
            frm.ShowDialog();
        }
    }
}