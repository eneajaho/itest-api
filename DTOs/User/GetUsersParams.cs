using iTestApi.Entities;
using iTestApi.Helpers;

namespace iTestApi.DTOs.User;

public class GetUsersParams : PaginationParams
{
    public string? Name { get; set; }
    public Role? Role { get; set; }
}