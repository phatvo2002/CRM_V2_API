using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Permissions
    {
        public Guid Id { get; set; }
        public string Module { get; set; } = default!;   
        public string Action { get; set; } = default!;  
        public string Name { get; set; } = default!;  
        public string? Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
            = new List<RolePermission>();

    }
}
