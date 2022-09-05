using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record CountryDtos(int Id,[Required] string Name,[Required] string AreaCode,[Required] string ISOCode);
    public record CreateCountryDtos([Required] string Name,[Required] string AreaCode,[Required] string ISOCode);
    public record ReadCountryDtos(int Id,string Name,string AreaCode,string ISOCode);
    
}