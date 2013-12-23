using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class SQL
    {
        #region hungvv============================================================================
        private string active;

        public string Active
        {
            get { return active; }
            set { active = value; }
        }
        private string serverName;

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        private string databaseName;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public SQL(string active, string serverName, string databaseName, string userName, string password)
        {
            this.active = active;
            this.serverName = serverName;
            this.databaseName = databaseName;
            this.userName = userName;
            this.password = password;
        }

        public SQL() { }
        public SQL(string active)
        {
            this.active = active;
        }
        #endregion
    }
}
