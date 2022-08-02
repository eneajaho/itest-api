namespace iTestApi.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; } = Role.Admin; // admin, user
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
        
    public DateTime CreatedAt { get; set; }
}