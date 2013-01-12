using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace Server_Client
{
    public class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        public TcpClient client;
        private System.Timers.Timer Time;
        #region Phần xử lý - không động gì vào
        /// <summary>
        /// Server
        /// </summary>
        public Server(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            Time = new System.Timers.Timer();
            Time.Interval = 3600000;
            Time.Elapsed += new System.Timers.ElapsedEventHandler(Time_Elapsed);
            Time.Start();
            this.listenThread.Start();

        }
        void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 22)
            {
                if (DateTime.Now.Day == DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                {
                }
                new BizLogic.SaoLuuHeThong().BackUp();
            }

        }
        public void ThoatServer()
        {
            tcpListener.Stop();
        }
        /// <summary>
        /// ListtenForClient
        /// </summary>
        private void ListenForClients()
        {
            try
            {
                this.tcpListener.Start();
                while (true)
                {
                    // mặc định cho Client kết nối
                    client = this.tcpListener.AcceptTcpClient();
                    // mỗi client ứng vs 1 Thread
                    Thread clientThread = new Thread(new ParameterizedThreadStart(Process));
                    clientThread.Start(client);
                }
            }
            catch { }
        }

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="client"></param>
        private void Process(object client)
        {
            using (TcpClient tcpClient = (TcpClient)client)
            {
                using (NetworkStream clientStream = tcpClient.GetStream())
                {
                    while (true)
                    {
                        try
                        {
                            IFormatter formatter = new BinaryFormatter();
                            string objectName = (string)formatter.Deserialize(clientStream);
                            // truyền vào method Bussiness
                            bool kt = Bussiness(clientStream, objectName);
                            if (kt == false)
                            {
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message;
                            // lỗi thì ngừng vòng lặp
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        IFormatter formatter = new BinaryFormatter();
        /// <summary>
        /// Business
        /// </summary>
        /// <param name="clientStream"></param>
        /// <param name="objectName"></param>
        /// <returns></returns>
        private bool Bussiness(NetworkStream clientStream, string objectName)
        {

            bool isSuccessfuly = false;
            try
            {
                switch (objectName)
                {
                    #region Server Của Sơn
                    case "NhanVien":
                        {
                            Xuly_NhanVien(clientStream);
                        }
                        break;
                    case "PhongBan":
                        {
                            Xuly_PhongBan(clientStream);
                        }
                        break;
                    case "TienTe":
                        {
                            Xuly_TienTe(clientStream);
                        }
                        break;
                    case "NhomTKKeToan":
                        {
                            Xuly_NhomTKKeToan(clientStream);
                        }
                        break;
                    case "TKKeToan":
                        {
                            Xuly_TKKeToan(clientStream);
                        }
                        break;
                    case "TKNganHang":
                        {
                            Xuly_TKNganHang(clientStream);
                        }
                        break;
                    case "KMThuChi":
                        {
                            Xuly_KMThuChi(clientStream);
                        }
                        break;
                    case "PhieuDieuCHuyenKhoNoiBo":
                        {
                            Xuly_PhieuDieuChuyenKho(clientStream);
                        }
                        break;
                    case "ChiTietPhieuDieuCHuyenKhoNoiBo":
                        {
                            Xuly_ChiTietPhieuDieuChuyenKho(clientStream);
                        }
                        break;
                    case "ChiTietKho":
                        {
                            Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkho = (Entities.ChiTietKhoHangTheoHoaHonNhap[])new BizLogic.ChiTietKhoHangTheoHoaHonNhap().Select();
                            formatter.Serialize(clientStream, ctkho);
                        }
                        break;
                    case "ChiTietKhoTheoKho":
                        {
                            Entities.ChiTietKhoHangTheoHoaHonNhap ctKhoHang = (Entities.ChiTietKhoHangTheoHoaHonNhap)formatter.Deserialize(clientStream);
                            Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkho = (Entities.ChiTietKhoHangTheoHoaHonNhap[])new BizLogic.ChiTietKhoHangTheoHoaHonNhap().SelectTheoMaKho(ctKhoHang.Makho);
                            formatter.Serialize(clientStream, ctkho);
                        }
                        break;
                    case "ChiTietKhoAll":
                        {
                            Entities.ChiTietKhoHang[] ctkArr = (Entities.ChiTietKhoHang[])new BizLogic.ChiTietKhoHangTheoHoaHonNhap().SelectAll();
                            formatter.Serialize(clientStream, ctkArr);
                        }
                        break;
                    case "CapNhatGia":
                        {
                            Xuly_CapNhatGia(clientStream);
                        }
                        break;
                    case "SoDuKho":
                        {
                            Xuly_SoDuKho(clientStream);
                        }
                        break;
                    case "ThemArr":
                        {
                            Entities.SoDuKho[] nv = (Entities.SoDuKho[])formatter.Deserialize(clientStream);
                            bool msg = new BizLogic.SoDuKho().InsertArr(nv);
                            formatter.Serialize(clientStream, msg);
                        }
                        break;
                    case "XoaArr":
                        {
                            Entities.SoDuKho[] nv = (Entities.SoDuKho[])formatter.Deserialize(clientStream);
                            bool msg = new BizLogic.SoDuKho().DeleteArr(nv);
                            formatter.Serialize(clientStream, msg);
                        }
                        break;
                    #endregion
                    #region Server Của hòa
                    case "PhieuThu": XuLy_PhieuThu(clientStream); break;
                    case "PhieuTTCuaKH": XuLy_PhieuTTCuaKH(clientStream); break;
                    case "PhieuTTNCC": XuLy_PhieuTTNCC(clientStream); break;
                    case "PhieuXuatHuy": XuLy_PhieuXuatHuy(clientStream); break;
                    case "PhieuXuatHuyMang": XuLy_PhieuXuatHuyMang(clientStream); break;
                    case "HDBanHang": XuLy_HDBanHang(clientStream); break;
                    case "ChiTietHDBanHang": XuLy_ChiTietHDBanHang(clientStream); break;
                    case "HDBanHangMang": XuLy_HDBanHangMang(clientStream); break;
                    case "HoaDonNhapMang": XuLy_HoaDonNhapMang(clientStream); break;
                    case "ChiTietHDBanHangMang": XuLy_ChiTietHDBanHangMang(clientStream); break;
                    case "ChiTietXuatHuy": XuLy_ChiTietXuatHuy(clientStream); break;
                    case "ChiTietXuatHuyMang": XuLy_ChiTietXuatHuyMang(clientStream); break;
                    case "ChiTietPhieuTTNCC": XuLy_ChiTietPhieuTTNCC(clientStream); break;
                    case "ChiTietPhieuTTNCCMang": XuLy_ChiTietPhieuTTNCCMang(clientStream); break;
                    case "ChiTietPhieuTTCuaKH": XuLy_ChiTietPhieuTTCuaKH(clientStream); break;
                    case "ChiTietPhieuTTCuaKHMang": XuLy_ChiTietPhieuTTCuaKHMang(clientStream); break;
                    case "LayID": XuLy_LayID(clientStream); break;
                    case "QuayThuNgan": XuLy_QuayThuNgan(clientStream); break;
                    case "Thue": XuLy_Thue(clientStream); break;
                    case "SoQuy": XuLy_SoQuy(clientStream); break;
                    case "CongNo": XuLy_CongNo(clientStream); break;
                    case "HDN": { XuLy_HDN(clientStream); } break;
                    case "KHTL": { XuLy_KHTL(clientStream); } break;
                    case "TLNCC": { XuLy_TLNCC(clientStream); } break;
                    // Phần của Hưởng
                    case "BCDTTheoHangHoa": XuLy_BCDTTheoHangHoa(clientStream); break;
                    case "BCDTTheoNhanVien": XuLy_BCDTTheoNhanVien(clientStream); break;
                    case "BCDTTheoNhomHang": XuLy_BCDTTheoNhomHang(clientStream); break;
                    case "BCDTTheoThoiGian": XuLy_BCDTTheoThoiGian(clientStream); break;
                    case "BCHDBanHang": XuLy_BCHDBanHang(clientStream); break;
                    case "BCHDBanBuon": XuLy_BCHDBanBuon(clientStream); break;
                    case "BCTonKhoTheoKho": XuLy_TonKhoTheoKho(clientStream); break;
                    case "BCTonKhoTheoNhom": XuLy_TonKhoTheoNhom(clientStream); break;
                    case "CheckRefer": Xuly_CheckRefer(clientStream); break;
                    case "Select": Xuly_Select(clientStream); break;
                    case "TheGiamGia": XulyTheGiamGia(clientStream); break;
                    case "Datetime": DateServer(clientStream); break;
                    #endregion
                    #region Server Hương
                    case "GoiHang":
                        XuLy_GoiHang(clientStream);
                        break;
                    case "KhuyenMaiSoLuong":
                        XuLy_KhuyenMaiSoLuong(clientStream);
                        break;
                    case "ChiTietGoiHang":
                        XuLy_ChiTietGoiHang(clientStream);
                        break;
                    case "QuyDoiDonViTinh":
                        XuLy_QuyDoiDonViTinh(clientStream);
                        break;
                    case "KhachHang":
                        XuLy_KhachHang(clientStream);
                        break;
                    case "NhaCungCap":
                        XuLy_NhaCungCap(clientStream);
                        break;
                    case "DonHang":
                        {
                            XuLy_DonHang(clientStream);
                        }
                        break;
                    case "XuatHang":
                        {
                            XuLy_XuatHang(clientStream);
                        }
                        break;
                    case "TraLai":
                        {
                            XuLy_TraLai(clientStream);
                        }
                        break;
                    case "ThanhToan":
                        {
                            XuLy_ThanhToan(clientStream);
                        }
                        break;
                    case "LSGDHangHoa":
                        {
                            XuLy_LSGDHangHoa(clientStream);
                        }
                        break;
                    case "LSGDNhapMua":
                        {
                            XuLy_LSGDNhapMua(clientStream);
                        }
                        break;
                    case "LSGDTraLaiNCC":
                        {
                            XuLy_LSGDTraLaiNCC(clientStream);
                        }
                        break;
                    case "LSGDTTNCC":
                        {
                            XuLy_LSGDTTNCC(clientStream);
                        }
                        break;
                    case "CapNhatGiaKH":
                        {
                            XuLy_CapNhatGiaKH(clientStream);
                        }
                        break;
                    case "BaoCaoNhapHangTheoMatHang":
                        {
                            XuLy_BaoCaoNhapHangTheoMatHang(clientStream);
                        }
                        break;
                    case "BaoCaoNhapHangTheoNhomHang":
                        {
                            XuLy_BaoCaoNhapHangTheoNhomHang(clientStream);
                        }
                        break;
                    case "CongTy":
                        {
                            XuLy_CongTy(clientStream);
                        }
                        break;
                    case "DonHangNCC":
                        {
                            XuLy_DonHangNCC(clientStream);
                        }
                        break;
                    case "ThueH":
                        {
                            XuLy_ThueH(clientStream);
                        }
                        break;
                    case "BCChiTietHangHoa":
                        {
                            XuLy_BCChiTietHangHoa(clientStream);
                        }
                        break;
                    #endregion
                    #region hungvv =====================================================================================================
                    //=================================================hungvv===========================================================
                    case "DonDatHang": { XuLy_DonDatHang(clientStream); } break;
                    case "HoaDonNhap": { XuLy_HoaDonNhap(clientStream); } break;
                    case "KhachHangTraLai": { XuLy_KhachHangTraLai(clientStream); } break;
                    case "TraLaiNhaCungCap": { XuLy_TraLaiNhaCungCap(clientStream); } break;
                    case "ChiTietDonDatHang": { XuLy_ChiTietDonDatHang(clientStream); } break;
                    case "ChiTietHoaDonNhap": { XuLy_ChiTietHoaDonNhap(clientStream); } break;
                    case "ChiTietKiemKeKho": { XuLy_ChiTietKiemKeKho(clientStream); } break;
                    case "ChiTietKhachHangTraLai": { XuLy_ChiTietKhachHangTraLai(clientStream); } break;
                    case "ChiTietTraLaiNhaCungCap": { XuLy_ChiTietTraLaiNhaCungCap(clientStream); } break;
                    case "XoaChiTietDonDatHang": { Xoa_ChiTietDonDatHang(clientStream); } break;
                    case "KiemKeKho": { XuLy_KiemKeKho(clientStream); } break;
                    case "Lay_ID_Top_1": { Lay_ID_Top_1(clientStream); } break;
                    case "ThongTinTienTe": { XuLy_ThongTinTienTe(clientStream); } break;
                    case "ThongTinDatHang": { XuLy_ThongTinDatHang(clientStream); } break;
                    case "ThongTinNhaCungCap": { XuLy_ThongTinNhaCungCap(clientStream); } break;
                    case "ThongTinNhanVienHienThi": { XuLy_ThongTinNhanVienHienThi(clientStream); } break;
                    case "HienThi_ChiTiet_DonDatHang": { XuLy_HienThi_ChiTiet_DonDatHang(clientStream); } break;
                    case "HienThi_ChiTiet_HoaDonNhap": { XuLy_HienThi_ChiTiet_HoaDonNhap(clientStream); } break;
                    case "HangTraLai_KhachHangTraLai_KhachHang": { XuLy_HienThi_ChiTiet_KhachHangTraLai(clientStream); } break;
                    case "ThongTinKhachHang": { XuLy_HienThi_ThongTinKhachHang(clientStream); } break;
                    case "sp_Tim_ID_HoaDonNhap": { XuLy_sp_Tim_ID_HoaDonNhap(clientStream); } break;
                    case "ThongTinMaDonDatHang": { XuLy_HienThi_ThongTinMaDonDatHang(clientStream); } break;
                    case "sp_LayID_KhachHangTraLai": { Top_Mot(clientStream); } break;
                    case "KiemTraMa": { KiemTraMa(clientStream); } break;
                    case "LayCombox": { XuLy_LayCombox(clientStream); } break;
                    case "LayThongTinHoaDonNhap": { XuLy_LayThongTinHoaDonNhap(clientStream); } break;
                    case "ThemchiTietKiemKeKho": { ThemchiTietKiemKeKho(clientStream); } break;
                    case "ThongTinHoaDonBanHang": { ThongTinHoaDonBanHang(clientStream); } break;
                    case "LayDonDatHangNhaCungCap": { LayDonDatHangNhaCungCap(clientStream); } break;
                    case "LayChiTietTraLaiNhaCungCap": { LayChiTietTraLaiNhaCungCap(clientStream); } break;
                    case "ThemChiTietKhoHang": { ThemChiTietKhoHang(clientStream); } break;
                    case "CapNhatTrangThaiDonDatHang": { CapNhatTrangThaiDonDatHang(clientStream); } break;
                    case "LayHangHoaTheoMaHangHoa": { LayHangHoaTheoMaHangHoa(clientStream); } break;
                    case "LayThongTinCongty": { LayThongTinCongty(clientStream); } break;
                    case "BaoCaoXuatHangTheoNhomHang": { BaoCaoXuatHangTheoNhomHang(clientStream); } break;
                    case "BaoCaoXuatHangTheoKho": { BaoCaoXuatHangTheoKho(clientStream); } break;
                    case "ChiTietKhoTheoMaKho": { ChiTietKhoTheoMaKho(clientStream); } break;
                    case "LayThongTinTienTe": { LayThongTinTienTe(clientStream); } break;
                    case "ThongTinMaVachHangHoa": { ThongTinMaVachHangHoa(clientStream); } break;
                    case "TimHoaDonBanHangTheoMaKhachHang": { TimHoaDonBanHangTheoMaKhachHang(clientStream); } break;
                    case "LayHangHoaTheoMaHoaDonBanHang": { LayHangHoaTheoMaHoaDonBanHang(clientStream); } break;
                    case "TimHoaDonNhapTheoMaNhaCungCap": { TimHoaDonNhapTheoMaNhaCungCap(clientStream); } break;
                    case "TimHangHoaTheoMaHoaDonNhap": { TimHangHoaTheoMaHoaDonNhap(clientStream); } break;
                    case "XoaTheoHoaDon": { XoaTheoHoaDon(clientStream); } break;
                    case "CheckDonDatHang": { CheckDonDatHang(clientStream); } break;
                    case "KhoHang": { XuLy_KhoHang(clientStream); } break;
                    case "CheckKhoHang": { CheckKhoHang(clientStream); } break;
                    case "CheckKiemKeKho": { CheckKiemKeKho(clientStream); } break;
                    case "LayKiemKeKhoTheoMaKiemKe": { LayKiemKeKhoTheoMaKiemKe(clientStream); } break;
                    case "CheckHoaDonNhap": { CheckHoaDonNhap(clientStream); } break;
                    case "KiemTraDonDatHang": { KiemTraDonDatHang(clientStream); } break;
                    case "CheckKhachHangTraLai": { CheckKhachHangTraLai(clientStream); } break;
                    case "LayHangHoaTheoMaKhachHangTraLaiHang": { LayHangHoaTheoMaKhachHangTraLaiHang(clientStream); } break;
                    case "CheckTraLaiNhaCungCap": { CheckTraLaiNhaCungCap(clientStream); } break;
                    case "LayHangHoaTheoMaTraLaiNhaCungCap": { LayHangHoaTheoMaTraLaiNhaCungCap(clientStream); } break;
                    case "ChiTietKhachHangTraLaiTheoDonBanHang": { ChiTietKhachHangTraLaiTheoDonBanHang(clientStream); } break;
                    case "BindingKhachHangTralaiHang": { BindingKhachHangTralaiHang(clientStream); } break;
                    case "ThongTinTraLaiNhaCungCap": { ThongTinTraLaiNhaCungCap(clientStream); } break;
                    case "KiemKeHangHoa": { KiemKeHangHoa(clientStream); } break;
                    case "UpdateDuNo": { UpdateDuNo(clientStream); } break;
                    case "BaoCaoNhapHangTheoTungKhoTheoThoiGian": { BaoCaoNhapHangTheoTungKhoTheoThoiGian(clientStream); } break;
                    case "BaoCaoNhapHangTheoTungMatHangTheoThoiGian": { BaoCaoNhapHangTheoTungMatHangTheoThoiGian(clientStream); } break;
                    case "BaoCaoNhapHangTheoTungNhomHangTheoThoiGian": { BaoCaoNhapHangTheoTungNhomHangTheoThoiGian(clientStream); } break;
                    case "TimHangHoaTheoMaNhomHang": { TimHangHoaTheoMaNhomHang(clientStream); } break;
                    case "BaoCaoTraLaiNhaCungcapTheoKy": { BaoCaoTraLaiNhaCungcapTheoKy(clientStream); } break;
                    case "BaoCaoKhachHangTraLaiTheoKy": { BaoCaoKhachHangTraLaiTheoKy(clientStream); } break;
                    case "BaoCaoBanBuonBanLeTheoKy": { BaoCaoBanBuonBanLeTheoKy(clientStream); } break;
                    case "LaySoLuongDaTraLaiTheoHoaDonBanHang": { LaySoLuongDaTraLaiTheoHoaDonBanHang(clientStream); } break;
                    case "LaySoLuongDaTraLaiTheoHoaDonNhap": { LaySoLuongDaTraLaiTheoHoaDonNhap(clientStream); } break;
                    case "CapNhatDuNoKhachHang": { CapNhatDuNoKhachHang(clientStream); } break;
                    case "CapNhatDuNoNhaCungCap": { CapNhatDuNoNhaCungCap(clientStream); } break;
                    case "BaoCaoSoDuKho": { BaoCaoSoDuKho(clientStream); } break;
                    case "LaySoLuongKhachHangTraLaiTheoHoaDonBanHang": { LaySoLuongKhachHangTraLaiTheoHoaDonBanHang(clientStream); } break;
                    case "LaySoLuongDaMuaTheoHoaDonBanHang": { LaySoLuongDaMuaTheoHoaDonBanHang(clientStream); } break;
                    case "LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang": { LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang(clientStream); } break;
                    case "LaySoLuongDaNhapTheoHoaDonNhap": { LaySoLuongDaNhapTheoHoaDonNhap(clientStream); } break;
                    case "LayBang_HangHoaTheoMaKhoHang": { LayBang_HangHoaTheoMaKhoHang(clientStream); } break;
                    case "KiemTraNhomHangHoa": { KiemTraNhomHangHoa(clientStream); } break;
                    case "LayHangHoaGoiHang": { LayHangHoaGoiHang(clientStream); } break;
                    case "LayDonViTinh": { LayDonViTinh(clientStream); } break;
                    case "QuyDoi": { LayQuyDoi(clientStream); } break;
                    case "GetDateTime": { GetDateTime(clientStream); } break;
                    //=================================================hungvv===========================================================
                    #endregion

                    #region Hưởng
                    case "LogIn": LogIn(clientStream); break;
                    //case "LogOut": LogOut(clientStream); break;
                    case "DocFileLog": DocFile(clientStream); break;
                    case "XoaFileLog": XoaFile(clientStream); break;
                    case "LayTaiKhoan": selectTaiKhoan(clientStream); break;
                    case "LayNhomQuyen": selectQuyen(clientStream); break;
                    case "LayChiTietQuyen": selectChiTietQuyen(clientStream); break;
                    case "SuaChiTietQuyen": updateChiTietQuyen(clientStream); break;
                    case "ThemNhomQuyen": insertNhomQuyen(clientStream); break;
                    case "XoaNhomQuyen": deleteNhomQuyen(clientStream); break;
                    case "ThemTaiKhoan": insertTaiKhoan(clientStream); break;
                    case "SuaTaiKhoan": updateTaiKhoan(clientStream); break;
                    case "XoaTaiKhoan": deleteTaiKhoan(clientStream); break;
                    case "LayBackUp": LayBackUp(clientStream); break;
                    case "Restore": { Restore(clientStream); break; }
                    case "LayTheVip": { LayTheVip(clientStream); break; }
                    case "LayTheVipTheoMaKhachHang": { LayTheVipTheoMaKhachHang(clientStream); break; }
                    case "ThemTheVip": { ThemTheVip(clientStream); break; }
                    case "SuaTheVip": { SuaTheVip(clientStream); break; }
                    case "XoaTheVip": { XoaTheVip(clientStream); break; }
                    #endregion

                    #region Server Luan
                    case "HangHoa": XuLy_HangHoa(clientStream); break;
                    case "NhomHang": XuLy_NhomHang(clientStream); break;
                    case "LoaiHangHoa": XuLy_LoaiHangHoa(clientStream); break;
                    case "DVT": XuLy_DVT(clientStream); break;
                    case "LoaiThue": XuLy_LoaiThue(clientStream); break;

                    #endregion

                    #region Mrk
                    case "GiaVon_k": { THAOTAC_GiaVon_k(clientStream); break; }
                    case "KhachHang_k": { THAOTAC_KhachHang_k(clientStream); break; }
                    case "THAOTAC_InMaVachTheVip": { THAOTAC_InMaVachTheVip(clientStream); break; }
                    case "THAOTAC_InMaVachTheGiaTri": { THAOTAC_InMaVachTheGiaTri(clientStream); break; }
                    case "ThaoTac_UpdateDuNo_k": { ThaoTac_UpdateDuNo_k(clientStream); break; }
                    case "insertTyLeTinh": { Insert_TyLeTinh(clientStream); break; }
                    case "selectTyLeTinh": { Select_TyLeTinh(clientStream); break; }
                    case "DiemThuongKhachHang": { ThemSuaXoaDiemThuongKhachHang(clientStream); break; }
                    case "SelectDiemThuongKhachHang": { SelectDiemThuongKhachHang(clientStream); break; }
                    case "ChiTietTheGiamGia": { ThemSuaXoaChiTietTheGiamGia(clientStream); break; }
                    case "SelectChiTietTheGiamGia": { SelectChiTietTheGiamGia(clientStream); break; }
                    case "Select_sp_BCNhapHangTheoNhomHangFIX": { Select_sp_BCNhapHangTheoNhomHangFIX(clientStream); break; }
                    #endregion

                    #region Lamtv
                    case "GiaVonBanHang":
                        {
                            Xuly_GiaVonBanHang(clientStream);
                        }

                        break;
                    #endregion

                    default:
                        break;
                }
                isSuccessfuly = true;
            }
            catch
            {
                isSuccessfuly = false;
            }

            return isSuccessfuly;
        }

        #region Mrk
        private void THAOTAC_GiaVon_k(NetworkStream clientStream)
        {
            ArrayList KArr = (ArrayList)formatter.Deserialize(clientStream);
            if (KArr != null)
            {
                if (KArr.Count > 0) //KArr.Count >= 4
                {
                    //Truyền tên hàm cần chạy
                    string FUNCTION_RUN = KArr[0].ToString();
                    //Truyền các parameters cho nó
                    string THAOTAC = KArr[1].ToString();
                    Entities.GiaVon set = (Entities.GiaVon)KArr[2];
                    Entities.GiaVon filter = (Entities.GiaVon)KArr[3];

                    if (FUNCTION_RUN.Equals("ThaoTac_GiaVon"))
                    {
                        int kq = new BizLogic.GiaVon().ThaoTac_GiaVon(THAOTAC, set, filter);
                        formatter.Serialize(clientStream, kq);
                    }
                    else if (FUNCTION_RUN.Equals("SelectTheoDieuKien_GiaVon"))
                    {
                        Entities.GiaVon[] kq = new BizLogic.GiaVon().SelectTheoDieuKien_GiaVon(THAOTAC, set, filter);
                        formatter.Serialize(clientStream, kq);
                    }
                }
            }
        }

        private void THAOTAC_KhachHang_k(NetworkStream clientStream)
        {
            ArrayList KArr = (ArrayList)formatter.Deserialize(clientStream);
            if (KArr != null)
            {
                if (KArr.Count > 0) //KArr.Count >= 4
                {
                    //Truyền tên hàm cần chạy
                    string FUNCTION_RUN = KArr[0].ToString();
                    //Truyền các parameters cho nó
                    string THAOTAC = KArr[1].ToString();
                    Entities.KhachHang_k set = (Entities.KhachHang_k)KArr[2];
                    Entities.KhachHang_k filter = (Entities.KhachHang_k)KArr[3];

                    if (FUNCTION_RUN.Equals("ThaoTac_KhachHang"))
                    {
                        int kq = new BizLogic.KhachHang_k().ThaoTac_KhachHang(THAOTAC, set, filter);
                        formatter.Serialize(clientStream, kq);
                    }
                    else if (FUNCTION_RUN.Equals("SelectTheoDieuKien_KhachHang"))
                    {
                        Entities.KhachHang_k[] kq = new BizLogic.KhachHang_k().SelectTheoDieuKien_KhachHang(THAOTAC, set, filter);
                        formatter.Serialize(clientStream, kq);
                    }
                }
            }
        }

        private void THAOTAC_InMaVachTheVip(NetworkStream clientStream)
        {
            Entities.ThongTinMaVach[] select = (Entities.ThongTinMaVach[])new BizLogic.ThongTinMaVach().sp_LayBang_ThongTinMaVachTheVip();
            formatter.Serialize(clientStream, select);
        }

        private void THAOTAC_InMaVachTheGiaTri(NetworkStream clientStream)
        {
            Entities.ThongTinMaVach[] select = (Entities.ThongTinMaVach[])new BizLogic.ThongTinMaVach().sp_LayBang_ThongTinMaVachTheGiaTri();
            formatter.Serialize(clientStream, select);
        }

        private void ThaoTac_UpdateDuNo_k(NetworkStream clientStream)
        {
            Entities.UpdateDuNoK29 dauvao = (Entities.UpdateDuNoK29)formatter.Deserialize(clientStream);
            int msg = new BizLogic.UpdateDuNo().ThaoTac_UpdateDuNo(dauvao);
            formatter.Serialize(clientStream, msg);
        }

        //Tỷ Lệ Tính
        private void Insert_TyLeTinh(NetworkStream clientStream)
        {
            Entities.TyLeTinh input = (Entities.TyLeTinh)formatter.Deserialize(clientStream);
            int msg = new BizLogic.TyLeTinh().InsertTyLeTinh(input);
            formatter.Serialize(clientStream, msg);
        }

        private void Select_TyLeTinh(NetworkStream clientStream)
        {
            Entities.TyLeTinh[] select = (Entities.TyLeTinh[])new BizLogic.TyLeTinh().SelectTyLeTinh();
            formatter.Serialize(clientStream, select);
        }

        //Điểm thưởng khách hàng
        private void ThemSuaXoaDiemThuongKhachHang(NetworkStream clientStream)
        {
            Entities.DiemThuongKhachHang input = (Entities.DiemThuongKhachHang)formatter.Deserialize(clientStream);
            int msg = new BizLogic.DiemThuongKhachHang().ThemSuaXoaDiemThuongKhachHang(input);
            formatter.Serialize(clientStream, msg);
        }

        private void SelectDiemThuongKhachHang(NetworkStream clientStream)
        {
            Entities.DiemThuongKhachHang input = (Entities.DiemThuongKhachHang)formatter.Deserialize(clientStream);
            Entities.DiemThuongKhachHang[] select = (Entities.DiemThuongKhachHang[])new BizLogic.DiemThuongKhachHang().SelectDiemThuongKhachHang(input);
            formatter.Serialize(clientStream, select);
        }

        //Chi Tiết Thẻ Giảm Giá
        private void ThemSuaXoaChiTietTheGiamGia(NetworkStream clientStream)
        {
            Entities.ChiTietTheGiamGia input = (Entities.ChiTietTheGiamGia)formatter.Deserialize(clientStream);
            int msg = new BizLogic.ChiTietTheGiamGia().ThemSuaXoaChiTietTheGiamGia(input);
            formatter.Serialize(clientStream, msg);
        }

        private void SelectChiTietTheGiamGia(NetworkStream clientStream)
        {
            Entities.ChiTietTheGiamGia input = (Entities.ChiTietTheGiamGia)formatter.Deserialize(clientStream);
            Entities.ChiTietTheGiamGia[] select = (Entities.ChiTietTheGiamGia[])new BizLogic.ChiTietTheGiamGia().SelectChiTietTheGiamGia(input);
            formatter.Serialize(clientStream, select);
        }

        //Báo cáo nhập hàng theo nhóm hàng
        public void Select_sp_BCNhapHangTheoNhomHangFIX(NetworkStream clientStream)
        {
            formatter.Serialize(clientStream, new BizLogic.BCNhapHangTheoNhomHang().Select());
        }
        #endregion

        #region CheckRefer
        /// <summary>
        /// check hàng hóa
        /// </summary>
        /// <param name="clientStream"></param>
        public void Xuly_CheckRefer(NetworkStream clientStream)
        {
            Entities.CheckRefer nv = (Entities.CheckRefer)formatter.Deserialize(clientStream);
            bool kt = false;
            kt = new BizLogic.CheckRefer().CheckReferen(nv);
            formatter.Serialize(clientStream, kt);
            return;
        }
        public void DateServer(NetworkStream clientStream)
        {
            DateTime dt = DateTime.Now;
            formatter.Serialize(clientStream, dt);
        }
        public void XulyTheGiamGia(NetworkStream clientStream)
        {
            Entities.TheGiamGia temp = (Entities.TheGiamGia)formatter.Deserialize(clientStream);
            switch (temp.HanhDong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.TheGiamGia().Insert(temp);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.TheGiamGia[] thegiamgia = new BizLogic.TheGiamGia().Select();
                        formatter.Serialize(clientStream, thegiamgia);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.TheGiamGia().Update(temp);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Delete":
                    {
                        int i = new BizLogic.TheGiamGia().Delete(temp);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
            }
        }
        public void Xuly_Select(NetworkStream clientStream)
        {
            Entities.CheckRefer nv = (Entities.CheckRefer)formatter.Deserialize(clientStream);
            switch (nv.TenTruong)
            {
                case "BCTraLaiNCC":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCTraLaiNCC(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCXuatHuyHangHoa":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCXuatHuyHangHoa(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCKhachHangTraHang":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCKhachHangTraHang(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCXuatNhapTonNhomHang":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCXuatNhapTonNhomHang(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "frmBCXuatHangTheoTungKho":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().frmBCXuatHangTheoTungKho(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "SoQuy":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().SoQuy();
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCDoanhThuMatHang":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCDoanhThuMatHang(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCDoanhThuNhomHang":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCDoanhThuNhomHang(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "TimKiemChungTu":
                    {

                        Entities.SelectAll temp = new BizLogic.SelectAll().TimKiemChungTu();
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCCongNoNhaCungCap":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCCongNoNhaCungCap();
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BanBuon":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BanBuon();
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCCongNoKhachHang":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCCongNoKhachHang();
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "BCThue":
                    {
                        Entities.SelectAll temp = new BizLogic.SelectAll().BCThue(nv.MaTruong);
                        formatter.Serialize(clientStream, temp);
                        break;
                    }
                case "PXH":
                    {
                        Entities.PhieuXuatHuy[] nv1 = new BizLogic.CheckRefer().PhieuXuatHuy();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTPXH":
                    {
                        Entities.ChiTietXuatHuy[] nv1 = new BizLogic.CheckRefer().ChiTietXuatHuy();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "DDH":
                    {
                        Entities.DonDatHang[] nv1 = new BizLogic.CheckRefer().DonDatHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "PT":
                    {
                        Entities.PhieuThu[] nv1 = new BizLogic.CheckRefer().PhieuThu();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "PTTCKH":
                    {
                        Entities.PhieuTTCuaKH[] nv1 = new BizLogic.CheckRefer().PhieuTTCuaKH();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTPTTCKH":
                    {
                        Entities.ChiTietPhieuTTCuaKH[] nv1 = new BizLogic.CheckRefer().ChiTietPhieuTTCuaKH();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "PTTNCC":
                    {
                        Entities.PhieuTTNCC[] nv1 = new BizLogic.CheckRefer().PhieuTTNCC();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTPTTNCC":
                    {
                        Entities.ChiTietPhieuTTNCC[] nv1 = new BizLogic.CheckRefer().ChiTietPhieuTTNCC();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTDDH":
                    {
                        Entities.ChiTietDonDatHang[] nv1 = new BizLogic.CheckRefer().ChiTietDonDatHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "HDBH":
                    {
                        Entities.HDBanHang[] nv1 = new BizLogic.CheckRefer().HDBanHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTHDBH":
                    {
                        Entities.ChiTietHDBanHang[] nv1 = new BizLogic.CheckRefer().ChiTietHDBanHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "PDCKNB":
                    {
                        Entities.PhieuDieuChuyenKhoNoiBo[] nv1 = new BizLogic.CheckRefer().PhieuDieuChuyenKhoNoiBo();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTPDCKNB":
                    {
                        Entities.ChiTietPhieuDieuChuyenKho[] nv1 = new BizLogic.CheckRefer().ChiTietPhieuDieuChuyenKho();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "TLNCC":
                    {
                        Entities.TraLaiNCC[] nv1 = new BizLogic.CheckRefer().TraLaiNCC();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTTLNCC":
                    {
                        Entities.ChiTietTraLaiNhaCungCap[] nv1 = new BizLogic.CheckRefer().ChiTietTraLaiNCC();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "HDN":
                    {
                        Entities.HoaDonNhap[] nv1 = new BizLogic.CheckRefer().HoaDonNhap();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTHDN":
                    {
                        Entities.ChiTietHoaDonNhap[] nv1 = new BizLogic.CheckRefer().ChiTietHoaDonNhap();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "KHTL":
                    {
                        Entities.KhachHangTraLai[] nv1 = new BizLogic.CheckRefer().KhachHangTraLai();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTKHTL":
                    {
                        Entities.ChiTietKhachHangTraLai[] nv1 = new BizLogic.CheckRefer().ChiTietKhachHangTraLai();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "LH":
                    {
                        Entities.LoaiHangHoa[] nv1 = new BizLogic.CheckRefer().LoaiHangHoa();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "HH":
                    {
                        Entities.HangHoa[] nv1 = new BizLogic.CheckRefer().HangHoa();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "NH":
                    {
                        Entities.NhomHang[] nv1 = new BizLogic.CheckRefer().NhomHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "KH":
                    {
                        Entities.KhoHang[] nv1 = new BizLogic.CheckRefer().KhoHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTKH":
                    {
                        Entities.ChiTietKhoHangTheoHoaHonNhap[] nv1 = new BizLogic.CheckRefer().ChiTietKhoHang();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "GH":
                    {
                        Entities.GoiHang[] nv1 = new BizLogic.GoiHang().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "CTGH":
                    {
                        Entities.ChiTietGoiHang[] nv1 = new BizLogic.ChiTietGoiHang().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "QD":
                    {
                        Entities.QuyDoiDonViTinh[] nv1 = new BizLogic.QuyDoiDonViTinh().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Hưởng
        public void LayTheVip(NetworkStream clientStream)
        {
            // kiểm tra hành động được gửi đến
            Entities.TheVip[] tk = new BizLogic.TheVip().Select();
            formatter.Serialize(clientStream, tk);
        }
        public void LayTheVipTheoMaKhachHang(NetworkStream clientStream)
        {
            Entities.TheVip tk1 = (Entities.TheVip)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            Entities.TheVip[] tk = new BizLogic.TheVip().Select(tk1);
            formatter.Serialize(clientStream, tk);
        }
        public void ThemTheVip(NetworkStream clientStream)
        {
            Entities.TheVip obj = (Entities.TheVip)formatter.Deserialize(clientStream);
            bool ctq = false;
            // kiểm tra hành động được gửi đến
            ctq = new BizLogic.TheVip().Insert(obj);
            if (ctq)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(obj.MaNhanVien, obj.TenDangNhap, "Insert", DateTime.Now.ToString(), " Thêm Thẻ Vip : " + obj.MaThe));
            }

            formatter.Serialize(clientStream, ctq);
        }
        public void SuaTheVip(NetworkStream clientStream)
        {
            Entities.TheVip obj = (Entities.TheVip)formatter.Deserialize(clientStream);
            bool ctq = false;
            // kiểm tra hành động được gửi đến
            ctq = new BizLogic.TheVip().Update(obj);
            if (ctq)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(obj.MaNhanVien, obj.TenDangNhap, "Update", DateTime.Now.ToString(), " Sửa Thẻ Vip : " + obj.MaThe));
            }

            formatter.Serialize(clientStream, ctq);
        }
        public void XoaTheVip(NetworkStream clientStream)
        {
            Entities.TheVip obj = (Entities.TheVip)formatter.Deserialize(clientStream);
            bool ctq = false;
            // kiểm tra hành động được gửi đến
            ctq = new BizLogic.TheVip().Delete(obj);
            if (ctq)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(obj.MaNhanVien, obj.TenDangNhap, "Delete", DateTime.Now.ToString(), " Xóa Thẻ Vip : " + obj.MaThe));
            }

            formatter.Serialize(clientStream, ctq);
        }
        public void Restore(NetworkStream clientStream)
        {
            Entities.SaoLuuHeThong tk1 = (Entities.SaoLuuHeThong)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool tk = new BizLogic.SaoLuuHeThong().Restore(tk1);

            if (tk)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk1.MaNhanVien, tk1.TenDangNhap, "Restore", DateTime.Now.ToString(), "Khôi Phục dữ liệu về ngày " + tk1.ThoiGian));
            }
            formatter.Serialize(clientStream, tk);

        }
        public void LayBackUp(NetworkStream clientStream)
        {
            //Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            Entities.SaoLuuHeThong[] tk = new BizLogic.SaoLuuHeThong().LayBackUp();
            //if (tk != null)
            //{
            //    new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk[0].NhanVienID, tk[0].TenDangNhap, "Log In ", DateTime.Now.ToString(), tk[0].NhanVienID + " Đăng Nhập Với tài khoản: " + tk[0].TenDangNhap));
            //}
            formatter.Serialize(clientStream, tk);

        }
        public void XoaFile(NetworkStream clientStream)
        {
            Entities.LogFile lf = (Entities.LogFile)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool tk = new BizLogic.LogFile().XoaFileLog(lf);
            formatter.Serialize(clientStream, tk);
        }
        public void DocFile(NetworkStream clientStream)
        {
            Entities.LogFile[] lf = new BizLogic.LogFile().DocFile();
            formatter.Serialize(clientStream, lf);
        }

        public void LogIn(NetworkStream clientStream)
        {
            Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            Entities.TaiKhoan[] tk = new BizLogic.TaiKhoan().LogIn(tk1);
            if (tk != null)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk[0].NhanVienID, tk[0].TenDangNhap, "Log In ", DateTime.Now.ToString(), tk[0].NhanVienID + " Đăng Nhập Với tài khoản: " + tk[0].TenDangNhap));
            }
            formatter.Serialize(clientStream, tk);

        }
        //public void LogOut(NetworkStream clientStream)
        //{
        //    Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
        //    // kiểm tra hành động được gửi đến
        //    new BizLogic.TaiKhoan().LogOut(tk1);
        //    formatter.Serialize(clientStream, null);

        //}
        public void selectTaiKhoan(NetworkStream clientStream)
        {
            //Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            Entities.TaiKhoan[] tk = new BizLogic.TaiKhoan().selectTaiKhoan();
            formatter.Serialize(clientStream, tk);
        }
        public void selectQuyen(NetworkStream clientStream)
        {
            //Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            Entities.NhomQuyen[] tk = new BizLogic.NhomQuyen().selectNhomQuyen();
            formatter.Serialize(clientStream, tk);
        }
        public void selectChiTietQuyen(NetworkStream clientStream)
        {
            Entities.ChiTietQuyen ctq1 = (Entities.ChiTietQuyen)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            Entities.ChiTietQuyen[] ctq = new BizLogic.ChiTietQuyen().selectChiTietQuyen(ctq1);
            formatter.Serialize(clientStream, ctq);
        }
        public void updateChiTietQuyen(NetworkStream clientStream)
        {
            object[] obj = (object[])formatter.Deserialize(clientStream);
            bool ctq = false;
            if (obj != null)
            {
                Entities.ChiTietQuyen[] ctq1 = (Entities.ChiTietQuyen[])obj[0];
                Entities.TaiKhoan tk = (Entities.TaiKhoan)obj[1];
                // kiểm tra hành động được gửi đến
                ctq = new BizLogic.ChiTietQuyen().update(ctq1);
                if (ctq)
                {
                    new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk.NhanVienID, tk.TenDangNhap, "Update", DateTime.Now.ToString(), tk.TenDN + " Sửa Nhóm Quyền: " + ctq1[0].TenNhomQuyen));
                }
            }
            formatter.Serialize(clientStream, ctq);
        }
        public void insertNhomQuyen(NetworkStream clientStream)
        {
            Entities.NhomQuyen nq1 = (Entities.NhomQuyen)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool nq = new BizLogic.NhomQuyen().insertNhomQuyen(nq1);
            if (nq)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(nq1.MaNhanVien, nq1.TenDangNhap, "Insert", DateTime.Now.ToString(), nq1.TenDangNhap + " Thêm Nhóm Quyền: " + nq1.TenNhomQuyen));
            }
            formatter.Serialize(clientStream, nq);
        }
        public void deleteNhomQuyen(NetworkStream clientStream)
        {
            Entities.NhomQuyen nq1 = (Entities.NhomQuyen)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool nq = new BizLogic.NhomQuyen().deleteNhomQuyen(nq1);
            if (nq)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(nq1.MaNhanVien, nq1.TenDangNhap, "delete", DateTime.Now.ToString(), nq1.TenDangNhap + " Xóa Nhóm Quyền: " + nq1.TenNhomQuyen));
            }
            formatter.Serialize(clientStream, nq);
        }
        public void insertTaiKhoan(NetworkStream clientStream)
        {
            Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool tk = new BizLogic.TaiKhoan().insertTaiKhoan(tk1);
            if (tk)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk1.MaNV, tk1.TenDN, "Insert ", DateTime.Now.ToString(), tk1.TenDN + " Thêm Tài Khoản: " + tk1.TenDangNhap));
            }
            formatter.Serialize(clientStream, tk);
        }
        public void updateTaiKhoan(NetworkStream clientStream)
        {
            Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool tk = new BizLogic.TaiKhoan().updateTaiKhoan(tk1);
            if (tk)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk1.MaNV, tk1.TenDN, "update ", DateTime.Now.ToString(), tk1.TenDN + " Sửa Tài Khoản: " + tk1.TenDangNhap));
            }
            formatter.Serialize(clientStream, tk);
        }
        public void deleteTaiKhoan(NetworkStream clientStream)
        {
            Entities.TaiKhoan tk1 = (Entities.TaiKhoan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            bool tk = new BizLogic.TaiKhoan().deleteTaiKhoan(tk1);
            if (tk)
            {
                new BizLogic.LogFile().GhiFile(new Entities.LogFile(tk1.MaNV, tk1.TenDN, "delete ", DateTime.Now.ToString(), tk1.TenDN + " Xóa Tài Khoản: " + tk1.TenDangNhap));
            }
            formatter.Serialize(clientStream, tk);
        }
        #endregion

        #region Server Của Sơn
        #region Xử lý nhân Viên(Sơn)
        public void Xuly_NhanVien(NetworkStream clientStream)
        {
            Entities.NhanVien nv = (Entities.NhanVien)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (nv.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.NhanVien().InsertUpdate(nv);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nv.NhanVienID1, nv.TenDangNhap, nv.HanhDong, DateTime.Now.ToString(), "Thêm Nhân Viên: " + nv.MaNhanVien));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.NhanVien().InsertUpdate(nv);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nv.NhanVienID1, nv.TenDangNhap, nv.HanhDong, DateTime.Now.ToString(), "Sửa Nhân Viên: " + nv.MaNhanVien));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.NhanVien().Delete(nv);
                        new BizLogic.LogFile().GhiFile(new Entities.LogFile(nv.NhanVienID1, nv.TenDangNhap, nv.HanhDong, DateTime.Now.ToString(), "Xóa Nhân Viên: " + nv.MaNhanVien));
                        break;
                    }
                case "Select":
                    {
                        Entities.NhanVien[] nv1 = new BizLogic.NhanVien().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "Search":
                    {
                        Entities.NhanVien[] kh1 = new BizLogic.NhanVien().Select(nv.Cot, nv.Kieu, nv.GiaTri);
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Phòng Ban(Sơn)
        public void Xuly_PhongBan(NetworkStream clientStream)
        {
            Entities.PhongBan pb = (Entities.PhongBan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (pb.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.PhongBan().InsertUpdate(pb);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pb.NhanVienID, pb.TenDangNhap, pb.HanhDong, DateTime.Now.ToString(), "Thêm Phòng Ban: " + pb.MaPhongBan));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.PhongBan().InsertUpdate(pb);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pb.NhanVienID, pb.TenDangNhap, pb.HanhDong, DateTime.Now.ToString(), "Sửa Phòng Ban: " + pb.MaPhongBan));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.PhongBan().Delete(pb);
                        new BizLogic.LogFile().GhiFile(new Entities.LogFile(pb.NhanVienID, pb.TenDangNhap, pb.HanhDong, DateTime.Now.ToString(), "Xóa Phòng Ban: " + pb.MaPhongBan));
                        break;
                    }
                case "Select":
                    {
                        Entities.PhongBan[] nv1 = new BizLogic.PhongBan().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Nhóm TK kế toán(Sơn)
        public void Xuly_NhomTKKeToan(NetworkStream clientStream)
        {
            Entities.NhomTKKeToan pb = (Entities.NhomTKKeToan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (pb.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.NhomTKKeToan().InsertUpdate(pb);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pb.NhanVienID, pb.TenDangNhap, pb.HanhDong, DateTime.Now.ToString(), "Thêm Nhóm TK Kế Toán: " + pb.MaNhomTKKeToan));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.NhomTKKeToan().InsertUpdate(pb);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pb.NhanVienID, pb.TenDangNhap, pb.HanhDong, DateTime.Now.ToString(), "Sửa Nhóm TK Kế Toán: " + pb.MaNhomTKKeToan));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.NhomTKKeToan().Delete(pb);

                        new BizLogic.LogFile().GhiFile(new Entities.LogFile(pb.NhanVienID, pb.TenDangNhap, pb.HanhDong, DateTime.Now.ToString(), "Xóa Nhóm TK Kế Toán: " + pb.MaNhomTKKeToan));

                        break;
                    }
                case "Select":
                    {
                        Entities.NhomTKKeToan[] nv1 = new BizLogic.NhomTKKeToan().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Tài Khoản Kế Toán(Sơn)
        public void Xuly_TKKeToan(NetworkStream clientStream)
        {
            Entities.TKKeToan tkkt = (Entities.TKKeToan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.TKKeToan().InsertUpdate(tkkt);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(tkkt.NhanVienID, tkkt.TenDangNhap, tkkt.HanhDong, DateTime.Now.ToString(), "Thêm TK Kế Toán: " + tkkt.MaTKKeToan));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.TKKeToan().InsertUpdate(tkkt);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(tkkt.NhanVienID, tkkt.TenDangNhap, tkkt.HanhDong, DateTime.Now.ToString(), "Sửa TK Kế Toán: " + tkkt.MaTKKeToan));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.TKKeToan().Delete(tkkt);
                        new BizLogic.LogFile().GhiFile(new Entities.LogFile(tkkt.NhanVienID, tkkt.TenDangNhap, tkkt.HanhDong, DateTime.Now.ToString(), "Xóa TK Kế Toán: " + tkkt.MaTKKeToan));
                        break;
                    }
                case "Select":
                    {
                        Entities.TKKeToan[] nv1 = new BizLogic.TKKeToan().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "LayNoTK":
                    {
                        Entities.TKKeToan[] nv1 = new BizLogic.TKKeToan().LayNoTK();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "LayCoTK":
                    {
                        Entities.TKKeToan[] nv1 = new BizLogic.TKKeToan().LayCoTK();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Tài Khoản Ngân Hàng(Sơn)
        public void Xuly_TKNganHang(NetworkStream clientStream)
        {
            Entities.TKNganHang tkkt = (Entities.TKNganHang)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.TKNganHang().InsertUpdate(tkkt);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.TKNganHang().InsertUpdate(tkkt);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.TKNganHang().Delete(tkkt);
                        break;
                    }
                case "Select":
                    {
                        Entities.TKNganHang[] nv1 = new BizLogic.TKNganHang().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Tiền Tệ(Sơn)
        public void Xuly_TienTe(NetworkStream clientStream)
        {
            Entities.TienTe tt = (Entities.TienTe)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tt.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.TienTe().InsertUpdate(tt);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(tt.NhanVienID, tt.TenDangNhap, tt.HanhDong, DateTime.Now.ToString(), "Thêm Tiền Tệ: " + tt.MaTienTe));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.TienTe().InsertUpdate(tt);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(tt.NhanVienID, tt.TenDangNhap, tt.HanhDong, DateTime.Now.ToString(), "Sửa Tiền Tệ: " + tt.MaTienTe));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.TienTe().Delete(tt);
                        new BizLogic.LogFile().GhiFile(new Entities.LogFile(tt.NhanVienID, tt.TenDangNhap, tt.HanhDong, DateTime.Now.ToString(), "Xóa Tiền Tệ: " + tt.MaTienTe));
                        break;
                    }
                case "Select":
                    {
                        Entities.TienTe[] tt1 = new BizLogic.TienTe().Select();
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Khoản mục thu chi(Sơn)
        public void Xuly_KMThuChi(NetworkStream clientStream)
        {
            Entities.KMThuChi tt = (Entities.KMThuChi)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tt.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.KMThuChi().InsertUpdate(tt);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(tt.NhanVienID, tt.TenDangNhap, tt.HanhDong, DateTime.Now.ToString(), "Thêm Khoản Mục Thu Chi: " + tt.MaKhoanMuc));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.KMThuChi().InsertUpdate(tt);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(tt.NhanVienID, tt.TenDangNhap, tt.HanhDong, DateTime.Now.ToString(), "Sửa Khoản Mục Thu Chi: " + tt.MaKhoanMuc));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.KMThuChi().Delete(tt);
                        new BizLogic.LogFile().GhiFile(new Entities.LogFile(tt.NhanVienID, tt.TenDangNhap, tt.HanhDong, DateTime.Now.ToString(), "Xóa Khoản Mục Thu Chi: " + tt.MaKhoanMuc));
                        break;
                    }
                case "Select":
                    {
                        Entities.KMThuChi[] tt1 = new BizLogic.KMThuChi().Select();
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.KMThuChi[] tt1 = new BizLogic.KMThuChi().LayKMThuChi(tt.LoaiKM);
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Phiếu điều chuyển kho
        public void Xuly_PhieuDieuChuyenKho(NetworkStream clientStream)
        {
            Entities.PhieuDieuChuyenKhoNoiBo pdck = (Entities.PhieuDieuChuyenKhoNoiBo)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (pdck.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.PhieuDieuChuyenKhoNoiBo().InsertUpdate(pdck);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.PhieuDieuChuyenKhoNoiBo().InsertUpdate(pdck);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.PhieuDieuChuyenKhoNoiBo().Delete(pdck);
                        break;
                    }
                case "Select":
                    {
                        Entities.PhieuDieuChuyenKhoNoiBo[] tt1 = new BizLogic.PhieuDieuChuyenKhoNoiBo().Select();
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                case "SelectTheoMaKho":
                    {
                        Entities.PhieuDieuChuyenKhoNoiBo[] tt1 = new BizLogic.PhieuDieuChuyenKhoNoiBo().SelectTheoMaKho(pdck.TuKho);
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Chi Tiết Phiếu điều chuyển kho
        public void Xuly_ChiTietPhieuDieuChuyenKho(NetworkStream clientStream)
        {
            Entities.ChiTietPhieuDieuChuyenKho CTpdck = (Entities.ChiTietPhieuDieuChuyenKho)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (CTpdck.HanhDong)
            {

                case "Insert":
                    {
                        int msg = new BizLogic.ChiTietPhieuDieuChuyenKho().InsertUpdate(CTpdck);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.ChiTietPhieuDieuChuyenKho().InsertUpdate(CTpdck);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        int msg = 0;
                        msg = new BizLogic.ChiTietPhieuDieuChuyenKho().Delete(CTpdck);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietPhieuDieuChuyenKho[] tt1 = new BizLogic.ChiTietPhieuDieuChuyenKho().Select();
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                case "SelectTheoMaPhieu":
                    {
                        Entities.ChiTietPhieuDieuChuyenKho[] tt1 = new BizLogic.ChiTietPhieuDieuChuyenKho().SelectTheoMaPhieu(CTpdck.MaPhieuDieuChuyenKho);
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Cập nhật giá(Sơn)
        public void Xuly_CapNhatGia(NetworkStream clientStream)
        {
            Entities.CapNhatGia nv = (Entities.CapNhatGia)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (nv.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.CapNhatGia().InsertUpdate(nv);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.CapNhatGia().InsertUpdate(nv);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.CapNhatGia().Delete(nv);
                        break;
                    }
                case "Select":
                    {
                        Entities.CapNhatGia[] nv1 = new BizLogic.CapNhatGia().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "Search":
                    {
                        Entities.CapNhatGia[] kh1 = new BizLogic.CapNhatGia().Select();
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Xử lý Số dư kho (Sơn)
        public void Xuly_SoDuKho(NetworkStream clientStream)
        {
            Entities.SoDuKho nv = (Entities.SoDuKho)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (nv.HanhDong)
            {
                case "Insert":
                    {
                        bool msg = new BizLogic.SoDuKho().Insert(nv);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        bool msg = new BizLogic.SoDuKho().Delete(nv);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Select":
                    {
                        Entities.SoDuKho[] nv1 = new BizLogic.SoDuKho().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "Search":
                    {
                        Entities.CapNhatGia[] kh1 = new BizLogic.CapNhatGia().Select();
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #endregion
        #region Server Của hòa
        #region Lấy ID
        /// <summary>
        /// Lấy ID
        /// </summary>
        /// <param name="obj"></param>
        public void XuLy_LayID(NetworkStream clientStream)
        {
            Entities.LayID lid = (Entities.LayID)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (lid.HanhDong)
            {
                case "Select":
                    {
                        Entities.LayID lid1 = (Entities.LayID)new BizLogic.Lay_ID().Select(lid);
                        formatter.Serialize(clientStream, lid1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Phiếu Thu
        /// <summary>
        /// Phiếu thu
        /// </summary>
        /// <param name="obj"></param>
        public void XuLy_PhieuThu(NetworkStream clientStream)
        {
            Entities.PhieuThu pt1 = (Entities.PhieuThu)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (pt1.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.PhieuThu().InsertUpdate(pt1);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pt1.MaNhanVien, pt1.TenDangNhap, pt1.HanhDong, DateTime.Now.ToString(), "Thêm phiếu thu: " + pt1.MaPhieuThu));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {

                        bool kt = new BizLogic.PhieuThu().InsertUpdate(pt1);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pt1.MaNhanVien, pt1.TenDangNhap, pt1.HanhDong, DateTime.Now.ToString(), "Sửa phiếu thu: " + pt1.MaPhieuThu));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.PhieuThu().Delete(pt1);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.PhieuThu[] pt = new BizLogic.PhieuThu().Select();
                        formatter.Serialize(clientStream, pt);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.PhieuThu[] pt = new BizLogic.PhieuThu().Select(pt1.PhieuThuID);
                        formatter.Serialize(clientStream, pt);
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion
        #region Thuế
        /// <summary>
        /// Phiếu thu
        /// </summary>
        /// <param name="obj"></param>
        public void XuLy_Thue(NetworkStream clientStream)
        {
            Entities.Thue pt1 = (Entities.Thue)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (pt1.HanhDong)
            {
                case "Select":
                    {
                        Entities.Thue[] pt = new BizLogic.Thue().Select();
                        formatter.Serialize(clientStream, pt);
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion
        #region Phiếu Thanh Toán Của Khách Hàng
        /// <summary>
        /// Phiếu Thanh Toán Của Khách Hàng
        /// </summary>
        /// <param name="clientStream"></param>
        /// <param name="objectName"></param>
        public void XuLy_PhieuTTCuaKH(NetworkStream clientStream)
        {
            Entities.PhieuTTCuaKH pttckh = (Entities.PhieuTTCuaKH)formatter.Deserialize(clientStream);
            switch (pttckh.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.PhieuTTCuaKH().InsertUpdate(pttckh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pttckh.MaNhanVien, pttckh.TenDangNhap, pttckh.HanhDong, DateTime.Now.ToString(), "Thêm phiếu thanh toán của khách hàng: " + pttckh.MaPhieuTTCuaKH));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {

                        bool kt = new BizLogic.PhieuTTCuaKH().InsertUpdate(pttckh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pttckh.MaNhanVien, pttckh.TenDangNhap, pttckh.HanhDong, DateTime.Now.ToString(), "Sửa phiếu thanh toán của khách hàng: " + pttckh.MaPhieuTTCuaKH));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.PhieuTTCuaKH().Delete(pttckh);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.PhieuTTCuaKH[] pttckh1 = new BizLogic.PhieuTTCuaKH().Select();
                        formatter.Serialize(clientStream, pttckh1);
                        break;
                    }
                default:
                    break;

            }
        }
        #endregion
        #region Phiếu Thanh Toán Nhà Cung Cấp
        /// <summary>
        /// Phiếu Thanh Toán Nhà Cung Cấp
        /// </summary>
        /// <param name="clientStream"></param>
        /// <param name="objectName"></param>
        public void XuLy_PhieuTTNCC(NetworkStream clientStream)
        {
            Entities.PhieuTTNCC pttncc = (Entities.PhieuTTNCC)formatter.Deserialize(clientStream);
            switch (pttncc.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.PhieuTTNCC().InsertUpdate(pttncc);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pttncc.MaNhanVien, pttncc.TenDangNhap, pttncc.HanhDong, DateTime.Now.ToString(), "Thêm phiếu thanh toán nhà cung cấp: " + pttncc.MaPhieuTTNCC));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        bool kt = new BizLogic.PhieuTTNCC().InsertUpdate(pttncc);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pttncc.MaNhanVien, pttncc.TenDangNhap, pttncc.HanhDong, DateTime.Now.ToString(), "Thêm phiếu thanh toán nhà cung cấp: " + pttncc.MaPhieuTTNCC));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.PhieuTTNCC().Delete(pttncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.PhieuTTNCC[] pttncc1 = new BizLogic.PhieuTTNCC().Select();
                        formatter.Serialize(clientStream, pttncc1);
                        break;
                    }

                default:
                    break;
            }
        }
        #endregion
        #region Phiếu Xuất Hủy
        /// <summary>
        /// Phiếu Xuất Hủy
        /// </summary>
        /// <param name="clientStream"></param>
        /// <param name="objectName"></param>
        public void XuLy_PhieuXuatHuy(NetworkStream clientStream)
        {
            Entities.PhieuXuatHuy pxh = (Entities.PhieuXuatHuy)formatter.Deserialize(clientStream);
            switch (pxh.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.PhieuXuatHuy().InsertUpdate(pxh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pxh.MaNhanVien, pxh.TenDangNhap, pxh.HanhDong, DateTime.Now.ToString(), "Thêm phiếu xuất hủy: " + pxh.MaPhieuXuatHuy));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {

                        bool kt = new BizLogic.PhieuXuatHuy().InsertUpdate(pxh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pxh.MaNhanVien, pxh.TenDangNhap, pxh.HanhDong, DateTime.Now.ToString(), "Sửa phiếu xuất hủy: " + pxh.MaPhieuXuatHuy));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.PhieuXuatHuy().Delete(pxh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pxh.MaNhanVien, pxh.TenDangNhap, pxh.HanhDong, DateTime.Now.ToString(), "Xóa phiếu xuất hủy: " + pxh.MaPhieuXuatHuy));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.PhieuXuatHuy[] pxh1 = new BizLogic.PhieuXuatHuy().Select();
                        formatter.Serialize(clientStream, pxh1);
                        break;
                    }
                case "SelectTheoMaKho":
                    {
                        Entities.PhieuXuatHuy[] pxh1 = new BizLogic.PhieuXuatHuy().SelectTheoMaKho(pxh.MaKho);
                        formatter.Serialize(clientStream, pxh1);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_PhieuXuatHuyMang(NetworkStream clientStream)
        {
            Entities.PhieuXuatHuy[] pxh = (Entities.PhieuXuatHuy[])formatter.Deserialize(clientStream);
            switch (pxh[0].HanhDong)
            {
                case "Update":
                    {
                        bool kt = new BizLogic.PhieuXuatHuy().UpdateTinhTrang(pxh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(pxh[0].MaNhanVien, pxh[0].TenDangNhap, pxh[0].HanhDong, DateTime.Now.ToString(), "Xác nhận phiếu xuất hủy: " + pxh[0].MaPhieuXuatHuy));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Chi Tiết Xuất Hủy
        /// <summary>
        /// Chi Tiết Xuất Hủy
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_ChiTietXuatHuy(NetworkStream clientStream)
        {
            Entities.ChiTietXuatHuy ctxh = (Entities.ChiTietXuatHuy)formatter.Deserialize(clientStream);
            switch (ctxh.HanhDong)
            {
                case "Select":
                    {
                        Entities.ChiTietXuatHuy[] ctxh1 = new BizLogic.ChiTietXuatHuy().Select(ctxh);
                        formatter.Serialize(clientStream, ctxh1);
                        break;
                    }
                case "SelectSon":
                    {
                        Entities.ChiTietXuatHuy[] ctxh1 = new BizLogic.ChiTietXuatHuy().Select();
                        formatter.Serialize(clientStream, ctxh1);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_ChiTietXuatHuyMang(NetworkStream clientStream)
        {
            Entities.ChiTietXuatHuy[] ctxh = (Entities.ChiTietXuatHuy[])formatter.Deserialize(clientStream);
            switch (ctxh[0].HanhDong)
            {
                case "InsertUpdate":
                    {

                        bool kt = new BizLogic.ChiTietXuatHuy().InsertUpdate(ctxh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.ChiTietXuatHuy().Delete(ctxh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion
        #region Chi Tiết Phiếu Thanh Toán Nhà Cung Cấp
        /// <summary>
        /// Chi Tiết Phiếu Thanh Toán Nhà Cung Cấp
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_ChiTietPhieuTTNCC(NetworkStream clientStream)
        {
            Entities.ChiTietPhieuTTNCC ctpttncc = (Entities.ChiTietPhieuTTNCC)formatter.Deserialize(clientStream);
            switch (ctpttncc.HanhDong)
            {
                case "Insert":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTNCC().InsertUpdate(ctpttncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTNCC().InsertUpdate(ctpttncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTNCC().Delete(ctpttncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietPhieuTTNCC[] ctpttncc1 = new BizLogic.ChiTietPhieuTTNCC().Select(ctpttncc);
                        formatter.Serialize(clientStream, ctpttncc1);
                        break;
                    }
                case "SelectAll":
                    {
                        Entities.ChiTietPhieuTTNCC[] ctpttncc1 = new BizLogic.ChiTietPhieuTTNCC().Select();
                        formatter.Serialize(clientStream, ctpttncc1);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_ChiTietPhieuTTNCCMang(NetworkStream clientStream)
        {
            Entities.ChiTietPhieuTTNCC[] ctpttncc = (Entities.ChiTietPhieuTTNCC[])formatter.Deserialize(clientStream);
            switch (ctpttncc[0].HanhDong)
            {
                case "Insert":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTNCC().InsertUpdate(ctpttncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Chi Tiết Phiếu Thanh Toán Của Khách Hàng
        /// <summary>
        /// Chi Tiết Phiếu Thanh Toán Của Khách Hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_ChiTietPhieuTTCuaKH(NetworkStream clientStream)
        {
            Entities.ChiTietPhieuTTCuaKH ctpttckh = (Entities.ChiTietPhieuTTCuaKH)formatter.Deserialize(clientStream);
            switch (ctpttckh.HanhDong)
            {
                case "Insert":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTCuaKH().InsertUpdate(ctpttckh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTCuaKH().InsertUpdate(ctpttckh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTCuaKH().Delete(ctpttckh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietPhieuTTCuaKH[] ctpttckh1 = new BizLogic.ChiTietPhieuTTCuaKH().Select(ctpttckh);
                        formatter.Serialize(clientStream, ctpttckh1);
                        break;
                    }
                case "SelectAll":
                    {
                        Entities.ChiTietPhieuTTCuaKH[] ctpttckh1 = new BizLogic.ChiTietPhieuTTCuaKH().Select();
                        formatter.Serialize(clientStream, ctpttckh1);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_ChiTietPhieuTTCuaKHMang(NetworkStream clientStream)
        {
            Entities.ChiTietPhieuTTCuaKH[] ctpttckh = (Entities.ChiTietPhieuTTCuaKH[])formatter.Deserialize(clientStream);
            switch (ctpttckh[0].HanhDong)
            {
                case "Insert":
                    {
                        bool kt = new BizLogic.ChiTietPhieuTTCuaKH().InsertUpdate(ctpttckh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Chi Tiết Hóa Đơn Bán Hàng
        /// <summary>
        /// Kho hàng
        /// </summary>
        /// <param name="clientStream"></param>
        /// 
        public void XuLy_ChiTietHDBanHang(NetworkStream clientStream)
        {
            Entities.ChiTietHDBanHang cthdbh = (Entities.ChiTietHDBanHang)formatter.Deserialize(clientStream);
            switch (cthdbh.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.ChiTietHDBanHang().InsertUpdate(cthdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {

                        bool kt = new BizLogic.ChiTietHDBanHang().InsertUpdate(cthdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.ChiTietHDBanHang().Delete(cthdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietHDBanHang[] kho = new BizLogic.ChiTietHDBanHang().Select(cthdbh);
                        formatter.Serialize(clientStream, kho);
                        break;
                    }
                case "SelectSon":
                    {
                        Entities.ChiTietHDBanHang[] kho = new BizLogic.ChiTietHDBanHang().Select();
                        formatter.Serialize(clientStream, kho);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_ChiTietHDBanHangMang(NetworkStream clientStream)
        {
            Entities.ChiTietHDBanHang[] cthdbh = (Entities.ChiTietHDBanHang[])formatter.Deserialize(clientStream);
            switch (cthdbh[0].HanhDong)
            {
                case "InsertUpdate":
                    {

                        bool kt = new BizLogic.ChiTietHDBanHang().InsertUpdate(cthdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.ChiTietHDBanHang().Delete(cthdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Hóa Đơn Nhập Mảng
        /// <summary>
        /// Kho hàng
        /// </summary>
        /// <param name="clientStream"></param>
        /// 


        public void XuLy_HoaDonNhapMang(NetworkStream clientStream)
        {
            Entities.HoaDonNhap[] cthdbh = (Entities.HoaDonNhap[])formatter.Deserialize(clientStream);
            switch (cthdbh[0].Hanhdong)
            {
                case "Update":
                    {

                        bool kt = new BizLogic.HoaDonNhap().UpdateThanhToanNgay(cthdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }

                default:
                    break;
            }
        }

        public void XuLy_HDN(NetworkStream clientStream)
        {
            Entities.HoaDonNhap cthdbh = (Entities.HoaDonNhap)formatter.Deserialize(clientStream);
            switch (cthdbh.Hanhdong)
            {
                case "Select":
                    {

                        Entities.HoaDonNhap[] hdn = new BizLogic.HoaDonNhap().Select();
                        formatter.Serialize(clientStream, hdn);
                        break;
                    }
                case "ThanhToanNgaySauLapPhieu":
                    {
                        bool msg = new BizLogic.PhieuTTNCC().InsertUpdateSauKhiLapPhieu(cthdbh);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion



        #region Hóa Đơn Bán Hàng
        /// <summary>
        /// Kho hàng
        /// </summary>
        /// <param name="clientStream"></param>
        /// 
        public void XuLy_HDBanHang(NetworkStream clientStream)
        {
            Entities.HDBanHang hdbh = (Entities.HDBanHang)formatter.Deserialize(clientStream);
            switch (hdbh.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.HDBanHang().InsertUpdate(hdbh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hdbh.MaNhanVien, hdbh.TenDangNhap, hdbh.HanhDong, DateTime.Now.ToString(), "Thêm hóa đơn bán hàng: " + hdbh.MaHDBanHang));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {

                        bool kt = new BizLogic.HDBanHang().InsertUpdate(hdbh);
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hdbh.MaNhanVien, hdbh.TenDangNhap, hdbh.HanhDong, DateTime.Now.ToString(), "Sửa hóa đơn bán hàng: " + hdbh.MaHDBanHang));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.HDBanHang().Delete(hdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.HDBanHang[] hdbh1 = new BizLogic.HDBanHang().Select();
                        formatter.Serialize(clientStream, hdbh1);
                        break;
                    }
                case "SelectTheoMaKho":
                    {
                        Entities.HDBanHang[] hdbh1 = new BizLogic.HDBanHang().Select_TheoMaKho(hdbh.MaKho);
                        formatter.Serialize(clientStream, hdbh1);
                        break;
                    }
                case "Search":
                    {
                        Entities.HDBanHang[] hdbh1 = new BizLogic.HDBanHang().Select(hdbh.Cot, hdbh.Kieu, hdbh.GiaTri, hdbh.MaKH);
                        formatter.Serialize(clientStream, hdbh1);
                        break;
                    }
                case "SelectTheoHoaDon":
                    {
                        Entities.HDBanHang[] hdbh1 = new BizLogic.HDBanHang().Select(hdbh.Cot, hdbh.Kieu, hdbh.GiaTri, hdbh.MaKH);
                        formatter.Serialize(clientStream, hdbh1);
                        break;
                    }
                case "DeleteTheoMa":
                    {
                        bool kt = new BizLogic.HDBanHang().Delete(hdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        public void XuLy_HDBanHangMang(NetworkStream clientStream)
        {
            Entities.HDBanHang[] hdbh = (Entities.HDBanHang[])formatter.Deserialize(clientStream);
            switch (hdbh[0].HanhDong)
            {
                case "Update":
                    {
                        bool kt = new BizLogic.HDBanHang().UpdateThanhToanNgay(hdbh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Quầy Thu Ngân
        public void XuLy_QuayThuNgan(NetworkStream clientStream)
        {
            Entities.QuayThuNgan tkkt = (Entities.QuayThuNgan)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt.HanhDong)
            {
                case "Insert":
                    {
                        break;
                    }
                case "Update":
                    {

                        break;
                    }
                case "Delete":
                    {
                        break;
                    }
                case "Select":
                    {
                        Entities.QuayThuNgan[] nv1 = new BizLogic.QuayThuNgan().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Sổ Quỹ
        public void XuLy_SoQuy(NetworkStream clientStream)
        {
            Entities.SoDuSoQuy tkkt = (Entities.SoDuSoQuy)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt.HanhDong)
            {
                case "Insert":
                    {
                        bool sq = new BizLogic.SoQuy().Insert(tkkt);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "Update":
                    {
                        bool sq = new BizLogic.SoQuy().Update(tkkt);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "UpdateTrangThai":
                    {
                        bool sq = new BizLogic.SoQuy().UpdateTrangThai(tkkt);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "Delete":
                    {
                        bool sq = new BizLogic.SoQuy().Delete(tkkt);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "Select":
                    {
                        Entities.SoDuSoQuy[] sq = new BizLogic.SoQuy().Select();
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Công Nợ
        public void XuLy_CongNo(NetworkStream clientStream)
        {
            Entities.SoDuCongNo[] tkkt = (Entities.SoDuCongNo[])formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt[0].HanhDong)
            {
                case "Insert":
                    {
                        bool sq = new BizLogic.CongNo().Insert(tkkt[0]);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "Update":
                    {

                        break;
                    }
                case "UpdateTrangThai":
                    {
                        bool sq = new BizLogic.CongNo().Update(tkkt);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "Delete":
                    {
                        bool sq = new BizLogic.CongNo().Delete(tkkt[0]);
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                case "Select":
                    {
                        Entities.SoDuCongNo[] sq = new BizLogic.CongNo().Select();
                        formatter.Serialize(clientStream, sq);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Báo Cáo Doanh Thu Theo Hàng Hóa
        public void XuLy_BCDTTheoHangHoa(NetworkStream clientStream)
        {
            Entities.BCDTTheoHangHoa tkkt = (Entities.BCDTTheoHangHoa)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCDTTheoHangHoa[] nv1 = new BizLogic.BCDTTheoHangHoa().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.BCDTTheoHangHoa[] nv1 = new BizLogic.BCDTTheoHangHoa().Select(tkkt);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Báo Cáo Doanh Thu Theo Nhân Viên
        public void XuLy_BCDTTheoNhanVien(NetworkStream clientStream)
        {
            Entities.BCDTTheoNhanVien tkkt = (Entities.BCDTTheoNhanVien)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (tkkt.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCDTTheoNhanVien[] nv1 = new BizLogic.BCDTTheoNhanVien().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.BCDTTheoNhanVien[] nv1 = new BizLogic.BCDTTheoNhanVien().Select(tkkt);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Báo Cáo Doanh Thu Theo Nhóm Hàng
        public void XuLy_BCDTTheoNhomHang(NetworkStream clientStream)
        {
            Entities.BCDTTheoNhomHang bcdttnh = (Entities.BCDTTheoNhomHang)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (bcdttnh.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCDTTheoNhomHang[] nv1 = new BizLogic.BCDTTheoNhomHang().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.BCDTTheoNhomHang[] nv1 = new BizLogic.BCDTTheoNhomHang().Select(bcdttnh);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Báo Cáo Doanh Thu Theo Thời Gian
        public void XuLy_BCDTTheoThoiGian(NetworkStream clientStream)
        {
            Entities.BCDTTheoThoiGian bcdtttg = (Entities.BCDTTheoThoiGian)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (bcdtttg.HanhDong)
            {
                case "SelectTheoThang":
                    {
                        Entities.BCDTTheoThoiGian[] nv1 = new BizLogic.BCDTTheoThoiGian().Select(bcdtttg.Thang, bcdtttg.Nam);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoNgay":
                    {
                        Entities.BCDTTheoThoiGian[] nv1 = new BizLogic.BCDTTheoThoiGian().Select(bcdtttg.Ngay);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoKhoang":
                    {
                        Entities.BCDTTheoThoiGian[] nv1 = new BizLogic.BCDTTheoThoiGian().Select(bcdtttg.NgayBatDau, bcdtttg.NgayKetThuc);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Báo Cáo Hóa Đơn Bán Hàng
        public void XuLy_BCHDBanHang(NetworkStream clientStream)
        {
            Entities.BCHDBanLe bchdbl = (Entities.BCHDBanLe)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (bchdbl.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCHDBanLe[] nv1 = new BizLogic.BCHDBanHang().Select(bchdbl);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_BCHDBanBuon(NetworkStream clientStream)
        {
            Entities.BCHDBanBuon bchdbl = (Entities.BCHDBanBuon)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (bchdbl.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCHDBanBuon[] nv1 = new BizLogic.BCHDBanHang().Select(bchdbl);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Báo Cáo Tồn Kho Theo Kho
        public void XuLy_TonKhoTheoKho(NetworkStream clientStream)
        {
            Entities.BCTonKhoTheoKho bchdbl = (Entities.BCTonKhoTheoKho)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (bchdbl.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCTonKhoTheoKho[] nv1 = new BizLogic.BCTonKhoTheoKho().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.BCTonKhoTheoKho[] nv1 = new BizLogic.BCTonKhoTheoKho().Select(bchdbl);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion

        #region Báo Cáo Tồn Kho Theo Nhóm Hàng
        public void XuLy_TonKhoTheoNhom(NetworkStream clientStream)
        {
            Entities.BCTonKhoTheoNhomHang bchdbl = (Entities.BCTonKhoTheoNhomHang)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (bchdbl.HanhDong)
            {
                case "Select":
                    {
                        Entities.BCTonKhoTheoNhomHang[] nv1 = new BizLogic.BCTonKhoTheoNhomHang().Select();
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                case "SelectTheoMa":
                    {
                        Entities.BCTonKhoTheoNhomHang[] nv1 = new BizLogic.BCTonKhoTheoNhomHang().Select(bchdbl);
                        formatter.Serialize(clientStream, nv1);
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion

        /// <summary>
        /// =========================================khach hang tra lai============================================================
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_TLNCC(NetworkStream clientStream)
        {
            Entities.TraLaiNCC khtl = (Entities.TraLaiNCC)formatter.Deserialize(clientStream);
            switch (khtl.Hanhdong)
            {
                case "Select":
                    {
                        Entities.TraLaiNCC[] select = (Entities.TraLaiNCC[])new BizLogic.CongNo().SelectTLNCC();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                case "SelectTheoMaKho":
                    {
                        Entities.TraLaiNCC[] select = (Entities.TraLaiNCC[])new BizLogic.CongNo().SelectTLNCCTheoMaKho(khtl.MaKho);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// ===============================================tra lai nha cung cap========================================================
        /// </summary>
        private void XuLy_KHTL(NetworkStream clientStream)
        {
            Entities.KhachHangTraLai kkcc = (Entities.KhachHangTraLai)formatter.Deserialize(clientStream);
            switch (kkcc.Hanhdong)
            {
                case "Select":
                    {
                        Entities.KhachHangTraLai[] select = (Entities.KhachHangTraLai[])new BizLogic.CongNo().SelectKHTL();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Server Hương
        #region Gói Hàng
        public void XuLy_GoiHang(NetworkStream clientStream)
        {
            Entities.GoiHang nkh = (Entities.GoiHang)formatter.Deserialize(clientStream);
            switch (nkh.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.GoiHang().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "Thêm gói hàng: " + nkh.MaGoiHang));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.GoiHang().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "Sửa gói hàng: " + nkh.MaGoiHang));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.GoiHang().Delete(nkh);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.GoiHang[] nkh1 = new BizLogic.GoiHang().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Khuyen mai theo sl

        public void XuLy_KhuyenMaiSoLuong(NetworkStream clientStream)
        {
            Entities.KhuyenMaiSoLuong item = (Entities.KhuyenMaiSoLuong)formatter.Deserialize(clientStream);
            switch (item.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.KhuyenMaiSoLuong().Insert(item);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.KhuyenMaiSoLuong().Update(item);

                        if (msg == 0)
                            new BizLogic.KhuyenMaiSoLuong().Insert(item);

                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        int msg = new BizLogic.KhuyenMaiSoLuong().Delete(item);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "SelectAll":
                    {
                        Entities.KhuyenMaiSoLuong[] nkh1 = new BizLogic.KhuyenMaiSoLuong().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                case "Select":
                    {
                        Entities.KhuyenMaiSoLuong[] nkh1 = new BizLogic.KhuyenMaiSoLuong().Select(item);
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Chi Tiết Gói Hàng
        public void XuLy_ChiTietGoiHang(NetworkStream clientStream)
        {
            Entities.ChiTietGoiHang[] nkh = (Entities.ChiTietGoiHang[])formatter.Deserialize(clientStream);
            switch (nkh[0].HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.ChiTietGoiHang().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile("", "", nkh[0].HanhDong, DateTime.Now.ToString(), "Thêm chi tiết gói hàng: " + nkh[0].MaGoiHang));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.ChiTietGoiHang().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile("", "", nkh[0].HanhDong, DateTime.Now.ToString(), "Sửa chi tiết gói hàng: " + nkh[0].MaGoiHang));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        int msg = new BizLogic.ChiTietGoiHang().Delete(nkh[0]);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietGoiHang[] nkh1 = new BizLogic.ChiTietGoiHang().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region Quy Đổi Đơn Vị Tính
        public void XuLy_QuyDoiDonViTinh(NetworkStream clientStream)
        {
            Entities.QuyDoiDonViTinh nkh = (Entities.QuyDoiDonViTinh)formatter.Deserialize(clientStream);
            switch (nkh.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.QuyDoiDonViTinh().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "Thêm quy đổi đơn vị tính: " + nkh.MaQuyDoiDonViTinh));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.QuyDoiDonViTinh().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "Sửa quy đổi đơn vị tính: " + nkh.MaQuyDoiDonViTinh));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.QuyDoiDonViTinh().Delete(nkh);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.QuyDoiDonViTinh[] nkh1 = new BizLogic.QuyDoiDonViTinh().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region BCChiTietHangHoa
        /// <summary>
        /// đơn hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_BCChiTietHangHoa(NetworkStream clientStream)
        {
            try
            {
                Entities.rptBCChiTietHangHoa lsgd = (Entities.rptBCChiTietHangHoa)formatter.Deserialize(clientStream);
                switch (lsgd.HanhDong)
                {

                    case "Select":
                        {

                            List<Entities.rptBCChiTietHangHoa> ctHangHoaList = new List<Entities.rptBCChiTietHangHoa>();
                            Entities.rptBCChiTietHangHoa temp = null;
                            Entities.GoiHang[] goihang = new BizLogic.GoiHang().Select();
                            // nhet goi hang vao List
                            foreach (Entities.GoiHang item in goihang)
                            {
                                temp = new Entities.rptBCChiTietHangHoa();
                                temp.MaHangHoa = item.MaGoiHang;
                                temp.TenHangHoa = item.TenGoiHang;
                                temp.TenNhomHang = item.TenNhomHang;
                                temp.GiaNhap = double.Parse(item.GiaNhap);
                                temp.GiaBanBuon = double.Parse(item.GiaBanBuon);
                                temp.GiaBanLe = double.Parse(item.GiaBanLe);
                                ctHangHoaList.Add(temp);
                            }

                            Entities.rptBCChiTietHangHoa[] lsgd1 = new BizLogic.BCChiTietHangHoa().Select();
                            foreach (Entities.rptBCChiTietHangHoa item in lsgd1)
                            {
                                ctHangHoaList.Add(item);
                            }
                            formatter.Serialize(clientStream, ctHangHoaList.ToArray());
                            break;

                        }
                    default:
                        break;
                }
            }
            catch (Exception)
            { }
        }
        # endregion
        #region Thue

        public void XuLy_ThueH(NetworkStream clientStream)
        {
            Entities.Thue lhh = (Entities.Thue)formatter.Deserialize(clientStream);
            switch (lhh.HanhDong)
            {
                case "Insert":
                    {
                        int kt = new BizLogic.ThueH().InsertUpdate(lhh);
                        if (kt == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(lhh.MaNhanVien, lhh.TenDangNhap, lhh.HanhDong, DateTime.Now.ToString(), "Thêm thuế: " + lhh.MaThue));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        int kt = new BizLogic.ThueH().InsertUpdate(lhh);
                        if (kt == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(lhh.MaNhanVien, lhh.TenDangNhap, lhh.HanhDong, DateTime.Now.ToString(), "Sửa thuế: " + lhh.MaThue));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.ThueH().Delete(lhh);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.Thue[] lhhang = new BizLogic.ThueH().sp_SelectThuesAll();
                        formatter.Serialize(clientStream, lhhang);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Cong Ty
        /// <summary>
        /// Công Ty
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_CongTy(NetworkStream clientStream)
        {
            Entities.ThongTinCongTy nkh = (Entities.ThongTinCongTy)formatter.Deserialize(clientStream);
            switch (nkh.HanhDong)
            {
                case "Insert":
                    {
                        Entities.ThongTinCongTy msg = new BizLogic.CongTy().InsertUpdate(nkh);
                        if (msg.MaCongTy == "YES")
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "thêm công ty: " + nkh.MaCongTy));
                        }
                        formatter.Serialize(clientStream, msg);
                        //break;
                        //new BizLogic.CongTy().InsertUpdate(nkh);

                        break;
                    }
                case "Update":
                    {
                        Entities.ThongTinCongTy msg = new BizLogic.CongTy().InsertUpdate(nkh);
                        if (msg.MaCongTy == "YES")
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "sửa công ty: " + nkh.MaCongTy));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Select":
                    {
                        Entities.ThongTinCongTy[] nkh1 = new BizLogic.CongTy().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Khách Hàng
        /// <summary>
        /// Khách Hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_KhachHang(NetworkStream clientStream)
        {
            Entities.KhachHang kh = (Entities.KhachHang)formatter.Deserialize(clientStream);
            switch (kh.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.KhachHang().InsertUpdate(kh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kh.MaNhanVien, kh.TenDangNhap, kh.HanhDong, DateTime.Now.ToString(), "Thêm khách hàng: " + kh.MaKH));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.KhachHang().InsertUpdate(kh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kh.MaNhanVien, kh.TenDangNhap, kh.HanhDong, DateTime.Now.ToString(), "Sửa khách hàng: " + kh.MaKH));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "UpdateDuNo":
                    {
                        bool msg = new BizLogic.KhachHang().Update(kh);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "UpdateDuNoKH":
                    {
                        bool msg = new BizLogic.KhachHang().UpdateKH(kh);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }

                case "Delete":
                    {
                        new BizLogic.KhachHang().Delete(kh);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.KhachHang[] kh1 = new BizLogic.KhachHang().Select();
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                case "Search":
                    {
                        Entities.KhachHang[] kh1 = new BizLogic.KhachHang().Select(kh.Cot, kh.Kieu, kh.GiaTri);
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region NhaCungCap
        /// <summary>
        /// Nhà Cung Cấp
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_NhaCungCap(NetworkStream clientStream)
        {
            Entities.NhaCungCap ncc = (Entities.NhaCungCap)formatter.Deserialize(clientStream);
            switch (ncc.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.NhaCungCap().InsertUpdate(ncc);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ncc.MaNhanVien, ncc.TenDangNhap, ncc.HanhDong, DateTime.Now.ToString(), "Thêm nhà cung cấp: " + ncc.MaNhaCungCap));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.NhaCungCap().InsertUpdate(ncc);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ncc.MaNhanVien, ncc.TenDangNhap, ncc.HanhDong, DateTime.Now.ToString(), "Sửa nhà cung cấp: " + ncc.MaNhaCungCap));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.NhaCungCap().Delete(ncc);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.NhaCungCap[] ncc1 = new BizLogic.NhaCungCap().Select();
                        formatter.Serialize(clientStream, ncc1);
                        break;
                    }
                case "Search":
                    {
                        Entities.NhaCungCap[] ncc1 = new BizLogic.NhaCungCap().Select(ncc.Cot, ncc.Kieu, ncc.GiaTri);
                        formatter.Serialize(clientStream, ncc1);
                        break;
                    }
                case "UpdateDuNo": // trừ
                    {
                        bool kt = new BizLogic.NhaCungCap().UpdateDuNo(ncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "UpdateDuNoNCC": // cộng
                    {
                        bool kt = new BizLogic.NhaCungCap().UpdateDuNoNCC(ncc);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion


        #region CapNhatGiaKH
        /// <summary>
        /// cập nhật giá khách hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_CapNhatGiaKH(NetworkStream clientStream)
        {
            Entities.CapNhatGiaKhachHang nkh = (Entities.CapNhatGiaKhachHang)formatter.Deserialize(clientStream);
            switch (nkh.HanhDong)
            {
                case "Insert":
                    {
                        int msg = new BizLogic.CapNhatGiaKH().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "Thêm cập nhật giá khách hàng: " + nkh.MaCapNhatGiaKhachHang));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Update":
                    {
                        int msg = new BizLogic.CapNhatGiaKH().InsertUpdate(nkh);
                        if (msg == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(nkh.MaNhanVien, nkh.TenDangNhap, nkh.HanhDong, DateTime.Now.ToString(), "Sửa cập nhật giá khách hàng: " + nkh.MaCapNhatGiaKhachHang));
                        }
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Delete":
                    {
                        int msg = new BizLogic.CapNhatGiaKH().Delete(nkh);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }
                case "Select":
                    {
                        Entities.CapNhatGiaKhachHang[] nkh1 = new BizLogic.CapNhatGiaKH().Select(nkh);
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region DonHang
        /// <summary>
        /// đơn hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_DonHang(NetworkStream clientStream)
        {
            Entities.DonHang lsgd = (Entities.DonHang)formatter.Deserialize(clientStream);
            switch (lsgd.HanhDong)
            {

                case "Select":
                    {
                        Entities.DonHang[] lsgd1 = new BizLogic.DonHang().Select(lsgd);
                        formatter.Serialize(clientStream, lsgd1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region XuatHang
        /// <summary>
        /// xuất hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_XuatHang(NetworkStream clientStream)
        {
            Entities.XuatHang xh = (Entities.XuatHang)formatter.Deserialize(clientStream);
            switch (xh.HanhDong)
            {

                case "Select":
                    {
                        Entities.XuatHang[] xh1 = new BizLogic.XuatHang().Select(xh);
                        formatter.Serialize(clientStream, xh1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region TraLai
        /// <summary>
        /// trả lại
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_TraLai(NetworkStream clientStream)
        {
            Entities.TraLai tl = (Entities.TraLai)formatter.Deserialize(clientStream);
            switch (tl.HanhDong)
            {

                case "Select":
                    {
                        Entities.TraLai[] tl1 = new BizLogic.TraLai().Select(tl);
                        formatter.Serialize(clientStream, tl1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region ThanhToan
        /// <summary>
        /// thanh toán
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_ThanhToan(NetworkStream clientStream)
        {
            Entities.ThanhToan tt = (Entities.ThanhToan)formatter.Deserialize(clientStream);
            switch (tt.HanhDong)
            {

                case "Select":
                    {
                        Entities.ThanhToan[] tt1 = new BizLogic.ThanhToan().Select(tt);
                        formatter.Serialize(clientStream, tt1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region LSGDHangHoa
        /// <summary>
        /// lịch sử giao dịch hàng hóa
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_LSGDHangHoa(NetworkStream clientStream)
        {
            Entities.LSGDHangHoa hh = (Entities.LSGDHangHoa)formatter.Deserialize(clientStream);
            switch (hh.HanhDong)
            {

                case "Select":
                    {
                        Entities.LSGDHangHoa[] hh1 = new BizLogic.LSGDHangHoa().Select(hh);
                        formatter.Serialize(clientStream, hh1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region DonHangNCC
        /// <summary>
        /// đơn hàng nhà cung cấp
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_DonHangNCC(NetworkStream clientStream)
        {
            Entities.DonHangNCC lsgd = (Entities.DonHangNCC)formatter.Deserialize(clientStream);
            switch (lsgd.HanhDong)
            {

                case "Select":
                    {
                        Entities.DonHangNCC[] lsgd1 = new BizLogic.DonHangNCC().Select(lsgd);
                        formatter.Serialize(clientStream, lsgd1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion

        #region LSGDNhapMua
        /// <summary>
        /// nhập mua
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_LSGDNhapMua(NetworkStream clientStream)
        {
            Entities.LSGDNhapMua hh = (Entities.LSGDNhapMua)formatter.Deserialize(clientStream);
            switch (hh.HanhDong)
            {

                case "Select":
                    {
                        Entities.LSGDNhapMua[] hh1 = (Entities.LSGDNhapMua[])new BizLogic.LSGDNhapMua().Select(hh);
                        formatter.Serialize(clientStream, hh1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region LSGDTraLaiNCC
        /// <summary>
        /// trả lại nhà cung cấp
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_LSGDTraLaiNCC(NetworkStream clientStream)
        {
            Entities.LSGDTraLaiNCC hh = (Entities.LSGDTraLaiNCC)formatter.Deserialize(clientStream);
            switch (hh.HanhDong)
            {

                case "Select":
                    {
                        Entities.LSGDTraLaiNCC[] hh1 = (Entities.LSGDTraLaiNCC[])new BizLogic.LSGDTraLaiNCC().Select(hh);
                        formatter.Serialize(clientStream, hh1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region LSGDTTNCC
        /// <summary>
        /// trả lại nhà cung cấp
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_LSGDTTNCC(NetworkStream clientStream)
        {
            Entities.LSGDTTNCC hh = (Entities.LSGDTTNCC)formatter.Deserialize(clientStream);
            switch (hh.HanhDong)
            {

                case "Select":
                    {
                        Entities.LSGDTTNCC[] hh1 = (Entities.LSGDTTNCC[])new BizLogic.LSGDTTNCC().Select(hh);
                        formatter.Serialize(clientStream, hh1);
                        break;
                    }
                default:
                    break;
            }
        }
        # endregion
        #region BaoCaoNhapHangTheoMatHang
        /// <summary>
        /// cập nhật giá khách hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_BaoCaoNhapHangTheoMatHang(NetworkStream clientStream)
        {
            Entities.BaoCaoNhapHangTheoMatHang truyen = (Entities.BaoCaoNhapHangTheoMatHang)formatter.Deserialize(clientStream);
            switch (truyen.HanhDong)
            {
                case "Select":
                    {
                        Entities.BaoCaoNhapHangTheoMatHang[] nkh1 = new BizLogic.BaoCaoNhapHangTheoMatHang().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region BaoCaoNhapHangTheoNhomHang
        /// <summary>
        /// cập nhật giá khách hàng
        /// </summary>
        /// <param name="clientStream"></param>
        public void XuLy_BaoCaoNhapHangTheoNhomHang(NetworkStream clientStream)
        {
            Entities.BaoCaoNhapHangTheoNhomHang truyen = (Entities.BaoCaoNhapHangTheoNhomHang)formatter.Deserialize(clientStream);
            switch (truyen.HanhDong)
            {
                case "Select":
                    {
                        Entities.BaoCaoNhapHangTheoNhomHang[] nkh1 = new BizLogic.BaoCaoNhapHangTheoNhomHang().Select();
                        formatter.Serialize(clientStream, nkh1);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #endregion


        #region Vuong van hung =============================Process====================================================================
        private void GetDateTime(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.TruyenGiaTri select = new Entities.TruyenGiaTri();
                            select.Giatritruyen = DateTime.Now.ToShortDateString();
                            select.GiatritruyenTU = DateTime.Now;
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        private void LayQuyDoi(NetworkStream clientStream)
        {
            try
            {
                Entities.HangHoaGoiHang truyen = (Entities.HangHoaGoiHang)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.HangHoaGoiHang select = (Entities.HangHoaGoiHang)new BizLogic.QuyDoi().Select(truyen);
                            if (select == null)
                            {
                                select = new Entities.HangHoaGoiHang();
                            }
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void LayDonViTinh(NetworkStream clientStream)
        {
            try
            {
                Entities.QuyDoiDonViTinh truyen = (Entities.QuyDoiDonViTinh)formatter.Deserialize(clientStream);
                switch (truyen.HanhDong)
                {
                    case "Select":
                        {
                            Entities.QuyDoiDonViTinh[] select = (Entities.QuyDoiDonViTinh[])new BizLogic.QuyDoiDonViTinh().Select();
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void LayHangHoaGoiHang(NetworkStream clientStream)
        {
            try
            {
                Entities.HangHoaGoiHang truyen = (Entities.HangHoaGoiHang)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.HangHoaGoiHang[] select = (Entities.HangHoaGoiHang[])new BizLogic.HangHoaGoiHang().Select();
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void KiemTraNhomHangHoa(NetworkStream clientStream)
        {
            try
            {
                Entities.HienThiBaoCao[] gitri = (Entities.HienThiBaoCao[])formatter.Deserialize(clientStream);
                switch (gitri[0].STT)
                {
                    case "Select":
                        {
                            Entities.HienThiBaoCao[] select = (Entities.HienThiBaoCao[])new BizLogic.ThongTinHangHoa().KiemTraNhomHangHoa(gitri);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayBang_HangHoaTheoMaKhoHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinDatHang().sp_LayBang_HangHoaTheoMaKhoHang(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LaySoLuongDaNhapTheoHoaDonNhap(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.SoLuongTraLai[] data = (Entities.SoLuongTraLai[])new BizLogic.SoLuongTraLai().sp_LaySoLuongDaNhapTheoHoaDonNhap(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.SoLuongTraLai[] data = (Entities.SoLuongTraLai[])new BizLogic.SoLuongTraLai().sp_LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LaySoLuongDaMuaTheoHoaDonBanHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.SoLuongTraLai[] data = (Entities.SoLuongTraLai[])new BizLogic.SoLuongTraLai().sp_LaySoLuongDaMuaTheoHoaDonBanHang(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LaySoLuongKhachHangTraLaiTheoHoaDonBanHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.SoLuongTraLai[] data = (Entities.SoLuongTraLai[])new BizLogic.SoLuongTraLai().sp_LaySoLuongKhachHangTraLaiTheoHoaDonBanHang(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoSoDuKho(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.BaoCaoSoDuKho[] data = (Entities.BaoCaoSoDuKho[])new BizLogic.BaoCaoSoDuKho().Select(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void CapNhatDuNoNhaCungCap(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Update":
                        {
                            int data = new BizLogic.KiemTraChung().CapNhatDuNoNhaCungCap(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void CapNhatDuNoKhachHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Update":
                        {
                            int data = new BizLogic.KiemTraChung().CapNhatDuNoKhachHang(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LaySoLuongDaTraLaiTheoHoaDonNhap(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.KiemTraChung[] data = (Entities.KiemTraChung[])new BizLogic.KiemTraChung().LaySoLuongDaTraLaiTheoHoaDonNhap(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LaySoLuongDaTraLaiTheoHoaDonBanHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.KiemTraChung[] data = (Entities.KiemTraChung[])new BizLogic.KiemTraChung().LaySoLuongDaTraLaiTheoHoaDonBanHang(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoBanBuonBanLeTheoKy(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.BaoCaoBanBuonBanLeTheoKy[] data = (Entities.BaoCaoBanBuonBanLeTheoKy[])new BizLogic.BaoCaoBanBuonBanLeTheoKy().Select(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoKhachHangTraLaiTheoKy(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.BaoCaoKhachHangTraLaiTheoKy[] data = (Entities.BaoCaoKhachHangTraLaiTheoKy[])new BizLogic.BaoCaoKhachHangTraLaiTheoKy().Select(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoTraLaiNhaCungcapTheoKy(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.BaoCaoTraLaiNhaCungcapTheoKy[] data = (Entities.BaoCaoTraLaiNhaCungcapTheoKy[])new BizLogic.BaoCaoTraLaiNhaCungcapTheoKy().Select(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void TimHangHoaTheoMaNhomHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.ThongTinHangHoa[] data = (Entities.ThongTinHangHoa[])new BizLogic.ThongTinHangHoa().Select(truyen);
                            formatter.Serialize(clientStream, data);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoNhapHangTheoTungNhomHangTheoThoiGian(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian[] data = (Entities.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian[])new BizLogic.BaoCaoNhapHangTheoTungNhomHangTheoThoiGian().Select(truyen);
                        formatter.Serialize(clientStream, data);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoNhapHangTheoTungMatHangTheoThoiGian(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian[] data = (Entities.BaoCaoNhapHangTheoTungMatHangTheoThoiGian[])new BizLogic.BaoCaoNhapHangTheoTungMatHangTheoThoiGian().Select(truyen);
                        formatter.Serialize(clientStream, data);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoNhapHangTheoTungKhoTheoThoiGian(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] data = (Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[])new BizLogic.BaoCaoNhapHangTheoTungKhoTheoThoiGian().Select(truyen);
                        formatter.Serialize(clientStream, data);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void UpdateDuNo(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Update":
                    {
                        int i = new BizLogic.HoaDonNhap().UpdateDuNo(truyen);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                default:
                    break;
            }
        }
        // <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void KiemKeHangHoa(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri kh = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (kh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinDatHang().sp_KiemKeHangHoa(kh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void BindingKhachHangTralaiHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.ThongTinKhachHang[] select = (Entities.ThongTinKhachHang[])new BizLogic.HienThi_KhachHangTraLai().BindingKhachHangTralaiHang(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void ChiTietKhachHangTraLaiTheoDonBanHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.HienThi_KhachHangTraLai().ChiTietKhachHangTraLaiTheoDonBanHang(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayHangHoaTheoMaTraLaiNhaCungCap(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.LayHangHoaTheoMaKhachHangTraLai[] select = (Entities.LayHangHoaTheoMaKhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().LayHangHoaTheoMaTraLaiNhaCungCap(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// kiem tra khi them moi trallai nha cung cap
        /// </summary>
        /// <param name="clientStream"></param>
        private void CheckTraLaiNhaCungCap(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.TraLaiNCC select = (Entities.TraLaiNCC)new BizLogic.TraLaiNhaCungCap().CheckTraLaiNhaCungCap(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay hang hoa theo ma khach hang tra lai
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayHangHoaTheoMaKhachHangTraLaiHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.LayHangHoaTheoMaKhachHangTraLai[] select = (Entities.LayHangHoaTheoMaKhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().sp_LayHangHoaTheoMaKhachHangTraLai(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// kiem tra update khach hang tra lai hang
        /// </summary>
        /// <param name="clientStream"></param>
        private void CheckKhachHangTraLai(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.KhachHangTraLai select = (Entities.KhachHangTraLai)new BizLogic.KhachHangTraLai().CheckKhachHangTraLai(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// kiem tra trang thai don dat hang
        /// </summary>
        /// <param name="clientStream"></param>
        private void KiemTraDonDatHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.TruyenGiaTri select = (Entities.TruyenGiaTri)new BizLogic.KiemTraChung().KiemTraDonDatHang(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// kiem tra khi update hoa don nhap
        /// </summary>
        /// <param name="clientStream"></param>
        private void CheckHoaDonNhap(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.HoaDonNhap select = (Entities.HoaDonNhap)new BizLogic.HoaDonNhap().LayHoaDonNhap(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay chie tiet kiem ke theo ma kiem ke
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayKiemKeKhoTheoMaKiemKe(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.ThongTinKiemKeKho[] select = (Entities.ThongTinKiemKeKho[])new BizLogic.ChiTietKiemKeKho().sp_LayKiemKeKhoTheoMa(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// kiem tra kiem ke kho khi sua
        /// </summary>
        /// <param name="clientStream"></param>
        private void CheckKiemKeKho(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.KiemKeKho select = (Entities.KiemKeKho)new BizLogic.KiemKeKho().sp_LayBang_TheoTenBang(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay ban ghi khi update
        /// </summary>
        /// <param name="clientStream"></param>
        private void CheckKhoHang(NetworkStream clientStream)
        {
            try
            {
                Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
                switch (truyen.Hanhdong)
                {
                    case "Select":
                        {
                            Entities.KhoHang select = (Entities.KhoHang)new BizLogic.KhoHang().sp_LayBang_TheoTenBang(truyen);
                            formatter.Serialize(clientStream, select);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay du lieu don dat hang checkconfix
        /// </summary>
        /// <param name="clientStream"></param>
        private void CheckDonDatHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.DonDatHang select = (Entities.DonDatHang)new BizLogic.DonDatHang().sp_LayBang_TheoTenBang(truyen);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_KhoHang(NetworkStream clientStream)
        {
            try
            {
                Entities.KhoHang kh = (Entities.KhoHang)formatter.Deserialize(clientStream);
                switch (kh.HanhDong)
                {
                    case "Insert":
                        {
                            Entities.KhoHang k = (Entities.KhoHang)new BizLogic.KhoHang().InsertUpdate(kh);
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kh.Manhanvien, kh.Tendangnhap, kh.HanhDong, DateTime.Now.ToString(), "Thêm kho hàng: " + kh.MaKho));
                            formatter.Serialize(clientStream, k);
                            break;
                        }
                    case "Update":
                        {
                            Entities.KhoHang k = (Entities.KhoHang)new BizLogic.KhoHang().InsertUpdate(kh);
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kh.Manhanvien, kh.Tendangnhap, kh.HanhDong, DateTime.Now.ToString(), "Sửa kho hàng: " + kh.MaKho));
                            formatter.Serialize(clientStream, k);
                            break;
                        }
                    case "Delete":
                        {

                            int i = new BizLogic.KhoHang().Delete(kh);
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kh.Manhanvien, kh.Tendangnhap, kh.HanhDong, DateTime.Now.ToString(), "Xóa kho hàng: " + kh.MaKho));
                            formatter.Serialize(clientStream, i);
                            break;
                        }
                    case "Select":
                        {
                            Entities.KhoHang[] kho = new BizLogic.KhoHang().sp_SelectKhoHangsAll();
                            formatter.Serialize(clientStream, kho);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch { }
        }
        /// <summary>
        /// cap nhat trang thai don hang hoac kiem tra ma don dat hang tra ve 'OK' or 'NO'
        /// </summary>
        /// <param name="clientStream"></param>
        private void CapNhatTrangThaiDonDatHang(NetworkStream clientStream)
        {
            Entities.DonDatHang dat = (Entities.DonDatHang)formatter.Deserialize(clientStream);
            switch (dat.Hanhdong)
            {
                case "Check":
                    {
                        string tra = new BizLogic.DonDatHang().CapNhatTrangThaiDonDatHang(dat);
                        formatter.Serialize(clientStream, tra);
                        break;
                    }
                case "Update":
                    {
                        string tra = new BizLogic.DonDatHang().CapNhatTrangThaiDonDatHang(dat);
                        formatter.Serialize(clientStream, tra);
                        break;
                    }
                default:
                    break;
            }

        }

        private void ThemChiTietKhoHang(NetworkStream clientStream)
        {
            Entities.ChiTietKhoHangTheoHoaHonNhap[] ddh = (Entities.ChiTietKhoHangTheoHoaHonNhap[])formatter.Deserialize(clientStream);
            switch (ddh[0].Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.ChiTietKhoHangTheoHoaHonNhap().LuuLai(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.ChiTietKhoHangTheoHoaHonNhap().TruSoLuong(ddh);
                        if (i == 1)
                            formatter.Serialize(clientStream, true);
                        else
                            formatter.Serialize(clientStream, false);
                        break;
                    }
                case "UpdateCong":
                    {
                        int i = new BizLogic.ChiTietKhoHangTheoHoaHonNhap().CongSoLuong(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        ///  =============================them ChiTietDonDatHang=========================================
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_ChiTietDonDatHang(NetworkStream clientStream)
        {
            Entities.ChiTietDonDatHang[] ddh = (Entities.ChiTietDonDatHang[])formatter.Deserialize(clientStream);
            switch (ddh[0].Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.ChiTietDonDatHang().LuuLai(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietDonDatHang[] a = new BizLogic.ChiTietDonDatHang().Select(ddh[0].MaDonDatHang);
                        formatter.Serialize(clientStream, a);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// xoa nhung hang hoa theo don hang hien tai
        /// </summary>
        /// <param name="clientStream"></param>
        private void XoaTheoHoaDon(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Update":
                    {
                        int i = new BizLogic.CapNhat().XoaTheoMaHoaDon(truyen);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// hungvv============================xoa,select don dat hang
        /// </summary>
        /// <param name="clientStream"></param>
        private void Xoa_ChiTietDonDatHang(NetworkStream clientStream)
        {
            Entities.ChiTietDonDatHang ddh = (Entities.ChiTietDonDatHang)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Delete":
                    {
                        int i = new BizLogic.ChiTietDonDatHang().sp_Xoa_ChiTietDonDatHang(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietDonDatHang[] select = (Entities.ChiTietDonDatHang[])new BizLogic.ChiTietDonDatHang().sp_LayBang_ChiTietDonDatHang();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void XuLy_ChiTietHoaDonNhap(NetworkStream clientStream)
        {
            Entities.ChiTietHoaDonNhap[] ddh = (Entities.ChiTietHoaDonNhap[])formatter.Deserialize(clientStream);
            switch (ddh[0].Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.ChiTietHoaDonNhap().LuuLai(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietHoaDonNhap[] hdn = (Entities.ChiTietHoaDonNhap[])new BizLogic.ChiTietHoaDonNhap().sp_LayBang_ChiTietHoaDonNhap();
                        formatter.Serialize(clientStream, hdn);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_ChiTietKhachHangTraLai(NetworkStream clientStream)
        {
            Entities.ChiTietKhachHangTraLai[] ddh = (Entities.ChiTietKhachHangTraLai[])formatter.Deserialize(clientStream);
            switch (ddh[0].Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.ChiTietKhachHangTraLai().LuuLai(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietKhachHangTraLai[] ctk = new BizLogic.ChiTietKhachHangTraLai().sp_LayBang_ChiTietKhachHangTraLai();
                        formatter.Serialize(clientStream, ctk);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_ChiTietTraLaiNhaCungCap(NetworkStream clientStream)
        {
            Entities.ChiTietTraLaiNhaCungCap[] ddh = (Entities.ChiTietTraLaiNhaCungCap[])formatter.Deserialize(clientStream);
            switch (ddh[0].Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.ChiTietTraLaiNhaCungCap().LuuLai(ddh);
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.ChiTietTraLaiNhaCungCap[] ct = new Entities.ChiTietTraLaiNhaCungCap[0];
                        ct = (Entities.ChiTietTraLaiNhaCungCap[])new BizLogic.ChiTietTraLaiNhaCungCap().sp_LayBang_ChiTietTraLaiNhaCungCap();
                        formatter.Serialize(clientStream, ct);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// lay ma hoa don ban hang theo ma khach hang
        /// </summary>
        /// <param name="?"></param>
        private void TimHoaDonBanHangTheoMaKhachHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.HienThi_KhachHangTraLai[] select = (Entities.HienThi_KhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().sp_HoaDonBanHangTheoKhachHang(truyen);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay thong tin hang tra lai theo ma nha cung cap
        /// </summary>
        /// <param name="clientStream"></param>
        private void TimHoaDonNhapTheoMaNhaCungCap(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.HienThi_KhachHangTraLai[] select = (Entities.HienThi_KhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().sp_TimHoaDonNhapTheoMaNhaCungCap(truyen);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay thong tin hang tra lai theo ma hoa don nhap
        /// </summary>
        /// <param name="clientStream"></param>
        private void TimHangHoaTheoMaHoaDonNhap(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.LayHangHoaTheoMaKhachHangTraLai[] select = (Entities.LayHangHoaTheoMaKhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().sp_LayHangHoaTheoMaHoaDonNhap(truyen);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay hang hoa theo ma hoa don ban hang
        /// </summary>
        /// <param name="?"></param>
        private void LayHangHoaTheoMaHoaDonBanHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.LayHangHoaTheoMaKhachHangTraLai[] select = (Entities.LayHangHoaTheoMaKhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().sp_LayHangHoaTheoHoaDonBanHang(truyen);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void ThongTinMaVachHangHoa(NetworkStream clientStream)
        {
            Entities.ThongTinMaVach mavach = (Entities.ThongTinMaVach)formatter.Deserialize(clientStream);
            switch (mavach.HanhDong)
            {
                case "Select":
                    {
                        Entities.ThongTinMaVach[] select = (Entities.ThongTinMaVach[])new BizLogic.ThongTinMaVach().sp_LayBang_ThongTinMaVachHangHoa();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay thong tin tien te ti gia
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayThongTinTienTe(NetworkStream clientStream)
        {
            Entities.KiemTraChung giatri = (Entities.KiemTraChung)formatter.Deserialize(clientStream);
            switch (giatri.Hanhdong)
            {
                case "Select":
                    {
                        Entities.KiemTraChung[] select = (Entities.KiemTraChung[])new BizLogic.KiemTraChung().LayThongTinTienTe();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void ChiTietKhoTheoMaKho(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri giatri = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (giatri.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ChiTietKhoHangTheoMa[] select = (Entities.ChiTietKhoHangTheoMa[])new BizLogic.ChiTietKhoHangTheoMa().sp_ChiTietKhoHangTheoMa(giatri);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        ///bao cao xuat hang theo nhom hang hungvv
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoXuatHangTheoNhomHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri giatri = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (giatri.Hanhdong)
            {
                case "Select":
                    {
                        Entities.BaoCaoXuatHangTheoNhomHang[] select = (Entities.BaoCaoXuatHangTheoNhomHang[])new BizLogic.BaoCaoXuatHangTheoNhomHang().sp_BaoCao_XuatTheoNhomHang(giatri);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// bao cao xuat hang theo kho hang hang hungvv
        /// </summary>
        /// <param name="clientStream"></param>
        private void BaoCaoXuatHangTheoKho(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri giatri = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (giatri.Hanhdong)
            {
                case "Select":
                    {
                        Entities.BaoCaoXuatHangTheoKho[] select = (Entities.BaoCaoXuatHangTheoKho[])new BizLogic.BaoCaoXuatHangTheoKho().sp_BaoCao_XuatTheoKho(giatri);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay thong tin cong ty
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayThongTinCongty(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri giatri = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (giatri.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinCongTy select = (Entities.ThongTinCongTy)new BizLogic.ThongTinCongTy().sp_ThongTinCongTy(giatri);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay hang hoa theo ma hang hoa
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayHangHoaTheoMaHangHoa(NetworkStream clientStream)
        {
            Entities.HienThi_ChiTiet_DonDatHang hien = (Entities.HienThi_ChiTiet_DonDatHang)formatter.Deserialize(clientStream);
            switch (hien.HanhDong)
            {
                case "Select":
                    {
                        Entities.HienThi_ChiTiet_DonDatHang select = (Entities.HienThi_ChiTiet_DonDatHang)new BizLogic.HienThi_ChiTiet_DonDatHang().sp_LayHangHoaTheoMaHangHoa(hien);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void ThongTinTraLaiNhaCungCap(NetworkStream clientStream)
        {
            Entities.ThongTinDatHang ddh = (Entities.ThongTinDatHang)formatter.Deserialize(clientStream);
            switch (ddh.HanhDong)
            {
                case "Select":
                    {
                        Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinDatHang().ThongTinTraLaiNhaCungCap(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay thong tin hang hoa da dat hang nha cung cap
        /// </summary>
        /// <param name="clientStream"></param>

        private void LayChiTietTraLaiNhaCungCap(NetworkStream clientStream)
        {
            Entities.ThongTinDatHang ddh = (Entities.ThongTinDatHang)formatter.Deserialize(clientStream);
            switch (ddh.HanhDong)
            {
                case "Select":
                    {
                        Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinDatHang().sp_LayChiTietTraLaiNhaCungCap(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// lay don dat hang nha cung cap đa thanh cong
        /// </summary>
        /// <param name="clientStream"></param>
        private void LayDonDatHangNhaCungCap(NetworkStream clientStream)
        {
            Entities.ThongTinDatHang ddh = (Entities.ThongTinDatHang)formatter.Deserialize(clientStream);
            switch (ddh.HanhDong)
            {
                case "Select":
                    {
                        Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinDatHang().sp_LayDonDatHangNhaCungCap();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_ChiTietKiemKeKho(NetworkStream clientStream)
        {
            Entities.ChiTietKiemKeKho ddh = (Entities.ChiTietKiemKeKho)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ChiTietKiemKeKho[] select = (Entities.ChiTietKiemKeKho[])new BizLogic.ChiTietKiemKeKho().sp_LayBang_ChiTietKiemKeKho(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void ThongTinHoaDonBanHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri ddh = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.HienThi_KhachHangTraLai[] select = (Entities.HienThi_KhachHangTraLai[])new BizLogic.HienThi_KhachHangTraLai().sp_HoaDonBanHangTheoKhachHang(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_LayThongTinHoaDonNhap(NetworkStream clientStream)
        {
            Entities.ThongTinDatHang ddh = (Entities.ThongTinDatHang)formatter.Deserialize(clientStream);
            switch (ddh.HanhDong)
            {
                case "Select":
                    {
                        Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinHoaDonNhap().sp_LayBang_HoaDonNhap(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_HienThi_ChiTiet_HoaDonNhap(NetworkStream clientStream)
        {
            Entities.HienThi_ChiTiet_DonDatHang ddh = (Entities.HienThi_ChiTiet_DonDatHang)formatter.Deserialize(clientStream);
            switch (ddh.HanhDong)
            {
                case "Select":
                    {
                        Entities.HienThi_ChiTiet_DonDatHang[] select = (Entities.HienThi_ChiTiet_DonDatHang[])new BizLogic.ChiTietHoaDonNhap().sp_LayBang_ThongTinHoaDonNhap(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_HienThi_ChiTiet_KhachHangTraLai(NetworkStream clientStream)
        {
            Entities.ThongTinMaDonDatHang ddh = (Entities.ThongTinMaDonDatHang)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinMaDonDatHang[] select = (Entities.ThongTinMaDonDatHang[])new BizLogic.HoaDonNhap().sp_LayBang_ThongTinMaDonDatHang();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void ThemchiTietKiemKeKho(NetworkStream clientStream)
        {
            Entities.ChiTietKiemKeKho[] kt = (Entities.ChiTietKiemKeKho[])formatter.Deserialize(clientStream);
            switch (kt[0].Hanhdong)
            {
                case "Insert":
                    {
                        // Them ct kiem ke kho
                        int trave = new BizLogic.ChiTietKiemKeKho().LuuLai(kt);
                        // cap nhat sl vao ct kho hang
                        if (kt != null && kt.Length > 0)
                        {
                            foreach (Entities.ChiTietKiemKeKho item in kt)
                            {
                                new BizLogic.ChiTietKhoHangTheoHoaHonNhap().CongSoLuong(item);
                            }
                        }
                        // cap nhat gia von 

                        formatter.Serialize(clientStream, trave);
                        break;
                    }
                case "Update":
                    {
                        Entities.ChiTietKiemKeKho ct = new Entities.ChiTietKiemKeKho();
                        if (kt != null)
                            ct = kt[0];
                        // Delete Ct
                        new BizLogic.ChiTietKiemKeKho().Delete(ct.MaPhieuKiemKe);
                        // Them ct kiem ke kho
                        int trave = new BizLogic.ChiTietKiemKeKho().LuuLai(kt);
                        // cap nhat sl vao ct kho hang
                        if (kt != null && kt.Length > 0)
                        {
                            foreach (Entities.ChiTietKiemKeKho item in kt)
                            {
                                if (item.IsChange)
                                    new BizLogic.ChiTietKhoHangTheoHoaHonNhap().CongSoLuong(item);
                            }
                        }

                        formatter.Serialize(clientStream, trave);
                        break;
                    }
                default:
                    break;
            }
        }
        private void KiemTraMa(NetworkStream clientStream)
        {
            Entities.KiemTraChung kt = (Entities.KiemTraChung)formatter.Deserialize(clientStream);
            switch (kt.Hanhdong)
            {
                case "Select":
                    {
                        Entities.KiemTraChung select = (Entities.KiemTraChung)new BizLogic.KiemTraChung().KiemTraMa(kt);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// lay id vao combox
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_LayCombox(NetworkStream clientStream)
        {
            Entities.KiemTraChung kt = (Entities.KiemTraChung)formatter.Deserialize(clientStream);
            switch (kt.Hanhdong)
            {
                case "Select":
                    {
                        Entities.KiemTraChung[] select = (Entities.KiemTraChung[])new BizLogic.KiemTraChung().LayCombox(kt);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void Top_Mot(NetworkStream clientStream)
        {
            Entities.Lay_ID_Top_1 ddh = (Entities.Lay_ID_Top_1)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.Lay_ID_Top_1 select = (Entities.Lay_ID_Top_1)new BizLogic.KhachHangTraLai().sp_Tim_ID();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void XuLy_HienThi_ThongTinMaDonDatHang(NetworkStream clientStream)
        {
            Entities.ThongTinMaDonDatHang ddh = (Entities.ThongTinMaDonDatHang)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinMaDonDatHang[] select = (Entities.ThongTinMaDonDatHang[])new BizLogic.HoaDonNhap().sp_LayBang_ThongTinMaDonDatHang();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_sp_Tim_ID_HoaDonNhap(NetworkStream clientStream)
        {
            Entities.Lay_ID_Top_1 ddh = (Entities.Lay_ID_Top_1)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.Lay_ID_Top_1 select = (Entities.Lay_ID_Top_1)new BizLogic.HoaDonNhap().sp_Tim_ID();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void XuLy_HienThi_ThongTinKhachHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri kh = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (kh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinKhachHang[] select = (Entities.ThongTinKhachHang[])new BizLogic.ThongTinKhachHang().sp_LayBang_KhachHang(kh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        private void XuLy_HienThi_ChiTiet_DonDatHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri kh = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (kh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.HienThi_ChiTiet_DonDatHang[] select = (Entities.HienThi_ChiTiet_DonDatHang[])new BizLogic.HienThi_ChiTiet_DonDatHang().sp_LayBang_ThongTinDonDatHang(kh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        public void XuLy_ThongTinNhanVienHienThi(NetworkStream clientStream)
        {
            Entities.ThongTinNhanVien kh = (Entities.ThongTinNhanVien)formatter.Deserialize(clientStream);
            switch (kh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinNhanVien[] select = (Entities.ThongTinNhanVien[])new BizLogic.ThongTinNhanVien().sp_LayBang_ThongTinNhanVien();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void XuLy_ThongTinNhaCungCap(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri truyen = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (truyen.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinNhaCungCap[] select = (Entities.ThongTinNhaCungCap[])new BizLogic.ThongTinNhaCungCap().sp_LayBang_NhaCungCap(truyen);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void XuLy_ThongTinDatHang(NetworkStream clientStream)
        {
            Entities.TruyenGiaTri kh = (Entities.TruyenGiaTri)formatter.Deserialize(clientStream);
            switch (kh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.ThongTinDatHang[] select = (Entities.ThongTinDatHang[])new BizLogic.ThongTinDatHang().sp_LayBang_HangHoa(kh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        private void XuLy_ThongTinTienTe(NetworkStream clientStream)
        {
            Entities.TienTe kh = (Entities.TienTe)formatter.Deserialize(clientStream);
            switch (kh.HanhDong)
            {
                case "Select":
                    {
                        Entities.TienTe[] select = (Entities.TienTe[])new BizLogic.TienTe().Select();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        ///  =============================get ID=========================================
        /// </summary>
        /// <param name="clientStream"></param>
        private void Lay_ID_Top_1(NetworkStream clientStream)
        {
            Entities.Lay_ID_Top_1 ddh = (Entities.Lay_ID_Top_1)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Select":
                    {
                        Entities.Lay_ID_Top_1 select = (Entities.Lay_ID_Top_1)new BizLogic.DonDatHang().sp_Tim_ID();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }


        /// <summary>
        ///  =============================kiem ke kho=========================================
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_KiemKeKho(NetworkStream clientStream)
        {
            Entities.KiemKeKho ddh = (Entities.KiemKeKho)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.KiemKeKho().sp_XuLy_KiemKeKho(ddh);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ddh.Manhanvien, ddh.Tendangnhap, ddh.Hanhdong, DateTime.Now.ToString(), "Thêm kiểm kê kho: " + ddh.MaKiemKe));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.KiemKeKho().sp_XuLy_KiemKeKho(ddh);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ddh.Manhanvien, ddh.Tendangnhap, ddh.Hanhdong, DateTime.Now.ToString(), "Sửa kiểm kê kho: " + ddh.MaKiemKe));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Delete":
                    {
                        int i = new BizLogic.KiemKeKho().sp_Xoa_KiemKeKho(ddh);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ddh.Manhanvien, ddh.Tendangnhap, ddh.Hanhdong, DateTime.Now.ToString(), "Xóa kiểm kê kho: " + ddh.MaKiemKe));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.KiemKeKho[] select = (Entities.KiemKeKho[])new BizLogic.KiemKeKho().sp_LayBang_KiemKeKho(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        ///  =============================don dat hang=========================================
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_DonDatHang(NetworkStream clientStream)
        {
            Entities.DonDatHang ddh = (Entities.DonDatHang)formatter.Deserialize(clientStream);
            switch (ddh.Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.DonDatHang().sp_XuLy_DonDatHang(ddh);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ddh.Manhanvien, ddh.Tendangnhap, ddh.Hanhdong, DateTime.Now.ToString(), "Thêm đơn đặt hàng: " + ddh.MaDonDatHang));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.DonDatHang().sp_XuLy_DonDatHang(ddh);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ddh.Manhanvien, ddh.Tendangnhap, ddh.Hanhdong, DateTime.Now.ToString(), "Sửa đơn đặt hàng: " + ddh.MaDonDatHang));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Delete":
                    {
                        int i = new BizLogic.DonDatHang().sp_Xoa_DonDatHang(ddh);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(ddh.Manhanvien, ddh.Tendangnhap, ddh.Hanhdong, DateTime.Now.ToString(), "Xóa đơn đặt hàng: " + ddh.MaDonDatHang));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.DonDatHang[] select = (Entities.DonDatHang[])new BizLogic.DonDatHang().sp_LayBang_DonDatHang(ddh);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                case "SelectDDH":
                    {
                        Entities.DonDatHang[] select = (Entities.DonDatHang[])new BizLogic.DonDatHang().Select();
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// =======================================hoa don nhap=========================================================
        /// </summary>
        private void XuLy_HoaDonNhap(NetworkStream clientStream)
        {
            Entities.HoaDonNhap hdn = (Entities.HoaDonNhap)formatter.Deserialize(clientStream);
            switch (hdn.Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.HoaDonNhap().sp_XuLy_HoaDonNhap(hdn);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hdn.Manhanvien, hdn.Tendangnhap, hdn.Hanhdong, DateTime.Now.ToString(), "Thêm hóa đơn nhập kho: " + hdn.MaHoaDonNhap));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.HoaDonNhap().sp_XuLy_HoaDonNhap(hdn);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hdn.Manhanvien, hdn.Tendangnhap, hdn.Hanhdong, DateTime.Now.ToString(), "Sửa hóa đơn nhập kho: " + hdn.MaHoaDonNhap));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Delete":
                    {
                        int i = new BizLogic.HoaDonNhap().sp_Xoa_HoaDonNhap(hdn);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hdn.Manhanvien, hdn.Tendangnhap, hdn.Hanhdong, DateTime.Now.ToString(), "Xóa hóa đơn nhập kho: " + hdn.MaHoaDonNhap));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.HoaDonNhap[] select = (Entities.HoaDonNhap[])new BizLogic.HoaDonNhap().sp_LayBang_HoaDonNhap(hdn);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// =========================================khach hang tra lai============================================================
        /// </summary>
        /// <param name="clientStream"></param>
        private void XuLy_KhachHangTraLai(NetworkStream clientStream)
        {
            Entities.KhachHangTraLai khtl = (Entities.KhachHangTraLai)formatter.Deserialize(clientStream);
            switch (khtl.Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.KhachHangTraLai().sp_XuLy_KhachHangTraLai(khtl);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(khtl.Manhanvien, khtl.Tendangnhap, khtl.Hanhdong, DateTime.Now.ToString(), "Thêm khách hàng trả lại hàng: " + khtl.MaKhachHangTraLai));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.KhachHangTraLai().sp_XuLy_KhachHangTraLai(khtl);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(khtl.Manhanvien, khtl.Tendangnhap, khtl.Hanhdong, DateTime.Now.ToString(), "Sửa khách hàng trả lại hàng: " + khtl.MaKhachHangTraLai));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Delete":
                    {
                        int i = new BizLogic.KhachHangTraLai().sp_Xoa_KhachHangTraLai(khtl);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(khtl.Manhanvien, khtl.Tendangnhap, khtl.Hanhdong, DateTime.Now.ToString(), "Xóa khách hàng trả lại hàng: " + khtl.MaKhachHangTraLai));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.KhachHangTraLai[] select = (Entities.KhachHangTraLai[])new BizLogic.KhachHangTraLai().sp_LayBang_KhachHangTraLai(khtl);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// ===============================================tra lai nha cung cap========================================================
        /// </summary>
        private void XuLy_TraLaiNhaCungCap(NetworkStream clientStream)
        {
            Entities.TraLaiNCC kkcc = (Entities.TraLaiNCC)formatter.Deserialize(clientStream);
            switch (kkcc.Hanhdong)
            {
                case "Insert":
                    {
                        int i = new BizLogic.TraLaiNhaCungCap().sp_XuLy_TraLaiNhaCungCap(kkcc);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kkcc.Manhanvien, kkcc.Tendangnhap, kkcc.Hanhdong, DateTime.Now.ToString(), "Thêm trả lại nhà cung cấp: " + kkcc.MaHDTraLaiNCC));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Update":
                    {
                        int i = new BizLogic.TraLaiNhaCungCap().sp_XuLy_TraLaiNhaCungCap(kkcc);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kkcc.Manhanvien, kkcc.Tendangnhap, kkcc.Hanhdong, DateTime.Now.ToString(), "Sửa trả lại nhà cung cấp: " + kkcc.MaHDTraLaiNCC));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Delete":
                    {
                        int i = new BizLogic.TraLaiNhaCungCap().sp_Xoa_TraLaiNhaCungCap(kkcc);
                        if (i == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(kkcc.Manhanvien, kkcc.Tendangnhap, kkcc.Hanhdong, DateTime.Now.ToString(), "Xóa trả lại nhà cung cấp: " + kkcc.MaHDTraLaiNCC));
                        }
                        formatter.Serialize(clientStream, i);
                        break;
                    }
                case "Select":
                    {
                        Entities.TraLaiNCC[] select = (Entities.TraLaiNCC[])new BizLogic.TraLaiNhaCungCap().sp_LayBang_tralainhacungcap(kkcc);
                        formatter.Serialize(clientStream, select);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Server Luan
        #region Hàng Hóa

        public void XuLy_HangHoa(NetworkStream clientStream)
        {
            Entities.HangHoa hh = (Entities.HangHoa)formatter.Deserialize(clientStream);
            switch (hh.HanhDong)
            {
                case "Insert":
                    {
                        int kt1 = new BizLogic.HangHoa().InsertUpdate(hh);
                        bool kt = false;
                        if (kt1 == 1)
                        {
                            kt = true;
                        }
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hh.NhanVienID, hh.TenDangNhap, hh.HanhDong, DateTime.Now.ToString(), "Thêm Hàng Hóa: " + hh.MaHangHoa));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        int kt1 = new BizLogic.HangHoa().InsertUpdate(hh);
                        bool kt = false;
                        if (kt1 == 1)
                        {
                            kt = true;
                        }
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hh.NhanVienID, hh.TenDangNhap, hh.HanhDong, DateTime.Now.ToString(), "Sửa Hàng Hóa: " + hh.MaHangHoa));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        int kt1 = new BizLogic.HangHoa().Delete(hh);
                        bool kt = false;
                        if (kt1 == 1)
                        {
                            kt = true;
                        }
                        if (kt == true)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(hh.NhanVienID, hh.TenDangNhap, hh.HanhDong, DateTime.Now.ToString(), "Xóa Hàng Hóa: " + hh.MaHangHoa));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.HangHoa[] hhoa = new BizLogic.HangHoa().sp_SelectHangHoasAll();
                        formatter.Serialize(clientStream, hhoa);
                        break;
                    }
                case "SelectAll":
                    {
                        Entities.HangHoa[] hhoa = new BizLogic.HangHoa().SelectAll();
                        formatter.Serialize(clientStream, hhoa);
                        break;
                    }
                case "SearchTheoKho":
                    {
                        Entities.HangHoa[] kh1 = new BizLogic.HangHoa().Select(hh.Cot, hh.Kieu, hh.GiaTri, hh.MaKho);
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                case "Search":
                    {
                        Entities.HangHoa[] kh1 = new BizLogic.HangHoa().Select(hh.Cot, hh.Kieu, hh.GiaTri);
                        formatter.Serialize(clientStream, kh1);
                        break;
                    }
                case "SelectTheoKho":
                    {
                        Entities.HangHoa[] hhoa = new BizLogic.HangHoa().SelectHHTheoKho(hh.MaKho);
                        formatter.Serialize(clientStream, hhoa);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Nhóm Hàng Hóa

        public void XuLy_NhomHang(NetworkStream clientStream)
        {
            Entities.NhomHang nhh = (Entities.NhomHang)formatter.Deserialize(clientStream);
            switch (nhh.HanhDong)
            {
                case "Insert":
                    {

                        bool kt = new BizLogic.NhomHang().InsertUpdate(nhh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {

                        bool kt = new BizLogic.NhomHang().InsertUpdate(nhh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {

                        bool kt = new BizLogic.NhomHang().Delete(nhh);
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.NhomHang[] nnhang = new BizLogic.NhomHang().sp_SelectNhomHangsAll();
                        formatter.Serialize(clientStream, nnhang);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Loại Hàng Hóa

        public void XuLy_LoaiHangHoa(NetworkStream clientStream)
        {
            Entities.LoaiHangHoa lhh = (Entities.LoaiHangHoa)formatter.Deserialize(clientStream);
            switch (lhh.HanhDong)
            {
                case "Insert":
                    {
                        int kt = new BizLogic.LoaiHangHoa().InsertUpdate(lhh);
                        if (kt == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(lhh.MaNhanVien, lhh.TenDangNhap, lhh.HanhDong, DateTime.Now.ToString(), "Thêm loại hàng hóa: " + lhh.MaLoaiHang));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        int kt = new BizLogic.LoaiHangHoa().InsertUpdate(lhh);
                        if (kt == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(lhh.MaNhanVien, lhh.TenDangNhap, lhh.HanhDong, DateTime.Now.ToString(), "Sửa loại hàng hóa: " + lhh.MaLoaiHang));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.LoaiHangHoa().Delete(lhh);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.LoaiHangHoa[] lhhang = new BizLogic.LoaiHangHoa().sp_SelectLoaiHangHoasAll();
                        formatter.Serialize(clientStream, lhhang);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #region Đơn Vị Tính

        public void XuLy_DVT(NetworkStream clientStream)
        {
            Entities.DVT dvt = (Entities.DVT)formatter.Deserialize(clientStream);
            switch (dvt.HanhDong)
            {
                case "Insert":
                    {
                        int kt = new BizLogic.DVT().InsertUpdate(dvt);
                        if (kt == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(dvt.MaNhanVien, dvt.TenDangNhap, dvt.HanhDong, DateTime.Now.ToString(), "Thêm đơn vị tính: " + dvt.MaDonViTinh));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        int kt = new BizLogic.DVT().InsertUpdate(dvt);
                        if (kt == 1)
                        {
                            new BizLogic.LogFile().GhiFile(new Entities.LogFile(dvt.MaNhanVien, dvt.TenDangNhap, dvt.HanhDong, DateTime.Now.ToString(), "Sửa đơn vị tính: " + dvt.MaDonViTinh));
                        }
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.DVT().Delete(dvt);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.DVT[] donvi = new BizLogic.DVT().sp_SelectDVTsAll();
                        formatter.Serialize(clientStream, donvi);
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion
        #region Loại Thuế
        public void XuLy_LoaiThue(NetworkStream clientStream)
        {
            Entities.LoaiThue lt = (Entities.LoaiThue)formatter.Deserialize(clientStream);
            switch (lt.HanhDong)
            {
                case "Insert":
                    {
                        new BizLogic.LoaiThue().InsertUpdate(lt);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Update":
                    {
                        new BizLogic.LoaiThue().InsertUpdate(lt);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Delete":
                    {
                        new BizLogic.LoaiThue().Delete(lt);
                        bool kt = true;
                        formatter.Serialize(clientStream, kt);
                        break;
                    }
                case "Select":
                    {
                        Entities.LoaiThue[] loaithue = new BizLogic.LoaiThue().sp_SelectLoaiThuesAll();
                        formatter.Serialize(clientStream, loaithue);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        #endregion

        #region Server cua Lamtv
        public void Xuly_GiaVonBanHang(NetworkStream clientStream)
        {
            Entities.GiaVonBanHang gv = (Entities.GiaVonBanHang)formatter.Deserialize(clientStream);
            // kiểm tra hành động được gửi đến
            switch (gv.HanhDong)
            {
                case "Insert":
                    {
                        bool msg = new BizLogic.GiaVonBanHang().Insert(gv);
                        formatter.Serialize(clientStream, msg);
                        break;
                    }

                case "SelectAll":
                    {
                        Entities.GiaVonBanHang[] gvArr = new BizLogic.GiaVonBanHang().Select(gv);
                        formatter.Serialize(clientStream, gvArr);
                        break;
                    }

                case "SelectBy":
                    {
                        Entities.GiaVonBanHang[] gvArr = new BizLogic.GiaVonBanHang().Select(gv);
                        formatter.Serialize(clientStream, gvArr);
                        break;
                    }

                default:
                    break;
            }
        }
        #endregion


    }
}