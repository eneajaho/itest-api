using iTestApi.DTOs.User;

namespace iTestApi.DTOs.Package
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDto User { get; set; }
    }
}