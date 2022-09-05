

using Api.Dtos;
using AutoMapper;
using Core.Domains.Position;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Exceptions;

namespace Api.Controllers
{
    internal class SalaryStructureController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SalaryStructureController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateSalaryStructureDtos createSalary)
        {

            var structure = mapper.Map<CreateSalaryStructureDtos, SalaryStructure>(createSalary);
            unitOfWork.Repository<SalaryStructure>().Add(structure);
            await unitOfWork.Complete();

            return CreatedAtAction(nameof(GetAsync), new { id= structure.Id },new Object{});
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SalaryStructureDtos>>> GetAsync()
        {
            var result = await unitOfWork.Repository<SalaryStructure>().GetAllListAsync();
            var structures = mapper.Map<IReadOnlyList<SalaryStructure>, IReadOnlyList<SalaryStructureDtos>>(result);

            return Ok(structures);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryStructureDtos>> Get(int id)
        {
            var result = await unitOfWork.Repository<SalaryStructure>().GetByIdAsync(id);
            var structure = mapper.Map<SalaryStructure, SalaryStructureDtos>(result);
            if (structure is null) return NotFound(new ApiResponse(404));
            return Ok(structure);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SalaryStructureDtos>> PutAsync(CreateSalaryStructureDtos ups, int id)
        {

            var result = await unitOfWork.Repository<SalaryStructure>().GetByIdAsync(id);
            if (result is null) return NotFound(new ApiResponse(404));
            result.UpdateSalaryStructure(ups.PayBand, ups.Minimum, ups.Midpoint, ups.Maximum, ups.Spread, ups.Range, ups.Note);
            await unitOfWork.Complete();
            var structure = mapper.Map<SalaryStructure, SalaryStructureDtos>(result);

            return CreatedAtAction(nameof(GetAsync), new { id = structure.Id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaryStructureDtos>> DeleteAsync(int id)
        {
            var result = await unitOfWork.Repository<SalaryStructure>().GetByIdAsync(id);
            if (result is null) return NotFound(new ApiResponse(404));

            unitOfWork.Repository<SalaryStructure>().Delete(result);
          
            await unitOfWork.Complete();
           
            return Ok();
        }
    }
}