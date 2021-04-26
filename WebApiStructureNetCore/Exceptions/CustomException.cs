using System;
using WebApiStructureNetCore.Enums;
using WebApiStructureNetCore.Models;

namespace WebApiStructureNetCore.Exceptions
{
    public class CustomException : Exception
    {
        /// <summary>
        /// StatusCode da requisição HTTP
        /// </summary>
        public int StatusCode { get; private set; }
        /// <summary>
        /// Identificador do tipo erro, isso é usado para o client identificar qual o tipo de erro que ele recebeu.
        /// </summary>
        public ExceptionTypesEnum Type { get; }

        protected CustomException(ExceptionTypesEnum type, int statusCode, string message)
            : base(message)
        {
            Type = type;
            StatusCode = statusCode;
        }

        protected CustomException(ExceptionTypesEnum type, int statusCode, string message, Exception inner)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }

        public CustomExceptionResponse GetResponse()
        {
            return new CustomExceptionResponse()
            {
                TipoErro = (short)Type,
                Mensagem = Message,
            };
        }
    }

}
