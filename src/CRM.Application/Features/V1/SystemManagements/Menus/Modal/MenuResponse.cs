using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Menus.Modal
{
    internal class MenuResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public int? OrderNumber { get; set; }
        public bool? IsActive { get; set; }
        public Guid? ParentId { get; set; }
    }
}
