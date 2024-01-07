using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLand.Core.Entities;

namespace BizLand.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(50);
            
           
            builder.Property(x => x.MediaUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.HasOne(x => x.Profession).WithMany(p => p.Employees);

        }
    }
}
