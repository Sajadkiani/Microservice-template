﻿using Product.Domain.SeedWork;

namespace Product.Domain.Aggregates.Users;

public interface IUserStore : IRepository<User, int>
{
    Task<List<Role>> GetUserIncludeRolesAsync(int userId);
    Task<User> GetTokenByRefreshAsync(string refreshToken);
    Task<User> GetByUserNameAsync(string userName);
    Task AddUserAsync(User user);
}