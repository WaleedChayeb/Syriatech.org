using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syriatech.Domain.Entities;

namespace Syriatech.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.EventId).ValueGeneratedNever(); 
            builder.Property(e => e.Organizer)
                .IsRequired()
                .HasMaxLength(100); 
            builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(100); 
            builder.Property(e => e.Url)
             .IsRequired(); 
            builder.Property(e => e.StartDate)
             .IsRequired();
        }
    }
}
