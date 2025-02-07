namespace PetProject.Core.Abstractions;

public interface IClock
{
    DateTimeOffset Current();
}