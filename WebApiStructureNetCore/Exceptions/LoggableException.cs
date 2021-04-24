using System;
using WebApiStructureNetCore.Models;

namespace WebApiStructureNetCore.Exceptions
{
    public class LoggableException : CustomException
    {
        /// <summary>
        /// Identificador da Exception
        /// </summary>
        public string Id { get; private set; }

        public LoggableException(int statusCode, string message, Exception inner)
            : base(statusCode, message, inner)
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public new CustomExceptionResponse GetResponse()
        {
            return new CustomExceptionResponse()
            {
                TipoErro = Type,
                Mensagem = Message,
                Id = Id,
            };
        }

        public LogErrors CreateLogErrorsObj(long? userId = null)
        {
            return new LogErrors()
            {
                Id = Id,
                Tipo = Type,
                UsuarioId = userId,
                Erro = InnerException.ToString(),
            };
        }
    }
}
