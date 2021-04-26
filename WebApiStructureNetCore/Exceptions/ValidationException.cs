using WebApiStructureNetCore.Enums;

namespace WebApiStructureNetCore.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(string message)
            : base(ExceptionTypesEnum.Validation, 400, message)
        {
        }
    }
}
