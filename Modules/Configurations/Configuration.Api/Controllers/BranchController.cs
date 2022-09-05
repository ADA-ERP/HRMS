


using Api.Dtos;
using Core.Domains.Configuration;
using Core.Specifications;
using Domains.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Exceptions;

namespace  Api.Controllers
{
    internal class BranchController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public BranchController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateBranchDtos createBranchDtos)
        {
            var createdBranch = new Branch() { Name = createBranchDtos.Name };
            unitOfWork.Repository<Branch>().Add(createdBranch);
            await unitOfWork.Complete();
            return CreatedAtAction("success", new ReadBranchDtos(createdBranch.Id, createdBranch.Name));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await unitOfWork.Repository<Branch>().GetBySpecificationAsync(new BranchAndDepartmentSpecification(b => b.Id == id));
            if (result is null) return NotFound(new ApiResponse(404));
            unitOfWork.Repository<Branch>().Delete(result);
            await unitOfWork.Complete();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadBranchDtos>>> GetBranchAsync()
        {
            var result = await unitOfWork.Repository<Branch>().GetAllListAsync();
            var readBranches = result.Select(b => new ReadBranchDtos(
              b.Id,
              b.Name
            )).ToList();
            return Ok(readBranches);
        }

        [HttpGet("Department")]
        public async Task<ActionResult<IEnumerable<ReadBranchWithDepartmentDtos>>> GetBranchAndDepartmentAsync()
        {

            var result = await unitOfWork.Repository<Branch>().GetAllBySpecification(new BranchAndDepartmentSpecification());
            var readBranches = result.Select(b => new ReadBranchWithDepartmentDtos(
              b.Id,
              b.Name,
              b.Departments.Select(d => new ReadDepartmentDtos(
                  d.Id,
                  d.Code,
                  d.Description,
                  GetParentDepartment(d.ParentCode, b.Departments)
              ))
            )).ToList();
            return Ok(readBranches);
        }

        private ReadDepartment? GetParentDepartment(string? parentCode, IReadOnlyCollection<Department> result)
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