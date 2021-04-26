using System;
using WebApiStructureNetCore.Enums;

namespace WebApiStructureNetCore.Exceptions
{
    public class UnexpectedException : LoggableException
    {
        public UnexpectedException(Exception exception)
            : base(ExceptionTypesEnum.Unexpected, 500, "Houve um erro ao executar sua solicitação. Contate o suporte.", exception)
        {
        }

        public UnexpectedException(Exception exception, string message)
            : base(ExceptionTypesEnum.Unexpected, 500, message, exception)
        {
        }
    }
}
