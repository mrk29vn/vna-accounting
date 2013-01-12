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
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
            try
            {
                ucBaoCao baocao = new ucBaoCao();
                baocao.BCDoanhThu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCDoanhThu_MouseDown);
                baocao.BCCongNo.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCCongNo_MouseDown);
                baocao.BCNhapHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCNhapHang_MouseDown);
                baocao.BCTonKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCTonKho_MouseDown);
                baocao.BCXuatHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(BCXuatHang_MouseDown);
                elementHost_BaoCao.Child = baocao;
            }
            catch 
            {
            }

        }

        void BCXuatHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ucBaoCaoXuatHang bcxuathang = new ucBaoCaoXuatHang();
            bcxuathang.bcXHTheoHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bcxuathang.bcXHTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bcxuathang.bcXHTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bcxuathang.bcXHTheoTG.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            elementHost_BaoCao.Child = bcxuathang;
        }
        void BCTonKho_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ucBaoCaoTonKho bctonkho = new ucBaoCaoTonKho();
            bctonkho.bcMucTonToiThieuToiDa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bctonkho.bcTonKhoTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bctonkho.bcTonKhoTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bctonkho.bcXNTTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bctonkho.bcXNTTheoLoaiHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bctonkho.bcXNTTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bctonkho.bcXNTTheoPhieuXuatHuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            elementHost_BaoCao.Child = bctonkho;
        }
        void BCNhapHang_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ucBaoCaoNhapHang bcnhaphang = new ucBaoCaoNhapHang();
            bcnhaphang.bcNHTheoHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bcnhaphang.bcNHTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bcnhaphang.bcNHTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bcnhaphang.bcNHTheoTG.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            elementHost_BaoCao.Child = bcnhaphang;
        }
        void BCCongNo_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ucBaoCaoCongNo bccongn = new ucBaoCaoCongNo();
            bccongn.bcCNTheoKH.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            bccongn.bcCNTheoNCC.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            elementHost_BaoCao.Child = bccongn;
        }
        void BCDoanhThu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ucBaoCaoDoanhThu doanhthu = new ucBaoCaoDoanhThu();
            doanhthu.bcDTTheoHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            doanhthu.bcDTTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            doanhthu.bcDTTheoNV.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            doanhthu.bcDTTheoTG.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            doanhthu.bcLaiLo.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
            elementHost_BaoCao.Child = doanhthu;
        }


        public static string BaoCao = "";
        public frmBaoCao(string BaoCao)
        {
            InitializeComponent();
            frmBaoCao.BaoCao = BaoCao;

        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                        this.WindowState = FormWindowState.Maximized;
                        switch (BaoCao)
                        {
                            case "DoanhThu":
                                {
                                    //DoanhThu = new string[5];
                                    //DoanhThu[0] = "Báo cáo doanh thu theo thời gian";
                                    //DoanhThu[1] = "Báo cáo doanh thu theo nhân viên";
                                    //DoanhThu[2] = "Báo cáo doanh thu theo nhóm hàng";
                                    //DoanhThu[3] = "Báo cáo doanh thu theo hàng hóa";
                                    //DoanhThu[4] = "Báo cáo lãi lỗ";
                                    //Load_Label(DoanhThu);
                                    ucBaoCaoDoanhThu doanhthu = new ucBaoCaoDoanhThu();
                                    doanhthu.bcDTTheoHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    doanhthu.bcDTTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    doanhthu.bcDTTheoNV.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    doanhthu.bcDTTheoTG.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    doanhthu.bcLaiLo.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    elementHost_BaoCao.Child = doanhthu;
                                    break;
                                }
                            case "CongNo":
                                {
                                    ucBaoCaoCongNo bccongn = new ucBaoCaoCongNo();
                                    bccongn.bcCNTheoKH.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bccongn.bcCNTheoNCC.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    elementHost_BaoCao.Child = bccongn;
                                    break;
                                }
                            case "XuatHang":
                                {
                                    ucBaoCaoXuatHang bcxuathang = new ucBaoCaoXuatHang();
                                    bcxuathang.bcXHTheoHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bcxuathang.bcXHTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bcxuathang.bcXHTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bcxuathang.bcXHTheoTG.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    elementHost_BaoCao.Child = bcxuathang;
                                    break;
                                }
                            case "NhapHang":
                                {
                                    ucBaoCaoNhapHang bcnhaphang = new ucBaoCaoNhapHang();
                                    bcnhaphang.bcNHTheoHangHoa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bcnhaphang.bcNHTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bcnhaphang.bcNHTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bcnhaphang.bcNHTheoTG.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    elementHost_BaoCao.Child = bcnhaphang;
                                    break;
                                }
                            case "TonKho":
                                {
                                    ucBaoCaoTonKho bctonkho = new ucBaoCaoTonKho();
                                    bctonkho.bcMucTonToiThieuToiDa.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bctonkho.bcTonKhoTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bctonkho.bcTonKhoTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bctonkho.bcXNTTheoKho.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bctonkho.bcXNTTheoLoaiHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bctonkho.bcXNTTheoNhomHang.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    bctonkho.bcXNTTheoPhieuXuatHuy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(temp_Click);
                                    elementHost_BaoCao.Child = bctonkho;
                                    break;
                                }
                        }
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

        void temp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image temp = (System.Windows.Controls.Image)sender;
            switch (temp.ToolTip.ToString())
            {
                #region Doanh Thu
                case "Báo cáo lãi lỗ":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCLaiLo", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCLaiLo"))
                        {
                            return;
                        }
                        frmBCLaiLo frm = new frmBCLaiLo();
                        
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo doanh thu theo thời gian": 
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmtg", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        frmtg frm=new frmtg();
                        frm.ShowDialog();
                        break; 
                    }
                case "Báo cáo doanh thu theo nhân viên":
                    {

                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCDoanhThuNhanVien", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCDoanhThuNhanVien"))
                        {
                            return;
                        }
                        frmBCDoanhThuTheoNhanVien frm = new frmBCDoanhThuTheoNhanVien();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo doanh thu theo nhóm hàng":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCDoanhThuNhomHang", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCDoanhThuNhomHang"))
                        {
                            return;
                        }
                        frmBCDoanhThuNhomHang frm = new frmBCDoanhThuNhomHang();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo doanh thu theo hàng hóa":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCDoanhThuHangHoa", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCDoanhThuHangHoa"))
                        {
                            return;
                        }
                        frmBCDoanhThuHangHoa frm = new frmBCDoanhThuHangHoa();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
