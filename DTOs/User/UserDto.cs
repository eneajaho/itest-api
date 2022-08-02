using iTestApi.Entities;

namespace iTestApi.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role Role { get; set; }
    }
}