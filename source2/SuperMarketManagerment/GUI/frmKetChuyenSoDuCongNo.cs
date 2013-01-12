using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmKetChuyenSoDuCongNo : Form
    {
        string ma = "";
        string id = "";
        string year;
        string month;
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.SoDuCongNo[] hienthi;
        Entities.SoDuCongNo[] hienthi1;
        DateTime datesv;
        public frmKetChuyenSoDuCongNo()
        {
            InitializeComponent();
            datesv = DateServer.Date();
            cbbnam.Text = datesv.Year.ToString();
            cbbthang.Text = datesv.Month.ToString();
            cbbdoituong.SelectedIndex = 0;
            SelectData();
        }

        public void SelectData()
        {
            try
            {
                bool loaiDoiTuong = false;
                if (cbbdoituong.SelectedIndex == 0)
                    loaiDoiTuong = false;
                else
                    loaiDoiTuong = true;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuCongNo[] pt = new Entities.SoDuCongNo[1];
                pt[0] = new Entities.SoDuCongNo("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi1 = (Entities.SoDuCongNo[])cl.DeserializeHepper1(clientstrem, hienthi1);
                if (hienthi1 == null)
                {
                    lbtrangthai.Text = "Kỳ này chưa đóng";
                    lbtrangthai.ForeColor = Color.Black;
                    tsslthuchien.Enabled = true;
                    return;
                }
                year = cbbnam.Text;
                month = cbbthang.Text;
                int sotang = 0;
                bool ktsd = false;
                Entities.SoDuCongNo[] sq = new Entities.SoDuCongNo[hienthi1.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = hienthi1[i].NgayKetChuyen.Year.ToString();
                    string thangkt = hienthi1[i].NgayKetChuyen.Month.ToString();

                    if (namkt == year && thangkt == month && hienthi1[i].LoaiDoiTuong == loaiDoiTuong)
                    {
                        if (hienthi1[i].TrangThai == false)
                        {
                            lbtrangthai.Text = "Kỳ này chưa đóng";
                            lbtrangthai.ForeColor = Color.Black;
                            tsslthuchien.Enabled = true;
                        }
                        else
                        {
                            lbtrangthai.Text = "Kỳ này đã khóa";
                            lbtrangthai.ForeColor = Color.Red;
                            tsslthuchien.Enabled = false;
                        }
                        ma = hienthi1[i].MaSoDuCongNo;
                        sq[sotang] = hienthi1[i];
                        sotang++;
                        ktsd = true;
                    }

                }
                if (ktsd == false)
                {
                    lbtrangthai.Text = "Kỳ này chưa đóng";
                    lbtrangthai.ForeColor = Color.Black;
                    tsslthuchien.Enabled = true;
                }
                if (sotang != 0)
                {
                    hienthi = new Entities.SoDuCongNo[sotang];
                    for (int i = 0; i < sotang; i++)
                    {
                        hienthi[i] = sq[i];
                    }
                }
                else
                    hienthi = null;
            }
            catch { }
            finally { }
        }

        private void tssltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = cbbnam.Text;
            month = cbbthang.Text;
            label1.Text = "Kết Chuyển Số Dư Công Nợ Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            SelectData();
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = cbbnam.Text;
            month = cbbthang.Text;
            label1.Text = "Kết Chuyển Số Dư Công Nợ Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            SelectData();
        }

        private void cbbdoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = cbbnam.Text;
            month = cbbthang.Text;
            label1.Text = "Kết Chuyển Số Dư Công Nợ Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            SelectData();
        }

        private void tsslthuchien_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                bool loaidoituong=false;
                string monthhientai = datesv.Month.ToString();
                string namhientai = datesv.Year.ToString();
                if(cbbdoituong.SelectedIndex==0)
                {
                    loaidoituong = false;
                }
                else
                    loaidoituong = true;
                
                if (hienthi != null)
                {
                    string month = hienthi[0].NgayKetChuyen.Month.ToString();
                    string year = hienthi[0].NgayKetChuyen.Year.ToString();
                    if (month == monthhientai && year == namhientai)
                    {
                        int soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            if (month == hienthi[i].NgayKetChuyen.Month.ToString() && year == hienthi[i].NgayKetChuyen.Year.ToString() && hienthi[i].LoaiDoiTuong==loaidoituong)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            MessageBox.Show("Bạn phải kết chuyển kỳ trước - Kiểm tra lại", "Hệ thống cảnh báo");
                            return;
                        }
                        frmCongNo a = new frmCongNo(namhientai, monthhientai, cbbdoituong.SelectedIndex);
                        if (frmCongNo.mangchitiet.ToArray().Length == 0)
                        {
                            frmCongNo.mangchitiet = new List<Entities.SoDuCongNo>();
                            frmCongNo.mangchitiet[0] = new Entities.SoDuCongNo("UpdateTrangThai", "");
                            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Không phát sinh Công nợ nào - Bạn xác nhận kết chuyển không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                            {
                                if (giatri == System.Windows.Forms.DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.SoDuCongNo[] pt = frmCongNo.mangchitiet.ToArray();
                        clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                        bool kt = false;
                        kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt == true)
                        {
                            SelectData();
                        }
                        else
                        {
                            MessageBox.Show("Thất bại - xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        }
                    }
                    else
                    {
                        string monthkytruoc = "";
                        string yearkytruoc = "";
                        if ((datesv.Month - 1) == 0)
                        {
                            monthkytruoc = "12";
                            yearkytruoc = (datesv.Year - 1).ToString();
                        }
                        else
                        {
                            monthkytruoc = (datesv.Month - 1).ToString();
                            yearkytruoc = datesv.Year.ToString();
                        }
                        if (month == monthkytruoc && year == yearkytruoc)
                        {

                            frmCongNo a = new frmCongNo(yearkytruoc, monthkytruoc, cbbdoituong.SelectedIndex);
                            if (frmCongNo.mangchitiet.ToArray().Length == 0)
                            {
                                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Không phát sinh Công nợ nào - Bạn xác nhận kết chuyển không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                                {
                                    if (giatri == System.Windows.Forms.DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                            }
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.SoDuCongNo[] pt = frmCongNo.mangchitiet.ToArray();
                            clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                                SelectData();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại - xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không phải kỳ hiện tại - không thể kết chuyển", "Hệ thống cảnh báo");
                            return;
                        }
                    }
                }
                else
                {
                    string month = cbbthang.Text;
                    string year = cbbnam.Text;
                    
                    if (hienthi1 != null)
                    {
                        int soluong = 0;
                        for (int i = 0; i < hienthi1.Length; i++)
                        {
                            if (month == hienthi1[i].NgayKetChuyen.Month.ToString() && year == hienthi1[i].NgayKetChuyen.Year.ToString())
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            MessageBox.Show("Bạn phải kết chuyển kỳ trước - Kiểm tra lại", "Hệ thống cảnh báo");
                            return;
                        }
                    }

                    if (month == monthhientai && year == namhientai)
                    {

                        frmCongNo a = new frmCongNo(namhientai, monthhientai, cbbdoituong.SelectedIndex);
                        if (frmCongNo.mangchitiet.ToArray().Length == 0)
                        {
                            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Không phát sinh Công nợ nào - Bạn xác nhận kết chuyển không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                            {
                                if (giatri == System.Windows.Forms.DialogResult.No)
                                {
                                    MessageBox.Show("Không phát sinh Công nợ nào", "Hệ thống cảnh báo");
                                    return;
                                }
                            }
                        }
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.SoDuCongNo[] pt = frmCongNo.mangchitiet.ToArray();
                        clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                        bool kt = false;
                        kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt == true)
                        {
                            SelectData();
                        }
                        else
                        {
                            MessageBox.Show("Thất bại - xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        }
                    }
                    else
                    {
                        string monthkytruoc = "";
                        string yearkytruoc = "";
                        if ((datesv.Month - 1) == 0)
                        {
                            monthkytruoc = "12";
                            yearkytruoc = (datesv.Year - 1).ToString();
                        }
                        else
                        {
                            monthkytruoc = (datesv.Month - 1).ToString();
                            yearkytruoc = datesv.Year.ToString();
                        }
                        if (month == monthkytruoc && year == yearkytruoc)
                        {

                            frmCongNo a = new frmCongNo(yearkytruoc, monthkytruoc, cbbdoituong.SelectedIndex);
                            if (frmCongNo.mangchitiet.ToArray().Length == 0)
                            {
                                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Không phát sinh Công nợ nào - Bạn xác nhận kết chuyển không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                                {
                                    if (giatri == System.Windows.Forms.DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                            }
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.SoDuCongNo[] pt = frmCongNo.mangchitiet.ToArray();
                            clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                                SelectData();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại - xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không phải kỳ hiện tại - không thể kết chuyển", "Hệ thống cảnh báo");
                            return;
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, hienthi);
                if (lid == null)
                    return "SDCN_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void frmKetChuyenSoDuCongNo_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void frmKetChuyenSoDuCongNo_Load(object sender, EventArgs e)
        {
            label1.Text = "Kết Chuyển Số Dư Công Nợ Kỳ " + datesv.Month + "/" + datesv.Year;
            label3.Text = "Hãy chắc chắn hôm nay " + datesv.Day + "/" + datesv.Month + "/" + datesv.Year + "\nlà ngày giao dịch cuối cùng trong kỳ";
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }
    }
}
