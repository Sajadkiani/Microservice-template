﻿using Product.Domain.Aggregates.Users;
using Product.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.EF.Stores;

public class UserStore : Repository<User, int>, IUserStore
{
    public UserStore(AppDbContext context) : base(context)
    {
    }
    
    public Task<User> GetByUserNameAsync(string userName)
    {
        return context.Users.Include(item => item.Tokens).FirstOrDefaultAsync(u => u.UserName == userName)!;
    }
    
    public Task AddUserAsync(User user)
    {
        return context.Users.AddAsync(user).AsTask();
    }

    public Task<List<Role>> GetUserIncludeRolesAsync(int userId)
    {
        return context.Users
            .Where(item => item.Id == userId)
            .SelectMany(item => item.UserRoles).Select(item => item.Role)
            .ToListAsync();
    }

    public Task<User> GetTokenByRefreshAsync(string refreshToken)
    {
        return context.Users.Include(u => u.Tokens.Where(item => item.RefreshToken == refreshToken))
            .FirstOrDefaultAsync()!;
    }
}