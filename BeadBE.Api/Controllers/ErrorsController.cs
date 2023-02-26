using BeadBE.Application.Common.Interfaces.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BeadBE.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error-development")]
        [ApiExplorerSettings(IgnoreApi = true)]

        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, title) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.Message),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error ocurred")
            };

            return Problem(statusCode: statusCode, title: title);
        }
    }
}
