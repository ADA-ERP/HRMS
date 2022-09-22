using System.Linq.Expressions;
using Core.Domains;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace Api.Controllers
{
    internal class TitleController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public TitleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Title>>> GetAsync()
        {
            var result = await unitOfWork.Repository<Title>().GetAllListAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(string Name)
        {
            var createTitle = new Title()
            {
                Name = Name,
            };
            unitOfWork.Repository<Title>().Add(createTitle);
            await unitOfWork.Complete();
            return CreatedAtAction(nameof(TitleController.Url.Action), createTitle);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string name, int id)
        {
            //if(string.IsNullOrEmpty(name))
            //TODO: validation code should be write here.

            var existTitle = await unitOfWork.Repository<Title>().GetByIdAsync(id);

            if (existTitle is null) return NotFound();

            var updateTitle = existTitle;
            updateTitle.Name = name;
            unitOfWork.Repository<Title>().Update(updateTitle, id);
            await unitOfWork.Complete();
            return Ok(updateTitle);
        }
    }

  
}

