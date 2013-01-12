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
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
            TenDangNhap = "";
        }

        Panel pnlChucnang = new Panel();
        String[] listHome = new String[4];
        String[] listDanhMuc = new String[14];
        String[] listNghiepVu = new String[11];
        String[] listKhoHang = new String[7];
        String[] listBaoCao = new String[5];
        bool isClose = true;
        bool isFormClose = true;


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Server_Client.Client cl = new Server_Client.Client();
            //    // gán TCPclient
            //    System.Net.Sockets.TcpClient client1 = cl.Connect(Luu.IP, Luu.Ports);
            //    System.Net.Sockets.NetworkStream clientstrem = cl.SerializeObj(client1, "LogOut", frmDangNhap.User);
            //    // đổ mảng đối tượng vào datagripview       
            //    cl.DeserializeHepper(clientstrem, null);

            //}
            //catch (Exception)
            //{
            //}
            //finally
            //{
            frmDangNhap.User = null;
            frmDangNhap.CTQ = null;
            Form fr = new frmDangNhap();
            fr.Show();
            this.Hide();
            //}
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("chưa xử lý");
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            frmQuanLyLogFile lf = new frmQuanLyLogFile();
            lf.ShowDialog();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isClose = Exit();
            if (isClose)
            {
                this.isFormClose = false;
                this.Close();
            }
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
        public bool ThoatFormTrangChinh()
        {
            Form[] frm = this.MdiChildren;
            foreach (Form temp in frm)
            {
                if (temp.Name.Equals("frmTrangChinh"))
                {
                    temp.Close();
                    return false;
                }
            }
            return true;
        }
        private void nhómHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
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
            frmQuanLyNhomHangHoa nhh = new frmQuanLyNhomHangHoa();
            closeall(nhh.Name);
            nhh.MdiParent = this;
            nhh.Show();

        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyHangHoa", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyHangHoa"))
            {
                return;
            }
            frmQuanLyHangHoa qlhh = new frmQuanLyHangHoa();
            closeall(qlhh.Name);
            qlhh.MdiParent = this;
            qlhh.Show();
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhoHang", 1))
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            if (!Check("frmQuanLyKhoHang"))
            {
                return;
            }
            frmQuanLyKhoHang kh = new frmQuanLyKhoHang();
            closeall(kh.Name);
            kh.MdiParent = this;
            kh.Show();

        }

        private void nhómĐốiTácKinhDoanhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyKhachHang"))
            {
                return;
            }
            frmQuanLyKhachHang kh = new frmQuanLyKhachHang();
            closeall(kh.Name);
            kh.MdiParent = this;
            kh.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhaCungCap", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyNhaCungCap"))
            {
                return;
            }
            frmQuanLyNhaCungCap ncc = new frmQuanLyNhaCungCap();
            closeall(ncc.Name);
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void nhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlynhanvien", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlynhanvien"))
            {
                return;
            }
            frmQuanlynhanvien qlnv = new frmQuanlynhanvien();
            closeall(qlnv.Name);
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void tàiKhoảnKếToánToolStripMenuItem_Click(object sender, EventArgs e)
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
            frmQuanLyTaiKhoanKeToan qltkkt = new frmQuanLyTaiKhoanKeToan();
            closeall(qltkkt.Name);
            qltkkt.MdiParent = this;
            qltkkt.Show();
        }
        private void thuTiềnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Check("frmQuanLyPhieuThu"))
            {
                return;
            }
            frmQuanLyPhieuThu tt = new frmQuanLyPhieuThu();
            closeall(tt.Name);
            tt.MdiParent = this;
            tt.Show();
        }

        private void chiTiềnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Check("frmQuanLyPhieuChi"))
            {
                return;
            }
            frmQuanLyPhieuChi ct = new frmQuanLyPhieuChi();
            closeall(ct.Name);
            ct.MdiParent = this;
            ct.Show();
        }

        private void tiểnTệToolStripMenuItem_Click(object sender, EventArgs e)
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
            frmQuanlytiente qltt = new frmQuanlytiente();
            closeall(qltt.Name);
            qltt.MdiParent = this;
            qltt.Show();
        }

        private void tàiKhoảnNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void nhậpMuaToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void kháchHàngTrảLạiToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void xuấtBánToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void bánLẻSiêuThịToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void trảLạiNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void thanhToánVớiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuThanhToanCuaKH", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuThanhToanCuaKH"))
            {
                return;
            }
            frmQuanLyPhieuThanhToanCuaKH ttkh = new frmQuanLyPhieuThanhToanCuaKH();
            closeall(ttkh.Name);
            ttkh.MdiParent = this;
            ttkh.Show();
        }

        private void thanhToánVớiNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyPhieuThanhToanNCC", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyPhieuThanhToanNCC"))
            {
                return;
            }
            frmQuanLyPhieuThanhToanNCC ttncc = new frmQuanLyPhieuThanhToanNCC();
            closeall(ttncc.Name);
            ttncc.MdiParent = this;
            ttncc.Show();
        }

        private void tổngHợpChiTiếtCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmCongNo", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmCongNo"))
            {
                return;
            }
            frmCongNo thctcn = new frmCongNo();
            closeall(thctcn.Name);
            thctcn.MdiParent = this;
            thctcn.Show();
        }

        private void nhậpSốDưCôngNợĐầuKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmSoDuKhachHang", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmSoDuKhachHang"))
            {
                return;
            }
            frmSoDuKhachHang thctcn = new frmSoDuKhachHang();
            closeall(thctcn.Name);
            thctcn.MdiParent = this;
            thctcn.Show();
        }

        private void chuyểnSốDưCôngNợCuốiKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            frmKetChuyenSoDuCongNo thctcn = new frmKetChuyenSoDuCongNo();
            closea(thctcn.Name);
            thctcn.ShowDialog();

        }
        void closeall(string Name)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name.Equals("frmTrangChinh") || item.Name.Equals("frmNghiepVu") || item.Name.Equals("frmDanhMuc") || item.Name.Equals("frmBaoCao") || item.Name.Equals("frmKhoHang"))
                    item.Close();
            }
        }
        void closea(string Name)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (!item.Name.Equals(Name))
                    item.Close();
            }
        }
        private void thuTiềnToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(tt.Name);
            tt.MdiParent = this;
            tt.Show();
        }

        private void chiTiềnToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(ct.Name);
            ct.MdiParent = this;
            ct.Show();
        }

        private void sổQuỹToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(sq.Name);
            sq.MdiParent = this;
            sq.Show();
        }
        private void điềuChuyểnKhoToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void xácNhânĐiềuChuyểnKhoToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void kiểmKêKhoToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void inTemMãVạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void nhậpSốDưTồnKhoĐầuKỳToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void chuyểnSốDưTồnKhoCuốiKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmKetChuyenSoDuKho"))
            {
                return;
            }
            frmKetChuyenSoDuKho frm = new frmKetChuyenSoDuKho();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoDoanhThuTheoNhómHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCDoanhThuNhomHang", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCDoanhThuNhomHang"))
            {
                return;
            }
            frmBCDoanhThuNhomHang frm = new frmBCDoanhThuNhomHang();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoDoanhThuTheoMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCDoanhThuHangHoa", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCDoanhThuHangHoa"))
            {
                return;
            }
            frmBCDoanhThuHangHoa frm = new frmBCDoanhThuHangHoa();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoNhậpXuấtTồnTheoKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void báoCáoCôngNợTheoThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void báoCáoCôngNợTheoNhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCCongNoNhaCungCap", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCCongNoNhaCungCap"))
            {
                return;
            }
            frmBCCongNoNhaCungCap frm = new frmBCCongNoNhaCungCap();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoCôngNợTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCCongNoKhachHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCCongNoKhachHang"))
            {
                return;
            }
            frmBCCongNoKhachHang frm = new frmBCCongNoKhachHang();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoNhậpXuấtTồnTheoMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void báoCáoNhậpXuấtTồnTheoNhómHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.TableOfContents);
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void traCứuHàngTheoChứngTừToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cậpNhậtGiáNhậpMớiNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Check("frmCapnhatgianhapmoinhat"))
            {
                return;
            }
            frmCapnhatgianhapmoinhat fr = new frmCapnhatgianhapmoinhat();
            closeall(fr.Name);
            fr.MdiParent = this;
            fr.Show();

        }
        //Show form
        private string TenDangNhap;
        public string _TenDangNhap
        {
            get { return TenDangNhap; }
            set { this.TenDangNhap = value; }
        }

        public frmChinh(string tendangnhap)
        {
            InitializeComponent();
            this.TenDangNhap = tendangnhap;

        }


        private void frmChinh_Load(object sender, EventArgs e)
        {
            if (Luu.Server.Equals("server"))
            {
                toolStripMenuItem5.Visible = true;
            }
            else if (Luu.Server.Equals("client"))
            {
                toolStripMenuItem5.Visible = false;
            }

            Size s = new System.Drawing.Size();
            s = SystemInformation.WorkingArea.Size;

            tlsUs.Text = "Người sử dụng: " + Common.Utilities.User.TenNhanVien;
            Form fr = new frmTrangChinh();
            fr.MdiParent = this;
            this.Height = Int32.Parse(s.Height.ToString());
            this.Width = Int32.Parse(Screen.PrimaryScreen.WorkingArea.Width.ToString());
            fr.Show();
            pnlChucnang.Visible = true;
            pnlChucnang.Location = new Point(1, 15);
            pnlChucnang.Size = new Size(166, 200);
            pnlChucnang.AutoScroll = true;

            groupBox1.Controls.Add(pnlChucnang);
            listHome[0] = "Đăng Xuất";
            listHome[1] = "Lưu viết hệ thống";
            listHome[2] = "Khôi phục dữ liệu";
            listHome[3] = "Phân quyền";

            listDanhMuc[0] = "Nhóm Hàng";
            listDanhMuc[1] = "Loại Hàng Hóa";
            listDanhMuc[2] = "Hàng Hóa";
            listDanhMuc[3] = "Khoản Mục Thu Chi";
            //listDanhMuc[4] = "TK Kế Toán";
            //listDanhMuc[5] = "Nhóm TKKT";
            listDanhMuc[4] = "Thuế";
            listDanhMuc[5] = "Nhà Cung Cấp";
            listDanhMuc[6] = "Khách Hàng";
            listDanhMuc[7] = "Phòng Ban";
            listDanhMuc[8] = "Nhân Viên";
            listDanhMuc[9] = "Kho Hàng";
            listDanhMuc[10] = "Tiền Tệ";
            listDanhMuc[11] = "Đơn Vị Tính";
            listDanhMuc[12] = "Gói Hàng";
            //listDanhMuc[13] = "Quy Đổi DVT";

            listKhoHang[0] = "Điều chuyển kho";
            listKhoHang[1] = "Xác nhận điều chuyển kho";
            listKhoHang[2] = "Kiểm kê kho";
            listKhoHang[3] = "In tem mã vạch";
            //listKhoHang[4] = "Nhập số dư tồn kho";
            //listKhoHang[4] = "Chuyển số dư tồn kho";
            listKhoHang[4] = "Số Dư Kho";
            listKhoHang[5] = "Phiếu Xuất Hủy";
            listKhoHang[6] = "Xác Nhận Phiếu Xuất Hủy";

            listNghiepVu[0] = "Phiếu Thu";
            listNghiepVu[1] = "Phiếu Chi";
            listNghiepVu[2] = "Sổ Quỹ";
            listNghiepVu[3] = "Khách hàng trả lại";
            listNghiepVu[4] = "Trả lại NCC";
            listNghiepVu[5] = "Số Dư Đầu Kỳ";
            listNghiepVu[6] = "Kết Chuyển Số Dư Đầu Kỳ";
            listNghiepVu[7] = "Đơn đặt hàng";
            listNghiepVu[8] = "Nhập kho";
            listNghiepVu[9] = "Bán Buôn";
            listNghiepVu[10] = "Bán Lẻ";

            listBaoCao[0] = "BC Doanh thu";
            listBaoCao[1] = "BC Công nợ";
            listBaoCao[2] = "BC Xuất hàng";
            listBaoCao[3] = "BC Nhập hàng";
            listBaoCao[4] = "BC Tồn kho";

        }

        private void btnTrangChinh_Click(object sender, EventArgs e)
        {
            if (!Check("frmTrangChinh"))
            {
                pnlChucnang.Controls.Clear();
                pnlChucnang.AutoScroll = true;
                for (int i = 0; i < 4; i++)
                {
                    Button btn = new Button();
                    btn.Location = new Point(0, i * 35 + 2);
                    btn.Text = listHome[i];
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Visible = true;
                    btn.Size = new Size(135, 35);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = Color.White;

                    btn.Image = new Bitmap(global::GUI.Properties.Resources.Home__1_);
                    btn.ImageAlign = ContentAlignment.MiddleLeft;
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btn.Click += new System.EventHandler(btn_click);

                    pnlChucnang.Controls.Add(btn);
                }
                return;
            }
            Form fr = new frmTrangChinh();
            fr.MdiParent = this;
            int Heights = Screen.PrimaryScreen.Bounds.Height;
            int Widths = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(0, 0);
            this.Width = Widths;
            this.Height = Heights - 40;
            fr.Show();


        }
        void closeformmain()
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name.Equals("frmTrangChinh") || item.Name.Equals("frmDanhMuc") || item.Name.Equals("frmNghiepVu") || item.Name.Equals("frmKhoHang") || item.Equals("frmBaoCao"))
                {
                    item.Close();
                }
            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                #region Home
                case "Đăng Xuất":
                    {
                        frmDangNhap.User = null;
                        frmDangNhap.CTQ = null;
                        this.Hide();
                        Form fr = new frmDangNhap();
                        fr.Show();
                        break;
                    }
                case "Lưu viết hệ thống":
                    {
                        if (!frmDangNhap.User.Administrator)
                        {
                            MessageBox.Show("Không có quyền vào chức năng này");
                            return;
                        }
                        frmQuanLyLogFile frm = new frmQuanLyLogFile();
                        frm.ShowDialog();
                        break;
                    }
                case "Khôi phục dữ liệu":
                    {

                        if (!frmDangNhap.User.Administrator)
                        {
                            MessageBox.Show("Không có quyền vào chức năng này");
                            return;
                        }
                        frmQuanLySaoLuuHeThong frm = new frmQuanLySaoLuuHeThong();
                        frm.ShowDialog();
                        break;
                    }
                case "Phân quyền":
                    {
                        if (!frmDangNhap.User.Administrator)
                        {
                            MessageBox.Show("Administrator mới được phân quyền");
                            return;
                        }
                        frmPhanQuyen frm = new frmPhanQuyen();
                        frm.ShowDialog();
                        break;
                    }
                #endregion
                #region Danh Mục
                case "Gói Hàng":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyGoiHang", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanLyGoiHang"))
                        {
                            return;
                        }
                        frmQuanLyGoiHang nhh = new frmQuanLyGoiHang();
                        closeall(nhh.Name);
                        nhh.MdiParent = this;
                        nhh.Show();

                        break;
                    }

                //case "Quy Đổi DVT":
                //    {
                //        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyQuyDoiDonViTinh", 1))
                //        {
                //            MessageBox.Show(" Không có quyền vào chức năng này.");
                //            return;
                //        }
                //        if (!Check("frmQuanLyQuyDoiDonViTinh"))
                //        {
                //            return;
                //        }
                //        frmQuanLyQuyDoiDonViTinh nhh = new frmQuanLyQuyDoiDonViTinh();
                //        closeall(nhh.Name);
                //        nhh.MdiParent = this;
                //        nhh.Show();
                //        break;
                //    }
                case "Nhóm Hàng":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhomHangHoa", 1))
                        {
                            MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                            return;
                        }
                        //if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhomHang", 1))
                        //{
                        //    MessageBox.Show(" Không có quyền vào chức năng này.");
                        //    return;
                        //}
                        if (!Check("frmQuanLyNhomHang"))
                        {
                            return;
                        }
                        frmQuanLyNhomHangHoa nhh = new frmQuanLyNhomHangHoa();
                        closeall(nhh.Name);
                        nhh.MdiParent = this;
                        nhh.Show();

                        break;
                    }
                case "Loại Hàng Hóa":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyLoaiHangHoa", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanLyLoaiHangHoa"))
                        {
                            return;
                        }
                        Form fr = new frmQuanLyLoaiHangHoa();
                        closeall(fr.Name);
                        fr.MdiParent = this;
                        fr.Show();

                        break;
                    }
                case "Hàng Hóa":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyHangHoa", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanLyHangHoa"))
                        {
                            return;
                        }
                        frmQuanLyHangHoa qlhh = new frmQuanLyHangHoa();
                        closeall(qlhh.Name);
                        qlhh.MdiParent = this;
                        qlhh.Show();

                        break;
                    }
                case "Khoản Mục Thu Chi":
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
                        frmQuanlyKMthuchi fr = new frmQuanlyKMthuchi();
                        closeall(fr.Name);
                        fr.MdiParent = this;
                        fr.Show();

                        break;
                    }
                case "TK Kế Toán":
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
                        frmQuanLyTaiKhoanKeToan qltkkt = new frmQuanLyTaiKhoanKeToan();
                        closeall(qltkkt.Name);
                        qltkkt.MdiParent = this;
                        qltkkt.Show();

                        break;
                    }
                case "Nhóm TKKT":
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
                        fr.MdiParent = this;
                        fr.Show();

                        break;
                    }
                case "Thuế":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyThue", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanLyThue"))
                        {
                            return;
                        }
                        Form frm = new frmQuanLyThue();
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                case "Nhà Cung Cấp":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyNhaCungCap", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanLyNhaCungCap"))
                        {
                            return;
                        }
                        frmQuanLyNhaCungCap ncc = new frmQuanLyNhaCungCap();
                        closeall(ncc.Name);
                        ncc.MdiParent = this;
                        ncc.Show();

                        break;
                    }
                case "Khách Hàng":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHang", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanLyKhachHang"))
                        {
                            return;
                        }
                        frmQuanLyKhachHang kh = new frmQuanLyKhachHang();
                        closeall(kh.Name);
                        kh.MdiParent = this;
                        kh.Show();

                        break;
                    }

                case "Phòng Ban":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlyphongban", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanlyphongban"))
                        {
                            return;
                        }
                        frmQuanlyphongban fr = new frmQuanlyphongban();
                        closeall(fr.Name);
                        fr.MdiParent = this;
                        fr.Show();

                        break;
                    }
                case "Nhân Viên":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlynhanvien", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        if (!Check("frmQuanlynhanvien"))
                        {
                            return;
                        }
                        frmQuanlynhanvien qlnv = new frmQuanlynhanvien();
                        closeall(qlnv.Name);
                        qlnv.MdiParent = this;
                        qlnv.Show();

                        break;
                    }
                case "Kho Hàng":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhoHang", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        try
                        {
                            if (!Check("frmQuanLyKhoHang"))
                            {
                                return;
                            }
                            frmQuanLyKhoHang kh = new frmQuanLyKhoHang();
                            closeall(kh.Name);
                            kh.MdiParent = this;
                            kh.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Tiền Tệ":
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
                        frmQuanlytiente qltt = new frmQuanlytiente();
                        closeall(qltt.Name);
                        qltt.MdiParent = this;
                        qltt.Show();

                        break;
                    }
                case "Đơn Vị Tính":
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
                        Form frm = new frmQuanLyDVT();
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                #endregion
                #region Kho Hàng
                case "Điều chuyển kho":
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
                        frmHienThi_DieuChuyenKhoNoiBo htdcknb = new frmHienThi_DieuChuyenKhoNoiBo();
                        closeall(htdcknb.Name);
                        htdcknb.MdiParent = this;
                        htdcknb.Show();

                        break;
                    }
                case "Xác nhận điều chuyển kho":
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
                        frmHienThi_XacNhanDieuChuyenKho xndck = new frmHienThi_XacNhanDieuChuyenKho();
                        closeall(xndck.Name);
                        xndck.MdiParent = this;
                        xndck.Show();

                        break;
                    }
                case "Kiểm kê kho":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKiemKeKho", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }

                        try
                        {
                            if (!Check("frmQuanLyKiemKeKho"))
                            {
                                return;
                            }
                            frmQuanLyKiemKeKho kkk = new frmQuanLyKiemKeKho();
                            closeall(kkk.Name);
                            kkk.MdiParent = this;
                            kkk.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }

                        break;
                    }
                case "In tem mã vạch":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyMaVach", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
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
                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        closeformmain();
                        break;
                    }
                case "Nhập số dư tồn kho":
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
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();
                        break;
                    }
                //case "Chuyển số dư tồn kho":
                //    {
                //        break;
                //    }
                case "Số Dư Kho":
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
                        Form frm = new frmSoDuKhoHang();
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                case "Phiếu Xuất Hủy":
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
                        Form fr = new frmQuanLyPhieuXuatHuy();
                        closeall(fr.Name);
                        fr.MdiParent = this;
                        fr.Show();

                        break;
                    }
                case "Xác Nhận Phiếu Xuất Hủy":
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
                        Form frm = new frmXacNhanPhieuXuatHuy();
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                #endregion
                #region Nghiệp Vụ
                case "Phiếu Thu":
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
                        closeall(tt.Name);
                        tt.MdiParent = this;
                        tt.Show();

                        break;
                    }
                case "Phiếu Chi":
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
                        closeall(ct.Name);
                        ct.MdiParent = this;
                        ct.Show();

                        break;
                    }
                case "Sổ Quỹ":
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
                        closeall(sq.Name);
                        sq.MdiParent = this;
                        sq.Show();

                        break;
                    }
                case "Khách hàng trả lại":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKhachHangTraLaiHang", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        try
                        {
                            if (!Check("frmQuanLyKhachHangTraLaiHang"))
                            {
                                return;
                            }
                            frmQuanLyKhachHangTraLaiHang fr = new frmQuanLyKhachHangTraLaiHang();
                            closeall(fr.Name);
                            fr.MdiParent = this;
                            fr.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Trả lại NCC":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyTraLaiNhaCungCap", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        try
                        {
                            if (!Check("frmQuanLyTraLaiNhaCungCap"))
                            {
                                return;
                            }
                            frmQuanLyTraLaiNhaCungCap httlncc = new frmQuanLyTraLaiNhaCungCap();
                            closeall(httlncc.Name);
                            httlncc.MdiParent = this;
                            httlncc.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Số Dư Đầu Kỳ":
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
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                case "Kết Chuyển Số Dư Đầu Kỳ":
                    {
                        if (!frmDangNhap.User.Administrator)
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        Form frm = new frmKetChuyenSoDu();
                        frm.ShowDialog();
                        closeall(frm.Name);
                        break;
                    }
                case "Đơn đặt hàng":
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
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                case "Nhập kho":
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
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                case "Bán Buôn":
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
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                case "Bán Lẻ":
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
                        Form frm = new frmQuanLyBanLe();
                        closeall(frm.Name);
                        frm.MdiParent = this;
                        frm.Show();

                        break;
                    }
                #endregion
                #region Báo Cáo
                case "BC Doanh thu":
                    {
                        closeformmain();
                        frmBaoCao kkk = new frmBaoCao("DoanhThu");
                        kkk.MdiParent = this;
                        kkk.Show();
                        break;
                    }
                case "BC Công nợ":
                    {
                        closeformmain();
                        frmBaoCao kkk = new frmBaoCao("CongNo");
                        kkk.MdiParent = this;
                        kkk.Show();
                        break;
                    }
                case "BC Xuất hàng":
                    {
                        closeformmain();
                        frmBaoCao kkk = new frmBaoCao("XuatHang");
                        kkk.MdiParent = this;
                        kkk.Show();
                        break;
                    }
                case "BC Nhập hàng":
                    {
                        closeformmain();
                        frmBaoCao kkk = new frmBaoCao("NhapHang");
                        kkk.MdiParent = this;
                        kkk.Show();
                        break;
                    }
                case "BC Tồn kho":
                    {
                        closeformmain();
                        frmBaoCao kkk = new frmBaoCao("TonKho");
                        kkk.MdiParent = this;
                        kkk.Show();
                        break;
                    }
                #endregion

            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {

            if (Check("frmDanhMuc"))
            {
                Form fr = new frmDanhMuc();
                fr.MdiParent = this;
                fr.Show();
            }

            pnlChucnang.Controls.Clear();

            for (int i = 0; i < listDanhMuc.Length - 1; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(0, i * 35 + 2);
                btn.Text = listDanhMuc[i];
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Visible = true;
                btn.Size = new Size(135, 35);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;

                btn.Image = new Bitmap(global::GUI.Properties.Resources.Danh_Muc__1_);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Click += new System.EventHandler(btn_click);

                pnlChucnang.Controls.Add(btn);
            }

        }

        private void btnNghiepVu_Click(object sender, EventArgs e)
        {
            if (Check("frmNghiepVu"))
            {
                Form fr = new frmNghiepVu();
                fr.MdiParent = this;
                fr.Show();
            }
            pnlChucnang.Controls.Clear();

            for (int i = 0; i < listNghiepVu.Length; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(0, i * 35 + 2);
                btn.Text = listNghiepVu[i];
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Visible = true;
                btn.Size = new Size(135, 35);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;

                btn.Image = new Bitmap(global::GUI.Properties.Resources.Nghiep_Vu__1_);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Click += new System.EventHandler(btn_click);

                pnlChucnang.Controls.Add(btn);
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (Check("frmBaoCao"))
            {
                Form fr = new frmBaoCao();
                fr.MdiParent = this;
                fr.Show();
            }
            pnlChucnang.Controls.Clear();

            for (int i = 0; i < listBaoCao.Length; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(0, i * 35 + 2);
                btn.Text = listBaoCao[i];
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Visible = true;
                btn.Size = new Size(135, 35);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
                btn.Image = Properties.Resources.Bao_Cao__1_;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Click += new System.EventHandler(btn_click);

                pnlChucnang.Controls.Add(btn);
            }
        }

        private void theoDõiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void doanhSốTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void phânTíchBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void theoDõiGiáVốnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        
        private void loạiHangHoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyLoaiHangHoa", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }

            if (!Check("frmQuanLyLoaiHangHoa"))
            {
                return;
            }
            Form fr = new frmQuanLyLoaiHangHoa();
            closeall(fr.Name);
            fr.MdiParent = this;
            fr.Show();

        }

        private void trảLạiNhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Check("frmHienThi_TraLaiNhaCungCap"))
            {
                return;
            }
            frmQuanLyTraLaiNhaCungCap frm = new frmQuanLyTraLaiNhaCungCap();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                frmTimBaoCao tim = new frmTimBaoCao();
                tim.ShowDialog();
                if (!Check("frmBaoCaoXuatHang"))
                {
                    return;
                }
                frmBaoCaoXuatHang frm = new frmBaoCaoXuatHang("XuatHangTheoKho", "Báo Cáo - Xuất Hàng Theo Từng Kho Hàng");
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception)
            { }
        }

        private void báoCáoXuấtHàngTheoTừngNhómHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check("frmBaoCaoXuatHang"))
                {
                    return;
                }
                frmBaoCaoXuatHang frm = new frmBaoCaoXuatHang("XuatHangTheoNhomHang", "Báo Cáo - Xuất Hàng Theo Từng Nhóm Hàng Hóa");
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception)
            { }
        }

        private void báoCáoXuấtHàngTheoTừngMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Check("frmBaoCaoXuatHang"))
            {
                return;
            }
            frmBaoCaoXuatHang frm = new frmBaoCaoXuatHang("XuatHangTheoMatHang", "Báo Cáo - Xuất Hàng Theo Từng Mặt Hàng");
            frm.MdiParent = this;
            frm.Show();
        }
        private void btnBanBuon_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyBanBuon", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!CheckQuyen("frmQuanLyBanBuon", 4))
            {
                return;
            }
            if (!Check("frmXuLyBanBuon"))
            {
                return;
            }
            for (int i = 0; i < 1000; i++)
            {
                if (frmXuLyBanBuon.trave == "")
                {
                    Form frm = new frmXuLyBanBuon("Them");
                    int Heights = Screen.PrimaryScreen.Bounds.Height;
                    int Widths = Screen.PrimaryScreen.Bounds.Width;
                    frm.Height = Heights - 60;
                    frm.ShowDialog();
                    closeall(frm.Name);
                }
                else
                {
                    frmXuLyBanBuon.trave = "";
                    return;
                }
            }


        }

        private void btnBanLe_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyBanLe", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!CheckQuyen("frmQuanLyBanLe", 4))
            {
                return;
            }
            if (!Check("frmXuLyBanLe"))
            {
                return;
            }
            for (int i = 0; i < 1000; i++)
            {
                if (frmXuLyBanLe.trave == "")
                {
                    Form frm = new frmXuLyBanLe("Them");
                    int Heights = Screen.PrimaryScreen.Bounds.Height;
                    int Widths = Screen.PrimaryScreen.Bounds.Width;
                    frm.Height = Heights - 60;
                    frm.ShowDialog(); closeall(frm.Name);
                }
                else
                {
                    frmXuLyBanLe.trave = "";
                    return;
                }
            }


        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            if (Check("frmKhoHang"))
            {
                Form fr = new frmKhoHang();
                fr.MdiParent = this;
                fr.Show();
            }

            pnlChucnang.Controls.Clear();

            for (int i = 0; i < listKhoHang.Length; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(0, i * 35 + 2);
                btn.Text = listKhoHang[i];
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Visible = true;
                btn.Size = new Size(135, 35);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;

                btn.Image = new Bitmap(global::GUI.Properties.Resources.Kho_Hang__1_);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Click += new System.EventHandler(btn_click);

                pnlChucnang.Controls.Add(btn);
            }
        }



        private void côngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyCongTy", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyCongTy"))
            {
                return;
            }
            Form frm = new frmQuanLyCongTy();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void inMãVạchToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void càiĐặtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmCaiDatKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            frmCaiDatKho frm = new frmCaiDatKho();
            frm.ShowDialog();
        }

        private void nhậpSốDưĐầuKỳToolStripMenuItem_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void xácNhậnPhiếuXuấtHủyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Check("frmXacNhanPhieuXuatHuy"))
            {
                return;
            }
            Form frm = new frmXacNhanPhieuXuatHuy();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void caiĐătKhoHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmCaiDatKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            frmCaiDatKho frm = new frmCaiDatKho();
            frm.ShowDialog();
        }

        private void kếtChuyểnSốDưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            Form frm = new frmKetChuyenSoDu();
            closea(frm.Name);
            frm.ShowDialog();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show("Administrator mới được phân quyền");
                return;
            }
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.ShowDialog();
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

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
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
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void baoCaoNhâpHangTheoTưngKhoHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Check("frmBaoCaoNhap"))
            {
                return;
            }
            frmBaoCaoNhap frm = new frmBaoCaoNhap("BaoCaoNhapTheoKhoHang");
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void baoCaoNhâpHangTheoTưngNhomHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Check("frmBaoCaoNhap"))
            {
                return;
            }
            frmBaoCaoNhap frm = new frmBaoCaoNhap("BaoCaoNhapTheoNhomHang");
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void baoCaoNhâpHangTheoTưngMătHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Check("frmBaoCaoNhap"))
            {
                return;
            }
            frmBaoCaoNhap frm = new frmBaoCaoNhap("BaoCaoNhapTheoMatHang");
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
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
            Form frm = new frmQuanLyDVT();
            closeall(frm.Name);
            frm.MdiParent = this;

            frm.Show();
        }

        private void thuếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyThue", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyThue"))
            {
                return;
            }
            Form frm = new frmQuanLyThue();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void phiếuXuấtHủyToolStripMenuItem_Click(object sender, EventArgs e)
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
            Form fr = new frmQuanLyPhieuXuatHuy();
            closeall(fr.Name);
            fr.MdiParent = this;
            fr.Show();
        }

        private void xácNhậnPhiếuXuấtHủyToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            Form fr = new frmXacNhanPhieuXuatHuy();
            closeall(fr.Name);
            fr.MdiParent = this;
            fr.Show();
        }

        private void theoThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmtg", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            frmtg a = new frmtg();
            a.ShowDialog();
        }

        private void theoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCDoanhThuNhanVien", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCDoanhThuNhanVien"))
            {
                return;
            }
            frmBCDoanhThuTheoNhanVien frm = new frmBCDoanhThuTheoNhanVien();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void theoKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCNhapHangTheoKho", 1))
                {
                    MessageBox.Show("Không có quyền vào chức năng này");
                    return;
                }
                frmBCNhapHangTheoKho frm = new frmBCNhapHangTheoKho();
                closeall(frm.Name);
                if (!Check("frmBCNhapHangTheoKho"))
                {
                    Application.OpenForms["frmBCNhapHangTheoKho"].Close();
                    frm.MdiParent = this;
                    frm.Show();
                    return;
                }
                frm.MdiParent = this;
                frm.Show();

            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void theoNhómHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCNhapHangTheoNhom", 1))
                {
                    MessageBox.Show("Không có quyền vào chức năng này");
                    return;
                }
                frmBCNhapHangTheoNhom frm = new frmBCNhapHangTheoNhom();
                closeall(frm.Name);
                if (!Check("frmBCNhapHangTheoNhom"))
                {
                    Application.OpenForms["frmBCNhapHangTheoNhom"].Close();
                    frm.MdiParent = this;
                    frm.Show();
                    return;
                }
                frm.MdiParent = this;
                frm.Show();

            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void theoMặtHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCNhapHangTheoMatHang", 1))
                {
                    MessageBox.Show("Không có quyền vào chức năng này");
                    return;
                }
                if (!Check("frmBCNhapHangTheoMatHang"))
                {
                    return;
                }
                frmBCNhapHangTheoMatHang frm = new frmBCNhapHangTheoMatHang();

                frm.MdiParent = this;
                closeall(frm.Name);
                frm.Show();

            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void xuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && CheckQuyen("frmBaoCaoXuatNhapTonTheoNhom", 1))
                {
                    MessageBox.Show("Không có quyền vào chức năng này");
                    return;
                }

                frmBaoCaoNhap frm = new frmBaoCaoNhap("XuatNhapTonTheoNhomHang");
                closeall(frm.Name);
                if (!Check("frmBaoCaoNhap"))
                {
                    Application.OpenForms["frmBaoCaoNhap"].Close();
                    frm.MdiParent = this;
                    frm.Show();
                    return;
                }
                frm.MdiParent = this;
                frm.Show();

            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void chiTiếtHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("BCChiTietHangHoa", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                if (!Check("frmBaoCaorpt"))
                {
                    return;
                }
                frmBaoCaorpt frm = new frmBaoCaorpt("ChiTietHangHoa");
                frm.ShowDialog();
            }
            catch
            { }
        }

        private void xuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatNhapTonNhomHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmBCXuatNhapTonNhomHang frm = new frmBCXuatNhapTonNhomHang();
                closeall(frm.Name);
                if (!Check("frmBaoCaoNhap"))
                {
                    Application.OpenForms["frmBCXuatNhapTonNhomHang"].Close();
                    frm.MdiParent = this;
                    frm.Show();
                    return;
                }

                frm.MdiParent = this;
                frm.Show();

            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void theoTừngKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCTonKhoTheoKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCTonKhoTheoKho"))
            {
                return;
            }
            frmBCTonKhoTheoKho frm = new frmBCTonKhoTheoKho();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void xuấtnhậptồnTheoKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatNhapTonTheoKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatNhapTonTheoKho"))
            {
                return;
            }
            frmBCXuatNhapTonTheoKho frm = new frmBCXuatNhapTonTheoKho();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void theoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCTonKhoTheoNhomHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCTonKhoTheoNhomHang"))
            {
                return;
            }
            frmBCTonKhoTheoNhomHang frm = new frmBCTonKhoTheoNhomHang();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void xuấtnhậptồnTheoLoạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatNhapTonLoaiHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatNhapTonLoaiHang"))
            {
                return;
            }
            frmBCXuatNhapTonLoaiHang frm = new frmBCXuatNhapTonLoaiHang();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void xuấtnhậptồnTheoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatNhapTonPhieuXuatNhap", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatNhapTonPhieuXuatNhap"))
            {
                return;
            }
            frmBCXuatNhapTonPhieuXuatNhap frm = new frmBCXuatNhapTonPhieuXuatNhap();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {
                MessageBox.Show("Không Có Quyền Vào Chức Năng Này");
                return;
            }
            frmQuanLySaoLuuHeThong frm = new frmQuanLySaoLuuHeThong();
            frm.ShowDialog();
        }

        private void theoThờiGianToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCCongNoKhachHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatHangTheoTungKho"))
            {
                return;
            }
            frmBCXuatHangTheoTungKho frm = new frmBCXuatHangTheoTungKho();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void theoNhómHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatHangTheoNhomHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatHangTheoNhomHang"))
            {
                return;
            }
            frmBCXuatHangTheoNhomHang frm = new frmBCXuatHangTheoNhomHang();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void theoMặtHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatHangTheoHangHoa", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatHangTheoHangHoa"))
            {
                return;
            }
            frmBCXuatHangTheoHangHoa frm = new frmBCXuatHangTheoHangHoa();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }



        private void mứcTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCMucTonToiThieuToiDa frm = new frmBCMucTonToiThieuToiDa();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mứcTồnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCMucTonToiThieuToiDa", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCMucTonToiThieuToiDa"))
            {
                return;
            }
            frmBCMucTonToiThieuToiDa frm = new frmBCMucTonToiThieuToiDa();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        //private void báoCáoLãiLỗToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCLaiLo", 1))
        //    {

        //        MessageBox.Show(" Không có quyền vào chức năng này.");
        //        return;
        //    }
        //    if (!Check("frmBCLaiLo"))
        //    {
        //        return;
        //    }
        //    frmBCLaiLo frm = new frmBCLaiLo();
        //    closeall(frm.Name);
        //    frm.MdiParent = this;
        //    frm.Show(); 
        //}

        private void chiTiếtĐiểmThưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmTinhDiemThuong", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmTinhDiemThuong"))
            {
                return;
            }
            frmTinhDiemThuong a = new frmTinhDiemThuong();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.isClose = Exit();
            if (isClose)
            {
                this.isFormClose = false;
                this.Close();
            }
        }

        private void tìmKiếmChứngTừToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmTimKiemChungTu", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmTimKiemChungTu"))
            {
                return;
            }
            frmTimKiemChungTu a = new frmTimKiemChungTu();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void theoThờiGianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCNhapHangTheoThoiGian", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCNhapHangTheoThoiGian"))
            {
                return;
            }
            frmBCNhapHangTheoThoiGian a = new frmBCNhapHangTheoThoiGian();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void theoThờiGianToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatHangTheoThoiGian", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatHangTheoThoiGian"))
            {
                return;
            }
            frmBCXuatHangTheoThoiGian a = new frmBCXuatHangTheoThoiGian();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void quyĐổiĐơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyQuyDoiDonViTinh", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyQuyDoiDonViTinh"))
            {
                return;
            }
            frmQuanLyQuyDoiDonViTinh a = new frmQuanLyQuyDoiDonViTinh();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void góiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyGoiHang", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyGoiHang"))
            {
                return;
            }
            frmQuanLyGoiHang a = new frmQuanLyGoiHang();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void báoCáoThuếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCThue", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCThue"))
            {
                return;
            }
            frmBCThue a = new frmBCThue();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void btnTrangChinh_MouseLeave(object sender, EventArgs e)
        {
            btnTrangChinh.Image = new Bitmap(global::GUI.Properties.Resources.home);
        }

        private void btnTrangChinh_MouseMove(object sender, MouseEventArgs e)
        {
            btnTrangChinh.Image = new Bitmap(global::GUI.Properties.Resources.home1);
        }

        private void btnBanBuon_MouseLeave(object sender, EventArgs e)
        {
            btnBanBuon.Image = new Bitmap(global::GUI.Properties.Resources.banbuon);
        }

        private void btnBanBuon_MouseMove(object sender, MouseEventArgs e)
        {
            btnBanBuon.Image = new Bitmap(global::GUI.Properties.Resources.banbuon1);
        }

        private void btnBanLe_MouseLeave(object sender, EventArgs e)
        {
            btnBanLe.Image = new Bitmap(global::GUI.Properties.Resources.banle);
        }

        private void btnBanLe_MouseMove(object sender, MouseEventArgs e)
        {
            btnBanLe.Image = new Bitmap(global::GUI.Properties.Resources.banle1);
        }

        private void btnDanhMuc_MouseLeave(object sender, EventArgs e)
        {
            btnDanhMuc.Image = new Bitmap(global::GUI.Properties.Resources.danhmuc);
        }

        private void btnDanhMuc_MouseMove(object sender, MouseEventArgs e)
        {
            btnDanhMuc.Image = new Bitmap(global::GUI.Properties.Resources.danhmuc1);
        }

        private void btnNghiepVu_MouseLeave(object sender, EventArgs e)
        {
            btnNghiepVu.Image = new Bitmap(global::GUI.Properties.Resources.nghiepvu);
        }

        private void btnNghiepVu_MouseMove(object sender, MouseEventArgs e)
        {
            btnNghiepVu.Image = new Bitmap(global::GUI.Properties.Resources.nghiepvu1);
        }

        private void btnKhoHang_MouseLeave(object sender, EventArgs e)
        {
            btnKhoHang.Image = new Bitmap(global::GUI.Properties.Resources.khohang);
        }

        private void btnKhoHang_MouseMove(object sender, MouseEventArgs e)
        {
            btnKhoHang.Image = new Bitmap(global::GUI.Properties.Resources.khohang1);
        }

        private void btnBaoCao_MouseLeave(object sender, EventArgs e)
        {
            btnBaoCao.Image = new Bitmap(global::GUI.Properties.Resources.baocao);
        }

        private void btnBaoCao_MouseMove(object sender, MouseEventArgs e)
        {
            btnBaoCao.Image = new Bitmap(global::GUI.Properties.Resources.baocao1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = new Bitmap(global::GUI.Properties.Resources.thoat1);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Image = new Bitmap(global::GUI.Properties.Resources.thoat11);
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlyphongban", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanlyphongban"))
            {
                return;
            }
            frmQuanlyphongban fr = new frmQuanlyphongban();
            closeall(fr.Name);
            fr.MdiParent = this;
            fr.Show();

        }

        private void nhómTkToolStripMenuItem_Click(object sender, EventArgs e)
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
            frmQuanLyNhomTKKeToan a = new frmQuanLyNhomTKKeToan();
            closeall(a.Name);
            a.MdiParent = this;
            a.Show();
        }

        private void thẻGiảmGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator)
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmQuanLyTheGiamGia"))
            {
                return;
            }
            frmQuanLyTheGiamGia frm = new frmQuanLyTheGiamGia();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoXuấtHủyHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatHuyHangHoa", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCXuatHuyHangHoa"))
            {
                return;
            }
            frmBCXuatHuyHangHoa frm = new frmBCXuatHuyHangHoa();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoTrảLạiNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCTraLaiNCC", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCTraLaiNCC"))
            {
                return;
            }
            frmBCTraLaiNCC frm = new frmBCTraLaiNCC();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoKháchHàngTrảLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCKhachHangTraHang", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCKhachHangTraHang"))
            {
                return;
            }
            frmBCKhachHangTraHang frm = new frmBCKhachHangTraHang();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void tổngHợpXuấtNhậpTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanLyKiemKeKho", 1))
            //{
            //    MessageBox.Show(" Không có quyền vào chức năng này.");
            //    return;
            //}
            //if (!Check("frmQuanLyKiemKeKho"))
            //{
            //    return;
            //}
            //frmQuanLyKiemKeKho frm = new frmQuanLyKiemKeKho();
            //closeall(frm.Name);
            //frm.MdiParent = this;
            //frm.Show(); 
        }

        private void báoCáoLãiLỗToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCLaiLo", 1))
            {

                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCLaiLo"))
            {
                return;
            }
            frmBCLaiLo frm = new frmBCLaiLo();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tooltripBaoCaoHangHetHan_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBaoCaoHanSuDung", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBaoCaoHanSuDung"))
            {
                return;
            }
            // Check quyen 
            frmBaoCaoHanSuDung frm = new frmBaoCaoHanSuDung();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmChinh_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (this.isFormClose)
            {
                if (!Exit())
                    e.Cancel = true;
            }
            else
            {
                if (this.isClose)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Thoat Chuong Trinh.
        /// </summary>
        /// <returns></returns>
        private bool Exit()
        {
            bool retVal = false;
            DialogResult giatri = MessageBox.Show("Bạn chắc chắn muốn thoát không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == DialogResult.Yes)
                {
                    if (Luu.Server.Equals("server"))
                    {
                        System.Windows.Forms.DialogResult giatri2 = System.Windows.Forms.MessageBox.Show("Bạn có muốn sao lưu lại dữ liệu trước khi thoát không ?", "Hệ Thống Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (giatri2 == System.Windows.Forms.DialogResult.Yes)
                        {
                            new BizLogic.SaoLuuHeThong().BackUp("");
                        }
                        try
                        {
                            Luu.maychu.ThoatServer();
                        }
                        catch
                        {
                        }
                    }
                    retVal = true;
                }
                else if (giatri == DialogResult.No)
                {
                    //không làm gì cả
                    retVal = false;
                }

                return retVal;
            }
        }

        private void tooltripBaoCaoTongHopThuChi_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBaoCaoTongHopThuChi", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBaoCaoTongHopThuChi"))
            {
                return;
            }
            frmBaoCaoTongHopThuChi frm = new frmBaoCaoTongHopThuChi();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoThuTiềnThẻGiáTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCThuTienTheGiaTri", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCThuTienTheGiaTri"))
            {
                return;
            }
            frmBCThuTienTheGiaTri frm = new frmBCThuTienTheGiaTri();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiềnTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCTienTonKho", 1))
            {
                MessageBox.Show(" Không có quyền vào chức năng này.");
                return;
            }
            if (!Check("frmBCTienTonKho"))
            {
                return;
            }
            frmBCTienTonKho frm = new frmBCTienTonKho();
            closeall(frm.Name);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
