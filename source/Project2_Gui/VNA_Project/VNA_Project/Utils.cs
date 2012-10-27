using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project
{
    public class Utils
    {
        #region Bảo mật
        public static string EnCrypt(string strEnCrypt)
        {
            return EnCrypt(strEnCrypt, "Đặng Đức Kiên");
        }
        private static string EnCrypt(string strEnCrypt, string key)
        {
            try
            {
                byte[] keyArr;
                byte[] EnCryptArr = UTF8Encoding.UTF8.GetBytes(strEnCrypt);
                System.Security.Cryptography.MD5CryptoServiceProvider MD5Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                System.Security.Cryptography.TripleDESCryptoServiceProvider tripDes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
                return Convert.ToBase64String(arrResult, 0, arrResult.Length);
            }
            catch (Exception ex) { }
            return string.Empty;
        }

        public static string DeCrypt(string strEnCrypt)
        {
            return DeCrypt(strEnCrypt, "Đặng Đức Kiên");
        }
        private static string DeCrypt(string strDecypt, string key)
        {
            try
            {
                byte[] keyArr;
                byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
                System.Security.Cryptography.MD5CryptoServiceProvider MD5Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                System.Security.Cryptography.TripleDESCryptoServiceProvider tripDes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] arrResult = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length);
                return UTF8Encoding.UTF8.GetString(arrResult);
            }
            catch (Exception ex) { }
            return string.Empty;
        }
        #endregion
    }
}
