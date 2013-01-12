using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Common;
using Entities;
using System.Xml;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Server_Client;
using System.Data.SqlClient;
using System.Net;
using Microsoft.SqlServer;
using Microsoft.Win32;
using System.Data.Sql;
using System.Collections;

namespace GUI
{
    public partial class frmSQL : Form
    {
        public frmSQL()
        {
            InitializeComponent();
            CheckRdo();
        }

        /// <summary>
        /// luu vao xml
        /// </summary>
        /// <param name="kiemtra"></param>
        /// <param name="Links"></param>
        private void Save()
        {
            try
            {
                Common.Utilities com = new Common.Utilities();
                string Links = Application.StartupPath.ToString() + @"\Config.xml";
                com.DeleteFile(Links);
                if (com.CheckFile(Links) == false)
                {
                    Boolean trave = com.Save(txtServerName.Text.ToString(), txtTenDangNhap.Text, txtMatKhau.Text, txtDatabaseName.Text.ToString());
                    if (trave == true)
                    {
                        loginOK();
                    }
                    else
                    { MessageBox.Show("Chưa lưu lại"); }
                }
                else
                {
                    loginOK();
                }
            }
            catch
            {
            
            }
        }

        private void loginOK()
        {
            if (!(new TienIch().checkFULL()))
            {
                this.Hide();
                frmDangKy fr = new frmDangKy();
                fr.Show();
            }
            else
            {
                this.Hide();
                frmDangNhap fr = new frmDangNhap();
                fr.Show();
            }
        }

        void SelectServerName()
        {
            try
            {
                string sqlName = string.Empty;
                this.txtServerName.Items.Clear();
                SqlServerList SqlSL = new SqlServerList();
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable table = instance.GetDataSources();

                foreach (DataRow row in table.Rows)
                {
                    SqlSL = new SqlServerList();
                    SqlSL.ServerName = row[0].ToString();
                    SqlSL.InstanceName = row[1].ToString();
                    if (string.IsNullOrEmpty(SqlSL.InstanceName))
                        sqlName = SqlSL.ServerName;
                    else
                        sqlName = SqlSL.ServerName + "\\" + SqlSL.InstanceName;
                    this.txtServerName.Items.Add(sqlName);

                }


            }

            catch
            {

            }
        }

        private void SelectDatabase()
        {
            if (txtServerName.Text.Equals(""))
            {
                txtDatabaseName.Items.Clear();
                return;
            }
            else
            {
                SqlDataReader read = null;
                SqlConnection conect = new SqlConnection();
                try
                {
                    txtDatabaseName.Items.Clear();
                    //conect.ConnectionString = Common.Constants.GiaTriCacForm.ConnectionString;
                    conect.ConnectionString = ConnectionString;
                    conect.Open();
                    SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases", conect);
                    cmd.CommandType = CommandType.Text;
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        txtDatabaseName.Items.Add(read["name"].ToString());
                    }
                    read.Close();
                    conect.Close();
                }
                catch
                { }
            }
        }

