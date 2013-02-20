using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FX.Data;
using IdentityManagement.Domain;
using IdentityManagement.IService;

namespace IdentityManagement.ServiceImp
{
    public class AppTokenService : BaseService<AppToken, int>, IAppTokenService
    {
        public AppTokenService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        { }
    }

}