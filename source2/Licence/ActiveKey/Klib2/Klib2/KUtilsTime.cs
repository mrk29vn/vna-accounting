using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Klib2
{
    class KUtilsTime
    {
        #region Get Time Internet By Mrk
        public static DateTime GetNetworkTime()
        {
            DateTime kq = new DateTime(1753, 1, 1);
            try
            {
                const string ntpServer = "time.windows.com";    //default Windows time server
                // NTP message size - 16 bytes of the digest (RFC 2030)
                var ntpData = new byte[48];
                //Setting the Leap Indicator, Version Number and Mode values
                ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)
                var addresses = Dns.GetHostEntry(ntpServer).AddressList;
                var ipEndPoint = new IPEndPoint(addresses[0], 123); //The UDP port number assigned to NTP is 123
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);    //NTP uses UDP
                socket.Connect(ipEndPoint); socket.Send(ntpData); socket.Receive(ntpData); socket.Close();
                //Offset to get to the "Transmit Timestamp" field (time at which the reply  //departed the server for the client, in 64-bit timestamp format."
                const byte serverReplyTime = 40;
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);    //Get the seconds part
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);  //Get the seconds fraction
                intPart = SwapEndianness(intPart); fractPart = SwapEndianness(fractPart);   //Convert From big-endian to little-endian
                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                kq = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);   //**UTC** time
            }
            catch { }
            return kq.AddHours(7); //(UTC+07:00) Bangkok, Hanoi, Jakarta (convert to Vietnamese Timezone by Mrk)
        }

        static uint SwapEndianness(ulong x) // stackoverflow.com/a/3294698/162671
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
        #endregion

        public static DateTime GetNistTime2()
        {//http: //tf.nist.gov/tf-cgi/servers.cgi
            DateTime kq = new DateTime(1753, 1, 1);
            try
            {
                var client = new TcpClient("time.nist.gov", 13);
                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();
                    var utcDateTimeString = response.Substring(7, 17);
                    var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                    kq = localDateTime;
                }
            }
            catch { }
            return kq;
        }

        public static DateTime GetNistTime1()
        {
            DateTime dateTime = DateTime.MinValue;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/timezone.cgi?UTC/s/0");
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string html = stream.ReadToEnd().ToUpper();
                string time = Regex.Match(html, @">\d+:\d+:\d+<").Value; //HH:mm:ss format
                string date = Regex.Match(html, @">\w+,\s\w+\s\d+,\s\d+<").Value; //dddd, MMMM dd, yyyy
                dateTime = DateTime.Parse((date + " " + time).Replace(">", "").Replace("<", ""));
            }
            return dateTime.ToLocalTime();
        }

        public static DateTime GetFastestNISTDate()
        {
            var result = DateTime.MinValue;

            // Initialize the list of NIST time servers
            // http://tf.nist.gov/tf-cgi/servers.cgi
            string[] servers = new string[] {
                    "nist1-ny.ustiming.org",
                    "nist1-nj.ustiming.org",
                    "nist1-pa.ustiming.org",
                    "time-a.nist.gov",
                    "time-b.nist.gov",
                    "nist1.aol-va.symmetricom.com",
                    "nist1.columbiacountyga.gov",
                    "nist1-chi.ustiming.org",
                    "nist.expertsmi.com",
                    "nist.netservicesgroup.com"
             };

            // Try 5 servers in random order to spread the load
            Random rnd = new Random();
            foreach (string server in servers.OrderBy(s => rnd.NextDouble()).Take(5))
            {
                try
                {
                    // Connect to the server (at port 13) and get the response
                    string serverResponse = string.Empty;
                    using (var reader = new StreamReader(new System.Net.Sockets.TcpClient(server, 13).GetStream()))
                    {
                        serverResponse = reader.ReadToEnd();
                    }

                    // If a response was received
                    if (!string.IsNullOrEmpty(serverResponse))
                    {
                        // Split the response string ("55596 11-02-14 13:54:11 00 0 0 478.1 UTC(NIST) *")
                        string[] tokens = serverResponse.Split(' ');

                        // Check the number of tokens
                        if (tokens.Length >= 6)
                        {
                            // Check the health status
                            string health = tokens[5];
                            if (health == "0")
                            {
                                // Get date and time parts from the server response
                                string[] dateParts = tokens[1].Split('-');
                                string[] timeParts = tokens[2].Split(':');

                                // Create a DateTime instance
                                DateTime utcDateTime = new DateTime(
                                    Convert.ToInt32(dateParts[0]) + 2000,
                                    Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]),
                                    Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]),
                                    Convert.ToInt32(timeParts[2]));

                                // Convert received (UTC) DateTime value to the local timezone
                                result = utcDateTime.ToLocalTime();

                                return result;
                                // Response successfully received; exit the loop

                            }
                        }

                    }

                }
                catch
                {
                    // Ignore exception and try the next server
                }
            }
            return result;
        }
    }
}
