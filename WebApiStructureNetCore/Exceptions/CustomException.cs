using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        protected int Type { get; set; }

        public CustomException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(int statusCode, string message, Exception inner)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }

        public CustomExceptionResponse GetResponse()
        {
            return new CustomExceptionResponse()
            {
                TipoErro = Type,
                Mensagem = Message,
            };
        }
    }

}
