

using Microsoft.AspNetCore.Mvc;

namespace Shared.Abstractions.Api
{
    [Route("api/v0/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
