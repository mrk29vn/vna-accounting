using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace kRunSql
{
    public partial class FrmRunSql : Form
    {
        private const string KeyOfEnDecode = "SupermarketManagement";

        public FrmRunSql()
        {
            InitializeComponent();
        }

        #region Event
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            string strcon;
            if (GetStrConnect(out strcon)) return;
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                }
                MessageBox.Show("Kết nối thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại!");
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void btnLoadDhtConfig_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                string file = openFileDialog.FileName;
                var doc = XDocument.Load(file);
                txtServerName.Text = Utils.GiaiMa(KeyOfEnDecode, GetValueOfXelement(doc, "DataSource"));
                txtUser.Text = Utils.GiaiMa(KeyOfEnDecode, GetValueOfXelement(doc, "UserID"));
                txtPass.Text = Utils.GiaiMa(KeyOfEnDecode, GetValueOfXelement(doc, "Password"));
                txtCsdlName.Text = Utils.GiaiMa(KeyOfEnDecode, GetValueOfXelement(doc, "InitialCatalog"));
            }
            catch
            {
                //
            }
        }

        private void btnSaveDhtConfig_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { FileName = "Config", DefaultExt = "xml" };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                string serverName = Utils.MaHoa(KeyOfEnDecode, txtServerName.Text);
                string use = Utils.MaHoa(KeyOfEnDecode, txtUser.Text);
                string pass = Utils.MaHoa(KeyOfEnDecode, txtPass.Text);
                string csdlName = Utils.MaHoa(KeyOfEnDecode, txtCsdlName.Text);
                XDocument doc = new XDocument(new XElement("Connect",
                                                           new XElement("DataSource", serverName),
                                                           new XElement("UserID", use),
                                                           new XElement("Password", pass),
                                                           new XElement("InitialCatalog", csdlName)
                                                           )
                                              );
                doc.Save(saveFileDialog.FileName);
            }
            catch
            {
                //
            }
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "SQL File (*.sql)|*.sql" };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            txtSql.Text = new FileInfo(openFileDialog.FileName).OpenText().ReadToEnd();
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            string strcon;
            if (GetStrConnect(out strcon)) return;
            string strSql = txtSql.Text;
            ExecuteScript(strcon, strSql);
        }
        #endregion

        #region Utils
        private bool GetStrConnect(out string strcon)
        {
            string serverName = txtServerName.Text;
            string use = txtUser.Text;
            string pass = txtPass.Text;
            string csdlName = txtCsdlName.Text;

            if (string.IsNullOrEmpty(serverName))
            {
                MessageBox.Show("tên máy chủ không được để trống");
                txtServerName.Focus();
                strcon = string.Empty;
                return true;
            }
            if (string.IsNullOrEmpty(use))
            {
                MessageBox.Show("tên tài khoản không được để trống");
                txtUser.Focus();
                strcon = string.Empty;
                return true;
            }
            if (string.IsNullOrEmpty(csdlName))
            {
                MessageBox.Show("tên CSDL không được để trống");
                txtCsdlName.Focus();
                strcon = string.Empty;
                return true;
            }

            //string strServerInternet =
            //    "workstation id={0};packet size=4096;user id={1};pwd={2};data source={0};persist security info=False;initial catalog={3}";
            const string strServerLocal = "Data Source={0};User ID={1};password={2};Initial Catalog={3}";
            strcon = string.Format(strServerLocal, serverName, use, pass, csdlName);
            return false;
        }

        private static string GetValueOfXelement(XContainer doc, string keyOfNode)
        {
            XElement xElement = doc.Descendants(keyOfNode).SingleOrDefault();
            return (xElement != null) ? xElement.Value : string.Empty;
        }

        protected virtual void ExecuteScript(string strCon, string script)
        {
            SqlConnection connection = new SqlConnection(strCon);
            try
            {
                connection.Open();

                string[] commandTextArray = System.Text.RegularExpressions.Regex.Split(script, "\r\n[\t ]*GO");

                SqlCommand cmd = new SqlCommand(String.Empty, connection);

                foreach (string commandText in commandTextArray.Where(commandText => commandText.Trim() != string.Empty))
                {
                    if ((commandText.Length >= 3) && (commandText.Substring(0, 3).ToUpper() == "USE"))
                    {
                        throw new Exception("Đoạn mã của bạn có chứa USE. Bạn cần trỏ tới một cơ sở dữ liệu cụ thể vui lòng chọn tab bên trái");
                    }

                    cmd.CommandText = commandText;
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đã chạy hoàn tất!", "Thông báo");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo");
            }
            finally
            {
                connection.Close();
            }

        }
        #endregion
    }
}
