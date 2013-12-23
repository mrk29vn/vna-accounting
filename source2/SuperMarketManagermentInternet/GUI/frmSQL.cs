using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entities;
using Server_Client;

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
        private void Save()
        {
            try
            {
                Common.Utilities com = new Common.Utilities();
                string links = Application.StartupPath + @"\Config.xml";
                com.DeleteFile(links);
                if (com.CheckFile(links) == false)
                {
                    Boolean trave = com.Save(txtServerName.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtDatabaseName.Text);
                    if (trave)
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
                Hide();
                frmDangKy fr = new frmDangKy();
                fr.Show();
            }
            else
            {
                Hide();
                frmDangNhap fr = new frmDangNhap();
                fr.Show();
            }
        }

        void SelectServerName()
        {
            try
            {
                txtServerName.Items.Clear();
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable table = instance.GetDataSources();

                foreach (DataRow row in table.Rows)
                {
                    SqlServerList sqlSl = new SqlServerList { ServerName = row[0].ToString(), InstanceName = row[1].ToString() };
                    string sqlName;
                    if (string.IsNullOrEmpty(sqlSl.InstanceName))
                        sqlName = sqlSl.ServerName;
                    else
                        sqlName = sqlSl.ServerName + "\\" + sqlSl.InstanceName;
                    txtServerName.Items.Add(sqlName);
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
                    conect.ConnectionString = _connectionString;
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
                            _connectionString = "Data Source=" + sql.ServerName
                                + ";User ID=" + sql.UserName
                                + ";password=" + sql.Password
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
                        { MessageBox.Show("Kiểm tra lại file xml"); }


                    }
                }
            }
            catch
            { }
        }

        static public bool TestConnString(string connectionString)
        {
            bool returnVal;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    returnVal = conn.State == ConnectionState.Open;
                }
                catch (Exception)
                {
                    returnVal = false;
                }
            }

            return returnVal;
        }

        private Boolean CheckServerName(string serverName)
        {
            Boolean check = false;
            _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
            try
            {
                SqlConnection conect = new SqlConnection { ConnectionString = _connectionString };
                conect.Open();
                const string sel = "SELECT name from sys.servers";
                SqlCommand cmd = new SqlCommand(sel, conect) { CommandType = CommandType.Text };
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (!read["name"].ToString().Equals(serverName)) continue;
                    check = true;
                    break;
                }
                read.Close();
                conect.Close();
            }
            catch (Exception)
            {
                check = false;
            }
            check = check || TestConnString(_connectionString);
            return check;
        }

        private string _connectionString;
        private Boolean CheckDatabase(string databaseName)
        {
            Boolean check = false;
            SqlConnection conect = new SqlConnection();
            try
            {
                //ConnectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
                conect.ConnectionString = _connectionString;
                conect.Open();
                const string sel = "SELECT name FROM sys.databases";
                SqlCommand cmd = new SqlCommand(sel, conect) { CommandType = CommandType.Text };
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (!read["name"].ToString().Equals(databaseName)) continue;
                    check = true;
                    break;
                }
                read.Close();
                conect.Close();
            }
            catch (Exception)
            {
                check = false;
            }
            return check;
        }

        private int AttachDatabase(string links, string links2)
        {
            int check;
            SqlConnection conect = new SqlConnection();
            try
            {
                _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
                conect.ConnectionString = _connectionString;
                conect.Open();
                String sel = null;
                string selectDatabase = "CREATE DATABASE SupermarketManagementDHT ON ( FILENAME = '" + links + "' ),( FILENAME = '" + links2 + "' ) FOR ATTACH;";
                sel = selectDatabase;
                SqlCommand cmd = new SqlCommand(sel, conect) { CommandType = CommandType.Text };
                check = cmd.ExecuteNonQuery();
                conect.Close();
            }
            catch (Exception)
            {
                check = 0;
            }
            return check;
        }

        private Boolean KiemTra2()
        {
            Boolean kt = false;
            try
            {
                _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
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
                _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";

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
                        //txtServerName.Text = "";
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
            catch (Exception)
            {
                kt = false;
            }
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
                _connectionString = "Data Source=" + txtServerName.SelectedItem.ToString() + ";"
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
                    _connectionString = "Data Source=" + txtServerName.Text + ";"
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
            _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
            //SelectDatabase();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
            //SelectDatabase();
        }

        private void txtDatabaseName_Click(object sender, EventArgs e)
        {
            _connectionString = "Data Source=" + txtServerName.Text.ToUpper() + ";User ID=" + txtTenDangNhap.Text + ";password=" + txtMatKhau.Text + ";Initial Catalog=master";
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
