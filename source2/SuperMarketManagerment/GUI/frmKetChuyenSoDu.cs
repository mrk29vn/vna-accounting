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
    public partial class frmKetChuyenSoDu : Form
    {
        string ma = "";
        string id = "";
        string nam;
        string thang;
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.SoDuSoQuy[] hienthi;
        DateTime datesv;
        public frmKetChuyenSoDu()
        {
            InitializeComponent();
            datesv = DateServer.Date();
            cbbnam.Text = datesv.Year.ToString();
            cbbthang.Text = datesv.Month.ToString();
            SelectData();
        }

        /// <summary>
        /// select dữ liệu
        /// </summary>
        public void SelectData()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.SoDuSoQuy[])cl.DeserializeHepper1(clientstrem, hienthi);
                if (hienthi == null)
                {
                    lbtrangthai.Text = "Kỳ này chưa đóng";
                    lbtrangthai.ForeColor = Color.Black;
                    return;
                }
                nam = cbbnam.Text;
                thang = cbbthang.Text;
                int sotang = 0;
                Entities.SoDuSoQuy[] sq = new Entities.SoDuSoQuy[hienthi.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = hienthi[i].NgayKetChuyen.Year.ToString();
                    string thangkt = hienthi[i].NgayKetChuyen.Month.ToString();

                    if (namkt == nam && thangkt == thang)
                    {
                        if (hienthi[i].TrangThai == false)
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
                        id = hienthi[i].SoDuSoQuyID.ToString();
                        sq[sotang] = hienthi[i];
                        sotang++;
                        break;
                    }
                    else
                    {
                        lbtrangthai.Text = "Kỳ này chưa đóng";
                        lbtrangthai.ForeColor = Color.Black;
                        tsslthuchien.Enabled = true;
                    }

                }
                if (sotang != 0)
                {
                    hienthi = new Entities.SoDuSoQuy[sotang];
                    for (int i = 0; i < sotang; i++)
                    {
                        hienthi[i] = sq[i];
                    }

                }
                else
                    hienthi = null;
            }
            catch
            {
            }
        }

        private void tssltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
        }

        private void tsslthuchien_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                string monthhientai = datesv.Month.ToString();
                string namhientai = datesv.Year.ToString();

                if (hienthi != null)
                {
                    string month = hienthi[0].NgayKetChuyen.Month.ToString();
                    string year = hienthi[0].NgayKetChuyen.Year.ToString();
                    if (month == monthhientai && year == namhientai)
                    {
                        frmSoquy a = new frmSoquy(year, month);
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        if (int.Parse(month) == 12)
                        {
                            month = "1";
                            year = (int.Parse(year) + 1).ToString();
                        }
                        else
                        {
                            month = (int.Parse(monthhientai) + 1).ToString();
                        }
                        Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("UpdateTrangThai", int.Parse(id), ProID("SoDuSoQuy"), Convert.ToDateTime(month + "/01/" + year), frmSoquy.a);
                        clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
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
                        if (month == "12" && year == yearkytruoc)
                        {
                            frmSoquy a = new frmSoquy(year, month);
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("UpdateTrangThai", int.Parse(id), ProID("SoDuSoQuy"), Convert.ToDateTime("01/01/" + (int.Parse(yearkytruoc) + 1).ToString()), frmSoquy.a);
                            clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
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
                            return;
                        }
                        if (month == monthkytruoc && year == yearkytruoc)
                        {
                            frmSoquy a = new frmSoquy(year, month);
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("UpdateTrangThai", int.Parse(id), ProID("SoDuSoQuy"), Convert.ToDateTime((int.Parse(monthkytruoc) + 1).ToString() + "/01/" + yearkytruoc), frmSoquy.a);
                            clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
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

                    string month = cbbthang.Text;
                    string year = cbbnam.Text;
                    //if (month == monthhientai && year == namhientai)
                    if (month == monthkytruoc && year == yearkytruoc)
                    {
                        frmSoquy a = new frmSoquy(year, month);
                        string masd = ProID("SoDuSoQuy");
                        cl = new Server_Client.Client();
                        // gán TCPclient
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        // khởi tạo biến truyền vào với hàm khởi tạo
                        Entities.SoDuSoQuy pt1 = new Entities.SoDuSoQuy();
                        pt1 = new Entities.SoDuSoQuy("Insert", masd, "0", Convert.ToDateTime(month + "/01/" + year), frmSoquy.a, false);
                        // khởi tạo mảng đối tượng để hứng giá trị
                        clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt1);
                        // đổ mảng đối tượng vào datagripview       
                        bool kt = false;
                        kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt == true)
                        {
                            SelectData();
                            tsslthuchien_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không phải kỳ hiện tại - không thể kết chuyển", "Hệ thống cảnh báo");
                        return;
                    }
                }
            }
            catch { }
            finally { this.Enabled = true; }
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
                    return "SDSQ_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            nam = cbbnam.Text;
            thang = cbbthang.Text;
            label1.Text = "Kết Chuyển Số Dư Sổ Quỹ Kỳ " + cbbthang.Text + "/" + cbbnam.Text;

            SelectData();
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            nam = cbbnam.Text;
            thang = cbbthang.Text;
            label1.Text = "Kết Chuyển Số Dư Sổ Quỹ Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            SelectData();
        }

        private void frmKetChuyenSoDu_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void frmKetChuyenSoDu_Load(object sender, EventArgs e)
        {
            label1.Text = "Kết Chuyển Số Dư Sổ Quỹ Kỳ " + datesv.Month + "/" + datesv.Year;
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
