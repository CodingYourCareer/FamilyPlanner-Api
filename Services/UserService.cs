using FamilyPlanner_Api.Data;
using FamilyPlanner_Api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner_Api.Services;

public class UserService : IUserService
{
    private readonly FamilyDbContext _dbContext;

    public UserService(FamilyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(string id)
    {
        return await _dbContext.Users.FindAsync(id);
    }
}
