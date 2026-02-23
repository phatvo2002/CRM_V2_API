using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repository
{
    public class BasePaginationEntity<TEntity> where TEntity : class
    {
        public long Total { get; set; }
        public int TotalPages { get; set; }
        public List<TEntity>? Data { get; set; }
    }
}
