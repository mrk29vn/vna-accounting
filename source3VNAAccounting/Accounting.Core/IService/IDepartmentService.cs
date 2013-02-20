using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Domain;
namespace Accounting.Core.IService
{
    public interface IDepartmentService : FX.Data.IBaseService<Department, int>
    {
    }
}
