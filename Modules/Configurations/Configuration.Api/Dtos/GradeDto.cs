

namespace Api.Dtos
{
    public record GradeDtos(int Id,string Name,
      double MinExperienceRequired,double MaxExperienceRequired,string SalaryStructurePayBand);
    public record CreateGradeDtos(string Name,double MinExperienceRequired,
    double MaxExperienceRequired,int salaryStructureId,int fieldOfStudyId);
    public record ReadGradeDetailDto(int Id,string Name,
    FieldOfStudyDtos? FieldOfStudyDtos,
    double MinExperienceRequired,double MaxExperienceRequired,
     IEnumerable<PositionDto> Position,SalaryStructureDtos SalaryStructure);

      public record ReadGradeDto(int Id,string Name,int FieldOfStudyId,
      double MinExperienceRequired,double MaxExperienceRequired,int SalaryStructureId);
    
}
