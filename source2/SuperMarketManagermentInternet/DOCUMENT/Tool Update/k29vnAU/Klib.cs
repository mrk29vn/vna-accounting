using System;
using System.IO;
using System.Reflection;
using k29vnAU.Properties;

namespace k29vnAU
{
    public class K29VnAuToolLib
    {
        public static byte[] Dl(string url, System.Windows.Forms.ProgressBar processBarTemp, System.Windows.Forms.Label lbMsgValue, System.Windows.Forms.Label lbProcessBar, out string returnMsg)
        {
            processBarTemp.Value = 0;
            byte[] kq;
            returnMsg = string.Empty;
            try
            {
                lbMsgValue.Text = Resources.K29VnAuTool_Dl_Đang_kết_nối_đến_server___;
                System.Windows.Forms.Application.DoEvents();
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] buffer = new byte[1024];
                int dataLength = (int)response.ContentLength;
                processBarTemp.Maximum = dataLength;
                lbProcessBar.Text = Resources.K29VnAuTool_Dl__0_ + dataLength;
                lbMsgValue.Text = Resources.K29VnAuTool_Dl_Đang_tải_dữ_liệu_về___;
                System.Windows.Forms.Application.DoEvents();
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    if (stream != null)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            processBarTemp.Value = processBarTemp.Maximum;
                            lbProcessBar.Text = dataLength + Resources.K29VnAuTool_Dl__ + dataLength;
                            System.Windows.Forms.Application.DoEvents();
                            break;
                        }
                        memStream.Write(buffer, 0, bytesRead);
                        if (processBarTemp.Value + bytesRead > processBarTemp.Maximum) continue;
                        processBarTemp.Value += bytesRead;
                    }
                    lbProcessBar.Text = processBarTemp.Value + Resources.K29VnAuTool_Dl__ + dataLength;
                    processBarTemp.Refresh();
                    System.Windows.Forms.Application.DoEvents();
                }
                kq = memStream.ToArray();
                stream.Close(); memStream.Close();
                lbMsgValue.Text = Resources.K29VnAuTool_Dl_Tải_thành_công_;
            }
            catch (Exception ex)
            {
                lbMsgValue.Text = Resources.K29VnAuTool_Dl_Đường_truyền_lỗi_hoặc_đường_link_file_cập_nhật_chưa_chính_xác_;
                returnMsg = ex.Message + "\r\n\r\n" + ex.StackTrace;
                kq = null;
            }
            return kq;
        }

        public static string GetUrlSave(string urlDownload, string urlFolderSave)
        {
            string[] strTem = urlDownload.Split('/');
            string urlSave = urlFolderSave + strTem[strTem.Length - 1];
            return urlSave;
        }

        public static string GetVer(string url)
        {
            System.Net.HttpWebRequest myWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            myWebRequest.Method = "GET";
            System.Net.HttpWebResponse myWebResponse = (System.Net.HttpWebResponse)myWebRequest.GetResponse();
            Stream stream = myWebResponse.GetResponseStream();
            if (stream == null) return string.Empty;
            StreamReader myWebSource = new StreamReader(stream);
            string myPageSource = myWebSource.ReadToEnd();
            myWebResponse.Close();
            return myPageSource;
        }

        public static string GetVerCurrent()
        {
            return new AssemblyInfo(Assembly.GetEntryAssembly()).Version;
        }
    }

    public class KWinZip
    {
        public static bool UnZipFile(string inputPathOfZipFile, out string returnMsg)
        {
            returnMsg = string.Empty;

            bool ret = true;
            try
            {
                if (File.Exists(inputPathOfZipFile))
                {
                    string baseDirectory = Path.GetDirectoryName(inputPathOfZipFile);

                    using (ICSharpCode.SharpZipLib.Zip.ZipInputStream zipStream = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(File.OpenRead(inputPathOfZipFile)))
                    {
                        ICSharpCode.SharpZipLib.Zip.ZipEntry theEntry;
                        while ((theEntry = zipStream.GetNextEntry()) != null)
                        {
                            if (theEntry.IsFile)
                            {
                                if (theEntry.Name != "")
                                {
                                    string strNewFile = @"" + baseDirectory + @"\" + theEntry.Name;
                                    //Check thư mục chứa nó, Nếu không có thì tạo mới
                                    string folder = Path.GetDirectoryName(strNewFile);
                                    if (folder != null && !Directory.Exists(folder)) Directory.CreateDirectory(folder);
                                    ////////End

                                    using (FileStream streamWriter = File.Create(strNewFile))
                                    {
                                        byte[] data = new byte[2048];
                                        while (true)
                                        {
                                            int size = zipStream.Read(data, 0, data.Length);
                                            if (size > 0)
                                                streamWriter.Write(data, 0, size);
                                            else
                                                break;
                                        }
                                        streamWriter.Close();
                                    }
                                }
                            }
                            else if (theEntry.IsDirectory)
                            {
                                string strNewDirectory = @"" + baseDirectory + @"\" + theEntry.Name;
                                if (!Directory.Exists(strNewDirectory))
                                {
                                    Directory.CreateDirectory(strNewDirectory);
                                }
                            }
                        }
                        zipStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
                returnMsg = ex.Message + "\r\n\r\n" + ex.StackTrace;
            }
            return ret;
        }
    }

    public class AssemblyInfo
    {
        public AssemblyInfo(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            _assembly = assembly;
        }
        private readonly Assembly _assembly;
        public string ProductTitle
        {
            get
            {
                return GetAttributeValue<AssemblyTitleAttribute>(a => a.Title,
                       Path.GetFileNameWithoutExtension(_assembly.CodeBase));
            }
        }
        public string Version
        {
            get
            {
                Version version = _assembly.GetName().Version;
                return version != null ? version.ToString() : "1.0.0.0";
            }
        }
        public string Description
        {
            get { return GetAttributeValue<AssemblyDescriptionAttribute>(a => a.Description); }
        }
        public string Product
        {
            get { return GetAttributeValue<AssemblyProductAttribute>(a => a.Product); }
        }
        public string Copyright
        {
            get { return GetAttributeValue<AssemblyCopyrightAttribute>(a => a.Copyright); }
        }
        public string Company
        {
            get { return GetAttributeValue<AssemblyCompanyAttribute>(a => a.Company); }
        }
        protected string GetAttributeValue<TAttr>(Func<TAttr,
          string> resolveFunc, string defaultResult = null) where TAttr : Attribute
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(TAttr), false);
            return attributes.Length > 0 ? resolveFunc((TAttr)attributes[0]) : defaultResult;
        }
    }
}
