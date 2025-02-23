namespace Calendar.Infrastructure.DAL;

internal interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}