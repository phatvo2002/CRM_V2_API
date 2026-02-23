using CRM.Application.Common.Interface.SystemManagement.User;
using CRM.Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repository.SystemManagement.User
{
    public class UserRepository : BaseRepository<CrmDbContext, Nguoidung>, IUserRepository
    {
        public UserRepository(CrmDbContext context) : base(context)
        {
        }
    }
}
