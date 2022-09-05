namespace Api.Dtos
{
    public record CreateBranchDtos(string Name);
    public record ReadBranchDtos(int Id,string Name);
    public record ReadBranchWithDepartmentDtos(int Id,string Name,IEnumerable<ReadDepartmentDtos> DepartmentDtos);
}