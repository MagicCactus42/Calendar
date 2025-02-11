namespace PetProject.Infrastructure.Auth;

public class AuthOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SigningKey { get; set; }
    public TimeSpan? Expiry { get; set; }
}