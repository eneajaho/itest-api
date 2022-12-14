using AutoMapper;
using AutoMapper.QueryableExtensions;
using iTestApi.DTOs.User;
using iTestApi.Entities;
using iTestApi.Entities.Core;
using iTestApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace iTestApi.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public async Task<PagedData<UserDto>> GetUsersAsync(GetUsersParams userParams, int currentUserId)
        {
            var users = _context.Users
                // we directly map to UserDto so we don't query data we don't use
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                // make sure query doesn't return authenticated user
                .Where(x => x.Id != currentUserId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(userParams.Name))
                users = users.Where(x => x.Name.Contains(userParams.Name));

            if (userParams.Role != null)
                users = users.Where(x => x.Role == userParams.Role);

            // userParams inherits from PaginationParams
            return await PagedData<UserDto>.CreateAsync(users, userParams);
        }

        // Will be used when we need the whole User entity (ex. on edit)
        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);

        public async Task<UserDto?> GetUserByIdAsync(int id) =>
            await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(u => u.Id == id);
    }
}