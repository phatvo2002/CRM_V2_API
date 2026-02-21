using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Repository.SystemManagements.User
{
    internal class UserRepository : BaseRepository<CrmDbContext, Nguoidung>, IUserRepository
    {
        public UserRepository(CrmDbContext context) : base(context)
        {
        }
    }
}
