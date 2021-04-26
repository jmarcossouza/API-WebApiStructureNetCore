using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiStructureNetCore.Data;
using WebApiStructureNetCore.Entities;
using WebApiStructureNetCore.Exceptions;

namespace WebApiStructureNetCore.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly WebapiStructureDbContext _context;
        public ErrorController(IConfiguration configuration, WebapiStructureDbContext context)
        {
            Configuration = configuration;
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
            if (Configuration.GetValue<bool>("Logs:Errors"))
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
}

