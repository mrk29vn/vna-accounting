using System;
using System.Security.Cryptography;
using System.Text;

namespace kRunSql
{
    class Utils
    {
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
