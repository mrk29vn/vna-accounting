using System;
using System.Configuration;
using FX.Core;
using System.Collections.Generic;


namespace Accounting.Core
{
    public static class Utils
    {
        public static readonly DateTime MinDate = new DateTime(1753, 10, 28);
        public static string SetDateTax(int datetax)
        {
            switch (datetax)
            {
                case 1: return "Kê khai theo tháng";
                case 2: return "Kê khai theo quý";
                case 3: return "Kê khai theo kỳ";
                case 4: return "Kê khai theo năm";
                case 5: return "Kê khai theo từng lần phát sinh";
                default: return "Kê khai theo tháng";
            }
        }
        public static int GetInt(char ss)
        {
            int a = 0;
            a = Convert.ToInt32(ss) - 48;
            return a;
        }
        public static bool CheckMST(string mST)
        {
            bool istrue = false;
            if (mST.Length <= 14 && mST.Length >= 10)
            {
                int value = GetInt(mST[0]) * 31 + GetInt(mST[1]) * 29 + GetInt(mST[2]) * 23 + GetInt(mST[3]) * 19 + GetInt(mST[4]) * 17 + GetInt(mST[5]) * 13 + GetInt(mST[6]) * 7 + GetInt(mST[7]) * 5 + GetInt(mST[8]) * 3;
                int mod = 10 - value % 11;
                if (Math.Abs(mod) == GetInt(mST[9]))
                    istrue = true;
            }
            else
                istrue = false;
            return istrue;
        }
        public static void SendMail(string countTK, string tr, string email, string temp)
        {
            try
            {
                var emailContact = ConfigurationManager.AppSettings.Get("MailAddress");
                FX.Utils.EmailService.IEmailService emailSrv =
                        IoC.Resolve<FX.Utils.EmailService.IEmailService>();
                Dictionary<string, string> subjectParams = new Dictionary<string, string>(1);
                subjectParams.Add("$subject", "Khai thuế Online bằng dịch vụ T-Van của VNPT");
                Dictionary<string, string> bodyParams = new Dictionary<string, string>(2);
                bodyParams.Add("$countTK", countTK);
                bodyParams.Add("$tr", tr);
                emailSrv.ProcessEmail(emailContact, email, temp, subjectParams, bodyParams);
            }
            catch (Exception ex)
            {
            }
        }
        //public static string Serial(string SerialTct)
        //{
        //    if (!string.IsNullOrEmpty(SerialTct))
        //    {
        //        var number = BigInteger.Parse(SerialTct);
        //        string b = number.ToString("X");
        //        return b;
        //    }
        //    return null;
        //}
    }
}
