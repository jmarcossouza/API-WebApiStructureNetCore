using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Enums
{
    public enum ExceptionTypesEnum
    {
        /// <summary>
        /// Erro inesperado que não está sendo tratado pela API, pode ser um erro de código ou alguma problema no servidor.
        /// Este é o único caso em que será disparada uma Exception ao invés de uma CustomException.
        /// Este erro será registrado no log.
        /// </summary>
        Unexpected,
        /// <summary>
        /// Um erro esperado de acontecer, intuição é somente avisar ao client que ele está requisitando algo de forma errada.
        /// </summary>
        Normal,
        /// <summary>
        /// Erro de validação em algum dos campos do request.
        /// </summary>
        Validation,
        /// <summary>
        /// Conflito, client tentou realizar um cadastro porém já existe um registro com a mesma chave no banco de dados.
        /// </summary>
        Conflict,
        /// <summary>
        /// Registro não encontrado no banco de dados.
        /// </summary>
        NotFound,
        /// <summary>
        /// Client precisa realizar o login (jwt) para executar esta ação.
        /// </summary>
        Unauthorized,
        /// <summary>
        /// Client não possui as permissões necessárias para executar esta ação
        /// </summary>
        Forbbiden,
        /// <summary>
        /// Erro interno inesperado que está sendo tratado pela API.
        /// Este erro será registrado no log.
        /// </summary>
        Internal,
    }
}
