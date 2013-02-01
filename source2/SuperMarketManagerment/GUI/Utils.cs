using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI
{
    public class Utils
    {
        #region Khai báo
        public static bool showXNT = false;
        #endregion

        #region Function Utils
        public static DateTime StringToDateTime(string ddMMyyyy, out bool kq)
        {
            kq = true;
            try
            {
                string[] arr = ddMMyyyy.Split('/');
                DateTime dt = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
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
