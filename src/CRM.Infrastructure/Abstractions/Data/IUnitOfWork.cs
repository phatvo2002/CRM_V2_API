using CRM.Infrastructure.Repository.SystemManagements.User;


namespace CRM.Application.Common.Abstractions.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

    }
}
