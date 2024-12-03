using FamilyPlanner_Api.Models.Users;

namespace FamilyPlanner_Api.Services;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();

    public Task<User?> GetUserById(string id);
    public Task<User> CreateUser(CreateUserDto createUserDto);
    public Task<User?> UpdateUser(string id, UpdateUserDto updateUserDto, string authorId);
    public Task DeleteUser(string id);
}
