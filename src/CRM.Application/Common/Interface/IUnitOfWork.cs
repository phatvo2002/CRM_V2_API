

using CRM.Application.Common.Interface.SystemManagement.Branch;
using CRM.Application.Common.Interface.SystemManagement.Role;
using CRM.Application.Common.Interface.SystemManagement.User;

namespace CRM.Application.Common.Abstractions.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IBranchRepository BranchRepository { get; }
    }
}
