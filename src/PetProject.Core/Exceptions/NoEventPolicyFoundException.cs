using PetProject.Core.ValueObjects;

namespace PetProject.Core.Exceptions;

public sealed class NoEventPolicyFoundException : CustomException
{
    public NoEventPolicyFoundException(Role role) : base($"Did not find any policy for {role} was found")
    {
    }
}