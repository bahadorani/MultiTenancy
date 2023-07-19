using Microsoft.EntityFrameworkCore;
using Sample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Persistence.Context
{
    public class MultiTenantContext :DbContext
    {
        public DbSet<User> Users { get; set; } = default!;

        public MultiTenantContext(DbContextOptions<MultiTenantContext> options)
            : base(options)
        {
        }
    }
}
