

using Api.Dtos;
using AutoMapper;
using Domains.Directory;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace Api.Controllers
{
    internal class CountryController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CountryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateCountryDtos createDtos)
        {
            var create = new Country()
            {
                Name = createDtos.Name,
                AreaCode = createDtos.AreaCode,
                ISOCode = createDtos.ISOCode
            };

            unitOfWork.Repository<Country>().Add(create);
            await unitOfWork.Complete();
            return CreatedAtAction(nameof(GetAsync), new {id = create.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(CountryDtos country, int id)
        {

            Country updateCountry =  new Country()
            {
                Id = country.Id,
                Name = country.Name,
                AreaCode = country.AreaCode,
                ISOCode = country.ISOCode
            };

            unitOfWork.Repository<Country>().Update(updateCountry, id);

            await unitOfWork.Complete();
            return Ok(updateCountry);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await unitOfWork.Repository<Country>().GetByIdAsync(id);

            return Ok(mapper.Map<Country,CountryDtos>(result));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCountryDtos>>> GetCountriesAsync()
        {
            var result = await unitOfWork.Repository<Country>().GetAllListAsync();
            var read = mapper.Map<IReadOnlyList<Country>,IReadOnlyList<ReadCountryDtos>>(result);
            return Ok(read);
        }

    }
}