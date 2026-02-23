using CRM.Infrastructure.Repository.SystemManagements.User;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Common.Abstractions.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrmDbContext _context;
        public UnitOfWork(CrmDbContext context) { 
              _context = context;   
        }

        private IUserRepository? _userRepository;   
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);


        private bool _disposed = false;
        public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
