using CRM.Application.Common.Interface.SystemManagement.Role;
using CRM.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repository.SystemManagement.Role
{
    public class RoleRepostitory : BaseRepository<CrmDbContext, IdentityRole<Guid>>, IRoleRepository
    {
        public RoleRepostitory(CrmDbContext context) : base(context)
        {
        }
    }
}
