namespace WebApiStructureNetCore.Models
{
    public class CustomExceptionResponse
    {
        public short TipoErro { get; set; }
        public string Mensagem { get; set; }
        public string Id { get; set; }
    }
}
