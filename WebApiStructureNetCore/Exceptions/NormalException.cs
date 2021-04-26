using WebApiStructureNetCore.Enums;

namespace WebApiStructureNetCore.Exceptions
{
    public class NormalException : CustomException
    {
        public NormalException(string message)
            : base(ExceptionTypesEnum.Normal, 400, message)
        {
        }
    }
}
