using System;
using System.Collections.Generic;
using System.Text;
using IdentityManagement.Domain;
namespace IdentityManagement.IService
{
    public interface IAppTokenService : FX.Data.IBaseService<AppToken, int>
    {
    }
}
