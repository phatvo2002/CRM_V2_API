using CRM.Application.Common.Interface.SystemManagement.Department;
using CRM.Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repository.SystemManagement.Department
{
    public class DepartmentRepository : BaseRepository<CrmDbContext, PhongBan>, IDepartmentRepository
    {
        public DepartmentRepository(CrmDbContext context) : base(context)
        {
        }
    }
}
