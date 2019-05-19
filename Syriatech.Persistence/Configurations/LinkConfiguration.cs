using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Persistence.Configurations
{
   public  class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.Property(e => e.LinkId).ValueGeneratedNever();
            builder.Property(e => e.Value)
                .IsRequired();
            builder.Property(e => e.Value)
               .IsRequired();
            builder.Property(e => e.CreatedBy)
             .IsRequired(); 
        }
    }
}
