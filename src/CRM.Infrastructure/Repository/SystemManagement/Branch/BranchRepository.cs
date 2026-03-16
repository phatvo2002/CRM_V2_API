using CRM.Application.Common.Interface;
using CRM.Application.Common.Interface.SystemManagement.Branch;
using CRM.Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repository.SystemManagement.Branch
{
    internal class BranchRepository : BaseRepository<CrmDbContext, ChiNhanh>, IBranchRepository
    {
        public BranchRepository(CrmDbContext context) : base(context)
        {
        }
    }
}
