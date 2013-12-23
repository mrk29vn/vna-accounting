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
    public partial class frmNghiepVu : Form
    {
        public frmNghiepVu()
        {
            InitializeComponent();
            panel2.Width = Screen.PrimaryScreen.WorkingArea.Width;
            panel2.Height = Screen.PrimaryScreen.WorkingArea.Height;
            try
            {

                ucNghiepVu nghiepvu = new ucNghiepVu();
                nghiepvu.lnkPhieuThu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkPhieuThu_MouseDown);
                nghiepvu.lnkPhieuChi.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkPhieuChi_MouseDown);
                nghiepvu.lnkSoQuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkSoQuy_MouseDown);
                nghiepvu.lnkBanBuon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkBanBuon_MouseDown);
                nghiepvu.lnkBanLe.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkBanLe_MouseDown);
                nghiepvu.lnkTraLaiNCC.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkTraLaiNCC_MouseDown);
                nghiepvu.lnkKhachHangTraLai.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhachHangTraLai_MouseDown);
                nghiepvu.lnkDonDatHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkDonDatHang_MouseDown);
                nghiepvu.lnkNhapKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhapKho_MouseDown);
                nghiepvu.lnkSoDuSoQuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkSoDuSoQuy_MouseDown);
                nghiepvu.lnkKetChuyenSoDu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKetChuyenSoDu_MouseDown);
                elementHost_NghiepVu.Child = nghiepvu;
            }
            catch
            {
            }
          
        }

        void lnkKetChuyenSoDu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            Form frm = new frmKetChuyenSoDu();
            closeall();
            frm.ShowDialog();
        }
        void lnkSoDuSoQuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoDuSoQuy", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoDuSoQuy"))
            {
                return;
            }
            Form frm = new frmSoDuSoQuy();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkNhapKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhapKho", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhapKho"))
            {
                return;
            }
            frmQuanLyNhapKho frm = new frmQuanLyNhapKho();
            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkDonDatHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyDonDatHang", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyDonDatHang"))
            {
                return;
            }
            frmQuanLyDonDatHang frm = new frmQuanLyDonDatHang();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkKhachHangTraLai_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHangTraLaiHang", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyKhachHangTraLaiHang"))
            {
                return;
            }
            frmQuanLyKhachHangTraLaiHang frm = new frmQuanLyKhachHangTraLaiHang();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkTraLaiNCC_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyTraLaiNhaCungCap", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyTraLaiNhaCungCap"))
            {
                return;
            }
            frmQuanLyTraLaiNhaCungCap frm = new frmQuanLyTraLaiNhaCungCap();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkBanLe_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyBanLe", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyBanLe"))
            {
                return;
            }
            frmQuanLyBanLe frm = new frmQuanLyBanLe();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkBanBuon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyBanBuon", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyBanBuon"))
            {
                return;
            }
            frmQuanLyBanBuon frm = new frmQuanLyBanBuon();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkSoQuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoquy", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoquy"))
            {
                return;
            }
            frmSoquy sq = new frmSoquy();

            sq.MdiParent = this.MdiParent;
            closeall(sq.Name);
            sq.Show(); closeformmain();
        }
        void lnkPhieuChi_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuChi", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuChi"))
            {
                return;
            }
            frmQuanLyPhieuChi ct = new frmQuanLyPhieuChi();

            ct.MdiParent = this.MdiParent;
            closeall(ct.Name);
            ct.Show(); closeformmain();
        }
        void lnkPhieuThu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuThu", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuThu"))
            {
                return;
            }
            frmQuanLyPhieuThu tt = new frmQuanLyPhieuThu();

            tt.MdiParent = this.MdiParent;
            closeall(tt.Name);
            tt.Show(); closeformmain();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lamtransoft.com/");
           
        }

        

        private void frmNghiepVu_Load(object sender, EventArgs e)
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
            //System.Diagnostics.Process.Start("http://dhtvietnam.com");
        }

    
        void closeformmain()
        {
            if (this.MdiParent == null)
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

    
        void closeall()
        {
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                item.Close();
            }
        }

    }
}
