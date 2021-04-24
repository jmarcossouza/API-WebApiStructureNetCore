using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStructureNetCore.Enums;

namespace WebApiStructureNetCore.Exceptions
{
    public class NormalException : CustomException
    {
        public NormalException(string message)
            : base(400, message)
        {
            Type = (int)ExceptionTypesEnum.Normal;
        }
    }
}
