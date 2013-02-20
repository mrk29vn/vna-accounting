using System;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.Caching;
namespace IdentityManagement.Authorization
{
    public abstract class FanxiAuthenticationBase
    {
        public static string Cache_Authenticate = "Cache_Authenticate";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mUserName"></param>
        /// <param name="mPassword"></param>
        /// <returns>
        /// Return user with permmissions list
        /// If result = null then the Authen Faile 
        /// </returns>
        public abstract UserIdentity Authenticate(string mUserName, string mPassword);

        public static void SetAuthCookie(UserIdentity _user)
        {
            if (_user == null) return;
            double totalSeconds = 50000; // Thenn Note
            //int timeout = 
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,               // version 
            //                                                  _user.Name,  // user name
            //                                                  DateTime.Now,    // create time
            //                                                  DateTime.Now.AddSeconds(3000), // expire time
            //                                                  false,           // persistent
            //                                                  _user.UserData);             // user data

            string userData = "InCache";
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,        // version
                                                                _user.Name,            // user name
                                                                DateTime.Now,          // create time
                                                                DateTime.Now.AddSeconds(totalSeconds), // expire time
                                                                false,                 // persistent
                                                                userData);             // user data
            string strEncryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strEncryptedTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
            if (HttpContext.Current.Cache[_user.Name] == null)
                HttpContext.Current.Cache.Insert(_user.Name, _user.UserData, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(totalSeconds));
            // HttpContext.Current.Session[Cache_Authenticate] = _user.UserData;//, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(totalSeconds));
        }

        public bool Login(string mUserName, string mPassword)
        {
            UserIdentity tempId = Authenticate(mUserName, mPassword);
            if (tempId == null) return false;
            SetAuthCookie(tempId);
            return true;
        }

        public static void SigOut(string username)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Cache.Remove(username);
        }
    }
}
