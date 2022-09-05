using Api.Dtos;
using AutoMapper;
using Core.Specifications;
using Core.Domains.Position;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Exceptions;
namespace Api.Controllers
{
    internal class GradeController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GradeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GradeDtos>>> GetAsync()
        {
            var result = await unitOfWork.Repository<JobGrade>()
            .GetAllBySpecification(new JobGradeWithSalaryStructureSpecification());
             var readGradeDto=  mapper.Map<IReadOnlyList<JobGrade>, IReadOnlyList<GradeDtos>>(result);
            return Ok(readGradeDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadGradeDto>> GetAsync(int id)
        { 
            
            var result = await unitOfWork.Repository<JobGrade>()
            .GetBySpecificationAsync(new JobGradeWithSalaryStructureSpecification(i=>i.Id ==id));    
            if(result is null ) return NotFound(new ApiResponse(404));
            var readGradeDto = new ReadGradeDto(result.Id,result.Name,result.FieldOfStudy,result.MinExperienceRequired
            ,result.MaxExperienceRequired,result.SalaryStructure.Id) ;      
            return Ok(readGradeDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateGradeDtos grade){
           
            var salaryStructure = await unitOfWork.Repository<SalaryStructure>().GetByIdAsync(grade.salaryStructureId);
            if(salaryStructure is null) return NotFound(new ApiResponse(404,"Salary structure for this grade doesn't exist"));
            
            JobGrade jobGrade = new JobGrade(grade.Name,
                                             grade.fieldOfStudyId,
                                             grade.MinExperienceRequired,
                                             grade.MaxExperienceRequired,
                                             salaryStructure);

            unitOfWork.Repository<JobGrade>().Add(jobGrade);
            await unitOfWork.Complete();

            return CreatedAtAction(nameof(GetAsync),new {id = jobGrade.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(CreateGradeDtos grade,int id){
           
            var _grade = await unitOfWork.Repository<JobGrade>().GetByIdAsync(id);
            if(grade is null) return NotFound(new ApiResponse(404));
            
            var salaryStructure = await unitOfWork.Repository<SalaryStructure>().GetByIdAsync(grade.salaryStructureId);
            if(salaryStructure is null) return NotFound(new ApiResponse(404,"Salary structure for this grade doesn't exist"));
            
            _grade.UpdateJobGrade (grade.Name,
                                grade.fieldOfStudyId,
                                salaryStructure,
                                grade.MinExperienceRequired,
                                grade.MaxExperienceRequired
                                );

            unitOfWork.Repository<JobGrade>().Update(_grade,id);
            await unitOfWork.Complete();

            return CreatedAtAction(nameof(GetAsync),new {id = id});
        }
    }
}