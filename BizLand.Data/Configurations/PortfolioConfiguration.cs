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
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        

        void IEntityTypeConfiguration<Portfolio>.Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.ImageUrl).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Category).WithMany(p => p.Portfolios);
        }
    }
}
