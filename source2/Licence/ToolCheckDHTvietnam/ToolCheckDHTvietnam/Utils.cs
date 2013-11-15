using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ToolCheckDHTvietnam
{
    public class Utils
    {
        public static List<List<string>> CheckThongTinNguoiDung(string strPatch)
        {
            //Get Thông Tin người dùng mới
            string bientam = Klib2.KEnDe.MrkKEY; Klib2.KEnDe.MrkKEY = string.Empty;
            string subK = Klib2.KEnDe.ES(strPatch);
            List<List<string>> kq = Klib2.Registry.GetRegistry(subK); Klib2.KEnDe.MrkKEY = bientam;
            return kq;
        }

        public static string Get(string ten, List<List<string>> l)
        {
            string kq = string.Empty;
            for (int i = 0; i < l[0].Count; i++)
            {
                if (l[0][i].Equals(ten)) kq = l[1][i];
            }
            return kq;
        }

        public static string MaHoa(string key, string toEncrypt)
        {
            try
            {
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                                                          {
                                                              Key = keyArray,
                                                              Mode = CipherMode.ECB,
                                                              Padding = PaddingMode.PKCS7
                                                          };
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GiaiMa(string key, string toDecrypt)
        {
            try
            {
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                                                          {
                                                              Key = keyArray,
                                                              Mode = CipherMode.ECB,
                                                              Padding = PaddingMode.PKCS7
                                                          };
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
