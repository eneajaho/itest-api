using System.Security.Cryptography;
using System.Text;
using iTestApi.Entities;
using iTestApi.Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace iTestApi.Services;

public class AuthService
{
    private readonly DataContext _context;
    
    public AuthService(DataContext context)
    {
        _context = context;
    }

    public async Task Register(User user, string password)
    {
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> Login(string email, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

        if (user == null)
            return null;

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

        return user;
    }

    public async Task<bool> UserExists(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
    }
}