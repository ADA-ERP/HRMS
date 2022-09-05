using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record ReadDepartment(int Id, string Code, string Description);
    public record CreateDepartmentDtos([Required] string Code, [Required] string Description, string? ParentCode);
    public record UpdateBranch(int Id, int BranchId);
    public record updateParent(int Id, int ParentId);
    public record UpdateDescription(int Id, string Description);
    public record ReadDepartmentDtos(int Id, string Code, string Description, ReadDepartment? parentDepartement);

}

