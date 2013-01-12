using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ServerConfig
    {
        #region hungvv===================================================================================
        private string server;
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        private string ip;
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string port;
        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        #endregion
    }
}
