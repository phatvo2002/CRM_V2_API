using CRM.Application.Common.Interface.SystemManagement.Menus;
using CRM.Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repository.SystemManagement.Menus
{
    public class MenuRepository : BaseRepository<CrmDbContext, Menu>, IMenuRepository
    {
        public MenuRepository(CrmDbContext context) : base(context)
        {
        }
    }
}
