using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmServerConfig : Form
    {
        public frmServerConfig()
        {
            InitializeComponent();
            txtPort.Text = DateTime.Now.Year.ToString();
        }

        private void Save()
        {
            try
            {
                Entities.ServerConfig con = new Entities.ServerConfig();
                con.Server = cbxLoaiMay.SelectedItem.ToString();
                con.Ip = txtIP.Text;
                con.Port = txtPort.Text;
                Common.Utilities com = new Common.Utilities();
                com.CreateFileServerConfig(con);
            }
            catch (Exception ex)
            { string s = ex.Message; this.Close(); }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                this.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbxLoaiMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxLoaiMay.SelectedItem.ToString() == "server")
                {
                    txtIP.ReadOnly = true;
                }
                else
                {
                    txtIP.ReadOnly = false;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

    }
}
