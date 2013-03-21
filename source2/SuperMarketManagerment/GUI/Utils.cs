using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI
{
    public class Utils
    {
        #region Khai báo
        public static bool tempKQ = true;   //Phục vụ cho StringToDateTime(string input, out bool kq)
        public static bool showXNT = false;
        #endregion

        #region Function Utils

        public static DateTime StringToDateTime(string input)
        {
            bool kq = false;
            return StringToDateTime(input, out kq, "dd/MM/yyyy");
        }
        public static DateTime StringToDateTime(string input, out bool kq)
        {
            return StringToDateTime(input, out kq, "dd/MM/yyyy");
        }
        public static DateTime StringToDateTime(string input, out bool kq, string Patterns)
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

        public static DateTime GetDateTimeNow(string select)
        {
            if (string.IsNullOrEmpty(select)) select = "server";
            DateTime dateTime = new DateTime(1753, 1, 1);
            //check kết nối mạng
            if (Klib2.InternetConnection.IsConnectedToInternet()) dateTime = Klib2.KUtilsTime.GetTimeInternet();
            bool a = dateTime.Date == (new DateTime(1753, 1, 1)).Date;
            bool b = dateTime.Date == (new DateTime()).Date;
            bool c = a || b;
            if (c && select.Equals("client"))
            {
                try
                { dateTime = DateServer.Date(); }
                catch
                { dateTime = DateTime.Now; }
            }
            else if (c && select.Equals("server"))
            {
                dateTime = DateTime.Now;
            }
            return dateTime;
        }
        #endregion
    }
}
