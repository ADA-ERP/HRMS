
using Api.Dtos;
using AutoMapper;
using Core.Domains.Position;
using Domains.Directory;

namespace Configuration.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          //country
           CreateMap<Country,ReadCountryDtos>().ReverseMap();
          //position
           CreateMap<JobPosition,PositionDto>()
           .ForCtorParam("PositionName",o=>o.MapFrom(s=>s.Name));
           //grade
           CreateMap<JobGrade,GradeDtos>()           
           .ForMember(j=>j.SalaryStructurePayBand,s=>s.MapFrom(p=>p.SalaryStructure.PayBand)).ReverseMap();
           

           
           CreateMap<JobGrade,ReadGradeDto>()
           .ForMember(j=>j.SalaryStructureId,s=>s.MapFrom(p=>p.SalaryStructure.Id))
           .ForMember(f=>f.FieldOfStudyId,s=>s.MapFrom(o=>o.FieldOfStudy));

           //salary structure
           CreateMap<CreateSalaryStructureDtos,SalaryStructure>();
           CreateMap<SalaryStructure,SalaryStructureDtos>();
        
        }
    }


}
