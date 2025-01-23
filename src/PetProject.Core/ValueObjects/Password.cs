using PetProject.Core.Exceptions;

namespace PetProject.Core.ValueObjects;

public sealed record Password
{
    private string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidPasswordException();
        if (value.Length < 8)
            throw new PasswordIsTooShortException();
        
        Value = value;
    }
    
    public static implicit operator string(Password password) => password.Value;
    public static implicit operator Password(string password) => new(password);
    public override string ToString() => Value;
}