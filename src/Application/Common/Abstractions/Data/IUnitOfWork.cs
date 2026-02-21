using CRM.Application.Repository.SystemManagements.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Common.Abstractions.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

    }
}
