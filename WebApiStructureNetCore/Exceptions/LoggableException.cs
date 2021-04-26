using System;
using WebApiStructureNetCore.Entities;
using WebApiStructureNetCore.Enums;
using WebApiStructureNetCore.Models;

namespace WebApiStructureNetCore.Exceptions
{
    public class LoggableException : CustomException
    {
        /// <summary>
        /// Identificador da Exception
        /// </summary>
        public string Id { get; private set; }

        protected LoggableException(ExceptionTypesEnum type, int statusCode, string message, Exception inner)
            : base(type, statusCode, message, inner)
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public new CustomExceptionResponse GetResponse()
        {
            return new CustomExceptionResponse()
            {
                TipoErro = (short)Type,
                Mensagem = Message,
                Id = Id,
            };
        }

        public LogErrors CreateLogErrorsObj(long? userId = null)
        {
            return new LogErrors()
            {
                Id = Id,
                Tipo = (short)Type,
                UsuarioId = userId,
                Erro = InnerException.ToString(),
            };
        }
    }
}
