using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Exceptions;

namespace Shared.Abstractions.Api
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : BaseController
    {
        public IActionResult Errors(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
 