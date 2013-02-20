using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Domain
{
    public enum AtaxType
    {
        /// <summary>
        /// to khai chinh thuc
        /// </summary>
        InUse,
        /// <summary>
        /// to khai bo sung
        /// </summary>
        Temporary,
        /// <summary>
        /// to khai phat sinh
        /// </summary>
        Incurred,
        /// <summary>
        /// dang ky su dung dich vu
        /// </summary>
        RegisProfile,
        /// <summary>
        /// phu luc to khai 
        /// </summary>
        Appendix
    }
}