        /// <summary>
        /// chay dau tien
        /// </summary>
        private int i = 0;
        private void frmSQL_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (i == 0)
                {
                    i = 1;
                    
                    if (Luu.Server == "server")
                    {
                        Common.Constants.Sql data = new Common.Constants.Sql();
                        string Links = Application.StartupPath.ToString() + data.ConfigXML;
                        Common.Utilities com = new Common.Utilities();
                        if (com.CheckFile(Links) == true)
                        {
                            Entities.SQL sql = new SQL();
                            sql = com.ConnectionsName();
                            ConnectionString = "Data Source=" + sql.ServerName
                                + ";User ID=" + sql.UserName
                                + ";password=" +sql.Password 
                                + ";Initial Catalog=" + sql.DatabaseName;

                            if (CheckDatabase("SupermarketManagementDHT") == true)
                            {
                                if (!Luu.KFULL)
                                {
                                    loginOK();
                                }
                            }
                            else
                            {
                                SelectServerName();
                            }
                        }
                        else
                        { SelectServerName(); }
                    }
                    else
                    {

                        if (Luu.Server == "client")
                        {
                            loginOK();
                        }
                        else
                        {MessageBox.Show("Kiểm tra lại file xml"); }


                    }
                }
            }
            catch
            { }
        }

        private Boolean CheckServerName(string ServerName)
        {
            Boolean check = false;
            SqlDataReader read = null;
            SqlConnection conect = new SqlConnection();
            Common.Constants.Sql q = new Common.Constants.Sql();
            try
            {
                ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
                //ConnectionString = @"Data Source=.;Initial Catalog=master;Integrated Security=True;";
                conect.ConnectionString = ConnectionString;
                conect.Open();
                String sel = null;
                sel = "SELECT name from sys.servers";
                SqlCommand cmd = new SqlCommand(sel, conect);
                cmd.CommandType = CommandType.Text;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read["name"].ToString() == ServerName)
                    {
                        check = true;
                        break;
                    }
                    else
                    { continue; }
                }
                read.Close();
                conect.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); check = false; }
            return check;
        }

        private string ConnectionString;
        private Boolean CheckDatabase(string DatabaseName)
        {
            Boolean check = false;
            SqlDataReader read = null;
            SqlConnection conect = new SqlConnection();
            try
            {
                //System.Net.IPHostEntry ip = new IPHostEntry();
                //string HostName = System.Net.Dns.GetHostName();
                //this.ConnectionString = "Data Source=" + HostName.ToUpper() + ";Initial Catalog=master;Integrated Security=True;";
                //ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
                conect.ConnectionString = ConnectionString;
                conect.Open();
                String sel = null;
                string selectDatabase = "SELECT name FROM sys.databases";
                sel = selectDatabase;
                SqlCommand cmd = new SqlCommand(sel, conect);
                cmd.CommandType = CommandType.Text;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read["name"].ToString() == DatabaseName)
                    {
                        check = true;
                        break;
                    }
                    else
                    { continue; }
                }
                read.Close();
                conect.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); check = false; }
            return check;
        }

        private int AttachDatabase(string links, string links2)
        {
            int check = 0;
            SqlConnection conect = new SqlConnection();
            try
            {
                ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
                conect.ConnectionString = ConnectionString;
                conect.Open();
                String sel = null;
                string selectDatabase = "CREATE DATABASE SupermarketManagementDHT ON ( FILENAME = '" + links + "' ),( FILENAME = '" + links2 + "' ) FOR ATTACH;";
                sel = selectDatabase;
                SqlCommand cmd = new SqlCommand(sel, conect);
                cmd.CommandType = CommandType.Text;
                check = cmd.ExecuteNonQuery();
                conect.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); check = 0; }
            return check;
        }

        private Boolean KiemTra2()
        {
            Boolean kt = false;
            try
            {
                ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
                if (CheckServerName(txtServerName.Text.ToUpper()) == false)
                {
                    MessageBox.Show("Kiểm tra lại tên server hoặc tên đăng nhập hoặc mật khẩu");
                    kt = false;
                }
                else
                {
                    kt = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; kt = false; }
            return kt;
        }

        private Boolean KiemTra()
        {
            Boolean kt = false;
            try
            {
                ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";

                if (CheckDatabase(txtDatabaseName.Text) == false)
                {
                    string links = Application.StartupPath.ToString() + @"\SupermarketManagementDHT.mdf";
                    string links2 = Application.StartupPath.ToString() + @"\SupermarketManagementDHT_log.ldf";
                    if (CheckFile(links, links2) == true)
                    {
                        if (AttachDatabase(links, links2) != 0)
                        { 
                            kt = true;
                            txtDatabaseName.Text = "SupermarketManagementDHT";
                        }
                        else
                        { txtDatabaseName.Text = ""; kt = false; }
                    }
                    else
                    {
                        openFile.Filter = "MDF (*.mdf)|*.mdf";
                        if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            links = openFile.FileName.ToString();
                            int i = openFile.FileName.ToString().IndexOf("SupermarketManagementDHT.mdf");
                            links2 = openFile.FileName.ToString().Substring(0, i);
                            links2 = links2 + "SupermarketManagementDHT_log.ldf";
                            if (AttachDatabase(links, links2) != 0)
                            {
                                kt = true;
                                txtDatabaseName.Text = "SupermarketManagementDHT";
                            }
                            else
                            { txtDatabaseName.Text = ""; kt = false; }
                        }
                    }
                }
                else
                {
                    if (CheckServerName(txtServerName.Text.ToUpper()) == false)
                    {
                        txtServerName.Text = "";
                        MessageBox.Show("Tên server không đúng");
                        txtServerName.Focus();
                        kt = false;
                    }
                    else
                    {
                        kt = true;
                    }
                }
                
            }
            catch (Exception ex)
            { string s = ex.Message; kt = false; }
            return kt;
        }

        private Boolean CheckFile(string links, string links2)
        {
            try
            {
                if (System.IO.File.Exists(links) == true && System.IO.File.Exists(links2) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                return false;
            }
        }
        /// <summary>
        /// lưu lại file xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (txtServerName.Text == "")
            { txtServerName.Focus(); return; }
            if (txtDatabaseName.Text == "")
            { txtDatabaseName.Focus(); return; }
            if (txtTenDangNhap.Text == "")
            { txtTenDangNhap.Focus(); return; }
            if (txtMatKhau.Text == "")
            { txtMatKhau.Focus(); return; }
            if (radioButton2.Checked)
            {//Attack cơ sở dữ liệu
                if (textBox1.Text.Equals(""))
                {
                    return;
                }
                else
                {
                    if (KiemTra2())
                    {
                        Save();
                    }
                    else
                    { MessageBox.Show("Thất bại"); return; }
                }
            }
            else
            {//Không attack cơ sở dữ liệu
                if (KiemTra())
                {
                    Save();
                }
                else
                { MessageBox.Show("Thất bại"); return; }
            }
            
        }

        /// <summary>
        /// thoat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn muốn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    Server server = new Server(Luu.Ports);
                        Application.Exit();
                }
                else
                { }
            }
        }

        private void txtServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ConnectionString = "Data Source=" + txtServerName.SelectedItem.ToString() + ";"
                                    + "Initial Catalog=master;Integrated Security = SSPI;";
                SelectDatabase();
            }
            catch
            {
            }
        }

        private void txtServerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    ConnectionString = "Data Source=" + txtServerName.Text + ";"
                                        + "Initial Catalog=master;Integrated Security = SSPI;";
                    SelectDatabase();
                }
                catch
                {
                }
            }
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
            //SelectDatabase();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
            //SelectDatabase();
        }

        private void txtDatabaseName_Click(object sender, EventArgs e)
        {
            ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
            SelectDatabase();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CheckRdo();
        }

        private void CheckRdo()
        {
            if (radioButton1.Checked)
            {
                txtDatabaseName.Enabled = true;
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                txtDatabaseName.Enabled = false;
                button1.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CheckRdo();
        }

        private int DinhKemCSDL(string links, string links2)
        {
            int kq = 0;
            //AttachDbFilename='" + links + "';
            string strcon = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Integrated Security=True;User Instance=false";
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                con.Open();
                string sql = "BEGIN TRY"
                                      + " CREATE DATABASE [SupermarketManagementDHT] ON "
                                      + " ( FILENAME = N'" + links + "' ),"
                                      + " ( FILENAME = N'" + links2 + "' )"
                                      + " FOR ATTACH"
                                      + " END TRY"
                                      + " BEGIN CATCH"
                                      + " EXEC master.dbo.sp_detach_db @dbname = N'SupermarketManagementDHT'"
                    //+ @" EXEC master.dbo.sp_detach_db @dbname = N'C:\DATABASE\SUPERMARKETMANAGEMENTDHT.MDF'"
                                      + " CREATE DATABASE [SupermarketManagementDHT] ON "
                                      + @" ( FILENAME = N'" + links + "' ),"
                                      + @" ( FILENAME = N'" + links2 + "' )"
                                      + " FOR ATTACH"
                                      + " END CATCH";
                                      //+ " GO;";
                kq = new SqlCommand(sql, con).ExecuteNonQuery();
                con.Dispose();
                con.Close(); 
            }
            catch
            {
                kq = 0; 
                con.Dispose();
                con.Close();
            }
            return kq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra2())
                {
                    openFile.Filter = "MDF (*.mdf)|*.mdf";
                    if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string links = openFile.FileName.ToString();
                        int i = openFile.FileName.ToString().IndexOf("SupermarketManagementDHT.mdf");
                        string links2 = openFile.FileName.ToString().Substring(0, i);
                        ////////////////////////////////////////////MRK ADD
                        System.IO.StreamWriter ghifile = new System.IO.StreamWriter(Application.StartupPath + "\\patch" + ".k29vn");
                        ghifile.WriteLine(links2);
                        ghifile.Close();
                        ghifile.Dispose();
                        ///////////////////////////////////////////////////
                        links2 = links2 + "SupermarketManagementDHT_log.ldf";
                        int iTEM = DinhKemCSDL(links, links2);
                        if (iTEM != 0 && iTEM != -1)
                        {
                            //CSDL chưa có sẵn database
                            txtDatabaseName.Text = "SupermarketManagementDHT";
                            textBox1.Text = links;
                            MessageBox.Show("Attack Thành Công!", "Hệ thống thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (iTEM == -1)
                        {
                            //CSDL đã có sẵn --> thay đổi đường dẫn
                            txtDatabaseName.Text = "SupermarketManagementDHT";
                            textBox1.Text = links;
                            MessageBox.Show("Attack Thành Công!", "Hệ thống thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        { txtDatabaseName.Text = ""; }
                    }
                }
            }
            catch { }
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
    [Serializable]
    class SqlServerList : IComparable, ICloneable
    {
        public SqlServerList()
        {
            ServerName = string.Empty;
            InstanceName = string.Empty;
            IsClustered = string.Empty;
            Version = string.Empty;
        }

        #region ICloneable Members
        public object Clone()
        {
            try
            {
                if (this == null)
                {
                    return null;
                }
                SqlServerList SqlSL = new SqlServerList { ServerName = ServerName, InstanceName = InstanceName, IsClustered = IsClustered, Version = Version };
                return SqlSL;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region IComparable Members
        public int CompareTo(object obj)
        {
            try
            {
                if (!(obj is SqlServerList))
                {
                    throw new Exception("obj is not an instance of SqlServerList");
                }
                if (this == null)
                {
                    return -1;
                }
                return ServerName.CompareTo((obj as SqlServerList).ServerName);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string IsClustered { get; set; }
        public string Version { get; set; }
    }
}
