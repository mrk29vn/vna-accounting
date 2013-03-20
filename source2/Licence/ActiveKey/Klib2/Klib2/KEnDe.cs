using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klib2
{
    public class KEnDe
    {
        public static String CtoBase64(int so, int nbase)
        {
            String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (nbase < 2 || nbase > chars.Length) return string.Empty;
            int r;
            String kq = string.Empty;
            while (so >= nbase)
            {
                r = so % nbase;
                kq = chars[r] + kq;
                so = so / nbase;
            }
            kq = chars[so] + kq;
            return kq;
        }

        public static string MrkKEY = "k29vn - Đặng Đức Kiên";

        public KEnDe() { }

        public static string K_B(string data)
        {
            string[] t0 = BitConverter.ToString(((new System.Security.Cryptography.MD5CryptoServiceProvider()).ComputeHash(Encoding.UTF8.GetBytes(data)))).Split('-');
            return t0[0] + t0[1] + "-" + t0[2] + t0[3] + "-" + t0[4] + t0[5] + "-" + t0[6] + t0[7] + "-" + t0[8] + t0[9] + "-" + t0[10] + t0[11] + "-" + t0[12] + t0[13] + "-" + t0[14] + t0[15];
        }

        public static string K_DS()
        {
            return DS("Mrk&^765BHHHMrkMrkMrk7hv4v4884g4");
        }
        public static string KDS(string toEncrypt)
        {
            if (toEncrypt.Equals("2+9=88")) toEncrypt = "Mrk&^765BHHHMrkMrkMrk7hv4v4884g4";
            string tem = toEncrypt;
            for (int i = 2; i < 9; i++) tem = DS(tem);
            return tem;
        }
        public static string DS(string toEncrypt)
        {
            string key = "k29vn - Đặng Đức Kiên";
            if (string.IsNullOrEmpty(MrkKEY)) key = "k29vn - Đặng Đức Kiên";
            else key = MrkKEY;
            string rt = string.Empty;
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                System.Security.Cryptography.MD5CryptoServiceProvider hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                System.Security.Cryptography.TripleDESCryptoServiceProvider tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                rt = System.Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch { rt = string.Empty; }
            return rt;
        }

        public static string K_ES()
        {
            return ES("Mrk&^765BHHHMrkMrkMrk7hv4v4884g4");
        }
        public static string KES(string toDecrypt)
        {
            if (toDecrypt.Equals("1+1=2")) toDecrypt = "Mrk&^765BHHHMrkMrkMrk7hv4v4884g4";
            string tem = toDecrypt;
            for (int i = 2; i < 9; i++) tem = ES(tem);
            return tem;
        }
        public static string ES(string toDecrypt)
        {
            string key = "k29vn - Đặng Đức Kiên";
            if (string.IsNullOrEmpty(MrkKEY)) key = "k29vn - Đặng Đức Kiên";
            else key = MrkKEY;
            string rt = string.Empty;
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = System.Convert.FromBase64String(toDecrypt);
                System.Security.Cryptography.MD5CryptoServiceProvider hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                System.Security.Cryptography.TripleDESCryptoServiceProvider tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                rt = UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch { rt = string.Empty; }
            return rt;
        }
    }
}
