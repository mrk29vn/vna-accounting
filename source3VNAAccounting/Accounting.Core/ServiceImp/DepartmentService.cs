using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FX.Data;
using Accounting.Core.Domain;
using Accounting.Core.IService;

namespace Accounting.Core.ServiceImp
{
    public class DepartmentService: BaseService<Department ,int>,IDepartmentService
    {
        public DepartmentService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {}
    }

}