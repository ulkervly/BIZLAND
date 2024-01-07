using BizLand.Core.Entities;
using BizLand.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions) { }
        

        public DbSet<Services> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
