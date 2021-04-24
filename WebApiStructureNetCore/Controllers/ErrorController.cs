using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiStructureNetCore.Data;
using WebApiStructureNetCore.Exceptions;
using WebApiStructureNetCore.Models;

namespace WebApiStructureNetCore.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly WebapiStructureDbContext _context;

        public ErrorController(WebapiStructureDbContext context)
        {
            _context = context;
        }

        [ApiExplorerSettings(IgnoreApi = true)] // Para o swagger ignorar esse method
        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            if (exception.GetType().IsSubclassOf(typeof(CustomException)))
            {
                if (exception.GetType().IsSubclassOf(typeof(LoggableException)))
                {
                    var loggableException = (exception as LoggableException);
                    LogErrorInDatabase(loggableException.CreateLogErrorsObj());
                    return StatusCode(loggableException.StatusCode, loggableException.GetResponse());
                }
                CustomException customException = (CustomException)exception;
                return StatusCode(customException.StatusCode, customException.GetResponse());
            }
            var unexpectedException = new UnexpectedException(exception);
            LogErrorInDatabase(unexpectedException.CreateLogErrorsObj());

            return StatusCode(unexpectedException.StatusCode, unexpectedException.GetResponse());
        }

        private void LogErrorInDatabase(LogErrors error)
        {
            try
            {
                _context.DetachAllEntities();
                _context.LogErrors.Add(error);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
    }
}

