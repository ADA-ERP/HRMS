

using Core.Domains;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace Api.Controllers
{
    internal class KeyValueController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public KeyValueController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<KeyValue>>> GetAsync(){
            var result = await unitOfWork.Repository<KeyValue>().GetAllListAsync();
            return Ok(result);
        }
    }
}