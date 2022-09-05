using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record FieldOfStudyDtos(int Id,string Name);
    public record CreateFieldOfStudyDtos([Required] string Name);
}