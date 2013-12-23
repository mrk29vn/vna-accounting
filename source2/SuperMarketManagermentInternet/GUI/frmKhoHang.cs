using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmKhoHang : Form
    {
        public frmKhoHang()
        {
            InitializeComponent();
            panel2.Width = Screen.PrimaryScreen.WorkingArea.Width;
            panel2.Height = Screen.PrimaryScreen.WorkingArea.Height;
            try
            {
                ucKhoHang khohang = new ucKhoHang();
                khohang.lnkDieuChuyenKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkDieuChuyenKho_MouseDown);
                khohang.lnkXNDieuChuyenKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkXNDieuChuyenKho_MouseDown);
                khohang.lnkKiemKeKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKiemKeKho_MouseDown);
                khohang.lnkInTemMaVach.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkInTemMaVach_MouseDown);
                khohang.lnkNhapSoDuTonKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhapSoDuTonKho_MouseDown);
                khohang.lnkPhieuXuatHuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkPhieuXuatHuy_MouseDown);
                khohang.lnkXNPhieuXuatHuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkXNPhieuXuatHuy_MouseDown);
                elementHost_KhoHang.Child = khohang;
            }
            catch 
            {
            }
        }

        void lnkXNPhieuXuatHuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmXacNhanPhieuXuatHuy", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmXacNhanPhieuXuatHuy"))
            {
                return;
            }
            frmXacNhanPhieuXuatHuy frm = new frmXacNhanPhieuXuatHuy();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }

        void lnkPhieuXuatHuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuXuatHuy", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuXuatHuy"))
            {
                return;
            }
            frmQuanLyPhieuXuatHuy frm = new frmQuanLyPhieuXuatHuy();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }

        void lnkNhapSoDuTonKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoDuKhoHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoDuKhoHang"))
            {
                return;
            }
            frmSoDuKhoHang frm = new frmSoDuKhoHang();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkInTemMaVach_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyMaVach", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }

            try
            {
                frmQuanLyMaVach frm = new frmQuanLyMaVach();
                frm.ShowDialog();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkKiemKeKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKiemKeKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            //frmQuanLyKiemKeKho frm = new frmQuanLyKiemKeKho();
            //closeall(frm.Name);
            //if (Application.OpenForms[frm.Name] == null)
            //{
            //    frm.MdiParent = this.MdiParent;
            //    frm.Show();
            //}
            //else
            //{
            //    Application.OpenForms[frm.Name].Focus();
            //}

            if (!Check("frmHienThi_KiemKeKho"))
            {
                return;
            }
            frmQuanLyKiemKeKho frm = new frmQuanLyKiemKeKho();
            closeall(frm.Name);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        void lnkXNDieuChuyenKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmHienThi_XacNhanDieuChuyenKho", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            //frmHienThi_XacNhanDieuChuyenKho frm = new frmHienThi_XacNhanDieuChuyenKho();
            //closeall(frm.Name);
            //if (Application.OpenForms[frm.Name] == null)
            //{
            //    frm.MdiParent = this.MdiParent;
            //    frm.Show();
            //}
            //else
            //{
            //    Application.OpenForms[frm.Name].Focus();
            //}

            if (!Check("frmHienThi_XacNhanDieuChuyenKho"))
            {
                return;
            }
            frmHienThi_XacNhanDieuChuyenKho frm = new frmHienThi_XacNhanDieuChuyenKho();
            closeall(frm.Name);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        void lnkDieuChuyenKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmHienThi_DieuChuyenKhoNoiBo", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            //frmHienThi_DieuChuyenKhoNoiBo frm = new frmHienThi_DieuChuyenKhoNoiBo();
            //if (Application.OpenForms[frm.Name] == null)
            //{
            //    frm.MdiParent = this.MdiParent;
            //    closeall(frm.Name);
            //    frm.Show();
            //}
            //else
            //{
            //    Application.OpenForms[frm.Name].Focus();
            //    closeall(frm.Name);
            //}

            if (!Check("frmHienThi_DieuChuyenKhoNoiBo"))
            {
                return;
            }
            frmHienThi_DieuChuyenKhoNoiBo frm = new frmHienThi_DieuChuyenKhoNoiBo();
            closeall(frm.Name);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        public bool Check(string form)
        {
            Form[] frm = this.MdiChildren;
            foreach (Form temp in frm)
            {
                if (temp.Name.Equals(form))
                {
                    temp.Activate();
                    closeall(temp.Name);
                    return false;
                }
            }
            return true;
        }
        void closeall(string Name)
        {
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (!item.Name.Equals(Name))
                    item.Close();
            }
        }


        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lamtransoft.com/");
        }


        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int Heights = Screen.PrimaryScreen.Bounds.Height;
            int Widths = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(0, 0);
            this.Width = Widths - 4;
            this.Height = Heights - 64;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://dhtvietnam.com");
        }

       
        void closeformmain()
        {
            if (this.MdiParent == null)
                return;
            if (this.MdiParent.MdiChildren == null)
                return;
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item.Name.Equals("frmTrangChinh") || item.Name.Equals("frmDanhMuc") || item.Name.Equals("frmNghiepVu") || item.Name.Equals("frmKhoHang") || item.Equals("frmBaoCao"))
                {
                    item.Close();
                }
            }
        }
        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXem;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenSua;
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXoa;
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenThem;
                        }
                        break;
                    }
            }
            return true;
        }



        private void lnkXacNhanDieuChuyenKho_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmHienThi_XacNhanDieuChuyenKho", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmHienThi_XacNhanDieuChuyenKho"))
            {
                return;
            }
            frmHienThi_XacNhanDieuChuyenKho frm = new frmHienThi_XacNhanDieuChuyenKho();
            
            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }

        private void lnkKiemKeKho_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKiemKeKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyKiemKeKho"))
            {
                return;
            }
            frmQuanLyKiemKeKho frm = new frmQuanLyKiemKeKho();
            
            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }

        private void lnkDieuChuyenKho_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmHienThi_DieuChuyenKhoNoiBo", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmHienThi_DieuChuyenKhoNoiBo"))
            {
                return;
            }
            frmHienThi_DieuChuyenKhoNoiBo frm = new frmHienThi_DieuChuyenKhoNoiBo();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }


    }
}
