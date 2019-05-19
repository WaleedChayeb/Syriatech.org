using Microsoft.EntityFrameworkCore;
using Syriatech.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Persistence
{
    public class SyriatechDbContextFactory : DesignTimeDbContextFactoryBase<SyriatechDbContext>
    {
        protected override SyriatechDbContext CreateNewInstance(DbContextOptions<SyriatechDbContext> options)
        {
            return new SyriatechDbContext(options);
        }
    }
}
