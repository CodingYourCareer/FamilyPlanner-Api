using FamilyPlanner_Api.Data;
using FamilyPlanner_Api.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.Serialization;
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


    public async Task<User> CreateUser(CreateUserDto createUserDto)
    {
        User newUser = new User();
        newUser.CreateToUser(createUserDto);

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        return newUser;
    }


    public async Task<User?> UpdateUser(string id, UpdateUserDto updateUserDto, string authorId)
    {
        User? user = await _dbContext.Users.FindAsync(id);

        if (user is null)
        {
            return null;
        }

        user.UpdateToUser(updateUserDto, authorId);

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }


    public async Task DeleteUser(string id)
    {
        User? user = await _dbContext.Users.FindAsync(id);

        if (user is null)
        {
            throw new UserNotFoundException($"User '{id}' was not found");
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}
