using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record SalaryStructureDtos(int Id,string PayBand,decimal Minimum,decimal Midpoint,
    decimal Maximum,decimal Spread,decimal Range,string Note);
    public record CreateSalaryStructureDtos(string PayBand,decimal Minimum,decimal Midpoint,
    decimal Maximum,decimal Spread,decimal Range,string Note);
}
