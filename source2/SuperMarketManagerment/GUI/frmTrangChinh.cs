using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace GUI
{
    public partial class frmTrangChinh : Form
    {
        public frmTrangChinh()
        {
            InitializeComponent();
            ucTrangChinh trangchinh = new ucTrangChinh();
            trangchinh.lnkNhomHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhomHangHoa_MouseDown);
            trangchinh.lnkHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkHangHoa_MouseDown);
            trangchinh.lnkKhachHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhachHang_MouseDown);
            trangchinh.lnkKhoHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhoHang_MouseDown);
            trangchinh.lnkNhanVien.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhanVien_MouseDown);
            trangchinh.lnkNhaCungCap.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhaCungCap_MouseDown);
            trangchinh.lnkKhoanMuc.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhoanMuc_MouseDown);
            trangchinh.lnkTienTe.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkTienTe_MouseDown);
            //trangchinh.lnkTaiKhoanKT.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkTaiKhoanKT_MouseDown);
            trangchinh.lnkDonDatHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkDonDatHang_MouseDown);
            trangchinh.lnkNhapKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhapKho_MouseDown);
            trangchinh.lnkKhachHangTraLai.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKhachHangTraLai_MouseDown);
            trangchinh.lnkBanBuon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkBanBuon_MouseDown);
            trangchinh.lnkBanLe.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkBanLe_MouseDown);
            trangchinh.lnkTraLaiNCC.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkTraLaiNCC_MouseDown);
            trangchinh.lnkPhieuThu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkPhieuThu_MouseDown);
            trangchinh.lnkSoQuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkSoQuy_MouseDown);
            trangchinh.lnkPhieuChi.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkPhieuChi_MouseDown);
            trangchinh.lnkDieuChuyenKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkDieuChuyenKho_MouseDown);
            trangchinh.lnkXNDieuChuyenKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkXNDieuChuyenKho_MouseDown);
            trangchinh.lnkKiemKeKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKiemKeKho_MouseDown);
            trangchinh.lnkInTemMaVach.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkInTemMaVach_MouseDown);
            trangchinh.lnkPhieuXuatHuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkPhieuXuatHuy_MouseDown);
            trangchinh.lnklbPhongBan.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnklbPhongBan_MouseDown);
            //trangchinh.lnkNhomTKKT.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhomTKKT_MouseDown);
            trangchinh.lnkDonViTinh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkDonViTinh_MouseDown);
            trangchinh.lnkThue.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkThue_MouseDown);
            trangchinh.lnkLoaiHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkLoaiHangHoa_MouseDown);
            trangchinh.BCTonKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCTonKho_MouseDown);
            trangchinh.BCDoanhThu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCDoanhThu_MouseDown);
            trangchinh.BCXuatHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCXuatHang_MouseDown);
            trangchinh.BCNhapHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCNhapHang_MouseDown);
            trangchinh.BCCongNo.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCCongNo_MouseDown);
            trangchinh.lnkNhapSoDuTonKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkNhapSoDuTonKho_MouseDown);
            trangchinh.lnkXNPhieuXuatHuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkXNPhieuXuatHuy_MouseDown);
            trangchinh.lnkKetChuyenSoDu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkKetChuyenSoDu_MouseDown);
            trangchinh.lnkSoDuDauKy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lnkSoDuDauKy_MouseDown);
           
            elementHost_Trangchinh.Child = trangchinh;
        }

        void lnkSoDuDauKy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoDuKhachHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoDuKhachHang"))
            {
                return;
            }
            Form frm = new frmSoDuKhachHang();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        void lnkKetChuyenSoDu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            //if (!frmDangNhap.User.Administrator && !CheckQuyen("frmKetChuyenSoDu", 1))
            //{
            //    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
            //    return;
            //}
            if (!Check("frmKetChuyenSoDu"))
            {
                return;
            }
            Form frm = new frmKetChuyenSoDu();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        void lnkXNPhieuXuatHuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmXacNhanPhieuXuatHuy", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmXacNhanPhieuXuatHuy"))
            {
                return;
            }
            Form frm = new frmXacNhanPhieuXuatHuy();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }
        void lnkNhapSoDuTonKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoDuKhoHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoDuKhoHang"))
            {
                return;
            }
            Form frm = new frmSoDuKhoHang();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }
        void lnkLoaiHangHoa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyLoaiHangHoa", 1))
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
            fr.Show(); closeformmain();
        }
        void lnkThue_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyThue", 1))
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
            frm.Show(); closeformmain();
        }
        void BCCongNo_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmBaoCao.BaoCao = "CongNo";
            if (!Check("frmBaoCao"))
            {
                return;
            }
            frmBaoCao kkk = new frmBaoCao("CongNo");
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
            this.Close();
        }
        void BCNhapHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmBaoCao.BaoCao = "NhapHang";
            if (!Check("frmBaoCao"))
            {
                return;
            }
            frmBaoCao kkk = new frmBaoCao("NhapHang");
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
            this.Close();
        }
        void BCXuatHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmBaoCao.BaoCao = "XuatHang";
            if (!Check("frmBaoCao"))
            {
                return;
            }
            frmBaoCao kkk = new frmBaoCao("XuatHang");
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
            this.Close();
        }
        void BCDoanhThu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmBaoCao.BaoCao = "DoanhThu";
            if (!Check("frmBaoCao"))
            {
                return;
            }
            frmBaoCao kkk = new frmBaoCao("DoanhThu");
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
            this.Close();
        }
        void BCTonKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmBaoCao.BaoCao = "TonKho";
            if (!Check("frmBaoCao"))
            {
                return;
            }
            frmBaoCao kkk = new frmBaoCao("TonKho");
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
            this.Close();
        }
        void lnkDonViTinh_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyDVT", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyDVT"))
            {
                return;
            }
            frmQuanLyDVT fr = new frmQuanLyDVT();
            fr.MdiParent = this.MdiParent;
            fr.Show();
        }
        void lnkNhomTKKT_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhomTKKeToan", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhomTKKeToan"))
            {
                return;
            }
            frmQuanLyNhomTKKeToan fr = new frmQuanLyNhomTKKeToan();
            fr.MdiParent = this.MdiParent;
            fr.Show(); closeformmain();
        }
        void lnklbPhongBan_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlyphongban", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlyphongban"))
            {
                return;
            }
            frmQuanlyphongban fr = new frmQuanlyphongban();
            fr.MdiParent = this.MdiParent;
            fr.Show(); closeformmain();
        }
        void lnkPhieuXuatHuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuXuatHuy", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuXuatHuy"))
            {
                return;
            }
            Form fr = new frmQuanLyPhieuXuatHuy();
            fr.MdiParent = this.MdiParent;
            fr.Show(); closeformmain();
        }
        void lnkInTemMaVach_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
              if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyMaVach", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }

            try
            {
                if (!Check("frmQuanLyMaVach"))
                {
                    return;
                }
                frmQuanLyMaVach frm = new frmQuanLyMaVach();
                frm.ShowDialog();
                closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkKiemKeKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKiemKeKho", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }

            try
            {
                if (!Check("frmQuanLyKiemKeKho"))
                {
                    return;
                }
                frmQuanLyKiemKeKho kkk = new frmQuanLyKiemKeKho();
                kkk.MdiParent = this.MdiParent;
                kkk.Show();
                closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkXNDieuChuyenKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmHienThi_XacNhanDieuChuyenKho", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmHienThi_XacNhanDieuChuyenKho"))
            {
                return;
            }
            frmHienThi_XacNhanDieuChuyenKho xndck = new frmHienThi_XacNhanDieuChuyenKho();
            xndck.MdiParent = this.MdiParent;
            xndck.Show(); closeformmain();

        }
        void lnkDieuChuyenKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmHienThi_DieuChuyenKhoNoiBo", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmHienThi_DieuChuyenKhoNoiBo"))
            {
                return;
            }
            frmHienThi_DieuChuyenKhoNoiBo htdcknb = new frmHienThi_DieuChuyenKhoNoiBo();

            htdcknb.MdiParent = this.MdiParent;
            htdcknb.Show(); closeformmain();
        }
        void lnkPhieuChi_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuChi", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuChi"))
            {
                return;
            }
            frmQuanLyPhieuChi ct = new frmQuanLyPhieuChi();
            ct.MdiParent = this.MdiParent;
            ct.Show(); closeformmain();
        }
        void lnkSoQuy_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoquy", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoquy"))
            {
                return;
            }
            frmSoquy sq = new frmSoquy();
            sq.MdiParent = this.MdiParent;
            sq.Show(); closeformmain();
        }
        void lnkPhieuThu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuThu", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuThu"))
            {
                return;
            }
            frmQuanLyPhieuThu tt = new frmQuanLyPhieuThu();
            tt.MdiParent = this.MdiParent;
            tt.Show(); closeformmain();
        }
        void lnkTraLaiNCC_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyTraLaiNhaCungCap", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                if (!Check("frmHienThi_TraLaiNhaCungCap"))
                {
                    return;
                }
                frmQuanLyTraLaiNhaCungCap httlncc = new frmQuanLyTraLaiNhaCungCap();
                httlncc.MdiParent = this.MdiParent;
                httlncc.Show(); closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
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
            frmQuanLyBanLe htbl = new frmQuanLyBanLe();
            htbl.MdiParent = this.MdiParent;
            htbl.Show();
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
            frmQuanLyBanBuon htbb = new frmQuanLyBanBuon();

            htbb.MdiParent = this.MdiParent;
            htbb.Show();
        }
        void lnkKhachHangTraLai_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHangTraLaiHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                if (!Check("frmQuanLyKhachHangTraLaiHang"))
                {
                    return;
                }
                frmQuanLyKhachHangTraLaiHang fr = new frmQuanLyKhachHangTraLaiHang();
                fr.MdiParent = this.MdiParent;
                fr.Show(); closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkNhapKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhapKho", 1))
                {

                    MessageBox.Show(" Không có quyền vào chức năng này.");
                    return;
                }
                if (!Check("frmHienThi_HoaDonNhap"))
                {
                    return;
                }
                frmQuanLyNhapKho xlnm = new frmQuanLyNhapKho();

                xlnm.MdiParent = this.MdiParent;
                xlnm.Show(); this.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkDonDatHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyDonDatHang", 1))
                {

                    MessageBox.Show(" Không có quyền vào chức năng này.");
                    return;
                }
                if (!Check("frmHienThi_DonDatHang"))
                {
                    return;
                }
                frmQuanLyDonDatHang htddh = new frmQuanLyDonDatHang();
                htddh.MdiParent = this.MdiParent;
                htddh.Show(); this.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }

        }
        void lnkTaiKhoanKT_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyTaiKhoanKeToan", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyTaiKhoanKeToan"))
            {
                return;
            }
            frmQuanLyTaiKhoanKeToan qltkkt = new frmQuanLyTaiKhoanKeToan();
            qltkkt.MdiParent = this.MdiParent;
            qltkkt.Show(); closeformmain();
        }
        void lnkTienTe_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlytiente", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlytiente"))
            {
                return;
            }
            frmQuanlytiente qltt = new frmQuanlytiente();
            qltt.MdiParent = this.MdiParent;
            qltt.Show(); closeformmain();
        }
        void lnkKhoanMuc_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlyKMthuchi", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlyKMthuchi"))
            {
                return;
            }
            frmQuanlyKMthuchi fr = new frmQuanlyKMthuchi();
            fr.MdiParent = this.MdiParent;
            fr.Show(); closeformmain();
        }
        void lnkNhaCungCap_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhaCungCap", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhaCungCap"))
            {
                return;
            }
            frmQuanLyNhaCungCap ncc = new frmQuanLyNhaCungCap();
            ncc.MdiParent = this.MdiParent;
            ncc.Show(); closeformmain();
        }
        void lnkNhanVien_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlynhanvien", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlynhanvien"))
            {
                return;
            }
            frmQuanlynhanvien qlnv = new frmQuanlynhanvien();
            qlnv.MdiParent = this.MdiParent;
            qlnv.Show(); closeformmain();
        }
        void lnkKhoHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhoHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                if (!Check("frmQuanLyKhoHang"))
                {
                    return;
                }
                frmQuanLyKhoHang kh = new frmQuanLyKhoHang();
                kh.MdiParent = this.MdiParent;
                kh.Show(); closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        void lnkKhachHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyKhachHang"))
            {
                return;
            }
            frmQuanLyKhachHang kh = new frmQuanLyKhachHang();
            kh.MdiParent = this.MdiParent;
            kh.Show(); closeformmain();
        }
        void lnkHangHoa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyHangHoa", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyHangHoa"))
            {
                return;
            }
            frmQuanLyHangHoa qlhh = new frmQuanLyHangHoa();
            qlhh.MdiParent = this.MdiParent;
            qlhh.Show(); closeformmain();
        }
        void lnkNhomHangHoa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhomHangHoa", 1))
            {
                MessageBox.Show("Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhomHangHoa"))
            {
                return;
            }
            frmQuanLyNhomHangHoa nhh = new frmQuanLyNhomHangHoa();
            nhh.MdiParent = this.MdiParent;
            nhh.Show(); closeformmain();
        }


        public bool Check(string form)
        {
            Form[] frm = this.ParentForm.MdiChildren;
            foreach (Form temp in frm)
            {
                if (temp.Name.Equals(form)){
                    closeall(temp.Name);
                    temp.Activate();
                    
                    return false;
                }
            }
            return true;
        }



        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Check("frmQuanLyNhomHang"))
            {
                return;
            }
            frmQuanLyNhomHangHoa nhh = new frmQuanLyNhomHangHoa();
                nhh.MdiParent = this.MdiParent;
                nhh.Show();
        }

   
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Check("frmQuanlyKMthuchi"))
            {
                return;
            }
            frmQuanlyKMthuchi fr = new frmQuanlyKMthuchi();
                fr.MdiParent = this.MdiParent;
                fr.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Check("frmQuanlytiente"))
            {
                return;
            }
            frmQuanlytiente qltt = new frmQuanlytiente();
                qltt.MdiParent = this.MdiParent;
                qltt.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Check("frmQuanLyTaiKhoanKeToan"))
            {
                return;
            }
            frmQuanLyTaiKhoanKeToan qltkkt = new frmQuanLyTaiKhoanKeToan();
                qltkkt.MdiParent = this.MdiParent;
                qltkkt.Show();
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyMaVach", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }

            try
            {
                if (!Check("frmQuanLyMaVach"))
                {
                    return;
                }
                frmQuanLyMaVach frm = new frmQuanLyMaVach();
                frm.ShowDialog();
                closeformmain();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            frm.Show(); closeformmain();
        }


    


        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Check("frmBCDoanhThuHangHoa"))
            {
                return;
            }
            frmBCDoanhThuHangHoa kkk = new frmBCDoanhThuHangHoa();
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
            this.Close();
        }



        private void linkLabel33_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBCCongNoNhaCungCap frm = new frmBCCongNoNhaCungCap();
            frm.ShowDialog();
        }

        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBCCongNoKhachHang frm = new frmBCCongNoKhachHang();
            frm.ShowDialog();
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lamtransoft.com/");
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

      
        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyBanLe", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyBanLe"))
            {
                return;
            }
            Form frm = new frmQuanLyBanLe();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoDuSoQuy", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoDuSoQuy"))
            {
                return;
            }
            Form frm = new frmSoDuSoQuy();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            Form frm = new frmKetChuyenSoDu();
            frm.ShowDialog();
            closeall(frm.Name);
        }
        void closeall(string Name)
        {
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if(!item.Name.Equals(Name))
                    item.Close();
            }
        }

    

        private void linkLabel9_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyDVT", 1))
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
            frm.Show(); closeformmain();
        }

        private void linkLabel11_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyDonDatHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyDonDatHang"))
            {
                return;
            }
            frmQuanLyDonDatHang frm = new frmQuanLyDonDatHang();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        private void linkLabel10_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhapKho", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhapKho"))
            {
                return;
            }
            frmQuanLyNhapKho frm = new frmQuanLyNhapKho();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyBanBuon", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyBanBuon"))
            {
                return;
            }
            frmQuanLyBanBuon frm = new frmQuanLyBanBuon();
            frm.MdiParent = this.MdiParent;
            frm.Show(); closeformmain();
        }

        private void linkLabel37_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCTonKhoTheoKho", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCTonKhoTheoKho"))
            {
                return;
            }
            frmBCTonKhoTheoKho frm = new frmBCTonKhoTheoKho();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void linkLabel25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCTonKhoTheoNhomHang", 1))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCTonKhoTheoNhomHang"))
            {
                return;
            }
            frmBCTonKhoTheoNhomHang frm = new frmBCTonKhoTheoNhomHang();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }


        private void frmTrangChinh_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            int Heights = Screen.PrimaryScreen.Bounds.Height;
            int Widths = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(0, 0);
            this.Width = Widths - 4;
            this.Height = Heights - 64;

        }

        void closeformmain()
        {
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item.Name.Equals("frmTrangChinh") || item.Name.Equals("frmDanhMuc") || item.Name.Equals("frmNghiepVu") || item.Name.Equals("frmKhoHang") || item.Equals("frmBaoCao"))
                {
                    item.Close();
                }
            }
        }
    }
}
