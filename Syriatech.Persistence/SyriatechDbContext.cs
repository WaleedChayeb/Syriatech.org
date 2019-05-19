using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System; 

namespace Syriatech.Persistence
{
    public class SyriatechDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User>, ISyriatechDbContext
    {

        public SyriatechDbContext(DbContextOptions<SyriatechDbContext> options)
    : base(options)
        {
        } 

        public DbSet<Event> Events { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Project> Projects { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SyriatechDbContext).Assembly);
        }
    }

 
}
