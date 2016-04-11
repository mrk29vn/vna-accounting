using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace GUI
{
    public static class Utils
    {
        #region Khai báo
        public static bool ShowXnt = false;
        #endregion

        #region Function Utils
        public static DateTime StringToDateTime(string input)
        {
            bool kq;
            return StringToDateTime(input, out kq, "dd/MM/yyyy");
        }
        public static DateTime StringToDateTime(string input, out bool kq)
        {
            return StringToDateTime(input, out kq, "dd/MM/yyyy");
        }
        public static DateTime StringToDateTime(string input, out bool kq, string patterns)
        {
            kq = true;
            try
            {
                DateTime dt = new DateTime(1753, 1, 1);
                switch (patterns)
                {
                    case "dd/MM/yyyy":
                        {
                            string[] arr = input.Split('/');
                            dt = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                        }
                        break;
                }
                return dt;
            }
            catch (Exception)
            {
                kq = false;
                return new DateTime(1753, 1, 1);
            }
        }

        public static DateTime GetDateTimeNow(string select = "")
        {
            if (string.IsNullOrEmpty(select)) select = Luu.Server;
            if (string.IsNullOrEmpty(select)) select = "server";
            DateTime dateTime = new DateTime(1753, 1, 1);
            //check kết nối mạng
            //if (Klib2.InternetConnection.IsConnectedToInternet()) dateTime = Klib2.KUtilsTime.GetTimeInternet();
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

        public static Entities.ThongTinCongTy LayThongTinCongty(string macty = "")
        {
            return "LayThongTinCongty".GetDataFromServer<Entities.ThongTinCongTy>(new Entities.TruyenGiaTri("Select", macty));
        }
        #endregion

        #region Utils
        /// <summary>
        /// Hàm lấy dữ liệu về từ server
        /// </summary>
        /// <param name="strServer">Lệnh truyền gọi hàm trên Server</param>
        /// <param name="input">Đối tượng lọc đầu vào</param>
        /// <param name="output">Dữ liệu trả về</param>
        /// <returns></returns>
        public static bool GetDataFromServer<T>(string strServer, object input, out T output)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(IPAddress.Parse(Luu.IP), Luu.Ports));
                NetworkStream networkStream = tcpClient.GetStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(networkStream, strServer);
                binaryFormatter.Serialize(networkStream, input);
                output = (T)binaryFormatter.Deserialize(networkStream);
                networkStream.Close();
                tcpClient.Close();
                return true;
            }
            catch (Exception)
            {
                output = default(T);
                return false;
            }
        }
        public static T GetDataFromServer<T>(this string strServer, object input = null)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(IPAddress.Parse(Luu.IP), Luu.Ports));
                NetworkStream networkStream = tcpClient.GetStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(networkStream, strServer);
                if (input != null) binaryFormatter.Serialize(networkStream, input);
                T output = (T)binaryFormatter.Deserialize(networkStream);
                networkStream.Close();
                tcpClient.Close();
                return output;
            }
            catch { }
            return default(T);
        }

        public static void Copy(object from, object to)
        {
            Type fromType = from.GetType();
            Type toType = to.GetType();

            //if (fromType == null)
            //    throw new ArgumentNullException("fromType", "The type that you are copying from cannot be null");
            //if (from == null)
            //    throw new ArgumentNullException("from", "The object you are copying from cannot be null");
            //if (toType == null)
            //    throw new ArgumentNullException("toType", "The type that you are copying to cannot be null");
            //if (to == null)
            //    throw new ArgumentNullException("to", "The object you are copying to cannot be null");

            // Don't copy if they are the same object  
            if (ReferenceEquals(@from, to)) return;
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty;
            // Get all of the public properties in the toType with getters and setters  
            PropertyInfo[] properties = toType.GetProperties(flags);
            Dictionary<string, PropertyInfo> toProperties = properties.ToDictionary(property => property.Name);

            // Now get all of the public properties in the fromType with getters and setters  
            properties = fromType.GetProperties(flags);
            foreach (PropertyInfo fromProperty in properties)
            {
                // If a property matches in name and type, copy across  
                if (!toProperties.ContainsKey(fromProperty.Name)) continue;
                PropertyInfo toProperty = toProperties[fromProperty.Name];
                if (toProperty.PropertyType != fromProperty.PropertyType) continue;
                object value = fromProperty.GetValue(@from, null);
                toProperty.SetValue(to, value, null);
            }
        }

        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().ToList().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();

                foreach (var pro in properties.Where(pro => columnNames.Contains(pro.Name)))
                {
                    pro.SetValue(objT, row[pro.Name], null);
                }

                return objT;
            }).ToList();
        }
        #endregion
    }
}
