using Calendar.Core.ValueObjects;

namespace Calendar.Core.Entities;

public class User
{
    public UserId UserId { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Username Username { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Role Role { get; private set; }

    public User(UserId userId, Email email, Password password, Username username, DateTime createdAt, Role role)
    {
        UserId = userId;
        Email = email;
        Password = password;
        Username = username;
        CreatedAt = createdAt;
        Role = role;
    }
}