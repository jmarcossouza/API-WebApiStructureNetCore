using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApiStructureNetCore.Exceptions;

namespace WebApiStructureNetCore.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)] // Para o swagger ignorar esse method
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context.Error.GetType().IsSubclassOf(typeof(CustomException)))
            {
                CustomException error = (CustomException)context.Error;
                return StatusCode(error.StatusCode, error.GetResponse());
            }
            var unexpectedException = new UnexpectedException(context.Error);
            //log
            return StatusCode(unexpectedException.StatusCode, unexpectedException.GetResponse());
        }
    }
}

