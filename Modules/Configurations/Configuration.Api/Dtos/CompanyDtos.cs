namespace Api.Dtos
{
    public record CreateCompanyDtos(string Name,string Description,string LogUrl,string TinNumber,string PhoneOne,string PhoneTwo);
    public record ReadCompanyDtos(int Id,string Name,string Description,string LogUrl,string TinNumber,string PhoneOne,string PhoneTwo);
    
}