using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record BankDtos(int Id,string Name);
    public record CreateBankDtos([Required] string Name);
}