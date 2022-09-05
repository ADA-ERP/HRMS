using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record LanguageDtos(int id, string LanguageName);
    public record CreateLanguageDtos([Required] string LanguageName);
}