using DuckDuckGo.Application.Exceptions;
using DuckDuckGo.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DuckDuckGoProxy.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; 
            var code = 500; // Internal Server Error by default

            if (exception is HttpStatusException httpException) code = (int)httpException.Status;

            Response.StatusCode = code; 

            return new ErrorResponse(exception); // Your error model
        }
    }
}
