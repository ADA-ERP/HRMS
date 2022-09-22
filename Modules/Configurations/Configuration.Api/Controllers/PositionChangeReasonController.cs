using Core.Domains.Position;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace Configuration.Api.Controllers
{
    internal class PositionChangeReasonController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public PositionChangeReasonController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PositionChangeReason>>> GetAsync(){
            var result = await unitOfWork.Repository<PositionChangeReason>().GetAllListAsync();
            return Ok(result);
        }
    }
}