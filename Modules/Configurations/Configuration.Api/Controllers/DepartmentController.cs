using Api.Dtos;
using Core.Domains.Configuration;
using Core.Specifications;
using Domains.Configuration;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace Api.Controllers
{
    internal class DepartmentController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("{branchId}")]
        public async Task<IActionResult> Post(CreateDepartmentDtos createDepartmentDto, int branchId)
        {

            var spec = new BranchAndDepartmentSpecification(b => b.Id == branchId);

            var exitingBranch = await unitOfWork.Repository<Branch>().GetBySpecificationAsync(spec);

            if (exitingBranch is null)
                return NotFound(new { value = "Branch not found!, In order to create department branch is required!." });

            exitingBranch.AddDepartment(createDepartmentDto.Code, createDepartmentDto.ParentCode, createDepartmentDto.Description);
           
            await unitOfWork.Complete();
            return CreatedAtAction("Success", exitingBranch);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDepartmentDtos>>> GetDepartments()
        {
            var result = await unitOfWork.Repository<Department>().GetAllListAsync();
            var readDept = result.Select(d => new ReadDepartmentDtos(
              d.Id,
              d.Code,
              d.Description,
              GetParentDepartment(d.ParentCode, result)
            )).ToList();
            return Ok(readDept);
        }

        private ReadDepartment? GetParentDepartment(string? parentCode, IReadOnlyList<Department> result)
        {
            var parentDepartment = result.Where(d => d.Code == parentCode).FirstOrDefault();
            if (parentDepartment is null) return null;
            return new ReadDepartment(
               parentDepartment.Id,
               parentDepartment.Code,
               parentDepartment.Description
            );
        }

    
    }
}