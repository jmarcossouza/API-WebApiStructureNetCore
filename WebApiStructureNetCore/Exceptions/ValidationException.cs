using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStructureNetCore.Enums;

namespace WebApiStructureNetCore.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(string message)
            : base(400, message)
        {
            Type = (int)ExceptionTypesEnum.Validation;
        }
    }
}
