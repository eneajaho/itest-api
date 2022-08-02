using iTestApi.Helpers;

namespace iTestApi.DTOs.Package
{
    public class GetPackagesParams : PaginationParams
    {
        public string? Name { get; set; }
        public int? UserId { get; set; }
    }
}