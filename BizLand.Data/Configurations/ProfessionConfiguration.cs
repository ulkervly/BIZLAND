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
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        

        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

        }
    }
}
