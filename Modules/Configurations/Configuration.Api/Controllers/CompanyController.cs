

using Api.Dtos;
using Domains.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Exceptions;

namespace Api.Controllers
{
    internal class CompanyController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadCompanyDtos>> GetCompanyAsync()
        {

            var results = await unitOfWork.Repository<Company>().GetAllListAsync();

            var result = results.FirstOrDefault();

            if (result is null) return NotFound(new ApiResponse(404));
            var company = new ReadCompanyDtos(result.Id, result.Name, result.Description, result.LogUrl,
                        result.TinNumber, result.PhoneOne, result.PhoneTwo);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostCompany(CreateCompanyDtos createCompanyDtos)
        {

            var results = await unitOfWork.Repository<Company>().GetAllListAsync();

            var company = results.FirstOrDefault();
            if (company is null)
            {
                company = new Company(createCompanyDtos.Name,
                            createCompanyDtos.Description,
                            createCompanyDtos.LogUrl,
                            createCompanyDtos.TinNumber,
                            createCompanyDtos.PhoneOne,
                            createCompanyDtos.PhoneTwo);

                unitOfWork.Repository<Company>().Add(company);

            }
            else
            {
                company.Name = createCompanyDtos.Name;
                company.Description = createCompanyDtos.Description;
                company.LogUrl = createCompanyDtos.LogUrl;
                company.TinNumber = createCompanyDtos.TinNumber;
                company.PhoneOne = createCompanyDtos.PhoneOne;
                company.PhoneTwo = createCompanyDtos.PhoneTwo;

                unitOfWork.Repository<Company>().Update(company, company.Id);
            }


            await unitOfWork.Complete();
            return CreatedAtAction("Created Successfully!.", company);

        }
    }
}