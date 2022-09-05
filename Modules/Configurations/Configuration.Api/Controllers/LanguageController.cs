

using Api.Dtos;
using Domains.Directory;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions.Api;
using Shared.Abstractions.DataAccess;

namespace Api.Controllers
{
    internal class LanguageController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public LanguageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateLanguageDtos createDtos){
            var create =new Language()
            {
              Name =createDtos.LanguageName,
            };

            unitOfWork.Repository<Language>().Add(create);
            await  unitOfWork.Complete();
            return CreatedAtAction("Success",new LanguageDtos(create.Id,create.Name));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(LanguageDtos language,int id){
            
            Language updateLanguage = new Language()
            {
                Id = language.id,
                Name = language.LanguageName,
            };
            
            unitOfWork.Repository<Language>().Update(updateLanguage, id);

            await unitOfWork.Complete();
            return Ok(updateLanguage); 
        }        
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDtos>>> GetAsync(){
            var result = await unitOfWork.Repository<Country>().GetAllListAsync();
              var read = result.Select(c => new LanguageDtos(
                c.Id,
                c.Name                
              )).ToList();
              return Ok(read);
        }
        
    }
}