using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;
using System.Collections;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Common
{
    public class Utilities
    {
        public static Entities.ChiTietQuyen[] CTQ = null;
        public static Entities.TaiKhoan User = null;
        private Common.Constants.Sql constants;
        public Utilities()
        {
            constants = new Common.Constants.Sql();
        }


        #region function (đọc 2 file config .xml  <ko phan su mien vao> )==============================================================================
        /// <summary>
        /// lay chuoi ket noi tu file xml
        /// </summary>
        /// <returns></returns>
        public SQL ConnectionsName()
        {
            SQL sql = new SQL();
            string Links = Application.StartupPath.ToString() + constants.ConfigXML;
            try
            {
                XmlDocument doc = new XmlDocument();
                if (CheckFile(Links) == true)
                {
                    doc.Load(Links);
                    XmlElement root = doc.DocumentElement;
                    sql.ServerName = GiaiMa(constants.KeywordConfigXML, root.ChildNodes[0].InnerText);
                    sql.UserName = GiaiMa(constants.KeywordConfigXML, root.ChildNodes[1].InnerText);
                    sql.Password = GiaiMa(constants.KeywordConfigXML, root.ChildNodes[2].InnerText);
                    sql.DatabaseName = GiaiMa(constants.KeywordConfigXML, root.ChildNodes[3].InnerText);
                }
                else
                {
                    CreateFile(1, Links);
                    sql = null;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                DeleteFile(Links);
                sql = null;
            }
            return sql;
        }
        /// <summary>
        /// cai dat kho
        /// </summary>
        /// <returns></returns>
        public TruyenGiaTri CaiDatKho(string hanhdong, string ma, string ten)
        {
            Common.Constants.Sql get = new Common.Constants.Sql();
            Entities.TruyenGiaTri giatri = new Entities.TruyenGiaTri();
            string Links = Application.StartupPath.ToString() + get.tenfile;
            try
            {
                XmlDocument doc = new XmlDocument();
                if (CheckFile(Links) == true)
                {
                    if (hanhdong == "View")
                    {
                        doc.Load(Links);
                        XmlElement root = doc.DocumentElement;
                        giatri.Giatritruyen = GiaiMa(get.setup, root.ChildNodes[0].InnerText);
                        giatri.Giatrithuhai = GiaiMa(get.setup, root.ChildNodes[1].InnerText);
                    }
                    if (hanhdong == "XuLy")
                    {
                        XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                        txtwrite.WriteStartDocument();
                        txtwrite.WriteStartElement(constants.Connect);
                        txtwrite.WriteElementString("MaKho", MaHoa(get.setup, ma));
                        txtwrite.WriteElementString("TenKho", MaHoa(get.setup, ten));
                        txtwrite.WriteEndElement();
                        txtwrite.WriteEndDocument();
                        txtwrite.Close();
                        giatri.Hanhdong = "Đã lưu lại";
                    }
                }
                else
                {
                    if (hanhdong == "XuLy")
                    {
                        XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                        txtwrite.WriteStartDocument();
                        txtwrite.WriteStartElement(constants.Connect);
                        txtwrite.WriteElementString("MaKho", MaHoa(get.setup, ma));
                        txtwrite.WriteElementString("TenKho", MaHoa(get.setup, ten));
                        txtwrite.WriteEndElement();
                        txtwrite.WriteEndDocument();
                        txtwrite.Close();
                        giatri.Hanhdong = "Đã lưu lại";
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                DeleteFile(Links);
                giatri.Hanhdong = "Đã xóa";
            }
            return giatri;
        }
        public bool CaiDatTrial()
        {
            try
            {
                //XmlDocument doc = new XmlDocument();
                //Common.Constants.Sql get = new Common.Constants.Sql();
                //string Links = Application.StartupPath.ToString() + "\\abc.xml";
                //if (!CheckFile(Links))
                //{
                //    XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                //    txtwrite.WriteStartDocument();
                //    txtwrite.WriteStartElement(constants.Connect);
                //    txtwrite.WriteElementString("abc", MaHoa(get.setup, DateTime.Now.DayOfYear.ToString()));
                //    txtwrite.WriteElementString("cba", MaHoa(get.setup, (DateTime.Now.DayOfYear + 15).ToString()));
                //    txtwrite.WriteEndElement();
                //    txtwrite.WriteEndDocument();
                //    txtwrite.Close();
                //}
                //else
                //{
                //    doc.Load(Links);
                //    XmlElement root = doc.DocumentElement;
                //    int batdau = int.Parse(GiaiMa(get.setup, root.ChildNodes[0].InnerText));
                //    int ketthuc = int.Parse(GiaiMa(get.setup, root.ChildNodes[1].InnerText));
                //    int hientai = DateTime.Now.DayOfYear;
                //    if (hientai < batdau)
                //    {
                //        MessageBox.Show("Bạn không nên thay đổi thời gian hệ thống");
                //        Application.Exit();
                //    }
                //    if (hientai > ketthuc)
                //    {
                //        MessageBox.Show("Hết hạn dùng thử phần mềm - xin hãy liên hệ để gia thêm hạn");
                //        Application.Exit();
                //    }
                //    if (hientai > batdau)
                //    {
                //        XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                //        txtwrite.WriteStartDocument();
                //        txtwrite.WriteStartElement(constants.Connect);
                //        txtwrite.WriteElementString("abc", MaHoa(get.setup, DateTime.Now.DayOfYear.ToString()));
                //        txtwrite.WriteElementString("cba", MaHoa(get.setup, ketthuc.ToString()));
                //        txtwrite.WriteEndElement();
                //        txtwrite.WriteEndDocument();
                //        txtwrite.Close();
                //    }
                //}
                return true;
            }
            catch
            {
                return true;
            }
            return true;
        }
        /// <summary>
        /// lay kho theo quay file xml
        /// </summary>
        /// <param name="kho"></param>
        public Boolean ComboxKhoHang(ComboBox kho)
        {
            try
            {
                Entities.TruyenGiaTri[] tra = new Entities.TruyenGiaTri[1];
                tra[0] = CaiDatKho("View", "", "");
                if (tra[0].Giatritruyen == "NULL")
                {
                    MessageBox.Show("Chưa cài đặt kho hàng");
                    return false;
                }
                BindingCombobox(tra, kho, "Giatrithuhai", "Giatritruyen");
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// thong tin file config=================vuong hung===============
        /// </summary>
        /// <returns></returns>
        public ServerConfig ReadConfig()
        {
            ServerConfig config = new ServerConfig();
            string Links = Application.StartupPath.ToString() + constants.ServerConfig;
            try
            {
                XmlDocument doc = new XmlDocument();
                if (CheckFile(Links) == true)
                {
                    doc.Load(Links);
                    XmlElement root = doc.DocumentElement;
                    config.Server = GiaiMa(constants.KeywordServerConfig, root.ChildNodes[0].InnerText);
                    config.Ip = GiaiMa(constants.KeywordServerConfig, root.ChildNodes[1].InnerText);
                    config.Port = GiaiMa(constants.KeywordServerConfig, root.ChildNodes[2].InnerText);
                }
                else
                {
                    CreateFile(2, Links);
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                DeleteFile(Links);
                config = null;
            }
            return config;
        }
        #endregion

        #region function (lấy serverName và databaseName <ko phan su mien vao>)================================================================================
        /// <summary>
        /// hungvv ====================lay ten server===============
        /// </summary>
        /// <returns></returns>
        public void getServerName(ComboBox combox)
        {
            SqlDataReader read = null;
            SqlConnection conect = new SqlConnection();
            Common.Constants.Sql q = new Common.Constants.Sql();
            try
            {
                conect.ConnectionString = q.ConnectionString;
                conect.Open();
                String sel = null;
                sel = q.selectServerName;
                SqlCommand cmd = new SqlCommand(sel, conect);
                cmd.CommandType = CommandType.Text;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    combox.Items.Add(read["name"].ToString());
                }
                read.Close();
                conect.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        public void getDataTableName(ComboBox combox)
        {
            SqlDataReader read = null;
            SqlConnection conect = new SqlConnection();
            Common.Constants.Sql q = new Common.Constants.Sql();
            try
            {
                conect.ConnectionString = q.ConnectionString;
                conect.Open();
                String sel = null;
                sel = q.selectDatabase;
                SqlCommand cmd = new SqlCommand(sel, conect);
                cmd.CommandType = CommandType.Text;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    combox.Items.Add(read["name"].ToString());
                }
                read.Close();
                conect.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        #endregion

        #region function (kiểm tra và xóa file)========================================================================================
        /// <summary>
        /// Kiem tra file co ton tai khong
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Boolean CheckFile(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName) == true)
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
        /// xoa file
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            try
            {
                FileInfo fi;
                if (System.IO.File.Exists(fileName) == true)
                {
                    fi = new FileInfo(fileName);
                    fi.Delete();
                }
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }
        #endregion

        #region function (Tạo mới và lưu lại file xml)=======================================================================
        /// <summary>
        /// hungvv ================luu lai file xml config==================
        /// </summary>
        /// <param name="TenServer"></param>
        /// <param name="TenDangNhap"></param>
        /// <param name="MatKhau"></param>
        /// <param name="TenCoSoDuLieu"></param>
        /// <returns></returns>
        public Boolean Save(string TenServer, string TenDangNhap, string MatKhau, string TenCoSoDuLieu)
        {
            Boolean check = false;
            try
            {
                Common.Utilities com = new Common.Utilities();
                string Links = Application.StartupPath.ToString() + @"\Config.xml";
                if (com.CheckFile(Links) == false)
                {
                    XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                    txtwrite.WriteStartDocument();
                    txtwrite.WriteStartElement(constants.Connect);
                    txtwrite.WriteElementString(constants.DataSource, MaHoa(constants.KeywordConfigXML, TenServer));
                    txtwrite.WriteElementString(constants.UserID, MaHoa(constants.KeywordConfigXML, TenDangNhap));
                    txtwrite.WriteElementString(constants.Password, MaHoa(constants.KeywordConfigXML, MatKhau));
                    txtwrite.WriteElementString(constants.InitialCatalog, MaHoa(constants.KeywordConfigXML, TenCoSoDuLieu));
                    txtwrite.WriteEndElement();
                    txtwrite.WriteEndDocument();
                    txtwrite.Close();
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); check = false; }
            return check;
        }
        public void CreateFileServerConfig(Entities.ServerConfig config)
        {
            try
            {
                string Links = System.Windows.Forms.Application.StartupPath.ToString() + new Common.Constants.Sql().ServerConfig;
                if (CheckFile(Links) == true)
                {
                    DeleteFile(Links);
                }
                XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                txtwrite.WriteStartDocument();
                txtwrite.WriteStartElement(constants.Config);
                txtwrite.WriteElementString(constants.Server, MaHoa(constants.KeywordServerConfig, config.Server));
                txtwrite.WriteElementString(constants.IP, MaHoa(constants.KeywordServerConfig, config.Ip));
                txtwrite.WriteElementString(constants.Port, MaHoa(constants.KeywordServerConfig, config.Port));
                txtwrite.WriteEndElement();
                txtwrite.WriteEndDocument();
                txtwrite.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// Tao file moi
        /// </summary>
        public void CreateFile(int kiemtra, string Links)
        {
            try
            {
                if (kiemtra == 1)
                {
                    XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                    txtwrite.WriteStartDocument();
                    txtwrite.WriteStartElement(constants.Connect);
                    txtwrite.WriteElementString(constants.DataSource, MaHoa(constants.KeywordConfigXML, constants.DataSourceValues));
                    txtwrite.WriteElementString(constants.UserID, MaHoa(constants.KeywordConfigXML, constants.UserIDValues));
                    txtwrite.WriteElementString(constants.Password, MaHoa(constants.KeywordConfigXML, constants.PasswordValues));
                    txtwrite.WriteElementString(constants.InitialCatalog, MaHoa(constants.KeywordConfigXML, constants.InitialCatalogValues));
                    txtwrite.WriteEndElement();
                    txtwrite.WriteEndDocument();
                    txtwrite.Close();
                }
                else
                {
                    if (kiemtra == 2)
                    {
                        XmlTextWriter txtwrite = new XmlTextWriter(Links, null);
                        txtwrite.WriteStartDocument();
                        txtwrite.WriteStartElement(constants.Config);
                        txtwrite.WriteElementString(constants.Server, MaHoa(constants.KeywordServerConfig, ""));
                        txtwrite.WriteElementString(constants.IP, MaHoa(constants.KeywordServerConfig, ""));
                        txtwrite.WriteElementString(constants.Port, MaHoa(constants.KeywordServerConfig, ""));
                        txtwrite.WriteEndElement();
                        txtwrite.WriteEndDocument();
                        txtwrite.Close();
                    }
                }

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        #endregion

        #region function (MaHoa và GiaiMa)=========================================================================
        /// <summary>
        /// ma hoa===================hungvv===========
        /// </summary>
        /// <param name="key"></param>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public string MaHoa(string key, string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// giai ma=========hungvv===========================
        /// </summary>
        /// <param name="key"></param>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public string GiaiMa(string key, string toDecrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        #region function (đổ dữ liệu vào combox)==============================================================================
        /// <summary>
        /// hungvv ========================dua gia tri vao combox====================
        /// </summary>
        public void BindingCombobox(object[] tbl, ComboBox box, string columnDisplay, string columnValue)
        {
            try
            {
                box.DataSource = tbl;
                box.DisplayMember = columnDisplay;
                box.ValueMember = columnValue;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        #endregion

        /// <summary>
        /// hungvv =======================tao them cot so thu tu====================================
        /// </summary>
        /// <param name="dgv"></param>
        public void CountDatagridview(DataGridView dgv)
        {
            int stt = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                stt = stt + 1;
                dgv.Rows[i].Cells[0].Value = stt;
            }
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Xử lý chuỗi String tăng giá trị cho các khóa chính
        /// </summary>
        /// <param name="strChuoi"></param>
        /// <returns></returns>
        public string ProcessID(string strChuoi)
        {
            try
            {
                int i = strChuoi.LastIndexOf("_");
                int ID = Convert.ToInt32(strChuoi.Substring(i + 1));
                string IDdau = strChuoi.Substring(0, i);
                ID = ID + 1;
                string IDcuoi = ID.ToString();
                if (IDcuoi.Length == 1) IDcuoi = "000" + IDcuoi;
                else if (IDcuoi.Length == 2) IDcuoi = "00" + IDcuoi;
                else if (IDcuoi.Length == 3) IDcuoi = "0" + IDcuoi;

                return IDdau + "_" + IDcuoi;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #region hungvv================================================================================

        /// <summary>
        /// hungvv ====================================================
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        public string XuLy(int viet, string chuoi)
        {
            //Hàm này của thằng hungvv có tác dụng đổi một chuỗi string ngày tháng năm thành một chuỗi string ngày tháng năm khác theo chuẩn nó đặt ra
            //ví dụ: viet = 1 => string bất kỳ thành dạng MM/dd/yyyy
            //       viet = 2 => string bất kỳ thành dạng dd/MM/yyyy
            //       viet = 3 => string bất kỳ thành dạng ddMMyyyy
            string tralai = "";
            try
            {
                if (viet == 1)
                {
                    string dd = DateTime.Parse(chuoi.ToString()).Day.ToString();
                    if (dd.Length == 1)
                    {
                        dd = "0" + dd;
                    }
                    string mm = DateTime.Parse(chuoi.ToString()).Month.ToString();
                    if (mm.Length == 1)
                    {
                        mm = "0" + mm;
                    }
                    string yyyy = DateTime.Parse(chuoi.ToString()).Year.ToString();
                    tralai = mm + "/" + dd + "/" + yyyy;
                }
                if (viet == 2)
                {
                    string dd = DateTime.Parse(chuoi.ToString()).Day.ToString();
                    if (dd.Length == 1)
                    {
                        dd = "0" + dd;
                    }
                    string mm = DateTime.Parse(chuoi.ToString()).Month.ToString();
                    if (mm.Length == 1)
                    {
                        mm = "0" + mm;
                    }
                    string yyyy = DateTime.Parse(chuoi.ToString()).Year.ToString();
                    tralai = dd + "/" + mm + "/" + yyyy;
                }
                if (viet == 3)
                {
                    string dd = DateTime.Parse(chuoi.ToString()).Day.ToString();
                    if (dd.Length == 1)
                    {
                        dd = "0" + dd;
                    }
                    string mm = DateTime.Parse(chuoi.ToString()).Month.ToString();
                    if (mm.Length == 1)
                    {
                        mm = "0" + mm;
                    }
                    string yyyy = DateTime.Parse(chuoi.ToString()).Year.ToString();
                    tralai = dd + mm + yyyy;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                tralai = "";
            }
            return tralai;
        }
        /// <summary>
        /// tinh tong tien
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public void TongTien(TextBox dachietkhau, TextBox chuachietkhau, DataGridView dgv)
        {
            try
            {
                string dack = "0";
                string chuack = "0";
                if (dgv.RowCount > 0)
                {
                    int count = dgv.RowCount;
                    for (int i = 0; i < count; i++)
                    {
                        string tra = dgv.Rows[i].Cells[8].Value.ToString();
                        dack = (Double.Parse(tra) + Double.Parse(dack)).ToString();
                        string chua = dgv.Rows[i].Cells[10].Value.ToString();
                        chuack = (Double.Parse(chua) + Double.Parse(chuack)).ToString();
                    }
                }
                else
                {
                    dack = "0";
                    chuack = "0";
                }
                dachietkhau.Text = dack;
                chuachietkhau.Text = chuack;
                dack = "0";
                chuack = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hungvv ----------------------tinh toan
        /// </summary>
        public Boolean TinhChietKhau(ToolStripTextBox txtchietkhau, ToolStripTextBox txtphantramchietkhau, ToolStripTextBox txtgianhap, Double giagoc, Double phantram)
        {
            Boolean tra = false;
            try
            {
                Double trave = 0;
                if (phantram > 0 && phantram < 100)
                {
                    trave = (phantram / giagoc) * 100;
                    txtgianhap.Text = trave.ToString();
                    txtchietkhau.Text = (giagoc - trave).ToString();
                    txtphantramchietkhau.Text = phantram.ToString();
                    tra = true;
                }
                else
                {
                    if (phantram == 0)
                    {
                        txtgianhap.Text = giagoc.ToString();
                        txtchietkhau.Text = "0";
                        txtphantramchietkhau.Text = "0";
                        tra = true;
                    }
                    else
                    {
                        if (phantram == 100)
                        {
                            txtgianhap.Text = "0";
                            txtchietkhau.Text = giagoc.ToString();
                            txtphantramchietkhau.Text = "100";
                            tra = true;
                        }
                        else
                        {
                            txtchietkhau.Text = "0";
                            txtgianhap.Text = giagoc.ToString();
                            txtphantramchietkhau.Text = "0";
                            tra = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return tra;
        }

        /// <summary>
        /// kiem tra dinh dang ngay thang nam da dc cat
        /// </summary>
        /// <param name="hanhdong"></param>
        /// <param name="dd"></param>
        /// <param name="mm"></param>
        /// <param name="yyyy"></param>
        /// <returns></returns>
        public string kiem_tra(string hanhdong, int dd, int mm, int yyyy)
        {
            string Tralai = "";
            bool b = false;
            try
            {
                if (dd <= 0 || mm <= 0 || mm > 12)
                { Tralai = ""; }
                else
                {
                    if (mm == 1 || mm == 3 || mm == 5 || mm == 8 || mm == 10 || mm == 12)
                    {
                        if (dd <= 31)
                        { b = true; }
                        else
                        { b = false; }
                    }
                    else
                    {
                        if (mm == 4 || mm == 6 || mm == 7 || mm == 9 || mm == 11)
                        {
                            if (dd <= 30)
                            { b = true; }
                            else
                            { b = false; }
                        }
                        else
                        {
                            if (mm == 2 && yyyy % 4 == 0 && yyyy % 100 != 0)
                            {
                                if (dd <= 29)
                                { b = true; }
                                else
                                { b = false; }
                            }
                        }
                    }
                }
                if (b == true)
                {
                    if (hanhdong == "NgayThangNam")
                    { Tralai = dd + "/" + mm + "/" + yyyy; }
                    if (hanhdong == "ThangNgayNam")
                    { Tralai = mm + "/" + dd + "/" + yyyy; }
                    if (hanhdong == "NamThangNgay")
                    { Tralai = yyyy + "/" + mm + "/" + dd; }
                    if (hanhdong == "NamNgayThang")
                    { Tralai = yyyy + "/" + dd + "/" + mm; }
                }
                else
                { Tralai = ""; }
            }
            catch (Exception ex)
            { string s = ex.Message; Tralai = ""; }
            return Tralai;
        }
        /// <summary>
        /// kiem tra chuoi 
        /// </summary>
        /// <param name="chuoikiemtra"></param>
        /// <returns></returns>
        public string KiemTraDinhDangNgayThangNam(string hanhdong, string chuoikiemtra, char kitucat)
        {
            //Mrk Fix 21/02/2013 --- Hàm của hungvv lởm vl
            return chuoikiemtra;

            //string tralai = "";
            //try
            //{
            //    string[] tam = chuoikiemtra.Split(kitucat);
            //    int ngay = int.Parse(tam[0].ToString());
            //    int thang = int.Parse(tam[1].ToString());
            //    int nam = int.Parse(tam[2].ToString().Substring(0, 4).ToString());
            //    tralai = kiem_tra(hanhdong, ngay, thang, nam);
            //}
            //catch (Exception ex)
            //{ string s = ex.Message; tralai = ""; }
            //return tralai;
        }
        /// <summary>
        /// so sanh ngay thang
        /// </summary>
        /// <param name="kitucat"></param>
        /// <param name="phepsosanh"></param>
        /// <param name="NgayCanSoSanh"></param>
        /// <param name="NgayLamMocSoSanh"></param>
        /// <returns></returns>
        public Boolean SoSanhNgay(char kitucat, string phepsosanh, string NgayCanSoSanh, string NgayLamMocSoSanh)
        {
            #region Mrk Fix  trên cơ sở hàm cũ 21/02/2013 --- Hàm của hungvv lởm vl
            bool _kq0 = true; bool _kq1 = true;
            DateTime ngay1 = StringToDateTime_Common(NgayCanSoSanh, out _kq0);  //DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", ngayhientai, '/'));
            DateTime ngay2 = StringToDateTime_Common(NgayLamMocSoSanh, out _kq1);  //DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", ngay, '/'));
            bool ketqua = false;
            if (_kq1 && _kq0)   //convert thành công string to DateTime
            {
                switch (phepsosanh)
                {
                    case ">=":
                        ketqua = (ngay1.Date >= ngay2.Date);
                        break;
                    case "<=":
                        ketqua = (ngay1.Date <= ngay2.Date);
                        break;
                    case "<":
                        ketqua = (ngay1.Date < ngay2.Date);
                        break;
                    case ">":
                        ketqua = (ngay1.Date > ngay2.Date);
                        break;
                    case "=":
                        ketqua = (ngay1.Date == ngay2.Date);
                        break;
                    case "!=":
                        ketqua = (ngay1.Date != ngay2.Date);
                        break;
                    default:
                        ketqua = false;
                        break;
                }
            }
            return ketqua;
            #endregion

            //Boolean tralai = false;
            //try
            //{
            //    string date1 = KiemTraDinhDangNgayThangNam("ThangNgayNam", NgayCanSoSanh, kitucat);
            //    string date2 = KiemTraDinhDangNgayThangNam("ThangNgayNam", NgayLamMocSoSanh, kitucat);
            //    if (date1.Length >= 8 && date2.Length >= 8)
            //    {
            //        DateTime ngay1 = DateTime.Parse(date1);
            //        DateTime ngay2 = DateTime.Parse(date2);
            //        if (phepsosanh == ">=")
            //        {
            //            if (ngay1 >= ngay2)
            //            { tralai = true; }
            //            else
            //            { tralai = false; }
            //        }
            //        if (phepsosanh == "<=")
            //        {
            //            if (ngay1 <= ngay2)
            //            { tralai = true; }
            //            else
            //            { tralai = false; }
            //        }
            //        if (phepsosanh == ">")
            //        {
            //            if (ngay1 > ngay2)
            //            { tralai = true; }
            //            else
            //            { tralai = false; }
            //        }
            //        if (phepsosanh == "<")
            //        {
            //            if (ngay1 < ngay2)
            //            { tralai = true; }
            //            else
            //            { tralai = false; }
            //        }
            //        if (phepsosanh == "=")
            //        {
            //            if (ngay1 == ngay2)
            //            { tralai = true; }
            //            else
            //            { tralai = false; }
            //        }
            //        if (phepsosanh == "!=")
            //        {
            //            if (ngay1 != ngay2)
            //            { tralai = true; }
            //            else
            //            { tralai = false; }
            //        }
            //    }
            //    else
            //    { tralai = false; }

            //}
            //catch (Exception ex)
            //{ string s = ex.Message.ToString(); tralai = false; }
            //return tralai;
        }
        /// <summary>
        /// kiem tra thoi gian
        /// </summary>
        public string MyDateConversion(string data)
        {
            string thoigian = "";
            try
            {
                string[] tam = data.Split('/');
                int ngay = int.Parse(tam[0].ToString());
                int thang = int.Parse(tam[1].ToString());
                int nam = int.Parse(tam[2].ToString().Substring(0, 4).ToString());
                if (ngay > 31 || ngay < 1)
                {
                    thoigian = "";
                }
                else
                {
                    if (thang > 12 || thang < 1)
                    {
                        thoigian = "";
                    }
                    else
                    {
                        if (nam > 9998 || nam < 1900)
                        {
                            thoigian = "";
                        }
                        else
                        {
                            thoigian = thang + "/" + ngay + "/" + nam;
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; thoigian = ""; }
            return thoigian;
        }
        #endregion

        public string FormatMoney(Double a)
        {
            if (a >= 0 && a < 10)
                return a.ToString();
            string str = "";
            try
            {
                if (a < 0)
                    str = String.Format("{0,-0:0,0}", a);
                else
                    str = String.Format("{0:0,0}", a);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                str = "";
            }
            return str;
        }
        /// <summary>
        /// chuyen chuoi co ki tu dac biet ve ko dau
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        public string KhongDau(string chuoi)
        {
            string tralai = "";
            try
            {
                Vietnamese.Convert con = new Vietnamese.Convert();
                tralai = con.TiegVietKhongDau(chuoi);
            }
            catch (Exception ex)
            { string s = ex.Message; tralai = chuoi; }
            return tralai;
        }
        /// <summary>
        /// loc so
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        public string loc(string chuoi)
        {
            string t = "0";
            try
            {
                if (chuoi.Length > 1 && chuoi.Length <= 2)
                {
                    t = (int.Parse(chuoi)).ToString();
                }
                else
                { t = chuoi; }
            }
            catch { }
            return t;
        }

        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (Entities.ChiTietQuyen item in CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXem;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Entities.ChiTietQuyen item in CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenSua;
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Entities.ChiTietQuyen item in CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXoa;
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Entities.ChiTietQuyen item in CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenThem;
                        }
                        break;
                    }
            }
            return false;
        }

        public static Entities.HangHoa[] CheckGoiHang(Entities.HangHoa[] hh1, Entities.GoiHang[] goihang, Entities.ChiTietGoiHang[] chitietgoihang)
        {
            try
            {
                ArrayList array = new ArrayList();
                foreach (Entities.GoiHang item in goihang)
                {
                    int sotang = 0;
                    foreach (Entities.ChiTietGoiHang item1 in chitietgoihang)
                    {
                        if (item.MaGoiHang == item1.MaGoiHang)
                        {
                            sotang++;
                            foreach (Entities.HangHoa item2 in hh1)
                            {
                                if (item1.MaHangHoa == item2.MaHangHoa)
                                {
                                    sotang--;
                                    break;
                                }
                            }
                            if (sotang != 0)
                                break;
                        }
                    }
                    if (sotang == 0)
                    {
                        Entities.HangHoa hh = new Entities.HangHoa();
                        hh.MaHangHoa = item.MaGoiHang;
                        hh.TenHangHoa = item.TenGoiHang;
                        hh.MaNhomHangHoa = item.MaNhomHang;
                        hh.TenNhomHangHoa = item.TenNhomHang;
                        hh.MaThueGiaTriGiaTang = "";
                        hh.GiaBanBuon = item.GiaBanBuon;
                        hh.GiaBanLe = item.GiaBanLe;
                        hh.GiaNhap = item.GiaNhap;
                        array.Add(hh);
                    }
                }
                return (Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa));
            }
            catch
            {
                return new Entities.HangHoa[0];
            }
        }

        #region Mrk
        public static bool CheckHangHoaOrGoiHang(string MaHangHoa, Entities.GoiHang[] GoiHang, Entities.ChiTietGoiHang[] ChiTietGoiHang)
        {//True: Gói hàng   | False: Hàng hóa
            bool kq = false;    //Mặc định là hàng hóa
            if (GoiHang.Equals(null) || ChiTietGoiHang.Equals(null))
            {
                return kq;
            }
            if (GoiHang.Length == 0 || ChiTietGoiHang.Length == 0)
            {
                return kq;
            }
            foreach (Entities.GoiHang item in GoiHang)
            {
                foreach (Entities.ChiTietGoiHang item1 in ChiTietGoiHang)
                {
                    if (item1.MaGoiHang.Equals(item.MaGoiHang) && item1.Equals(MaHangHoa))
                    {
                        kq = true;
                        return true;
                    }
                }
            }
            return kq;
        }
        #endregion


        #region Boy loivt
        // load image and mousemove
        public void MouseLeave_Image(System.Windows.Controls.Image im)
        {
            try
            {
                switch (im.Name)
                {
                    case Common.Constants.lnkBanBuon:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banbuon.png"));
                            break;
                        }
                    case Common.Constants.lnkBanLe:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banle.png"));
                            break;
                        }
                    case Common.Constants.lnkKhoanMuc:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khoanmucthuchi.png"));
                            break;
                        }
                    case Common.Constants.lnkKhoHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khohang.png"));
                            break;
                        }
                    case Common.Constants.lnkKiemKeKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/kiemkekho.png"));
                            break;
                        }
                    case Common.Constants.lnkLoaiHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/loaihh.png"));
                            break;
                        }
                    case Common.Constants.lnkNhaCungCap:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhacungcap.png"));
                            break;
                        }
                    case Common.Constants.lnkNhanVien:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhanvien.png"));
                            break;
                        }
                    case Common.Constants.lnkKhachHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khachhang.png"));
                            break;
                        }
                    case Common.Constants.lnkDonViTinh:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/donvt.png"));
                            break;
                        }
                    case Common.Constants.lnkTienTe:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/tiente.png"));
                            break;
                        }

                    case Common.Constants.lnkNhomHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhomhh.png"));
                            break;
                        }

                    case Common.Constants.lnkSoQuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/soquy.png"));
                            break;
                        }
                    case Common.Constants.lnkTaiKhoanKT:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/tkketoan.png"));
                            break;
                        }
                    case Common.Constants.lnkThue:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/thue.png"));
                            break;
                        }
                    case Common.Constants.lnkInTemMaVach:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/inmavach.png"));
                            break;
                        }
                    case Common.Constants.BCDoanhThu:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bcdoanhthu.png"));
                            break;
                        }
                    case Common.Constants.BCTonKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bctonkho.png"));
                            break;
                        }
                    case Common.Constants.BCXuatHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bcxuathang.png"));
                            break;
                        }
                    case Common.Constants.BCNhapHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bcnhaphang.png"));
                            break;
                        }
                    case Common.Constants.BCCongNo:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bccongno.png"));
                            break;
                        }
                    case Common.Constants.lnkSoDuDauKy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/sodudauky.png"));
                            break;
                        }
                    case Common.Constants.lnkKetChuyenSoDu:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/ketchuyensodu.png"));
                            break;
                        }
                    case Common.Constants.lnkNhapKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhapkho.png"));
                            break;
                        }
                    case Common.Constants.lnkNhomTKKT:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhomtkketoan.png"));
                            break;
                        }
                    case Common.Constants.lnkPhieuChi:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phieuchi.png"));
                            break;
                        }
                    case Common.Constants.lnkPhieuThu:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phieuthu.png"));
                            break;
                        }
                    case Common.Constants.lnklbPhongBan:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phongban.png"));
                            break;
                        }
                    case Common.Constants.lnkDieuChuyenKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/dieuchuyenkho.png"));
                            break;
                        }
                    case Common.Constants.lnkXNDieuChuyenKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/xacnhandieuchuyenkho.png"));
                            break;
                        }
                    case Common.Constants.lnkPhieuXuatHuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phieuxuathuy.png"));
                            break;
                        }
                    case Common.Constants.lnkXNPhieuXuatHuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/xacnhanphieuxuathuy.png"));
                            break;
                        }
                    case Common.Constants.lnkHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/hanghoa.png"));
                            break;
                        }
                    case Common.Constants.lnkNhapSoDuTonKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/sodutonkho.png"));
                            break;
                        }
                    case Common.Constants.lnkKhachHangTraLai:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khtralai.png"));
                            break;
                        }
                    case Common.Constants.lnkTraLaiNCC:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/tralaincc.png"));
                            break;
                        }
                    case Common.Constants.lnkDonDatHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/dondathang.png"));
                            break;
                        }
                    case Common.Constants.imgDHT:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/DHT.jpg"));
                            break;
                        }
                    case Common.Constants.bcDTTheoTG:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcthoigian.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoNV:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhanvien.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bchanghoa.png"));
                            break;
                        }
                    case Common.Constants.bcLaiLo:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bclailo.png"));
                            break;
                        }
                    case Common.Constants.bcCNTheoNCC:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcncc.png"));
                            break;
                        }
                    case Common.Constants.bcCNTheoKH:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckh.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckho.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bchanghoa.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckho.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bchanghoa.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoTG:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcthoigian.png"));
                            break;
                        }
                    case Common.Constants.bcTonKhoTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckho.png"));
                            break;
                        }
                    case Common.Constants.bcTonKhoTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcxntkho.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoPhieuXuatHuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcxntxuathuy.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoLoaiHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcxntloaihang.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoTG:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcthoigian.png"));
                            break;
                        }
                    case Common.Constants.bcMucTonToiThieuToiDa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bctoithieutoida.png"));
                            break;
                        }
                    case Common.Constants.lnkcongty:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/congty.png"));
                            break;
                        }
                    case Common.Constants.lnkgoihang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/goihang.png"));
                            break;
                        }
                    case Common.Constants.lnkquydoi:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/quydoi.png"));
                            break;
                        }
                    case "NULL":
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banbuon.png"));
                            break;
                        }
                    default:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banbuon.png"));
                            break;
                        }
                }

            }
            catch
            {
            }
        }

        // mouse move
        public void MouseMove_Image(System.Windows.Controls.Image im)
        {
            try
            {
                switch (im.Name)
                {
                    case Common.Constants.lnkBanBuon:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banbuon1.png"));
                            break;
                        }
                    case Common.Constants.lnkBanLe:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banle1.png"));
                            break;
                        }
                    case Common.Constants.lnkKhoanMuc:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khoanmucthuchi1.png"));
                            break;
                        }
                    case Common.Constants.lnkKhoHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khohang1.png"));
                            break;
                        }
                    case Common.Constants.lnkKiemKeKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/kiemkekho1.png"));
                            break;
                        }
                    case Common.Constants.lnkLoaiHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/loaihh1.png"));
                            break;
                        }
                    case Common.Constants.lnkNhaCungCap:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhacungcap1.png"));
                            break;
                        }
                    case Common.Constants.lnkNhanVien:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhanvien1.png"));
                            break;
                        }
                    case Common.Constants.lnkNhomHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhomhh1.png"));
                            break;
                        }
                    case Common.Constants.lnkSoQuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/soquy1.png"));
                            break;
                        }
                    case Common.Constants.lnkTaiKhoanKT:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/tkketoan1.png"));
                            break;
                        }
                    case Common.Constants.lnkThue:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/thue1.png"));
                            break;
                        }
                    case Common.Constants.lnkInTemMaVach:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/inmavach1.png"));
                            break;
                        }
                    case Common.Constants.BCDoanhThu:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bcdoanhthu1.png"));
                            break;
                        }
                    case Common.Constants.BCTonKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bctonkho1.png"));
                            break;
                        }
                    case Common.Constants.BCXuatHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bcxuathang1.png"));
                            break;
                        }
                    case Common.Constants.BCNhapHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bcnhaphang1.png"));
                            break;
                        }
                    case Common.Constants.BCCongNo:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/bccongno1.png"));
                            break;
                        }
                    case Common.Constants.lnkKhachHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khachhang1.png"));
                            break;
                        }
                    case Common.Constants.lnkDonViTinh:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/donvt1.png"));
                            break;
                        }
                    case Common.Constants.lnkTienTe:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/tiente1.png"));
                            break;
                        }
                    case Common.Constants.lnkSoDuDauKy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/sodudauky1.png"));
                            break;
                        }
                    case Common.Constants.lnkKetChuyenSoDu:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/ketchuyensodu1.png"));
                            break;
                        }
                    case Common.Constants.lnkNhapKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhapkho1.png"));
                            break;
                        }
                    case Common.Constants.lnkNhomTKKT:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/nhomtkketoan1.png"));
                            break;
                        }
                    case Common.Constants.lnkPhieuChi:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phieuchi1.png"));
                            break;
                        }
                    case Common.Constants.lnkPhieuThu:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phieuthu1.png"));
                            break;
                        }
                    case Common.Constants.lnklbPhongBan:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phongban1.png"));
                            break;
                        }
                    case Common.Constants.lnkDieuChuyenKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/dieuchuyenkho1.png"));
                            break;
                        }
                    case Common.Constants.lnkXNDieuChuyenKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/xacnhandieuchuyenkho1.png"));
                            break;
                        }
                    case Common.Constants.lnkPhieuXuatHuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/phieuxuathuy1.png"));
                            break;
                        }
                    case Common.Constants.lnkXNPhieuXuatHuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/xacnhanphieuxuathuy1.png"));
                            break;
                        }
                    case Common.Constants.lnkHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/hanghoa1.png"));
                            break;
                        }
                    case Common.Constants.lnkNhapSoDuTonKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/sodutonkho1.png"));
                            break;
                        }
                    case Common.Constants.lnkKhachHangTraLai:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/khtralai1.png"));
                            break;
                        }
                    case Common.Constants.lnkTraLaiNCC:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/tralaincc1.png"));
                            break;
                        }
                    case Common.Constants.lnkDonDatHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/dondathang1.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoTG:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcthoigian1.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoNV:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhanvien1.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang1.png"));
                            break;
                        }
                    case Common.Constants.bcDTTheoHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bchanghoa1.png"));
                            break;
                        }
                    case Common.Constants.bcLaiLo:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bclailo1.png"));
                            break;
                        }
                    case Common.Constants.bcCNTheoNCC:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcncc1.png"));
                            break;
                        }
                    case Common.Constants.bcCNTheoKH:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckh1.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckho1.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang1.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bchanghoa1.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckho1.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang1.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoHangHoa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bchanghoa1.png"));
                            break;
                        }
                    case Common.Constants.bcNHTheoTG:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcthoigian1.png"));
                            break;
                        }
                    case Common.Constants.bcTonKhoTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bckho1.png"));
                            break;
                        }
                    case Common.Constants.bcTonKhoTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang1.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoKho:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcxntkho1.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoNhomHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcnhomhang1.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoPhieuXuatHuy:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcxntxuathuy1.png"));
                            break;
                        }
                    case Common.Constants.bcXNTTheoLoaiHang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcxntloaihang1.png"));
                            break;
                        }
                    case Common.Constants.bcXHTheoTG:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bcthoigian1.png"));
                            break;
                        }
                    case Common.Constants.bcMucTonToiThieuToiDa:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BC/bctoithieutoida1.png"));
                            break;
                        }
                    case Common.Constants.lnkcongty:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/congty1.png"));
                            break;
                        }
                    case Common.Constants.lnkgoihang:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/goihang1.png"));
                            break;
                        }
                    case Common.Constants.lnkquydoi:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/quydoi1.png"));
                            break;
                        }
                    case "NULL":
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banbuon1.png"));
                            break;
                        }
                    default:
                        {
                            im.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/banbuon1.png"));
                            break;
                        }
                }

            }
            catch
            {
            }
        }

        // setting mouse move 
        public void Themes_MouseMove(object obj)
        {
            try
            {
                System.Windows.Controls.Image img = (System.Windows.Controls.Image)obj;
                MouseMove_Image(img);
            }
            catch
            {
            }
        }

        // setting mouse leave 
        public void Themes_MouseLeave(object obj)
        {
            try
            {
                System.Windows.Controls.Image img = (System.Windows.Controls.Image)obj;
                MouseLeave_Image(img);
            }
            catch
            {
            }
        }

        #endregion


        //Mrk fix 21/02/2013 - hơi bị trùng hàm
        public static DateTime StringToDateTime_Common(string input, out bool kq)
        {
            return StringToDateTime_Common(input, out kq, "dd/MM/yyyy");
        }
        public static DateTime StringToDateTime_Common(string input, out bool kq, string Patterns)
        {
            kq = true;
            try
            {
                DateTime dt = new DateTime(1753, 1, 1);
                switch (Patterns)
                {
                    case "dd/MM/yyyy":
                        {
                            string[] arr = input.Split('/');
                            dt = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                        }
                        break;
                    default:
                        break;
                }
                return dt;
            }
            catch (Exception ex)
            {
                kq = false;
                return new DateTime(1753, 1, 1);
            }
        }
    }
}
