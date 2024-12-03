namespace FamilyPlanner_Api.Models.Users;

public class UserNotFoundException : Exception
{
    public override string Message { get; }

    public UserNotFoundException(string message)
        : base(message)
    {
        Message = message;
    }

    public UserNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        Message = message;
    }
}
