namespace FamilyPlanner_Api.Models.Users;

public static class UserExtensions
{
    public static void UpdateToUser(this User user, UpdateUserDto updateUserDto, string authorUsername)
    {
        user.Email = updateUserDto.Email;
        user.UserName = updateUserDto.UserName;
        user.UpdatedBy = authorUsername;
        user.UpdatedOn = DateTime.UtcNow;
    }

    public static void CreateToUser(this User user, CreateUserDto createUserDto)
    {
        user.Id = createUserDto.Id;
        user.Email = createUserDto.Email;
        user.UserName = createUserDto.UserName;
        user.CreatedBy = createUserDto.Id;
        /* CreatedOn field is set to Datetime.UtcNow by default in BaseModel.cs */
    }
}