using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FX.Data;
using IdentityManagement.Domain;
using IdentityManagement.IService;

namespace IdentityManagement.ServiceImp
{
    public class UserProfileService: BaseService<UserProfile ,int>,IUserProfileService
    {
        public UserProfileService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {}
    }

}