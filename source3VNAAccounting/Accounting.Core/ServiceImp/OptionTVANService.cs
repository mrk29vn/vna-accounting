using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FX.Data;
using Accounting.Core.Domain;
using Accounting.Core.IService;

namespace Accounting.Core.ServiceImp
{
    public class OptionTVANService : BaseService<OptionTVAN, int>, IOptionTVANService
    {
        public OptionTVANService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        { }
    }

}