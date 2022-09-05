
using Api.Dtos;
using AutoMapper;
using Core.Domains.Position;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Exceptions;
namespace Api.Controllers
{

    internal class PositionController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PositionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpPost("Grade/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostAsync(CreatePositionDto createPosition, int id)
        {
            var spec = new JobGradeWithPositionAndSalaryStructureSpecification(x => x.Id == id);
            var _jobGrade = await unitOfWork.Repository<JobGrade>().GetBySpecificationAsync(spec);

            if (_jobGrade is null)
                return NotFound(new ApiResponse(404));

            _jobGrade.AddPosition(createPosition.PositionCode, createPosition.PositionName, createPosition.Description);

            await unitOfWork.Complete();

            return CreatedAtAction(nameof(GetPositionAsync), new { _jobGrade.Id }, new Object { });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadPositionDto>> GetPositionAsync(int id)
        {

            var position = await unitOfWork.Repository<JobPosition>().GetByIdAsync(id);

            if (position is null)
                return NotFound(new ApiResponse(404));

            return Ok(mapper.Map<JobPosition, PositionDto>(position));
        }

        [HttpGet("Grade/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetPositionByGradeAsync(int id)
        {
            var spec = new JobGradeWithPositionAndSalaryStructureSpecification(x => x.Id == id);
            var jobGrade = await unitOfWork.Repository<JobGrade>().GetBySpecificationAsync(spec);

            if (jobGrade is null)
                return NotFound(new ApiResponse(404));

            return Ok(mapper.Map<IEnumerable<JobPosition>, IEnumerable<PositionDto>>(jobGrade.Positions));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ReadPositionDto>>> GetPositions()
        {
            var positions = await unitOfWork.Repository<JobPosition>().GetAllListAsync();

            if (positions is null)
                return NotFound(new ApiResponse(404));

            List<ReadPositionDto> positionDtos = new List<ReadPositionDto>();
            foreach (var p in positions)
            {
                var grade = await unitOfWork.Repository<JobGrade>().GetByIdAsync(p.GradeId);
                positionDtos.Add(new ReadPositionDto(p.Id, p.PositionCode, p.Name, p.Description, p.GradeId, grade.Name));
            }
            return Ok(positionDtos);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePosition(int id)
        {
            var position = await unitOfWork.Repository<JobPosition>().GetByIdAsync(id);

            if (position is null)
                return NotFound(new ApiResponse(404));

            unitOfWork.Repository<JobPosition>().Delete(position);
            await unitOfWork.Complete();

            return Ok( position);
        }
    }
}
