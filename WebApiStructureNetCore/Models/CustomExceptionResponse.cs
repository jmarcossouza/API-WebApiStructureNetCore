using System.Collections.Generic;

namespace WebApiStructureNetCore.Models
{
    public class CustomExceptionResponse
    {
        public short TipoErro { get; set; }
        public string Mensagem { get; set; }
        public string Id { get; set; }
        public IEnumerable<DetailsObjectExcpetion> Erros { get; set; }
    }
}
