using Calendar.Core.ValueObjects;

namespace Calendar.Core.Exceptions;

public sealed class NoEventPolicyFoundException : CustomException
{
    public NoEventPolicyFoundException(Role role) : base($"Did not find any policy for {role}")
    {
    }
}