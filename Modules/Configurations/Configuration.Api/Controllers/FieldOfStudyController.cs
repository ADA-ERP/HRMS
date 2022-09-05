
using Api.Dtos;
using Core.Directory;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace API.Controllers
{
    internal class FieldOfStudyController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public FieldOfStudyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync( CreateFieldOfStudyDtos fieldOfStudy)
        {
            var _fieldOfStudy = new FieldOfStudy(){
                Name = fieldOfStudy.Name
            };

            unitOfWork.Repository<FieldOfStudy>().Add(_fieldOfStudy);
           
            await unitOfWork.Complete();
           
            return CreatedAtAction("Successfull",_fieldOfStudy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync( CreateFieldOfStudyDtos fieldOfStudy,int id)
        {
            var _fieldOfStudy = new FieldOfStudy(){
                Id = id,
                Name = fieldOfStudy.Name
            };

            unitOfWork.Repository<FieldOfStudy>().Update(_fieldOfStudy,id);

            await unitOfWork.Complete();
            
            return CreatedAtAction("Successfull",_fieldOfStudy);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldOfStudy>>> GetFieldOfStudyAsync()
        {
            var result = await unitOfWork.Repository<FieldOfStudy>().GetAllListAsync();
            var _fieldOfStudys = result.Select(f=>new FieldOfStudyDtos(f.Id,f.Name));

            return Ok(_fieldOfStudys);
        }
    }
}