#endregion
                #region Công Nợ
                case "Báo cáo công nợ theo nhà cung cấp":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCCongNoNhaCungCap", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCCongNoNhaCungCap"))
                        {
                            return;
                        }
                        frmBCCongNoNhaCungCap frm = new frmBCCongNoNhaCungCap();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo công nợ theo khách hàng":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCCongNoKhachHang", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCCongNoKhachHang"))
                        {
                            return;
                        }
                        frmBCCongNoKhachHang frm = new frmBCCongNoKhachHang();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                #endregion
                #region Xuất Hàng
                case "Báo cáo xuất hàng theo từng kho":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatHangTheoTungKho", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        frmBCXuatHangTheoTungKho frm = new frmBCXuatHangTheoTungKho();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo xuất hàng theo từng nhóm hàng":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatHangTheoNhomHang", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCXuatHangTheoNhomHang"))
                            return;
                        frmBCXuatHangTheoNhomHang frm = new frmBCXuatHangTheoNhomHang();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo xuất hàng theo từng hàng hóa":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatHangTheoHangHoa", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCXuatHangTheoHangHoa"))
                            return;
                        frmBCXuatHangTheoHangHoa frm = new frmBCXuatHangTheoHangHoa();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo xuất hàng theo thời gian":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatHangTheoThoiGian", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCXuatHangTheoThoiGian"))
                            return;
                        frmBCXuatHangTheoThoiGian frm = new frmBCXuatHangTheoThoiGian();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();

                        break;
                    }
                #endregion
                #region Nhập Hàng chưa ghép===============================================================================================================
                case "Báo cáo nhập hàng theo từng kho":
                    {
                        try
                        {
                            if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCNhapHangTheoKho", 1))
                            {
                                MessageBox.Show("Không có quyền vào chức năng này");
                                return;
                            }
                            frmBCNhapHangTheoKho frm = new frmBCNhapHangTheoKho();
                            
                            if (!Check("frmBCNhapHangTheoKho"))
                            {
                                return;
                            }
                           
                            frm.MdiParent = this.MdiParent;
                            closeall(frm.Name);
                            frm.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Báo cáo nhập hàng theo thời gian":
                    {
                        try
                        {
                            if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCNhapHangTheoThoiGian", 1))
                            {
                                MessageBox.Show("Không có quyền vào chức năng này");
                                return;
                            }
                            frmBCNhapHangTheoThoiGian frm = new frmBCNhapHangTheoThoiGian();

                            if (!Check("frmBCNhapHangTheoThoiGian"))
                            {
                                return;
                            }

                            frm.MdiParent = this.MdiParent;
                            closeall(frm.Name);
                            frm.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Báo cáo nhập hàng theo từng nhóm hàng":
                    {
                        try
                        {
                            if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCNhapHangTheoNhom", 1))
                            {
                                MessageBox.Show("Không có quyền vào chức năng này");
                                return;
                            }
                            frmBCNhapHangTheoNhom frm = new frmBCNhapHangTheoNhom();
                            
                            if (!Check("frmBCNhapHangTheoNhom"))
                            {
                                return;
                            }
                            closeall(frm.Name);
                            frm.MdiParent = this.MdiParent;
                            frm.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Báo cáo nhập hàng theo từng hàng hóa":
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
                            
                            frm.MdiParent = this.MdiParent;
                            closeall(frm.Name);
                            frm.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                #endregion
                #region Tồn Kho còn thiếu phiếu xuất nhập tồn theo nhóm hàng
                case "Báo cáo tồn kho theo kho":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCTonKhoTheoKho", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCTonKhoTheoKho"))
                        {
                            return;
                        }
                        frmBCTonKhoTheoKho frm = new frmBCTonKhoTheoKho();
                        
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo tồn kho theo nhóm hàng":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCTonKhoTheoNhomHang", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCTonKhoTheoNhomHang"))
                        {
                            return;
                        }
                        frmBCTonKhoTheoNhomHang frm = new frmBCTonKhoTheoNhomHang();
                        
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo xuất nhập tồn theo kho":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatNhapTonTheoKho", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCXuatNhapTonTheoKho"))
                        {
                            return;
                        }
                        frmBCXuatNhapTonTheoKho frm = new frmBCXuatNhapTonTheoKho();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo xuất nhập tồn theo nhóm hàng":
                    {
                        if (!frmDangNhap.User.Administrator && !CheckQuyen("frmBCXuatNhapTonNhomHang", 1))
                        {
                            MessageBox.Show(" Không có quyền vào chức năng này.");
                            return;
                        }
                        try
                        {
                            frmBCXuatNhapTonNhomHang frm = new frmBCXuatNhapTonNhomHang();

                            if (!Check("frmBCXuatNhapTonNhomHang"))
                            {
                                return;
                            }
                            
                            frm.MdiParent = this.MdiParent;
                            closeall(frm.Name);
                            frm.Show();

                        }
                        catch (Exception ex)
                        { string s = ex.Message; }
                        break;
                    }
                case "Báo cáo xuất nhập tồn theo phiếu xuất nhập":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatNhapTonPhieuXuatNhap", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCXuatNhapTonPhieuXuatNhap"))
                        {
                            return;
                        }
                        frmBCXuatNhapTonPhieuXuatNhap frm = new frmBCXuatNhapTonPhieuXuatNhap();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo xuất nhập tồn theo loại hàng":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCXuatNhapTonLoaiHang", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCXuatNhapTonLoaiHang"))
                        {
                            return;
                        }
                        frmBCXuatNhapTonLoaiHang frm = new frmBCXuatNhapTonLoaiHang();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                case "Báo cáo Mức Tồn Tối Thiểu - Tối Đa":
                    {
                        if (!Common.Utilities.User.Administrator && !CheckQuyen("frmBCMucTonToiThieuToiDa", 1))
                        {
                            MessageBox.Show("không có quyền vào báo cáo này");
                            return;
                        }
                        if (!Check("frmBCMucTonToiThieuToiDa"))
                        {
                            return;
                        }
                        frmBCMucTonToiThieuToiDa frm = new frmBCMucTonToiThieuToiDa();
                        frm.MdiParent = this.MdiParent;
                        closeall(frm.Name);
                        frm.Show();
                        
                        break;
                    }
                #endregion
            }
        }

        private void frmBaoCao_Activated(object sender, EventArgs e)
        {
            this.frmBaoCao_Load(sender, e);
        }

        public bool Check(string form)
        {
            Form[] frm = this.ParentForm.MdiChildren;
            foreach (Form temp in frm)
            {
                if (temp.Name.Equals(form))
                {
                    temp.Activate();
                    return false;
                }
            }
            return true;
        }

        #region check quyen
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
        #endregion
        void closeformmain()
        {
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item.Name.Equals("frmTrangChinh") || item.Name.Equals("frmDanhMuc") || item.Name.Equals("frmNghiepVu") || item.Name.Equals("frmKhoHang") || item.Name.Equals("frmBaoCao"))
                {
                    item.Close();
                }
            }
        }

        void closeall(string Name)
        {
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (!item.Name.Equals(Name))
                    item.Close();
            }
        }

        void Load_Label(string[] arr)
        {
            if (arr == null)
                return;
            // groupBox1.Controls.Clear();
            int x = 180;
            int y = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Label temp = new Label();
                temp.Text = arr[i];
                temp.Location = new Point(x, 19 + (25 * y));
                temp.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                temp.ForeColor = Color.Black;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.Size = new System.Drawing.Size(250, 20);
                // temp.Click += new EventHandler(temp_Click);
                //groupBox1.Controls.Add(temp);
                y++;
                if ((i + 1) % 10 == 0 && i > 0)
                {
                    x += 250;
                    y = 0;
                }
            }
            Panel pnlBC = new Panel();
            pnlBC.BackgroundImage = Properties.Resources.Bao_Cao__3_;
            pnlBC.Location = new System.Drawing.Point(24, 19);
            pnlBC.Name = "pnlBC";
            pnlBC.Size = new System.Drawing.Size(128, 128);
            // groupBox1.Controls.Add(pnlBC);
        }


    }
}

