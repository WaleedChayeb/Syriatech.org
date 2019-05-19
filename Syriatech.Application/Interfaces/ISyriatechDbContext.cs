using Microsoft.EntityFrameworkCore;
using Syriatech.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Interfaces
{
    public interface ISyriatechDbContext
    {
        DbSet<Event> Events { get; set; }
        DbSet<Link> Links { get; set; }
        DbSet<Project> Projects { get; set; } 

        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 

    }
}
