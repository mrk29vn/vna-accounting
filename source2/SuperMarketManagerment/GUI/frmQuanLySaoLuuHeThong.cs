using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmQuanLySaoLuuHeThong : Form
    {
        public frmQuanLySaoLuuHeThong()
        {
            InitializeComponent();
        }
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        private void frmQuanLySaoLuuHeThong_Load(object sender, EventArgs e)
        {
            LayDL();
        }
        Entities.SaoLuuHeThong[] slht;
        void LayDL()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                //truyền giá trị lên server
                clientstrem = cl.SerializeObj(this.client1, "LayBackUp", null);
                // đổ mảng đối tượng vào datagripview       
                slht = (Entities.SaoLuuHeThong[])cl.DeserializeHepper1(clientstrem, null);
                if (slht != null)
                {
                    if (slht.Length > 0)
                    {
                        dgvHienThi.DataSource = slht;
                    }
                }
                else
                {
                    slht = new Entities.SaoLuuHeThong[0];
                    dgvHienThi.DataSource = slht;
                }
                fix();
            }
            catch
            {
                dgvHienThi.DataSource = new Entities.SaoLuuHeThong[0];
                fix();
            }
            
            dgvHienThi.Refresh();
        }

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                { }
            }
        }

        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHienThi.SelectedRows.Count > 0)
                {
                    DataGridViewRow item = dgvHienThi.SelectedRows[0];
                    Entities.SaoLuuHeThong slht1 = (Entities.SaoLuuHeThong)item.DataBoundItem;
                    System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn muốn phục hồi từ file " + slht1.Name + " hay tìm trên máy... ?\r\nYES: phục hồi từ file " + slht1.Name + "\r\nNO: Tìm file phục hồi trên máy\r\nCancel: Thoát", "Hệ Thống Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    {
                        if (giatri == System.Windows.Forms.DialogResult.Yes)
                        {//Phục hồi từ file
                            slht1.TenDangNhap = Common.Utilities.User.TenDangNhap;
                            slht1.MaNhanVien = Common.Utilities.User.NhanVienID;
                            if (!Restore(slht1))
                                MessageBox.Show("Restore Thất Bại, hãy kiểm tra lại database");
                            else
                                MessageBox.Show("Restore thành công lại thời gian ngày: " + slht1.ThoiGian);

                        }
                        else if (giatri == System.Windows.Forms.DialogResult.No)
                        {//Phục hồi từ file trên máy
                            OpenFileDialog o = new OpenFileDialog();
                            o.Filter = "Tệp tin sao lưu|*.bak";
                            o.Title = "Chọn tệp tin cần phục hồi...";
                            if (o.ShowDialog() == DialogResult.OK)
                            {
                                bool kq = new BizLogic.SaoLuuHeThong().Restore(o.FileName);
                                if (!kq)
                                    MessageBox.Show("Restore Thất Bại, hãy kiểm tra lại file");
                                else
                                    MessageBox.Show("Restore thành công!");
                            }
                        }
                        else if (giatri == System.Windows.Forms.DialogResult.Cancel)
                        {//Thoát
                            return;
                        }
                    }
                }
                else if (dgvHienThi.SelectedRows.Count == 0)
                {
                    System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn muốn phục hồi từ file không?", "Hệ Thống Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    {
                        if (giatri == System.Windows.Forms.DialogResult.Yes)
                        {
                            OpenFileDialog o = new OpenFileDialog();
                            o.Filter = "Tệp tin sao lưu|*.bak";
                            o.Title = "Chọn tệp tin cần phục hồi...";
                            if (o.ShowDialog() == DialogResult.OK)
                            {
                                bool kq = new BizLogic.SaoLuuHeThong().Restore(o.FileName);
                                if (!kq)
                                    MessageBox.Show("Restore Thất Bại, hãy kiểm tra lại file");
                                else
                                    MessageBox.Show("Restore thành công!");
                            }
                        }
                        else if (giatri == System.Windows.Forms.DialogResult.No)
                        {
                            
                        }
                    }
                }
            }
            catch { }

        }
        public bool Restore(Entities.SaoLuuHeThong slht1)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                //truyền giá trị lên server
                clientstrem = cl.SerializeObj(this.client1, "Restore", slht1);
                //lấy giá trị về
                bool tv = (bool)cl.DeserializeHepper(clientstrem, null);
                return tv;
            }
            catch { return false; }
        }
        void fix()
        {
            dgvHienThi.Columns["Name"].HeaderText = "Tên";
            dgvHienThi.Columns["ThoiGian"].HeaderText = "Ngày Back Up";
            dgvHienThi.Columns["DungLuong"].HeaderText = "Dung Lượng File";
        }

        private void rdoTatca_CheckedChanged(object sender, EventArgs e)
        {
            LayDL();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbNgay.Checked)
            {
                ArrayList arr = new ArrayList();
                foreach (Entities.SaoLuuHeThong item in slht)
                {
                    if (item.ThoiGian.IndexOf(txtTimkiem.Text) != -1)
                    {
                        arr.Add(item);
                    }
                }
                if (arr.Count > 0)
                    dgvHienThi.DataSource = arr;
                else
                    dgvHienThi.DataSource = new Entities.SaoLuuHeThong[0];
                fix();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.Filter = "Tệp tin sao lưu|*.bak";
            o.DefaultExt = "bak";
            o.Title = "Chọn nơi lưu tệp tin...";
            if (o.ShowDialog() == DialogResult.OK)
            {
                new BizLogic.SaoLuuHeThong().BackUp(o.FileName);
            }
        }
    }
}
