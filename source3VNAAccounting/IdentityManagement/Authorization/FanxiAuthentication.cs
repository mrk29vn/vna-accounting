using System;
using System.Web;
using System.Web.Security;
using IdentityManagement.IService;
using IdentityManagement.Domain;
using FX.Data;
using System.Collections.Generic;
using IdentityManagement.WebProviders;
using System.Linq;
namespace IdentityManagement.Authorization
{
    public class FanxiAuthentication : FanxiAuthenticationBase
    {
        IRBACMembershipProvider _membershipProvider;
        public FanxiAuthentication(IRBACMembershipProvider mMembershipProvider)
        {
            _membershipProvider = mMembershipProvider;
        }

        public FanxiAuthentication(string mApplicationName, string mSessionFactoryConfigPath)
        {
            _membershipProvider = new RBACMembershipProvider(mApplicationName, mSessionFactoryConfigPath);
        }

        public override UserIdentity Authenticate(string mUserName, string mPassword)
        {
            Func<role, bool> predicate = null;
            user TempUser = _membershipProvider.AuthenUser(mUserName, mPassword);
            if (predicate == null)
            {
                predicate = delegate(role r)
                {
                    return r.AppID == this._membershipProvider.Application.AppID;
                };
            }
            if (TempUser != null)
            {
                IList<role> TempRoles = (from r in TempUser.Roles where r.AppID == _membershipProvider.Application.AppID select r).ToList();
                IList<permission> PerList = new List<permission>();
                foreach (role r in TempRoles)
                {
                    foreach (permission per in r.Permissions)
                    {
                        if (!PerList.Contains(per)) PerList.Add(per);
                    }
                }
                IList<FanxiPermission> _FPList = new List<FanxiPermission>();  
                foreach(permission per in PerList)
                {
                    string mObject = (per.ObjectRBAC != null) ? per.ObjectRBAC.name : "";
                    string mOperation = (per.Operation != null) ? per.Operation.name : "";
                    FanxiPermission _FP = new FanxiPermission(per.name, mObject, mOperation);
                    _FPList.Add(_FP);
                }
                string[] RoleStrs  = TempRoles.Select<role, string>(delegate (role r)
                                    { 
                                        return r.name;
                                    }).ToArray<string>();
                //(from r in TempRoles select r.name).ToArray();
                return new UserIdentity(TempUser.username, _FPList,RoleStrs);
            }
            else return null;
        }
    }
}
