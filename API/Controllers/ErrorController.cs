using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace API.Controllers
{
    public class ErrorController  : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
   
            if(ex is not null && SoyErrorDeValidacion(ex))
            {
                var details = DameErroresDeValidacion(ex);
                return ValidationProblem(details);
            }

            var (statusCode, message) = ex switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "Ha ocurrido un error no controlado")
            };

            return Problem(statusCode: statusCode, title: message);
        }

        private bool SoyErrorDeValidacion(Exception ex) 
            => ex.GetType().Name.Equals(typeof(Application.Common.Exceptions.ValidationException).Name);

        private static ValidationProblemDetails DameErroresDeValidacion(Exception ex)
        {
            ValidationException? validationException = ex as ValidationException;
            return new ValidationProblemDetails(validationException!.Errors);
        }

    }
}
