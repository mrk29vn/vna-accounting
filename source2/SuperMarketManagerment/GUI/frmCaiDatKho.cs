using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmCaiDatKho : Form
    {
        public frmCaiDatKho()
        {
            InitializeComponent();
        }
        #region hungvv========================================================================================
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        ///  Lấy Kho Hàng
        /// </summary>
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        private void LayKhoHang()
        {
            try
            {
                cbxMaKho.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "KhoHang", "MaKho", "TenKho");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    Common.Utilities com = new Common.Utilities();
                    com.BindingCombobox(ddh, cbxMaKho, "giatri", "khoachinh");
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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
        /// <summary>
        /// lay thong tin các kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCaiDatKho_Load(object sender, EventArgs e)
        {
            try
            {
                LayKhoHang();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// them moi hoac sua lai cai dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 4))
                { return; }

                if (cbxMaKho.SelectedValue != null)
                {
                    Common.Utilities pro = new Common.Utilities();
                    Entities.TruyenGiaTri tra = pro.CaiDatKho("XuLy", cbxMaKho.SelectedValue.ToString(), cbxMaKho.Text.ToString());
                    this.Close();
                }
                else
                { 
                    Common.Utilities pro = new Common.Utilities();
                    Entities.TruyenGiaTri tra = pro.CaiDatKho("XuLy", "NULL", "NULL");
                    this.Close();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// lay gia tri kho dc cai dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 1))
                { return; }
                Common.Utilities pro = new Common.Utilities();
                Entities.TruyenGiaTri tra = pro.CaiDatKho("View","","");
                if (tra != null)
                {
                    MessageBox.Show("Đang cài đặt với tên kho: " + tra.Giatrithuhai + "(" + tra.Giatritruyen + ")");
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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

        #endregion
    }
}
