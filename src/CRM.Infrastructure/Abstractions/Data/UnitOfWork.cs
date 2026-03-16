

using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Common.Interface.SystemManagement.Branch;
using CRM.Application.Common.Interface.SystemManagement.Role;
using CRM.Application.Common.Interface.SystemManagement.User;
using CRM.Infrastructure.Persistence;
using CRM.Infrastructure.Repository.SystemManagement.Branch;
using CRM.Infrastructure.Repository.SystemManagement.Role;
using CRM.Infrastructure.Repository.SystemManagement.User;

namespace CRM.Infrastructure.Abstractions.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrmDbContext _context;
        public UnitOfWork(CrmDbContext context) { 
              _context = context;   
        }

        private bool _disposed = false;

        private IUserRepository _userRepository;
        public IUserRepository UserRepository 
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        private IRoleRepository _roleRepository;
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepostitory(_context);
                }
                return _roleRepository;
            }   
        }

        private IBranchRepository _branchRepository;
        public IBranchRepository BranchRepository
        {
            get
            {
                if (_branchRepository == null)
                {
                    _branchRepository = new BranchRepository(_context);
                }
                return _branchRepository;
            }
        }

        public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
