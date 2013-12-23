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
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
        {
            InitializeComponent();
            try
            {
                ucDanhMuc danhmuc = new ucDanhMuc();
                danhmuc.lnkNhomHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhomHangHoa_MouseDown);
                danhmuc.lnkHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkHangHoa_MouseDown);
                danhmuc.lnkKhoHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhoHang_MouseDown);
                danhmuc.lnkKhachHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhachHang_MouseDown);
                danhmuc.lnkNhanVien.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhanVien_MouseDown);
                danhmuc.lnkNhaCungCap.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhaCungCap_MouseDown);
                danhmuc.lnkKhoanMuc.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhoanMuc_MouseDown);
                danhmuc.lnkTienTe.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkTienTe_MouseDown);
                danhmuc.lnkTaiKhoanKT.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkTaiKhoanKT_MouseDown);
                danhmuc.lnkLoaiHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkLoaiHangHoa_MouseDown);
                danhmuc.lnkDonViTinh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkDonViTinh_MouseDown);
                danhmuc.lnkThue.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkThue_MouseDown);
                danhmuc.lnkNhomTKKT.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhomTKKT_MouseDown);
                danhmuc.lnkcongty.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkcongty_MouseDown);
                danhmuc.lnkgoihang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkgoihang_MouseDown);
                //danhmuc.lnkquydoi.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkquydoi_MouseDown);
                elementHost_DanhMuc.Child = danhmuc;
            }
            catch 
            {
            }
        }

        void lnkquydoi_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (!frmDangNhap.User.Administrator && !new Common.Utilities().CheckQuyen("frmQuanLyQuyDoiDonViTinh", 1))
            //{
            //    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
            //    return;
            //}
            //if (!Check("frmQuanLyQuyDoiDonViTinh"))
            //{
            //    return;
            //}
            //Form frm = new frmQuanLyQuyDoiDonViTinh();
            //frm.MdiParent = this.MdiParent;
            //closeall(frm.Name);
            //frm.Show();
        }
        void lnkgoihang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !new Common.Utilities().CheckQuyen("frmQuanLyGoiHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyGoiHang"))
            {
                return;
            }
            Form frm = new frmQuanLyGoiHang();
            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show();
        }
        void lnkcongty_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !new Common.Utilities().CheckQuyen("frmQuanLyCongTy", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyCongTy"))
            {
                return;
            }
            Form frm = new frmQuanLyCongTy();
            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show();
        }
        void lnkNhomTKKT_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhomTKKeToan", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhomTKKeToan"))
            {
                return;
            }
            frmQuanLyNhomTKKeToan fr = new frmQuanLyNhomTKKeToan();
            closeall(fr.Name);
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }
        void lnkThue_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !new Common.Utilities().CheckQuyen("frmQuanLyThue", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyThue"))
            {
                return;
            }
            Form frm = new frmQuanLyThue();
            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show();
        }
        void lnkDonViTinh_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !new Common.Utilities().CheckQuyen("frmQuanLyDVT", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyDVT"))
            {
                return;
            }
            Form frm = new frmQuanLyDVT();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkLoaiHangHoa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !new Common.Utilities().CheckQuyen("frmQuanLyLoaiHangHoa", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyLoaiHangHoa"))
            {
                return;
            }
            Form fr = new frmQuanLyLoaiHangHoa();

            fr.MdiParent = this.MdiParent;
            closeall(fr.Name);
            fr.Show(); closeformmain();
        }
        void lnkTaiKhoanKT_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyTaiKhoanKeToan", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyTaiKhoanKeToan"))
            {
                return;
            }
            frmQuanLyTaiKhoanKeToan frm = new frmQuanLyTaiKhoanKeToan();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkTienTe_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlytiente", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlytiente"))
            {
                return;
            }
            frmQuanlytiente frm = new frmQuanlytiente();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkKhoanMuc_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlyKMthuchi", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlyKMthuchi"))
            {
                return;
            }
            Form frm = new frmQuanlyKMthuchi();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkNhaCungCap_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhaCungCap", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            if (!Check("frmQuanLyNhaCungCap"))
            {
                return;
            }
            frmQuanLyNhaCungCap frm = new frmQuanLyNhaCungCap();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkNhanVien_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlynhanvien", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            if (!Check("frmQuanlynhanvien"))
            {
                return;
            }
            frmQuanlynhanvien frm = new frmQuanlynhanvien();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkKhachHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHang", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            if (!Check("frmQuanLyKhachHang"))
            {
                return;
            }
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkKhoHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhoHang", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            try
            {
                if (!Check("frmHienThi_KhoHang"))
                {
                    return;
                }
                frmQuanLyKhoHang frm = new frmQuanLyKhoHang();

                frm.MdiParent = this.MdiParent;
                closeall(frm.Name);
                frm.Show();
                this.Close(); closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkHangHoa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyHangHoa", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            if (!Check("frmQuanLyHangHoa"))
            {
                return;
            }
            frmQuanLyHangHoa frm = new frmQuanLyHangHoa();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show(); closeformmain();
        }
        void lnkNhomHangHoa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhomHangHoa", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            if (!Check("frmQuanLyNhomHangHoa"))
            {
                return;
            }
            frmQuanLyNhomHangHoa frm = new frmQuanLyNhomHangHoa();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show();
            closeformmain();
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

 
        private void lnkNhomDoiTac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Check("frmQuanLyKhachHang"))
            {
                return;
            }
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();
            
                frm.MdiParent = this.MdiParent;
                closeall(frm.Name);
                frm.Show();
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lamtransoft.com/");
        }


        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            try
            {
                int Heights = Screen.PrimaryScreen.Bounds.Height;
                int Widths = Screen.PrimaryScreen.Bounds.Width;
                this.Location = new Point(0, 0);
                this.Width = Widths - 4;
                this.Height = Heights - 64;
            }
            catch 
            {
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://dhtvietnam.com");
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



        private void label1_Click(object sender, EventArgs e)
        {
            if (!Check("frmDanhMuc"))
            {
                return;
            }
            frmDanhMuc frm = new frmDanhMuc();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!Check("frmQuanLyHangHoa"))
            {
                return;
            }
            frmQuanLyHangHoa frm = new frmQuanLyHangHoa();

            frm.MdiParent = this.MdiParent;
            closeall(frm.Name);
            frm.Show();
        }
    }
}
