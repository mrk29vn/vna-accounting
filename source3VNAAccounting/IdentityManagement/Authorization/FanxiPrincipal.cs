using System;
using System.Collections;
using System.Security;
using System.Security.Principal;
using System.Linq;
namespace IdentityManagement.Authorization
{
    public class FanxiPrincipal:IPrincipal 
    {
        private IIdentity _identity;

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public FanxiPrincipal(UserIdentity midentity)
        {
            _identity = midentity;
        }

        public bool IsInRole(string roles)
        {
            UserIdentity midentity = _identity as UserIdentity;
            if (midentity != null)
            {
                return midentity.Roles.Contains(roles);
            }
            else return false;
        }

        public bool IsInRole(string mObject, string mOperation)
        {
            UserIdentity midentity = _identity as UserIdentity;
            if (midentity != null)
            {
                foreach (FanxiPermission Fp in midentity.Permissions)
                {
                    if (Fp.RbacObject == mObject || Fp.RbacOperation == mOperation)
                        return true;
                }
                return false;
            }
            else return false;
        }
    }
}
