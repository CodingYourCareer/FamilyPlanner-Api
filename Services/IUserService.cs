using FamilyPlanner_Api.Models.Users;

namespace FamilyPlanner_Api.Services;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();

    public Task<User?> GetUserById(string id);
}
