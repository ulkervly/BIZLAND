using BizLand.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Services>
    {
        void IEntityTypeConfiguration<Services>.Configure(EntityTypeBuilder<Services> builder)
        {
            builder.Property(x => x.İconUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
        }
    }
}
