using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(e => e.ProjectId).ValueGeneratedNever();
            builder.Property(e => e.CreateBy)
                .IsRequired();
            builder.Property(e => e.Title)
               .IsRequired();
            builder.Property(e => e.Url)
             .IsRequired();
        }
    }
}
