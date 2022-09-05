using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record PositionDto(int Id,string? PositionCode,string? PositionName,string? Description,int GradeId);
    public record CreatePositionDto([Required]string PositionCode,[Required]string PositionName,string Description);
    public record UpdatePositionDto(int Id,string PositionCode,string PositionName,string Description,int GradeId);
    
    public record ReadPositionDto(int Id,string PositionCode,string PositionName,string Description,int GradeId,string GradeName);
}
