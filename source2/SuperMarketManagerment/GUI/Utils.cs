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
        #endregion
    }
}
