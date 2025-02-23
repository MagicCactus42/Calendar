using Calendar.Core.Exceptions;

namespace Calendar.Core.ValueObjects;
 
 public sealed class Role
 {
     public static IEnumerable<string> AvailableRoles { get; } = new[] { "owner", "user" };
     public string Value { get; }
     
     public Role(string value)
     {
         if (string.IsNullOrWhiteSpace(value) || value.Length > 6)
             throw new InvalidRoleException(value);
         if (!AvailableRoles.Contains(value))
             throw new InvalidRoleException(value);
         
         Value = value.ToLower();
     }
     
     public static Role Owner() => new("owner");
     public static Role User() => new("user");
     public static implicit operator string(Role role) => role.Value;
     public static implicit operator Role(string role) => new(role);
     public override string ToString() => Value;
 }