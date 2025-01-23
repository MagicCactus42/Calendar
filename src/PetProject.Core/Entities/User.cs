using PetProject.Core.ValueObjects;

namespace PetProject.Core.Entities;

public class User
{
    public UserId UserId { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public Username Username { get; set; }
    public DateTime CreatedAt { get; set; }

    public User(UserId userId, Email email, Password password, Username username, DateTime createdAt)
    {
        UserId = userId;
        Email = email;
        Password = password;
        Username = username;
        CreatedAt = createdAt;
    }
}