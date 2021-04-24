using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Exceptions
{
    public class UnexpectedException : LoggableException
    {
        public UnexpectedException(Exception exception)
            : base(500, "Houve um erro ao executar sua solicitação. Contate o suporte.", exception)
        {
        }
    }
}
