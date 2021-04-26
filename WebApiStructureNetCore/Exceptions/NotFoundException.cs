using WebApiStructureNetCore.Enums;

namespace WebApiStructureNetCore.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException()
            : base(ExceptionTypesEnum.NotFound, 404, "Não foram encontrados resultados.")
        {
        }

        public NotFoundException(string message)
            : base(ExceptionTypesEnum.NotFound, 404, message)
        {
        }
    }
}
