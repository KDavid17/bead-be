using BeadBE.Api.Common.Http;
using BeadBE.Application.Common.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BeadBE.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(ServiceError error)
        {
            if (error.Errors.Any())
            {
                return HandleValidationProblem(error.Errors);
            }

            return HandleProblem(error);
        }

        private IActionResult HandleProblem(ServiceError error)
        {

            return Problem(statusCode: (int?)error.StatusCode ?? 500, title: error.Title);
        }

        private IActionResult HandleValidationProblem(List<ValidationError> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Property,
                    error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}
